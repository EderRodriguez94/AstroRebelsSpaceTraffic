using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Domain.Rules.Advanced;

public static class MultiZoneRules
{
    public static bool ContainsShip(GameState state, ShipId shipId) => state.Zones.Zones.Any(zone => zone.ShipIds.Contains(shipId));
    public static bool IsWithinZone(GameState state, ZoneId zoneId, GridCell cell) => state.Zones.Zones.Any(zone => zone.Id == zoneId && cell.X >= 0 && cell.Y >= 0 && cell.X < zone.Width && cell.Y < zone.Height);
}
