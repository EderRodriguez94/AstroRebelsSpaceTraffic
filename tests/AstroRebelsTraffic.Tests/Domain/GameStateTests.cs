using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Tests.Domain;

public class GameStateTests
{
    [Fact]
    public void Initial_state_copies_mutable_inputs()
    {
        var ships = new List<ShipState> { new(new ShipId("s"), new ZoneId("z"), "red", ShipSize.Small, Direction.Up, 0, false) };
        var queue = new PassengerQueueState(new[] { new PassengerGroup("red", 4) });
        var state = GameState.CreateInitial("level-1", new GridState(new[] { new GridState.Zone(new ZoneId("z"), 2, 2, new[] { new ShipId("s") }) }), ships, queue, new PreQueueState(Array.Empty<PassengerGroup>()), DockState.CreateInitial());
        ships.Clear();
        Assert.Single(state.ShipsById);
        Assert.Equal("red:4", state.PassengerQueue.Serialize());
        Assert.Equal(GamePhase.Playing, state.Phase);
    }
}
