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
}
