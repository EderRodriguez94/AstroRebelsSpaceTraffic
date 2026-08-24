using AstroRebelsTraffic.Domain.Commands;
using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Application.GameSession;

public sealed class GameSession
{
    private readonly object gate = new();
    private GameState state;
    private bool commandInFlight;

    public GameSession(GameState initialState) => state = initialState;
    public GameState State { get { lock (gate) return state; } }

    public CommandResult Submit(ReleaseShipCommand command)
    {
        lock (gate)
        {
            if (commandInFlight || state.Phase != GamePhase.Playing)
                return CommandResult.Rejected(state, CommandRejectionReason.InvalidState);
            commandInFlight = true;
            try
            {
                var result = ReleaseShipTransaction.Execute(state, command);
                if (result.Accepted) state = result.NextState;
                return result;
            }
            finally { commandInFlight = false; }
        }
    }
}
