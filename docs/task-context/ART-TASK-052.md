# Task: ART-TASK-052

### ART-SPEC-QUEUE-003 — Color conservation `[CORE-REQUIRED]`

For every color in a production level, the total number of passengers MUST equal the total capacity of all ships of that color across every enabled ship source, including reserves when enabled. Level validation MUST reject a mismatch.

### ART-SPEC-LEVEL-002 — Production solvability `[PRODUCT-REQUIRED]`

Every production level MUST have at least one valid solution without ads, rewarded docks, boosters, purchases, or other paid/rewarded assistance. A level that fails solver validation MUST be rejected.

### ART-ARCH-LEVEL-003 — `LevelValidator`

Validation MUST include:

- schema/version and required fields;
- unique IDs and known enums;
- positive valid dimensions;
- ship footprint alignment, bounds, overlap, and capacity mapping;
- valid direction and exit geometry;
- exactly four base and four rewarded standard dock definitions unless a future schema explicitly changes presentation only;
- positive prequeue capacity, default 16;
- passenger group sizes 4/8/16;
- per-color passenger/capacity conservation including reserves;
- mechanic-specific fields and dependencies;
- initial invariants;
- solver solvability for production status;
- no assistance required by the recorded solution.

## Source files
- C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic\docs\ASTRO_REBELS_TRAFFIC_MASTER_SPEC_EN.md
- C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic\docs\ASTRO_REBELS_TRAFFIC_ARCHITECTURE_EN.md
