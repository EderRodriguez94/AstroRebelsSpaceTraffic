using AstroRebelsTraffic.Application.Ads;

namespace AstroRebelsTraffic.Tests.Ads;

public sealed class RewardGrantTests
{
    [Fact]
    public void Verified_token_grants_once_and_rejects_replay_or_full_docks()
    {
        var service = new RewardGrantService();
        var result = new AdResult(AdResultKind.CompletedVerified, "rewarded_dock", "token-1");
        Assert.True(service.TryGrant(result, "rewarded_dock", 3));
        Assert.False(service.TryGrant(result, "rewarded_dock", 3));
        Assert.False(service.TryGrant(new AdResult(AdResultKind.CompletedVerified, "rewarded_dock", "token-2"), "rewarded_dock", 4));
        Assert.False(service.TryGrant(new AdResult(AdResultKind.Cancelled, "rewarded_dock", "token-3"), "rewarded_dock", 3));
    }
}
