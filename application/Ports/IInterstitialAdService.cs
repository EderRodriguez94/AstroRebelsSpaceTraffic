using AstroRebelsTraffic.Application.Ads;

namespace AstroRebelsTraffic.Application.Ports;

public interface IInterstitialAdService { AdResult Show(string placementId); }
public sealed class NoOpInterstitialAdService : IInterstitialAdService { public AdResult Show(string placementId) => new(AdResultKind.Unavailable, placementId); }
