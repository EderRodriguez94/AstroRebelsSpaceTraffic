using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Domain.Rules.Advanced;

public sealed record MysteryReveal(ShipId ShipId, string ColorId);

public static class MysteryRules
{
    public static IReadOnlyList<MysteryReveal> RevealClearShips(GameState state, bool mechanicEnabled)
    {
        if (!mechanicEnabled) return Array.Empty<MysteryReveal>();
        return state.ShipsById.Values.Where(ship => ship.SpecialType == SpecialType.Mystery && !string.IsNullOrWhiteSpace(ship.ColorId))
            .OrderBy(ship => ship.ShipId.Value, StringComparer.Ordinal)
            .Select(ship => new MysteryReveal(ship.ShipId, ship.ColorId)).ToArray();
    }
}
