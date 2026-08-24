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
}
