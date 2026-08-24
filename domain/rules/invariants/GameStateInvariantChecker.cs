using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Domain.Rules.Invariants;

public sealed record InvariantViolation(string Code, string Path);

public static class GameStateInvariantChecker
{
    public static IReadOnlyList<InvariantViolation> Check(GameState state)
    {
        var violations = new List<InvariantViolation>();
        foreach (var entry in state.ShipsById.OrderBy(pair => pair.Key.Value, StringComparer.Ordinal))
        {
            if (entry.Key != entry.Value.ShipId) violations.Add(new("SHIP_ID_MISMATCH", $"ships_by_id.{entry.Key}"));
            if (entry.Value.PassengerCount < 0 || entry.Value.PassengerCount > entry.Value.Capacity) violations.Add(new("PASSENGER_COUNT", $"ships_by_id.{entry.Key}.passenger_count"));
            if (entry.Value.Capacity is not (4 or 8 or 16)) violations.Add(new("SHIP_CAPACITY", $"ships_by_id.{entry.Key}.capacity"));
            if (!Enum.IsDefined(entry.Value.ExitDirection)) violations.Add(new("DIRECTION_ID", $"ships_by_id.{entry.Key}.direction"));
        }
        foreach (var dock in state.Docks.OrderBy(dock => dock.VisualIndex))
            if (!dock.IsActive && dock.Occupant is not null) violations.Add(new("INACTIVE_DOCK_OCCUPANT", $"docks[{dock.VisualIndex}].occupant"));
        if (state.PreQueue.PassengerCount > state.PreQueue.Capacity) violations.Add(new("PREQUEUE_CAPACITY", "prequeue"));
        foreach (var group in state.PassengerQueue.Groups.Select((group, index) => (group, index)))
            if (group.group.Size is not (4 or 8 or 16)) violations.Add(new("MAIN_GROUP_SIZE", $"passenger_queue[{group.index}].size"));
        return violations.OrderBy(v => v.Path, StringComparer.Ordinal).ThenBy(v => v.Code, StringComparer.Ordinal).ToArray();
    }
}
