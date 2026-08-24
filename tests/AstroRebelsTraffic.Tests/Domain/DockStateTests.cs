using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Tests.Domain;

public class DockStateTests
{
    [Fact]
    public void Initial_factory_returns_four_active_and_four_locked_docks()
    {
        var docks = DockState.CreateInitial();
        Assert.Equal(8, docks.Count);
        Assert.Equal(Enumerable.Range(0, 8), docks.Select(d => d.VisualIndex));
        Assert.Equal(4, docks.Count(d => d.IsActive));
        Assert.All(docks.Skip(4), dock => Assert.False(dock.IsActive));
    }
    [Fact]
    public void Inactive_docks_reject_occupants_and_vip_is_disabled()
    {
        var ship = new ShipState(new ShipId("s"), new ZoneId("z"), "red", ShipSize.Small, Direction.Up, 0, false);
        Assert.Throws<InvalidOperationException>(() => DockState.CreateInitial()[4].WithOccupant(ship));
        Assert.All(DockState.CreateInitial(), dock => Assert.False(dock.IsVip));
    }
}
