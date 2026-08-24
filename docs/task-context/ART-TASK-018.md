# Task: ART-TASK-018

### ART-SPEC-QA-001 — Determinism `[CORE-REQUIRED]`

Given the same level definition, state, and command, gameplay MUST produce the same next settled state and ordered domain events.

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

### ART-ARCH-SOLVER-003 — `StateHasher`

The hasher MUST canonicalize all rule-relevant state:

- zones in stable order and ship IDs/positions/directions/reveal state;
- dock activation, occupants, and ship passenger counts in dock index order;
- main queue order and counts;
- prequeue logical order and capacity;
- reserve order/entry state when enabled;
- mechanic flags and rule-relevant attempt modifiers;
- deterministic RNG state if authorized.

It MUST exclude presentation, animation time, analytics IDs, wall clock, and undo history unless a particular search explicitly models undo. Equality MUST confirm canonical data after hash matches to protect against collisions.

## Source files
- C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic\docs\ASTRO_REBELS_TRAFFIC_MASTER_SPEC_EN.md
- C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic\docs\ASTRO_REBELS_TRAFFIC_ARCHITECTURE_EN.md
