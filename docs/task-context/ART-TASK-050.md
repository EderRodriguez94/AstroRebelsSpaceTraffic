# Task: ART-TASK-050

### ART-SPEC-LEVEL-001 — Data-driven levels `[PRODUCT-REQUIRED]`

Every level MUST be loadable from a versioned data definition. At minimum it defines: `level_id`, schema version, grid zones and dimensions, ships, standard dock configuration, prequeue capacity, passenger groups, enabled mechanics, content/difficulty metadata, and any reserve data.

### ART-ARCH-LEVEL-001 — `LevelDefinition`

Use a versioned, data-only definition equivalent to:

```text
LevelDefinition
  schema_version
  level_id
  zones[]
    zone_id, width, height
  ships[]
    id, zone, color, size, anchor, direction, special_type, hidden_color
  docks
    base_count=4, rewarded_count=4, enabled special configuration
  prequeue_capacity=16
  passenger_groups[]
    id, color, count
  mechanics{}
  reserve{}          # optional
  tutorial{}         # optional
  difficulty_metadata{}
  content_metadata{}
```

Do not store scene paths or provider objects inside core mechanical data. Presentation asset catalogs MAY reference the same stable IDs separately.

### ART-ARCH-LEVEL-004 — Schema migration

Level schema changes require a version bump, deterministic migration or explicit incompatibility error, updated fixtures, and validator tests. Never reinterpret old data silently.

## Source files
- C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic\docs\ASTRO_REBELS_TRAFFIC_MASTER_SPEC_EN.md
- C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic\docs\ASTRO_REBELS_TRAFFIC_ARCHITECTURE_EN.md
