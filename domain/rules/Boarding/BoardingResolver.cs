using AstroRebelsTraffic.Domain.Rules.Docks;
using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Domain.Rules.Boarding;

public sealed record BoardingFact(int DockIndex, ShipId ShipId, int PassengerCount);
public sealed record BoardingResult(int RequestedCount, int BoardedCount, IReadOnlyList<DockState> Docks, IReadOnlyList<BoardingFact> Facts)
{
    public int RemainingCount => RequestedCount - BoardedCount;
}

public static class BoardingResolver
{
    public static BoardingResult Board(IReadOnlyList<DockState> docks, string colorId, int passengerCount)
    {
        if (passengerCount < 0) throw new ArgumentOutOfRangeException(nameof(passengerCount));
        var updated = docks.ToArray();
        var facts = new List<BoardingFact>();
        var remaining = passengerCount;

        while (remaining > 0)
        {
            var compatible = DockBoardingQuery.FindCompatible(updated, colorId, 1);
            if (compatible.Count == 0) break;
            var target = compatible[0];
            var ship = target.Occupant!;
            var amount = Math.Min(remaining, ship.Capacity - ship.PassengerCount);
            if (amount <= 0) break;
            var boardedShip = new ShipState(ship.ShipId, ship.ZoneId, ship.ColorId, ship.Size, ship.AnchorCell, ship.ExitDirection, ship.SpecialType, ship.PassengerCount + amount, ship.IsRevealed);
            updated[target.VisualIndex] = target.WithOccupant(boardedShip);
            facts.Add(new BoardingFact(target.VisualIndex, ship.ShipId, amount));
            remaining -= amount;
        }

        return new BoardingResult(passengerCount, passengerCount - remaining, updated, facts);
    }
}
