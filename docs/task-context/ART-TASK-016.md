# Task: ART-TASK-016

### ART-SPEC-QA-001 — Determinism `[CORE-REQUIRED]`

Given the same level definition, state, and command, gameplay MUST produce the same next settled state and ordered domain events.

### ART-SPEC-QA-002 — Shared rules `[CORE-REQUIRED]`

Runtime, automated tests, solver, level validator, replay, and generator evaluation MUST use the same canonical state and rules. Duplicate alternate gameplay logic is forbidden.

### ART-ARCH-STATE-001 — `GameState`

`GameState` MUST be a complete, deep-copyable, deterministically serializable logical state. It contains at least:

```text
GameState
  schema_version
  level_id
  attempt_id          # excluded from solver equality when non-gameplay metadata
  phase               # PLAYING | WON | LOST
  move_index
  zones[]             # GridState in stable zone order
  ships_by_id{}       # ShipState, stable IDs
  passenger_queue     # PassengerQueueState
  prequeue            # PreQueueState
  docks               # DockState in fixed left-to-right order
  vip_dock             # optional planned state
  reserve              # optional planned state
  mechanic_flags
  attempt_modifiers   # temporary unlocks/boosters
  tutorial_state      # only logical gating needed by gameplay
  rng_state            # only if an approved deterministic feature needs it
```

Animation progress, Node references, textures, audio state, wall-clock timestamps, analytics IDs, and provider objects MUST NOT be stored in `GameState`.

### ART-ARCH-DEP-003 — Ownership

`GameSession` owns the one authoritative runtime `GameState`. Views hold identifiers and display data only. A view MUST request a command; it MUST NOT mutate ship, passenger, dock, or grid state.

---

## Source files
- C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic\docs\ASTRO_REBELS_TRAFFIC_MASTER_SPEC_EN.md
- C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic\docs\ASTRO_REBELS_TRAFFIC_ARCHITECTURE_EN.md
