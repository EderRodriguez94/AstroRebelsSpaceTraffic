using AstroRebelsTraffic.Domain.Rules.Advanced;
using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Application.Boosters;

public sealed record ScannerResult(bool Accepted, IReadOnlyList<MysteryReveal> Reveals);

public sealed class ScannerService
{
    public ScannerResult Use(GameState state, bool mechanicEnabled, int inventory)
    {
        if (!mechanicEnabled || inventory <= 0) return new(false, Array.Empty<MysteryReveal>());
        return new(true, MysteryRules.RevealClearShips(state, true));
    }
}
