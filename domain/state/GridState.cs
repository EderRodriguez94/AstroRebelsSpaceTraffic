namespace AstroRebelsTraffic.Domain.State;

public sealed class GridState
{
    public sealed record Zone
    {
        public ZoneId Id { get; }
        public int Width { get; }
        public int Height { get; }
        public IReadOnlyList<ShipId> ShipIds { get; }

        public Zone(ZoneId id, int width, int height, IEnumerable<ShipId> shipIds)
        {
            if (width <= 0) throw new ArgumentOutOfRangeException(nameof(width));
            if (height <= 0) throw new ArgumentOutOfRangeException(nameof(height));
            Id = id; Width = width; Height = height; ShipIds = shipIds.ToArray();
            if (ShipIds.Distinct().Count() != ShipIds.Count) throw new ArgumentException("Ship IDs must be unique.", nameof(shipIds));
        }
    }

    public IReadOnlyList<Zone> Zones { get; }

    public GridState(IEnumerable<Zone> zones)
    {
        var copy = zones.ToArray();
        if (copy.Length == 0) throw new ArgumentException("At least one zone is required.", nameof(zones));
        if (copy.Select(z => z.Id).Distinct().Count() != copy.Length) throw new ArgumentException("Zone IDs must be unique.", nameof(zones));
        Zones = copy;
    }

    public string Serialize() => string.Join("|", Zones.Select(z => $"{z.Id}:{z.Width}x{z.Height}:{string.Join(',', z.ShipIds)}"));
}
