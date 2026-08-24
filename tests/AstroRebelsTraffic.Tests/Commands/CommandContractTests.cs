using AstroRebelsTraffic.Domain.Commands;
using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Tests.Commands;

public sealed class CommandContractTests
{
    [Fact]
    public void Commands_are_immutable_records()
    {
        var command = new ReleaseShipCommand(new ShipId("ship-1"));
        Assert.Equal(new ShipId("ship-1"), command.ShipId);
        Assert.Equal("ship-1", command.ShipId.ToString());
    }

    [Fact]
    public void Rejected_result_has_unchanged_state_and_no_events()
    {
        var state = GameState.CreateInitial(
            "level",
            new GridState(new[] { new GridState.Zone(new ZoneId("zone"), 2, 2, Array.Empty<ShipId>()) }),
            Array.Empty<ShipState>(),
            new PassengerQueueState(Array.Empty<PassengerGroup>()),
            new PreQueueState(Array.Empty<PassengerGroup>()),
            DockState.CreateInitial());
        var result = CommandResult.Rejected(state, CommandRejectionReason.ShipNotFound);

        Assert.False(result.Accepted);
        Assert.Same(state, result.NextState);
        Assert.Empty(result.Events);
    }
}
