using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Domain.Rules.Invariants;

public sealed record InvariantViolation(string Code, string Path);

public static class GameStateInvariantChecker
{
    public static IReadOnlyList<InvariantViolation> Check(GameState state)
    {
        var violations = new List<InvariantViolation>();
        var locations = new Dictionary<ShipId, List<string>>();

        void AddLocation(ShipState ship, string path)
        {
            if (!locations.TryGetValue(ship.ShipId, out var paths))
                locations[ship.ShipId] = paths = new List<string>();
            paths.Add(path);
        }

        foreach (var entry in state.ShipsById.OrderBy(pair => pair.Key.Value, StringComparer.Ordinal))
        {
            if (entry.Key != entry.Value.ShipId) violations.Add(new("SHIP_ID_MISMATCH", $"ships_by_id.{entry.Key}"));
            if (entry.Value.PassengerCount < 0 || entry.Value.PassengerCount > entry.Value.Capacity) violations.Add(new("PASSENGER_COUNT", $"ships_by_id.{entry.Key}.passenger_count"));
            if (entry.Value.Capacity is not (4 or 8 or 16)) violations.Add(new("SHIP_CAPACITY", $"ships_by_id.{entry.Key}.capacity"));
            if (!Enum.IsDefined(entry.Value.ExitDirection)) violations.Add(new("DIRECTION_ID", $"ships_by_id.{entry.Key}.direction"));
        }
        foreach (var zone in state.Zones.Zones.OrderBy(zone => zone.Id.Value, StringComparer.Ordinal))
            foreach (var shipId in zone.ShipIds.OrderBy(id => id.Value, StringComparer.Ordinal))
            {
                if (!state.ShipsById.TryGetValue(shipId, out var ship))
                    violations.Add(new("UNKNOWN_GRID_SHIP", $"zones[{zone.Id}].ship_ids[{shipId}]"));
                else
                    AddLocation(ship, $"zones[{zone.Id}].ship_ids[{shipId}]");
            }
        foreach (var dock in state.Docks.OrderBy(dock => dock.VisualIndex))
        {
            if (!dock.IsActive && dock.Occupant is not null) violations.Add(new("INACTIVE_DOCK_OCCUPANT", $"docks[{dock.VisualIndex}].occupant"));
            if (dock.Occupant is not null)
            {
                if (!state.ShipsById.ContainsKey(dock.Occupant.ShipId)) violations.Add(new("UNKNOWN_DOCK_SHIP", $"docks[{dock.VisualIndex}].occupant"));
                AddLocation(dock.Occupant, $"docks[{dock.VisualIndex}].occupant");
            }
        }
        if (state.Docks.Count != 8) violations.Add(new("DOCK_COUNT", "docks"));
        if (state.Docks.Select(dock => dock.VisualIndex).Distinct().Count() != state.Docks.Count) violations.Add(new("DUPLICATE_DOCK_INDEX", "docks"));
        if (state.VipDock is not null)
        {
            if (!state.ShipsById.ContainsKey(state.VipDock.ShipId)) violations.Add(new("UNKNOWN_VIP_SHIP", "vip_dock"));
            AddLocation(state.VipDock, "vip_dock");
        }
        foreach (var ship in state.Reserve.OrderBy(ship => ship.ShipId.Value, StringComparer.Ordinal))
        {
            if (!state.ShipsById.ContainsKey(ship.ShipId)) violations.Add(new("UNKNOWN_RESERVE_SHIP", $"reserve[{ship.ShipId}]"));
            AddLocation(ship, $"reserve[{ship.ShipId}]");
        }
        foreach (var location in locations.OrderBy(pair => pair.Key.Value, StringComparer.Ordinal))
            if (location.Value.Count > 1)
                violations.Add(new("MULTIPLE_SHIP_LOCATIONS", $"ships_by_id.{location.Key}.locations"));
        if (state.PreQueue.PassengerCount > state.PreQueue.Capacity) violations.Add(new("PREQUEUE_CAPACITY", "prequeue"));
        foreach (var group in state.PassengerQueue.Groups.Select((group, index) => (group, index)))
            if (group.group.Size is not (4 or 8 or 16)) violations.Add(new("MAIN_GROUP_SIZE", $"passenger_queue[{group.index}].size"));
        return violations.OrderBy(v => v.Path, StringComparer.Ordinal).ThenBy(v => v.Code, StringComparer.Ordinal).ToArray();
    }
}
