namespace AstroRebelsTraffic.Domain.State;

public sealed record PassengerGroup
{
    public string ColorId { get; }
    public int Size { get; }

    public PassengerGroup(string colorId, int size)
    {
        if (string.IsNullOrWhiteSpace(colorId)) throw new ArgumentException("Color ID cannot be empty.", nameof(colorId));
        if (size is not (4 or 8 or 16)) throw new ArgumentOutOfRangeException(nameof(size), "Passenger groups must contain 4, 8 or 16 passengers.");
        ColorId = colorId; Size = size;
    }
}
