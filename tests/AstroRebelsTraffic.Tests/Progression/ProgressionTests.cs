using AstroRebelsTraffic.Application.Progression;

namespace AstroRebelsTraffic.Tests.Progression;

public sealed class ProgressionTests
{
    [Fact]
    public void Win_unlocks_next_level_idempotently_and_loss_does_not_change_progression()
    {
        var progress = LevelProgression.Create().RecordWin(1).RecordWin(1);
        Assert.Equal(2, progress.HighestUnlockedLevel);
        Assert.Single(progress.CompletedLevels);
        var safe = progress.Clamp(8);
        Assert.Equal(progress.HighestUnlockedLevel, safe.HighestUnlockedLevel);
        Assert.Equal(progress.CompletedLevels, safe.CompletedLevels);
    }

    [Fact]
    public void Corrupt_progress_is_clamped()
    {
        var progress = new LevelProgression(99, new HashSet<int> { -1, 1, 99 });
        var safe = progress.Clamp(8);
        Assert.Equal(8, safe.HighestUnlockedLevel);
        Assert.Equal(new[] { 1 }, safe.CompletedLevels);
    }
}
