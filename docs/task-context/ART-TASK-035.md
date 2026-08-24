# Task: ART-TASK-035

### ART-SPEC-QUEUE-005 — Atomic front-group admission `[CORE-REQUIRED]`

Before removing the front group from the main queue, the resolver MUST calculate how many members can board immediately and how many would remain. The group may be admitted only if the complete remainder fits in the prequeue. If it does not fit, the group MUST remain unchanged at the front and no member of that group may board in that attempt. This prevents passenger loss and partial untracked groups.

---

### ART-SPEC-PREQ-004 — Full prequeue `[CORE-REQUIRED]`

A full prequeue is not an immediate loss. It prevents admission of a main-queue group whose calculated remainder would not fit. Automatic boarding and other legal moves may still create space.

### ART-ARCH-QUEUE-001 — `PassengerQueueRules`

This module MUST expose the front group and compute atomic admission under `ART-SPEC-QUEUE-005`. It MUST not remove or partially consume a main group unless its immediate-board plus prequeue-remainder result is valid as a complete transition.

## Source files
- C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic\docs\ASTRO_REBELS_TRAFFIC_MASTER_SPEC_EN.md
- C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic\docs\ASTRO_REBELS_TRAFFIC_ARCHITECTURE_EN.md
