using AstroRebelsTraffic.Domain.Rules.Advanced;
using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Tests.Advanced;

public sealed class MultiZoneTests
{
    [Fact]
    public void Multiple_zones_share_state_and_keep_boundaries_separate()
    {
        var first = new ZoneId("first");
        var second = new ZoneId("second");
        var state = GameState.CreateInitial("multi", new GridState(new[] { new GridState.Zone(first, 2, 2, Array.Empty<ShipId>()), new GridState.Zone(second, 3, 3, Array.Empty<ShipId>()) }), Array.Empty<ShipState>(), new PassengerQueueState(Array.Empty<PassengerGroup>()), new PreQueueState(Array.Empty<PassengerGroup>()), DockState.CreateInitial());
        Assert.True(MultiZoneRules.IsWithinZone(state, second, new GridCell(2, 2)));
        Assert.False(MultiZoneRules.IsWithinZone(state, first, new GridCell(2, 2)));
    }
}
