using AstroRebelsTraffic.Domain.Resolution;
using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Tests.Resolution;

public class SettlementTests
{
    [Fact]
    public void Settles_boarding_and_departure_cascade_deterministically()
    {
        var ship = new ShipState(new ShipId("ship"), new ZoneId("zone"), "red", ShipSize.Small, Direction.Right, 0, false);
        var docks = DockState.CreateInitial().ToArray();
        docks[0] = docks[0].WithOccupant(ship);
        var state = GameState.Create("level", new GridState(new[] { new GridState.Zone(new ZoneId("zone"), 2, 2, Array.Empty<ShipId>()) }), new[] { ship }, new PassengerQueueState(Array.Empty<PassengerGroup>()), new PreQueueState(new[] { new PassengerGroup("red", 4) }), docks);

        var result = ResolutionSystem.Resolve(state);
        var repeated = ResolutionSystem.Resolve(result.State);

        Assert.True(result.Changed);
        Assert.Null(result.State.Docks[0].Occupant);
        Assert.Empty(result.State.PreQueue.Groups);
        Assert.Empty(result.State.Zones.Zones[0].ShipIds);
        Assert.False(repeated.Changed);
        Assert.Empty(repeated.Events);
        Assert.Equal(result.State.Docks.Select(dock => dock.Occupant?.ShipId), repeated.State.Docks.Select(dock => dock.Occupant?.ShipId));
    }
}
