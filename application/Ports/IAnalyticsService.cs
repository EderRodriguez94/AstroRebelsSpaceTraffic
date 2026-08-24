namespace AstroRebelsTraffic.Application.Ports;

public sealed record AnalyticsEvent(string Name, IReadOnlyDictionary<string, object?> Properties);

public interface IAnalyticsService
{
    void Track(AnalyticsEvent analyticsEvent);
}

public sealed class NoOpAnalyticsService : IAnalyticsService
{
    public void Track(AnalyticsEvent analyticsEvent) { }
}
