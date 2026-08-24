namespace AstroRebelsTraffic.Domain.State;

public readonly record struct GridCell
{
    public int X { get; }
    public int Y { get; }

    public GridCell(int x, int y)
    {
        if (x < 0 || y < 0) throw new ArgumentOutOfRangeException(nameof(x), "Grid coordinates cannot be negative.");
        X = x;
        Y = y;
    }
}
