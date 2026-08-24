using AstroRebelsTraffic.Domain.Rules.Release;
using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Tests.Grid;

public class ReleaseValidationReasonTests
{
    [Fact]
    public void Reports_wrong_phase_before_other_failures()
    {
        var state = State(GamePhase.Won, Array.Empty<ShipState>(), DockState.CreateInitial());

        var before = Snapshot(state);
        var result = ReleaseValidator.Validate(state, new ShipId("missing"));

        Assert.False(result.IsAccepted);
        Assert.Equal(ReleaseValidationReason.WrongPhase, result.Reason);
        Assert.Equal(before, Snapshot(state));
    }

    [Fact]
    public void Reports_unknown_ship_before_path_and_docks()
    {
        var state = State(GamePhase.Playing, Array.Empty<ShipState>(), DockState.CreateInitial());

        var result = ReleaseValidator.Validate(state, new ShipId("missing"));

        Assert.Equal(ReleaseValidationReason.UnknownShip, result.Reason);
    }

    [Fact]
    public void Reports_blocked_path_before_full_docks()
    {
        var moving = Ship("moving", new GridCell(0, 0), ShipSize.Small);
        var blocker = Ship("blocker", new GridCell(1, 0), ShipSize.Small);
        var state = State(GamePhase.Playing, new[] { moving, blocker }, DockState.CreateInitial());

        var result = ReleaseValidator.Validate(state, moving.ShipId);

        Assert.Equal(ReleaseValidationReason.BlockedPath, result.Reason);
        Assert.Equal(blocker.ShipId, result.BlockerShipId);
    }

    [Fact]
    public void Reports_full_docks_after_a_clear_path()
    {
        var moving = Ship("moving", new GridCell(0, 0), ShipSize.Small);
        var docks = DockState.CreateInitial().Select(dock => dock.IsActive ? dock.WithOccupant(Ship($"dock-{dock.VisualIndex}", new GridCell(0, 0), ShipSize.Small)) : dock).ToArray();
        var state = State(GamePhase.Playing, new[] { moving }, docks);

        var result = ReleaseValidator.Validate(state, moving.ShipId);

        Assert.Equal(ReleaseValidationReason.DocksFull, result.Reason);
    }

    private static ShipState Ship(string id, GridCell anchor, ShipSize size) =>
        new(new ShipId(id), new ZoneId("zone"), "red", size, anchor, Direction.Right, SpecialType.Normal, 0, false);

    private static GameState State(GamePhase phase, IEnumerable<ShipState> ships, IEnumerable<DockState> docks) =>
        GameState.Create("level", new GridState(new[] { new GridState.Zone(new ZoneId("zone"), 5, 2, ships.Select(ship => ship.ShipId)) }), ships, new PassengerQueueState(Array.Empty<PassengerGroup>()), new PreQueueState(Array.Empty<PassengerGroup>()), docks, phase: phase);

    private static string Snapshot(GameState state) => $"{state.Phase}|{state.MoveIndex}|{state.Zones.Serialize()}|{string.Join(';', state.ShipsById.OrderBy(pair => pair.Key.Value).Select(pair => $"{pair.Key}:{pair.Value.AnchorCell.X},{pair.Value.AnchorCell.Y}"))}";
}
