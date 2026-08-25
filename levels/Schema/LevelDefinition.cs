namespace AstroRebelsTraffic.Levels.Schema;

public sealed record LevelDefinition(int SchemaVersion, string LevelId, IReadOnlyList<LevelZone> Zones, int PreQueueCapacity = 16, IReadOnlyList<LevelPassengerGroup>? PassengerQueue = null);
public sealed record LevelZone(string Id, int Width, int Height, IReadOnlyList<LevelShip> Ships);
public sealed record LevelShip(string Id, string Color, string Size, string Direction, int Passengers = 0);
public sealed record LevelPassengerGroup(string Color, int Size);
