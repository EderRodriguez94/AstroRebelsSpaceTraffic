using AstroRebelsTraffic.Application.Save;

namespace AstroRebelsTraffic.Tests.Save;

public sealed class SaveDataTests
{
    [Fact]
    public void Defaults_are_explicit_and_transient_game_state_is_absent()
    {
        var data = new SaveData();
        Assert.Equal(1, data.SchemaVersion);
        Assert.Equal(1, data.MusicVolume);
        Assert.Empty(data.CompletedTutorialSteps);
        Assert.Empty(data.DisabledBoosterInventory);
        Assert.DoesNotContain(typeof(SaveData).GetProperties(), property => property.Name.Contains("Dock", StringComparison.OrdinalIgnoreCase));
    }
}
