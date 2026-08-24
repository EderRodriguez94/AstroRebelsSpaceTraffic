# Task: ART-TASK-070

## References

- ART-SPEC-UI-001: application flow owns screen composition and keeps per-level state out of global singletons.
- ART-ARCH-SCENE-001/002/003: AppRoot is the composition root; screen transitions are explicit; gameplay uses portrait-safe layout.

## Files

- app/AppRoot.tscn
- app/AppBootstrap.gd
- app/ScreenHost.gd
- presentation/Screens/MainMenu.tscn
- presentation/Screens/LevelSelect.tscn
- presentation/Gameplay/GameplayScreen.tscn

## Evidence

AppRoot composes the four screens, ScreenHost exposes explicit screen selection, AppBootstrap starts at MainMenu, and GameplayScreen contains a portrait-safe MarginContainer. No autoload or global per-level GameSession was added.

Git commits and diffs are the repository traceability mechanism; file hashes are not used.
