using AstroRebelsTraffic.Domain.Commands;
using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Solver.Search;

public sealed record SolverResult(bool Solved, IReadOnlyList<LegalAction> Actions, GameState State);

public static class BaselineSolver
{
    public static SolverResult Solve(GameState initialState, int maxDepth = 64)
    {
        var state = initialState;
        var actions = new List<LegalAction>();
        for (var depth = 0; depth < maxDepth; depth++)
        {
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
