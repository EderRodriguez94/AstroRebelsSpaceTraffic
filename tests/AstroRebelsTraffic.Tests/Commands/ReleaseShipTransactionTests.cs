using AstroRebelsTraffic.Domain.Commands;
using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Tests.Commands;

public sealed class ReleaseShipTransactionTests
{
    [Fact]
    public void Unknown_ship_is_rejected_without_state_change()
    {
        var state = GameState.CreateInitial("level", new GridState(new[] { new GridState.Zone(new ZoneId("zone"), 2, 2, Array.Empty<ShipId>()) }), Array.Empty<ShipState>(), new PassengerQueueState(Array.Empty<PassengerGroup>()), new PreQueueState(Array.Empty<PassengerGroup>()), DockState.CreateInitial());
        var result = ReleaseShipTransaction.Execute(state, new ReleaseShipCommand(new ShipId("missing")));
        Assert.False(result.Accepted);
        Assert.Same(state, result.NextState);
        Assert.Empty(result.Events);
    }
}
