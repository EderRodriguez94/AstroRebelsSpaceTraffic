using System.Text.Json;
using AstroRebelsTraffic.Domain.State;
using AstroRebelsTraffic.Levels.Loader;
using AstroRebelsTraffic.Levels.Schema;
using AstroRebelsTraffic.Levels.Validator;
using AstroRebelsTraffic.Solver.Search;

namespace AstroRebelsTraffic.Generator;

public sealed record GeneratedCandidate(string LevelJson, int Seed, bool HumanReviewed, int SolutionLength, double Score);

public static class LevelGenerator
{
    public static GeneratedCandidate Generate(int seed)
    {
        var shipId = $"generated-{seed}";
        var definition = new LevelDefinition(1, $"generated-{seed}", new[]
        {
            new LevelZone("zone-a", 2, 2, new[] { new LevelShip(shipId, "red", "Small", "Right") })
        });
        var json = JsonSerializer.Serialize(new { schema_version = definition.SchemaVersion, level_id = definition.LevelId, zones = definition.Zones.Select(z => new { id = z.Id, width = z.Width, height = z.Height, ships = z.Ships.Select(s => new { id = s.Id, color = s.Color, size = s.Size, direction = s.Direction, passengers = s.Passengers }) }), prequeue_capacity = definition.PreQueueCapacity });
        return new GeneratedCandidate(json, seed, false, 0, 0);
    }

    public static GeneratedCandidate ValidateAndScore(GeneratedCandidate candidate)
    {
        if (candidate.HumanReviewed) throw new InvalidOperationException("Generator cannot auto-mark human review.");
        var loaded = LevelLoader.Load(candidate.LevelJson);
        if (!loaded.Success || loaded.State is null) throw new InvalidOperationException("Candidate failed loading.");
        if (LevelValidator.Validate(loaded.State).Count != 0) throw new InvalidOperationException("Candidate failed validation.");
        var playable = GameState.Create(loaded.State.LevelId, loaded.State.Zones, loaded.State.ShipsById.Values,
            new PassengerQueueState(new[] { new PassengerGroup("red", 4) }), loaded.State.PreQueue, loaded.State.Docks);
        var result = BaselineSolver.Solve(playable);
        if (!result.Solved) throw new InvalidOperationException("Candidate failed solver validation.");
        return candidate with { SolutionLength = result.Actions.Count, Score = result.Actions.Count };
    }
}
