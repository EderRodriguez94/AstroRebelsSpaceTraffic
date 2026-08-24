using AstroRebelsTraffic.Domain.Serialization;
using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Application.Undo;

public sealed class UndoHistory
{
    private readonly Stack<(GameState State, string Canonical)> snapshots = new();

    public int Count => snapshots.Count;

    public void CaptureAcceptedMove(GameState settledState, bool undoEnabled)
    {
        if (undoEnabled) snapshots.Push((settledState, GameStateSerializer.Serialize(settledState)));
    }

    public bool TryUndo(out GameState? restoredState)
    {
        if (snapshots.Count == 0) { restoredState = null; return false; }
        var snapshot = snapshots.Pop();
        restoredState = GameStateSerializer.Deserialize(snapshot.Canonical);
        return true;
    }
}
