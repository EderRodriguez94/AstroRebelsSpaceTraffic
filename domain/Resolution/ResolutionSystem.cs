using AstroRebelsTraffic.Domain.Events;
using AstroRebelsTraffic.Domain.Rules.Docks;
using AstroRebelsTraffic.Domain.Rules.Passengers;
using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Domain.Resolution;

public sealed record ResolutionResult(GameState State, IReadOnlyList<DomainEvent> Events)
{
    public bool Changed => Events.Count > 0;
}

public static class ResolutionSystem
{
    public static ResolutionResult Resolve(GameState initialState)
    {
        var state = initialState;
        var events = new List<DomainEvent>();
        var changed = true;
        var pass = 0;

        while (changed)
        {
            if (++pass > 1000) throw new InvalidOperationException("Resolution did not terminate within the bounded guard.");
            changed = false;

            var prequeue = PreQueueRules.Scan(state.PreQueue, state.Docks);
            if (prequeue.Changed)
            {
                state = Rebuild(state, state.Zones, state.PassengerQueue, prequeue.Remaining, prequeue.Docks);
                events.AddRange(prequeue.Facts.Select(fact => new PassengersBoarded($"board-{events.Count}", fact.ShipId, fact.PassengerCount)));
                changed = true;
            }

            var departures = ShipDepartureRules.DepartFullShips(state.Docks);
            if (departures.Changed)
            {
                var departed = departures.Departures.Select(fact => fact.ShipId).ToHashSet();
                var zones = new GridState(state.Zones.Zones.Select(zone => new GridState.Zone(zone.Id, zone.Width, zone.Height, zone.ShipIds.Where(id => !departed.Contains(id)))));
                state = Rebuild(state, zones, state.PassengerQueue, state.PreQueue, departures.Docks);
                events.AddRange(departures.Departures.Select(fact => new ShipDepartedDock($"depart-{events.Count}", fact.ShipId, fact.DockIndex)));
                changed = true;
            }

            var admission = PassengerQueueRules.AdmitFront(state.PassengerQueue, state.PreQueue, state.Docks);
            if (admission.Accepted)
            {
                state = Rebuild(state, state.Zones, admission.Queue, admission.PreQueue, admission.Docks);
                events.AddRange(admission.Facts.Select(fact => new PassengersBoarded($"board-{events.Count}", fact.ShipId, fact.PassengerCount)));
                changed = true;
            }
        }

        return new ResolutionResult(state, events);
    }

    private static GameState Rebuild(GameState state, GridState zones, PassengerQueueState queue, PreQueueState preQueue, IReadOnlyList<DockState> docks) =>
        GameState.Create(state.LevelId, zones, state.ShipsById.Values, queue, preQueue, docks, state.AttemptId, state.Phase, state.MoveIndex, state.VipDock, state.Reserve, state.MechanicFlags, state.AttemptModifiers, state.TutorialState);
}
