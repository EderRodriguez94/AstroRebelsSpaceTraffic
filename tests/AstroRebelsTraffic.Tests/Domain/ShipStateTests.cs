using AstroRebelsTraffic.Domain.Rules.Ships;
using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Tests.Domain;

public class ShipStateTests
{
    [Theory]
    [InlineData(ShipSize.Small, 1, 4)]
    [InlineData(ShipSize.Medium, 2, 8)]
    [InlineData(ShipSize.Large, 3, 16)]
    public void Size_mapping_is_canonical(ShipSize size, int length, int capacity)
    {
        Assert.Equal(length, ShipRules.LengthFor(size));
        Assert.Equal(capacity, ShipRules.CapacityFor(size));
    }

    [Fact]
    public void Passenger_count_cannot_exceed_capacity()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new ShipState(new ShipId("s"), new ZoneId("z"), "blue", ShipSize.Small, Direction.Up, 5, false));
    }
}
