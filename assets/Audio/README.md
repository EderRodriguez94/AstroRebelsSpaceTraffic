# Audio catalog

The catalog is intentionally placeholder-backed until licensed audio is supplied.
The runtime contract in `presentation/Audio/AudioCoordinator.cs` keeps music and SFX
volumes independent and resolves missing assets safely.

| Category | Event keys | Approved placeholder |
|---|---|---|
| Music | gameplay | `placeholder://music/gameplay` |
| SFX | tap, movement, error, dock, boarding, full, departure, victory, defeat | `placeholder://sfx/<event>` |

Licensed files must be added here with their source and license recorded before
replacing a placeholder. No domain rule depends on an audio file or engine node.
