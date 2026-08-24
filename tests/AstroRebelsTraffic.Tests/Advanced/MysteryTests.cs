using AstroRebelsTraffic.Domain.Rules.Advanced;
using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Tests.Advanced;

public sealed class MysteryTests
{
    [Fact]
    public void Disabled_mechanic_has_no_reveal_effect()
    {
        var zone = new ZoneId("zone");
        var ship = new ShipState(new ShipId("mystery"), zone, "red", ShipSize.Small, Direction.Right, 0, true);
        var state = GameState.CreateInitial("mystery", new GridState(new[] { new GridState.Zone(zone, 2, 2, new[] { ship.ShipId }) }), new[] { ship }, new PassengerQueueState(Array.Empty<PassengerGroup>()), new PreQueueState(Array.Empty<PassengerGroup>()), DockState.CreateInitial());
        Assert.Empty(MysteryRules.RevealClearShips(state, false));
    }
}
