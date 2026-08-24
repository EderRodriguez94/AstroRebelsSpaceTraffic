using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Domain.Rules.Advanced;

public static class VipDockRules
{
    public static VipDockState Route(VipDockState state, ShipState ship, bool authorized) =>
        authorized && state.Active && state.Occupant is null ? state with { Occupant = ship } : state;
}
