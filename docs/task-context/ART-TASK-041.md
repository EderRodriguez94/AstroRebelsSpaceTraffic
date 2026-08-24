# Task: ART-TASK-041

### ART-SPEC-RESOLVE-001 — Required settled-state outcome `[CORE-REQUIRED]`

After an accepted release, the game MUST resolve all mandatory automatic transitions until a settled state is reached. The observable sequence is:

1. ship exits grid;
2. ship enters assigned dock;
3. prequeue and eligible front main-queue demand are resolved;
4. full ships depart and free docks;
5. any resulting boarding opportunity is resolved;
6. win and deadlock are evaluated;
7. control returns if the level is neither won nor lost.

The technical architecture defines the exact deterministic loop without changing these outcomes.

### ART-SPEC-PREQ-005 — Reevaluation triggers `[CORE-REQUIRED]`

The prequeue MUST be reevaluated during deterministic resolution whenever a ship arrives, compatible capacity changes, boarding occurs, or a full ship departs.

---

### ART-ARCH-RES-001 — Responsibility

`ResolutionSystem` converts one accepted command state into one settled state. It owns ordering of automatic transitions; it does not own animation timing.

### ART-ARCH-RES-003 — Settlement loop

Use the following logical loop until a complete pass makes no state change:

```text
repeat
  changed = false

  scan prequeue once in preserved logical order;
  board every passenger that is eligible under right-to-left priority;
  changed |= any boarded

  depart every full dock ship in stable dock-index order;
  changed |= any departed

  if front main-queue group can be atomically admitted:
      board its immediately compatible passengers;
      append its complete unboarded remainder to prequeue;
      remove the group from main queue;
      changed = true

  depart every newly full dock ship in stable dock-index order;
  changed |= any departed
until changed == false
```

After any departure, the next pass reevaluates the prequeue before another main group. This gives previously waiting passengers priority over newly admitted demand and preserves deterministic circular behavior.

### ART-ARCH-RES-004 — Termination guarantee

Each state-changing loop operation MUST monotonically reduce passengers outside ships, increase passengers inside a ship, remove a full ship, or remove a main group. No operation may move a passenger back to the main queue or create passengers. Tests MUST prove termination for bounded valid levels.

### ART-ARCH-RES-005 — Event order

Events MUST be appended in exactly the transition order used by the resolver. If operations are batched for performance, their event ordering and final state MUST match the unbatched canonical algorithm.

## Source files
- C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic\docs\ASTRO_REBELS_TRAFFIC_MASTER_SPEC_EN.md
- C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic\docs\ASTRO_REBELS_TRAFFIC_ARCHITECTURE_EN.md
