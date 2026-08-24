# Task: ART-TASK-076

## References
- ART-SPEC-UI-002 and ART-SPEC-UI-003.
- ART-ARCH-PRES-002.

## Files
- presentation/UI/Hud.gd
- presentation/UI/Hud.tscn
- presentation/Screens/SettingsScreen.tscn

## Evidence
HUD rebuilds from settled state, keeps restart available, and exposes optional controls only when both enabled and available. Settings has a dedicated screen; no booster state is synthesized by presentation.
