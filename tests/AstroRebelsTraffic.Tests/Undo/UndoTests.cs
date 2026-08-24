using AstroRebelsTraffic.Application.Undo;
using AstroRebelsTraffic.Domain.Serialization;
using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Tests.Undo;

public sealed class UndoTests
{
    [Fact]
    public void Undo_restores_canonical_snapshot_and_rejected_capture_is_ignored()
    {
        var state = GameState.CreateInitial("level", new GridState(new[] { new GridState.Zone(new ZoneId("z"), 2, 2, Array.Empty<ShipId>()) }), Array.Empty<ShipState>(), new PassengerQueueState(Array.Empty<PassengerGroup>()), new PreQueueState(Array.Empty<PassengerGroup>()), DockState.CreateInitial());
        var history = new UndoHistory();
        history.CaptureAcceptedMove(state, undoEnabled: false);
        Assert.Equal(0, history.Count);
        history.CaptureAcceptedMove(state, undoEnabled: true);
        Assert.True(history.TryUndo(out var restored));
        Assert.Equal(GameStateSerializer.Serialize(state), GameStateSerializer.Serialize(restored!));
        Assert.False(history.TryUndo(out _));
    }
}
