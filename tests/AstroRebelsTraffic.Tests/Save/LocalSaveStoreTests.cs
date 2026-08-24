using AstroRebelsTraffic.Application.Save;
using AstroRebelsTraffic.Infrastructure.Save;

namespace AstroRebelsTraffic.Tests.Save;

public sealed class LocalSaveStoreTests
{
    [Fact]
    public void Corrupt_primary_recovers_backup_without_throwing()
    {
        var directory = Path.Combine(Path.GetTempPath(), "astro-save-" + Guid.NewGuid());
        var store = new LocalSaveStore(directory);
        Assert.True(store.TrySave(new SaveData { HighestUnlockedLevel = 3 }));
        Assert.True(store.TrySave(new SaveData { HighestUnlockedLevel = 4 }));
        File.WriteAllText(Path.Combine(directory, "save.json"), "{broken");
        Assert.Equal(3, store.LoadOrDefault().HighestUnlockedLevel);
    }
}
