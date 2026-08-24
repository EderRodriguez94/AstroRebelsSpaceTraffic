namespace AstroRebelsTraffic.Domain.State;

public sealed record PassengerGroup
{
    public string ColorId { get; }
    public int Size { get; }

    public PassengerGroup(string colorId, int size)
        : this(colorId, size, false)
    {
    }

    private PassengerGroup(string colorId, int size, bool allowEntrySize)
    {
        if (string.IsNullOrWhiteSpace(colorId)) throw new ArgumentException("Color ID cannot be empty.", nameof(colorId));
        if (allowEntrySize ? size is < 1 or > 16 : size is not (4 or 8 or 16)) throw new ArgumentOutOfRangeException(nameof(size), "Passenger groups must contain 4, 8 or 16 passengers.");
        ColorId = colorId; Size = size;
    }

    internal static PassengerGroup CreateEntry(string colorId, int size) => new(colorId, size, true);
}
