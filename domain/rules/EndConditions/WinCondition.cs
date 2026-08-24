using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Domain.Rules.EndConditions;

public static class WinCondition
{
    public static bool IsWon(GameState state, bool isSettled)
    {
        if (!isSettled) throw new InvalidOperationException("Win can only be evaluated after settlement.");
        if (state.Zones.Zones.Any(zone => zone.ShipIds.Count > 0)) return false;
        if (state.Docks.Any(dock => dock.Occupant is not null)) return false;
        if (state.PassengerQueue.Groups.Count > 0 || state.PreQueue.Groups.Count > 0) return false;
        if (state.MechanicFlags.TryGetValue("reserve", out var reserveEnabled) && reserveEnabled && state.Reserve.Count > 0) return false;
        if (state.VipDock is not null) return false;
        return true;
    }
}
