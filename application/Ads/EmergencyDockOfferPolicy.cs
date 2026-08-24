namespace AstroRebelsTraffic.Application.Ads;

public sealed record EmergencyDockOfferInput(bool NearDeadlock, bool AfterLoss, bool ResolutionLocked, bool TutorialLocked, int RewardedDockCount);
public sealed record EmergencyDockOffer(bool Suggested);

public static class EmergencyDockOfferPolicy
{
    public static EmergencyDockOffer Evaluate(EmergencyDockOfferInput input) =>
        new(!input.ResolutionLocked && !input.TutorialLocked && input.RewardedDockCount < 4 && (input.NearDeadlock || input.AfterLoss));
}
