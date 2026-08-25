using AstroRebelsTraffic.Domain.Serialization;
using AstroRebelsTraffic.Domain.State;
using AstroRebelsTraffic.Solver.Search;

namespace AstroRebelsTraffic.Application.BackgroundWork;

/// <summary>
/// Runs optional solver work on an immutable serialized snapshot.
/// The worker never receives or mutates Godot Nodes.
/// </summary>
public static class BackgroundSolverService
{
    public static Task<SolverResult> SolveAsync(
        GameState state,
        int maxDepth,
        TimeSpan budget,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(state);
        if (maxDepth < 0) throw new ArgumentOutOfRangeException(nameof(maxDepth));
        if (budget <= TimeSpan.Zero) throw new ArgumentOutOfRangeException(nameof(budget));

        var snapshot = GameStateSerializer.Deserialize(GameStateSerializer.Serialize(state));
        return Task.Run(() => BaselineSolver.Solve(snapshot, maxDepth, cancellationToken, budget));
    }
}
