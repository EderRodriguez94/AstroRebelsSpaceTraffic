using AstroRebelsTraffic.Domain.Rules.Docks;
using AstroRebelsTraffic.Domain.Rules.Grid;
using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Domain.Rules.Release;

public enum ReleaseValidationReason
{
    None,
    WrongPhase,
    UnknownShip,
    BlockedPath,
    DocksFull
}

public sealed record ReleaseValidationResult(bool IsAccepted, ReleaseValidationReason Reason, ShipId? BlockerShipId)
{
    public static ReleaseValidationResult Accepted() => new(true, ReleaseValidationReason.None, null);
}

public static class ReleaseValidator
{
    public static ReleaseValidationResult Validate(GameState state, ShipId shipId)
    {
        if (state.Phase != GamePhase.Playing) return new(false, ReleaseValidationReason.WrongPhase, null);
        if (!state.ShipsById.ContainsKey(shipId)) return new(false, ReleaseValidationReason.UnknownShip, null);

        var path = PathValidator.GetExitPath(state, shipId);
        if (!path.IsClear) return new(false, ReleaseValidationReason.BlockedPath, path.BlockerShipId);
        if (DockSystem.FindLeftmostEmptyStandard(state.Docks) is null) return new(false, ReleaseValidationReason.DocksFull, null);
        return ReleaseValidationResult.Accepted();
    }
}
