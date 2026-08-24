# Task: ART-TASK-065

## References

- ART-SPEC-LEVEL-004 and ART-SPEC-LEVEL-005: difficulty evidence is explainable and must not alter gameplay.
- ART-ARCH-SOLVER-007: metrics consume canonical state and solver evidence.

## Files

- solver/Difficulty/DifficultyEvaluator.cs
- tests/AstroRebelsTraffic.Tests/Solver/DifficultyTests.cs

## Evidence

The evaluator reports solution length, legal branching, ship count, board density, component weights and final score without mutating the input state.

Git commits and diffs are the repository traceability mechanism; file hashes are not used.
