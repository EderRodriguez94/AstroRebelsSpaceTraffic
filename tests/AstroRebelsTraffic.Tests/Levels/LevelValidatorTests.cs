using AstroRebelsTraffic.Domain.State;
using AstroRebelsTraffic.Levels.Validator;

namespace AstroRebelsTraffic.Tests.Levels;

public sealed class LevelValidatorTests
{
    [Fact]
    public void Canonical_initial_state_has_no_level_errors()
    {
        var state = GameState.CreateInitial("level", new GridState(new[] { new GridState.Zone(new ZoneId("z"), 2, 2, Array.Empty<ShipId>()) }), Array.Empty<ShipState>(), new PassengerQueueState(Array.Empty<PassengerGroup>()), new PreQueueState(Array.Empty<PassengerGroup>()), DockState.CreateInitial());
        Assert.Empty(LevelValidator.Validate(state));
        var result = LevelValidator.Analyze(state);
        Assert.True(result.IsStructurallyValid);
        Assert.True(result.SolverSolvable);
    }
}
