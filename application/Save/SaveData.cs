namespace AstroRebelsTraffic.Application.Save;

public sealed record SaveData
{
    public int SchemaVersion { get; init; } = 1;
    public double MusicVolume { get; init; } = 1;
    public double SfxVolume { get; init; } = 1;
    public int HighestUnlockedLevel { get; init; } = 1;
    public IReadOnlySet<string> CompletedTutorialSteps { get; init; } = new HashSet<string>(StringComparer.Ordinal);
    public IReadOnlyDictionary<string, int> DisabledBoosterInventory { get; init; } = new Dictionary<string, int>(StringComparer.Ordinal);
}
