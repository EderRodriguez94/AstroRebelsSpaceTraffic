# Task: ART-TASK-053

### ART-SPEC-TUT-002 — Teaching order `[PRODUCT-REQUIRED]`

The initial teaching order MUST be:

1. release a clear ship;
2. color matching;
3. limited docks;
4. consequences of releasing the wrong color;
5. multiple directions;
6. Medium ships;
7. Large ships;
8. circular prequeue.

Advanced mechanics MUST receive their own introduction before appearing in an unrestricted level.

### ART-SPEC-LEVEL-003 — Color progression `[PRODUCT-REQUIRED]`

Initial colors are `Red`, `Blue`, `Green`, and `Yellow`. Later content MAY introduce `Purple`, `Orange`, `Cyan`, and `Pink`. Colors MUST be introduced progressively; number of simultaneous colors is a difficulty variable.

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

## Source files
- C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic\docs\ASTRO_REBELS_TRAFFIC_MASTER_SPEC_EN.md
- C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic\docs\ASTRO_REBELS_TRAFFIC_ARCHITECTURE_EN.md
