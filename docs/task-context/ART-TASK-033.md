# Task: ART-TASK-033

### ART-SPEC-BOARD-001 — Automatic boarding `[CORE-REQUIRED]`

Boarding MUST be automatic. The player MUST NOT drag passengers or manually choose a ship.

### ART-SPEC-BOARD-002 — Right-to-left compatible priority `[CORE-REQUIRED]`

When more than one dock ship can accept a passenger of the same color, the resolver MUST fill the **rightmost compatible ship first**, then continue toward the left. “Rightmost” means the highest fixed dock index. This rule supersedes the earlier discarded left-first boarding proposal.

### ART-SPEC-BOARD-003 — Capacity boundary `[CORE-REQUIRED]`

A ship MUST never receive more passengers than its capacity. Boarding consumes passengers one logical unit at a time or as an equivalent deterministic batch with exactly the same outcome.

### ART-SPEC-QUEUE-004 — Group splitting `[CORE-REQUIRED]`

A group MAY split across multiple compatible dock ships. It MUST board compatible ships using `ART-SPEC-BOARD-002`. Examples:

- 8 passengers may fill one 8-capacity ship or two 4-capacity ships.
- 16 passengers may fill one 16-capacity ship, two 8-capacity ships, four 4-capacity ships, or another exact same-color combination.

No passenger may board an incompatible ship.

### ART-ARCH-BOARD-001 — `BoardingResolver`

`BoardingResolver` MUST be the sole owner of passenger-to-dock allocation. For each eligible passenger or equivalent deterministic batch it MUST:

1. identify occupied ships of equal color with remaining capacity;
2. order them by dock `visual_index` descending;
3. fill the first compatible ship before the next;
4. never exceed capacity;
5. emit exact passenger-count changes and boarding events.

No queue, dock view, or solver code may implement a separate boarding priority.

## Source files
- C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic\docs\ASTRO_REBELS_TRAFFIC_MASTER_SPEC_EN.md
- C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic\docs\ASTRO_REBELS_TRAFFIC_ARCHITECTURE_EN.md
