using AstroRebelsTraffic.Application.Ads;

namespace AstroRebelsTraffic.Tests.Ads;

public sealed class OfferPolicyTests
{
    [Fact]
    public void Offer_is_suggestion_only_and_suppressed_when_locked_or_full()
    {
        Assert.True(EmergencyDockOfferPolicy.Evaluate(new(true, false, false, false, 0)).Suggested);
        Assert.False(EmergencyDockOfferPolicy.Evaluate(new(true, false, true, false, 0)).Suggested);
        Assert.False(EmergencyDockOfferPolicy.Evaluate(new(false, true, false, false, 4)).Suggested);
    }
}
