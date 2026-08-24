using System.Text.Json;
using AstroRebelsTraffic.Levels.Schema;

namespace AstroRebelsTraffic.Tests.Levels;

public sealed class SchemaTests
{
    [Fact]
    public void Version_one_definition_has_authorized_default_capacity()
    {
        var level = new LevelDefinition(1, "level-1", Array.Empty<LevelZone>());
        Assert.Equal(16, level.PreQueueCapacity);
        var root = new DirectoryInfo(AppContext.BaseDirectory);
        for (var i = 0; i < 5; i++) root = root.Parent!;
        var schemaPath = Path.Combine(root.FullName, "levels", "schema", "astro-rebels-level-v1.schema.json");
        Assert.Equal(1, JsonDocument.Parse(File.ReadAllText(schemaPath)).RootElement.GetProperty("properties").GetProperty("schema_version").GetProperty("const").GetInt32());
    }
}
