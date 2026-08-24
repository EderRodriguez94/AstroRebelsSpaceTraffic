using AstroRebelsTraffic.Domain.Rules.Docks;
using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Tests.Docks;

public class ShipDepartureTests
{
    [Fact]
    public void Departs_only_full_ships_in_ascending_dock_order()
    {
        var docks = DockState.CreateInitial().ToArray();
        docks[0] = docks[0].WithOccupant(Ship("partial", 3));
        docks[1] = docks[1].WithOccupant(Ship("full-right", 4));
        docks[2] = docks[2].WithOccupant(Ship("full-left", 4));

        var result = ShipDepartureRules.DepartFullShips(docks);

        Assert.Equal(new[] { 1, 2 }, result.Departures.Select(departure => departure.DockIndex));
        Assert.Equal(new[] { "full-right", "full-left" }, result.Departures.Select(departure => departure.ShipId.Value));
        Assert.NotNull(result.Docks[0].Occupant);
        Assert.Null(result.Docks[1].Occupant);
        Assert.Null(result.Docks[2].Occupant);
    }

    private static ShipState Ship(string id, int passengers) =>
        new(new ShipId(id), new ZoneId("zone"), "red", ShipSize.Small, Direction.Right, passengers, false);
}
