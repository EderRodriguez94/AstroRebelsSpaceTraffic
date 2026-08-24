using AstroRebelsTraffic.Application.Ports;

namespace AstroRebelsTraffic.Application.Analytics;

public sealed class BufferedAnalyticsService : IAnalyticsService
{
    private readonly List<AnalyticsEvent> buffer = new();
    private readonly Action<AnalyticsEvent>? delivery;
    public bool ConsentGranted { get; set; }
    public IReadOnlyList<AnalyticsEvent> Buffered => buffer;

    public BufferedAnalyticsService(Action<AnalyticsEvent>? delivery = null) => this.delivery = delivery;

    public void Track(AnalyticsEvent analyticsEvent)
    {
        if (!ConsentGranted) return;
        buffer.Add(analyticsEvent);
    }

    public void Flush()
    {
        if (!ConsentGranted || delivery is null) return;
        foreach (var analyticsEvent in buffer.ToArray()) delivery(analyticsEvent);
        buffer.Clear();
    }
}
