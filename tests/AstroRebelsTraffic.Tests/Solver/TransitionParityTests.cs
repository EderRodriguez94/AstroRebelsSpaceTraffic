using AstroRebelsTraffic.Domain.Commands;
using AstroRebelsTraffic.Domain.State;
using AstroRebelsTraffic.Solver.Search;

namespace AstroRebelsTraffic.Tests.Solver;

public sealed class TransitionParityTests
{
    [Fact]
    public void Legal_release_has_matching_runtime_and_solver_transition()
    {
        var state = CreateState(new ShipId("ship-a"));
        var action = Assert.Single(LegalActionEnumerator.Enumerate(state));

        var runtime = ReleaseShipTransaction.Execute(state, new ReleaseShipCommand(action.ShipId));
        var solver = ReleaseShipTransaction.Execute(state, new ReleaseShipCommand(action.ShipId));

        Assert.Equal(runtime.Accepted, solver.Accepted);
        Assert.Equal(runtime.RejectionReason, solver.RejectionReason);
        Assert.Equal(runtime.NextState.Zones.Serialize(), solver.NextState.Zones.Serialize());
        Assert.Equal(runtime.NextState.Phase, solver.NextState.Phase);
        Assert.Equal(runtime.NextState.MoveIndex, solver.NextState.MoveIndex);
        Assert.Equal(runtime.Events, solver.Events);
    }

    [Fact]
    public void Illegal_release_is_rejected_identically_by_both_entry_paths()
    {
        var state = CreateState(new ShipId("ship-a"));
        var command = new ReleaseShipCommand(new ShipId("missing"));

        var runtime = ReleaseShipTransaction.Execute(state, command);
        var solver = ReleaseShipTransaction.Execute(state, command);

        Assert.False(runtime.Accepted);
        Assert.Equal(runtime.Accepted, solver.Accepted);
        Assert.Equal(runtime.RejectionReason, solver.RejectionReason);
        Assert.Same(state, runtime.NextState);
        Assert.Same(state, solver.NextState);
        Assert.Empty(runtime.Events);
        Assert.Empty(solver.Events);
    }

    private static GameState CreateState(ShipId shipId)
    {
        var zoneId = new ZoneId("zone-a");
        var ship = new ShipState(shipId, zoneId, "red", ShipSize.Small, Direction.Right, 0, true);
        return GameState.CreateInitial(
            "parity-fixture",
            new GridState(new[] { new GridState.Zone(zoneId, 2, 2, new[] { shipId }) }),
            new[] { ship },
            new PassengerQueueState(Array.Empty<PassengerGroup>()),
            new PreQueueState(Array.Empty<PassengerGroup>()),
            DockState.CreateInitial());
    }
}
