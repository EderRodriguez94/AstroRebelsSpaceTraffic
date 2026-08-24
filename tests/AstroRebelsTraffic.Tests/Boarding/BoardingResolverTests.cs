using AstroRebelsTraffic.Domain.Rules.Boarding;
using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Tests.Boarding;

public class BoardingResolverTests
{
    [Fact]
    public void Splits_eight_passengers_right_to_left_across_two_small_ships()
    {
        var docks = Docks(Ship("left", 0), Ship("right", 0));

        var result = BoardingResolver.Board(docks, "red", 8);

        Assert.Equal(8, result.BoardedCount);
        Assert.Equal(new[] { 1, 0 }, result.Facts.Select(fact => fact.DockIndex));
        Assert.Equal(new[] { 4, 4 }, result.Facts.Select(fact => fact.PassengerCount));
    }

    [Theory]
    [InlineData(16, 0, 0, 2)]
    [InlineData(12, 4, 0, 2)]
    [InlineData(8, 4, 0, 1)]
    [InlineData(4, 4, 0, 1)]
    public void Boards_exact_batches_without_overflow(int requested, int firstCapacityUsed, int secondCapacityUsed, int expectedFacts)
    {
        var docks = Docks(Ship("left", firstCapacityUsed, ShipSize.Medium), Ship("right", secondCapacityUsed, ShipSize.Medium));

        var result = BoardingResolver.Board(docks, "red", requested);

        Assert.Equal(requested, result.BoardedCount);
        Assert.Equal(expectedFacts, result.Facts.Count);
        Assert.All(result.Docks.Where(dock => dock.Occupant is not null), dock => Assert.InRange(dock.Occupant!.PassengerCount, 0, dock.Occupant.Capacity));
    }

    [Fact]
    public void Leaves_incompatible_passengers_and_docks_unchanged()
    {
        var docks = Docks(Ship("blue", 0, ShipSize.Small, "blue"));

        var result = BoardingResolver.Board(docks, "red", 4);

        Assert.Equal(0, result.BoardedCount);
        Assert.Empty(result.Facts);
        Assert.Equal(docks[0].Occupant?.PassengerCount, result.Docks[0].Occupant?.PassengerCount);
    }

    private static IReadOnlyList<DockState> Docks(ShipState first, ShipState? second = null, ShipSize size = ShipSize.Small, string color = "red")
    {
        var docks = DockState.CreateInitial().ToArray();
        docks[0] = docks[0].WithOccupant(first);
        if (second is not null) docks[1] = docks[1].WithOccupant(second);
        return docks;
    }

    private static ShipState Ship(string id, int passengers, ShipSize size = ShipSize.Small, string color = "red") =>
        new(new ShipId(id), new ZoneId("zone"), color, size, Direction.Right, passengers, false);
}
