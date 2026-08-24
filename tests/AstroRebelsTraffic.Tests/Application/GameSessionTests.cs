using AstroRebelsTraffic.Application.GameSession;
using AstroRebelsTraffic.Domain.Commands;
using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Tests.Application;

public sealed class GameSessionTests
{
    [Fact]
    public void Invalid_command_does_not_advance_move_index()
    {
        var state = GameState.CreateInitial("level", new GridState(new[] { new GridState.Zone(new ZoneId("zone"), 2, 2, Array.Empty<ShipId>()) }), Array.Empty<ShipState>(), new PassengerQueueState(Array.Empty<PassengerGroup>()), new PreQueueState(Array.Empty<PassengerGroup>()), DockState.CreateInitial());
        var session = new GameSession(state);
        var result = session.Submit(new ReleaseShipCommand(new ShipId("missing")));
        Assert.False(result.Accepted);
        Assert.Equal(0, session.State.MoveIndex);
    }
}
