using AstroRebelsTraffic.Domain.Events;
using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Domain.Commands;

public enum CommandRejectionReason
{
    None,
    InvalidState,
    ShipNotFound,
    ShipNotReleaseable,
    DockCapacityUnavailable,
    FeatureDisabled,
    InvalidRewardToken
}

public sealed record CommandResult(
    bool Accepted,
    CommandRejectionReason RejectionReason,
    GameState NextState,
    IReadOnlyList<DomainEvent> Events)
{
    public static CommandResult AcceptedResult(GameState state, IEnumerable<DomainEvent>? events = null) =>
        new(true, CommandRejectionReason.None, state, (events ?? Array.Empty<DomainEvent>()).ToArray());

    public static CommandResult Rejected(GameState state, CommandRejectionReason reason) =>
        new(false, reason, state, Array.Empty<DomainEvent>());
}

public sealed record ReleaseShipCommand(ShipId ShipId);
public sealed record RestartLevelCommand;
public sealed record UndoCommand;
public sealed record UnlockRewardDockCommand(string RewardToken);
public sealed record UseScannerCommand;
