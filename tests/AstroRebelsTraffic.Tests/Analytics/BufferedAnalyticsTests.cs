using AstroRebelsTraffic.Application.Analytics;

namespace AstroRebelsTraffic.Tests.Analytics;

public sealed class BufferedAnalyticsTests
{
    [Fact]
    public void Consent_is_required_before_buffering_or_delivery()
    {
        var delivered = 0;
        var service = new BufferedAnalyticsService(_ => delivered++);
        var analyticsEvent = AnalyticsEventFactory.Create("start", 1, "level", "attempt", 0);
        service.Track(analyticsEvent);
        Assert.Empty(service.Buffered);
        service.ConsentGranted = true;
        service.Track(analyticsEvent);
        service.Flush();
        Assert.Equal(1, delivered);
        Assert.Empty(service.Buffered);
    }
}
