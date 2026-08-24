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
}
