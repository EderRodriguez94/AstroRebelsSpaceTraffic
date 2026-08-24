namespace AstroRebelsTraffic.Application.Save;

public sealed record SaveData
{
    public int SchemaVersion { get; init; } = 1;
    public double MusicVolume { get; init; } = 1;
    public double SfxVolume { get; init; } = 1;
    public int HighestUnlockedLevel { get; init; } = 1;
    public HashSet<string> CompletedTutorialSteps { get; init; } = new(StringComparer.Ordinal);
    public Dictionary<string, int> DisabledBoosterInventory { get; init; } = new(StringComparer.Ordinal);
}
