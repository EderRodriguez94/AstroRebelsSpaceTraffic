using AstroRebelsTraffic.Domain.Rules.EndConditions;
using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Tests.EndConditions;

public class DeadlockTests
{
    [Fact]
    public void Detects_real_deadlock_with_structured_evidence()
    {
        var state = FullDocksState();

        var result = DeadlockDetector.Check(state, isSettled: true, isWinning: false);

        Assert.True(result.IsDeadlock);
        Assert.All(result.Evidence, evidence => Assert.True(evidence.Satisfied));
    }

    [Fact]
    public void Rejects_winning_and_intermediate_states()
    {
        var state = FullDocksState();

        Assert.False(DeadlockDetector.Check(state, isSettled: true, isWinning: true).IsDeadlock);
        Assert.False(DeadlockDetector.Check(state, isSettled: false, isWinning: false).IsDeadlock);
    }

    [Fact]
    public void Full_docks_alone_are_not_a_deadlock_when_boarding_can_progress()
    {
        var state = FullDocksState("blue");

        var result = DeadlockDetector.Check(state, isSettled: true, isWinning: false);

        Assert.False(result.IsDeadlock);
        Assert.Contains(result.Evidence, evidence => evidence.Code == "NO_ELIGIBLE_PASSENGER" && !evidence.Satisfied);
    }

    [Fact]
    public void Locked_reward_docks_do_not_count_as_available_capacity()
    {
        var state = FullDocksState();
        var result = DeadlockDetector.Check(state, isSettled: true, isWinning: false);

        Assert.True(result.Evidence.Single(evidence => evidence.Code == "ACTIVE_DOCKS_OCCUPIED").Satisfied);
    }

    private static GameState FullDocksState(string? preQueueColor = null)
    {
        var docks = DockState.CreateInitial().ToArray();
        for (var i = 0; i < 4; i++) docks[i] = docks[i].WithOccupant(Ship($"dock-{i}", "blue", 0));
        var preQueue = preQueueColor is null ? new PreQueueState(Array.Empty<PassengerGroup>()) : new PreQueueState(new[] { new PassengerGroup(preQueueColor, 4) });
        return GameState.Create("level", new GridState(new[] { new GridState.Zone(new ZoneId("zone"), 2, 2, Array.Empty<ShipId>()) }), Array.Empty<ShipState>(), new PassengerQueueState(Array.Empty<PassengerGroup>()), preQueue, docks);
    }

    private static ShipState Ship(string id, string color, int passengers) =>
        new(new ShipId(id), new ZoneId("zone"), color, ShipSize.Small, Direction.Right, passengers, false);
}
