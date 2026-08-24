# Task: ART-TASK-116

## References
- ART-SPEC-ADV-005.
- ART-ARCH-ADV-006.

## Files
- domain/commands/UseExtraDockCommand.cs
- application/Boosters/ExtraDockService.cs
- tests/AstroRebelsTraffic.Tests/Advanced/ExtraDockTests.cs

## Evidence
Extra Dock activation is attempt-local, consumes one booster only after successful activation, and rejects disabled, empty or full-dock cases.
