# Astro Rebels Traffic — Technical Architecture

**Document ID:** `ART-ARCH`  
**Language:** English  
**Status:** Normative technical source of truth  
**Product rules:** `ASTRO_REBELS_TRAFFIC_MASTER_SPEC_EN.md`  
**Engine:** Godot 4.x  
**Intended reader:** A local implementation AI with limited reasoning ability

---

## 1. Architecture Contract

### ART-ARCH-GOV-001 — Required architecture

The game MUST use this logical flow:

```text
Input / Solver
      ↓
   Commands
      ↓
Command Validation ──→ Pure Rules
      ↓
Deterministic ResolutionSystem
      ↓
New GameState + Ordered Domain Events
      ↓
Presentation / Audio / Analytics
```

The required separation is **GameState + Commands + pure Rules + deterministic ResolutionSystem + Events + Presentation**.

### ART-ARCH-GOV-002 — One canonical game

Runtime, unit tests, integration tests, solver, state replay, level validator, level generator, and difficulty evaluator MUST consume the same canonical `GameState`, commands, and rule modules. They MUST NOT reproduce gameplay rules in UI scripts, solver-only code, test fakes, or editor tools.

### ART-ARCH-GOV-003 — Normative technical terms

- **Domain:** serializable state and deterministic game rules.
- **Application layer:** command orchestration, snapshots, and service coordination.
- **Presentation:** Godot scenes, nodes, animation, VFX, UI, input, and audio.
- **Infrastructure:** persistence, ads, analytics providers, platform adapters, files, and clocks.
- **Pure function:** output depends only on explicit input; no scene tree, wall clock, device, network, singleton, mutable global, or hidden randomness.

### ART-ARCH-GOV-004 — Undecided implementation choices

The final Godot minor version and implementation language are TBD in `ART-SPEC-OPEN-002`. An agent MUST NOT silently choose them in an unrelated task. Once approved, pin them in project configuration and CI. Class/module names in this document are normative concepts; language-specific casing may follow the approved style guide.

### ART-ARCH-GOV-005 — No speculative framework

Use Godot built-ins and small project-owned modules. Do not add a dependency-injection framework, entity-component framework, physics-based puzzle model, reactive framework, or service locator unless an approved task demonstrates a requirement.

---

## 2. Dependency Direction

### ART-ARCH-DEP-001 — Layer dependency rule

Allowed compile/load-time dependency direction:

```text
Presentation ───────→ Application ───────→ Domain
Infrastructure ────→ Application ports ─→ Domain value types
Solver / Tools ─────────────────────────→ Domain
Tests ──────────────────────────────────→ all tested targets
```

Domain MUST depend on no presentation, infrastructure, ad SDK, analytics SDK, filesystem, platform API, Godot scene, animation, or audio object.

### ART-ARCH-DEP-002 — Forbidden dependencies

The following are forbidden:

- `Domain → Presentation`;
- `Domain → Infrastructure`;
- `Solver → Presentation`;
- `Rules → Godot scene nodes`;
- `BoardingResolver → animations`;
- `DeadlockDetector → UI or ad availability`;
- gameplay code calling a concrete ad/analytics SDK;
- presentation directly mutating `GameState`;
- multiple mutable authoritative copies of state.

### ART-ARCH-DEP-003 — Ownership

`GameSession` owns the one authoritative runtime `GameState`. Views hold identifiers and display data only. A view MUST request a command; it MUST NOT mutate ship, passenger, dock, or grid state.

---

## 3. Canonical State Model

### ART-ARCH-STATE-001 — `GameState`

`GameState` MUST be a complete, deep-copyable, deterministically serializable logical state. It contains at least:

```text
GameState
  schema_version
  level_id
  attempt_id          # excluded from solver equality when non-gameplay metadata
  phase               # PLAYING | WON | LOST
  move_index
  zones[]             # GridState in stable zone order
  ships_by_id{}       # ShipState, stable IDs
  passenger_queue     # PassengerQueueState
  prequeue            # PreQueueState
  docks               # DockState in fixed left-to-right order
  vip_dock             # optional planned state
  reserve              # optional planned state
  mechanic_flags
  attempt_modifiers   # temporary unlocks/boosters
  tutorial_state      # only logical gating needed by gameplay
  rng_state            # only if an approved deterministic feature needs it
```

Animation progress, Node references, textures, audio state, wall-clock timestamps, analytics IDs, and provider objects MUST NOT be stored in `GameState`.

### ART-ARCH-STATE-002 — Stable identifiers and order

Zone, ship, dock, group, and level IDs MUST be stable and unique within their declared scope. Any collection whose order affects rules or hashing MUST use an explicit ordered representation. Unordered map iteration MUST NOT determine gameplay outcomes.

### ART-ARCH-STATE-003 — `GridState` and `ShipState`

```text
GridState
  zone_id
  width
  height
  ship_ids in stable order
  occupancy index or reproducible occupancy data

ShipState
  ship_id
  zone_id or DOCK/RESERVE location
  color_id
  size_class       # SMALL | MEDIUM | LARGE
  capacity         # derived/validated as 4 | 8 | 16
  passenger_count
  anchor_cell
  direction        # UP | DOWN | LEFT | RIGHT
  special_type     # NORMAL | MYSTERY, extensible by approved rules
  is_revealed
```

Ship footprint MUST be derived from anchor, size, and direction by one canonical function. It MUST NOT be stored in multiple independently mutable forms.

### ART-ARCH-STATE-004 — Passenger state

```text
PassengerGroup
  group_id
  color_id
  count            # exactly 4, 8, or 16 in source level data

PassengerQueueState
  groups[]         # ordered; front is index 0 or explicit head

PreQueueState
  capacity         # individual passenger units; default 16
  entries[]        # ordered compact runs or individual logical entries
  count
```

If compact color runs are used, operations MUST produce exactly the same order and boarding result as individual passenger entries.

### ART-ARCH-STATE-005 — Dock state

```text
DockState
  dock_id
  visual_index     # fixed left-to-right total order
  kind             # BASE | REWARDED | VIP
  is_active
  occupant_ship_id # null or exactly one ship
```

The eight standard docks MUST have a stable left-to-right index. Base docks start active; rewarded docks start inactive. Standard release assignment searches active empty standard docks in ascending index. Boarding searches compatible occupied docks in descending index.

### ART-ARCH-STATE-006 — Invariants

`GameStateInvariantChecker` MUST validate at least:

- one logical location per ship;
- no grid overlap or out-of-bounds footprint;
- occupancy index equals derived footprints;
- canonical size/capacity mapping;
- `0 ≤ passenger_count ≤ capacity`;
- at most one occupant per dock;
- no occupant in an inactive dock;
- prequeue count equals entries and does not exceed capacity;
- main source group sizes are 4/8/16;
- non-negative passenger counts;
- known color and direction IDs;
- state phase consistent with win/deadlock when checked at settlement;
- reserve and Mystery state consistent with enabled mechanic flags.

Invariant checks MUST run in tests, level validation, solver ingestion, and debug builds. Release builds MAY use a lower-cost subset at safe boundaries.

---

## 4. Commands and Application Boundary

### ART-ARCH-CMD-001 — Command interface

Every state-changing user/system request MUST be represented as an immutable command. A command handler returns a structured result, never a presentation side effect:

```text
CommandResult
  accepted: bool
  rejection_reason: enum/null
  next_state: GameState
  events[]: DomainEvent in stable order
  snapshot_policy/result metadata
```

### ART-ARCH-CMD-002 — Required commands

The application/domain boundary MUST define at least:

- `ReleaseShipCommand(ship_id)`;
- `RestartLevelCommand` or an application-level restart operation;
- `UndoCommand` when Undo is enabled;
- `UnlockRewardDockCommand(reward_token)` through the ad reward boundary;
- `UseScannerCommand` when Mystery/Scanner is enabled;
- `ActivateVipDockCommand` only after VIP routing is specified;
- tutorial acknowledgement/gating commands only when they change logical tutorial state.

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

### ART-ARCH-CMD-005 — Input gate versus domain state

Runtime input lock has two parts:

- the domain/application transaction disallows another command while resolution is executing;
- `PresentationCoordinator` keeps gameplay input disabled until the emitted event sequence that must precede control return has finished.

Solver and tests execute the same transaction without animation and receive the settled result immediately. Presentation timing MUST not enter state hashing.

---

## 5. Pure Rule Modules

### ART-ARCH-RULE-001 — Rule function contract

Rule modules MUST be stateless pure functions or stateless objects with explicit immutable inputs. They MAY return derived data. They MUST NOT mutate the scene tree or call services.

### ART-ARCH-GRID-001 — `GridQuery`

`GridQuery` MUST provide canonical queries for rectangular bounds, footprint, occupancy, and zones. Every consumer MUST use these queries instead of reproducing coordinate math. Static obstacle/traversability rules are not part of the authorized core.

### ART-ARCH-GRID-002 — `PathValidator`

`PathValidator.get_exit_path(state, ship_id)` MUST:

1. derive the complete footprint;
2. advance it one cell at a time in the ship direction;
3. test every newly occupied footprint cell against the rectangular zone boundary and other ships;
4. succeed only when the full rigid footprint can pass beyond the correct zone boundary;
5. return a deterministic path or a structured blocker/reason.

It MUST support all four directions and lengths 1, 2, and 3. It MUST use no physics/raycast dependency.

### ART-ARCH-GRID-003 — Visual independence

Grid coordinates are integers. Pixel position and scale are computed only by presentation from zone layout. Increasing cell density MUST not alter rule calculations.

### ART-ARCH-DOCK-001 — `DockSystem`

`DockSystem` MUST own pure dock queries and transitions:

- find leftmost empty active standard dock: ascending `visual_index`;
- return compatible occupied docks for boarding: descending `visual_index`;
- place/remove a ship;
- activate one authorized rewarded slot;
- report standard capacity/occupancy;
- exclude locked docks from availability and deadlock prevention.

### ART-ARCH-QUEUE-001 — `PassengerQueueRules`

This module MUST expose the front group and compute atomic admission under `ART-SPEC-QUEUE-005`. It MUST not remove or partially consume a main group unless its immediate-board plus prequeue-remainder result is valid as a complete transition.

### ART-ARCH-QUEUE-002 — `PreQueueRules`

This module MUST append remainder passengers without exceeding capacity and perform one deterministic logical-order scan. Removal MUST preserve relative order of remaining entries. Visual circular movement is irrelevant to these rules.

### ART-ARCH-BOARD-001 — `BoardingResolver`

`BoardingResolver` MUST be the sole owner of passenger-to-dock allocation. For each eligible passenger or equivalent deterministic batch it MUST:

1. identify occupied ships of equal color with remaining capacity;
2. order them by dock `visual_index` descending;
3. fill the first compatible ship before the next;
4. never exceed capacity;
5. emit exact passenger-count changes and boarding events.

No queue, dock view, or solver code may implement a separate boarding priority.

### ART-ARCH-END-001 — `WinCondition`

`WinCondition.is_won(state)` MUST implement only `ART-SPEC-WIN-001`. It MUST be called after resolution reaches quiescence. It MUST account for all zones and enabled Reserve/VIP state.

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

## 6. Deterministic `ResolutionSystem`

### ART-ARCH-RES-001 — Responsibility

`ResolutionSystem` converts one accepted command state into one settled state. It owns ordering of automatic transitions; it does not own animation timing.

### ART-ARCH-RES-002 — Release transaction

For an accepted standard release, the domain order MUST be:

1. remove ship occupancy from its zone;
2. assign it to the previously selected leftmost empty active standard dock;
3. emit grid-exit and dock-arrival domain events;
4. run the automatic settlement loop in `ART-ARCH-RES-003`;
5. evaluate win, then real deadlock;
6. set phase and emit one terminal event if applicable;
7. assert invariants and return.

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

### ART-ARCH-RES-006 — Reserve integration `[PLANNED/ADVANCED]`

When Reserve/Hangar is implemented, check its configured entry once after a grid ship leaves and before passenger settlement. Its transition MUST be covered by termination tests. It MUST NOT be added until the per-release entry count, target zone, and entry cells from `ART-SPEC-ADV-002` are represented in `LevelDefinition`.

### ART-ARCH-RES-007 — Mystery reveal integration `[PLANNED/ADVANCED]`

When Mystery Ships are enabled, removing a grid ship MUST trigger a stable ship-ID-order scan of still-hidden Mystery Ships. Any ship whose path changed from blocked to clear because of that removal is revealed and emits `MysteryShipRevealed` before passenger settlement. Selecting an already-clear hidden Mystery Ship reveals it during command validation before release. The hidden color always comes from level data; neither path validation nor presentation generates it.

---

## 7. Domain Events and Presentation

### ART-ARCH-EVENT-001 — Event contract

Domain events are immutable facts. They MUST contain stable IDs and logical before/after values needed for consumers, not Node references. Required event categories include:

```text
ShipReleaseRejected
ShipExitedGrid
ShipAssignedToDock
PassengerGroupAdmitted
PassengersEnteredPreQueue
PassengersBoarded
ShipDepartedDock
RewardDockActivated
MysteryShipRevealed
UndoApplied
LevelWon
RealDeadlockDetected
```

### ART-ARCH-EVENT-002 — Event consumers

Presentation, audio, analytics mapping, tutorials, and debugging MAY consume events. Consumers MUST NOT change the already-resolved outcome. A consumer failure MUST NOT corrupt `GameState`.

### ART-ARCH-PRES-001 — `PresentationCoordinator`

`PresentationCoordinator` MUST:

1. receive the accepted command result and ordered events;
2. disable gameplay input;
3. play or skip visual/audio sequences in event order with safe parallelism only where outcome clarity is preserved;
4. rebuild/synchronize views from authoritative state after the sequence;
5. show terminal UI or re-enable input.

It MUST support instant playback for tests/debug and interruption-safe rebuilding after scene reload.

### ART-ARCH-PRES-002 — View responsibilities

`GridView`, `ShipView`, `PassengerQueueView`, `PreQueueView`, `DockRowView`, `HudView`, `TutorialOverlay`, and booster views render state and forward intent. They MUST NOT contain path, boarding, win, or deadlock rules.

### ART-ARCH-PRES-003 — Object pooling

Passenger figures, transient VFX, and frequently created labels/icons SHOULD use pools. Pool reuse MUST fully reset visual state. Logical passengers remain domain data, not pooled Nodes.

### ART-ARCH-PRES-004 — Accessibility mapping

`ColorCatalog`/presentation data MUST map each logical color ID to visual color, faction symbol/pattern, accessible label, and assets. Rules compare stable color IDs only.

---

## 8. Level Data Pipeline

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

### ART-ARCH-LEVEL-002 — `LevelLoader`

`LevelLoader` MUST parse external data, validate schema/version/types, normalize only explicitly allowed defaults, call `LevelValidator`, and construct the initial canonical `GameState`. It MUST return structured errors with a field path. It MUST NOT guess unknown values.

### ART-ARCH-LEVEL-003 — `LevelValidator`

Validation MUST include:

- schema/version and required fields;
- unique IDs and known enums;
- positive valid dimensions;
- ship footprint alignment, bounds, overlap, and capacity mapping;
- valid direction and exit geometry;
- exactly four base and four rewarded standard dock definitions unless a future schema explicitly changes presentation only;
- positive prequeue capacity, default 16;
- passenger group sizes 4/8/16;
- per-color passenger/capacity conservation including reserves;
- mechanic-specific fields and dependencies;
- initial invariants;
- solver solvability for production status;
- no assistance required by the recorded solution.

### ART-ARCH-LEVEL-004 — Schema migration

Level schema changes require a version bump, deterministic migration or explicit incompatibility error, updated fixtures, and validator tests. Never reinterpret old data silently.

### ART-ARCH-LEVEL-005 — Production manifest

Only validated level IDs may enter the production level manifest. Development/generated candidates MUST remain outside the production manifest until solve, score, and human-review gates pass.

---

## 9. Solver, Hashing, Generation, and Difficulty

### ART-ARCH-SOLVER-001 — Solver boundary

`Solver` MUST load a validated `LevelDefinition`, build the same `GameState`, enumerate legal domain commands, and execute them through the same command handler and `ResolutionSystem` as runtime. A solver-only “fast rule” that changes results is forbidden.

### ART-ARCH-SOLVER-002 — Legal action enumeration

For core levels, legal solver actions are accepted `ReleaseShipCommand`s for grid ships. Ads, rewarded docks, boosters, purchases, restarts, and presentation actions MUST be excluded when proving baseline production solvability.

### ART-ARCH-SOLVER-003 — `StateHasher`

The hasher MUST canonicalize all rule-relevant state:

- zones in stable order and ship IDs/positions/directions/reveal state;
- dock activation, occupants, and ship passenger counts in dock index order;
- main queue order and counts;
- prequeue logical order and capacity;
- reserve order/entry state when enabled;
- mechanic flags and rule-relevant attempt modifiers;
- deterministic RNG state if authorized.

It MUST exclude presentation, animation time, analytics IDs, wall clock, and undo history unless a particular search explicitly models undo. Equality MUST confirm canonical data after hash matches to protect against collisions.

### ART-ARCH-SOLVER-004 — Search result

`SolverResult` SHOULD report solvable status, a valid and preferably minimal command sequence under configured search, move count, explored states, dead-end/deadlock count, limits/timeouts, and reproducible diagnostics. “Unknown due to limit” MUST NOT be reported as unsolvable.

### ART-ARCH-SOLVER-005 — Search strategy

The initial strategy MAY use BFS, A*, IDA*, or another state search with pruning. Strategy is replaceable; canonical state transition semantics are not. Search limits MUST be explicit and deterministic where practical.

### ART-ARCH-SOLVER-006 — `LevelGenerator` `[PLANNED/ADVANCED]`

`LevelGenerator` creates candidate definitions only. It MUST call the shared validator and solver, then `DifficultyEvaluator`, then output to a review queue. It MUST never write directly to the production manifest.

### ART-ARCH-SOLVER-007 — `DifficultyEvaluator` `[PLANNED/ADVANCED]`

Difficulty evaluation SHOULD combine solution length, branching factor, number/proximity of real deadlocks, forced moves, dock pressure, color count, prequeue pressure, grid density, ship sizes, and enabled advanced mechanics. Metric weights are tunable content configuration, not gameplay rules.

### ART-ARCH-PERF-001 — Solver execution

Runtime solver/generator work, if exposed in tools, MUST run outside the gameplay main thread with cancellation and bounded budgets. The shipped puzzle loop MUST not wait for solver completion.

---

## 10. Undo and Snapshots

### ART-ARCH-UNDO-001 — Snapshot boundary `[PLANNED/ADVANCED]`

Before an accepted player move mutates state, `UndoService` MUST deep-copy or structurally snapshot the complete settled `GameState`. Rejected commands MUST NOT create snapshots.

### ART-ARCH-UNDO-002 — Restore semantics `[PLANNED/ADVANCED]`

Undo restores the snapshot as the new authoritative state, validates invariants, clears any current presentation sequence, rebuilds all views, and emits `UndoApplied`. It MUST restore all fields listed by `ART-SPEC-ADV-006`.

### ART-ARCH-UNDO-003 — History policy `[PLANNED/ADVANCED]`

Core product direction requires at least one-step Undo when the booster is enabled. Multi-step depth, storage limit, and whether an undo consumption itself is reversible are TBD. Do not invent them.

### ART-ARCH-UNDO-004 — Solver interaction

Baseline solvability MUST ignore Undo. Undo history is excluded from normal state hashing. A future solver that evaluates booster strategy must use a separate explicit search model.

---

## 11. Save Architecture

### ART-ARCH-SAVE-001 — Port and adapter

Application code MUST depend on an `ISaveStore`-equivalent interface, not a direct filesystem/cloud API:

```text
load() -> SaveLoadResult
write_atomically(save_data) -> SaveWriteResult
backup/recover() -> result
```

### ART-ARCH-SAVE-002 — `SaveData`

`SaveData` MUST be separate from `GameState` and versioned. It contains settings, progression, tutorial completion, and approved inventory. Attempt-local temporary docks MUST not be copied to general progression data.

### ART-ARCH-SAVE-003 — Atomic persistence

The local adapter MUST serialize deterministically where practical, validate before write, write a temporary file, flush/close, replace the primary atomically where supported, and retain/recover from a last-known-good backup. Corruption MUST return a structured recovery result, not crash.

### ART-ARCH-SAVE-004 — Migrations

Each released save schema transition requires tested migrations. Unknown future versions MUST be preserved/rejected safely rather than overwritten.

### ART-ARCH-SAVE-005 — Cloud save `[PLANNED/ADVANCED]`

Cloud save is TBD. It MUST be a separate adapter with an explicit conflict policy before implementation.

---

## 12. Rewarded Ads and Monetization Boundaries

### ART-ARCH-ADS-001 — Provider abstraction

Use an application-facing `IRewardedAdService` equivalent:

```text
is_available(placement_id)
show(placement_id) -> RewardedAdResult
```

`RewardedAdResult` MUST distinguish completed-and-verified, unavailable, cancelled, failed, and invalid/stale reward.

### ART-ARCH-ADS-002 — Reward authority

Only `RewardGrantService` may translate a verified provider result into `UnlockRewardDockCommand` or an approved booster grant. UI callbacks and provider adapters MUST NOT mutate `GameState` directly. Each reward transaction MUST be idempotent by a unique reward token.

### ART-ARCH-ADS-003 — Provider failure

Ad service failure MUST leave game state unchanged and return control safely. The domain MUST remain testable with fake success/failure adapters and no SDK installed.

### ART-ARCH-ADS-004 — Interstitial abstraction

Interstitial availability/frequency belongs to a policy/service outside the domain. Presentation may request display only at application flow boundaries allowed by `ART-SPEC-ADS-003`.

### ART-ARCH-ADS-005 — Near-deadlock hints

A non-terminal risk evaluator MAY suggest an emergency-dock offer, but it MUST be separate from `DeadlockDetector`. It MUST NOT change loss classification or core rules.

---

## 13. Analytics Architecture

### ART-ARCH-AN-001 — Port

Gameplay/application code MUST emit typed internal analytics records through `IAnalyticsService`. The default no-op adapter MUST preserve full gameplay functionality.

### ART-ARCH-AN-002 — Mapping

`AnalyticsEventMapper` MAY translate domain events and application lifecycle facts to provider schemas. Domain event classes MUST NOT contain provider names or SDK objects.

### ART-ARCH-AN-003 — Reliability and privacy

Analytics is best-effort. Buffering, retry, consent filtering, and provider failure MUST not block resolution. Payload allowlists MUST enforce `ART-SPEC-AN-003`.

---

## 14. Advanced-System Extension Points

### ART-ARCH-ADV-001 — Feature gating

Advanced mechanics MUST be activated by validated `LevelDefinition.mechanics` flags and corresponding data. Disabled systems MUST have zero effect on core state transitions and hashes.

### ART-ARCH-ADV-002 — Mystery Ships

Mystery uses the existing `ShipState` with predefined hidden color and reveal state. `MysteryRules` decides reveal eligibility. `PathValidator` uses footprint/direction regardless of reveal. `BoardingResolver` sees the true color only after release/reveal rules authorize it. Scanner dispatches a command; presentation never assigns a color.

### ART-ARCH-ADV-003 — Reserve/Hangar

Reserve uses ordered `ReserveState`, pure `ReserveRules`, and validated entry definitions. Automatic insertion is orchestrated only by `ResolutionSystem`. It MUST share `ShipState`, `GridState`, invariants, solver, and hashing.

### ART-ARCH-ADV-004 — Multi-zone

`GameState.zones` is required even for one-zone levels. `PathValidator` receives a zone ID. Dock, passenger, boarding, end-condition, solver, and resolution modules operate across the zone collection without duplicating per-zone rules.

### ART-ARCH-ADV-005 — VIP Dock

Model VIP as a separate dock kind/state, not as a color override. Do not connect release routing until `ART-SPEC-ADV-004` is resolved. Enabling an empty VIP dock must affect deadlock only if the approved routing makes it eligible to receive a ship.

### ART-ARCH-ADV-006 — Boosters

Each booster requires one command, pure validation, deterministic state transition, event, UI adapter, save/inventory rule, analytics mapping, tests, and solver policy. No booster may bypass the command boundary.

---

## 15. Godot Scene and Service Structure

### ART-ARCH-SCENE-001 — Scene tree

Use a small composed scene structure equivalent to:

```text
AppRoot.tscn
  AppBootstrap
  SceneFlow
  ServiceRegistry        # composition root only
  ScreenHost

MainMenuScreen.tscn
LevelSelectScreen.tscn
GameplayScreen.tscn
  GameplayController
  PresentationCoordinator
  HudLayer
    LevelHeader
    PassengerQueueView
    PreQueueView
    DockRowView
    BoosterBar
    TutorialOverlay
    ResultOverlay
  BoardViewport
    ZoneLayout
      GridView (one per zone)
      ShipView instances
  VfxLayer
  AudioCoordinator
SettingsScreen.tscn
```

Exact Node types may follow the approved 2D/2.5D art implementation. Responsibilities and dependency boundaries MUST remain.

### ART-ARCH-SCENE-002 — Composition root

`AppBootstrap`/`ServiceRegistry` is the only place that constructs concrete save, ad, analytics, audio, and platform adapters. It injects ports into application services. Domain modules MUST NOT fetch global singletons.

### ART-ARCH-SCENE-003 — Autoload policy

Autoloads MAY be used only for true application-lifetime services such as scene flow, settings/save coordination, and composition. Do not make `GameState`, `BoardingResolver`, views, or per-level mutable systems global autoloads.

### ART-ARCH-SCENE-004 — Runtime session

`GameplayController` owns/uses one `GameSession`, forwards validated player intent, receives `CommandResult`, and hands events to `PresentationCoordinator`. It MUST not calculate paths or boarding.

### ART-ARCH-SCENE-005 — Rebuildability

Every gameplay view MUST be able to rebuild completely from a settled `GameState` plus presentation catalogs. This is required for load, restart, undo, skipped animation, debug replay, and recovery from interrupted presentation.

---

## 16. Required Folder Structure

### ART-ARCH-FOLDER-001

Use the following responsibility-based structure. Minor naming changes require an architecture task; mixing layers does not.

```text
res://
  app/
    bootstrap/
    scene_flow/
    config/

  domain/
    state/
    commands/
    rules/
      grid/
      ships/
      passengers/
      docks/
      boarding/
      end_conditions/
      advanced/
    resolution/
    events/
    serialization/

  application/
    game_session/
    undo/
    save/
    ads/
    analytics/
    ports/

  levels/
    schema/
    loader/
    validator/
    definitions/
    production_manifest/

  solver/
    search/
    hashing/
    difficulty/

  generator/

  presentation/
    gameplay/
      grid/
      ships/
      passengers/
      docks/
      coordination/
    screens/
    ui/
    tutorial/
    accessibility/

  infrastructure/
    save/
    ads/
    analytics/
    platform/

  audio/
  vfx/
  assets/
    art/
    audio/
    fonts/
    catalogs/

  tools/
    level_editor/
    validation/
    generation/

  tests/
    unit/
    integration/
    solver/
    levels/
    presentation/
    fixtures/
```

Generated/imported Godot metadata stays in engine-standard locations and MUST not be treated as domain source.

---

## 17. Test Architecture

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

### ART-ARCH-TEST-003 — Transition parity

For a corpus of level states and commands, runtime headless execution and solver execution MUST return equal canonical next states, equal acceptance/rejection, and equal ordered domain events.

### ART-ARCH-TEST-004 — Reproducibility

Every failing randomized/property test MUST print a reproducible seed and minimized state/command fixture. Hidden wall-clock randomness is forbidden.

### ART-ARCH-TEST-005 — Mobile verification

CI/build scripts and release checklists MUST verify Android and iOS export configuration. Device testing must measure frame rate, level load time, memory, scene transitions, background/resume, safe-area UI, audio settings, and ad/save failure paths on named reference devices once selected.

---

## 18. Performance Architecture

### ART-ARCH-PERF-002 — Runtime budgets

Performance work MUST target `ART-SPEC-PERF-*`: 60 FPS on selected mid-range devices, 100 passengers, 60 ships, and level load under 2 seconds. Budgets MUST be measured; claims without profiler/device evidence are not acceptance evidence.

### ART-ARCH-PERF-003 — Hot-path rules

Maintain a reproducible occupancy index for grid queries, avoid scene-tree traversal inside rules, avoid per-passenger Node creation during resolution, batch only when canonical ordering is preserved, reuse buffers where safe, and profile before introducing complex optimization.

### ART-ARCH-PERF-004 — Loading

Level data validation for production assets SHOULD be completed at build/content-validation time. Runtime still performs safe schema and invariant checks, then instantiates pooled/cached presentation assets asynchronously where Godot allows without violating scene-thread rules.

### ART-ARCH-PERF-005 — Main-thread boundary

Godot scene mutations remain on the main thread. Pure solver, generation, hashing, and validation MAY run on workers using immutable/deep-copied data. Worker results MUST be marshalled safely and MUST be cancellable when the screen/session closes.

---

## 19. Traceability Rules

### ART-ARCH-TRACE-001 — Code traceability

Every atomic implementation task MUST include:

- one or more `ART-SPEC-*` functional IDs;
- one or more `ART-ARCH-*` architecture IDs;
- files allowed to change;
- dependencies;
- acceptance criteria;
- tests/validation commands;
- expected evidence and failure report.

Code comments need not repeat IDs on every line. Tests and module documentation SHOULD cite the governing IDs at the scenario/module level.

### ART-ARCH-TRACE-002 — Primary mapping

| Architecture module | Governing functional IDs |
|---|---|
| `GameState`, invariants | `ART-SPEC-QA-001`, `ART-SPEC-QA-002`, all state-bearing rules |
| `GridState`, `GridQuery`, `PathValidator` | `ART-SPEC-SHIP-001..006`, `ART-SPEC-GRID-001..003` |
| `DockSystem` | `ART-SPEC-SHIP-007`, `ART-SPEC-DOCK-001..005` |
| `PassengerQueueRules` | `ART-SPEC-QUEUE-001..005` |
| `PreQueueRules` | `ART-SPEC-PREQ-001..005` |
| `BoardingResolver` | `ART-SPEC-BOARD-001..003` |
| `ResolutionSystem` | `ART-SPEC-RESOLVE-001..003` |
| `WinCondition` | `ART-SPEC-WIN-001` |
| `DeadlockDetector` | `ART-SPEC-LOSE-001..002` |
| `LevelDefinition/Loader/Validator` | `ART-SPEC-LEVEL-001..006`, `ART-SPEC-QUEUE-003` |
| `Solver/StateHasher` | `ART-SPEC-LEVEL-002`, `ART-SPEC-QA-001..002` |
| `LevelGenerator/DifficultyEvaluator` | `ART-SPEC-LEVEL-004..006` |
| `UndoService` | `ART-SPEC-ADV-005..006` |
| ad ports/reward grants | `ART-SPEC-ADS-001..005`, `ART-SPEC-DOCK-003..004` |
| save ports/adapters | `ART-SPEC-SAVE-001..003` |
| analytics ports/mapping | `ART-SPEC-AN-001..003` |
| presentation scenes/views | `ART-SPEC-UI-*`, `ART-SPEC-ART-*`, `ART-SPEC-AUDIO-*` |
| platform/performance | `ART-SPEC-PLAT-001`, `ART-SPEC-PERF-001..005` |

### ART-ARCH-TRACE-003 — Planned-feature rule

An atomic task for a planned feature MUST cite its planned spec ID and every resolved prerequisite. If the spec says part of the behavior is TBD, implementation MUST stop at the extension boundary and MUST NOT invent the missing behavior.

---

## 20. Required Implementation Order

### ART-ARCH-ORDER-001

Dependencies MUST be respected in this order when work is decomposed:

1. pinned Godot/language/tooling decision and test runner;
2. level value types, canonical state, serialization, invariants;
3. pure grid/ship/path rules;
4. dock, queue, prequeue, and boarding rules;
5. deterministic resolution and end conditions;
6. commands and `GameSession`;
7. headless tests and parity fixtures;
8. level loader/validator;
9. solver and hasher;
10. basic presentation and event playback;
11. save, settings, analytics ports;
12. tutorial/progression;
13. ads/reward ports and approved placements;
14. art/audio/VFX integration and mobile performance;
15. planned advanced mechanics, one independently specified system at a time;
16. generator/difficulty pipeline and production content scaling.

Presentation prototypes MAY be explored earlier, but they MUST not become an alternate authority for gameplay.

---

## 21. Architecture Acceptance Checklist

### ART-ARCH-ACCEPT-001

The architecture is correctly implemented only when all statements below are true:

- one canonical `GameState` represents complete logical play;
- runtime, tests, and solver execute the same commands and resolution rules;
- full-footprint path validation is pure and grid-based;
- standard release assignment is leftmost-empty;
- compatible boarding priority is right-to-left;
- main queue and prequeue rules preserve every passenger and logical order;
- resolution reaches a deterministic settled state and terminates;
- only `WinCondition` and `DeadlockDetector` determine terminal gameplay outcomes;
- input remains locked through required event presentation;
- views can rebuild from state and never own domain rules;
- level data is versioned, validated, and solver-gated;
- hashing includes all and only rule-relevant state;
- Undo restores a complete snapshot when enabled;
- save, ads, and analytics are replaceable ports with failure tests;
- advanced systems are gated and do not affect disabled levels;
- Android/iOS builds and measured device targets pass before release;
- every atomic task and acceptance test is traceable to both source documents.
