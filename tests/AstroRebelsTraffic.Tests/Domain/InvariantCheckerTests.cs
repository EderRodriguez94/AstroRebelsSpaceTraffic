using AstroRebelsTraffic.Domain.Rules.Invariants;
using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Tests.Domain;

public class InvariantCheckerTests
{
    [Fact]
    public void Valid_initial_state_has_no_violations()
    {
        var state = GameState.CreateInitial("level", new GridState(new[] { new GridState.Zone(new ZoneId("z"), 2, 2, Array.Empty<ShipId>()) }), Array.Empty<ShipState>(), new PassengerQueueState(Array.Empty<PassengerGroup>()), new PreQueueState(Array.Empty<PassengerGroup>()), DockState.CreateInitial());
        Assert.Empty(GameStateInvariantChecker.Check(state));
    }

    [Fact]
    public void Reports_a_ship_present_in_more_than_one_logical_location()
    {
        var ship = new ShipState(new ShipId("ship"), new ZoneId("zone"), "red", ShipSize.Small, Direction.Right, 0, false);
        var docks = DockState.CreateInitial().ToArray();
        docks[0] = docks[0].WithOccupant(ship);
        var state = GameState.CreateInitial("level", new GridState(new[] { new GridState.Zone(new ZoneId("zone"), 2, 2, new[] { ship.ShipId }) }), new[] { ship }, new PassengerQueueState(Array.Empty<PassengerGroup>()), new PreQueueState(Array.Empty<PassengerGroup>()), docks);

        var violation = Assert.Single(GameStateInvariantChecker.Check(state), item => item.Code == "MULTIPLE_SHIP_LOCATIONS");
        Assert.Equal("ships_by_id.ship.locations", violation.Path);
    }

    [Fact]
    public void Reports_a_grid_reference_to_an_unknown_ship()
    {
        var state = GameState.CreateInitial("level", new GridState(new[] { new GridState.Zone(new ZoneId("zone"), 2, 2, new[] { new ShipId("missing") }) }), Array.Empty<ShipState>(), new PassengerQueueState(Array.Empty<PassengerGroup>()), new PreQueueState(Array.Empty<PassengerGroup>()), DockState.CreateInitial());

        var violation = Assert.Single(GameStateInvariantChecker.Check(state), item => item.Code == "UNKNOWN_GRID_SHIP");
        Assert.Equal("zones[zone].ship_ids[missing]", violation.Path);
    }

    [Fact]
    public void Reports_a_dock_collection_that_is_not_the_canonical_eight_docks()
    {
        var state = GameState.CreateInitial("level", new GridState(new[] { new GridState.Zone(new ZoneId("zone"), 2, 2, Array.Empty<ShipId>()) }), Array.Empty<ShipState>(), new PassengerQueueState(Array.Empty<PassengerGroup>()), new PreQueueState(Array.Empty<PassengerGroup>()), DockState.CreateInitial().Take(4));

        var violation = Assert.Single(GameStateInvariantChecker.Check(state), item => item.Code == "DOCK_COUNT");
        Assert.Equal("docks", violation.Path);
    }

    [Fact]
    public void Reports_out_of_bounds_footprint_with_exact_path()
    {
        var ship = Ship("ship", new GridCell(2, 0));
        var state = State(new GridState(new[] { new GridState.Zone(new ZoneId("zone"), 2, 2, new[] { ship.ShipId }) }), new[] { ship });

        var violation = Assert.Single(GameStateInvariantChecker.Check(state), item => item.Code == "FOOTPRINT_OUT_OF_BOUNDS");
        Assert.Equal("ships_by_id.ship.footprint[0]", violation.Path);
    }

    [Fact]
    public void Reports_a_negative_cell_derived_by_an_edge_facing_ship()
    {
        var ship = new ShipState(new ShipId("ship"), new ZoneId("zone"), "red", ShipSize.Medium, new GridCell(0, 0), Direction.Left, SpecialType.Normal, 0, false);
        var state = State(new GridState(new[] { new GridState.Zone(new ZoneId("zone"), 2, 2, new[] { ship.ShipId }) }), new[] { ship });

        var violation = Assert.Single(GameStateInvariantChecker.Check(state), item => item.Code == "FOOTPRINT_OUT_OF_BOUNDS");
        Assert.Equal("ships_by_id.ship.footprint[1]", violation.Path);
    }

    [Fact]
    public void Reports_overlapping_footprints_with_exact_path()
    {
        var first = Ship("first", new GridCell(0, 0));
        var second = Ship("second", new GridCell(0, 0));
        var state = State(new GridState(new[] { new GridState.Zone(new ZoneId("zone"), 2, 2, new[] { first.ShipId, second.ShipId }) }), new[] { first, second });

        var violation = Assert.Single(GameStateInvariantChecker.Check(state), item => item.Code == "FOOTPRINT_OVERLAP");
        Assert.Equal("ships_by_id.second.footprint[0]", violation.Path);
    }

    [Fact]
    public void Reports_mismatched_occupancy_index()
    {
        var ship = Ship("ship", new GridCell(0, 0));
        var state = State(new GridState(new[] { new GridState.Zone(new ZoneId("zone"), 2, 2, new[] { ship.ShipId }) }), new[] { ship });
        var context = new GameStateInvariantContext(OccupancyIndex: new Dictionary<GridCell, ShipId>());

        var violation = Assert.Single(GameStateInvariantChecker.Check(state, context), item => item.Code == "OCCUPANCY_INDEX_MISMATCH");
        Assert.Equal("occupancy_index", violation.Path);
    }

    [Fact]
    public void Reports_unknown_color_against_supplied_catalog()
    {
        var ship = Ship("ship", new GridCell(0, 0), "unknown");
        var state = State(new GridState(new[] { new GridState.Zone(new ZoneId("zone"), 2, 2, new[] { ship.ShipId }) }), new[] { ship });

        var violation = Assert.Single(GameStateInvariantChecker.Check(state, new GameStateInvariantContext(new HashSet<string> { "red" })), item => item.Code == "COLOR_ID");
        Assert.Equal("ships_by_id.ship.color_id", violation.Path);
    }

    [Fact]
    public void Reports_unknown_direction_with_exact_path()
    {
        var ship = new ShipState(new ShipId("ship"), new ZoneId("zone"), "red", ShipSize.Small, new GridCell(0, 0), (Direction)99, SpecialType.Normal, 0, false);
        var state = State(new GridState(new[] { new GridState.Zone(new ZoneId("zone"), 2, 2, Array.Empty<ShipId>()) }), new[] { ship });

        var violation = Assert.Single(GameStateInvariantChecker.Check(state), item => item.Code == "DIRECTION_ID");
        Assert.Equal("ships_by_id.ship.direction", violation.Path);
    }

    [Fact]
    public void Reports_terminal_phase_that_disagrees_with_settlement()
    {
        var state = GameState.Create("level", new GridState(new[] { new GridState.Zone(new ZoneId("zone"), 2, 2, Array.Empty<ShipId>()) }), Array.Empty<ShipState>(), new PassengerQueueState(Array.Empty<PassengerGroup>()), new PreQueueState(Array.Empty<PassengerGroup>()), DockState.CreateInitial(), phase: GamePhase.Playing);

        var violation = Assert.Single(GameStateInvariantChecker.Check(state, new GameStateInvariantContext(IsSettled: true, IsWon: true)), item => item.Code == "WIN_PHASE_MISMATCH");
        Assert.Equal("phase", violation.Path);
    }

    [Fact]
    public void Reports_advanced_state_when_its_mechanic_is_disabled()
    {
        var mystery = new ShipState(new ShipId("mystery"), new ZoneId("zone"), "red", ShipSize.Small, new GridCell(0, 0), Direction.Right, SpecialType.Mystery, 0, false);
        var state = State(new GridState(new[] { new GridState.Zone(new ZoneId("zone"), 2, 2, Array.Empty<ShipId>()) }), new[] { mystery }, reserve: new[] { mystery });

        var violations = GameStateInvariantChecker.Check(state);
        Assert.Contains(violations, item => item.Code == "MYSTERY_MECHANIC_DISABLED" && item.Path == "mechanic_flags.mystery");
        Assert.Contains(violations, item => item.Code == "RESERVE_MECHANIC_DISABLED" && item.Path == "mechanic_flags.reserve");
    }

    private static ShipState Ship(string id, GridCell anchor, string color = "red") =>
        new(new ShipId(id), new ZoneId("zone"), color, ShipSize.Small, anchor, Direction.Right, SpecialType.Normal, 0, false);

    private static GameState State(GridState grid, IEnumerable<ShipState> ships, IEnumerable<ShipState>? reserve = null) =>
        GameState.Create("level", grid, ships, new PassengerQueueState(Array.Empty<PassengerGroup>()), new PreQueueState(Array.Empty<PassengerGroup>()), DockState.CreateInitial(), reserve: reserve);
}
