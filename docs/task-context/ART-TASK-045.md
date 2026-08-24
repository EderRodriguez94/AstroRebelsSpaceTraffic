# Task: ART-TASK-045

### ART-SPEC-SHIP-005 — Release prerequisites `[CORE-REQUIRED]`

A standard ship release is legal if and only if both conditions are true:

1. `ART-SPEC-SHIP-004` reports a clear path.
2. At least one standard active dock is empty.

If either condition is false, the ship MUST remain in the grid and the state MUST not otherwise change.

### ART-SPEC-SHIP-007 — Dock assignment `[CORE-REQUIRED]`

A successfully released standard ship MUST be assigned to the **leftmost empty standard active dock**. “Leftmost” is determined by the dock's fixed visual/logical index, from lowest index to highest. The player MUST NOT choose the destination standard dock.

### ART-SPEC-RESOLVE-002 — Input lock `[CORE-REQUIRED]`

From acceptance of a state-changing command until its resolution and required presentation complete, ship-selection input MUST be locked. Additional taps MUST NOT queue another move. Restart and application-level safety controls MAY use a separately defined confirmation flow.

### ART-ARCH-CMD-003 — Release validation order

`ReleaseShipCommand` MUST validate in deterministic order:

1. session phase is `PLAYING`;
2. input/application gate accepts a new gameplay command;
3. ship ID exists and ship is in a grid zone;
4. tutorial permits selection, if constrained;
5. Mystery reveal rule, if enabled and applicable;
6. `PathValidator` confirms a clear full-footprint route;
7. `DockSystem` finds the leftmost empty standard active dock.

The rejection reason MUST identify the first failed applicable condition. A rejected release MUST return an unchanged state and MUST not create an undo snapshot.

### ART-ARCH-CMD-004 — Transactionality

An accepted command and its complete automatic domain resolution MUST be one logical transaction from settled state to settled state. If an invariant fails, the transaction MUST not publish a partial state.

### ART-ARCH-RES-002 — Release transaction

For an accepted standard release, the domain order MUST be:

1. remove ship occupancy from its zone;
2. assign it to the previously selected leftmost empty active standard dock;
3. emit grid-exit and dock-arrival domain events;
4. run the automatic settlement loop in `ART-ARCH-RES-003`;
5. evaluate win, then real deadlock;
6. set phase and emit one terminal event if applicable;
7. assert invariants and return.

## Source files
- C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic\docs\ASTRO_REBELS_TRAFFIC_MASTER_SPEC_EN.md
- C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic\docs\ASTRO_REBELS_TRAFFIC_ARCHITECTURE_EN.md
