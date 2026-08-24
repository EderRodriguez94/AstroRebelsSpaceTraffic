using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Domain.Rules.Docks;

public sealed record DockAssignmentResult(bool Assigned, int? DockIndex, IReadOnlyList<DockState> Docks, string? RejectionReason);

public static class DockSystem
{
    public static int? FindLeftmostEmptyStandard(IReadOnlyList<DockState> docks) => docks
        .Where(dock => dock.IsActive && !dock.IsVip && dock.Occupant is null)
        .OrderBy(dock => dock.VisualIndex)
        .Select(dock => (int?)dock.VisualIndex)
        .FirstOrDefault();

    public static DockAssignmentResult Assign(IReadOnlyList<DockState> docks, ShipState ship)
    {
        if (docks.Any(dock => dock.Occupant?.ShipId == ship.ShipId))
            return new(false, null, docks.ToArray(), "SHIP_ALREADY_DOCKED");

        var index = FindLeftmostEmptyStandard(docks);
        if (index is null) return new(false, null, docks.ToArray(), "NO_EMPTY_STANDARD_DOCK");

        var updated = docks.Select(dock => dock.VisualIndex == index.Value ? dock.WithOccupant(ship) : dock).ToArray();
        return new(true, index, updated, null);
    }
}
