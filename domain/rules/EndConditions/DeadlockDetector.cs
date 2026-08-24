using AstroRebelsTraffic.Domain.Rules.Docks;
using AstroRebelsTraffic.Domain.Rules.Grid;
using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Domain.Rules.EndConditions;

public sealed record DeadlockResult(bool IsDeadlock, IReadOnlyList<DeadlockEvidence> Evidence);

public static class DeadlockDetector
{
    public static DeadlockResult Check(GameState state, bool isSettled, bool isWinning, bool hasMandatoryAutomaticTransition = false)
    {
        var evidence = new List<DeadlockEvidence>();
        var activeDocksFull = state.Docks.Where(dock => dock.IsActive && !dock.IsVip).All(dock => dock.Occupant is not null);
        evidence.Add(new("ACTIVE_DOCKS_OCCUPIED", activeDocksFull, "Every active standard dock is occupied."));

        var eligiblePreQueue = state.PreQueue.Groups.Any(group => DockBoardingQuery.FindCompatible(state.Docks, group.ColorId, 1).Count > 0);
        var eligibleMain = state.PassengerQueue.Front is { } front && DockBoardingQuery.FindCompatible(state.Docks, front.ColorId, 1).Count > 0;
        var noEligiblePassengers = !eligiblePreQueue && !eligibleMain;
        evidence.Add(new("NO_ELIGIBLE_PASSENGER", noEligiblePassengers, "No prequeue or front-group passenger can board."));

        var noAutomaticDeparture = !ShipDepartureRules.DepartFullShips(state.Docks).Changed;
        evidence.Add(new("NO_AUTOMATIC_DEPARTURE", noAutomaticDeparture, "No full dock ship can depart."));
        var noMandatoryTransition = !hasMandatoryAutomaticTransition;
        evidence.Add(new("NO_MANDATORY_TRANSITION", noMandatoryTransition, "No enabled mandatory transition is pending."));

        var isDeadlock = isSettled && !isWinning && activeDocksFull && noEligiblePassengers && noAutomaticDeparture && noMandatoryTransition;
        evidence.Add(new("SETTLED_NON_WINNING", isSettled && !isWinning, "Deadlock is evaluated only after settlement and before win."));
        return new DeadlockResult(isDeadlock, evidence);
    }
}
