# Task: ART-TASK-022

### ART-SPEC-SHIP-004 — Clear path `[CORE-REQUIRED]`

A path is clear only when the ship can translate from its current footprint to and beyond the applicable rectangular zone boundary without any occupied footprint cell intersecting another ship. Validation MUST consider the whole footprint on every translation step. Partial passage is forbidden. Core levels do not define static obstacles or non-traversable cells.

### ART-SPEC-SHIP-005 — Release prerequisites `[CORE-REQUIRED]`

A standard ship release is legal if and only if both conditions are true:

1. `ART-SPEC-SHIP-004` reports a clear path.
2. At least one standard active dock is empty.

If either condition is false, the ship MUST remain in the grid and the state MUST not otherwise change.

### ART-ARCH-GRID-002 — `PathValidator`

`PathValidator.get_exit_path(state, ship_id)` MUST:

1. derive the complete footprint;
2. advance it one cell at a time in the ship direction;
3. test every newly occupied footprint cell against the rectangular zone boundary and other ships;
4. succeed only when the full rigid footprint can pass beyond the correct zone boundary;
5. return a deterministic path or a structured blocker/reason.

It MUST support all four directions and lengths 1, 2, and 3. It MUST use no physics/raycast dependency.

## Source files
- C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic\docs\ASTRO_REBELS_TRAFFIC_MASTER_SPEC_EN.md
- C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic\docs\ASTRO_REBELS_TRAFFIC_ARCHITECTURE_EN.md
