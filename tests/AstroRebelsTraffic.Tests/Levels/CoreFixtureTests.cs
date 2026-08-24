using AstroRebelsTraffic.Levels.Loader;

namespace AstroRebelsTraffic.Tests.Levels;

public sealed class CoreFixtureTests
{
    [Fact]
    public void Core_fixtures_load_without_presentation_dependencies()
    {
        var root = new DirectoryInfo(AppContext.BaseDirectory);
        for (var i = 0; i < 5; i++) root = root.Parent!;
        var files = Directory.GetFiles(Path.Combine(root.FullName, "tests", "fixtures", "levels", "core"), "*.json");
        Assert.True(files.Length >= 7);
        foreach (var file in files) Assert.True(LevelLoader.Load(File.ReadAllText(file)).Success, file);
    }
}
