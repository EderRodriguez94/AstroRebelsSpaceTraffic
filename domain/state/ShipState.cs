namespace AstroRebelsTraffic.Domain.State;

public sealed record ShipState
{
    public ShipId ShipId { get; }
    public ZoneId ZoneId { get; }
    public string ColorId { get; }
    public ShipSize Size { get; }
    public GridCell AnchorCell { get; }
    public Direction ExitDirection { get; }
    public SpecialType SpecialType { get; }
    public int PassengerCount { get; }
    public bool IsRevealed { get; }
    public int Capacity => Rules.Ships.ShipRules.CapacityFor(Size);
    public int Length => Rules.Ships.ShipRules.LengthFor(Size);

    public ShipState(ShipId shipId, ZoneId zoneId, string colorId, ShipSize size, Direction exitDirection, int passengerCount, bool isRevealed)
        : this(shipId, zoneId, colorId, size, new GridCell(0, 0), exitDirection, SpecialType.Normal, passengerCount, isRevealed)
    {
    }

    public ShipState(ShipId shipId, ZoneId zoneId, string colorId, ShipSize size, GridCell anchorCell, Direction exitDirection, SpecialType specialType, int passengerCount, bool isRevealed)
    {
        if (string.IsNullOrWhiteSpace(colorId)) throw new ArgumentException("Color ID cannot be empty.", nameof(colorId));
        ShipId = shipId; ZoneId = zoneId; ColorId = colorId; Size = size; AnchorCell = anchorCell; ExitDirection = exitDirection; SpecialType = specialType; PassengerCount = passengerCount; IsRevealed = isRevealed;
        if (passengerCount < 0 || passengerCount > Capacity) throw new ArgumentOutOfRangeException(nameof(passengerCount));
    }
}
