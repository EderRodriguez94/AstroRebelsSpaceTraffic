using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Tests.Domain;

public class PreQueueStateTests
{
    [Fact]
    public void Default_capacity_counts_individual_passengers()
    {
        var state = new PreQueueState(new[] { new PassengerGroup("red", 8) });
        Assert.Equal(16, state.Capacity);
        Assert.Equal(8, state.PassengerCount);
    }

    [Fact]
    public void Append_and_remove_preserve_survivor_order()
    {
        var state = new PreQueueState(Array.Empty<PassengerGroup>(), 12)
            .Append(new PassengerGroup("red", 4)).Append(new PassengerGroup("blue", 8));
        var removed = state.RemoveFront();
        Assert.Equal("red", removed.Group.ColorId);
        Assert.Equal("blue", removed.Remaining.Groups[0].ColorId);
        Assert.Throws<InvalidOperationException>(() => removed.Remaining.Append(new PassengerGroup("green", 8)));
    }
}
