using AstroRebelsTraffic.Application.Ads;
using AstroRebelsTraffic.Application.Ports;

namespace AstroRebelsTraffic.Tests.Ads;

public sealed class AdPortTests
{
    [Fact]
    public void No_op_adapters_never_grant_or_throw()
    {
        var rewarded = new NoOpRewardedAdService().Show("rewarded_dock");
        var interstitial = new NoOpInterstitialAdService().Show("between_levels");
        Assert.Equal(AdResultKind.Unavailable, rewarded.Kind);
        Assert.Equal(AdResultKind.Unavailable, interstitial.Kind);
        Assert.Null(rewarded.VerificationToken);
    }
}
