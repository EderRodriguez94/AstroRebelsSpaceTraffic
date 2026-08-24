using AstroRebelsTraffic.Domain.Serialization;
using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Tests.Domain;

public sealed class GameStateSerializationTests
{
    [Fact]
    public void Serialization_is_deterministic_and_has_explicit_schema()
    {
        var state = GameState.CreateInitial("level", new GridState(new[] { new GridState.Zone(new ZoneId("z"), 2, 2, Array.Empty<ShipId>()) }), Array.Empty<ShipState>(), new PassengerQueueState(Array.Empty<PassengerGroup>()), new PreQueueState(Array.Empty<PassengerGroup>()), DockState.CreateInitial());
        var first = GameStateSerializer.Serialize(state);
        Assert.Equal(first, GameStateSerializer.Serialize(state));
        Assert.Contains("\"schema_version\":1", first);
        GameStateSerializer.EnsureSupportedSchema(first);
        Assert.Equal(first, GameStateSerializer.Serialize(GameStateSerializer.Deserialize(first)));
    }

    [Fact]
    public void Future_schema_is_rejected()
    {
        Assert.Throws<NotSupportedException>(() => GameStateSerializer.EnsureSupportedSchema("{\"schema_version\":99}"));
    }
}
