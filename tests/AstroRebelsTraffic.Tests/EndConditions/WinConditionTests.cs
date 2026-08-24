using AstroRebelsTraffic.Domain.Rules.EndConditions;
using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Tests.EndConditions;

public class WinConditionTests
{
    [Fact]
    public void Exact_empty_settled_state_wins()
    {
        Assert.True(WinCondition.IsWon(EmptyState(), true));
    }

    [Fact]
    public void Non_settled_evaluation_is_rejected()
    {
        Assert.Throws<InvalidOperationException>(() => WinCondition.IsWon(EmptyState(), false));
    }

    [Fact]
    public void Every_non_empty_container_prevents_win()
    {
        var ship = Ship("ship");
        var zoneState = State(new GridState(new[] { new GridState.Zone(new ZoneId("zone"), 2, 2, new[] { ship.ShipId }) }), new[] { ship });
        Assert.False(WinCondition.IsWon(zoneState, true));

        var dockState = EmptyStateWith(docks: OccupiedDock(ship));
        Assert.False(WinCondition.IsWon(dockState, true));

        var queueState = EmptyStateWith(queue: new PassengerQueueState(new[] { new PassengerGroup("red", 4) }));
        Assert.False(WinCondition.IsWon(queueState, true));

        var preQueueState = EmptyStateWith(preQueue: new PreQueueState(new[] { new PassengerGroup("red", 4) }));
        Assert.False(WinCondition.IsWon(preQueueState, true));

        var reserveState = EmptyStateWith(reserve: new[] { ship }, mechanics: new Dictionary<string, bool> { ["reserve"] = true });
        Assert.False(WinCondition.IsWon(reserveState, true));
    }

    private static GameState EmptyState() => EmptyStateWith();
    private static GameState EmptyStateWith(GridState? grid = null, IEnumerable<DockState>? docks = null, PassengerQueueState? queue = null, PreQueueState? preQueue = null, IEnumerable<ShipState>? reserve = null, IReadOnlyDictionary<string, bool>? mechanics = null) =>
        GameState.Create("level", grid ?? new GridState(new[] { new GridState.Zone(new ZoneId("zone"), 2, 2, Array.Empty<ShipId>()) }), Array.Empty<ShipState>(), queue ?? new PassengerQueueState(Array.Empty<PassengerGroup>()), preQueue ?? new PreQueueState(Array.Empty<PassengerGroup>()), docks ?? DockState.CreateInitial(), reserve: reserve, mechanicFlags: mechanics);
    private static IReadOnlyList<DockState> OccupiedDock(ShipState ship)
    {
        var docks = DockState.CreateInitial().ToArray(); docks[0] = docks[0].WithOccupant(ship); return docks;
    }
    private static ShipState Ship(string id) => new(new ShipId(id), new ZoneId("zone"), "red", ShipSize.Small, Direction.Right, 0, false);
    private static GameState State(GridState grid, IEnumerable<ShipState> ships) => GameState.Create("level", grid, ships, new PassengerQueueState(Array.Empty<PassengerGroup>()), new PreQueueState(Array.Empty<PassengerGroup>()), DockState.CreateInitial());
}
