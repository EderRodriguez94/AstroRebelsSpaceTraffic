using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Domain.Rules.Ships;

public static class ShipRules
{
    public static int LengthFor(ShipSize size) => size switch
    {
        ShipSize.Small => 1,
        ShipSize.Medium => 2,
        ShipSize.Large => 3,
        _ => throw new ArgumentOutOfRangeException(nameof(size))
    };

    public static int CapacityFor(ShipSize size) => size switch
    {
        ShipSize.Small => 4,
        ShipSize.Medium => 8,
        ShipSize.Large => 16,
        _ => throw new ArgumentOutOfRangeException(nameof(size))
    };
}
