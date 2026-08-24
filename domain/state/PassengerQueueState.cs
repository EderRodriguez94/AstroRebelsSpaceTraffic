namespace AstroRebelsTraffic.Domain.State;

public sealed class PassengerQueueState
{
    public IReadOnlyList<PassengerGroup> Groups { get; }

    public PassengerQueueState(IEnumerable<PassengerGroup> groups)
    {
        var copy = groups.ToArray();
        if (copy.Any(group => group.Size is not (4 or 8 or 16))) throw new ArgumentOutOfRangeException(nameof(groups), "Main source groups must contain 4, 8 or 16 passengers.");
        Groups = copy;
    }

    public PassengerGroup? Front => Groups.Count == 0 ? null : Groups[0];

    public (PassengerGroup Group, PassengerQueueState Remaining) ConsumeFront()
    {
        if (Front is null) throw new InvalidOperationException("Cannot consume an empty passenger queue.");
        return (Front, new PassengerQueueState(Groups.Skip(1)));
    }

    public string Serialize() => string.Join("|", Groups.Select(g => $"{g.ColorId}:{g.Size}"));
}
