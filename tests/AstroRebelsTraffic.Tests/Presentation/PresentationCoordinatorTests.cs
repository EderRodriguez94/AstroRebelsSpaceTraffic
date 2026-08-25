using AstroRebelsTraffic.Domain.Events;
using AstroRebelsTraffic.Domain.State;
using AstroRebelsTraffic.Presentation.Gameplay.Coordination;

namespace AstroRebelsTraffic.Tests.Presentation;

public sealed class PresentationCoordinatorTests
{
    [Fact]
    public void Plays_events_in_order_and_rebuilds_once()
    {
        var coordinator = new PresentationCoordinator();
        var events = new DomainEvent[]
        {
            new ShipReleaseRejected("e1", new ShipId("ship"), "blocked-path"),
            new UndoApplied("e2", 0)
        };
        var displayed = new List<string>();
        var rebuilds = 0;

        Assert.True(coordinator.TryPlay(events, e => displayed.Add(e.EventId), instant: true, () => rebuilds++));
        Assert.Equal(new[] { "e1", "e2" }, displayed);
        Assert.Equal(1, rebuilds);
        Assert.True(coordinator.CanAcceptInput);
    }

    [Fact]
    public void A_second_tap_during_playback_is_rejected()
    {
        var coordinator = new PresentationCoordinator();
        var secondTapAccepted = true;
        var events = new DomainEvent[] { new UndoApplied("e1", 0) };

        Assert.True(coordinator.TryPlay(events, _ =>
        {
            secondTapAccepted = coordinator.TryPlay(events, _ => { }, instant: true);
        }, instant: false));

        Assert.False(secondTapAccepted);
        Assert.True(coordinator.CanAcceptInput);
    }

    [Fact]
    public void Terminal_events_keep_ship_input_locked()
    {
        var coordinator = new PresentationCoordinator();

        Assert.True(coordinator.TryPlay(
            new DomainEvent[] { new LevelWon("win", "level-1") },
            _ => { },
            instant: true));

        Assert.True(coordinator.TerminalOverlayVisible);
        Assert.False(coordinator.CanAcceptInput);
        Assert.False(coordinator.TryPlay(Array.Empty<DomainEvent>(), _ => { }, instant: true));
        coordinator.Reset();
        Assert.True(coordinator.CanAcceptInput);
    }

    [Fact]
    public void Interrupt_stops_non_terminal_playback_and_releases_input()
    {
        var coordinator = new PresentationCoordinator();
        var displayed = new List<string>();

        Assert.True(coordinator.TryPlay(
            new DomainEvent[]
            {
                new UndoApplied("e1", 0),
                new UndoApplied("e2", 1)
            },
            e =>
            {
                displayed.Add(e.EventId);
                coordinator.Interrupt();
            },
            instant: false));

        Assert.Equal(new[] { "e1" }, displayed);
        Assert.True(coordinator.WasInterrupted);
        Assert.True(coordinator.CanAcceptInput);
    }
}
