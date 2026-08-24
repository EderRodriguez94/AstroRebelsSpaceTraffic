using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Tests.Domain;

public class GridStateTests
{
    [Fact]
    public void One_and_two_zone_states_have_stable_serialization()
    {
        var one = new GridState(new[] { new GridState.Zone(new ZoneId("z1"), 3, 4, new[] { new ShipId("s1") }) });
        var two = new GridState(new[]
        {
            new GridState.Zone(new ZoneId("z1"), 3, 4, new[] { new ShipId("s1") }),
            new GridState.Zone(new ZoneId("z2"), 2, 2, new[] { new ShipId("s2") })
        });
        Assert.Equal("z1:3x4:s1", one.Serialize());
        Assert.Equal("z1:3x4:s1|z2:2x2:s2", two.Serialize());
    }

    [Fact]
    public void Non_positive_dimensions_are_rejected()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new GridState.Zone(new ZoneId("z"), 0, 2, Array.Empty<ShipId>()));
    }
}
