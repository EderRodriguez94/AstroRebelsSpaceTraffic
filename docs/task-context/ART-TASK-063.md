# Task: ART-TASK-063

## Normative references

- ART-SPEC-QA-002: runtime and solver transitions must agree for legal and illegal commands.
- ART-ARCH-TEST-003: parity tests compare acceptance, rejection, canonical state and ordered events.

## Exact implementation files

- domain/Commands/ReleaseShipTransaction.cs
- solver/Search/LegalActionEnumerator.cs
- tests/AstroRebelsTraffic.Tests/Solver/TransitionParityTests.cs

## Validation scope

The parity suite uses a deterministic in-memory fixture, exercises one legal and one illegal release, and compares acceptance, rejection reason, canonical zone serialization, phase, move index, object identity for rejected state, and ordered events.

## Traceability

Source and test changes are tracked by Git commits and diffs. File hashes are intentionally not used for integrity validation in this repository.
