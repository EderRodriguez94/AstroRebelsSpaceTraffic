using AstroRebelsTraffic.Presentation.Accessibility;

namespace AstroRebelsTraffic.Tests.Presentation;

public sealed class ColorCatalogTests
{
    [Fact]
    public void Core_colors_have_unique_symbols_and_labels()
    {
        var colors = ColorCatalog.Enabled();
        Assert.Equal(new[] { "blue", "green", "red", "yellow" }, colors.Select(x => x.Id).OrderBy(x => x));
        Assert.Equal(colors.Count, colors.Select(x => x.Symbol).Distinct(StringComparer.Ordinal).Count());
        Assert.Equal(colors.Count, colors.Select(x => x.Label).Distinct(StringComparer.Ordinal).Count());
        Assert.All(colors, color => Assert.False(string.IsNullOrWhiteSpace(color.Label)));
    }

    [Fact]
    public void Missing_catalog_entry_fails_instead_of_falling_back()
    {
        var error = Assert.Throws<KeyNotFoundException>(() => ColorCatalog.Get("magenta"));

        Assert.Contains("magenta", error.Message, StringComparison.Ordinal);
    }
}
