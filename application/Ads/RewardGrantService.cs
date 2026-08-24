namespace AstroRebelsTraffic.Application.Ads;

public sealed class RewardGrantService
{
    private readonly HashSet<string> consumedTokens = new(StringComparer.Ordinal);

    public bool TryGrant(AdResult result, string expectedPlacementId, int activeDockCount, int maxActiveDocks = 4)
    {
        if (result.Kind != AdResultKind.CompletedVerified || result.PlacementId != expectedPlacementId || string.IsNullOrWhiteSpace(result.VerificationToken)) return false;
        if (activeDockCount >= maxActiveDocks || !consumedTokens.Add(result.VerificationToken)) return false;
        return true;
    }
}
