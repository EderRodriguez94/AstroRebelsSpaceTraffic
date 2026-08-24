using AstroRebelsTraffic.Application.Ads;

namespace AstroRebelsTraffic.Application.Ports;

public interface IRewardedAdService { AdResult Show(string placementId); }
public sealed class NoOpRewardedAdService : IRewardedAdService { public AdResult Show(string placementId) => new(AdResultKind.Unavailable, placementId); }
