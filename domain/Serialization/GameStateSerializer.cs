using System.Text.Json;
using System.Text.Json.Nodes;
using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Domain.Serialization;

public static class GameStateSerializer
{
    public const int CurrentSchemaVersion = 1;

    public static string Serialize(GameState state)
    {
        var root = new JsonObject
        {
            ["schema_version"] = state.SchemaVersion,
            ["level_id"] = state.LevelId,
            ["attempt_id"] = state.AttemptId,
            ["phase"] = state.Phase.ToString(),
            ["move_index"] = state.MoveIndex,
            ["zones"] = new JsonArray(state.Zones.Zones.OrderBy(z => z.Id.Value).Select(z => (JsonNode)new JsonObject
            {
                ["id"] = z.Id.Value,
                ["width"] = z.Width,
                ["height"] = z.Height,
                ["ships"] = new JsonArray(z.ShipIds.OrderBy(id => id.Value).Select(id => (JsonNode)id.Value).ToArray())
            }).ToArray()),
            ["ships"] = new JsonArray(state.ShipsById.OrderBy(p => p.Key.Value).Select(p => (JsonNode)new JsonObject
            {
                ["id"] = p.Key.Value,
                ["zone"] = p.Value.ZoneId.Value,
                ["color"] = p.Value.ColorId,
                ["size"] = p.Value.Size.ToString(),
                ["anchor_x"] = p.Value.AnchorCell.X,
                ["anchor_y"] = p.Value.AnchorCell.Y,
                ["direction"] = p.Value.ExitDirection.ToString(),
                ["special"] = p.Value.SpecialType.ToString(),
                ["passengers"] = p.Value.PassengerCount,
                ["revealed"] = p.Value.IsRevealed
            }).ToArray()),
            ["queue"] = new JsonArray(state.PassengerQueue.Groups.Select(g => (JsonNode)new JsonObject { ["color"] = g.ColorId, ["size"] = g.Size }).ToArray()),
            ["prequeue"] = new JsonArray(state.PreQueue.Groups.Select(g => (JsonNode)new JsonObject { ["color"] = g.ColorId, ["size"] = g.Size }).ToArray()),
            ["docks"] = new JsonArray(state.Docks.OrderBy(d => d.VisualIndex).Select(d => (JsonNode)new JsonObject { ["index"] = d.VisualIndex, ["active"] = d.IsActive, ["ship"] = d.Occupant?.ShipId.Value }).ToArray()),
            ["mechanics"] = new JsonObject(state.MechanicFlags.OrderBy(p => p.Key).ToDictionary(p => p.Key, p => (JsonNode?)p.Value)),
            ["modifiers"] = new JsonObject(state.AttemptModifiers.OrderBy(p => p.Key).ToDictionary(p => p.Key, p => (JsonNode?)p.Value)),
            ["tutorial"] = state.TutorialState
        };
        return root.ToJsonString(new JsonSerializerOptions { WriteIndented = false });
    }

    public static void EnsureSupportedSchema(string serialized)
    {
        var version = JsonNode.Parse(serialized)?["schema_version"]?.GetValue<int>()
            ?? throw new FormatException("Missing schema_version.");
        if (version > CurrentSchemaVersion) throw new NotSupportedException($"Unsupported future schema version: {version}.");
    }

    public static GameState Deserialize(string serialized)
    {
        EnsureSupportedSchema(serialized);
        using var document = JsonDocument.Parse(serialized);
        var root = document.RootElement;
        var ships = root.GetProperty("ships").EnumerateArray().Select(ship => new ShipState(
            new ShipId(ship.GetProperty("id").GetString()!), new ZoneId(ship.GetProperty("zone").GetString()!),
            ship.GetProperty("color").GetString()!, DomainEnumSerialization.Parse<ShipSize>(ship.GetProperty("size").GetString()!),
            new GridCell(ship.GetProperty("anchor_x").GetInt32(), ship.GetProperty("anchor_y").GetInt32()),
            DomainEnumSerialization.Parse<Direction>(ship.GetProperty("direction").GetString()!),
            DomainEnumSerialization.Parse<SpecialType>(ship.GetProperty("special").GetString()!),
            ship.GetProperty("passengers").GetInt32(), ship.GetProperty("revealed").GetBoolean())).ToArray();
        var shipMap = ships.ToDictionary(ship => ship.ShipId);
        var zones = root.GetProperty("zones").EnumerateArray().Select(zone => new GridState.Zone(
            new ZoneId(zone.GetProperty("id").GetString()!), zone.GetProperty("width").GetInt32(), zone.GetProperty("height").GetInt32(),
            zone.GetProperty("ships").EnumerateArray().Select(id => new ShipId(id.GetString()!))));
        var queue = new PassengerQueueState(ReadGroups(root.GetProperty("queue")));
        var preQueue = new PreQueueState(ReadGroups(root.GetProperty("prequeue")));
        var docks = root.GetProperty("docks").EnumerateArray().Select(dock =>
        {
            var result = DockState.CreateInitial().Single(item => item.VisualIndex == dock.GetProperty("index").GetInt32());
            if (dock.GetProperty("active").GetBoolean()) result = result.Activate();
            var ship = dock.GetProperty("ship");
            return ship.ValueKind == JsonValueKind.String ? result.WithOccupant(shipMap[new ShipId(ship.GetString()!)]) : result;
        }).ToArray();
        return GameState.Create(root.GetProperty("level_id").GetString()!, new GridState(zones), ships, queue, preQueue, docks,
            root.GetProperty("attempt_id").GetString()!, DomainEnumSerialization.Parse<GamePhase>(root.GetProperty("phase").GetString()!), root.GetProperty("move_index").GetInt32(), tutorialState: root.GetProperty("tutorial").GetString()!);
    }

    private static IEnumerable<PassengerGroup> ReadGroups(JsonElement element) =>
        element.EnumerateArray().Select(group => PassengerGroup.CreateEntry(group.GetProperty("color").GetString()!, group.GetProperty("size").GetInt32()));
}
