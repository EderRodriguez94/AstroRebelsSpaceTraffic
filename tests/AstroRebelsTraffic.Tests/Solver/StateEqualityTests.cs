using AstroRebelsTraffic.Domain.State;
using AstroRebelsTraffic.Solver.Hashing;

namespace AstroRebelsTraffic.Tests.Solver;

public sealed class StateEqualityTests
{
    [Fact]
    public void Equivalent_states_are_equal_and_relevant_changes_are_not()
    {
        var first = State("level");
        var equivalent = State("level");
        var changed = State("other-level");
        Assert.True(StateEquality.AreEqual(first, equivalent));
        Assert.False(StateEquality.AreEqual(first, changed));
        Assert.False(StateEquality.AreEqual(first, null));
    }

    private static GameState State(string levelId) => GameState.CreateInitial(
        levelId,
        new GridState(new[] { new GridState.Zone(new ZoneId("zone"), 2, 2, Array.Empty<ShipId>()) }),
        Array.Empty<ShipState>(), new PassengerQueueState(Array.Empty<PassengerGroup>()),
        new PreQueueState(Array.Empty<PassengerGroup>()), DockState.CreateInitial());
}
