using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Domain.Rules.Grid;

/// <summary>Derives a ship's occupied cells from its anchor and exit direction.</summary>
/// <remarks>The anchor is the first occupied cell nearest the ship's entry side.</remarks>
public static class ShipFootprint
{
    public static IReadOnlyList<GridCell> Derive(GridCell anchor, Direction direction, int length)
    {
        if (length is < 1 or > 3)
            throw new ArgumentOutOfRangeException(nameof(length), "Ship length must be 1, 2 or 3.");

        var step = direction switch
        {
            Direction.Up => (X: 0, Y: -1),
            Direction.Down => (X: 0, Y: 1),
            Direction.Left => (X: -1, Y: 0),
            Direction.Right => (X: 1, Y: 0),
            _ => throw new ArgumentOutOfRangeException(nameof(direction))
        };

        return Enumerable.Range(0, length)
            .Select(offset => new GridCell(anchor.X + step.X * offset, anchor.Y + step.Y * offset))
            .ToArray();
    }
}
