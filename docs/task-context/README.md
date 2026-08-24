# Bounded task context extractor

`Build-TaskContext.ps1` extracts only the explicitly requested `ART-SPEC-*` and `ART-ARCH-*` requirement blocks. It accepts `TaskId`, `SpecIds`, `ArchIds`, `OutputPath`, `MaxChars` and optional `ExactFileList`.

Production command:

```powershell
powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId ART-SMOKE -SpecIds ART-SPEC-PLAT-001 -ArchIds ART-ARCH-GOV-004 -OutputPath docs\task-context\ART-SMOKE.md -MaxChars 24000
```

Without `ExactFileList`, the extractor reads the repository's two source-of-truth documents. With it, provide up to six literal file paths; wildcards are rejected. Missing or duplicate IDs, missing files, and output larger than `MaxChars` fail with a non-zero exit code and an explicit message. Source SHA-256 hashes are recorded in the output.

Run the parameterless self-test:

```powershell
powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Test-Build-TaskContext.ps1
```
