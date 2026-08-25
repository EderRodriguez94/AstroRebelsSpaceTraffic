# Astro Rebels Traffic release checklist

## Scope for the first release

- Platform: Android only.
- Orientation: portrait.
- iOS: deferred; no iOS build or device evidence is claimed.
- APK/device execution: deferred until the final validation pass.
- Signing credentials: supplied outside the repository; never commit secrets.

## Android candidate checks

| Check | Evidence required | Status |
|---|---|---|
| Debug/release candidate builds | Export log and Git commit | Pending final APK pass |
| Level 1 launches | Device record and screenshot | Pending final APK pass |
| Touch and safe area | Galaxy A52, Pixel 6a and Tab A8 records | Pending final APK pass |
| Background/resume | Device reproduction record | Pending final APK pass |
| Independent audio settings | Device reproduction record | Pending final APK pass |
| Corrupted save recovery | Fixture and device record | Pending final APK pass |
| Stress fixture | 100 passengers / 60 ships report | Pending final APK pass |

The checklist deliberately records unverified items as pending. A release
cannot be declared complete until the final Android validation updates each
row with a dated device report.
