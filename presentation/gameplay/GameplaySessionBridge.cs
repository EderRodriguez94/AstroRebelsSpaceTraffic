using Godot;
using AstroRebelsTraffic.Application.GameSession;
using AstroRebelsTraffic.Domain.Commands;
using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Presentation.Gameplay;

public partial class GameplaySessionBridge : Node
{
    private GameSession? session;

    public override void _Ready()
    {
        var zone = new ZoneId("tutorial-zone");
        var shipId = new ShipId("tutorial-ship");
        var ship = new ShipState(shipId, zone, "blue", ShipSize.Small, new GridCell(0, 0), Direction.Right,
            SpecialType.Normal, 1, true);
        var grid = new GridState(new[] { new GridState.Zone(zone, 3, 1, new[] { shipId }) });
        session = new GameSession(GameState.CreateInitial("level-1", grid, new[] { ship },
            new PassengerQueueState(Array.Empty<PassengerGroup>()), new PreQueueState(Array.Empty<PassengerGroup>()),
            DockState.CreateInitial()));
    }

    public string ReleaseFirstShip()
    {
        if (session is null) return "Session is not ready";

        var result = session.Submit(new ReleaseShipCommand(new ShipId("tutorial-ship")));
        if (result.Accepted)
            return result.NextState.Phase == GamePhase.Won ? "Level complete" : "Ship released";

        return $"Release rejected: {result.RejectionReason}";
    }
}
