using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Domain.Rules.Docks;

public sealed record ShipDepartureFact(int DockIndex, ShipId ShipId);
public sealed record ShipDepartureResult(IReadOnlyList<DockState> Docks, IReadOnlyList<ShipDepartureFact> Departures)
{
    public bool Changed => Departures.Count > 0;
}

public static class ShipDepartureRules
{
    public static ShipDepartureResult DepartFullShips(IReadOnlyList<DockState> docks)
    {
        var departures = docks
            .Where(dock => dock.Occupant is not null && dock.Occupant.PassengerCount == dock.Occupant.Capacity)
            .OrderBy(dock => dock.VisualIndex)
            .Select(dock => new ShipDepartureFact(dock.VisualIndex, dock.Occupant!.ShipId))
            .ToArray();
        var departureIndexes = departures.Select(departure => departure.DockIndex).ToHashSet();
        var updated = docks.Select(dock => departureIndexes.Contains(dock.VisualIndex) ? dock.WithOccupant(null) : dock).ToArray();
        return new ShipDepartureResult(updated, departures);
    }
}
