using AstroRebelsTraffic.Application.Analytics;

namespace AstroRebelsTraffic.Tests.Analytics;

public sealed class AnalyticsTests
{
    [Fact]
    public void Payload_is_allowlisted_and_contains_no_state_dump()
    {
        var analyticsEvent = AnalyticsEventFactory.Create("level_started", 1, "level-1", "attempt-1", 2);
        Assert.Equal(4, analyticsEvent.Properties.Count);
        Assert.DoesNotContain("state", analyticsEvent.Properties.Keys);
        Assert.DoesNotContain("personal_data", analyticsEvent.Properties.Keys);
    }
}
