using AstroRebelsTraffic.Generator;
using AstroRebelsTraffic.Levels.Loader;

namespace AstroRebelsTraffic.Tests.Property;

public sealed class SeededFixtureTests
{
    [Fact]
    public void Generated_fixtures_are_valid_for_a_reproducible_seed_set()
    {
        var seeds = Enumerable.Range(1, 32).ToArray();
        foreach (var seed in seeds)
        {
            try
            {
                var generated = LevelGenerator.Generate(seed);
                var loaded = LevelLoader.Load(generated.LevelJson);
                Assert.True(loaded.Success, $"seed={seed}; fixture={generated.LevelJson}");
                Assert.True(LevelGenerator.ValidateAndScore(generated).SolutionLength > 0,
                    $"seed={seed}; fixture={generated.LevelJson}");
            }
            catch (Exception error)
            {
                throw new Xunit.Sdk.XunitException($"seed={seed}; minimized-fixture=generated-level; {error.Message}", error);
            }
        }
    }
}
