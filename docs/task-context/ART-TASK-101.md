# Task: ART-TASK-101

## References
- ART-SPEC-ADS-001 and ART-SPEC-ADS-004.
- ART-ARCH-ADS-002 and ART-ARCH-ADS-003.

## Files
- application/Ads/RewardGrantService.cs
- tests/AstroRebelsTraffic.Tests/Ads/RewardGrantTests.cs

## Evidence
RewardGrantService accepts only verified expected-placement tokens, consumes each token once, enforces the four-dock limit and performs no provider or GameState mutation.
