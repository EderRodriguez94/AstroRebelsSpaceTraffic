namespace AstroRebelsTraffic.Application.Ads;

public enum AdResultKind { CompletedVerified, Unavailable, Cancelled, Failed, Stale }
public sealed record AdResult(AdResultKind Kind, string PlacementId, string? VerificationToken = null);
