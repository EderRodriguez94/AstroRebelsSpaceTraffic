# Task: ART-TASK-091

## References
- ART-SPEC-SAVE-002.
- ART-ARCH-SAVE-001 and ART-ARCH-SAVE-003.

## Files
- application/Ports/ISaveStore.cs
- infrastructure/Save/LocalSaveStore.cs
- tests/AstroRebelsTraffic.Tests/Save/LocalSaveStoreTests.cs

## Evidence
LocalSaveStore writes a temporary file, rotates one backup, replaces the primary and recovers malformed primary data from the backup without throwing.
