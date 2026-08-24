namespace AstroRebelsTraffic.Application.Tutorial;

public sealed record TutorialState(bool Enabled, int Step, IReadOnlySet<string> AllowedShipIds)
{
    public static TutorialState Disabled() => new(false, 0, new HashSet<string>(StringComparer.Ordinal));

    public bool Allows(string shipId) => !Enabled || AllowedShipIds.Contains(shipId);

    public TutorialState Advance(string completedShipId, string nextAllowedShipId)
    {
        if (!Allows(completedShipId)) return this;
        return this with { Step = Step + 1, AllowedShipIds = new HashSet<string>(new[] { nextAllowedShipId }, StringComparer.Ordinal) };
    }
}
