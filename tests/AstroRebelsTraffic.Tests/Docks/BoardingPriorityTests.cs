using AstroRebelsTraffic.Domain.Rules.Docks;
using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Tests.Docks;

public class BoardingPriorityTests
{
    [Fact]
    public void Returns_rightmost_compatible_docks_first_without_mutation()
    {
        var docks = DockState.CreateInitial().ToArray();
        docks[0] = docks[0].WithOccupant(Ship("left", "red", 0));
        docks[1] = docks[1].WithOccupant(Ship("middle", "red", 0));
        docks[2] = docks[2].WithOccupant(Ship("wrong-color", "blue", 0));
        docks[3] = docks[3].WithOccupant(Ship("right", "red", 8));
        var before = docks.Select(dock => dock.Occupant?.PassengerCount).ToArray();

        var result = DockBoardingQuery.FindCompatible(docks, "red", 4);

        Assert.Equal(new[] { 1, 0 }, result.Select(dock => dock.VisualIndex));
        Assert.Equal(before, docks.Select(dock => dock.Occupant?.PassengerCount));
    }

    private static ShipState Ship(string id, string color, int passengers) =>
        new(new ShipId(id), new ZoneId("zone"), color, ShipSize.Medium, Direction.Right, passengers, false);
}
