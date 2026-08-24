namespace AstroRebelsTraffic.Domain.State;

public sealed record VipDockState(bool Active, ShipState? Occupant = null);
