# Android development export

The first device-test target is Android. The repository preset is development-only:

```powershell
& 'C:\Users\eorod\Desktop\Godot_v4.7.1-stable_mono_win64\Godot_v4.7.1-stable_mono_win64_console.exe' --headless --path 'C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic' --export-debug 'Android' 'build\android\AstroRebelsTraffic-debug.apk'
```

Package ID: `com.astrorebels.traffic`  
Orientation: portrait  
Architecture: ARM64  
Signing: Godot debug keystore only; no signing secret is stored in this repository.

Release signing and device selection remain pending Product Owner/platform decisions.
