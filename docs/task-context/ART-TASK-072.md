# Task: ART-TASK-072

## References
- ART-SPEC-UI-001 and ART-SPEC-ART-005.
- ART-ARCH-PRES-002 and ART-ARCH-PRES-003.

## Files
- presentation/gameplay/QueueView.gd
- presentation/gameplay/DockView.gd
- presentation/gameplay/GameplayScreen.tscn

## Evidence
QueueView and DockView are presentation-only rebuild points. QueueView receives logical passenger groups, DockView receives logical dock slots, and GameplayScreen owns composition without applying domain rules.

## Versioning
Git commit history is the integrity and change-trace mechanism for this task; file hashes are not used.
