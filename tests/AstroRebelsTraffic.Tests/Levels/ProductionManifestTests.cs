using AstroRebelsTraffic.Levels.ProductionManifest;

namespace AstroRebelsTraffic.Tests.Levels;

public sealed class ProductionManifestTests
{
    [Fact]
    public void Manifest_requires_review_validation_and_solver_success()
    {
        var valid = ProductionManifestGate.Validate(new[] { new ProductionLevelEntry("l1", "candidate/l1.json", "production/l1.json", true) }, _ => true, _ => true);
        Assert.True(valid.IsValid);
        var invalid = ProductionManifestGate.Validate(new[] { new ProductionLevelEntry("l1", "candidate/l1.json", "production/l1.json", false) }, _ => false, _ => false);
        Assert.False(invalid.IsValid);
        Assert.Contains("l1:human_reviewed", invalid.Errors);
        Assert.Equal(invalid.Serialize(), invalid.Serialize());
    }
}
