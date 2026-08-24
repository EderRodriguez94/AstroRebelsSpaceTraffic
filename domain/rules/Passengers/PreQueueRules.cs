using AstroRebelsTraffic.Domain.Rules.Boarding;
using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Domain.Rules.Passengers;

public sealed record PreQueueScanResult(PreQueueState Remaining, IReadOnlyList<DockState> Docks, IReadOnlyList<BoardingFact> Facts, bool Changed);

public static class PreQueueRules
{
    public static PreQueueScanResult Scan(PreQueueState preQueue, IReadOnlyList<DockState> docks)
    {
        var originalEntries = preQueue.Groups.ToArray();
        var survivors = new List<PassengerGroup>();
        var currentDocks = docks.ToArray();
        var facts = new List<BoardingFact>();

        foreach (var entry in originalEntries)
        {
            var result = BoardingResolver.Board(currentDocks, entry.ColorId, entry.Size);
            currentDocks = result.Docks.ToArray();
            facts.AddRange(result.Facts);
            if (result.RemainingCount > 0) survivors.Add(PassengerGroup.CreateEntry(entry.ColorId, result.RemainingCount));
        }

        return new PreQueueScanResult(new PreQueueState(survivors, preQueue.Capacity), currentDocks, facts, facts.Count > 0);
    }
}
