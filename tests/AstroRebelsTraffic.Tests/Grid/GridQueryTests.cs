using AstroRebelsTraffic.Domain.Rules.Grid;
using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Tests.Grid;

public class GridQueryTests
{
    [Fact]
    public void Returns_exact_occupants_and_bounds_from_state()
    {
        var ship = new ShipState(new ShipId("ship"), new ZoneId("zone"), "red", ShipSize.Medium, new GridCell(0, 0), Direction.Right, SpecialType.Normal, 0, false);
        var state = State(new GridState(new[] { new GridState.Zone(new ZoneId("zone"), 3, 2, new[] { ship.ShipId }) }), ship);
        var query = GridQuery.From(state);

        Assert.True(query.IsWithinBounds(new ZoneId("zone"), new GridCell(2, 1)));
        Assert.False(query.IsWithinBounds(new ZoneId("zone"), new GridCell(3, 1)));
        Assert.Equal(ship.ShipId, query.GetBlocker(new ZoneId("zone"), new GridCell(1, 0)));
        Assert.Null(query.GetBlocker(new ZoneId("zone"), new GridCell(0, 1)));
        Assert.Empty(query.Issues);
    }

    [Fact]
    public void Reports_overlap_without_overwriting_the_first_occupant()
    {
        var first = Ship("first", new GridCell(0, 0));
        var second = Ship("second", new GridCell(0, 0));
        var state = State(new GridState(new[] { new GridState.Zone(new ZoneId("zone"), 2, 2, new[] { first.ShipId, second.ShipId }) }), first, second);
        var query = GridQuery.From(state);

        var issue = Assert.Single(query.Issues, item => item.Code == "OVERLAP");
        Assert.Equal(new[] { new ShipId("first"), new ShipId("second") }, issue.ShipIds);
        Assert.Equal(first.ShipId, query.GetBlocker(new ZoneId("zone"), new GridCell(0, 0)));
    }

    [Fact]
    public void Reports_out_of_bounds_footprint_explicitly()
    {
        var ship = Ship("ship", new GridCell(1, 0), Direction.Right);
        var state = State(new GridState(new[] { new GridState.Zone(new ZoneId("zone"), 1, 1, new[] { ship.ShipId }) }), ship);

        var issue = Assert.Single(GridQuery.From(state).Issues, item => item.Code == "OUT_OF_BOUNDS");
        Assert.Equal("ships_by_id.ship.footprint[0]", issue.Path);
    }

    private static ShipState Ship(string id, GridCell anchor, Direction direction = Direction.Right) =>
        new(new ShipId(id), new ZoneId("zone"), "red", ShipSize.Small, anchor, direction, SpecialType.Normal, 0, false);

    private static GameState State(GridState grid, params ShipState[] ships) =>
        GameState.Create("level", grid, ships, new PassengerQueueState(Array.Empty<PassengerGroup>()), new PreQueueState(Array.Empty<PassengerGroup>()), DockState.CreateInitial());
}
