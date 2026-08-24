# Task: ART-TASK-061

### ART-SPEC-LEVEL-002 — Production solvability `[PRODUCT-REQUIRED]`

Every production level MUST have at least one valid solution without ads, rewarded docks, boosters, purchases, or other paid/rewarded assistance. A level that fails solver validation MUST be rejected.

### ART-ARCH-SOLVER-001 — Solver boundary

`Solver` MUST load a validated `LevelDefinition`, build the same `GameState`, enumerate legal domain commands, and execute them through the same command handler and `ResolutionSystem` as runtime. A solver-only “fast rule” that changes results is forbidden.

### ART-ARCH-SOLVER-002 — Legal action enumeration

For core levels, legal solver actions are accepted `ReleaseShipCommand`s for grid ships. Ads, rewarded docks, boosters, purchases, restarts, and presentation actions MUST be excluded when proving baseline production solvability.

## Source files
- C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic\docs\ASTRO_REBELS_TRAFFIC_MASTER_SPEC_EN.md
- C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic\docs\ASTRO_REBELS_TRAFFIC_ARCHITECTURE_EN.md
