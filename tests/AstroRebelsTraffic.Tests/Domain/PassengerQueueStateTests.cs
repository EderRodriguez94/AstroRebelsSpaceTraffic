using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Tests.Domain;

public class PassengerQueueStateTests
{
    [Theory]
    [InlineData(4)]
    [InlineData(8)]
    [InlineData(16)]
    public void Only_canonical_group_sizes_are_allowed(int size) => _ = new PassengerGroup("red", size);

    [Fact]
    public void Invalid_group_size_is_rejected() => Assert.Throws<ArgumentOutOfRangeException>(() => new PassengerGroup("red", 5));

    [Fact]
    public void Repeated_colors_preserve_front_to_back_order()
    {
        var queue = new PassengerQueueState(new[] { new PassengerGroup("red", 4), new PassengerGroup("blue", 8), new PassengerGroup("red", 16) });
        var consumed = queue.ConsumeFront();
        Assert.Equal("red:4|blue:8|red:16", queue.Serialize());
        Assert.Equal("blue:8|red:16", consumed.Remaining.Serialize());
    }
}
