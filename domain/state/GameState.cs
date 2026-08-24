namespace AstroRebelsTraffic.Domain.State;

public sealed class GameState
{
    public int SchemaVersion { get; }
    public string LevelId { get; }
    public string AttemptId { get; }
    public GamePhase Phase { get; }
    public int MoveIndex { get; }
    public GridState Zones { get; }
    public IReadOnlyDictionary<ShipId, ShipState> ShipsById { get; }
    public PassengerQueueState PassengerQueue { get; }
    public PreQueueState PreQueue { get; }
    public IReadOnlyList<DockState> Docks { get; }
    public ShipState? VipDock { get; }
    public IReadOnlyList<ShipState> Reserve { get; }
    public IReadOnlyDictionary<string, bool> MechanicFlags { get; }
    public IReadOnlyDictionary<string, bool> AttemptModifiers { get; }
    public string TutorialState { get; }

    private GameState(int schemaVersion, string levelId, string attemptId, GamePhase phase, int moveIndex, GridState zones,
        IReadOnlyDictionary<ShipId, ShipState> shipsById, PassengerQueueState passengerQueue, PreQueueState preQueue,
        IReadOnlyList<DockState> docks, ShipState? vipDock, IReadOnlyList<ShipState> reserve,
        IReadOnlyDictionary<string, bool> mechanicFlags, IReadOnlyDictionary<string, bool> attemptModifiers, string tutorialState)
    {
        if (schemaVersion <= 0) throw new ArgumentOutOfRangeException(nameof(schemaVersion));
        if (string.IsNullOrWhiteSpace(levelId)) throw new ArgumentException("Level ID cannot be empty.", nameof(levelId));
        SchemaVersion = schemaVersion; LevelId = levelId; AttemptId = attemptId; Phase = phase; MoveIndex = moveIndex; Zones = zones;
        ShipsById = new Dictionary<ShipId, ShipState>(shipsById); PassengerQueue = new PassengerQueueState(passengerQueue.Groups);
        PreQueue = new PreQueueState(preQueue.Groups, preQueue.Capacity); Docks = docks.ToArray(); VipDock = vipDock;
        Reserve = reserve.ToArray(); MechanicFlags = new Dictionary<string, bool>(mechanicFlags); AttemptModifiers = new Dictionary<string, bool>(attemptModifiers); TutorialState = tutorialState;
    }

    public static GameState CreateInitial(string levelId, GridState zones, IEnumerable<ShipState> ships, PassengerQueueState passengerQueue,
        PreQueueState preQueue, IEnumerable<DockState> docks, string attemptId = "initial")
    {
        var shipMap = ships.ToDictionary(ship => ship.ShipId);
        return new GameState(1, levelId, attemptId, GamePhase.Playing, 0, zones, shipMap, passengerQueue, preQueue, docks.ToArray(), null, Array.Empty<ShipState>(), new Dictionary<string, bool>(), new Dictionary<string, bool>(), "none");
    }
}
