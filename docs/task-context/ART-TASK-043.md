# Task: ART-TASK-043

### ART-SPEC-LOSE-001 — Exact real-deadlock condition `[CORE-REQUIRED]`

A level is lost if and only if all of the following are true in a settled, non-winning state:

1. every currently active dock that may receive a standard released ship is occupied;
2. no currently eligible passenger from the prequeue or front main-queue group can produce boarding under the queue, capacity, color, and right-to-left priority rules;
3. no automatic transition can fill and depart a dock ship or otherwise free a dock;
4. no grid ship can be released because no eligible active dock is empty; and
5. no already-active special system has a mandatory automatic transition that can change conditions 1–4.

This is a real deadlock. “Docks full” alone, “prequeue full” alone, or “a selected ship is blocked” alone MUST NOT cause loss. Locked rewarded recovery and unused boosters are external recovery options and MUST NOT prevent the state from being classified as a loss.

### ART-SPEC-LOSE-002 — No false loss during resolution `[CORE-REQUIRED]`

Deadlock MUST NOT be evaluated on an intermediate animation or before mandatory automatic transitions finish.

---

### ART-ARCH-END-002 — `DeadlockDetector`

`DeadlockDetector.is_real_deadlock(state)` MUST implement the conjunction in `ART-SPEC-LOSE-001`. It MUST:

- first reject winning states;
- require a settled state;
- treat only currently active docks as available;
- use canonical queue/prequeue eligibility and `BoardingResolver` queries;
- confirm no automatic transition can free space;
- ignore locked ads, unconsumed boosters, and hypothetical purchases;
- return structured evidence for tests, UI, analytics, and solver diagnostics.

### ART-ARCH-END-003 — No heuristic loss

UI scripts and dock counters MUST NOT declare loss. Only `DeadlockDetector` may produce the terminal deadlock result.

---

## Source files
- C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic\docs\ASTRO_REBELS_TRAFFIC_MASTER_SPEC_EN.md
- C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic\docs\ASTRO_REBELS_TRAFFIC_ARCHITECTURE_EN.md
