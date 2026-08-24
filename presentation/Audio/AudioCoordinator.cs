using System;
using System.Collections.Generic;

namespace AstroRebelsTraffic.Presentation.Audio;

/// <summary>Safe, engine-independent routing contract for music and SFX.</summary>
public sealed class AudioCoordinator
{
    private readonly Dictionary<string, string> _sfx = new(StringComparer.OrdinalIgnoreCase)
    {
        ["tap"] = "placeholder://sfx/tap",
        ["movement"] = "placeholder://sfx/movement",
        ["error"] = "placeholder://sfx/error",
        ["dock"] = "placeholder://sfx/dock",
        ["boarding"] = "placeholder://sfx/boarding",
        ["full"] = "placeholder://sfx/full",
        ["departure"] = "placeholder://sfx/departure",
        ["victory"] = "placeholder://sfx/victory",
        ["defeat"] = "placeholder://sfx/defeat"
    };

    public float MusicVolume { get; private set; } = 1f;
    public float SfxVolume { get; private set; } = 1f;
    public string MusicTrack { get; private set; } = "placeholder://music/gameplay";

    public IReadOnlyDictionary<string, string> SoundEffects => _sfx;

    public void ApplySettings(float musicVolume, float sfxVolume)
    {
        MusicVolume = Clamp(musicVolume);
        SfxVolume = Clamp(sfxVolume);
    }

    public void SetMusicTrack(string? track)
    {
        MusicTrack = string.IsNullOrWhiteSpace(track) ? "placeholder://music/gameplay" : track;
    }

    public string ResolveSfx(string eventName) =>
        _sfx.TryGetValue(eventName, out var asset) ? asset : "placeholder://sfx/missing";

    private static float Clamp(float value) => Math.Clamp(value, 0f, 1f);
}
