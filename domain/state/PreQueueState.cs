namespace AstroRebelsTraffic.Domain.State;

public sealed class PreQueueState
{
    public const int DefaultCapacity = 16;
    public int Capacity { get; }
    public IReadOnlyList<PassengerGroup> Groups { get; }
    public int PassengerCount => Groups.Sum(group => group.Size);

    public PreQueueState(IEnumerable<PassengerGroup> groups, int capacity = DefaultCapacity)
    {
        if (capacity <= 0) throw new ArgumentOutOfRangeException(nameof(capacity));
        Capacity = capacity; Groups = groups.ToArray();
        if (PassengerCount > Capacity) throw new ArgumentException("Prequeue exceeds capacity.", nameof(groups));
    }

    public PreQueueState Append(PassengerGroup group)
    {
        if (PassengerCount + group.Size > Capacity) throw new InvalidOperationException("Prequeue capacity exceeded.");
        return new PreQueueState(Groups.Append(group), Capacity);
    }

    public (PassengerGroup Group, PreQueueState Remaining) RemoveFront()
    {
        if (Groups.Count == 0) throw new InvalidOperationException("Cannot remove from an empty prequeue.");
        return (Groups[0], new PreQueueState(Groups.Skip(1), Capacity));
    }
}
