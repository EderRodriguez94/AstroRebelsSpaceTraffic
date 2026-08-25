# VFX catalog

The event mapper uses lightweight procedural effects so no external or copied asset is required. Effects are presentation-only, skippable and cleared by `rebuild()`:

- `trail`: ship exit, 0.3 s
- `arrival_flash`: dock entry, 0.3 s
- `boarding_pulse`: grouped boarding, 0.25 s
- `propulsion`: departure, 0.7 s maximum
- `error_pulse`: invalid release
- `win_burst`: authoritative win event

All effects are driven by ordered domain-event names. `instant=true` skips the animation while preserving the same event order, and `skip()`/`rebuild()` clear active effects so no stale view survives. Settled domain state remains authoritative.
