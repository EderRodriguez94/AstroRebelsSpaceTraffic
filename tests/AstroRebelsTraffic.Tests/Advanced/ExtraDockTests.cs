using AstroRebelsTraffic.Application.Boosters;

namespace AstroRebelsTraffic.Tests.Advanced;

public sealed class ExtraDockTests
{
    [Fact]
    public void Booster_consumes_once_only_when_activation_succeeds()
    {
        var service = new ExtraDockService();
        var result = service.Use(1, 3, true);
        Assert.True(result.Accepted);
        Assert.Equal(0, result.InventoryRemaining);
        Assert.Equal(4, result.ActiveDockCount);
        Assert.False(service.Use(1, 4, true).Accepted);
    }
}
