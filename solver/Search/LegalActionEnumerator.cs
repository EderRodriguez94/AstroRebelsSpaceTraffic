using AstroRebelsTraffic.Domain.Rules.Release;
using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Solver.Search;

public sealed record LegalAction(ShipId ShipId);

public static class LegalActionEnumerator
{
    public static IReadOnlyList<LegalAction> Enumerate(GameState state) => state.Phase == GamePhase.Playing
        ? state.ShipsById.Values.Where(ship => state.Zones.Zones.Any(zone => zone.ShipIds.Contains(ship.ShipId)))
            .Where(ship => ReleaseValidator.Validate(state, ship.ShipId).IsAccepted)
            .OrderBy(ship => ship.ShipId.Value, StringComparer.Ordinal)
            .Select(ship => new LegalAction(ship.ShipId)).ToArray()
        : Array.Empty<LegalAction>();
}
