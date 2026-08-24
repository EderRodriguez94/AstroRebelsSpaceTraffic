using AstroRebelsTraffic.Domain.Rules.Advanced;
using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Tests.Advanced;

public sealed class VipDockTests
{
    [Fact]
    public void VIP_routing_requires_authorization_and_preserves_color()
    {
        var zone = new ZoneId("zone");
        var ship = new ShipState(new ShipId("vip"), zone, "blue", ShipSize.Small, Direction.Right, 0, true);
        var state = new VipDockState(true);
        Assert.Null(VipDockRules.Route(state, ship, false).Occupant);
        Assert.Equal("blue", VipDockRules.Route(state, ship, true).Occupant!.ColorId);
    }
}
