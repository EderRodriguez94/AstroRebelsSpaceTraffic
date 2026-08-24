# Task: ART-TASK-047

### ART-SPEC-ADV-005 — Initial boosters `[PLANNED/ADVANCED]`

The planned initial booster set is:

- **Extra Dock:** activates one temporary eligible dock under the same unlock limit.
- **Undo:** restores the complete state before the previous accepted player move.
- **Scanner:** reveals Mystery Ships without changing their predefined colors.

Shuffle and Emergency Launch are deferred and MUST NOT be implemented without new rules.

### ART-SPEC-ADV-006 — Undo state `[PLANNED/ADVANCED]`

Undo MUST restore the full pre-move logical state, including grids, ship positions and revealed state, docks, ship passenger counts, main queue, prequeue and its logical order, active temporary docks, reserve state, booster consumption state relevant to the move, move counters, and deterministic random state if one is ever authorized.

---

### ART-ARCH-UNDO-001 — Snapshot boundary `[PLANNED/ADVANCED]`

Before an accepted player move mutates state, `UndoService` MUST deep-copy or structurally snapshot the complete settled `GameState`. Rejected commands MUST NOT create snapshots.

### ART-ARCH-UNDO-002 — Restore semantics `[PLANNED/ADVANCED]`

Undo restores the snapshot as the new authoritative state, validates invariants, clears any current presentation sequence, rebuilds all views, and emits `UndoApplied`. It MUST restore all fields listed by `ART-SPEC-ADV-006`.

### ART-ARCH-UNDO-003 — History policy `[PLANNED/ADVANCED]`

Core product direction requires at least one-step Undo when the booster is enabled. Multi-step depth, storage limit, and whether an undo consumption itself is reversible are TBD. Do not invent them.

## Source files
- C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic\docs\ASTRO_REBELS_TRAFFIC_MASTER_SPEC_EN.md
- C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic\docs\ASTRO_REBELS_TRAFFIC_ARCHITECTURE_EN.md
