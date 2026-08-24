# Task: ART-TASK-080

## References
- ART-SPEC-TUT-001.
- ART-ARCH-CMD-003.

## Files
- application/Tutorial/TutorialState.cs
- tests/AstroRebelsTraffic.Tests/Tutorial/TutorialTests.cs

## Evidence
Tutorial state is deterministic, gates only the allowed ship IDs, advances after an allowed application fact, and disabled mode permits every action without changing domain validation.
