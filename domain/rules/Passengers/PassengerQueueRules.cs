using AstroRebelsTraffic.Domain.Rules.Boarding;
using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Domain.Rules.Passengers;

public sealed record GroupAdmissionResult(bool Accepted, PassengerQueueState Queue, PreQueueState PreQueue, IReadOnlyList<DockState> Docks, IReadOnlyList<BoardingFact> Facts, string? RejectionReason)
{
    public static GroupAdmissionResult Rejected(PassengerQueueState queue, PreQueueState preQueue, IReadOnlyList<DockState> docks, string reason) =>
        new(false, queue, preQueue, docks.ToArray(), Array.Empty<BoardingFact>(), reason);
}

public static class PassengerQueueRules
{
    public static GroupAdmissionResult AdmitFront(PassengerQueueState queue, PreQueueState preQueue, IReadOnlyList<DockState> docks)
    {
        var front = queue.Front;
        if (front is null) return GroupAdmissionResult.Rejected(queue, preQueue, docks, "QUEUE_EMPTY");

        var projection = BoardingResolver.Board(docks, front.ColorId, front.Size);
        var freeCapacity = preQueue.Capacity - preQueue.PassengerCount;
        if (projection.RemainingCount > freeCapacity)
            return GroupAdmissionResult.Rejected(queue, preQueue, docks, "PREQUEUE_REMAINDER_DOES_NOT_FIT");

        var remainingGroups = queue.Groups.Skip(1).ToArray();
        var nextQueue = new PassengerQueueState(remainingGroups);
        var nextPreQueue = projection.RemainingCount == 0
            ? preQueue
            : preQueue.Append(PassengerGroup.CreateEntry(front.ColorId, projection.RemainingCount));
        return new(true, nextQueue, nextPreQueue, projection.Docks, projection.Facts, null);
    }
}
