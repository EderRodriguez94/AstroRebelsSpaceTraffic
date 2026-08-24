using AstroRebelsTraffic.Domain.Rules.Advanced;
using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Tests.Advanced;

public sealed class ReserveTests
{
    [Fact]
    public void Blocked_entry_preserves_order_and_visible_prefix_is_bounded()
    {
        var zone = new ZoneId("reserve");
        var first = new ShipState(new ShipId("a"), zone, "red", ShipSize.Small, Direction.Right, 0, true);
        var second = new ShipState(new ShipId("b"), zone, "blue", ShipSize.Small, Direction.Right, 0, true);
        var reserve = new ReserveState(new[] { first, second }, 99, true);
        Assert.Equal(2, reserve.VisibleShips.Count);
        var blocked = ReserveRules.TryEnter(reserve, false);
        Assert.Null(blocked.Entered);
        Assert.Equal("a", blocked.Reserve.OrderedShips[0].ShipId.Value);
    }
}
