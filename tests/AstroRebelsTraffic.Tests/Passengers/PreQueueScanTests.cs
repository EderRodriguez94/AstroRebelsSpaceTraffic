using AstroRebelsTraffic.Domain.Rules.Passengers;
using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Tests.Passengers;

public class PreQueueScanTests
{
    [Fact]
    public void Boards_compatible_entries_behind_incompatible_entries_once()
    {
        var preQueue = new PreQueueState(new[] { new PassengerGroup("blue", 4), new PassengerGroup("red", 4) });
        var docks = DockState.CreateInitial().ToArray();
        docks[0] = docks[0].WithOccupant(Ship("red"));

        var result = PreQueueRules.Scan(preQueue, docks);

        Assert.True(result.Changed);
        Assert.Equal(new[] { "blue" }, result.Remaining.Groups.Select(group => group.ColorId));
        Assert.Equal(4, result.Remaining.Groups[0].Size);
        Assert.Equal(4, result.Facts.Sum(fact => fact.PassengerCount));
    }

    [Fact]
    public void Preserves_survivor_relative_order_and_does_not_rescan()
    {
        var preQueue = new PreQueueState(new[] { new PassengerGroup("blue", 4), new PassengerGroup("green", 4), new PassengerGroup("red", 4) });
        var docks = DockState.CreateInitial();

        var result = PreQueueRules.Scan(preQueue, docks);

        Assert.False(result.Changed);
        Assert.Equal(new[] { "blue", "green", "red" }, result.Remaining.Groups.Select(group => group.ColorId));
    }

    private static ShipState Ship(string color) =>
        new(new ShipId("ship"), new ZoneId("zone"), color, ShipSize.Small, Direction.Right, 0, false);
}
