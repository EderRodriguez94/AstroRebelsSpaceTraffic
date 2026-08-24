using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Domain.Rules.Grid;

public sealed record PathValidationResult(bool IsClear, IReadOnlyList<GridCell> AnchorPath, string? BlockerCode, ShipId? BlockerShipId)
{
    public static PathValidationResult Clear(IReadOnlyList<GridCell> path) => new(true, path, null, null);
    public static PathValidationResult Blocked(IReadOnlyList<GridCell> path, string code, ShipId? shipId) => new(false, path, code, shipId);
}

public static class PathValidator
{
    public static PathValidationResult GetExitPath(GameState state, ShipId shipId)
    {
        if (!state.ShipsById.TryGetValue(shipId, out var ship))
            return PathValidationResult.Blocked(Array.Empty<GridCell>(), "UNKNOWN_SHIP", shipId);

        var zone = state.Zones.Zones.SingleOrDefault(candidate => candidate.Id == ship.ZoneId);
        if (zone is null)
            return PathValidationResult.Blocked(Array.Empty<GridCell>(), "UNKNOWN_ZONE", null);

        var query = GridQuery.From(state);
        var path = new List<GridCell>();
        var anchor = ship.AnchorCell;
        var step = ship.ExitDirection switch
        {
            Direction.Up => (X: 0, Y: -1),
            Direction.Down => (X: 0, Y: 1),
            Direction.Left => (X: -1, Y: 0),
            Direction.Right => (X: 1, Y: 0),
            _ => throw new ArgumentOutOfRangeException(nameof(ship.ExitDirection))
        };

        while (true)
        {
            anchor = new GridCell(anchor.X + step.X, anchor.Y + step.Y);
            path.Add(anchor);
            var footprint = ShipFootprint.Derive(anchor, ship.ExitDirection, ship.Length);
            foreach (var cell in footprint)
            {
                if (!query.IsWithinBounds(zone.Id, cell)) continue;
                if (query.TryGetOccupant(zone.Id, cell, out var blocker) && blocker != shipId)
                    return PathValidationResult.Blocked(path, "BLOCKED_BY_SHIP", blocker);
            }

            if (IsBeyondBoundary(footprint, zone.Width, zone.Height, ship.ExitDirection))
                return PathValidationResult.Clear(path);
        }
    }

    private static bool IsBeyondBoundary(IReadOnlyList<GridCell> footprint, int width, int height, Direction direction) => direction switch
    {
        Direction.Up => footprint.All(cell => cell.Y < 0),
        Direction.Down => footprint.All(cell => cell.Y >= height),
        Direction.Left => footprint.All(cell => cell.X < 0),
        Direction.Right => footprint.All(cell => cell.X >= width),
        _ => false
    };
}
