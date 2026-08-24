using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Domain.Events;

public abstract record DomainEvent(string EventId)
{
    public abstract string EventType { get; }
    public virtual string Serialize() => $"{EventType}:{EventId}";
}

public sealed record ShipReleaseRejected(string EventId, ShipId ShipId, string Reason) : DomainEvent(EventId)
{
    public override string EventType => "ShipReleaseRejected";
    public override string Serialize() => $"{base.Serialize()}:{ShipId}:{Reason}";
}

public sealed record ShipExitedGrid(string EventId, ShipId ShipId, ZoneId ZoneId) : DomainEvent(EventId)
{
    public override string EventType => "ShipExitedGrid";
    public override string Serialize() => $"{base.Serialize()}:{ShipId}:{ZoneId}";
}

public sealed record ShipAssignedToDock(string EventId, ShipId ShipId, int DockIndex) : DomainEvent(EventId)
{
    public override string EventType => "ShipAssignedToDock";
    public override string Serialize() => $"{base.Serialize()}:{ShipId}:{DockIndex}";
}

public sealed record PassengerGroupAdmitted(string EventId, string ColorId, int Count) : DomainEvent(EventId)
{
    public override string EventType => "PassengerGroupAdmitted";
    public override string Serialize() => $"{base.Serialize()}:{ColorId}:{Count}";
}

public sealed record PassengersEnteredPreQueue(string EventId, string ColorId, int Count) : DomainEvent(EventId)
{
    public override string EventType => "PassengersEnteredPreQueue";
    public override string Serialize() => $"{base.Serialize()}:{ColorId}:{Count}";
}

public sealed record PassengersBoarded(string EventId, ShipId ShipId, int Count) : DomainEvent(EventId)
{
    public override string EventType => "PassengersBoarded";
    public override string Serialize() => $"{base.Serialize()}:{ShipId}:{Count}";
}

public sealed record ShipDepartedDock(string EventId, ShipId ShipId, int DockIndex) : DomainEvent(EventId)
{
    public override string EventType => "ShipDepartedDock";
    public override string Serialize() => $"{base.Serialize()}:{ShipId}:{DockIndex}";
}

public sealed record RewardDockActivated(string EventId, int DockIndex) : DomainEvent(EventId)
{
    public override string EventType => "RewardDockActivated";
    public override string Serialize() => $"{base.Serialize()}:{DockIndex}";
}

public sealed record MysteryShipRevealed(string EventId, ShipId ShipId, string ColorId) : DomainEvent(EventId)
{
    public override string EventType => "MysteryShipRevealed";
    public override string Serialize() => $"{base.Serialize()}:{ShipId}:{ColorId}";
}

public sealed record UndoApplied(string EventId, int RestoredMoveIndex) : DomainEvent(EventId)
{
    public override string EventType => "UndoApplied";
    public override string Serialize() => $"{base.Serialize()}:{RestoredMoveIndex}";
}

public sealed record LevelWon(string EventId, string LevelId) : DomainEvent(EventId)
{
    public override string EventType => "LevelWon";
    public override string Serialize() => $"{base.Serialize()}:{LevelId}";
}

public sealed record RealDeadlockDetected(string EventId, string LevelId, string Evidence) : DomainEvent(EventId)
{
    public override string EventType => "RealDeadlockDetected";
    public override string Serialize() => $"{base.Serialize()}:{LevelId}:{Evidence}";
}
