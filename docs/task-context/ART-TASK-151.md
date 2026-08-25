# Task: ART-TASK-151

### ART-SPEC-LEVEL-002 — Production solvability `[PRODUCT-REQUIRED]`

Every production level MUST have at least one valid solution without ads, rewarded docks, boosters, purchases, or other paid/rewarded assistance. A level that fails solver validation MUST be rejected.

### ART-SPEC-QA-004 — Release gates `[PRODUCT-REQUIRED]`

A release candidate is not complete until relevant automated tests pass, representative levels validate and solve, Android/iOS builds succeed, device performance is measured, and save/ad failure paths have been tested where those systems are enabled.

---

### ART-ARCH-LEVEL-005 — Production manifest

Only validated level IDs may enter the production level manifest. Development/generated candidates MUST remain outside the production manifest until solve, score, and human-review gates pass.

---

## Source files
- C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic\docs\ASTRO_REBELS_TRAFFIC_MASTER_SPEC_EN.md
- C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic\docs\ASTRO_REBELS_TRAFFIC_ARCHITECTURE_EN.md
