using AstroRebelsTraffic.Domain.Rules.Grid;
using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Tests.Grid;

public class ShipFootprintTests
{
    public static IEnumerable<object[]> Cases()
    {
        foreach (var direction in Enum.GetValues<Direction>())
            foreach (var length in new[] { 1, 2, 3 })
                yield return new object[] { direction, length };
    }

    [Theory]
    [MemberData(nameof(Cases))]
    public void Derives_exact_cells_in_direction(Direction direction, int length)
    {
        var actual = ShipFootprint.Derive(new GridCell(10, 20), direction, length);
        var expected = direction switch
        {
            Direction.Up => Enumerable.Range(0, length).Select(i => new GridCell(10, 20 - i)),
            Direction.Down => Enumerable.Range(0, length).Select(i => new GridCell(10, 20 + i)),
            Direction.Left => Enumerable.Range(0, length).Select(i => new GridCell(10 - i, 20)),
            Direction.Right => Enumerable.Range(0, length).Select(i => new GridCell(10 + i, 20)),
            _ => throw new ArgumentOutOfRangeException(nameof(direction))
        };

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Rejects_lengths_outside_canonical_range() =>
        Assert.Throws<ArgumentOutOfRangeException>(() => ShipFootprint.Derive(new GridCell(0, 0), Direction.Up, 4));
}
