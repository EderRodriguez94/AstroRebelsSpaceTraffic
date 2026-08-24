namespace AstroRebelsTraffic.Presentation.Accessibility;

public sealed record ColorDefinition(string Id, string Hex, string Symbol, string Label, bool Enabled = true);

public static class ColorCatalog
{
    private static readonly IReadOnlyDictionary<string, ColorDefinition> Definitions = new Dictionary<string, ColorDefinition>(StringComparer.Ordinal)
    {
        ["red"] = new("red", "#E05252", "circle", "Red"),
        ["blue"] = new("blue", "#4C8DCC", "triangle", "Blue"),
        ["green"] = new("green", "#58A66A", "square", "Green"),
        ["yellow"] = new("yellow", "#D6B84C", "diamond", "Yellow")
    };

    public static ColorDefinition Get(string id) => Definitions.TryGetValue(id, out var definition)
        ? definition
        : throw new KeyNotFoundException($"No color catalog entry exists for '{id}'.");

    public static IReadOnlyCollection<ColorDefinition> Enabled() => Definitions.Values.Where(x => x.Enabled).ToArray();
}
