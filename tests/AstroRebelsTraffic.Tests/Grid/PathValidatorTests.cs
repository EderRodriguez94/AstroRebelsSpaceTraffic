using AstroRebelsTraffic.Domain.Rules.Grid;
using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Tests.Grid;

public class PathValidatorTests
{
    public static IEnumerable<object[]> ClearCases()
    {
        yield return new object[] { Direction.Up, new GridCell(1, 2), 1 };
        yield return new object[] { Direction.Down, new GridCell(1, 0), 1 };
        yield return new object[] { Direction.Left, new GridCell(2, 1), 1 };
        yield return new object[] { Direction.Right, new GridCell(0, 1), 1 };
        yield return new object[] { Direction.Up, new GridCell(1, 3), 2 };
        yield return new object[] { Direction.Down, new GridCell(1, 0), 2 };
        yield return new object[] { Direction.Left, new GridCell(3, 1), 2 };
        yield return new object[] { Direction.Right, new GridCell(0, 1), 2 };
        yield return new object[] { Direction.Up, new GridCell(1, 4), 3 };
        yield return new object[] { Direction.Down, new GridCell(1, 0), 3 };
        yield return new object[] { Direction.Left, new GridCell(4, 1), 3 };
        yield return new object[] { Direction.Right, new GridCell(0, 1), 3 };
    }

    [Theory]
    [MemberData(nameof(ClearCases))]
    public void Supports_clear_exit_for_all_sizes_and_directions(Direction direction, GridCell anchor, int length)
    {
        var size = length switch { 1 => ShipSize.Small, 2 => ShipSize.Medium, _ => ShipSize.Large };
        var ship = new ShipState(new ShipId("ship"), new ZoneId("zone"), "red", size, anchor, direction, SpecialType.Normal, 0, false);
        var state = State(new GridState(new[] { new GridState.Zone(new ZoneId("zone"), 5, 5, new[] { ship.ShipId }) }), ship);

        var result = PathValidator.GetExitPath(state, ship.ShipId);

        Assert.True(result.IsClear);
        Assert.NotEmpty(result.AnchorPath);
        Assert.Null(result.BlockerShipId);
    }

    [Fact]
    public void Rejects_a_partial_gap_for_a_large_ship()
    {
        var moving = Ship("moving", new GridCell(0, 1), ShipSize.Large, Direction.Right);
        var blocker = Ship("blocker", new GridCell(2, 1), ShipSize.Small, Direction.Down);
        var state = State(new GridState(new[] { new GridState.Zone(new ZoneId("zone"), 5, 4, new[] { moving.ShipId, blocker.ShipId }) }), moving, blocker);

        var result = PathValidator.GetExitPath(state, moving.ShipId);

        Assert.False(result.IsClear);
        Assert.Equal("BLOCKED_BY_SHIP", result.BlockerCode);
        Assert.Equal(blocker.ShipId, result.BlockerShipId);
    }

    private static ShipState Ship(string id, GridCell anchor, ShipSize size, Direction direction) =>
        new(new ShipId(id), new ZoneId("zone"), "red", size, anchor, direction, SpecialType.Normal, 0, false);

    private static GameState State(GridState grid, params ShipState[] ships) =>
        GameState.Create("level", grid, ships, new PassengerQueueState(Array.Empty<PassengerGroup>()), new PreQueueState(Array.Empty<PassengerGroup>()), DockState.CreateInitial());
}
