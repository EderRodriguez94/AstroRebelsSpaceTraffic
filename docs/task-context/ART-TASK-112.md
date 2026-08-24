# Task: ART-TASK-112

## References
- ART-SPEC-ADV-002.
- ART-ARCH-ADV-003 and ART-ARCH-RES-006.

## Files
- domain/state/ReserveState.cs
- domain/rules/Advanced/ReserveRules.cs
- tests/AstroRebelsTraffic.Tests/Advanced/ReserveTests.cs

## Evidence
Reserve order is deterministic, the visible prefix is bounded, and blocked entry leaves the reserve unchanged. Disabled reserve has no entry effect.
