using AstroRebelsTraffic.Domain.State;
using AstroRebelsTraffic.Solver.Difficulty;

namespace AstroRebelsTraffic.Tests.Solver;

public sealed class DifficultyTests
{
    [Fact]
    public void Metrics_are_explainable_and_weights_do_not_mutate_state()
    {
        var zone = new ZoneId("zone");
        var state = GameState.CreateInitial("difficulty", new GridState(new[] { new GridState.Zone(zone, 2, 2, new[] { new ShipId("ship") }) }), new[] { new ShipState(new ShipId("ship"), zone, "red", ShipSize.Small, Direction.Right, 0, true) }, new PassengerQueueState(Array.Empty<PassengerGroup>()), new PreQueueState(Array.Empty<PassengerGroup>()), DockState.CreateInitial());
        var before = state.Zones.Serialize();
        var metrics = DifficultyEvaluator.Evaluate(state, new DifficultyWeights(2, 3, 4));
        Assert.Equal(1, metrics.ShipCount);
        Assert.Equal(before, state.Zones.Serialize());
        Assert.True(metrics.Score > 0);
    }
}
