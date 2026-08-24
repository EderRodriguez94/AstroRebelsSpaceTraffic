using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Domain.Rules.Docks;

public sealed record RewardDockActivationResult(bool Activated, int? DockIndex, IReadOnlyList<DockState> Docks, string? RejectionReason);

public static class RewardDockRules
{
    public static RewardDockActivationResult ActivateOne(IReadOnlyList<DockState> docks)
    {
        var candidate = docks.Where(dock => !dock.IsActive && !dock.IsVip).OrderBy(dock => dock.VisualIndex).FirstOrDefault();
        if (candidate is null) return new(false, null, docks.ToArray(), "NO_REWARDED_DOCKS_REMAINING");
        var updated = docks.Select(dock => dock.VisualIndex == candidate.VisualIndex ? dock.Activate() : dock).ToArray();
        return new(true, candidate.VisualIndex, updated, null);
    }
}
