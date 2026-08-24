namespace AstroRebelsTraffic.Domain.State;

public readonly record struct GridCell
{
    public int X { get; }
    public int Y { get; }

    public GridCell(int x, int y)
    {
        X = x;
        Y = y;
    }
}
