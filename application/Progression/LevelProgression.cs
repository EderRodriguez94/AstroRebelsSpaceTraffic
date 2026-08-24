namespace AstroRebelsTraffic.Application.Progression;

public sealed record LevelProgression(int HighestUnlockedLevel, IReadOnlySet<int> CompletedLevels)
{
    public static LevelProgression Create(int highestUnlockedLevel = 1) => new(Math.Max(1, highestUnlockedLevel), new HashSet<int>());

    public LevelProgression RecordWin(int level)
    {
        if (level < 1) return this;
        var completed = new HashSet<int>(CompletedLevels) { level };
        return this with { HighestUnlockedLevel = Math.Max(HighestUnlockedLevel, level + 1), CompletedLevels = completed };
    }

    public LevelProgression Clamp(int maxLevel) => this with
    {
        HighestUnlockedLevel = Math.Clamp(HighestUnlockedLevel, 1, Math.Max(1, maxLevel)),
        CompletedLevels = CompletedLevels.Where(level => level >= 1 && level <= Math.Max(1, maxLevel)).ToHashSet()
    };
}
