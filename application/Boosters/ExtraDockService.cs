namespace AstroRebelsTraffic.Application.Boosters;

public sealed record ExtraDockResult(bool Accepted, int InventoryRemaining, int ActiveDockCount);

public sealed class ExtraDockService
{
    public ExtraDockResult Use(int inventory, int activeDockCount, bool enabled)
    {
        if (!enabled || inventory <= 0 || activeDockCount >= 4) return new(false, inventory, activeDockCount);
        return new(true, inventory - 1, activeDockCount + 1);
    }
}
