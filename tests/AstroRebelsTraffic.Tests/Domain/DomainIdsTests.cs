using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Tests.Domain;

public class DomainIdsTests
{
    [Fact]
    public void IDs_have_value_equality_and_deterministic_text()
    {
        Assert.Equal(new ShipId("ship-1"), new ShipId("ship-1"));
        Assert.Equal("ship-1", new ShipId("ship-1").ToString());
    }

    [Fact]
    public void Empty_id_is_rejected()
    {
        Assert.Throws<ArgumentException>(() => new ShipId(" "));
    }

    [Fact]
    public void Enums_round_trip_and_unknown_values_fail()
    {
        var text = DomainEnumSerialization.Serialize(Direction.Left);
        Assert.Equal(Direction.Left, DomainEnumSerialization.Parse<Direction>(text));
        var error = Assert.Throws<FormatException>(() => DomainEnumSerialization.Parse<Direction>("Diagonal"));
        Assert.Contains("Unknown Direction", error.Message);
    }
}
