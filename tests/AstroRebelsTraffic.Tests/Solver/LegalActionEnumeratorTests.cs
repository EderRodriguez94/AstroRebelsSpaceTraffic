using AstroRebelsTraffic.Domain.State;
using AstroRebelsTraffic.Solver.Search;

namespace AstroRebelsTraffic.Tests.Solver;

public sealed class LegalActionEnumeratorTests
{
    [Fact]
    public void Non_playing_state_has_no_legal_actions()
    {
        var state = GameState.Create("level", new GridState(new[] { new GridState.Zone(new ZoneId("z"), 2, 2, Array.Empty<ShipId>()) }), Array.Empty<ShipState>(), new PassengerQueueState(Array.Empty<PassengerGroup>()), new PreQueueState(Array.Empty<PassengerGroup>()), DockState.CreateInitial(), phase: GamePhase.Won);
        Assert.Empty(LegalActionEnumerator.Enumerate(state));
    }
}
