using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Domain.Rules.Docks;

public static class DockBoardingQuery
{
    public static IReadOnlyList<DockState> FindCompatible(IReadOnlyList<DockState> docks, string colorId, int passengerCount) => docks
        .Where(dock => dock.IsActive && dock.Occupant is not null)
        .Where(dock => dock.Occupant!.ColorId == colorId && dock.Occupant.PassengerCount + passengerCount <= dock.Occupant.Capacity)
        .OrderByDescending(dock => dock.VisualIndex)
        .ToArray();
}
