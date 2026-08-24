using AstroRebelsTraffic.Domain.Rules.Docks;
using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Tests.Docks;

public class RewardDockRulesTests
{
    [Fact]
    public void Four_grants_activate_four_distinct_rewarded_docks_in_order()
    {
        var docks = DockState.CreateInitial();
        var indexes = new List<int>();
        for (var grant = 0; grant < 4; grant++)
        {
            var result = RewardDockRules.ActivateOne(docks);
            Assert.True(result.Activated);
            indexes.Add(result.DockIndex!.Value);
            docks = result.Docks;
        }

        Assert.Equal(new[] { 4, 5, 6, 7 }, indexes);
        Assert.All(docks, dock => Assert.True(dock.IsActive));
    }

    [Fact]
    public void Fifth_grant_is_rejected_without_mutating_the_attempt()
    {
        var docks = DockState.CreateInitial();
        for (var grant = 0; grant < 4; grant++) docks = RewardDockRules.ActivateOne(docks).Docks;
        var before = docks.Select(dock => dock.IsActive).ToArray();

        var result = RewardDockRules.ActivateOne(docks);

        Assert.False(result.Activated);
        Assert.Equal("NO_REWARDED_DOCKS_REMAINING", result.RejectionReason);
        Assert.Equal(before, result.Docks.Select(dock => dock.IsActive));
    }
}
