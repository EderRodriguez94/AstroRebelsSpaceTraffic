using AstroRebelsTraffic.Application.Boosters;
using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Tests.Advanced;

public sealed class ScannerTests
{
    [Fact]
    public void Unavailable_scanner_is_rejected_without_mutation()
    {
        var zone = new ZoneId("zone");
        var state = GameState.CreateInitial("scanner", new GridState(new[] { new GridState.Zone(zone, 2, 2, Array.Empty<ShipId>()) }), Array.Empty<ShipState>(), new PassengerQueueState(Array.Empty<PassengerGroup>()), new PreQueueState(Array.Empty<PassengerGroup>()), DockState.CreateInitial());
        var result = new ScannerService().Use(state, true, 0);
        Assert.False(result.Accepted);
        Assert.Empty(result.Reveals);
        Assert.Empty(state.ShipsById);
    }
}
