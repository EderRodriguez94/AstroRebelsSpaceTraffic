using AstroRebelsTraffic.Generator;

namespace AstroRebelsTraffic.Tests.Generator;

public sealed class GeneratorTests
{
    [Fact]
    public void Seed_is_deterministic_and_review_stays_false()
    {
        var first = LevelGenerator.Generate(7);
        var second = LevelGenerator.Generate(7);
        Assert.Equal(first.LevelJson, second.LevelJson);
        Assert.False(first.HumanReviewed);
        var scored = LevelGenerator.ValidateAndScore(first);
        Assert.True(scored.SolutionLength > 0);
        Assert.False(scored.HumanReviewed);
    }
}
