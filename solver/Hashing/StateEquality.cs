using AstroRebelsTraffic.Domain.Serialization;
using AstroRebelsTraffic.Domain.State;

namespace AstroRebelsTraffic.Solver.Hashing;

public static class StateEquality
{
    public static bool AreEqual(GameState? left, GameState? right)
    {
        if (ReferenceEquals(left, right)) return true;
        if (left is null || right is null) return false;
        return string.Equals(GameStateSerializer.Serialize(left), GameStateSerializer.Serialize(right), StringComparison.Ordinal);
    }
}
