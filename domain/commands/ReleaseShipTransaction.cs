using AstroRebelsTraffic.Domain.Events;
using AstroRebelsTraffic.Domain.Resolution;
using AstroRebelsTraffic.Domain.Rules.EndConditions;
using AstroRebelsTraffic.Domain.Rules.Grid;
using AstroRebelsTraffic.Domain.Rules.Release;
using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Domain.Commands;

public static class ReleaseShipTransaction
{
    public static CommandResult Execute(GameState state, ReleaseShipCommand command, bool inputGateOpen = true)
    {
        if (state.Phase != GamePhase.Playing) return CommandResult.Rejected(state, CommandRejectionReason.InvalidState);
        if (!inputGateOpen) return CommandResult.Rejected(state, CommandRejectionReason.InvalidState);
        var validation = ReleaseValidator.Validate(state, command.ShipId);
        if (!validation.IsAccepted)
            return CommandResult.Rejected(state, MapReason(validation.Reason));

        var ship = state.ShipsById[command.ShipId];
        var assignment = Rules.Docks.DockSystem.Assign(state.Docks, ship);
        if (!assignment.Assigned || assignment.DockIndex is null)
            return CommandResult.Rejected(state, CommandRejectionReason.DockCapacityUnavailable);

        var zones = new GridState(state.Zones.Zones.Select(zone =>
            new GridState.Zone(zone.Id, zone.Width, zone.Height, zone.ShipIds.Where(id => id != command.ShipId))));
        var next = GameState.Create(state.LevelId, zones, state.ShipsById.Values, state.PassengerQueue, state.PreQueue,
            assignment.Docks, state.AttemptId, state.Phase, state.MoveIndex + 1, state.VipDock, state.Reserve,
            state.MechanicFlags, state.AttemptModifiers, state.TutorialState);
        var events = new List<DomainEvent>
        {
            new ShipExitedGrid($"release-exit-{state.MoveIndex}", ship.ShipId, ship.ZoneId),
            new ShipAssignedToDock($"release-dock-{state.MoveIndex}", ship.ShipId, assignment.DockIndex.Value)
        };

        var settled = ResolutionSystem.Resolve(next);
        events.AddRange(settled.Events);
        var winning = WinCondition.IsWon(settled.State, true);
        if (winning)
        {
            next = GameState.Create(settled.State.LevelId, settled.State.Zones, settled.State.ShipsById.Values, settled.State.PassengerQueue,
                settled.State.PreQueue, settled.State.Docks, settled.State.AttemptId, GamePhase.Won, settled.State.MoveIndex,
                settled.State.VipDock, settled.State.Reserve, settled.State.MechanicFlags, settled.State.AttemptModifiers, settled.State.TutorialState);
            events.Add(new LevelWon($"win-{state.MoveIndex}", next.LevelId));
        }
        else
        {
            next = settled.State;
        }
        return CommandResult.AcceptedResult(next, events);
    }

    private static CommandRejectionReason MapReason(ReleaseValidationReason reason) => reason switch
    {
        ReleaseValidationReason.UnknownShip => CommandRejectionReason.ShipNotFound,
        ReleaseValidationReason.DocksFull => CommandRejectionReason.DockCapacityUnavailable,
        _ => CommandRejectionReason.InvalidState
    };
}
