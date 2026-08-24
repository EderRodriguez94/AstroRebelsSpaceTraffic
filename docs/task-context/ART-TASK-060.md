# Task: ART-TASK-060

### ART-SPEC-QA-001 — Determinism `[CORE-REQUIRED]`

Given the same level definition, state, and command, gameplay MUST produce the same next settled state and ordered domain events.

### ART-SPEC-QA-002 — Shared rules `[CORE-REQUIRED]`

Runtime, automated tests, solver, level validator, replay, and generator evaluation MUST use the same canonical state and rules. Duplicate alternate gameplay logic is forbidden.

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
