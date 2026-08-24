using System.Text.Json;
using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Levels.Loader;

public static class LevelLoader
{
    public static LevelLoadResult Load(string json)
    {
        try
        {
            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;
            var version = root.GetProperty("schema_version").GetInt32();
            if (version != 1) return LevelLoadResult.Failure(new LevelLoadError("schema_version", "UNSUPPORTED_VERSION", "Only schema version 1 is supported."));
            var levelId = root.GetProperty("level_id").GetString();
            if (string.IsNullOrWhiteSpace(levelId)) return LevelLoadResult.Failure(new LevelLoadError("level_id", "REQUIRED", "Level ID is required."));
            var ships = new List<ShipState>();
            var zones = new List<GridState.Zone>();
            foreach (var zone in root.GetProperty("zones").EnumerateArray())
            {
                var zoneId = zone.GetProperty("id").GetString()!;
                var ids = new List<ShipId>();
                foreach (var ship in zone.GetProperty("ships").EnumerateArray())
                {
                    var id = ship.GetProperty("id").GetString()!;
                    var shipId = new ShipId(id);
                    ids.Add(shipId);
                    ships.Add(new ShipState(shipId, new ZoneId(zoneId), ship.GetProperty("color").GetString()!,
                        DomainEnumSerialization.Parse<ShipSize>(ship.GetProperty("size").GetString()!),
                        DomainEnumSerialization.Parse<Direction>(ship.GetProperty("direction").GetString()!),
                        ship.TryGetProperty("passengers", out var passengers) ? passengers.GetInt32() : 0, true));
                }
                zones.Add(new GridState.Zone(new ZoneId(zoneId), zone.GetProperty("width").GetInt32(), zone.GetProperty("height").GetInt32(), ids));
            }
            var capacity = root.TryGetProperty("prequeue_capacity", out var cap) ? cap.GetInt32() : 16;
            var state = GameState.Create(levelId, new GridState(zones), ships, new PassengerQueueState(Array.Empty<PassengerGroup>()), new PreQueueState(Array.Empty<PassengerGroup>(), capacity), DockState.CreateInitial());
            return new(true, state, Array.Empty<LevelLoadError>());
        }
        catch (KeyNotFoundException ex) { return LevelLoadResult.Failure(new LevelLoadError("$", "REQUIRED", ex.Message)); }
        catch (JsonException ex) { return LevelLoadResult.Failure(new LevelLoadError("$", "INVALID_JSON", ex.Message)); }
        catch (Exception ex) when (ex is FormatException or ArgumentException or InvalidOperationException) { return LevelLoadResult.Failure(new LevelLoadError("$", "INVALID_LEVEL", ex.Message)); }
    }
}
