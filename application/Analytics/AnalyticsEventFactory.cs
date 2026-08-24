using AstroRebelsTraffic.Application.Ports;

namespace AstroRebelsTraffic.Application.Analytics;

public static class AnalyticsEventFactory
{
    private static readonly HashSet<string> Allowed = new(StringComparer.Ordinal) { "schema_version", "level_id", "attempt_id", "move_index" };

    public static AnalyticsEvent Create(string name, int schemaVersion, string levelId, string attemptId, int moveIndex)
    {
        var properties = new Dictionary<string, object?>
        {
            ["schema_version"] = schemaVersion,
            ["level_id"] = levelId,
            ["attempt_id"] = attemptId,
            ["move_index"] = moveIndex
        };
        return new AnalyticsEvent(name, properties.Where(pair => Allowed.Contains(pair.Key)).ToDictionary(pair => pair.Key, pair => pair.Value));
    }
}
