using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Domain.Rules.Grid;

public readonly record struct GridPosition(ZoneId ZoneId, GridCell Cell);
public sealed record GridQueryIssue(string Code, string Path, IReadOnlyList<ShipId> ShipIds);

/// <summary>Read-only bounds and occupancy queries derived from one GameState snapshot.</summary>
public sealed class GridQuery
{
    private readonly Dictionary<GridPosition, ShipId> _occupancy;
    private readonly Dictionary<ZoneId, (int Width, int Height)> _bounds;

    public IReadOnlyList<GridQueryIssue> Issues { get; }

    private GridQuery(Dictionary<GridPosition, ShipId> occupancy, Dictionary<ZoneId, (int Width, int Height)> bounds, IReadOnlyList<GridQueryIssue> issues)
    {
        _occupancy = occupancy;
        _bounds = bounds;
        Issues = issues;
    }

    public static GridQuery From(GameState state)
    {
        var occupancy = new Dictionary<GridPosition, ShipId>();
        var bounds = state.Zones.Zones.ToDictionary(zone => zone.Id, zone => (zone.Width, zone.Height));
        var issues = new List<GridQueryIssue>();

        foreach (var zone in state.Zones.Zones.OrderBy(zone => zone.Id.Value, StringComparer.Ordinal))
        {
            foreach (var shipId in zone.ShipIds.OrderBy(id => id.Value, StringComparer.Ordinal))
            {
                if (!state.ShipsById.TryGetValue(shipId, out var ship))
                {
                    issues.Add(new("UNKNOWN_SHIP", $"zones[{zone.Id}].ship_ids[{shipId}]", new[] { shipId }));
                    continue;
                }

                var footprint = ShipFootprint.Derive(ship.AnchorCell, ship.ExitDirection, ship.Length);
                for (var index = 0; index < footprint.Count; index++)
                {
                    var cell = footprint[index];
                    var position = new GridPosition(zone.Id, cell);
                    if (cell.X < 0 || cell.Y < 0 || cell.X >= zone.Width || cell.Y >= zone.Height)
                    {
                        issues.Add(new("OUT_OF_BOUNDS", $"ships_by_id.{shipId}.footprint[{index}]", new[] { shipId }));
                        continue;
                    }

                    if (occupancy.TryGetValue(position, out var blocker))
                    {
                        var ids = new[] { blocker, shipId }.OrderBy(id => id.Value, StringComparer.Ordinal).ToArray();
                        issues.Add(new("OVERLAP", $"zones[{zone.Id}].occupancy[{cell.X},{cell.Y}]", ids));
                        continue;
                    }

                    occupancy[position] = shipId;
                }
            }
        }

        return new GridQuery(occupancy, bounds, issues.OrderBy(issue => issue.Path, StringComparer.Ordinal).ThenBy(issue => issue.Code, StringComparer.Ordinal).ToArray());
    }

    public bool IsWithinBounds(ZoneId zoneId, GridCell cell) =>
        _bounds.TryGetValue(zoneId, out var bounds) && cell.X >= 0 && cell.Y >= 0 && cell.X < bounds.Width && cell.Y < bounds.Height;

    public bool TryGetOccupant(ZoneId zoneId, GridCell cell, out ShipId shipId) =>
        _occupancy.TryGetValue(new GridPosition(zoneId, cell), out shipId);

    public ShipId? GetBlocker(ZoneId zoneId, GridCell cell) =>
        TryGetOccupant(zoneId, cell, out var shipId) ? shipId : null;
}
