namespace AstroRebelsTraffic.Domain.State;

public sealed record ReserveState(IReadOnlyList<ShipState> OrderedShips, int VisiblePrefix = 0, bool Enabled = false)
{
    public IReadOnlyList<ShipState> VisibleShips => Enabled ? OrderedShips.Take(Math.Clamp(VisiblePrefix, 0, OrderedShips.Count)).ToArray() : Array.Empty<ShipState>();
}
