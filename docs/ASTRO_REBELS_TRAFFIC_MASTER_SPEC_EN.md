# Astro Rebels Traffic — Master Product and Game Specification

**Document ID:** `ART-SPEC`  
**Language:** English  
**Status:** Normative source of truth  
**Scope:** Complete product; not limited to an MVP  
**Intended reader:** A local implementation AI with limited reasoning ability

---

## 1. How to Use This Document

### ART-SPEC-GOV-001 — Normative terms

- **MUST / MUST NOT**: mandatory.
- **SHOULD / SHOULD NOT**: expected unless the Product Owner approves an exception.
- **MAY**: optional.
- **Core-required**: required for the first complete implementation of the central puzzle.
- **Planned/advanced**: part of the complete product direction, but not required to prove the core puzzle. It MUST NOT be silently implemented as a core rule.
- **TBD**: not decided. An implementation agent MUST ask for a Product Owner decision and MUST NOT invent the missing rule.

### ART-SPEC-GOV-002 — Authority and conflict resolution

1. This document defines product behavior and game rules.
2. `ASTRO_REBELS_TRAFFIC_ARCHITECTURE_EN.md` defines the required technical organization.
3. Atomic tasks define execution steps. They MUST cite IDs from both documents.
4. An atomic task MUST NOT override either source of truth.
5. If two statements appear to conflict, the more specific requirement applies.
6. If a real conflict remains, stop and request a Product Owner decision.

### ART-SPEC-GOV-003 — No inferred features

The implementation MUST NOT add mechanics, currencies, lives, purchases, scoring, obstacles, random outcomes, or monetization behavior that is not explicitly authorized here.

### ART-SPEC-GOV-004 — Scope labels

Every system below is labelled **CORE-REQUIRED**, **PRODUCT-REQUIRED**, or **PLANNED/ADVANCED**. “Planned” means the architecture must leave a clean extension point; it does not mean the feature is required in the first playable build.

---

## 2. Product Definition

### ART-SPEC-PROD-001 — Product identity `[PRODUCT-REQUIRED]`

The product name is **Astro Rebels Traffic**. It is a portrait-oriented mobile puzzle game with an original cartoon science-fiction presentation.

### ART-SPEC-PROD-002 — Original presentation `[PRODUCT-REQUIRED]`

The game MAY use the general connected-puzzle structure of traffic release plus color boarding, but it MUST use original names, UI, ships, characters, art, animation, audio, and fiction. It MUST NOT copy another game's protected presentation or assets.

### ART-SPEC-PROD-003 — Player objective `[CORE-REQUIRED]`

The player selects ships that can leave a directional traffic grid. A released ship waits in a limited dock. Passengers automatically board same-color ships. The player must choose a release order that clears every ship and every passenger without creating a real deadlock.

### ART-SPEC-PROD-004 — Core loop `[CORE-REQUIRED]`

The loop MUST be:

1. Inspect the ordered passenger demand and the traffic grid.
2. Select a ship.
3. Validate its complete exit path and dock availability.
4. If valid, release the ship and assign it to a dock.
5. Resolve boarding and full-ship departures automatically.
6. Resolve the circular prequeue automatically.
7. Evaluate win and real deadlock.
8. Return control only after resolution finishes.

---

## 3. Canonical Terms

### ART-SPEC-TERM-001

- **Grid:** a logical rectangular cell area that contains ships.
- **Zone:** one Grid in a level; advanced levels may contain more than one.
- **Ship:** a rigid, oriented, colored piece with a passenger capacity.
- **Main Queue:** ordered passenger groups not yet admitted to boarding/prequeue resolution.
- **Prequeue:** bounded circular waiting sequence for passengers that could not board.
- **Dock:** a waiting slot for one released ship.
- **Active Dock:** an unlocked dock currently usable in the level.
- **Compatible:** passenger and ship colors are equal.
- **Settled state:** no automatic rule can currently change the state.
- **Player move:** one accepted ship-release command. Invalid taps are not moves.
- **Resolution:** deterministic automatic transitions caused by an accepted command or system activation.

---

## 4. Ships and Traffic Grid

### ART-SPEC-SHIP-001 — Canonical sizes and capacities `[CORE-REQUIRED]`

| Ship size | Grid length | Passenger capacity |
|---|---:|---:|
| Small | 1 cell | 4 |
| Medium | 2 contiguous cells | 8 |
| Large | 3 contiguous cells | 16 |

No other core ship size or capacity is authorized.

### ART-SPEC-SHIP-002 — Orientation `[CORE-REQUIRED]`

Every ship MUST have exactly one exit direction: `UP`, `DOWN`, `LEFT`, or `RIGHT`. Its occupied cells MUST be aligned with its orientation. The ship MUST move only in its exit direction and MUST move as one rigid piece.

### ART-SPEC-SHIP-003 — Occupancy `[CORE-REQUIRED]`

Each grid cell MUST contain at most one ship footprint cell. A ship footprint MUST be completely inside its zone at level start. Ships MUST NOT overlap.

### ART-SPEC-SHIP-004 — Clear path `[CORE-REQUIRED]`

A path is clear only when the ship can translate from its current footprint to and beyond the applicable rectangular zone boundary without any occupied footprint cell intersecting another ship. Validation MUST consider the whole footprint on every translation step. Partial passage is forbidden. Core levels do not define static obstacles or non-traversable cells.

### ART-SPEC-SHIP-005 — Release prerequisites `[CORE-REQUIRED]`

A standard ship release is legal if and only if both conditions are true:

1. `ART-SPEC-SHIP-004` reports a clear path.
2. At least one standard active dock is empty.

If either condition is false, the ship MUST remain in the grid and the state MUST not otherwise change.

### ART-SPEC-SHIP-006 — Invalid release feedback `[PRODUCT-REQUIRED]`

An invalid tap MUST provide immediate non-destructive feedback. A blocked path SHOULD identify obstruction visually. A clear path with no empty active dock MUST show a “docks full” equivalent. Text may be localized; the logical failure reason MUST be distinct.

### ART-SPEC-SHIP-007 — Dock assignment `[CORE-REQUIRED]`

A successfully released standard ship MUST be assigned to the **leftmost empty standard active dock**. “Leftmost” is determined by the dock's fixed visual/logical index, from lowest index to highest. The player MUST NOT choose the destination standard dock.

### ART-SPEC-GRID-001 — Stable board footprint `[CORE-REQUIRED]`

The board's approximate visual footprint MUST remain stable across levels. Grid density MAY increase by increasing row/column counts while decreasing visual cell and ship scale. The logical rules MUST remain cell-based and MUST NOT depend on rendered pixel size.

### ART-SPEC-GRID-002 — Suggested density progression `[PRODUCT-REQUIRED]`

The intended progression is approximately `6×8` early, `8×10` mid, and `10×12` advanced. These are content guidelines, not hard engine limits. Expert dimensions are level-configurable.

### ART-SPEC-GRID-003 — No general physics dependency `[CORE-REQUIRED]`

Traffic validity MUST be determined by grid rules, not by a general-purpose physics simulation.

---

## 5. Standard Docks and Emergency Docks

### ART-SPEC-DOCK-001 — Dock inventory `[CORE-REQUIRED]`

Every normal level MUST expose eight standard dock positions in one horizontal row:

- Four base docks are active at level start.
- Four rewarded docks are visible but locked at level start.
- Base dock count MUST remain four as a learnable constant; ordinary difficulty MUST NOT be created by reducing it.

### ART-SPEC-DOCK-002 — One ship per dock `[CORE-REQUIRED]`

Each dock holds zero or one ship. A dock ship retains its fixed color, total capacity, and current passenger count.

### ART-SPEC-DOCK-003 — Reward unlock behavior `[PRODUCT-REQUIRED]`

One completed rewarded video unlocks exactly one additional standard dock for the current level. Rewarded docks unlock one at a time, to a maximum of four additional docks. An unlock is temporary and MUST end when the level attempt ends.

### ART-SPEC-DOCK-004 — Availability and loss `[CORE-REQUIRED]`

A locked rewarded dock is not active and MUST NOT prevent deadlock detection. The possibility of watching a future ad MUST NOT make an otherwise deadlocked state count as playable.

### ART-SPEC-DOCK-005 — Full departure `[CORE-REQUIRED]`

When a dock ship's passenger count equals its capacity, that ship MUST depart automatically during resolution and its dock MUST become empty. A ship MUST NOT depart partially filled under core rules.

---

## 6. Passenger Main Queue

### ART-SPEC-QUEUE-001 — Ordered groups `[CORE-REQUIRED]`

The main queue MUST be an ordered sequence of passenger groups. Each group has exactly one color and a size of exactly `4`, `8`, or `16`. Groups of the same color MAY appear at multiple non-adjacent positions.

### ART-SPEC-QUEUE-002 — No free passenger selection `[CORE-REQUIRED]`

The player MUST NOT select or reorder individual passengers. Only the front main-queue group is eligible for admission from the main queue.

### ART-SPEC-QUEUE-003 — Color conservation `[CORE-REQUIRED]`

For every color in a production level, the total number of passengers MUST equal the total capacity of all ships of that color across every enabled ship source, including reserves when enabled. Level validation MUST reject a mismatch.

### ART-SPEC-QUEUE-004 — Group splitting `[CORE-REQUIRED]`

A group MAY split across multiple compatible dock ships. It MUST board compatible ships using `ART-SPEC-BOARD-002`. Examples:

- 8 passengers may fill one 8-capacity ship or two 4-capacity ships.
- 16 passengers may fill one 16-capacity ship, two 8-capacity ships, four 4-capacity ships, or another exact same-color combination.

No passenger may board an incompatible ship.

### ART-SPEC-QUEUE-005 — Atomic front-group admission `[CORE-REQUIRED]`

Before removing the front group from the main queue, the resolver MUST calculate how many members can board immediately and how many would remain. The group may be admitted only if the complete remainder fits in the prequeue. If it does not fit, the group MUST remain unchanged at the front and no member of that group may board in that attempt. This prevents passenger loss and partial untracked groups.

---

## 7. Circular Prequeue

### ART-SPEC-PREQ-001 — Purpose and capacity `[CORE-REQUIRED]`

Passengers admitted from the main queue who cannot board immediately MUST enter a bounded circular prequeue. Capacity is counted in individual passengers, is configurable per level, and defaults to `16`.

### ART-SPEC-PREQ-002 — Logical order `[CORE-REQUIRED]`

The prequeue MUST preserve logical arrival order. Circular presentation MUST NOT reorder its logical sequence. Removing boardable passengers MUST preserve the relative order of every passenger that remains.

### ART-SPEC-PREQ-003 — Deterministic circular scan `[CORE-REQUIRED]`

During a prequeue pass, inspect passengers once in logical arrival order. A passenger boards if compatible dock capacity exists at the instant it is inspected; otherwise it remains. The resolver MUST NOT repeatedly skip ahead forever in the same pass. Another pass may occur only after a state-changing boarding/departure/admission transition.

### ART-SPEC-PREQ-004 — Full prequeue `[CORE-REQUIRED]`

A full prequeue is not an immediate loss. It prevents admission of a main-queue group whose calculated remainder would not fit. Automatic boarding and other legal moves may still create space.

### ART-SPEC-PREQ-005 — Reevaluation triggers `[CORE-REQUIRED]`

The prequeue MUST be reevaluated during deterministic resolution whenever a ship arrives, compatible capacity changes, boarding occurs, or a full ship departs.

---

## 8. Boarding and Automatic Resolution

### ART-SPEC-BOARD-001 — Automatic boarding `[CORE-REQUIRED]`

Boarding MUST be automatic. The player MUST NOT drag passengers or manually choose a ship.

### ART-SPEC-BOARD-002 — Right-to-left compatible priority `[CORE-REQUIRED]`

When more than one dock ship can accept a passenger of the same color, the resolver MUST fill the **rightmost compatible ship first**, then continue toward the left. “Rightmost” means the highest fixed dock index. This rule supersedes the earlier discarded left-first boarding proposal.

### ART-SPEC-BOARD-003 — Capacity boundary `[CORE-REQUIRED]`

A ship MUST never receive more passengers than its capacity. Boarding consumes passengers one logical unit at a time or as an equivalent deterministic batch with exactly the same outcome.

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

### ART-SPEC-RESOLVE-002 — Input lock `[CORE-REQUIRED]`

From acceptance of a state-changing command until its resolution and required presentation complete, ship-selection input MUST be locked. Additional taps MUST NOT queue another move. Restart and application-level safety controls MAY use a separately defined confirmation flow.

### ART-SPEC-RESOLVE-003 — Fast presentation `[PRODUCT-REQUIRED]`

Resolution presentation MUST be short and must not artificially delay control after logical settlement. Animation timing targets are defined by `ART-SPEC-ART-009`.

---

## 9. Exact End Conditions

### ART-SPEC-WIN-001 — Exact win condition `[CORE-REQUIRED]`

A level is won if and only if, after automatic resolution:

1. every enabled traffic grid/zone is empty;
2. every active or occupied dock, including an enabled VIP dock, is empty;
3. the main passenger queue is empty;
4. the circular prequeue is empty; and
5. when Reserve/Hangar is enabled, its ship supply is empty.

The check MUST occur only after automatic boarding and departures reach a settled state.

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

## 10. Level Rules and Difficulty

### ART-SPEC-LEVEL-001 — Data-driven levels `[PRODUCT-REQUIRED]`

Every level MUST be loadable from a versioned data definition. At minimum it defines: `level_id`, schema version, grid zones and dimensions, ships, standard dock configuration, prequeue capacity, passenger groups, enabled mechanics, content/difficulty metadata, and any reserve data.

### ART-SPEC-LEVEL-002 — Production solvability `[PRODUCT-REQUIRED]`

Every production level MUST have at least one valid solution without ads, rewarded docks, boosters, purchases, or other paid/rewarded assistance. A level that fails solver validation MUST be rejected.

### ART-SPEC-LEVEL-003 — Color progression `[PRODUCT-REQUIRED]`

Initial colors are `Red`, `Blue`, `Green`, and `Yellow`. Later content MAY introduce `Purple`, `Orange`, `Cyan`, and `Pink`. Colors MUST be introduced progressively; number of simultaneous colors is a difficulty variable.

### ART-SPEC-LEVEL-004 — Difficulty dimensions `[PRODUCT-REQUIRED]`

Difficulty MAY increase through more ships, more colors, denser grids, fewer direct exit paths, more Medium/Large ships, passenger groups requiring capacity combinations, smaller prequeue capacity, and enabled advanced mechanics. Difficulty MUST NOT rely only on reducing available docks; the four base docks remain constant.

### ART-SPEC-LEVEL-005 — Difficulty evidence `[PRODUCT-REQUIRED]`

Difficulty metadata SHOULD be based on solver and playtest evidence, including solution length, branching, deadlock exposure, and mechanic complexity. A hand-entered label alone is insufficient for production calibration.

### ART-SPEC-LEVEL-006 — Content generation `[PLANNED/ADVANCED]`

Generated levels MUST follow `Generate → Validate → Solve → Score → Filter → Human Review`. A generator MUST NOT publish directly to production. The solver, not a generative AI, decides whether the level is mechanically valid and solvable.

---

## 11. Advanced Puzzle Systems

These systems are part of the complete product direction but are not core-required unless a level explicitly enables them.

### ART-SPEC-ADV-001 — Mystery Ships `[PLANNED/ADVANCED]`

- A Mystery Ship has a predefined hidden color; its size, footprint, and direction remain visible.
- It occupies and blocks grid cells normally.
- Its color MUST be deterministic level data, never chosen randomly after the player commits.
- It reveals when its exit path becomes clear, or when the player selects it while its path is clear.
- Scanner may reveal it earlier.
- Once revealed, it remains revealed for that attempt.

### ART-SPEC-ADV-002 — Reserve/Hangar `[PLANNED/ADVANCED]`

- A level may define an off-grid ordered ship supply.
- A reserve-entry check occurs automatically after a grid ship leaves. A level defines the designated zone, entry cells, and how many reserve ships may enter per release. A ship enters only when its required entry cells are clear.
- The player MUST know at least a configured visible prefix of the order.
- Exact entry locations, visible-prefix size, and trigger data MUST be defined by each level.
- Reserve ships count toward color-capacity conservation and completion.

### ART-SPEC-ADV-003 — Multi-zone grid `[PLANNED/ADVANCED]`

- A level may contain multiple independent traffic zones.
- All zones share the same main queue, prequeue, and docks.
- A ship exits through its own zone boundary.
- The player may choose a legal ship from any zone while input is enabled.

### ART-SPEC-ADV-004 — VIP Dock `[PLANNED/ADVANCED]`

- The VIP Dock is one special rescue slot outside the eight standard docks.
- It is initially inactive.
- A booster or rewarded flow may activate it for the current attempt.
- It holds one ship and does not change that ship's color or matching rules.
- Activating it supplies space only; it is not a universal-color boarding rule.
- Exact routing into the VIP Dock is TBD and MUST be approved before implementation. Until then, standard releases use only `ART-SPEC-SHIP-007`.

### ART-SPEC-ADV-005 — Initial boosters `[PLANNED/ADVANCED]`

The planned initial booster set is:

- **Extra Dock:** activates one temporary eligible dock under the same unlock limit.
- **Undo:** restores the complete state before the previous accepted player move.
- **Scanner:** reveals Mystery Ships without changing their predefined colors.

Shuffle and Emergency Launch are deferred and MUST NOT be implemented without new rules.

### ART-SPEC-ADV-006 — Undo state `[PLANNED/ADVANCED]`

Undo MUST restore the full pre-move logical state, including grids, ship positions and revealed state, docks, ship passenger counts, main queue, prequeue and its logical order, active temporary docks, reserve state, booster consumption state relevant to the move, move counters, and deterministic random state if one is ever authorized.

---

## 12. Tutorial and Progression

### ART-SPEC-TUT-001 — Integrated tutorial `[PRODUCT-REQUIRED]`

Tutorial teaching MUST occur inside early playable levels, not only in a separate instructions page. Prompts MUST constrain or clearly direct the intended action when required.

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

### ART-SPEC-PROG-001 — Base progression `[PRODUCT-REQUIRED]`

Progression is initially a linear ordered sequence of levels. Completion unlocks the next level. Worlds/planets MAY later group levels visually, with each world introducing or emphasizing a mechanic.

### ART-SPEC-PROG-002 — Scoring and lives `[PLANNED/ADVANCED]`

The core game MUST NOT require a numeric score or lives system. Stars, time targets, error counts, booster-use ratings, and lives are deferred. They require explicit economy and progression specifications before implementation.

### ART-SPEC-PROG-003 — Economy and rewards `[PLANNED/ADVANCED]`

Currencies, purchases, daily rewards, live events, and LiveOps are not yet defined. The implementation MUST provide extension boundaries but MUST NOT invent values, reward tables, store products, or event rules.

---

## 13. Monetization and Ads

### ART-SPEC-ADS-001 — Rewarded uses `[PRODUCT-REQUIRED]`

Rewarded ads MAY be offered for one emergency dock, post-loss recovery, or an explicitly defined booster. Watching is optional. Core level solvability MUST never depend on it.

### ART-SPEC-ADS-002 — Emergency dock offer `[PRODUCT-REQUIRED]`

An offer SHOULD appear near a deadlock or after a loss and MUST unlock only one dock per completed reward. At most four rewarded standard docks may be unlocked in one attempt.

### ART-SPEC-ADS-003 — Interstitial placement `[PRODUCT-REQUIRED]`

Interstitial ads MAY appear only between levels or attempts, under remotely/configurably controlled frequency. They MUST NOT appear during a puzzle move, automatic resolution, tutorial instruction, or immediately before required player input.

### ART-SPEC-ADS-004 — Failure behavior `[PRODUCT-REQUIRED]`

If an ad is unavailable, cancelled, or fails, no reward is granted and the game state MUST remain valid. Gameplay code MUST not depend directly on a specific ad SDK.

### ART-SPEC-ADS-005 — Consent and platform policy `[PRODUCT-REQUIRED]`

Ad, consent, privacy, and tracking behavior MUST comply with the current store and regional requirements at release time. Exact SDKs and consent providers are TBD.

---

## 14. Save, Analytics, and Privacy

### ART-SPEC-SAVE-001 — Persistent data `[PRODUCT-REQUIRED]`

The game MUST persist at least settings, highest unlocked level, completed levels, tutorial progress, and granted/owned booster data once boosters exist. It SHOULD persist a resumable attempt only after that feature is explicitly enabled.

### ART-SPEC-SAVE-002 — Safe save behavior `[PRODUCT-REQUIRED]`

Save data MUST be versioned, validated, written atomically, and recover safely from corruption without crashing. Migration rules are required before changing a released schema.

### ART-SPEC-SAVE-003 — Attempt scope `[PRODUCT-REQUIRED]`

Temporary rewarded docks and attempt-local rescue state MUST NOT persist into a new level attempt. A suspended-attempt feature, if enabled later, must preserve them only inside that exact attempt.

### ART-SPEC-AN-001 — Required event categories `[PRODUCT-REQUIRED]`

Analytics SHOULD cover: app/session start, level start, accepted move, invalid release reason, level win, real-deadlock loss, restart, undo, booster use, rewarded offer/result/reward, interstitial impression, tutorial step, level load/validation failure, and performance health.

### ART-SPEC-AN-002 — Event properties `[PRODUCT-REQUIRED]`

Gameplay events SHOULD include schema version, level ID, attempt ID, move index, enabled mechanics, dock occupancy, queue/prequeue counts, and non-identifying outcome metadata where relevant.

### ART-SPEC-AN-003 — Privacy `[PRODUCT-REQUIRED]`

Analytics MUST NOT include passenger/ship state dumps, device identifiers, or personal data unless specifically required, consented, documented, and policy-compliant. Gameplay correctness MUST not depend on analytics availability.

---

## 15. UI and Accessibility

### ART-SPEC-UI-001 — Portrait layout `[PRODUCT-REQUIRED]`

The gameplay screen MUST be portrait. The intended top-to-bottom hierarchy is:

1. level/progression header;
2. passenger main queue;
3. circular prequeue;
4. horizontal docks;
5. traffic grid;
6. booster area.

Responsive spacing MAY adapt, but the relationships and legibility MUST remain.

### ART-SPEC-UI-002 — Required controls `[PRODUCT-REQUIRED]`

Restart MUST be accessible. Settings MUST expose separate music and SFX controls. Undo, Scanner, Extra Dock, VIP, and rewarded controls MUST appear only when the corresponding system is enabled and available.

### ART-SPEC-UI-003 — Low-text gameplay `[PRODUCT-REQUIRED]`

Gameplay SHOULD minimize text and prioritize clear icons, silhouettes, animation, and localized short labels. Critical feedback MUST remain understandable.

### ART-SPEC-UI-004 — Color accessibility `[PRODUCT-REQUIRED]`

Color MUST NOT be the only matching cue. Every passenger faction/color and corresponding ship MUST also use a consistent symbol, pattern, or emblem with sufficient contrast.

### ART-SPEC-UI-005 — State clarity `[PRODUCT-REQUIRED]`

The UI MUST clearly distinguish active, empty, occupied, locked, rewarded, and VIP dock states; ship direction; Mystery state; selection lock; win; and real-deadlock loss.

---

## 16. Art, Animation, VFX, and Audio

### ART-SPEC-ART-001 — Art direction `[PRODUCT-REQUIRED]`

Use a clean, colorful, cartoon science-fiction style optimized for mobile readability. Puzzle readability has priority over visual detail. Backgrounds MUST not compete with the board.

### ART-SPEC-ART-002 — Ship silhouettes `[PRODUCT-REQUIRED]`

Small, Medium, and Large ships MUST be distinguishable by silhouette as well as scale. Orientation MUST be visually obvious.

### ART-SPEC-ART-003 — Passenger design `[PRODUCT-REQUIRED]`

Passengers are simple rebel crew characters with reusable visual variants. Their suit/helmet color and faction symbol MUST communicate matching identity.

### ART-SPEC-ART-004 — Direction cues `[PRODUCT-REQUIRED]`

Ship direction MUST combine physical orientation with a subtle holographic arrow and/or propulsion/guide effect. An arrow alone MUST NOT be the only direction cue.

### ART-SPEC-ART-005 — Dock presentation `[PRODUCT-REQUIRED]`

Docks form one horizontal row between passenger systems and the grid. Four base positions and four locked rewarded positions MUST be visually understandable. Boarding priority MUST not be implied incorrectly; compatible boarding proceeds right-to-left.

### ART-SPEC-ART-006 — Required VFX `[PRODUCT-REQUIRED]`

Provide ship trail, dock arrival flash, boarding color pulse, departure propulsion, blocked/error feedback, and a light win celebration. VFX MUST not obscure puzzle state.

### ART-SPEC-ART-007 — Asset originality and validation `[PRODUCT-REQUIRED]`

Every external/generated asset MUST pass license, style, scale, pivot, material, performance, and in-game readability validation before integration.

### ART-SPEC-ART-008 — 3D pipeline `[PLANNED/ADVANCED]`

The intended pipeline is Tripo for base generation, Blender for cleanup/optimization/materials/pivots/scale/export, and UniRig only for passengers that need rigs. Ships do not require complex rigs. Tool substitutions require equivalent validation.

### ART-SPEC-ART-009 — Animation timing `[PRODUCT-REQUIRED]`

- grid exit: approximately `0.2–0.4 s`;
- dock entry: approximately `0.2–0.4 s`;
- boarding: accelerated/grouped presentation;
- full departure: satisfying but no more than approximately `0.7 s`.

Timings MAY be tuned, but MUST remain fast and MUST not change logical results.

### ART-SPEC-AUDIO-001 — Music and SFX `[PRODUCT-REQUIRED]`

Use casual ambient sci-fi music. Required SFX categories are tap, movement, error, dock arrival, boarding, ship full, departure, victory, and defeat. Music and SFX MUST have separate mute/volume settings.

---

## 17. Platforms and Performance

### ART-SPEC-PLAT-001 — Engine and targets `[PRODUCT-REQUIRED]`

The project MUST use Godot 4.x. Primary release platforms are Android and iOS. Android is the first device-testing platform. Desktop MAY be used for development and tools but is not an initial commercial target.

### ART-SPEC-PERF-001 — Frame target `[PRODUCT-REQUIRED]`

Gameplay MUST target 60 FPS on the defined mid-range reference Android and iOS devices. Reference device models remain TBD and MUST be selected before performance sign-off.

### ART-SPEC-PERF-002 — Content scale `[PRODUCT-REQUIRED]`

The runtime MUST support at least 100 visible/logical passengers and 60 ships in advanced levels without rule degradation.

### ART-SPEC-PERF-003 — Load time `[PRODUCT-REQUIRED]`

A gameplay level SHOULD load in less than 2 seconds on the reference target device after required shared content is available.

### ART-SPEC-PERF-004 — Rendering and allocation `[PRODUCT-REQUIRED]`

Use shared materials, pooling for passenger presentation and effects, bounded transient allocations, and no general physics simulation for puzzle rules.

### ART-SPEC-PERF-005 — Solver isolation `[PRODUCT-REQUIRED]`

Solver or generation work MUST never block the gameplay main thread. Production gameplay MUST not require an online solver call.

---

## 18. Quality and Acceptance

### ART-SPEC-QA-001 — Determinism `[CORE-REQUIRED]`

Given the same level definition, state, and command, gameplay MUST produce the same next settled state and ordered domain events.

### ART-SPEC-QA-002 — Shared rules `[CORE-REQUIRED]`

Runtime, automated tests, solver, level validator, replay, and generator evaluation MUST use the same canonical state and rules. Duplicate alternate gameplay logic is forbidden.

### ART-SPEC-QA-003 — Required rule coverage `[PRODUCT-REQUIRED]`

Automated tests MUST cover ship footprints and all four directions, release rejection reasons, leftmost dock assignment, right-to-left boarding, group splits, prequeue order/capacity, cascading departures, exact win, exact deadlock, input gating, undo restoration, level validation, and deterministic serialization/hashing.

### ART-SPEC-QA-004 — Release gates `[PRODUCT-REQUIRED]`

A release candidate is not complete until relevant automated tests pass, representative levels validate and solve, Android/iOS builds succeed, device performance is measured, and save/ad failure paths have been tested where those systems are enabled.

---

## 19. Explicit Non-Rules and Open Decisions

### ART-SPEC-OPEN-001

The following are not authorized core rules: free grid movement, rotating ships, partial ship departure, universal-color VIP boarding, random Mystery colors after selection, infinite prequeue, prequeue-full instant loss, dock-full instant loss, ads required for solvability, or manual passenger dragging.

### ART-SPEC-OPEN-002

The following require future Product Owner decisions: VIP routing, currencies/economy, in-app purchase catalog, lives, star/scoring formula, LiveOps, exact post-loss recovery state, ad SDK/provider, consent provider, cloud save, suspend/resume of active attempts, reference devices, final Godot minor version, and implementation language.

---

## 20. Functional-to-Architecture Traceability

| Functional IDs | Primary architecture IDs |
|---|---|
| `ART-SPEC-SHIP-*`, `ART-SPEC-GRID-*` | `ART-ARCH-STATE-003`, `ART-ARCH-GRID-*`, `ART-ARCH-CMD-002` |
| `ART-SPEC-DOCK-*` | `ART-ARCH-STATE-005`, `ART-ARCH-DOCK-*` |
| `ART-SPEC-QUEUE-*`, `ART-SPEC-PREQ-*` | `ART-ARCH-STATE-004`, `ART-ARCH-QUEUE-*` |
| `ART-SPEC-BOARD-*`, `ART-SPEC-RESOLVE-*` | `ART-ARCH-BOARD-*`, `ART-ARCH-RES-*`, `ART-ARCH-EVENT-*` |
| `ART-SPEC-WIN-*`, `ART-SPEC-LOSE-*` | `ART-ARCH-END-*` |
| `ART-SPEC-LEVEL-*` | `ART-ARCH-LEVEL-*`, `ART-ARCH-SOLVER-*` |
| `ART-SPEC-ADV-*` | `ART-ARCH-ADV-*`, `ART-ARCH-UNDO-*` |
| `ART-SPEC-ADS-*` | `ART-ARCH-ADS-*` |
| `ART-SPEC-SAVE-*` | `ART-ARCH-SAVE-*` |
| `ART-SPEC-AN-*` | `ART-ARCH-AN-*` |
| `ART-SPEC-UI-*`, `ART-SPEC-ART-*`, `ART-SPEC-AUDIO-*` | `ART-ARCH-PRES-*`, `ART-ARCH-SCENE-*` |
| `ART-SPEC-PERF-*`, `ART-SPEC-QA-*` | `ART-ARCH-PERF-*`, `ART-ARCH-TEST-*` |

---

## 21. Definition of Product-Spec Compliance

An implementation is compliant only when:

1. every implemented rule cites at least one `ART-SPEC-*` ID;
2. no implementation changes a normative outcome;
3. planned systems remain disabled unless their prerequisite decisions and atomic tasks exist;
4. all production levels pass the shared validator and solver without assistance;
5. exact win and real-deadlock behavior match this document; and
6. tests, runtime, and solver demonstrate identical deterministic results.
