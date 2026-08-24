namespace AstroRebelsTraffic.Levels.ProductionManifest;

public sealed record ProductionLevelEntry(string LevelId, string CandidatePath, string ProductionPath, bool HumanReviewed);
public sealed record ProductionManifestReport(bool IsValid, IReadOnlyList<string> Errors)
{
    public string Serialize() => string.Join("\n", Errors.OrderBy(error => error));
}

public static class ProductionManifestGate
{
    public static ProductionManifestReport Validate(IEnumerable<ProductionLevelEntry> entries, Func<string, bool> validator, Func<string, bool> solver)
    {
        var errors = new List<string>();
        foreach (var entry in entries.OrderBy(item => item.LevelId, StringComparer.Ordinal))
        {
            if (string.IsNullOrWhiteSpace(entry.LevelId)) errors.Add("level_id:required");
            if (string.IsNullOrWhiteSpace(entry.CandidatePath)) errors.Add($"{entry.LevelId}:candidate_path");
            if (string.IsNullOrWhiteSpace(entry.ProductionPath)) errors.Add($"{entry.LevelId}:production_path");
            if (!entry.HumanReviewed) errors.Add($"{entry.LevelId}:human_reviewed");
            if (!validator(entry.CandidatePath)) errors.Add($"{entry.LevelId}:validator");
            if (!solver(entry.CandidatePath)) errors.Add($"{entry.LevelId}:solver");
        }
        return new(errors.Count == 0, errors);
    }
}
