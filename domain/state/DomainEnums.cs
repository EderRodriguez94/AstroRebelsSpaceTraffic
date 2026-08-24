namespace AstroRebelsTraffic.Domain.State;

public enum Direction { Up, Down, Left, Right }
public enum ShipSize { Small, Medium, Large }
public enum GamePhase { Playing, Won, Lost }
public enum DockKind { Standard, Booster }
public enum SpecialType { Normal, Mystery }

public static class DomainEnumSerialization
{
    public static string Serialize<T>(T value) where T : struct, Enum => value.ToString().ToUpperInvariant();

    public static T Parse<T>(string value) where T : struct, Enum
    {
        if (!Enum.TryParse<T>(value, ignoreCase: true, out var result) || !Enum.IsDefined(result))
            throw new FormatException($"Unknown {typeof(T).Name} value '{value}'.");
        return result;
    }
}
