using AstroRebelsTraffic.Domain.Rules.Docks;
using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Tests.Docks;

public class DockAssignmentTests
{
    [Fact]
    public void Assigns_the_lowest_empty_active_dock()
    {
        var docks = DockState.CreateInitial().ToArray();
        var ship = Ship("ship");
        docks[0] = docks[0].WithOccupant(Ship("existing"));
        docks[2] = docks[2].WithOccupant(Ship("existing-2"));

        var result = DockSystem.Assign(docks, ship);

        Assert.True(result.Assigned);
        Assert.Equal(1, result.DockIndex);
        Assert.Equal(ship.ShipId, result.Docks[1].Occupant?.ShipId);
    }

    [Fact]
    public void Locked_reward_docks_never_count_as_available()
    {
        var docks = DockState.CreateInitial();

        Assert.Equal(0, DockSystem.FindLeftmostEmptyStandard(docks));
    }

    [Fact]
    public void Rejects_double_occupancy_and_full_standard_capacity()
    {
        var ship = Ship("ship");
        var docks = DockState.CreateInitial().Select(dock => dock.IsActive ? dock.WithOccupant(dock.VisualIndex == 0 ? ship : Ship($"existing-{dock.VisualIndex}")) : dock).ToArray();

        var duplicate = DockSystem.Assign(docks, ship);
        var full = DockSystem.Assign(docks, Ship("new"));

        Assert.Equal("SHIP_ALREADY_DOCKED", duplicate.RejectionReason);
        Assert.Equal("NO_EMPTY_STANDARD_DOCK", full.RejectionReason);
    }

    private static ShipState Ship(string id) =>
        new(new ShipId(id), new ZoneId("zone"), "red", ShipSize.Small, Direction.Right, 0, false);
}
