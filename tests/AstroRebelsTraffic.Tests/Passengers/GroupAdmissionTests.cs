using AstroRebelsTraffic.Domain.Rules.Passengers;
using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Tests.Passengers;

public class GroupAdmissionTests
{
    [Fact]
    public void Rejects_atomic_admission_when_remainder_does_not_fit_and_preserves_state()
    {
        var queue = new PassengerQueueState(new[] { new PassengerGroup("red", 8), new PassengerGroup("blue", 4) });
        var preQueue = new PreQueueState(new[] { new PassengerGroup("green", 8), new PassengerGroup("yellow", 4) });
        var docks = DockState.CreateInitial().ToArray();
        var before = Snapshot(queue, preQueue, docks);

        var result = PassengerQueueRules.AdmitFront(queue, preQueue, docks);

        Assert.False(result.Accepted);
        Assert.Equal("PREQUEUE_REMAINDER_DOES_NOT_FIT", result.RejectionReason);
        Assert.Equal(before, Snapshot(result.Queue, result.PreQueue, result.Docks));
    }

    [Fact]
    public void Admits_only_the_front_group_and_conserves_the_unboarded_remainder()
    {
        var queue = new PassengerQueueState(new[] { new PassengerGroup("red", 8), new PassengerGroup("blue", 4) });
        var preQueue = new PreQueueState(Array.Empty<PassengerGroup>());
        var docks = DockState.CreateInitial().ToArray();
        docks[0] = docks[0].WithOccupant(Ship("red"));

        var result = PassengerQueueRules.AdmitFront(queue, preQueue, docks);

        Assert.True(result.Accepted);
        Assert.Equal(new[] { "blue" }, result.Queue.Groups.Select(group => group.ColorId));
        Assert.Equal(new[] { "red" }, result.PreQueue.Groups.Select(group => group.ColorId));
        Assert.Equal(4, result.PreQueue.PassengerCount);
        Assert.Equal(8, result.Facts.Sum(fact => fact.PassengerCount) + result.PreQueue.PassengerCount);
    }

    private static ShipState Ship(string color) =>
        new(new ShipId("ship"), new ZoneId("zone"), color, ShipSize.Small, Direction.Right, 0, false);

    private static string Snapshot(PassengerQueueState queue, PreQueueState preQueue, IReadOnlyList<DockState> docks) =>
        $"{queue.Serialize()}|{string.Join(';', preQueue.Groups.Select(group => $"{group.ColorId}:{group.Size}"))}|{string.Join(';', docks.Select(dock => dock.Occupant?.ShipId.Value ?? "empty"))}";
}
