# Task: ART-TASK-100

## References
- ART-SPEC-ADS-001, ART-SPEC-ADS-003, ART-SPEC-ADS-004.
- ART-ARCH-ADS-001 and ART-ARCH-ADS-004.

## Files
- application/Ports/IRewardedAdService.cs
- application/Ports/IInterstitialAdService.cs
- application/Ads/AdResults.cs
- tests/AstroRebelsTraffic.Tests/Ads/AdPortTests.cs

## Evidence
Ad ports are provider-neutral, expose explicit outcomes and placement IDs, and no-op adapters leave gameplay untouched without granting rewards.
