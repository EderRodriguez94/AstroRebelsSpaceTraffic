# Android performance baseline

## Reference device matrix

The first release targets Android only. The matrix deliberately covers an older
supported device, a current mid-range phone, and a tablet:

| Role | Device | Android target | Minimum acceptance |
|---|---|---:|---|
| Legacy phone | Samsung Galaxy A52 (SM-A525F) | Android 11 | Launches, touch works, 30 FPS floor |
| Reference phone | Google Pixel 6a | Android 14 | 60 FPS target, load under 2 s |
| Current phone | Google Pixel 9a | Android 15 | 60 FPS target, load under 2 s |
| Tablet | Samsung Galaxy Tab A8 10.5 (SM-X200) | Android 13 | Portrait safe area, touch works, 30 FPS floor |

The project export preset uses portrait orientation, ARM64, min SDK 23 and target
SDK 35. Devices below Android 6.0/API 23 are out of scope. Android 8–15 is the
compatibility range for this release matrix; exact OS versions must be recorded
from the device before each run.

## Measurement procedure

Use the same debug APK, cold launch, fresh process, and level 1 fixture. Record
device model, OS build, APK commit, average/minimum FPS during 60 seconds of
gameplay, peak memory, and time from launch to the first interactive frame.
Capture one profiler screenshot or `adb shell dumpsys meminfo` output per device
under `performance/reports/YYYY-MM-DD/`.

No device measurements are claimed until the APK has been installed and run on
each named device. iOS is intentionally excluded from this release baseline.
