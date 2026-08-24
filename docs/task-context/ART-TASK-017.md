# Task: ART-TASK-017

### ART-SPEC-QA-003 — Required rule coverage `[PRODUCT-REQUIRED]`

Automated tests MUST cover ship footprints and all four directions, release rejection reasons, leftmost dock assignment, right-to-left boarding, group splits, prequeue order/capacity, cascading departures, exact win, exact deadlock, input gating, undo restoration, level validation, and deterministic serialization/hashing.

### ART-ARCH-STATE-006 — Invariants

`GameStateInvariantChecker` MUST validate at least:

- one logical location per ship;
- no grid overlap or out-of-bounds footprint;
- occupancy index equals derived footprints;
- canonical size/capacity mapping;
- `0 ≤ passenger_count ≤ capacity`;
- at most one occupant per dock;
- no occupant in an inactive dock;
- prequeue count equals entries and does not exceed capacity;
- main source group sizes are 4/8/16;
- non-negative passenger counts;
- known color and direction IDs;
- state phase consistent with win/deadlock when checked at settlement;
- reserve and Mystery state consistent with enabled mechanic flags.

Invariant checks MUST run in tests, level validation, solver ingestion, and debug builds. Release builds MAY use a lower-cost subset at safe boundaries.

---

## Source files
- C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic\docs\ASTRO_REBELS_TRAFFIC_MASTER_SPEC_EN.md
- C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic\docs\ASTRO_REBELS_TRAFFIC_ARCHITECTURE_EN.md
