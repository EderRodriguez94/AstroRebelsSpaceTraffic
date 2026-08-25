# Task: ART-TASK-150

### ART-SPEC-QA-003 — Required rule coverage `[PRODUCT-REQUIRED]`

Automated tests MUST cover ship footprints and all four directions, release rejection reasons, leftmost dock assignment, right-to-left boarding, group splits, prequeue order/capacity, cascading departures, exact win, exact deadlock, input gating, undo restoration, level validation, and deterministic serialization/hashing.

### ART-ARCH-TEST-001 — Test layers

Required automated suites:

- pure unit tests for state, footprint, path, docks, queues, boarding, resolution, win, and deadlock;
- command transaction tests;
- invariant/property tests;
- level schema/validator fixture tests;
- runtime-versus-solver transition parity tests;
- hash/equality golden tests;
- solver solvable/unsolvable/unknown-limit tests;
- save migration/corruption tests;
- ad result/idempotency tests;
- scene smoke and presentation rebuild tests;
- production-level validation and solvability gate.

### ART-ARCH-TEST-002 — Canonical scenario fixtures

Fixtures MUST include at least:

1. each ship size in each direction with clear and blocked paths;
2. leftmost empty dock assignment;
3. multiple same-color docks proving right-to-left boarding;
4. 8 split into two Small ships;
5. 16 split across valid combinations;
6. prequeue compatible passengers removed while survivor order is preserved;
7. front main group held when its remainder cannot fit;
8. full prequeue that is not a loss;
9. cascading boarding/departure to settlement;
10. exact win with every required container empty;
11. full docks with a possible boarding transition, proving no false loss;
12. exact real deadlock;
13. rejected tap produces unchanged hash and no snapshot;
14. undo restores byte/canonical equality;
15. multi-zone, Mystery, and Reserve fixtures when enabled.

### ART-ARCH-TEST-004 — Reproducibility

Every failing randomized/property test MUST print a reproducible seed and minimized state/command fixture. Hidden wall-clock randomness is forbidden.

## Source files
- C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic\docs\ASTRO_REBELS_TRAFFIC_MASTER_SPEC_EN.md
- C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic\docs\ASTRO_REBELS_TRAFFIC_ARCHITECTURE_EN.md
