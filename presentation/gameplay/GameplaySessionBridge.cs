using Godot;
using AstroRebelsTraffic.Application.GameSession;
using AstroRebelsTraffic.Domain.Commands;
using AstroRebelsTraffic.Domain.State;
using AstroRebelsTraffic.Domain.Rules.Grid;

namespace AstroRebelsTraffic.Presentation.Gameplay;

public partial class GameplaySessionBridge : Node
{
    private GameSession? session;

    public override void _Ready()
    {
        ResetSession();
    }

    public void ResetSession()
    {
        var zone = new ZoneId("tutorial-zone");
        var blueId = new ShipId("tutorial-blue");
        var redId = new ShipId("tutorial-red");
        var blue = new ShipState(blueId, zone, "blue", ShipSize.Small, new GridCell(0, 0), Direction.Right,
            SpecialType.Normal, 1, true);
        var red = new ShipState(redId, zone, "red", ShipSize.Small, new GridCell(0, 1), Direction.Right,
            SpecialType.Normal, 1, true);
        var grid = new GridState(new[] { new GridState.Zone(zone, 3, 2, new[] { blueId, redId }) });
        session = new GameSession(GameState.CreateInitial("level-1", grid, new[] { blue, red },
            new PassengerQueueState(new[] { new PassengerGroup("red", 4) }), new PreQueueState(Array.Empty<PassengerGroup>()),
            DockState.CreateInitial()));
    }

    public string ReleaseFirstShip()
        => ReleaseShip("tutorial-blue");

    public string ReleaseShip(string shipId)
    {
        if (session is null) return "Session is not ready";

        var result = session.Submit(new ReleaseShipCommand(new ShipId(shipId)));
        if (result.Accepted)
            return result.NextState.Phase == GamePhase.Won ? "Level complete" : "Ship released";

        return $"Release rejected: {result.RejectionReason}";
    }

    public string GetBoardSummary()
    {
        if (session is null) return "Loading board...";
        var state = session.State;
        var shipsOnGrid = state.Zones.Zones.Sum(zone => zone.ShipIds.Count);
        return $"GRID  •  {shipsOnGrid} ship{(shipsOnGrid == 1 ? "" : "s")} remaining  •  Turn {state.MoveIndex}";
    }

    public string GetDockSummary()
    {
        if (session is null) return "DOCKS  •  Loading...";
        var occupied = session.State.Docks.Count(dock => dock.Occupant is not null);
        var active = session.State.Docks.Count(dock => dock.IsActive);
        return $"DOCKS  •  {occupied} / {active} occupied";
    }

    public string GetQueueSummary()
    {
        if (session is null) return "PASSENGERS  •  Loading...";
        var waiting = session.State.PassengerQueue.Groups.Sum(group => group.Size);
        return $"PASSENGERS  •  {waiting} waiting";
    }

    public string GetPathSummary()
    {
        if (session is null) return "EXIT PATH  •  Loading...";
        var paths = session.State.ShipsById.Values.Select(ship => PathValidator.GetExitPath(session.State, ship.ShipId));
        var blocked = paths.Count(path => !path.IsClear);
        return blocked == 0 ? "EXIT PATHS  •  ALL CLEAR  →" : $"EXIT PATHS  •  {blocked} BLOCKED";
    }

    public string GetPhaseSummary()
    {
        if (session is null) return "SESSION  •  Loading...";
        return $"SESSION  •  {session.State.Phase.ToString().ToUpperInvariant()}";
    }
}
