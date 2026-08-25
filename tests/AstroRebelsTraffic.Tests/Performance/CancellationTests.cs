using AstroRebelsTraffic.Application.BackgroundWork;
using AstroRebelsTraffic.Domain.State;
using AstroRebelsTraffic.Solver.Search;

namespace AstroRebelsTraffic.Tests.Performance;

public sealed class CancellationTests
{
    [Fact]
    public async Task Solver_observes_cancellation_on_a_serialized_snapshot()
    {
        using var cancellation = new CancellationTokenSource();
        cancellation.Cancel();
        var original = GameState.CreateInitial(
            "level",
            new GridState(new[] { new GridState.Zone(new ZoneId("zone"), 2, 2, Array.Empty<ShipId>()) }),
            Array.Empty<ShipState>(),
            new PassengerQueueState(Array.Empty<PassengerGroup>()),
            new PreQueueState(Array.Empty<PassengerGroup>()),
            DockState.CreateInitial());

        var result = await BackgroundSolverService.SolveAsync(original, 64, TimeSpan.FromSeconds(1), cancellation.Token);

        Assert.False(result.Solved);
        Assert.Equal(0, original.MoveIndex);
    }

    [Fact]
    public async Task Generation_cancellation_stops_before_worker_execution()
    {
        using var cancellation = new CancellationTokenSource();
        cancellation.Cancel();

        await Assert.ThrowsAsync<OperationCanceledException>(() =>
            BackgroundGenerationService.GenerateAsync(7, cancellation.Token));
    }

    [Fact]
    public void Solver_budget_returns_without_touching_domain_state()
    {
        var original = GameState.CreateInitial(
            "level",
            new GridState(new[] { new GridState.Zone(new ZoneId("zone"), 2, 2, Array.Empty<ShipId>()) }),
            Array.Empty<ShipState>(),
            new PassengerQueueState(Array.Empty<PassengerGroup>()),
            new PreQueueState(Array.Empty<PassengerGroup>()),
            DockState.CreateInitial());

        var result = BaselineSolver.Solve(original, 64, budget: TimeSpan.Zero);

        Assert.False(result.Solved);
        Assert.Equal(0, original.MoveIndex);
    }
}
