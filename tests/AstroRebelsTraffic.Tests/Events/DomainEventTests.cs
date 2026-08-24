using AstroRebelsTraffic.Domain.Events;
using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Tests.Events;

public class DomainEventTests
{
    [Fact]
    public void Required_event_categories_are_constructible_and_typed()
    {
        var events = new DomainEvent[]
        {
            new ShipReleaseRejected("e01", new ShipId("s"), "blocked"),
            new ShipExitedGrid("e02", new ShipId("s"), new ZoneId("z")),
            new ShipAssignedToDock("e03", new ShipId("s"), 0),
            new PassengerGroupAdmitted("e04", "red", 4),
            new PassengersEnteredPreQueue("e05", "red", 4),
            new PassengersBoarded("e06", new ShipId("s"), 4),
            new ShipDepartedDock("e07", new ShipId("s"), 0),
            new RewardDockActivated("e08", 4),
            new MysteryShipRevealed("e09", new ShipId("s"), "blue"),
            new UndoApplied("e10", 2),
            new LevelWon("e11", "level"),
            new RealDeadlockDetected("e12", "level", "no-clear-release")
        };

        Assert.Equal(12, events.Select(e => e.EventType).Distinct().Count());
        Assert.All(events, e => Assert.Contains(e.EventId, e.Serialize()));
    }

    [Fact]
    public void Event_order_serializes_reproducibly()
    {
        var events = new DomainEvent[]
        {
            new ShipExitedGrid("e01", new ShipId("s"), new ZoneId("z")),
            new ShipAssignedToDock("e02", new ShipId("s"), 0)
        };

        Assert.Equal(events.Select(e => e.Serialize()), events.Select(e => e.Serialize()));
    }
}
