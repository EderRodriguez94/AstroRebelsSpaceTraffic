# Task: ART-TASK-003

### ART-SPEC-PLAT-001 — Engine and targets `[PRODUCT-REQUIRED]`

The project MUST use Godot 4.x. Primary release platforms are Android and iOS. Android is the first device-testing platform. Desktop MAY be used for development and tools but is not an initial commercial target.

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

## Source files
- C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic\docs\ASTRO_REBELS_TRAFFIC_MASTER_SPEC_EN.md - BA9E820719788E586D19EDB3D77E5CDE01C11AD99929399D433EABAFC70A18E5
- C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic\docs\ASTRO_REBELS_TRAFFIC_ARCHITECTURE_EN.md - 9C077B9DA8D404FE1394CA12B71B9C4706B93B47742F8FE189C08703180C6B3E
