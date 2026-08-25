using AstroRebelsTraffic.Generator;
using AstroRebelsTraffic.Levels.Loader;
using AstroRebelsTraffic.Domain.State;

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

    [Fact]
    public void Queue_operations_conserve_passenger_count()
    {
        var source = new[] { new PassengerGroup("blue", 4), new PassengerGroup("red", 8) };
        var queue = new PassengerQueueState(source);
        var before = queue.Groups.Sum(group => group.Size);
        var (consumed, remaining) = queue.ConsumeFront();
        Assert.Equal(before, consumed.Size + remaining.Groups.Sum(group => group.Size));

        var preQueue = new PreQueueState(Array.Empty<PassengerGroup>(), 16);
        var afterAppend = preQueue.Append(new PassengerGroup("green", 4));
        Assert.Equal(4, afterAppend.PassengerCount);
    }
}
