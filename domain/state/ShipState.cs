namespace AstroRebelsTraffic.Domain.State;

public sealed record ShipState
{
    public ShipId ShipId { get; }
    public ZoneId ZoneId { get; }
    public string ColorId { get; }
    public ShipSize Size { get; }
    public Direction ExitDirection { get; }
    public int PassengerCount { get; }
    public bool IsRevealed { get; }
    public int Capacity => Rules.Ships.ShipRules.CapacityFor(Size);
    public int Length => Rules.Ships.ShipRules.LengthFor(Size);

    public ShipState(ShipId shipId, ZoneId zoneId, string colorId, ShipSize size, Direction exitDirection, int passengerCount, bool isRevealed)
    {
        if (string.IsNullOrWhiteSpace(colorId)) throw new ArgumentException("Color ID cannot be empty.", nameof(colorId));
        ShipId = shipId; ZoneId = zoneId; ColorId = colorId; Size = size; ExitDirection = exitDirection; PassengerCount = passengerCount; IsRevealed = isRevealed;
        if (passengerCount < 0 || passengerCount > Capacity) throw new ArgumentOutOfRangeException(nameof(passengerCount));
    }
}
