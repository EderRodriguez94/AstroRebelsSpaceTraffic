using AstroRebelsTraffic.Domain.State;
using AstroRebelsTraffic.Solver.Search;

namespace AstroRebelsTraffic.Solver.Difficulty;

public sealed record DifficultyWeights(double SolutionLength = 1, double Branching = 1, double Density = 1);
public sealed record DifficultyMetrics(int SolutionLength, int Branching, int ShipCount, double Density, double Score);

public static class DifficultyEvaluator
{
    public static DifficultyMetrics Evaluate(GameState state, DifficultyWeights? weights = null)
    {
        weights ??= new DifficultyWeights();
        var legal = LegalActionEnumerator.Enumerate(state);
        var area = state.Zones.Zones.Sum(zone => zone.Width * zone.Height);
        var density = area == 0 ? 0 : (double)state.ShipsById.Count / area;
        var solution = BaselineSolver.Solve(state).Actions.Count;
        var score = solution * weights.SolutionLength + legal.Count * weights.Branching + density * weights.Density;
        return new DifficultyMetrics(solution, legal.Count, state.ShipsById.Count, density, score);
    }
}
