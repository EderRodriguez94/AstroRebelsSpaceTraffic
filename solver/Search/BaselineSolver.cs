using AstroRebelsTraffic.Domain.Commands;
using AstroRebelsTraffic.Domain.State;
using System.Diagnostics;

namespace AstroRebelsTraffic.Solver.Search;

public sealed record SolverResult(bool Solved, IReadOnlyList<LegalAction> Actions, GameState State);

public static class BaselineSolver
{
    public static SolverResult Solve(GameState initialState, int maxDepth = 64,
        CancellationToken cancellationToken = default, TimeSpan? budget = null)
    {
        var state = initialState;
        var actions = new List<LegalAction>();
        var stopwatch = Stopwatch.StartNew();
        for (var depth = 0; depth < maxDepth; depth++)
        {
            if (cancellationToken.IsCancellationRequested || budget is not null && stopwatch.Elapsed >= budget.Value)
                return new(false, actions, state);
            var legal = LegalActionEnumerator.Enumerate(state);
            if (legal.Count == 0) return new(false, actions, state);
            var action = legal[0];
            var result = ReleaseShipTransaction.Execute(state, new ReleaseShipCommand(action.ShipId));
            if (!result.Accepted) return new(false, actions, state);
            actions.Add(action);
            state = result.NextState;
            if (state.Phase == GamePhase.Won) return new(true, actions, state);
        }
        return new(false, actions, state);
    }
}
