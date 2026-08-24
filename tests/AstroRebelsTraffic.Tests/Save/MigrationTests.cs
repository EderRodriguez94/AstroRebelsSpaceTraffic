using AstroRebelsTraffic.Application.Save.Migrations;

namespace AstroRebelsTraffic.Tests.Save;

public sealed class MigrationTests
{
    [Fact]
    public void Current_fixture_loads_and_future_version_is_rejected()
    {
        var current = SaveMigration.Migrate("{\"schemaVersion\":1,\"highestUnlockedLevel\":1}");
        var future = SaveMigration.Migrate("{\"schemaVersion\":99}");
        Assert.True(current.Supported);
        Assert.False(future.Supported);
        Assert.Null(future.Document);
    }
}
