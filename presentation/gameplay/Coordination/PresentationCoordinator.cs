using AstroRebelsTraffic.Domain.Events;

namespace AstroRebelsTraffic.Presentation.Gameplay.Coordination;

/// <summary>
/// Serializes domain-event presentation and owns the input lock around it.
/// The domain state is already settled before this coordinator is called.
/// </summary>
public sealed class PresentationCoordinator
{
    private readonly List<DomainEvent> playedEvents = new();

    public bool InputLocked { get; private set; }
    public bool TerminalOverlayVisible { get; private set; }
    public bool WasInterrupted { get; private set; }
    public IReadOnlyList<DomainEvent> PlayedEvents => playedEvents;

    public bool CanAcceptInput => !InputLocked && !TerminalOverlayVisible;

    public bool TryPlay(
        IReadOnlyList<DomainEvent> events,
        Action<DomainEvent> apply,
        bool instant,
        Action? rebuildViews = null)
    {
        ArgumentNullException.ThrowIfNull(events);
        ArgumentNullException.ThrowIfNull(apply);

        if (!CanAcceptInput)
            return false;

        InputLocked = true;
        WasInterrupted = false;
        playedEvents.Clear();

        try
        {
            // Both modes consume the same ordered domain events. The view layer
            // may animate inside apply; instant mode simply skips that animation.
            _ = instant;
            foreach (var domainEvent in events)
            {
                if (WasInterrupted)
                    break;

                apply(domainEvent);
                playedEvents.Add(domainEvent);

                if (domainEvent is LevelWon or RealDeadlockDetected)
                    TerminalOverlayVisible = true;
            }

            rebuildViews?.Invoke();
            return true;
        }
        finally
        {
            // A terminal result remains locked until the owning screen restarts
            // or dismisses the result. Interrupted non-terminal playback safely
            // returns control to the screen.
            InputLocked = TerminalOverlayVisible;
        }
    }

    public void Interrupt()
    {
        if (InputLocked && !TerminalOverlayVisible)
            WasInterrupted = true;
    }

    public void Reset()
    {
        InputLocked = false;
        TerminalOverlayVisible = false;
        WasInterrupted = false;
        playedEvents.Clear();
    }
}
