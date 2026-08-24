using AstroRebelsTraffic.Levels.Loader;

namespace AstroRebelsTraffic.Tests.Levels;

public sealed class LevelLoaderTests
{
    [Fact]
    public void Valid_fixture_constructs_initial_state()
    {
        var result = LevelLoader.Load("{\"schema_version\":1,\"level_id\":\"l1\",\"zones\":[{\"id\":\"z\",\"width\":2,\"height\":2,\"ships\":[]}]}");
        Assert.True(result.Success);
        Assert.Equal("l1", result.State!.LevelId);
        Assert.Equal(16, result.State.PreQueue.Capacity);
    }

    [Fact]
    public void Malformed_content_returns_structured_error()
    {
        var result = LevelLoader.Load("{bad");
        Assert.False(result.Success);
        Assert.Equal("INVALID_JSON", result.Errors[0].Code);
    }
}
