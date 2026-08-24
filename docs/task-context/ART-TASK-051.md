# Task: ART-TASK-051

### ART-SPEC-LEVEL-001 — Data-driven levels `[PRODUCT-REQUIRED]`

Every level MUST be loadable from a versioned data definition. At minimum it defines: `level_id`, schema version, grid zones and dimensions, ships, standard dock configuration, prequeue capacity, passenger groups, enabled mechanics, content/difficulty metadata, and any reserve data.

### ART-ARCH-LEVEL-002 — `LevelLoader`

`LevelLoader` MUST parse external data, validate schema/version/types, normalize only explicitly allowed defaults, call `LevelValidator`, and construct the initial canonical `GameState`. It MUST return structured errors with a field path. It MUST NOT guess unknown values.

## Source files
- C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic\docs\ASTRO_REBELS_TRAFFIC_MASTER_SPEC_EN.md
- C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic\docs\ASTRO_REBELS_TRAFFIC_ARCHITECTURE_EN.md
