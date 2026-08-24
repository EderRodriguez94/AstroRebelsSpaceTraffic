using AstroRebelsTraffic.Presentation.Accessibility;

namespace AstroRebelsTraffic.Tests.Presentation;

public sealed class ColorCatalogTests
{
    [Fact]
    public void Core_colors_have_unique_symbols_and_labels()
    {
        var colors = ColorCatalog.Enabled();
        Assert.Contains(colors, x => x.Id == "red");
        Assert.Equal(colors.Count, colors.Select(x => x.Symbol).Distinct(StringComparer.Ordinal).Count());
        Assert.All(colors, color => Assert.False(string.IsNullOrWhiteSpace(color.Label)));
    }
}
