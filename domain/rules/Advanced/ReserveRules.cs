using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Domain.Rules.Advanced;

public static class ReserveRules
{
    public static (ReserveState Reserve, ShipState? Entered) TryEnter(ReserveState reserve, bool entryClear)
    {
        if (!reserve.Enabled || !entryClear || reserve.OrderedShips.Count == 0) return (reserve, null);
        var ship = reserve.OrderedShips[0];
        return (reserve with { OrderedShips = reserve.OrderedShips.Skip(1).ToArray() }, ship);
    }
}
