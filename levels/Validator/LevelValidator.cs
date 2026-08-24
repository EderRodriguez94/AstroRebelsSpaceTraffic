using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Levels.Validator;

public sealed record LevelValidationError(string Path, string Code, string Message);
public sealed record LevelValidationResult(IReadOnlyList<LevelValidationError> StructuralErrors, bool SolverSolvable)
{
    public bool IsStructurallyValid => StructuralErrors.Count == 0;
}

public static class LevelValidator
{
    public static IReadOnlyList<LevelValidationError> Validate(GameState state)
    {
        var errors = new List<LevelValidationError>();
        if (state.SchemaVersion != 1) errors.Add(new("schema_version", "SCHEMA_VERSION", "Unsupported schema version."));
        var ids = state.ShipsById.Keys.ToArray();
        if (ids.Distinct().Count() != ids.Length) errors.Add(new("ships", "DUPLICATE_ID", "Ship IDs must be unique."));
        foreach (var zone in state.Zones.Zones)
        {
            if (zone.ShipIds.Distinct().Count() != zone.ShipIds.Count) errors.Add(new($"zones[{zone.Id}].ships", "DUPLICATE_ID", "Zone ship IDs must be unique."));
            foreach (var shipId in zone.ShipIds)
                if (!state.ShipsById.ContainsKey(shipId)) errors.Add(new($"zones[{zone.Id}].ships", "UNKNOWN_SHIP", $"Unknown ship {shipId}."));
        }
        if (state.PreQueue.Capacity != 16 && state.PreQueue.Capacity <= 0) errors.Add(new("prequeue_capacity", "CAPACITY", "Prequeue capacity must be positive."));
        if (state.Docks.Count == 0) errors.Add(new("docks", "DOCKS_REQUIRED", "At least one dock is required."));
        if (state.Docks.Count != 8) errors.Add(new("docks", "DOCK_COUNT", "Exactly 8 docks are required."));
        if (state.Docks.Count(dock => dock.IsActive) != 4) errors.Add(new("docks", "BASE_DOCK_COUNT", "Exactly 4 base docks must be active."));
        return errors;
    }

    public static LevelValidationResult Analyze(GameState state)
    {
        var errors = Validate(state).ToArray();
        return new LevelValidationResult(errors, errors.Length == 0);
    }
}
