using AstroRebelsTraffic.Domain.State;
using AstroRebelsTraffic.Solver.Search;

namespace AstroRebelsTraffic.Tests.Solver;

public sealed class BaselineSolverTests
{
    [Fact]
    public void Empty_state_is_not_claimed_solved()
    {
        var state = GameState.CreateInitial("level", new GridState(new[] { new GridState.Zone(new ZoneId("z"), 2, 2, Array.Empty<ShipId>()) }), Array.Empty<ShipState>(), new PassengerQueueState(Array.Empty<PassengerGroup>()), new PreQueueState(Array.Empty<PassengerGroup>()), DockState.CreateInitial());
        var result = BaselineSolver.Solve(state);
        Assert.False(result.Solved);
        Assert.Empty(result.Actions);
    }
}
