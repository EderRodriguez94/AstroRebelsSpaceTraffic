# Task: ART-TASK-113

## References
- ART-SPEC-ADV-003.
- ART-ARCH-ADV-004.

## Files
- domain/rules/Advanced/MultiZoneRules.cs
- tests/AstroRebelsTraffic.Tests/Advanced/MultiZoneTests.cs

## Evidence
Existing zone collections are reused, each zone validates its own logical boundary, and the state retains one shared queue and dock collection.
