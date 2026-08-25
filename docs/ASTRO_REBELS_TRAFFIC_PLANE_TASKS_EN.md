# Astro Rebels Traffic - Plane Task Backlog

This document is a deterministic export of the live Plane backlog. Plane remains authoritative for current state and dependency execution.

- Exported at: 2026-08-23T17:36:28Z
- Plane project ID: `fe63be51-31de-4d6b-90a3-2b2988fe1c84`
- External source: `astro-rebels-traffic-backlog-v1`
- Total tasks: 218
- Plane URL: http://localhost:8080/tikal1/projects/fe63be51-31de-4d6b-90a3-2b2988fe1c84/issues/

## State summary

| State | Count |
|---|---:|
| Backlog | 217 |
| Done | 1 |

## Executor summary

| Executor | Count |
|---|---:|
| `agent:alfredo` | 111 |
| `agent:bruno` | 5 |
| `agent:lucia` | 7 |
| `agent:nicolas` | 49 |
| `agent:paula` | 3 |
| `agent:pedro` | 8 |
| `agent:ricardo` | 5 |
| `agent:sofia` | 30 |

## Tasks

## ART-TASK-000 - Bounded-context extractor - integration gate

- Plane work item ID: `42a4d6a1-5a69-48f5-a138-f19bf0d77fea`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:tooling`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 85

### Objective

Close ART-TASK-000 only after P1, P2 and VAL are Done. This gate performs no implementation.

### Executor

agent:alfredo

### 32K context contract

- Risk class: gate
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-000-VAL

### SPEC references

- ART-SPEC-GOV-002

### Architecture references

- ART-ARCH-TRACE-001

### Allowed files

- docs/task-context/README.md

### Exact instructions

1. Confirm ART-TASK-000-P1, ART-TASK-000-P2 and ART-TASK-000-VAL are Done.

2. Close this gate without editing files or rerunning commands.

### Commands

None.

### Validation

- Plane shows the three atomic subtasks Done.
- The VAL report contains both successful command exit codes and the smoke character count.

### Acceptance criteria

- Every later CTX task remains blocked until the extractor is independently validated.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-000-P1 - Repair and implement the bounded-context extractor only

- Plane work item ID: `b05ee1d1-b747-4a93-ac6d-c859f4a6465e`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:tooling`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 216

### Objective

Produce one syntax-valid extractor script. Do not create its test harness or documentation in this phase.

### Executor

agent:alfredo

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-001

### SPEC references

- ART-SPEC-GOV-002

### Architecture references

- ART-ARCH-TRACE-001

### Allowed files

- tools/Context/Build-TaskContext.ps1

### Exact instructions

1. Inspect only tools/Context/Build-TaskContext.ps1 and the exact parser errors already reported in Plane.

2. Implement the declared TaskId, SpecIds, ArchIds, OutputPath, MaxChars and optional exact-file-list parameters.

3. Extract exact unique requirement blocks programmatically; reject missing IDs, duplicate IDs, wildcards, more than six exact files and oversized output.

4. Write UTF-8 output with source hashes and character count without printing either full source document.

### Commands

- powershell -NoProfile -Command "$tokens=$null;$errors=$null;[System.Management.Automation.Language.Parser]::ParseFile('tools\Context\Build-TaskContext.ps1',[ref]$tokens,[ref]$errors)|Out-Null;if($errors.Count){$errors|ForEach-Object{$_.Message};exit 1}"

### Validation

- Windows PowerShell 5.1 parser exits 0.
- Only tools/Context/Build-TaskContext.ps1 is changed.

### Acceptance criteria

- The extractor has a stable non-interactive parameter contract.
- All declared refusal conditions are implemented in one file.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-000-P2 - Create extractor self-test and operator README only

- Plane work item ID: `f325e6b7-5ec1-43c4-8630-980713cbe5da`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:test`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 217

### Objective

Add a parameterless deterministic self-test and concise usage documentation without editing the extractor.

### Executor

agent:alfredo

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-000-P1

### SPEC references

- ART-SPEC-GOV-002

### Architecture references

- ART-ARCH-TRACE-001

### Allowed files

- tools/Context/Test-Build-TaskContext.ps1
- docs/task-context/README.md

### Exact instructions

1. Create a parameterless test script; it must not declare mandatory caller parameters.

2. Generate isolated temporary SPEC and ARCH fixtures inside the test process.

3. Test success, missing ID, duplicate ID and MaxChars failure and clean temporary data in finally.

4. Document the exact production command, limits and failure meanings in README.md.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Test-Build-TaskContext.ps1

### Validation

- The self-test command accepts no arguments, exits 0 and reports four passing cases.
- The extractor file is not modified in this phase.

### Acceptance criteria

- Tests are self-contained and do not depend on the production documents.
- README examples match the extractor parameter names exactly.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-000-VAL - Validate bounded-context extractor end to end

- Plane work item ID: `21848e6d-1b43-4e66-a2ce-78ef1737f364`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:test`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 218

### Objective

Validate the completed extractor without implementing or repairing it. Report a literal failure if any check fails.

### Executor

agent:alfredo

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-000-P2

### SPEC references

- ART-SPEC-GOV-002

### Architecture references

- ART-ARCH-TRACE-001

### Allowed files

- tools/Context/Build-TaskContext.ps1
- tools/Context/Test-Build-TaskContext.ps1
- docs/task-context/README.md
- docs/task-context/ART-SMOKE.md

### Exact instructions

1. Run the parameterless self-test exactly once.

2. Run the production smoke command for only ART-SPEC-PLAT-001 and ART-ARCH-GOV-004.

3. Verify ART-SMOKE.md is at most 24,000 characters and does not contain unrelated requirement IDs.

4. Report command, exit code, output character count and requested IDs.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Test-Build-TaskContext.ps1
- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId ART-SMOKE -SpecIds ART-SPEC-PLAT-001 -ArchIds ART-ARCH-GOV-004 -OutputPath docs\task-context\ART-SMOKE.md -MaxChars 24000

### Validation

- Both commands exit 0.
- Self-test reports all four cases passed.
- Smoke output contains exactly the two requested normative blocks and stays within 24,000 characters.

### Acceptance criteria

- Evidence is sufficient to close ART-TASK-000.
- No source, test or documentation file is edited during validation.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-001 - Approve and record the technical baseline

- Plane work item ID: `90bb39eb-9472-4695-aa3e-261a57230f51`
- State: **Done**
- Priority: **urgent**
- Executor: `agent:pedro`
- Type: `type:decision`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 1



---

## ART-TASK-002 - Install the two source-of-truth documents in the game repository â integration gate

- Plane work item ID: `a2f769bf-1cd7-43c6-b73a-0d8d6f2faefa`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:pedro`
- Type: `type:tooling`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 2



---

## ART-TASK-002-CTX - Build bounded context pack for ART-TASK-002

- Plane work item ID: `6e26d7cf-1950-4c43-a94d-1f7ec92a1f72`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:pedro`
- Type: `type:tooling`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 116

### Objective

Create the only normative and repository context that ART-TASK-002 may consume.

### Executor

agent:pedro

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-001
- ART-TASK-000

### SPEC references

- ART-SPEC-GOV-002

### Architecture references

- ART-ARCH-TRACE-001

### Allowed files

- docs/task-context/ART-TASK-002.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-GOV-002] and ARCH IDs [ART-ARCH-TRACE-001].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-002' -SpecIds 'ART-SPEC-GOV-002' -ArchIds 'ART-ARCH-TRACE-001' -OutputPath 'docs/task-context/ART-TASK-002.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-002.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-002 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-002-P1 - Install the two source-of-truth documents in the game repository â atomic implementation phase 1

- Plane work item ID: `46b695c1-76b6-466b-9072-aecf51e2aa80`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:pedro`
- Type: `type:tooling`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 117

### Objective

Perform only the first bounded half of ART-TASK-002; do not execute final validation or the remaining steps.

### Executor

agent:pedro

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-002.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-002-CTX

### SPEC references

- ART-SPEC-GOV-002

### Architecture references

- ART-ARCH-TRACE-001

### Allowed files

- docs/ASTRO_REBELS_TRAFFIC_MASTER_SPEC_EN.md
- docs/ASTRO_REBELS_TRAFFIC_ARCHITECTURE_EN.md
- docs/TRACEABILITY.md

### Exact instructions

1. Copy the exact approved documents into docs/.

2. Record SHA-256 hashes in docs/TRACEABILITY.md.

### Commands

- Get-FileHash 'C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic\docs\ASTRO_REBELS_TRAFFIC_MASTER_SPEC_EN.md' -Algorithm SHA256

### Validation

- Changed files are within the task allowlist and the context pack exact-file list.
- No tool result exceeds 4,000 characters; verbose output is redirected to a file and summarized.
- The phase report lists unfinished original steps explicitly.

### Acceptance criteria

- Phase-one steps are implemented without claiming the original task complete.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-002-P2 - Install the two source-of-truth documents in the game repository â atomic implementation phase 2

- Plane work item ID: `954e9e47-4949-4d6b-aefb-b3b3f8db8ac9`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:pedro`
- Type: `type:tooling`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 118

### Objective

Perform only the remaining bounded half of ART-TASK-002 using phase-one artifacts.

### Executor

agent:pedro

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-002.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-002-P1

### SPEC references

- ART-SPEC-GOV-002

### Architecture references

- ART-ARCH-TRACE-001

### Allowed files

- docs/ASTRO_REBELS_TRAFFIC_MASTER_SPEC_EN.md
- docs/ASTRO_REBELS_TRAFFIC_ARCHITECTURE_EN.md
- docs/TRACEABILITY.md

### Exact instructions

1. State that Plane contains operational work and these files contain product/technical truth.

2. Do not copy documents from the unrelated AstroRebels action-game repository.

### Commands

- Get-FileHash 'C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic\docs\ASTRO_REBELS_TRAFFIC_ARCHITECTURE_EN.md' -Algorithm SHA256

### Validation

- Phase-one artifacts are present and unchanged except for required integration edits.
- Changed files are within the task allowlist and the context pack exact-file list.
- The phase report maps every original instruction to P1 or P2 evidence.

### Acceptance criteria

- All implementation instructions are covered; final acceptance is deferred to the validation phase.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-002-VAL - Install the two source-of-truth documents in the game repository â bounded validation

- Plane work item ID: `03730765-5a03-4e1c-b016-635e8b9ebf36`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:pedro`
- Type: `type:test`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 119

### Objective

Validate ART-TASK-002 without implementing new functionality.

### Executor

agent:pedro

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-002.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-002-P2

### SPEC references

- ART-SPEC-GOV-002

### Architecture references

- ART-ARCH-TRACE-001

### Allowed files

- docs/ASTRO_REBELS_TRAFFIC_MASTER_SPEC_EN.md
- docs/ASTRO_REBELS_TRAFFIC_ARCHITECTURE_EN.md
- docs/TRACEABILITY.md

### Exact instructions

1. Run only the original validation commands with concise output.

2. Record exit codes and the smallest relevant failure output.

3. Check every original acceptance criterion against observable evidence.

4. Do not repair failures; return BLOCKED with the exact failing phase.

### Commands

- Get-FileHash 'C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic\docs\ASTRO_REBELS_TRAFFIC_MASTER_SPEC_EN.md' -Algorithm SHA256
- Get-FileHash 'C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic\docs\ASTRO_REBELS_TRAFFIC_ARCHITECTURE_EN.md' -Algorithm SHA256

### Validation

- Both files exist and are non-empty.
- All ART-SPEC and ART-ARCH exact references used by this backlog resolve.

### Acceptance criteria

- Hashes are recorded.
- Source documents are unchanged.
- Wrong-project contamination is absent.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-003 - Create the Godot C# project skeleton

- Plane work item ID: `c51a835c-e3b3-4949-b425-212e1d5204b8`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:nicolas`
- Type: `type:code`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 3

### Objective

Create only the approved Godot C# project and required empty layer folders in the existing AstroRebelsSpaceTraffic directory.

### Executor

agent:nicolas

### 32K context contract

- Risk class: context-required
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-003.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-001
- ART-TASK-002
- ART-TASK-003-CTX

### SPEC references

- ART-SPEC-PLAT-001

### Architecture references

- ART-ARCH-SCENE-001
- ART-ARCH-FOLDER-001

### Allowed files

- project.godot
- AstroRebelsTraffic.csproj
- AstroRebelsTraffic.sln
- app/**
- domain/**
- application/**
- levels/**
- solver/**
- presentation/**
- infrastructure/**
- tests/**

### Exact instructions

1. Create project.godot with config_version=5, project name Astro Rebels Traffic, C# feature and portrait orientation.

2. Create AstroRebelsTraffic.csproj using Godot.NET.Sdk/4.7.1 and TargetFramework net8.0.

3. Create the folder structure from ART-ARCH-FOLDER-001.

4. Create a minimal AppRoot scene that opens without gameplay.

5. Do not add external runtime packages.

### Commands

- Set-Location 'C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic'
- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- & 'C:\Users\eorod\Desktop\Godot_v4.7.1-stable_mono_win64\Godot_v4.7.1-stable_mono_win64_console.exe' --headless --path 'C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic' --editor --quit

### Validation

- Build exits 0.
- Godot imports project headlessly and exits 0.
- No files were created in juegos/AstroRebels.

### Acceptance criteria

- Project opens to the minimal AppRoot scene.
- All mandatory top-level folders exist.
- No gameplay behavior is invented.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-003-CTX - Build bounded context pack for ART-TASK-003

- Plane work item ID: `4d71b509-11fe-4e6a-b41e-c2d8b7d88b49`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:nicolas`
- Type: `type:tooling`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 86

### Objective

Create the only normative and repository context that ART-TASK-003 may consume.

### Executor

agent:nicolas

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-001
- ART-TASK-002
- ART-TASK-000

### SPEC references

- ART-SPEC-PLAT-001

### Architecture references

- ART-ARCH-SCENE-001
- ART-ARCH-FOLDER-001

### Allowed files

- docs/task-context/ART-TASK-003.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-PLAT-001] and ARCH IDs [ART-ARCH-SCENE-001,ART-ARCH-FOLDER-001].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-003' -SpecIds 'ART-SPEC-PLAT-001' -ArchIds 'ART-ARCH-SCENE-001,ART-ARCH-FOLDER-001' -OutputPath 'docs/task-context/ART-TASK-003.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-003.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-003 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-004 - Create the xUnit test project and common test command

- Plane work item ID: `6128981a-a487-413b-b4c8-6fa3d65902f7`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:test`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 4

### Objective

Create a repeatable headless unit-test project that references the domain assembly.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-003

### SPEC references

- ART-SPEC-QA-003

### Architecture references

- ART-ARCH-TEST-001

### Allowed files

- tests/AstroRebelsTraffic.Tests/**
- AstroRebelsTraffic.sln

### Exact instructions

1. Create xUnit project targeting net8.0.

2. Reference the main project.

3. Add one smoke test that always proves the runner is connected.

4. Add both projects to the solution.

5. Document the single canonical test command in README.md.

### Commands

- Set-Location 'C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic'
- dotnet new xunit -n AstroRebelsTraffic.Tests -o tests\AstroRebelsTraffic.Tests -f net8.0
- dotnet add tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj reference AstroRebelsTraffic.csproj
- dotnet sln AstroRebelsTraffic.sln add tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Restore and test exit 0.
- Test output reports at least one passed test.

### Acceptance criteria

- The canonical test command works from repository root.
- No scene tree is required by domain tests.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-005 - Add formatting, warnings and repository ignore rules

- Plane work item ID: `41f112fb-6f46-4e0a-a013-798155063bab`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:alfredo`
- Type: `type:tooling`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 5

### Objective

Make compilation failures and formatting deterministic while excluding generated Godot and build output.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-003
- ART-TASK-004

### SPEC references

- ART-SPEC-QA-004

### Architecture references

- ART-ARCH-GOV-005

### Allowed files

- .editorconfig
- .gitignore
- Directory.Build.props
- README.md

### Exact instructions

1. Enable nullable reference types.

2. Treat project-owned compiler warnings as errors.

3. Ignore .godot, bin, obj, test results and local secrets.

4. Do not ignore level definitions, source assets or docs.

5. Document formatting and build commands.

### Commands

- Set-Location 'C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic'
- dotnet format AstroRebelsTraffic.sln --verify-no-changes
- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- No secrets or generated output are tracked.
- Build and tests remain green.

### Acceptance criteria

- Formatting command is deterministic.
- Warnings cannot be silently accepted.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-010 - Define canonical domain enums and identifiers

- Plane work item ID: `b78f5345-5f99-440d-8864-c4277e37c221`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 6

### Objective

Create immutable value types for IDs and closed enums for direction, size, phase, dock kind and special type.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-004

### SPEC references

- ART-SPEC-TERM-001
- ART-SPEC-SHIP-001
- ART-SPEC-SHIP-002

### Architecture references

- ART-ARCH-STATE-002
- ART-ARCH-STATE-003

### Allowed files

- domain/State/DomainIds.cs
- domain/State/DomainEnums.cs
- tests/AstroRebelsTraffic.Tests/Domain/DomainIdsTests.cs

### Exact instructions

1. Use value equality and deterministic string serialization.

2. Reject empty IDs at construction or validation boundary.

3. Define only authorized enum values.

4. Do not use display strings as rule identifiers.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Round-trip and equality tests pass.
- Unknown serialized enum values fail with a structured error.

### Acceptance criteria

- No rule depends on localized text.
- Canonical size and direction values match the SPEC.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-011 - Implement ShipState and canonical size-capacity mapping

- Plane work item ID: `b4f89753-e2ce-41f7-8043-b38f8a7a6b11`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 7

### Objective

Represent one logical ship and derive capacity only from Small=4, Medium=8, Large=16.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-010

### SPEC references

- ART-SPEC-SHIP-001
- ART-SPEC-SHIP-002

### Architecture references

- ART-ARCH-STATE-003
- ART-ARCH-STATE-006

### Allowed files

- domain/State/ShipState.cs
- domain/Rules/Ships/ShipRules.cs
- tests/AstroRebelsTraffic.Tests/Domain/ShipStateTests.cs

### Exact instructions

1. Create immutable/copy-safe ShipState.

2. Centralize size-to-length and size-to-capacity mapping.

3. Validate passenger count range.

4. Include reveal state without presentation data.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Tests cover all three sizes and invalid passenger counts.
- No second size-capacity table exists.

### Acceptance criteria

- Capacity mapping is exact.
- ShipState has no Godot Node, texture or animation dependency.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-012 - Implement GridState and zone collection

- Plane work item ID: `25d09501-dc93-4922-8154-8b6e9b5487e3`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 8

### Objective

Represent one or more rectangular zones using integer coordinates and stable ship ordering.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-010
- ART-TASK-011

### SPEC references

- ART-SPEC-GRID-001
- ART-SPEC-SHIP-003

### Architecture references

- ART-ARCH-STATE-003
- ART-ARCH-ADV-004

### Allowed files

- domain/State/GridState.cs
- domain/State/GridCell.cs
- tests/AstroRebelsTraffic.Tests/Domain/GridStateTests.cs

### Exact instructions

1. Store width, height, zone ID and stable ship IDs.

2. Do not store pixel positions.

3. Support one zone without a special-case state shape.

4. Reject non-positive dimensions.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Tests cover one and two zones.
- Serialization order is stable.

### Acceptance criteria

- Grid is presentation-independent.
- Multi-zone extension exists without enabling the mechanic.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-013 - Implement PassengerQueueState and PassengerGroup

- Plane work item ID: `52127a0f-1de9-44f0-a467-e969c784fdd1`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 9

### Objective

Represent immutable ordered main-queue groups of one color and size 4, 8 or 16.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-010

### SPEC references

- ART-SPEC-QUEUE-001
- ART-SPEC-QUEUE-002

### Architecture references

- ART-ARCH-STATE-004

### Allowed files

- domain/State/PassengerGroup.cs
- domain/State/PassengerQueueState.cs
- tests/AstroRebelsTraffic.Tests/Domain/PassengerQueueStateTests.cs

### Exact instructions

1. Preserve exact front-to-back order.

2. Reject other source group sizes.

3. Support repeated non-adjacent colors.

4. Provide copy-safe front/consume operations without boarding rules.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Group size validation tests pass.
- Repeated-color order survives round-trip serialization.

### Acceptance criteria

- No player reordering API exists.
- State contains no passenger Nodes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-014 - Implement PreQueueState with bounded logical order

- Plane work item ID: `7d92df71-0cd8-4ccc-afc1-5d106af41221`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 10

### Objective

Represent the bounded circular prequeue as logical arrival order with default capacity 16.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-010
- ART-TASK-013

### SPEC references

- ART-SPEC-PREQ-001
- ART-SPEC-PREQ-002

### Architecture references

- ART-ARCH-STATE-004

### Allowed files

- domain/State/PreQueueState.cs
- tests/AstroRebelsTraffic.Tests/Domain/PreQueueStateTests.cs

### Exact instructions

1. Count capacity in individual passengers.

2. Allow compact runs only if survivor order is exact.

3. Reject append beyond capacity.

4. Do not store visual rotation angle or animation position.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Default and custom capacity tests pass.
- Append/remove tests preserve survivor order.

### Acceptance criteria

- Full prequeue remains a valid state.
- Logical state is independent of circular rendering.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-015 - Implement DockState and fixed standard dock order

- Plane work item ID: `f59c8b8e-99c7-4c37-9009-740b235e742a`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 11

### Objective

Represent four active base docks and four inactive rewarded docks in one fixed left-to-right order.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-010
- ART-TASK-011

### SPEC references

- ART-SPEC-DOCK-001
- ART-SPEC-DOCK-002

### Architecture references

- ART-ARCH-STATE-005

### Allowed files

- domain/State/DockState.cs
- tests/AstroRebelsTraffic.Tests/Domain/DockStateTests.cs

### Exact instructions

1. Assign visual indices 0 through 7.

2. Ensure one optional occupant per dock.

3. Reject occupants in inactive docks.

4. Model VIP separately and disabled.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Initial factory returns exactly 8 standard docks.
- Indices and activation states match the SPEC.

### Acceptance criteria

- Dock order is stable.
- No boarding priority is implemented in state classes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-016 - Assemble canonical GameState

- Plane work item ID: `da2fe839-ae84-4a88-bdd8-c1f768b271ad`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 12

### Objective

Create the complete logical state used by runtime, tests and solver.

### Executor

agent:alfredo

### 32K context contract

- Risk class: context-required
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-016.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-012
- ART-TASK-013
- ART-TASK-014
- ART-TASK-015
- ART-TASK-016-CTX

### SPEC references

- ART-SPEC-QA-001
- ART-SPEC-QA-002

### Architecture references

- ART-ARCH-STATE-001
- ART-ARCH-DEP-003

### Allowed files

- domain/State/GameState.cs
- tests/AstroRebelsTraffic.Tests/Domain/GameStateTests.cs

### Exact instructions

1. Include every field required by ART-ARCH-STATE-001.

2. Use deep-copy-safe immutable collections or controlled copying.

3. Exclude Node references, clocks and provider objects.

4. Provide one initial-state construction boundary used by the loader.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Deep-copy mutation tests prove no aliasing.
- Equivalent states compare deterministically.

### Acceptance criteria

- GameState is the only authoritative logical state.
- Runtime and solver can reference the same type.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-016-CTX - Build bounded context pack for ART-TASK-016

- Plane work item ID: `b16d59b8-734b-4e63-b6c7-6f6bb2f03cb3`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:tooling`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 87

### Objective

Create the only normative and repository context that ART-TASK-016 may consume.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-012
- ART-TASK-013
- ART-TASK-014
- ART-TASK-015
- ART-TASK-000

### SPEC references

- ART-SPEC-QA-001
- ART-SPEC-QA-002

### Architecture references

- ART-ARCH-STATE-001
- ART-ARCH-DEP-003

### Allowed files

- docs/task-context/ART-TASK-016.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-QA-001,ART-SPEC-QA-002] and ARCH IDs [ART-ARCH-STATE-001,ART-ARCH-DEP-003].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-016' -SpecIds 'ART-SPEC-QA-001,ART-SPEC-QA-002' -ArchIds 'ART-ARCH-STATE-001,ART-ARCH-DEP-003' -OutputPath 'docs/task-context/ART-TASK-016.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-016.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-016 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-017 - Implement GameStateInvariantChecker â integration gate

- Plane work item ID: `98798c1d-3805-4084-8458-5503e60e33f2`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:test`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 13

### Objective

Close ART-TASK-017 only after its context, implementation and validation subtasks are Done. This gate performs no implementation.

### Executor

agent:alfredo

### 32K context contract

- Risk class: gate
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-017.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-017-VAL

### SPEC references

- ART-SPEC-QA-003

### Architecture references

- ART-ARCH-STATE-006

### Allowed files

- docs/task-context/ART-TASK-017.md

### Exact instructions

1. Confirm ART-TASK-017-CTX, ART-TASK-017-P1, ART-TASK-017-P2 and ART-TASK-017-VAL are Done in Plane.

2. Confirm validation evidence addresses every original acceptance criterion.

3. Record the four subtask IDs and evidence links in the completion comment.

4. Do not read source files or rerun broad commands in this gate.

### Commands

None.

### Validation

- All four required subtasks are Done and none reports an unresolved blocker.

### Acceptance criteria

- The original task closes as a traceability gate without consuming implementation context.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-017-CTX - Build bounded context pack for ART-TASK-017

- Plane work item ID: `7af6c5a4-032d-4996-95da-4c1444f7c210`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:tooling`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 120

### Objective

Create the only normative and repository context that ART-TASK-017 may consume.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-016
- ART-TASK-000

### SPEC references

- ART-SPEC-QA-003

### Architecture references

- ART-ARCH-STATE-006

### Allowed files

- docs/task-context/ART-TASK-017.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-QA-003] and ARCH IDs [ART-ARCH-STATE-006].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-017' -SpecIds 'ART-SPEC-QA-003' -ArchIds 'ART-ARCH-STATE-006' -OutputPath 'docs/task-context/ART-TASK-017.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-017.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-017 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-017-P1 - Implement GameStateInvariantChecker â atomic implementation phase 1

- Plane work item ID: `aa79633c-586b-4035-90a3-c5e9580a102f`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:test`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 121

### Objective

Perform only the first bounded half of ART-TASK-017; do not execute final validation or the remaining steps.

### Executor

agent:alfredo

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-017.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-017-CTX

### SPEC references

- ART-SPEC-QA-003

### Architecture references

- ART-ARCH-STATE-006

### Allowed files

- domain/Rules/Invariants/GameStateInvariantChecker.cs
- tests/AstroRebelsTraffic.Tests/Domain/InvariantCheckerTests.cs

### Exact instructions

1. Implement each bullet in ART-ARCH-STATE-006.

2. Return all violations in deterministic order.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug

### Validation

- Changed files are within the task allowlist and the context pack exact-file list.
- No tool result exceeds 4,000 characters; verbose output is redirected to a file and summarized.
- The phase report lists unfinished original steps explicitly.

### Acceptance criteria

- Phase-one steps are implemented without claiming the original task complete.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-017-P2 - Implement GameStateInvariantChecker â atomic implementation phase 2

- Plane work item ID: `b620534b-d39f-4b69-a4a0-aacf141d53e2`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:test`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 122

### Objective

Perform only the remaining bounded half of ART-TASK-017 using phase-one artifacts.

### Executor

agent:alfredo

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-017.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-017-P1

### SPEC references

- ART-SPEC-QA-003

### Architecture references

- ART-ARCH-STATE-006

### Allowed files

- domain/Rules/Invariants/GameStateInvariantChecker.cs
- tests/AstroRebelsTraffic.Tests/Domain/InvariantCheckerTests.cs

### Exact instructions

1. Do not repair invalid state silently.

2. Add one failing fixture for every invariant.

### Commands

- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Phase-one artifacts are present and unchanged except for required integration edits.
- Changed files are within the task allowlist and the context pack exact-file list.
- The phase report maps every original instruction to P1 or P2 evidence.

### Acceptance criteria

- All implementation instructions are covered; final acceptance is deferred to the validation phase.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-017-VAL - Implement GameStateInvariantChecker â bounded validation

- Plane work item ID: `eb04a73c-9b83-466b-8ac1-33c9668068f5`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:test`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 123

### Objective

Validate ART-TASK-017 without implementing new functionality.

### Executor

agent:alfredo

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-017.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-017-P2

### SPEC references

- ART-SPEC-QA-003

### Architecture references

- ART-ARCH-STATE-006

### Allowed files

- domain/Rules/Invariants/GameStateInvariantChecker.cs
- tests/AstroRebelsTraffic.Tests/Domain/InvariantCheckerTests.cs

### Exact instructions

1. Run only the original validation commands with concise output.

2. Record exit codes and the smallest relevant failure output.

3. Check every original acceptance criterion against observable evidence.

4. Do not repair failures; return BLOCKED with the exact failing phase.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Each intentionally invalid fixture reports its exact code and path.
- A valid fixture reports no violations.

### Acceptance criteria

- Checker is used by tests and later loader/solver tasks.
- No presentation dependency exists.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-018 - Implement deterministic state serialization

- Plane work item ID: `5f38df67-6199-4e84-9a49-aeb628434e22`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 14

### Objective

Serialize canonical state with stable field and collection order for snapshots, replay and hashing.

### Executor

agent:alfredo

### 32K context contract

- Risk class: context-required
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-018.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-016
- ART-TASK-017
- ART-TASK-018-CTX

### SPEC references

- ART-SPEC-QA-001

### Architecture references

- ART-ARCH-STATE-001
- ART-ARCH-SOLVER-003

### Allowed files

- domain/Serialization/GameStateSerializer.cs
- tests/AstroRebelsTraffic.Tests/Domain/GameStateSerializationTests.cs

### Exact instructions

1. Use explicit schema version.

2. Order zones, docks and keyed collections canonically.

3. Reject unknown future schema versions.

4. Never serialize presentation or service state.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Golden serialization fixture is byte-stable across repeated runs.
- Round trip returns equal canonical state.

### Acceptance criteria

- Serialization is deterministic.
- Schema version is explicit.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-018-CTX - Build bounded context pack for ART-TASK-018

- Plane work item ID: `f2b371cf-d7ea-40b3-b63e-ca77db094376`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:alfredo`
- Type: `type:tooling`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 88

### Objective

Create the only normative and repository context that ART-TASK-018 may consume.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-016
- ART-TASK-017
- ART-TASK-000

### SPEC references

- ART-SPEC-QA-001

### Architecture references

- ART-ARCH-STATE-001
- ART-ARCH-SOLVER-003

### Allowed files

- docs/task-context/ART-TASK-018.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-QA-001] and ARCH IDs [ART-ARCH-STATE-001,ART-ARCH-SOLVER-003].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-018' -SpecIds 'ART-SPEC-QA-001' -ArchIds 'ART-ARCH-STATE-001,ART-ARCH-SOLVER-003' -OutputPath 'docs/task-context/ART-TASK-018.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-018.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-018 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-020 - Implement canonical ship footprint derivation

- Plane work item ID: `0fb50fb7-2ddb-402b-9bda-909cb140459f`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 15

### Objective

Derive all occupied integer cells from anchor, direction and ship length using one function.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-011
- ART-TASK-012

### SPEC references

- ART-SPEC-SHIP-002
- ART-SPEC-SHIP-003

### Architecture references

- ART-ARCH-STATE-003
- ART-ARCH-GRID-001

### Allowed files

- domain/Rules/Grid/ShipFootprint.cs
- tests/AstroRebelsTraffic.Tests/Grid/ShipFootprintTests.cs

### Exact instructions

1. Define anchor semantics in code documentation.

2. Return cells in deterministic order.

3. Support lengths 1, 2 and 3 in all four directions.

4. Do not duplicate footprint math elsewhere.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Twelve size-direction combinations have exact expected cells.
- Boundary-independent unit tests pass.

### Acceptance criteria

- One canonical footprint implementation exists.
- No pixel or physics dependency exists.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-021 - Implement GridQuery and occupancy index

- Plane work item ID: `ff3316c2-11ea-4678-8ebd-c3ed0eded7cb`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 16

### Objective

Provide bounds, occupancy and ship lookup queries with a reproducible occupancy index.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-020

### SPEC references

- ART-SPEC-SHIP-003
- ART-SPEC-GRID-003

### Architecture references

- ART-ARCH-GRID-001
- ART-ARCH-PERF-003

### Allowed files

- domain/Rules/Grid/GridQuery.cs
- tests/AstroRebelsTraffic.Tests/Grid/GridQueryTests.cs

### Exact instructions

1. Build index from canonical footprints.

2. Detect overlap rather than overwriting it.

3. Return stable blocker identifiers.

4. Keep index reproducible from GameState.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Overlap and out-of-bounds fixtures fail explicitly.
- Queries return exact occupants.

### Acceptance criteria

- No scene-tree traversal occurs.
- Index never becomes a second authority.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-022 - Implement full-footprint PathValidator

- Plane work item ID: `766cdc0f-0b36-463c-b740-bb79f490fe3f`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 17

### Objective

Validate rigid translation to the rectangular zone boundary for all sizes and directions.

### Executor

agent:alfredo

### 32K context contract

- Risk class: context-required
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-022.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-021
- ART-TASK-022-CTX

### SPEC references

- ART-SPEC-SHIP-004
- ART-SPEC-SHIP-005

### Architecture references

- ART-ARCH-GRID-002

### Allowed files

- domain/Rules/Grid/PathValidator.cs
- tests/AstroRebelsTraffic.Tests/Grid/PathValidatorTests.cs

### Exact instructions

1. Advance one logical cell at a time.

2. Check every newly occupied footprint cell against other ships.

3. Return clear path or structured blocker.

4. Do not use physics, raycasts or rendered bounds.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Clear and blocked fixtures cover 3 sizes Ã 4 directions.
- Partial-gap cases for Medium/Large are rejected.

### Acceptance criteria

- Path result is deterministic.
- Whole footprint is always considered.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-022-CTX - Build bounded context pack for ART-TASK-022

- Plane work item ID: `ac962bf2-1aa3-4a35-9abf-c4bbaffb1377`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:tooling`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 89

### Objective

Create the only normative and repository context that ART-TASK-022 may consume.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-021
- ART-TASK-000

### SPEC references

- ART-SPEC-SHIP-004
- ART-SPEC-SHIP-005

### Architecture references

- ART-ARCH-GRID-002

### Allowed files

- docs/task-context/ART-TASK-022.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-SHIP-004,ART-SPEC-SHIP-005] and ARCH IDs [ART-ARCH-GRID-002].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-022' -SpecIds 'ART-SPEC-SHIP-004,ART-SPEC-SHIP-005' -ArchIds 'ART-ARCH-GRID-002' -OutputPath 'docs/task-context/ART-TASK-022.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-022.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-022 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-023 - Implement invalid release reason tests

- Plane work item ID: `79294ee5-0bbb-48d4-9426-33194dcf07a6`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:sofia`
- Type: `type:test`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 18

### Objective

Lock the exact validation order and structured rejection reasons before command implementation.

### Executor

agent:sofia

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-022

### SPEC references

- ART-SPEC-SHIP-006

### Architecture references

- ART-ARCH-CMD-003

### Allowed files

- tests/AstroRebelsTraffic.Tests/Grid/ReleaseValidationReasonTests.cs

### Exact instructions

1. Create fixtures for wrong phase, unknown ship, blocked path and full docks.

2. Assert first applicable failure reason.

3. Assert rejected state canonical bytes remain unchanged.

4. Do not test UI text.

### Commands

- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- All failure-order tests pass.
- State hash/serialization is unchanged after rejection.

### Acceptance criteria

- Reasons are domain enums.
- No invalid tap counts as a move.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-030 - Implement DockSystem leftmost assignment

- Plane work item ID: `f55d1c44-5d1c-4bae-bdc8-4da64d12933a`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 19

### Objective

Select and occupy the leftmost empty active standard dock.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-015
- ART-TASK-017

### SPEC references

- ART-SPEC-SHIP-007
- ART-SPEC-DOCK-004

### Architecture references

- ART-ARCH-DOCK-001

### Allowed files

- domain/Rules/Docks/DockSystem.cs
- tests/AstroRebelsTraffic.Tests/Docks/DockAssignmentTests.cs

### Exact instructions

1. Search ascending visual index.

2. Ignore locked rewarded and VIP docks.

3. Return no destination when all eligible docks are occupied.

4. Reject double occupancy.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Gap fixtures always choose the lowest empty active index.
- Locked docks never count as available.

### Acceptance criteria

- Assignment is leftmost-empty.
- Player cannot choose a standard destination.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-031 - Implement rewarded standard dock activation rule

- Plane work item ID: `2dfffd03-c0c6-49e9-b105-b31f258e967c`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 20

### Objective

Activate exactly one still-locked rewarded standard dock per authorized reward, maximum four, for the current attempt.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-030

### SPEC references

- ART-SPEC-DOCK-003
- ART-SPEC-DOCK-004

### Architecture references

- ART-ARCH-DOCK-001

### Allowed files

- domain/Rules/Docks/RewardDockRules.cs
- tests/AstroRebelsTraffic.Tests/Docks/RewardDockRulesTests.cs

### Exact instructions

1. Activate rewarded docks in fixed ascending index unless product data later specifies otherwise.

2. Reject a fifth activation.

3. Keep activation attempt-local.

4. Do not call an ad provider.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Four successive grants activate four distinct docks.
- Fifth grant is rejected without mutation.

### Acceptance criteria

- No locked dock prevents deadlock.
- Rule is provider-neutral.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-032 - Implement right-to-left compatible dock query

- Plane work item ID: `28833d26-edc4-4a25-8f33-944915f8738f`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 21

### Objective

Return compatible non-full dock ships in descending visual index.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-030

### SPEC references

- ART-SPEC-BOARD-002

### Architecture references

- ART-ARCH-DOCK-001
- ART-ARCH-BOARD-001

### Allowed files

- domain/Rules/Docks/DockBoardingQuery.cs
- tests/AstroRebelsTraffic.Tests/Docks/BoardingPriorityTests.cs

### Exact instructions

1. Filter by exact color ID and remaining capacity.

2. Sort descending index.

3. Exclude empty, incompatible, full and inactive docks.

4. Add a regression test proving left-first is wrong.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Rightmost compatible ship is always first.
- Multiple gaps and colors are covered.

### Acceptance criteria

- Boarding priority cannot regress to left-first.
- Query has no mutation.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-033 - Implement BoardingResolver

- Plane work item ID: `16154323-53c0-4c6d-b6e7-942c79fdb8d5`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 22

### Objective

Allocate passenger units to same-color dock ships in exact right-to-left order without exceeding capacity.

### Executor

agent:alfredo

### 32K context contract

- Risk class: context-required
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-033.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-032
- ART-TASK-014
- ART-TASK-033-CTX

### SPEC references

- ART-SPEC-BOARD-001
- ART-SPEC-BOARD-002
- ART-SPEC-BOARD-003
- ART-SPEC-QUEUE-004

### Architecture references

- ART-ARCH-BOARD-001

### Allowed files

- domain/Rules/Boarding/BoardingResolver.cs
- tests/AstroRebelsTraffic.Tests/Boarding/BoardingResolverTests.cs

### Exact instructions

1. Use DockBoardingQuery only.

2. Produce a new state/result and ordered boarding facts.

3. Support exact batching with individual-passenger-equivalent outcome.

4. Never depart ships inside this class.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- 8 splits across two Small ships.
- 16 covers 1Ã16, 2Ã8, 4Ã4 and mixed exact combinations.
- No incompatible or overflow boarding occurs.

### Acceptance criteria

- Resolver is sole boarding authority.
- Outcome is deterministic.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-033-CTX - Build bounded context pack for ART-TASK-033

- Plane work item ID: `1b9a3136-54f6-4093-b11f-393a5649af81`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:tooling`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 90

### Objective

Create the only normative and repository context that ART-TASK-033 may consume.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-032
- ART-TASK-014
- ART-TASK-000

### SPEC references

- ART-SPEC-BOARD-001
- ART-SPEC-BOARD-002
- ART-SPEC-BOARD-003
- ART-SPEC-QUEUE-004

### Architecture references

- ART-ARCH-BOARD-001

### Allowed files

- docs/task-context/ART-TASK-033.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-BOARD-001,ART-SPEC-BOARD-002,ART-SPEC-BOARD-003,ART-SPEC-QUEUE-004] and ARCH IDs [ART-ARCH-BOARD-001].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-033' -SpecIds 'ART-SPEC-BOARD-001,ART-SPEC-BOARD-002,ART-SPEC-BOARD-003,ART-SPEC-QUEUE-004' -ArchIds 'ART-ARCH-BOARD-001' -OutputPath 'docs/task-context/ART-TASK-033.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-033.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-033 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-034 - Implement one-pass circular PreQueue scan

- Plane work item ID: `1c3f2be2-20ce-4084-9f07-8a2c82a6ba45`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 23

### Objective

Inspect prequeue passengers once in logical order, board eligible units and preserve survivor order.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-014
- ART-TASK-033

### SPEC references

- ART-SPEC-PREQ-002
- ART-SPEC-PREQ-003
- ART-SPEC-PREQ-005

### Architecture references

- ART-ARCH-QUEUE-002

### Allowed files

- domain/Rules/Passengers/PreQueueRules.cs
- tests/AstroRebelsTraffic.Tests/Passengers/PreQueueScanTests.cs

### Exact instructions

1. Take a snapshot of the pass input order.

2. Inspect each original entry once.

3. Use BoardingResolver for allocation.

4. Preserve relative order of all survivors.

5. Return whether state changed.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Compatible passengers behind incompatible passengers can board.
- Survivor order is exact.
- No infinite rescan occurs inside one pass.

### Acceptance criteria

- Visual circular position is irrelevant.
- Pass behavior matches SPEC exactly.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-035 - Implement atomic front-group admission

- Plane work item ID: `0851fe51-417c-4c38-ae62-b8752b5d2284`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 24

### Objective

Admit the complete front group only when its projected unboarded remainder fits in prequeue.

### Executor

agent:alfredo

### 32K context contract

- Risk class: context-required
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-035.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-013
- ART-TASK-014
- ART-TASK-033
- ART-TASK-035-CTX

### SPEC references

- ART-SPEC-QUEUE-005
- ART-SPEC-PREQ-004

### Architecture references

- ART-ARCH-QUEUE-001

### Allowed files

- domain/Rules/Passengers/PassengerQueueRules.cs
- tests/AstroRebelsTraffic.Tests/Passengers/GroupAdmissionTests.cs

### Exact instructions

1. Project immediate compatible dock capacity without mutating.

2. Calculate exact remainder after right-to-left boarding.

3. If remainder exceeds free prequeue space, return unchanged.

4. Otherwise board, append full remainder and consume exactly one group atomically.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Blocked admission produces byte-equal state.
- Successful admission conserves every passenger.
- Full prequeue alone is not loss.

### Acceptance criteria

- No partial untracked group exists.
- Only queue front is considered.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-035-CTX - Build bounded context pack for ART-TASK-035

- Plane work item ID: `96643e6d-c092-4217-aa7c-f70352e00998`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:tooling`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 91

### Objective

Create the only normative and repository context that ART-TASK-035 may consume.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-013
- ART-TASK-014
- ART-TASK-033
- ART-TASK-000

### SPEC references

- ART-SPEC-QUEUE-005
- ART-SPEC-PREQ-004

### Architecture references

- ART-ARCH-QUEUE-001

### Allowed files

- docs/task-context/ART-TASK-035.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-QUEUE-005,ART-SPEC-PREQ-004] and ARCH IDs [ART-ARCH-QUEUE-001].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-035' -SpecIds 'ART-SPEC-QUEUE-005,ART-SPEC-PREQ-004' -ArchIds 'ART-ARCH-QUEUE-001' -OutputPath 'docs/task-context/ART-TASK-035.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-035.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-035 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-036 - Implement automatic full-ship departure transition

- Plane work item ID: `46ebe849-d5db-4e93-8663-8ff68a79eefd`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 25

### Objective

Remove exactly full dock ships in stable dock-index order and free their slots.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-033

### SPEC references

- ART-SPEC-DOCK-005

### Architecture references

- ART-ARCH-RES-003

### Allowed files

- domain/Rules/Docks/ShipDepartureRules.cs
- tests/AstroRebelsTraffic.Tests/Docks/ShipDepartureTests.cs

### Exact instructions

1. Detect passenger_count == capacity only.

2. Process stable ascending dock index for event consistency.

3. Do not depart partial ships.

4. Return departure facts with ship and dock IDs.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Full ships depart; partial ships remain.
- Multiple departures use stable order.

### Acceptance criteria

- Dock becomes empty.
- Ship is no longer in any logical location.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-040 - Define immutable domain events

- Plane work item ID: `55c8418d-8b6d-4c07-8359-ceeca9a9df6e`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 26

### Objective

Create typed immutable event records for every required core transition.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-016

### SPEC references

- ART-SPEC-RESOLVE-001

### Architecture references

- ART-ARCH-EVENT-001
- ART-ARCH-EVENT-002

### Allowed files

- domain/Events/**
- tests/AstroRebelsTraffic.Tests/Events/DomainEventTests.cs

### Exact instructions

1. Implement required event categories from ART-ARCH-EVENT-001.

2. Include stable IDs and logical values only.

3. Exclude Nodes, textures and provider payloads.

4. Define deterministic event serialization/order tests.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- All core event types are constructible and immutable.
- Round-trip order is stable.

### Acceptance criteria

- Events are facts, not commands.
- Consumers cannot alter resolved outcome.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-041 - Implement deterministic ResolutionSystem settlement loop

- Plane work item ID: `97fd65ba-7eff-42e8-9814-269e43f61431`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 27

### Objective

Run prequeue, departures and atomic main-group admission until a deterministic quiescent state.

### Executor

agent:alfredo

### 32K context contract

- Risk class: context-required
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-041.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-034
- ART-TASK-035
- ART-TASK-036
- ART-TASK-040
- ART-TASK-041-CTX

### SPEC references

- ART-SPEC-RESOLVE-001
- ART-SPEC-PREQ-005

### Architecture references

- ART-ARCH-RES-001
- ART-ARCH-RES-003
- ART-ARCH-RES-004
- ART-ARCH-RES-005

### Allowed files

- domain/Resolution/ResolutionSystem.cs
- tests/AstroRebelsTraffic.Tests/Resolution/SettlementTests.cs

### Exact instructions

1. Copy the exact loop from ART-ARCH-RES-003.

2. Track changed only from real state changes.

3. Reevaluate prequeue before another main group after departure.

4. Append events in transition order.

5. Assert a bounded termination guard in debug/tests.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Cascading boarding/departure fixtures settle correctly.
- Repeated execution on settled state makes no change.
- Termination property tests pass.

### Acceptance criteria

- No animation timing exists in resolver.
- Final state and event order are deterministic.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-041-CTX - Build bounded context pack for ART-TASK-041

- Plane work item ID: `e9160a88-dc32-4d29-8e78-6fe54f9897a0`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:tooling`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 92

### Objective

Create the only normative and repository context that ART-TASK-041 may consume.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-034
- ART-TASK-035
- ART-TASK-036
- ART-TASK-040
- ART-TASK-000

### SPEC references

- ART-SPEC-RESOLVE-001
- ART-SPEC-PREQ-005

### Architecture references

- ART-ARCH-RES-001
- ART-ARCH-RES-003
- ART-ARCH-RES-004
- ART-ARCH-RES-005

### Allowed files

- docs/task-context/ART-TASK-041.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-RESOLVE-001,ART-SPEC-PREQ-005] and ARCH IDs [ART-ARCH-RES-001,ART-ARCH-RES-003,ART-ARCH-RES-004,ART-ARCH-RES-005].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-041' -SpecIds 'ART-SPEC-RESOLVE-001,ART-SPEC-PREQ-005' -ArchIds 'ART-ARCH-RES-001,ART-ARCH-RES-003,ART-ARCH-RES-004,ART-ARCH-RES-005' -OutputPath 'docs/task-context/ART-TASK-041.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-041.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-041 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-042 - Implement exact WinCondition

- Plane work item ID: `119eb0b7-37b8-4904-aa6b-3663302706e8`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 28

### Objective

Return win only when every enabled ship source, dock and passenger container is empty after settlement.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-016
- ART-TASK-041

### SPEC references

- ART-SPEC-WIN-001

### Architecture references

- ART-ARCH-END-001

### Allowed files

- domain/Rules/EndConditions/WinCondition.cs
- tests/AstroRebelsTraffic.Tests/EndConditions/WinConditionTests.cs

### Exact instructions

1. Check every zone.

2. Check all active or occupied docks.

3. Check main queue and prequeue.

4. Check enabled reserve and VIP state.

5. Reject intermediate/non-settled evaluation in debug/tests.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Each non-empty container independently prevents win.
- Exact all-empty state wins.

### Acceptance criteria

- No visual âno shipsâ shortcut exists.
- Advanced enabled containers are included.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-043 - Implement exact real DeadlockDetector with evidence â integration gate

- Plane work item ID: `ac8244e0-3984-4c91-9700-a6106141a184`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 29

### Objective

Close ART-TASK-043 only after its context, implementation and validation subtasks are Done. This gate performs no implementation.

### Executor

agent:alfredo

### 32K context contract

- Risk class: gate
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-043.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-043-VAL

### SPEC references

- ART-SPEC-LOSE-001
- ART-SPEC-LOSE-002

### Architecture references

- ART-ARCH-END-002
- ART-ARCH-END-003

### Allowed files

- docs/task-context/ART-TASK-043.md

### Exact instructions

1. Confirm ART-TASK-043-CTX, ART-TASK-043-P1, ART-TASK-043-P2 and ART-TASK-043-VAL are Done in Plane.

2. Confirm validation evidence addresses every original acceptance criterion.

3. Record the four subtask IDs and evidence links in the completion comment.

4. Do not read source files or rerun broad commands in this gate.

### Commands

None.

### Validation

- All four required subtasks are Done and none reports an unresolved blocker.

### Acceptance criteria

- The original task closes as a traceability gate without consuming implementation context.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-043-CTX - Build bounded context pack for ART-TASK-043

- Plane work item ID: `c977770f-6cae-4e50-bc1d-c5bd3b80d880`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:tooling`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 124

### Objective

Create the only normative and repository context that ART-TASK-043 may consume.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-032
- ART-TASK-034
- ART-TASK-035
- ART-TASK-036
- ART-TASK-041
- ART-TASK-042
- ART-TASK-000

### SPEC references

- ART-SPEC-LOSE-001
- ART-SPEC-LOSE-002

### Architecture references

- ART-ARCH-END-002
- ART-ARCH-END-003

### Allowed files

- docs/task-context/ART-TASK-043.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-LOSE-001,ART-SPEC-LOSE-002] and ARCH IDs [ART-ARCH-END-002,ART-ARCH-END-003].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-043' -SpecIds 'ART-SPEC-LOSE-001,ART-SPEC-LOSE-002' -ArchIds 'ART-ARCH-END-002,ART-ARCH-END-003' -OutputPath 'docs/task-context/ART-TASK-043.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-043.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-043 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-043-P1 - Implement exact real DeadlockDetector with evidence â atomic implementation phase 1

- Plane work item ID: `72d3c0d8-9538-4963-953e-03ccb791039c`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 125

### Objective

Perform only the first bounded half of ART-TASK-043; do not execute final validation or the remaining steps.

### Executor

agent:alfredo

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-043.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-043-CTX

### SPEC references

- ART-SPEC-LOSE-001
- ART-SPEC-LOSE-002

### Architecture references

- ART-ARCH-END-002
- ART-ARCH-END-003

### Allowed files

- domain/Rules/EndConditions/DeadlockDetector.cs
- domain/Rules/EndConditions/DeadlockEvidence.cs
- tests/AstroRebelsTraffic.Tests/EndConditions/DeadlockTests.cs

### Exact instructions

1. Reject winning and non-settled states.

2. Require every eligible active receiving dock occupied.

3. Use canonical passenger eligibility and boarding queries.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug

### Validation

- Changed files are within the task allowlist and the context pack exact-file list.
- No tool result exceeds 4,000 characters; verbose output is redirected to a file and summarized.
- The phase report lists unfinished original steps explicitly.

### Acceptance criteria

- Phase-one steps are implemented without claiming the original task complete.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-043-P2 - Implement exact real DeadlockDetector with evidence â atomic implementation phase 2

- Plane work item ID: `d3954eaf-7d2d-42e7-a0d9-ae5d640ee5fa`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 126

### Objective

Perform only the remaining bounded half of ART-TASK-043 using phase-one artifacts.

### Executor

agent:alfredo

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-043.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-043-P1

### SPEC references

- ART-SPEC-LOSE-001
- ART-SPEC-LOSE-002

### Architecture references

- ART-ARCH-END-002
- ART-ARCH-END-003

### Allowed files

- domain/Rules/EndConditions/DeadlockDetector.cs
- domain/Rules/EndConditions/DeadlockEvidence.cs
- tests/AstroRebelsTraffic.Tests/EndConditions/DeadlockTests.cs

### Exact instructions

1. Prove no automatic departure can free a dock.

2. Ignore locked rewards and unused boosters.

3. Return evidence for every clause.

### Commands

- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Phase-one artifacts are present and unchanged except for required integration edits.
- Changed files are within the task allowlist and the context pack exact-file list.
- The phase report maps every original instruction to P1 or P2 evidence.

### Acceptance criteria

- All implementation instructions are covered; final acceptance is deferred to the validation phase.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-043-VAL - Implement exact real DeadlockDetector with evidence â bounded validation

- Plane work item ID: `31a3bf75-d9cf-434a-a268-2bebcd3393c2`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:test`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 127

### Objective

Validate ART-TASK-043 without implementing new functionality.

### Executor

agent:alfredo

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-043.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-043-P2

### SPEC references

- ART-SPEC-LOSE-001
- ART-SPEC-LOSE-002

### Architecture references

- ART-ARCH-END-002
- ART-ARCH-END-003

### Allowed files

- domain/Rules/EndConditions/DeadlockDetector.cs
- domain/Rules/EndConditions/DeadlockEvidence.cs
- tests/AstroRebelsTraffic.Tests/EndConditions/DeadlockTests.cs

### Exact instructions

1. Run only the original validation commands with concise output.

2. Record exit codes and the smallest relevant failure output.

3. Check every original acceptance criterion against observable evidence.

4. Do not repair failures; return BLOCKED with the exact failing phase.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Full docks with possible boarding are not loss.
- Full prequeue alone is not loss.
- Exact deadlock fixture loses.
- Locked rewarded docks do not prevent loss.

### Acceptance criteria

- Only this detector declares deadlock.
- No false loss during resolution.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-044 - Implement command contracts and rejection results

- Plane work item ID: `ff97404b-5f62-4b8f-996b-f6dc7d44f7aa`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 30

### Objective

Define immutable commands and CommandResult with accepted/rejected state and ordered events.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-023
- ART-TASK-040

### SPEC references

- ART-SPEC-TERM-001

### Architecture references

- ART-ARCH-CMD-001
- ART-ARCH-CMD-002

### Allowed files

- domain/Commands/**
- tests/AstroRebelsTraffic.Tests/Commands/CommandContractTests.cs

### Exact instructions

1. Implement ReleaseShipCommand first.

2. Define rejection enum.

3. Ensure rejected result returns unchanged state.

4. Define extension commands without enabling TBD behavior.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Command and result types are immutable.
- Rejected results contain no state-changing events.

### Acceptance criteria

- No presentation side effect exists.
- All state changes enter through commands.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-045 - Implement ReleaseShipCommand transaction

- Plane work item ID: `ed3f6a4b-3ded-4cdf-91c5-a068a0b009ad`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 31

### Objective

Validate, release, assign, settle and evaluate one ship selection as one atomic transaction.

### Executor

agent:alfredo

### 32K context contract

- Risk class: context-required
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-045.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-030
- ART-TASK-041
- ART-TASK-043
- ART-TASK-044
- ART-TASK-045-CTX

### SPEC references

- ART-SPEC-SHIP-005
- ART-SPEC-SHIP-007
- ART-SPEC-RESOLVE-002

### Architecture references

- ART-ARCH-CMD-003
- ART-ARCH-CMD-004
- ART-ARCH-RES-002

### Allowed files

- application/GameSession/ReleaseShipHandler.cs
- tests/AstroRebelsTraffic.Tests/Commands/ReleaseShipCommandTests.cs

### Exact instructions

1. Apply validation order exactly.

2. Select dock before mutation.

3. Remove grid occupancy and place ship in selected dock.

4. Run ResolutionSystem to quiescence.

5. Evaluate win then deadlock.

6. Assert invariants before publishing result.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Accepted command produces expected state/events.
- Rejected command is byte-equal and creates no move.
- Win and loss terminal events occur once.

### Acceptance criteria

- Transaction is settled-to-settled.
- No partial state is published.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-045-CTX - Build bounded context pack for ART-TASK-045

- Plane work item ID: `e7bf92b3-b6ae-46fa-8520-c92d15f5bb9e`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:tooling`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 93

### Objective

Create the only normative and repository context that ART-TASK-045 may consume.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-030
- ART-TASK-041
- ART-TASK-043
- ART-TASK-044
- ART-TASK-000

### SPEC references

- ART-SPEC-SHIP-005
- ART-SPEC-SHIP-007
- ART-SPEC-RESOLVE-002

### Architecture references

- ART-ARCH-CMD-003
- ART-ARCH-CMD-004
- ART-ARCH-RES-002

### Allowed files

- docs/task-context/ART-TASK-045.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-SHIP-005,ART-SPEC-SHIP-007,ART-SPEC-RESOLVE-002] and ARCH IDs [ART-ARCH-CMD-003,ART-ARCH-CMD-004,ART-ARCH-RES-002].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-045' -SpecIds 'ART-SPEC-SHIP-005,ART-SPEC-SHIP-007,ART-SPEC-RESOLVE-002' -ArchIds 'ART-ARCH-CMD-003,ART-ARCH-CMD-004,ART-ARCH-RES-002' -OutputPath 'docs/task-context/ART-TASK-045.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-045.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-045 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-046 - Implement GameSession command gate and move index

- Plane work item ID: `7e895914-6f6d-425a-b2c4-1127fdcbc3ce`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 32

### Objective

Own the one authoritative runtime GameState and prevent concurrent gameplay commands.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-045

### SPEC references

- ART-SPEC-RESOLVE-002

### Architecture references

- ART-ARCH-DEP-003
- ART-ARCH-CMD-005
- ART-ARCH-SCENE-004

### Allowed files

- application/GameSession/GameSession.cs
- tests/AstroRebelsTraffic.Tests/Application/GameSessionTests.cs

### Exact instructions

1. Accept one command at a time.

2. Increment move index only for accepted player moves.

3. Reject commands after WON/LOST.

4. Expose settled result/events without exposing mutable state.

5. Do not use a global autoload for GameState.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Concurrent-command test accepts at most one mutation.
- Invalid taps do not increment move index.

### Acceptance criteria

- One authoritative state exists.
- Session is usable headlessly by tests and solver.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-047 - Implement complete Undo snapshots

- Plane work item ID: `1ecaa476-025f-4e37-a170-39420079efc6`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:planned`
- Module: Unassigned
- Plane sequence: 33

### Objective

Store a full pre-move settled snapshot and restore it exactly when the Undo booster is enabled.

### Executor

agent:alfredo

### 32K context contract

- Risk class: context-required
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-047.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-018
- ART-TASK-046
- ART-TASK-047-CTX

### SPEC references

- ART-SPEC-ADV-005
- ART-SPEC-ADV-006

### Architecture references

- ART-ARCH-UNDO-001
- ART-ARCH-UNDO-002
- ART-ARCH-UNDO-003

### Allowed files

- application/Undo/**
- tests/AstroRebelsTraffic.Tests/Undo/UndoTests.cs

### Exact instructions

1. Snapshot only before accepted player mutation.

2. Store at least one snapshot.

3. Do not snapshot rejected commands.

4. Restore complete canonical state and validate invariants.

5. Clear interrupted presentation via an application event.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Undo restores canonical byte equality.
- All required fields from ART-SPEC-ADV-006 restore.
- Rejected move leaves history unchanged.

### Acceptance criteria

- Baseline solver ignores undo.
- Multi-step policy remains TBD and unimplemented.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-047-CTX - Build bounded context pack for ART-TASK-047

- Plane work item ID: `7d83f66c-8c1f-4799-8477-bd6fe9f0af26`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:alfredo`
- Type: `type:tooling`
- Scope: `scope:planned`
- Module: Unassigned
- Plane sequence: 94

### Objective

Create the only normative and repository context that ART-TASK-047 may consume.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-018
- ART-TASK-046
- ART-TASK-000

### SPEC references

- ART-SPEC-ADV-005
- ART-SPEC-ADV-006

### Architecture references

- ART-ARCH-UNDO-001
- ART-ARCH-UNDO-002
- ART-ARCH-UNDO-003

### Allowed files

- docs/task-context/ART-TASK-047.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-ADV-005,ART-SPEC-ADV-006] and ARCH IDs [ART-ARCH-UNDO-001,ART-ARCH-UNDO-002,ART-ARCH-UNDO-003].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-047' -SpecIds 'ART-SPEC-ADV-005,ART-SPEC-ADV-006' -ArchIds 'ART-ARCH-UNDO-001,ART-ARCH-UNDO-002,ART-ARCH-UNDO-003' -OutputPath 'docs/task-context/ART-TASK-047.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-047.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-047 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-050 - Define versioned LevelDefinition DTOs and JSON schema

- Plane work item ID: `64507119-a6ef-4077-881c-0b36daf4d4dc`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:data`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 34

### Objective

Define schema version 1 for zones, ships, docks, queues, mechanics and metadata without scene paths.

### Executor

agent:alfredo

### 32K context contract

- Risk class: context-required
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-050.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-017
- ART-TASK-050-CTX

### SPEC references

- ART-SPEC-LEVEL-001

### Architecture references

- ART-ARCH-LEVEL-001
- ART-ARCH-LEVEL-004

### Allowed files

- levels/Schema/**
- levels/schema/astro-rebels-level-v1.schema.json
- tests/AstroRebelsTraffic.Tests/Levels/SchemaTests.cs

### Exact instructions

1. Map every field in ART-ARCH-LEVEL-001.

2. Require stable IDs and canonical enums.

3. Default prequeue capacity to 16 only when absent.

4. Keep presentation asset catalogs separate.

5. Reject unknown required mechanic fields.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Valid minimal fixture passes JSON schema.
- Missing/unknown-invalid fixtures fail with field paths.

### Acceptance criteria

- Schema is versioned.
- No provider or Node data appears.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-050-CTX - Build bounded context pack for ART-TASK-050

- Plane work item ID: `b00272d6-c4fe-4c27-9505-0c4e9fc72ff7`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:tooling`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 95

### Objective

Create the only normative and repository context that ART-TASK-050 may consume.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-017
- ART-TASK-000

### SPEC references

- ART-SPEC-LEVEL-001

### Architecture references

- ART-ARCH-LEVEL-001
- ART-ARCH-LEVEL-004

### Allowed files

- docs/task-context/ART-TASK-050.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-LEVEL-001] and ARCH IDs [ART-ARCH-LEVEL-001,ART-ARCH-LEVEL-004].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-050' -SpecIds 'ART-SPEC-LEVEL-001' -ArchIds 'ART-ARCH-LEVEL-001,ART-ARCH-LEVEL-004' -OutputPath 'docs/task-context/ART-TASK-050.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-050.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-050 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-051 - Implement LevelLoader with structured errors

- Plane work item ID: `8d32d5e3-fe2b-426a-99a6-ccd05d7cf3e0`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 35

### Objective

Parse level JSON, apply authorized defaults, and construct canonical initial GameState or structured errors.

### Executor

agent:alfredo

### 32K context contract

- Risk class: context-required
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-051.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-050
- ART-TASK-018
- ART-TASK-051-CTX

### SPEC references

- ART-SPEC-LEVEL-001

### Architecture references

- ART-ARCH-LEVEL-002

### Allowed files

- levels/Loader/LevelLoader.cs
- levels/Loader/LevelLoadError.cs
- tests/AstroRebelsTraffic.Tests/Levels/LevelLoaderTests.cs

### Exact instructions

1. Parse schema version first.

2. Never guess unknown enum or ID.

3. Use canonical state constructors.

4. Return all actionable field paths.

5. Do not open a gameplay scene on failure.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Valid fixture constructs expected state.
- Malformed JSON and semantic errors return structured failures.

### Acceptance criteria

- No exception escapes for bad content.
- Loader uses no presentation data.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-051-CTX - Build bounded context pack for ART-TASK-051

- Plane work item ID: `84baa0d9-8b4c-419e-8b62-bf184ffbd14f`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:tooling`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 96

### Objective

Create the only normative and repository context that ART-TASK-051 may consume.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-050
- ART-TASK-018
- ART-TASK-000

### SPEC references

- ART-SPEC-LEVEL-001

### Architecture references

- ART-ARCH-LEVEL-002

### Allowed files

- docs/task-context/ART-TASK-051.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-LEVEL-001] and ARCH IDs [ART-ARCH-LEVEL-002].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-051' -SpecIds 'ART-SPEC-LEVEL-001' -ArchIds 'ART-ARCH-LEVEL-002' -OutputPath 'docs/task-context/ART-TASK-051.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-051.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-051 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-052 - Implement complete LevelValidator â integration gate

- Plane work item ID: `d6c763af-1359-46c8-b4e1-bede186809d1`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:test`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 36

### Objective

Close ART-TASK-052 only after its context, implementation and validation subtasks are Done. This gate performs no implementation.

### Executor

agent:alfredo

### 32K context contract

- Risk class: gate
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-052.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-052-VAL

### SPEC references

- ART-SPEC-QUEUE-003
- ART-SPEC-LEVEL-002

### Architecture references

- ART-ARCH-LEVEL-003

### Allowed files

- docs/task-context/ART-TASK-052.md

### Exact instructions

1. Confirm ART-TASK-052-CTX, ART-TASK-052-P1, ART-TASK-052-P2 and ART-TASK-052-VAL are Done in Plane.

2. Confirm validation evidence addresses every original acceptance criterion.

3. Record the four subtask IDs and evidence links in the completion comment.

4. Do not read source files or rerun broad commands in this gate.

### Commands

None.

### Validation

- All four required subtasks are Done and none reports an unresolved blocker.

### Acceptance criteria

- The original task closes as a traceability gate without consuming implementation context.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-052-CTX - Build bounded context pack for ART-TASK-052

- Plane work item ID: `7d1f56b0-0fc0-4380-8287-4c48e83c0609`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:tooling`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 128

### Objective

Create the only normative and repository context that ART-TASK-052 may consume.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-051
- ART-TASK-022
- ART-TASK-043
- ART-TASK-000

### SPEC references

- ART-SPEC-QUEUE-003
- ART-SPEC-LEVEL-002

### Architecture references

- ART-ARCH-LEVEL-003

### Allowed files

- docs/task-context/ART-TASK-052.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-QUEUE-003,ART-SPEC-LEVEL-002] and ARCH IDs [ART-ARCH-LEVEL-003].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-052' -SpecIds 'ART-SPEC-QUEUE-003,ART-SPEC-LEVEL-002' -ArchIds 'ART-ARCH-LEVEL-003' -OutputPath 'docs/task-context/ART-TASK-052.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-052.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-052 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-052-P1 - Implement complete LevelValidator â atomic implementation phase 1

- Plane work item ID: `fd7f485f-fb25-45ca-8cf4-a896c44fa1e8`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:test`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 129

### Objective

Perform only the first bounded half of ART-TASK-052; do not execute final validation or the remaining steps.

### Executor

agent:alfredo

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-052.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-052-CTX

### SPEC references

- ART-SPEC-QUEUE-003
- ART-SPEC-LEVEL-002

### Architecture references

- ART-ARCH-LEVEL-003

### Allowed files

- levels/Validator/LevelValidator.cs
- tests/AstroRebelsTraffic.Tests/Levels/LevelValidatorTests.cs

### Exact instructions

1. Implement every bullet in ART-ARCH-LEVEL-003.

2. Check per-color passengers equal total ship capacity including reserve.

3. Check footprints, overlaps and bounds.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug

### Validation

- Changed files are within the task allowlist and the context pack exact-file list.
- No tool result exceeds 4,000 characters; verbose output is redirected to a file and summarized.
- The phase report lists unfinished original steps explicitly.

### Acceptance criteria

- Phase-one steps are implemented without claiming the original task complete.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-052-P2 - Implement complete LevelValidator â atomic implementation phase 2

- Plane work item ID: `5ef1c09d-b3bc-48c2-8d1e-3ccde911bd1c`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:test`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 130

### Objective

Perform only the remaining bounded half of ART-TASK-052 using phase-one artifacts.

### Executor

agent:alfredo

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-052.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-052-P1

### SPEC references

- ART-SPEC-QUEUE-003
- ART-SPEC-LEVEL-002

### Architecture references

- ART-ARCH-LEVEL-003

### Allowed files

- levels/Validator/LevelValidator.cs
- tests/AstroRebelsTraffic.Tests/Levels/LevelValidatorTests.cs

### Exact instructions

1. Require exactly 4 base and 4 rewarded docks.

2. Separate structural validity from solver solvability result.

### Commands

- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Phase-one artifacts are present and unchanged except for required integration edits.
- Changed files are within the task allowlist and the context pack exact-file list.
- The phase report maps every original instruction to P1 or P2 evidence.

### Acceptance criteria

- All implementation instructions are covered; final acceptance is deferred to the validation phase.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-052-VAL - Implement complete LevelValidator â bounded validation

- Plane work item ID: `7368581e-fbb6-4431-90ad-17d7c18f7d21`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:test`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 131

### Objective

Validate ART-TASK-052 without implementing new functionality.

### Executor

agent:alfredo

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-052.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-052-P2

### SPEC references

- ART-SPEC-QUEUE-003
- ART-SPEC-LEVEL-002

### Architecture references

- ART-ARCH-LEVEL-003

### Allowed files

- levels/Validator/LevelValidator.cs
- tests/AstroRebelsTraffic.Tests/Levels/LevelValidatorTests.cs

### Exact instructions

1. Run only the original validation commands with concise output.

2. Record exit codes and the smallest relevant failure output.

3. Check every original acceptance criterion against observable evidence.

4. Do not repair failures; return BLOCKED with the exact failing phase.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- One fixture fails each validation rule with exact code/path.
- Valid fixtures return no errors.

### Acceptance criteria

- Invalid production level cannot load as playable.
- Validation order is deterministic.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-053 - Create canonical core level fixtures â integration gate

- Plane work item ID: `b3423608-1060-40ec-a25b-2cde1c995365`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:sofia`
- Type: `type:data`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 37

### Objective

Close ART-TASK-053 only after its context, implementation and validation subtasks are Done. This gate performs no implementation.

### Executor

agent:sofia

### 32K context contract

- Risk class: gate
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-053.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-053-VAL

### SPEC references

- ART-SPEC-TUT-002
- ART-SPEC-LEVEL-003

### Architecture references

- ART-ARCH-TEST-002

### Allowed files

- docs/task-context/ART-TASK-053.md

### Exact instructions

1. Confirm ART-TASK-053-CTX, ART-TASK-053-P1, ART-TASK-053-P2 and ART-TASK-053-VAL are Done in Plane.

2. Confirm validation evidence addresses every original acceptance criterion.

3. Record the four subtask IDs and evidence links in the completion comment.

4. Do not read source files or rerun broad commands in this gate.

### Commands

None.

### Validation

- All four required subtasks are Done and none reports an unresolved blocker.

### Acceptance criteria

- The original task closes as a traceability gate without consuming implementation context.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-053-CTX - Build bounded context pack for ART-TASK-053

- Plane work item ID: `b9eb22b7-fb14-4940-b84f-6847bdc8bff7`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:sofia`
- Type: `type:tooling`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 132

### Objective

Create the only normative and repository context that ART-TASK-053 may consume.

### Executor

agent:sofia

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-052
- ART-TASK-000

### SPEC references

- ART-SPEC-TUT-002
- ART-SPEC-LEVEL-003

### Architecture references

- ART-ARCH-TEST-002

### Allowed files

- docs/task-context/ART-TASK-053.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-TUT-002,ART-SPEC-LEVEL-003] and ARCH IDs [ART-ARCH-TEST-002].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-053' -SpecIds 'ART-SPEC-TUT-002,ART-SPEC-LEVEL-003' -ArchIds 'ART-ARCH-TEST-002' -OutputPath 'docs/task-context/ART-TASK-053.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-053.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-053 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-053-P1 - Create canonical core level fixtures â atomic implementation phase 1

- Plane work item ID: `a0607b7e-4cfd-4806-8aed-1f2f5338d197`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:sofia`
- Type: `type:data`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 133

### Objective

Perform only the first bounded half of ART-TASK-053; do not execute final validation or the remaining steps.

### Executor

agent:sofia

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-053.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-053-CTX

### SPEC references

- ART-SPEC-TUT-002
- ART-SPEC-LEVEL-003

### Architecture references

- ART-ARCH-TEST-002

### Allowed files

- tests/fixtures/levels/core/**

### Exact instructions

1. Create clear/blocked ship fixtures.

2. Create dock-priority and group-split fixtures.

3. Create prequeue order/capacity fixtures.

### Commands

- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Changed files are within the task allowlist and the context pack exact-file list.
- No tool result exceeds 4,000 characters; verbose output is redirected to a file and summarized.
- The phase report lists unfinished original steps explicitly.

### Acceptance criteria

- Phase-one steps are implemented without claiming the original task complete.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-053-P2 - Create canonical core level fixtures â atomic implementation phase 2

- Plane work item ID: `c695eaa7-5e80-4cdc-9d65-a81840dbda1c`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:sofia`
- Type: `type:data`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 134

### Objective

Perform only the remaining bounded half of ART-TASK-053 using phase-one artifacts.

### Executor

agent:sofia

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-053.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-053-P1

### SPEC references

- ART-SPEC-TUT-002
- ART-SPEC-LEVEL-003

### Architecture references

- ART-ARCH-TEST-002

### Allowed files

- tests/fixtures/levels/core/**

### Exact instructions

1. Create win and real-deadlock fixtures.

2. Keep each fixture minimal and name its expected result.

### Commands

None.

### Validation

- Phase-one artifacts are present and unchanged except for required integration edits.
- Changed files are within the task allowlist and the context pack exact-file list.
- The phase report maps every original instruction to P1 or P2 evidence.

### Acceptance criteria

- All implementation instructions are covered; final acceptance is deferred to the validation phase.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-053-VAL - Create canonical core level fixtures â bounded validation

- Plane work item ID: `7d2f59f5-d4b0-42cf-a570-82004a3688c2`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:sofia`
- Type: `type:test`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 135

### Objective

Validate ART-TASK-053 without implementing new functionality.

### Executor

agent:sofia

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-053.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-053-P2

### SPEC references

- ART-SPEC-TUT-002
- ART-SPEC-LEVEL-003

### Architecture references

- ART-ARCH-TEST-002

### Allowed files

- tests/fixtures/levels/core/**

### Exact instructions

1. Run only the original validation commands with concise output.

2. Record exit codes and the smallest relevant failure output.

3. Check every original acceptance criterion against observable evidence.

4. Do not repair failures; return BLOCKED with the exact failing phase.

### Commands

- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Every fixture loads and validates or intentionally fails its named rule.
- No fixture depends on ads or boosters.

### Acceptance criteria

- Fixtures cover ART-ARCH-TEST-002 items 1â14.
- Expected outcomes are machine-readable.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-054 - Implement production level manifest gate â integration gate

- Plane work item ID: `dad53f85-4a19-496e-ba37-6d070feaacc8`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:alfredo`
- Type: `type:tooling`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 38

### Objective

Close ART-TASK-054 only after its context, implementation and validation subtasks are Done. This gate performs no implementation.

### Executor

agent:alfredo

### 32K context contract

- Risk class: gate
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-054.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-054-VAL

### SPEC references

- ART-SPEC-LEVEL-002
- ART-SPEC-LEVEL-006

### Architecture references

- ART-ARCH-LEVEL-005

### Allowed files

- docs/task-context/ART-TASK-054.md

### Exact instructions

1. Confirm ART-TASK-054-CTX, ART-TASK-054-P1, ART-TASK-054-P2 and ART-TASK-054-VAL are Done in Plane.

2. Confirm validation evidence addresses every original acceptance criterion.

3. Record the four subtask IDs and evidence links in the completion comment.

4. Do not read source files or rerun broad commands in this gate.

### Commands

None.

### Validation

- All four required subtasks are Done and none reports an unresolved blocker.

### Acceptance criteria

- The original task closes as a traceability gate without consuming implementation context.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-054-CTX - Build bounded context pack for ART-TASK-054

- Plane work item ID: `f00cee9c-c35b-4d73-8be9-6388e2c6abd1`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:alfredo`
- Type: `type:tooling`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 136

### Objective

Create the only normative and repository context that ART-TASK-054 may consume.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-052
- ART-TASK-060
- ART-TASK-000

### SPEC references

- ART-SPEC-LEVEL-002
- ART-SPEC-LEVEL-006

### Architecture references

- ART-ARCH-LEVEL-005

### Allowed files

- docs/task-context/ART-TASK-054.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-LEVEL-002,ART-SPEC-LEVEL-006] and ARCH IDs [ART-ARCH-LEVEL-005].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-054' -SpecIds 'ART-SPEC-LEVEL-002,ART-SPEC-LEVEL-006' -ArchIds 'ART-ARCH-LEVEL-005' -OutputPath 'docs/task-context/ART-TASK-054.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-054.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-054 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-054-P1 - Implement production level manifest gate â atomic implementation phase 1

- Plane work item ID: `ee84bbbc-9c71-4f19-96eb-fdaa48d0847b`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:alfredo`
- Type: `type:tooling`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 137

### Objective

Perform only the first bounded half of ART-TASK-054; do not execute final validation or the remaining steps.

### Executor

agent:alfredo

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-054.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-054-CTX

### SPEC references

- ART-SPEC-LEVEL-002
- ART-SPEC-LEVEL-006

### Architecture references

- ART-ARCH-LEVEL-005

### Allowed files

- levels/ProductionManifest/**
- tools/Validation/**
- tests/AstroRebelsTraffic.Tests/Levels/ProductionManifestTests.cs

### Exact instructions

1. Define candidate and production locations.

2. Require validator success and solver result with no assistance.

3. Require human_reviewed=true metadata.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug

### Validation

- Changed files are within the task allowlist and the context pack exact-file list.
- No tool result exceeds 4,000 characters; verbose output is redirected to a file and summarized.
- The phase report lists unfinished original steps explicitly.

### Acceptance criteria

- Phase-one steps are implemented without claiming the original task complete.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-054-P2 - Implement production level manifest gate â atomic implementation phase 2

- Plane work item ID: `8f633fdc-bee8-4053-8b12-460bada57c5b`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:alfredo`
- Type: `type:tooling`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 138

### Objective

Perform only the remaining bounded half of ART-TASK-054 using phase-one artifacts.

### Executor

agent:alfredo

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-054.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-054-P1

### SPEC references

- ART-SPEC-LEVEL-002
- ART-SPEC-LEVEL-006

### Architecture references

- ART-ARCH-LEVEL-005

### Allowed files

- levels/ProductionManifest/**
- tools/Validation/**
- tests/AstroRebelsTraffic.Tests/Levels/ProductionManifestTests.cs

### Exact instructions

1. Emit a deterministic validation report.

2. Fail build on invalid manifest entry.

### Commands

- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Phase-one artifacts are present and unchanged except for required integration edits.
- Changed files are within the task allowlist and the context pack exact-file list.
- The phase report maps every original instruction to P1 or P2 evidence.

### Acceptance criteria

- All implementation instructions are covered; final acceptance is deferred to the validation phase.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-054-VAL - Implement production level manifest gate â bounded validation

- Plane work item ID: `f785ccb5-7240-4cc8-aac4-0d6bb5c72635`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:alfredo`
- Type: `type:test`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 139

### Objective

Validate ART-TASK-054 without implementing new functionality.

### Executor

agent:alfredo

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-054.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-054-P2

### SPEC references

- ART-SPEC-LEVEL-002
- ART-SPEC-LEVEL-006

### Architecture references

- ART-ARCH-LEVEL-005

### Allowed files

- levels/ProductionManifest/**
- tools/Validation/**
- tests/AstroRebelsTraffic.Tests/Levels/ProductionManifestTests.cs

### Exact instructions

1. Run only the original validation commands with concise output.

2. Record exit codes and the smallest relevant failure output.

3. Check every original acceptance criterion against observable evidence.

4. Do not repair failures; return BLOCKED with the exact failing phase.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Manifest gate rejects unsolved, invalid or unreviewed candidates.
- Valid approved fixture passes.

### Acceptance criteria

- Generator cannot publish directly.
- Build gate is automated.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-060 - Implement canonical StateHasher and equality

- Plane work item ID: `f8c1e2cb-c5d0-47bc-bc74-cb4250725e49`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 39

### Objective

Hash all and only rule-relevant canonical state and confirm equality after hash matches.

### Executor

agent:alfredo

### 32K context contract

- Risk class: context-required
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-060.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-018
- ART-TASK-046
- ART-TASK-060-CTX

### SPEC references

- ART-SPEC-QA-001
- ART-SPEC-QA-002

### Architecture references

- ART-ARCH-SOLVER-003

### Allowed files

- solver/Hashing/StateHasher.cs
- solver/Hashing/StateEquality.cs
- tests/AstroRebelsTraffic.Tests/Solver/StateHasherTests.cs

### Exact instructions

1. Include every field listed in ART-ARCH-SOLVER-003.

2. Exclude presentation, analytics, clocks and undo history.

3. Canonicalize collection order.

4. Use collision-safe equality confirmation.

5. Create golden hashes for fixtures.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Equivalent states hash/equal.
- Every rule-relevant one-field change changes equality.
- Presentation-only metadata has no effect.

### Acceptance criteria

- Hash is stable across runs.
- Hashing uses canonical GameState only.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-060-CTX - Build bounded context pack for ART-TASK-060

- Plane work item ID: `89d2ef95-e033-43fc-92e9-16f2c968d746`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:tooling`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 97

### Objective

Create the only normative and repository context that ART-TASK-060 may consume.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-018
- ART-TASK-046
- ART-TASK-000

### SPEC references

- ART-SPEC-QA-001
- ART-SPEC-QA-002

### Architecture references

- ART-ARCH-SOLVER-003

### Allowed files

- docs/task-context/ART-TASK-060.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-QA-001,ART-SPEC-QA-002] and ARCH IDs [ART-ARCH-SOLVER-003].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-060' -SpecIds 'ART-SPEC-QA-001,ART-SPEC-QA-002' -ArchIds 'ART-ARCH-SOLVER-003' -OutputPath 'docs/task-context/ART-TASK-060.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-060.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-060 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-061 - Implement legal action enumeration

- Plane work item ID: `2e879c6d-03ca-4279-aa36-f2dc0254bce5`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 40

### Objective

Enumerate accepted ReleaseShip commands from a settled core state without assistance actions.

### Executor

agent:alfredo

### 32K context contract

- Risk class: context-required
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-061.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-045
- ART-TASK-052
- ART-TASK-061-CTX

### SPEC references

- ART-SPEC-LEVEL-002

### Architecture references

- ART-ARCH-SOLVER-001
- ART-ARCH-SOLVER-002

### Allowed files

- solver/Search/LegalActionEnumerator.cs
- tests/AstroRebelsTraffic.Tests/Solver/LegalActionTests.cs

### Exact instructions

1. Inspect every grid ship in stable zone/ship order.

2. Validate through the same command handler.

3. Exclude rejected releases, ads, boosters, restart and presentation.

4. Return deterministic command order.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Enumerator matches brute-force accepted commands.
- No assistance command appears.

### Acceptance criteria

- Runtime and solver share validation.
- Enumeration order is stable.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-061-CTX - Build bounded context pack for ART-TASK-061

- Plane work item ID: `6622ce38-69ff-4408-ab7d-06ce07eadc7d`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:tooling`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 98

### Objective

Create the only normative and repository context that ART-TASK-061 may consume.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-045
- ART-TASK-052
- ART-TASK-000

### SPEC references

- ART-SPEC-LEVEL-002

### Architecture references

- ART-ARCH-SOLVER-001
- ART-ARCH-SOLVER-002

### Allowed files

- docs/task-context/ART-TASK-061.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-LEVEL-002] and ARCH IDs [ART-ARCH-SOLVER-001,ART-ARCH-SOLVER-002].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-061' -SpecIds 'ART-SPEC-LEVEL-002' -ArchIds 'ART-ARCH-SOLVER-001,ART-ARCH-SOLVER-002' -OutputPath 'docs/task-context/ART-TASK-061.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-061.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-061 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-062 - Implement bounded baseline solver â integration gate

- Plane work item ID: `9d5743ae-3cff-4e2d-bb01-31d79bcee403`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 41

### Objective

Close ART-TASK-062 only after its context, implementation and validation subtasks are Done. This gate performs no implementation.

### Executor

agent:alfredo

### 32K context contract

- Risk class: gate
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-062.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-062-VAL

### SPEC references

- ART-SPEC-LEVEL-002

### Architecture references

- ART-ARCH-SOLVER-001
- ART-ARCH-SOLVER-004
- ART-ARCH-SOLVER-005

### Allowed files

- docs/task-context/ART-TASK-062.md

### Exact instructions

1. Confirm ART-TASK-062-CTX, ART-TASK-062-P1, ART-TASK-062-P2 and ART-TASK-062-VAL are Done in Plane.

2. Confirm validation evidence addresses every original acceptance criterion.

3. Record the four subtask IDs and evidence links in the completion comment.

4. Do not read source files or rerun broad commands in this gate.

### Commands

None.

### Validation

- All four required subtasks are Done and none reports an unresolved blocker.

### Acceptance criteria

- The original task closes as a traceability gate without consuming implementation context.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-062-CTX - Build bounded context pack for ART-TASK-062

- Plane work item ID: `cdf0829c-8199-4bc3-973e-53b55c8f774b`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:tooling`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 140

### Objective

Create the only normative and repository context that ART-TASK-062 may consume.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-060
- ART-TASK-061
- ART-TASK-000

### SPEC references

- ART-SPEC-LEVEL-002

### Architecture references

- ART-ARCH-SOLVER-001
- ART-ARCH-SOLVER-004
- ART-ARCH-SOLVER-005

### Allowed files

- docs/task-context/ART-TASK-062.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-LEVEL-002] and ARCH IDs [ART-ARCH-SOLVER-001,ART-ARCH-SOLVER-004,ART-ARCH-SOLVER-005].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-062' -SpecIds 'ART-SPEC-LEVEL-002' -ArchIds 'ART-ARCH-SOLVER-001,ART-ARCH-SOLVER-004,ART-ARCH-SOLVER-005' -OutputPath 'docs/task-context/ART-TASK-062.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-062.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-062 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-062-P1 - Implement bounded baseline solver â atomic implementation phase 1

- Plane work item ID: `2b587e98-1d99-4cdb-9aee-02f68fe77943`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 141

### Objective

Perform only the first bounded half of ART-TASK-062; do not execute final validation or the remaining steps.

### Executor

agent:alfredo

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-062.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-062-CTX

### SPEC references

- ART-SPEC-LEVEL-002

### Architecture references

- ART-ARCH-SOLVER-001
- ART-ARCH-SOLVER-004
- ART-ARCH-SOLVER-005

### Allowed files

- solver/Search/Solver.cs
- solver/Search/SolverOptions.cs
- solver/Search/SolverResult.cs
- tests/AstroRebelsTraffic.Tests/Solver/SolverTests.cs

### Exact instructions

1. Start with BFS for minimal core fixtures unless evidence requires another strategy.

2. Deduplicate with StateHasher plus equality.

3. Execute actions through GameSession/command handler.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug

### Validation

- Changed files are within the task allowlist and the context pack exact-file list.
- No tool result exceeds 4,000 characters; verbose output is redirected to a file and summarized.
- The phase report lists unfinished original steps explicitly.

### Acceptance criteria

- Phase-one steps are implemented without claiming the original task complete.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-062-P2 - Implement bounded baseline solver â atomic implementation phase 2

- Plane work item ID: `6ddcf209-2efe-4f39-8353-2a3c6a41b2d2`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 142

### Objective

Perform only the remaining bounded half of ART-TASK-062 using phase-one artifacts.

### Executor

agent:alfredo

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-062.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-062-P1

### SPEC references

- ART-SPEC-LEVEL-002

### Architecture references

- ART-ARCH-SOLVER-001
- ART-ARCH-SOLVER-004
- ART-ARCH-SOLVER-005

### Allowed files

- solver/Search/Solver.cs
- solver/Search/SolverOptions.cs
- solver/Search/SolverResult.cs
- tests/AstroRebelsTraffic.Tests/Solver/SolverTests.cs

### Exact instructions

1. Treat deadlock as terminal failure and win as success.

2. Honor explicit state/time budgets and cancellation.

3. Never label budget exhaustion unsolvable.

### Commands

- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Phase-one artifacts are present and unchanged except for required integration edits.
- Changed files are within the task allowlist and the context pack exact-file list.
- The phase report maps every original instruction to P1 or P2 evidence.

### Acceptance criteria

- All implementation instructions are covered; final acceptance is deferred to the validation phase.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-062-VAL - Implement bounded baseline solver â bounded validation

- Plane work item ID: `bddc5ea2-fa1d-4d10-976a-9a1100440f3e`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:alfredo`
- Type: `type:test`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 143

### Objective

Validate ART-TASK-062 without implementing new functionality.

### Executor

agent:alfredo

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-062.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-062-P2

### SPEC references

- ART-SPEC-LEVEL-002

### Architecture references

- ART-ARCH-SOLVER-001
- ART-ARCH-SOLVER-004
- ART-ARCH-SOLVER-005

### Allowed files

- solver/Search/Solver.cs
- solver/Search/SolverOptions.cs
- solver/Search/SolverResult.cs
- tests/AstroRebelsTraffic.Tests/Solver/SolverTests.cs

### Exact instructions

1. Run only the original validation commands with concise output.

2. Record exit codes and the smallest relevant failure output.

3. Check every original acceptance criterion against observable evidence.

4. Do not repair failures; return BLOCKED with the exact failing phase.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Known solvable fixture returns a valid replayable sequence.
- Known dead fixture returns unsolvable.
- Low budget returns unknown.

### Acceptance criteria

- Solution uses no assistance.
- Command replay reaches exact win.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-063 - Add runtime-versus-solver transition parity suite â integration gate

- Plane work item ID: `16435f63-9020-4ae2-981d-b6b2cb1301f1`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:sofia`
- Type: `type:test`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 42

### Objective

Close ART-TASK-063 only after its context, implementation and validation subtasks are Done. This gate performs no implementation.

### Executor

agent:sofia

### 32K context contract

- Risk class: gate
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-063.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-063-VAL

### SPEC references

- ART-SPEC-QA-002

### Architecture references

- ART-ARCH-TEST-003

### Allowed files

- docs/task-context/ART-TASK-063.md

### Exact instructions

1. Confirm ART-TASK-063-CTX, ART-TASK-063-P1, ART-TASK-063-P2 and ART-TASK-063-VAL are Done in Plane.

2. Confirm validation evidence addresses every original acceptance criterion.

3. Record the four subtask IDs and evidence links in the completion comment.

4. Do not read source files or rerun broad commands in this gate.

### Commands

None.

### Validation

- All four required subtasks are Done and none reports an unresolved blocker.

### Acceptance criteria

- The original task closes as a traceability gate without consuming implementation context.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-063-CTX - Build bounded context pack for ART-TASK-063

- Plane work item ID: `e7249e31-79d1-4df3-a780-008500cd8b24`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:sofia`
- Type: `type:tooling`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 144

### Objective

Create the only normative and repository context that ART-TASK-063 may consume.

### Executor

agent:sofia

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-062
- ART-TASK-000

### SPEC references

- ART-SPEC-QA-002

### Architecture references

- ART-ARCH-TEST-003

### Allowed files

- docs/task-context/ART-TASK-063.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-QA-002] and ARCH IDs [ART-ARCH-TEST-003].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-063' -SpecIds 'ART-SPEC-QA-002' -ArchIds 'ART-ARCH-TEST-003' -OutputPath 'docs/task-context/ART-TASK-063.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-063.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-063 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-063-P1 - Add runtime-versus-solver transition parity suite â atomic implementation phase 1

- Plane work item ID: `ca47335a-d6d4-4a02-a204-a84b92a5c02b`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:sofia`
- Type: `type:test`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 145

### Objective

Perform only the first bounded half of ART-TASK-063; do not execute final validation or the remaining steps.

### Executor

agent:sofia

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-063.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-063-CTX

### SPEC references

- ART-SPEC-QA-002

### Architecture references

- ART-ARCH-TEST-003

### Allowed files

- tests/AstroRebelsTraffic.Tests/Solver/TransitionParityTests.cs

### Exact instructions

1. Load canonical fixtures.

2. Execute each legal and selected illegal command by both entry paths.

### Commands

- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Changed files are within the task allowlist and the context pack exact-file list.
- No tool result exceeds 4,000 characters; verbose output is redirected to a file and summarized.
- The phase report lists unfinished original steps explicitly.

### Acceptance criteria

- Phase-one steps are implemented without claiming the original task complete.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-063-P2 - Add runtime-versus-solver transition parity suite â atomic implementation phase 2

- Plane work item ID: `7c73fec6-5b04-4984-bc8e-4fce2103f8d7`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:sofia`
- Type: `type:test`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 146

### Objective

Perform only the remaining bounded half of ART-TASK-063 using phase-one artifacts.

### Executor

agent:sofia

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-063.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-063-P1

### SPEC references

- ART-SPEC-QA-002

### Architecture references

- ART-ARCH-TEST-003

### Allowed files

- tests/AstroRebelsTraffic.Tests/Solver/TransitionParityTests.cs

### Exact instructions

1. Compare acceptance, rejection, canonical serialization and ordered events.

2. Print fixture and command on failure.

### Commands

None.

### Validation

- Phase-one artifacts are present and unchanged except for required integration edits.
- Changed files are within the task allowlist and the context pack exact-file list.
- The phase report maps every original instruction to P1 or P2 evidence.

### Acceptance criteria

- All implementation instructions are covered; final acceptance is deferred to the validation phase.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-063-VAL - Add runtime-versus-solver transition parity suite â bounded validation

- Plane work item ID: `f0673d31-7890-4a8e-896b-1f6d39f85dae`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:sofia`
- Type: `type:test`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 147

### Objective

Validate ART-TASK-063 without implementing new functionality.

### Executor

agent:sofia

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-063.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-063-P2

### SPEC references

- ART-SPEC-QA-002

### Architecture references

- ART-ARCH-TEST-003

### Allowed files

- tests/AstroRebelsTraffic.Tests/Solver/TransitionParityTests.cs

### Exact instructions

1. Run only the original validation commands with concise output.

2. Record exit codes and the smallest relevant failure output.

3. Check every original acceptance criterion against observable evidence.

4. Do not repair failures; return BLOCKED with the exact failing phase.

### Commands

- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Parity passes for every core fixture.
- No solver-only rule implementation exists.

### Acceptance criteria

- One canonical game is demonstrated.
- Failures are reproducible.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-064 - Implement LevelGenerator candidate pipeline

- Plane work item ID: `7ae6d54c-0105-4dff-9c83-63697add53a9`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:alfredo`
- Type: `type:tooling`
- Scope: `scope:planned`
- Module: Unassigned
- Plane sequence: 43

### Objective

Generate candidates only through Generate â Validate â Solve â Score â Filter â Human Review.

### Executor

agent:alfredo

### 32K context contract

- Risk class: context-required
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-064.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-054
- ART-TASK-062
- ART-TASK-064-CTX

### SPEC references

- ART-SPEC-LEVEL-006

### Architecture references

- ART-ARCH-SOLVER-006

### Allowed files

- generator/**
- tests/AstroRebelsTraffic.Tests/Generator/GeneratorTests.cs

### Exact instructions

1. Use seeded deterministic candidate generation.

2. Write candidates outside production manifest.

3. Reject validation or solver failures.

4. Record seed, solution and metrics.

5. Never auto-mark human_reviewed.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Same seed produces same candidate.
- Invalid/unsolved candidate cannot advance.
- No direct production write path exists.

### Acceptance criteria

- Pipeline order is enforced.
- Human review remains mandatory.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-064-CTX - Build bounded context pack for ART-TASK-064

- Plane work item ID: `75e79ccd-afbe-4290-a037-50d6be184721`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:alfredo`
- Type: `type:tooling`
- Scope: `scope:planned`
- Module: Unassigned
- Plane sequence: 99

### Objective

Create the only normative and repository context that ART-TASK-064 may consume.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-054
- ART-TASK-062
- ART-TASK-000

### SPEC references

- ART-SPEC-LEVEL-006

### Architecture references

- ART-ARCH-SOLVER-006

### Allowed files

- docs/task-context/ART-TASK-064.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-LEVEL-006] and ARCH IDs [ART-ARCH-SOLVER-006].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-064' -SpecIds 'ART-SPEC-LEVEL-006' -ArchIds 'ART-ARCH-SOLVER-006' -OutputPath 'docs/task-context/ART-TASK-064.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-064.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-064 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-065 - Implement DifficultyEvaluator metrics

- Plane work item ID: `2aa2edbe-eb0c-4f6e-abf7-c8150fbe7200`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:alfredo`
- Type: `type:tooling`
- Scope: `scope:planned`
- Module: Unassigned
- Plane sequence: 44

### Objective

Compute explainable difficulty metrics from solver and level evidence without changing gameplay.

### Executor

agent:alfredo

### 32K context contract

- Risk class: context-required
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-065.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-062
- ART-TASK-065-CTX

### SPEC references

- ART-SPEC-LEVEL-004
- ART-SPEC-LEVEL-005

### Architecture references

- ART-ARCH-SOLVER-007

### Allowed files

- solver/Difficulty/**
- tests/AstroRebelsTraffic.Tests/Solver/DifficultyTests.cs

### Exact instructions

1. Record solution length, branching, deadlock exposure, forced moves, dock pressure, colors, prequeue pressure, density and mechanics.

2. Keep weights in versioned content config.

3. Return component values and final score.

4. Do not use hand label as sole evidence.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Golden fixtures produce stable metric components.
- Weight changes do not change gameplay state.

### Acceptance criteria

- Difficulty result is explainable.
- Evaluator uses solver outputs and canonical level data.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-065-CTX - Build bounded context pack for ART-TASK-065

- Plane work item ID: `6bb2d4ca-8e09-4f69-9b83-f3c1bf7837fe`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:alfredo`
- Type: `type:tooling`
- Scope: `scope:planned`
- Module: Unassigned
- Plane sequence: 100

### Objective

Create the only normative and repository context that ART-TASK-065 may consume.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-062
- ART-TASK-000

### SPEC references

- ART-SPEC-LEVEL-004
- ART-SPEC-LEVEL-005

### Architecture references

- ART-ARCH-SOLVER-007

### Allowed files

- docs/task-context/ART-TASK-065.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-LEVEL-004,ART-SPEC-LEVEL-005] and ARCH IDs [ART-ARCH-SOLVER-007].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-065' -SpecIds 'ART-SPEC-LEVEL-004,ART-SPEC-LEVEL-005' -ArchIds 'ART-ARCH-SOLVER-007' -OutputPath 'docs/task-context/ART-TASK-065.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-065.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-065 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-070 - Create AppRoot, scene flow and GameplayScreen composition â integration gate

- Plane work item ID: `5540888a-8052-470a-95c4-b5fac63fdc46`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:nicolas`
- Type: `type:ui`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 45

### Objective

Close ART-TASK-070 only after its context, implementation and validation subtasks are Done. This gate performs no implementation.

### Executor

agent:nicolas

### 32K context contract

- Risk class: gate
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-070.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-070-VAL

### SPEC references

- ART-SPEC-UI-001

### Architecture references

- ART-ARCH-SCENE-001
- ART-ARCH-SCENE-002
- ART-ARCH-SCENE-003

### Allowed files

- docs/task-context/ART-TASK-070.md

### Exact instructions

1. Confirm ART-TASK-070-CTX, ART-TASK-070-P1, ART-TASK-070-P2 and ART-TASK-070-VAL are Done in Plane.

2. Confirm validation evidence addresses every original acceptance criterion.

3. Record the four subtask IDs and evidence links in the completion comment.

4. Do not read source files or rerun broad commands in this gate.

### Commands

None.

### Validation

- All four required subtasks are Done and none reports an unresolved blocker.

### Acceptance criteria

- The original task closes as a traceability gate without consuming implementation context.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-070-CTX - Build bounded context pack for ART-TASK-070

- Plane work item ID: `15076787-d4b9-426c-9cb4-0106aa8f81ca`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:nicolas`
- Type: `type:tooling`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 148

### Objective

Create the only normative and repository context that ART-TASK-070 may consume.

### Executor

agent:nicolas

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-003
- ART-TASK-046
- ART-TASK-051
- ART-TASK-000

### SPEC references

- ART-SPEC-UI-001

### Architecture references

- ART-ARCH-SCENE-001
- ART-ARCH-SCENE-002
- ART-ARCH-SCENE-003

### Allowed files

- docs/task-context/ART-TASK-070.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-UI-001] and ARCH IDs [ART-ARCH-SCENE-001,ART-ARCH-SCENE-002,ART-ARCH-SCENE-003].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-070' -SpecIds 'ART-SPEC-UI-001' -ArchIds 'ART-ARCH-SCENE-001,ART-ARCH-SCENE-002,ART-ARCH-SCENE-003' -OutputPath 'docs/task-context/ART-TASK-070.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-070.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-070 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-070-P1 - Create AppRoot, scene flow and GameplayScreen composition â atomic implementation phase 1

- Plane work item ID: `8cfdc0d3-71fa-4cc0-9899-f277a28f589e`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:nicolas`
- Type: `type:ui`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 149

### Objective

Perform only the first bounded half of ART-TASK-070; do not execute final validation or the remaining steps.

### Executor

agent:nicolas

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-070.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-070-CTX

### SPEC references

- ART-SPEC-UI-001

### Architecture references

- ART-ARCH-SCENE-001
- ART-ARCH-SCENE-002
- ART-ARCH-SCENE-003

### Allowed files

- app/**
- presentation/Screens/**
- presentation/Gameplay/GameplayScreen.tscn

### Exact instructions

1. Create AppBootstrap and ScreenHost.

2. Create MainMenu, LevelSelect, Gameplay and Settings scenes.

3. Create one per-level GameSession, not an autoload.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug

### Validation

- Changed files are within the task allowlist and the context pack exact-file list.
- No tool result exceeds 4,000 characters; verbose output is redirected to a file and summarized.
- The phase report lists unfinished original steps explicitly.

### Acceptance criteria

- Phase-one steps are implemented without claiming the original task complete.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-070-P2 - Create AppRoot, scene flow and GameplayScreen composition â atomic implementation phase 2

- Plane work item ID: `9ba9e3b1-84f6-4bd6-b6fd-a29934da42e7`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:nicolas`
- Type: `type:ui`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 150

### Objective

Perform only the remaining bounded half of ART-TASK-070 using phase-one artifacts.

### Executor

agent:nicolas

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-070.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-070-P1

### SPEC references

- ART-SPEC-UI-001

### Architecture references

- ART-ARCH-SCENE-001
- ART-ARCH-SCENE-002
- ART-ARCH-SCENE-003

### Allowed files

- app/**
- presentation/Screens/**
- presentation/Gameplay/GameplayScreen.tscn

### Exact instructions

1. Wire ports only in composition root.

2. Use portrait safe-area containers.

### Commands

- & 'C:\Users\eorod\Desktop\Godot_v4.7.1-stable_mono_win64\Godot_v4.7.1-stable_mono_win64_console.exe' --headless --path 'C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic' --editor --quit

### Validation

- Phase-one artifacts are present and unchanged except for required integration edits.
- Changed files are within the task allowlist and the context pack exact-file list.
- The phase report maps every original instruction to P1 or P2 evidence.

### Acceptance criteria

- All implementation instructions are covered; final acceptance is deferred to the validation phase.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-070-VAL - Create AppRoot, scene flow and GameplayScreen composition â bounded validation

- Plane work item ID: `771957fa-9afc-497b-9c15-b32950af41e4`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:nicolas`
- Type: `type:test`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 151

### Objective

Validate ART-TASK-070 without implementing new functionality.

### Executor

agent:nicolas

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-070.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-070-P2

### SPEC references

- ART-SPEC-UI-001

### Architecture references

- ART-ARCH-SCENE-001
- ART-ARCH-SCENE-002
- ART-ARCH-SCENE-003

### Allowed files

- app/**
- presentation/Screens/**
- presentation/Gameplay/GameplayScreen.tscn

### Exact instructions

1. Run only the original validation commands with concise output.

2. Record exit codes and the smallest relevant failure output.

3. Check every original acceptance criterion against observable evidence.

4. Do not repair failures; return BLOCKED with the exact failing phase.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- & 'C:\Users\eorod\Desktop\Godot_v4.7.1-stable_mono_win64\Godot_v4.7.1-stable_mono_win64_console.exe' --headless --path 'C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic' --editor --quit

### Validation

- All scenes import.
- AppRoot opens headlessly without missing nodes/scripts.

### Acceptance criteria

- Scene tree matches responsibilities.
- Domain has no Presentation reference.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-071 - Implement rebuildable GridView and ShipView

- Plane work item ID: `5f3910a0-2f57-4f1f-b750-bf25165c77a6`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:nicolas`
- Type: `type:ui`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 46

### Objective

Render zones and ships entirely from settled GameState with stable board footprint and direction cues.

### Executor

agent:nicolas

### 32K context contract

- Risk class: context-required
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-071.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-070
- ART-TASK-022
- ART-TASK-071-CTX

### SPEC references

- ART-SPEC-GRID-001
- ART-SPEC-ART-002
- ART-SPEC-ART-004

### Architecture references

- ART-ARCH-PRES-002
- ART-ARCH-SCENE-005

### Allowed files

- presentation/Gameplay/Grid/**
- presentation/Gameplay/Ships/**
- tests/AstroRebelsTraffic.Tests/Presentation/GridViewTests.cs

### Exact instructions

1. Compute cell pixel size from available board rectangle and logical dimensions.

2. Scale ships with cells.

3. Map IDs to views.

4. Rebuild after load/restart/undo.

5. Forward taps as ReleaseShipCommand intent only.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- 6Ã8, 8Ã10 and 10Ã12 fixtures fit the same board container.
- Rebuild creates exact ship count and orientation.

### Acceptance criteria

- View does not validate path.
- Color and direction cues remain legible.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-071-CTX - Build bounded context pack for ART-TASK-071

- Plane work item ID: `ea0afb8c-ec82-4452-b732-374edecb6329`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:nicolas`
- Type: `type:tooling`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 101

### Objective

Create the only normative and repository context that ART-TASK-071 may consume.

### Executor

agent:nicolas

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-070
- ART-TASK-022
- ART-TASK-000

### SPEC references

- ART-SPEC-GRID-001
- ART-SPEC-ART-002
- ART-SPEC-ART-004

### Architecture references

- ART-ARCH-PRES-002
- ART-ARCH-SCENE-005

### Allowed files

- docs/task-context/ART-TASK-071.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-GRID-001,ART-SPEC-ART-002,ART-SPEC-ART-004] and ARCH IDs [ART-ARCH-PRES-002,ART-ARCH-SCENE-005].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-071' -SpecIds 'ART-SPEC-GRID-001,ART-SPEC-ART-002,ART-SPEC-ART-004' -ArchIds 'ART-ARCH-PRES-002,ART-ARCH-SCENE-005' -OutputPath 'docs/task-context/ART-TASK-071.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-071.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-071 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-072 - Implement queue, circular prequeue and dock views â integration gate

- Plane work item ID: `c744e952-e556-431a-ae2c-132d7f46515f`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:nicolas`
- Type: `type:ui`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 47

### Objective

Close ART-TASK-072 only after its context, implementation and validation subtasks are Done. This gate performs no implementation.

### Executor

agent:nicolas

### 32K context contract

- Risk class: gate
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-072.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-072-VAL

### SPEC references

- ART-SPEC-UI-001
- ART-SPEC-ART-005

### Architecture references

- ART-ARCH-PRES-002
- ART-ARCH-PRES-003

### Allowed files

- docs/task-context/ART-TASK-072.md

### Exact instructions

1. Confirm ART-TASK-072-CTX, ART-TASK-072-P1, ART-TASK-072-P2 and ART-TASK-072-VAL are Done in Plane.

2. Confirm validation evidence addresses every original acceptance criterion.

3. Record the four subtask IDs and evidence links in the completion comment.

4. Do not read source files or rerun broad commands in this gate.

### Commands

None.

### Validation

- All four required subtasks are Done and none reports an unresolved blocker.

### Acceptance criteria

- The original task closes as a traceability gate without consuming implementation context.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-072-CTX - Build bounded context pack for ART-TASK-072

- Plane work item ID: `d536dcdd-d578-4cea-bb4d-a09f0f68f8aa`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:nicolas`
- Type: `type:tooling`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 152

### Objective

Create the only normative and repository context that ART-TASK-072 may consume.

### Executor

agent:nicolas

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-070
- ART-TASK-034
- ART-TASK-032
- ART-TASK-000

### SPEC references

- ART-SPEC-UI-001
- ART-SPEC-ART-005

### Architecture references

- ART-ARCH-PRES-002
- ART-ARCH-PRES-003

### Allowed files

- docs/task-context/ART-TASK-072.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-UI-001,ART-SPEC-ART-005] and ARCH IDs [ART-ARCH-PRES-002,ART-ARCH-PRES-003].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-072' -SpecIds 'ART-SPEC-UI-001,ART-SPEC-ART-005' -ArchIds 'ART-ARCH-PRES-002,ART-ARCH-PRES-003' -OutputPath 'docs/task-context/ART-TASK-072.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-072.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-072 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-072-P1 - Implement queue, circular prequeue and dock views â atomic implementation phase 1

- Plane work item ID: `17201ad0-0fee-4a1a-8578-822db858b6b4`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:nicolas`
- Type: `type:ui`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 153

### Objective

Perform only the first bounded half of ART-TASK-072; do not execute final validation or the remaining steps.

### Executor

agent:nicolas

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-072.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-072-CTX

### SPEC references

- ART-SPEC-UI-001
- ART-SPEC-ART-005

### Architecture references

- ART-ARCH-PRES-002
- ART-ARCH-PRES-003

### Allowed files

- presentation/Gameplay/Passengers/**
- presentation/Gameplay/Docks/**

### Exact instructions

1. Render queue front distinctly.

2. Render prequeue circularly from logical sequence.

3. Show 4 active base and 4 locked rewarded slots.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug

### Validation

- Changed files are within the task allowlist and the context pack exact-file list.
- No tool result exceeds 4,000 characters; verbose output is redirected to a file and summarized.
- The phase report lists unfinished original steps explicitly.

### Acceptance criteria

- Phase-one steps are implemented without claiming the original task complete.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-072-P2 - Implement queue, circular prequeue and dock views â atomic implementation phase 2

- Plane work item ID: `b579d6a8-181f-4df2-a50b-ca8103311c8b`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:nicolas`
- Type: `type:ui`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 154

### Objective

Perform only the remaining bounded half of ART-TASK-072 using phase-one artifacts.

### Executor

agent:nicolas

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-072.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-072-P1

### SPEC references

- ART-SPEC-UI-001
- ART-SPEC-ART-005

### Architecture references

- ART-ARCH-PRES-002
- ART-ARCH-PRES-003

### Allowed files

- presentation/Gameplay/Passengers/**
- presentation/Gameplay/Docks/**

### Exact instructions

1. Show empty/occupied/locked states.

2. Pool passenger figures and reset pooled visuals completely.

### Commands

- & 'C:\Users\eorod\Desktop\Godot_v4.7.1-stable_mono_win64\Godot_v4.7.1-stable_mono_win64_console.exe' --headless --path 'C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic' --editor --quit

### Validation

- Phase-one artifacts are present and unchanged except for required integration edits.
- Changed files are within the task allowlist and the context pack exact-file list.
- The phase report maps every original instruction to P1 or P2 evidence.

### Acceptance criteria

- All implementation instructions are covered; final acceptance is deferred to the validation phase.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-072-VAL - Implement queue, circular prequeue and dock views â bounded validation

- Plane work item ID: `8034dac2-0efc-4c5b-af98-0e5ceeb587a8`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:nicolas`
- Type: `type:test`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 155

### Objective

Validate ART-TASK-072 without implementing new functionality.

### Executor

agent:nicolas

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-072.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-072-P2

### SPEC references

- ART-SPEC-UI-001
- ART-SPEC-ART-005

### Architecture references

- ART-ARCH-PRES-002
- ART-ARCH-PRES-003

### Allowed files

- presentation/Gameplay/Passengers/**
- presentation/Gameplay/Docks/**

### Exact instructions

1. Run only the original validation commands with concise output.

2. Record exit codes and the smallest relevant failure output.

3. Check every original acceptance criterion against observable evidence.

4. Do not repair failures; return BLOCKED with the exact failing phase.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- & 'C:\Users\eorod\Desktop\Godot_v4.7.1-stable_mono_win64\Godot_v4.7.1-stable_mono_win64_console.exe' --headless --path 'C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic' --editor --quit

### Validation

- Views rebuild from fixtures.
- Visual dock order matches logical indices.
- Prequeue animation never mutates logical order.

### Acceptance criteria

- Right-to-left priority is not reimplemented in view.
- 100 logical passengers can be represented.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-073 - Implement PresentationCoordinator and input lock

- Plane work item ID: `a1049d13-baf7-40be-a610-d9d902f17dad`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:nicolas`
- Type: `type:ui`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 48

### Objective

Play ordered domain events while gameplay input is locked, then synchronize views and return control.

### Executor

agent:nicolas

### 32K context contract

- Risk class: context-required
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-073.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-040
- ART-TASK-046
- ART-TASK-070
- ART-TASK-071
- ART-TASK-072
- ART-TASK-073-CTX

### SPEC references

- ART-SPEC-RESOLVE-002
- ART-SPEC-RESOLVE-003
- ART-SPEC-ART-009

### Architecture references

- ART-ARCH-PRES-001
- ART-ARCH-CMD-005

### Allowed files

- presentation/Gameplay/Coordination/PresentationCoordinator.cs
- tests/AstroRebelsTraffic.Tests/Presentation/PresentationCoordinatorTests.cs

### Exact instructions

1. Disable ship input before dispatch.

2. Play/skip events in order.

3. Support instant mode for tests.

4. Rebuild views from final state after playback.

5. Show terminal overlay or re-enable input.

6. Handle interrupted scene safely.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Second tap during playback cannot dispatch.
- Instant and animated modes end in identical displayed state.
- Terminal event never re-enables ship input.

### Acceptance criteria

- Logical state does not wait on animation.
- Lock covers required presentation duration.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-073-CTX - Build bounded context pack for ART-TASK-073

- Plane work item ID: `92486b30-1e74-4884-83c7-5a4fb1e1d79f`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:nicolas`
- Type: `type:tooling`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 102

### Objective

Create the only normative and repository context that ART-TASK-073 may consume.

### Executor

agent:nicolas

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-040
- ART-TASK-046
- ART-TASK-070
- ART-TASK-071
- ART-TASK-072
- ART-TASK-000

### SPEC references

- ART-SPEC-RESOLVE-002
- ART-SPEC-RESOLVE-003
- ART-SPEC-ART-009

### Architecture references

- ART-ARCH-PRES-001
- ART-ARCH-CMD-005

### Allowed files

- docs/task-context/ART-TASK-073.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-RESOLVE-002,ART-SPEC-RESOLVE-003,ART-SPEC-ART-009] and ARCH IDs [ART-ARCH-PRES-001,ART-ARCH-CMD-005].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-073' -SpecIds 'ART-SPEC-RESOLVE-002,ART-SPEC-RESOLVE-003,ART-SPEC-ART-009' -ArchIds 'ART-ARCH-PRES-001,ART-ARCH-CMD-005' -OutputPath 'docs/task-context/ART-TASK-073.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-073.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-073 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-074 - Implement invalid-release, win and loss feedback

- Plane work item ID: `9f84d59b-0715-4ad3-b356-0c4e7c0ecec9`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:nicolas`
- Type: `type:ui`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 49

### Objective

Map structured outcomes to clear localized visual feedback without deciding outcomes in UI.

### Executor

agent:nicolas

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-043
- ART-TASK-073

### SPEC references

- ART-SPEC-SHIP-006
- ART-SPEC-UI-005

### Architecture references

- ART-ARCH-EVENT-002
- ART-ARCH-END-003

### Allowed files

- presentation/Gameplay/Feedback/**
- presentation/UI/ResultOverlay.tscn

### Exact instructions

1. Map blocked path and docks-full separately.

2. Add non-destructive blocked pulse/shake.

3. Show win only from LevelWon.

4. Show loss only from RealDeadlockDetected.

5. Provide restart and eligible recovery actions.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- & 'C:\Users\eorod\Desktop\Godot_v4.7.1-stable_mono_win64\Godot_v4.7.1-stable_mono_win64_console.exe' --headless --path 'C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic' --editor --quit

### Validation

- Each domain reason maps to one feedback case.
- UI cannot synthesize LevelWon or loss.

### Acceptance criteria

- Feedback is readable without debug text.
- No false loss counter exists.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-075 - Implement ColorCatalog and accessibility symbols

- Plane work item ID: `394cde82-4257-4c72-a96c-fc69e5b25d11`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:nicolas`
- Type: `type:ui`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 50

### Objective

Map every logical color to visual color, faction symbol, accessible label and asset references.

### Executor

agent:nicolas

### 32K context contract

- Risk class: context-required
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-075.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-071
- ART-TASK-072
- ART-TASK-075-CTX

### SPEC references

- ART-SPEC-LEVEL-003
- ART-SPEC-UI-004

### Architecture references

- ART-ARCH-PRES-004

### Allowed files

- presentation/Accessibility/ColorCatalog.cs
- assets/Catalogs/color_catalog.tres
- tests/AstroRebelsTraffic.Tests/Presentation/ColorCatalogTests.cs

### Exact instructions

1. Add Red, Blue, Green, Yellow first.

2. Add later color definitions disabled by content progression.

3. Ensure ship and passenger use the same symbol mapping.

4. Rules continue comparing IDs only.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Every enabled color has unique symbol and label.
- Missing catalog entry fails validation in debug/content checks.

### Acceptance criteria

- Color is not the only cue.
- Catalog cannot alter logical matching.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-075-CTX - Build bounded context pack for ART-TASK-075

- Plane work item ID: `e7a03b6e-2212-48bc-bc4d-d70b29e065a0`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:nicolas`
- Type: `type:tooling`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 103

### Objective

Create the only normative and repository context that ART-TASK-075 may consume.

### Executor

agent:nicolas

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-071
- ART-TASK-072
- ART-TASK-000

### SPEC references

- ART-SPEC-LEVEL-003
- ART-SPEC-UI-004

### Architecture references

- ART-ARCH-PRES-004

### Allowed files

- docs/task-context/ART-TASK-075.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-LEVEL-003,ART-SPEC-UI-004] and ARCH IDs [ART-ARCH-PRES-004].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-075' -SpecIds 'ART-SPEC-LEVEL-003,ART-SPEC-UI-004' -ArchIds 'ART-ARCH-PRES-004' -OutputPath 'docs/task-context/ART-TASK-075.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-075.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-075 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-076 - Implement HUD, restart, settings and conditional booster controls â integration gate

- Plane work item ID: `e00d56a1-d7cd-4286-b4cd-2ae3db835e97`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:nicolas`
- Type: `type:ui`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 51

### Objective

Close ART-TASK-076 only after its context, implementation and validation subtasks are Done. This gate performs no implementation.

### Executor

agent:nicolas

### 32K context contract

- Risk class: gate
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-076.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-076-VAL

### SPEC references

- ART-SPEC-UI-002
- ART-SPEC-UI-003

### Architecture references

- ART-ARCH-PRES-002

### Allowed files

- docs/task-context/ART-TASK-076.md

### Exact instructions

1. Confirm ART-TASK-076-CTX, ART-TASK-076-P1, ART-TASK-076-P2 and ART-TASK-076-VAL are Done in Plane.

2. Confirm validation evidence addresses every original acceptance criterion.

3. Record the four subtask IDs and evidence links in the completion comment.

4. Do not read source files or rerun broad commands in this gate.

### Commands

None.

### Validation

- All four required subtasks are Done and none reports an unresolved blocker.

### Acceptance criteria

- The original task closes as a traceability gate without consuming implementation context.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-076-CTX - Build bounded context pack for ART-TASK-076

- Plane work item ID: `3584963f-f547-42da-badd-5f2eeab74b68`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:nicolas`
- Type: `type:tooling`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 156

### Objective

Create the only normative and repository context that ART-TASK-076 may consume.

### Executor

agent:nicolas

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-070
- ART-TASK-073
- ART-TASK-075
- ART-TASK-000

### SPEC references

- ART-SPEC-UI-002
- ART-SPEC-UI-003

### Architecture references

- ART-ARCH-PRES-002

### Allowed files

- docs/task-context/ART-TASK-076.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-UI-002,ART-SPEC-UI-003] and ARCH IDs [ART-ARCH-PRES-002].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-076' -SpecIds 'ART-SPEC-UI-002,ART-SPEC-UI-003' -ArchIds 'ART-ARCH-PRES-002' -OutputPath 'docs/task-context/ART-TASK-076.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-076.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-076 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-076-P1 - Implement HUD, restart, settings and conditional booster controls â atomic implementation phase 1

- Plane work item ID: `4bb3e233-6ce3-4814-a036-ebe0de18e9a8`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:nicolas`
- Type: `type:ui`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 157

### Objective

Perform only the first bounded half of ART-TASK-076; do not execute final validation or the remaining steps.

### Executor

agent:nicolas

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-076.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-076-CTX

### SPEC references

- ART-SPEC-UI-002
- ART-SPEC-UI-003

### Architecture references

- ART-ARCH-PRES-002

### Allowed files

- presentation/UI/**
- presentation/Screens/SettingsScreen.tscn

### Exact instructions

1. Add level header and accessible restart.

2. Add separate music and SFX controls.

3. Hide Undo/Scanner/Extra Dock/VIP unless enabled and available.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug

### Validation

- Changed files are within the task allowlist and the context pack exact-file list.
- No tool result exceeds 4,000 characters; verbose output is redirected to a file and summarized.
- The phase report lists unfinished original steps explicitly.

### Acceptance criteria

- Phase-one steps are implemented without claiming the original task complete.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-076-P2 - Implement HUD, restart, settings and conditional booster controls â atomic implementation phase 2

- Plane work item ID: `9ad34755-588a-4e9d-9a14-3b3ccdad8e0b`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:nicolas`
- Type: `type:ui`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 158

### Objective

Perform only the remaining bounded half of ART-TASK-076 using phase-one artifacts.

### Executor

agent:nicolas

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-076.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-076-P1

### SPEC references

- ART-SPEC-UI-002
- ART-SPEC-UI-003

### Architecture references

- ART-ARCH-PRES-002

### Allowed files

- presentation/UI/**
- presentation/Screens/SettingsScreen.tscn

### Exact instructions

1. Use localization keys for visible text.

2. Respect safe areas and minimum touch sizes.

### Commands

- & 'C:\Users\eorod\Desktop\Godot_v4.7.1-stable_mono_win64\Godot_v4.7.1-stable_mono_win64_console.exe' --headless --path 'C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic' --editor --quit

### Validation

- Phase-one artifacts are present and unchanged except for required integration edits.
- Changed files are within the task allowlist and the context pack exact-file list.
- The phase report maps every original instruction to P1 or P2 evidence.

### Acceptance criteria

- All implementation instructions are covered; final acceptance is deferred to the validation phase.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-076-VAL - Implement HUD, restart, settings and conditional booster controls â bounded validation

- Plane work item ID: `4c808196-7607-46bb-a1ad-c93e9ca263ba`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:nicolas`
- Type: `type:test`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 159

### Objective

Validate ART-TASK-076 without implementing new functionality.

### Executor

agent:nicolas

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-076.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-076-P2

### SPEC references

- ART-SPEC-UI-002
- ART-SPEC-UI-003

### Architecture references

- ART-ARCH-PRES-002

### Allowed files

- presentation/UI/**
- presentation/Screens/SettingsScreen.tscn

### Exact instructions

1. Run only the original validation commands with concise output.

2. Record exit codes and the smallest relevant failure output.

3. Check every original acceptance criterion against observable evidence.

4. Do not repair failures; return BLOCKED with the exact failing phase.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- & 'C:\Users\eorod\Desktop\Godot_v4.7.1-stable_mono_win64\Godot_v4.7.1-stable_mono_win64_console.exe' --headless --path 'C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic' --editor --quit

### Validation

- Portrait layouts render at representative aspect ratios.
- Disabled systems have no visible control.

### Acceptance criteria

- Restart is reachable.
- Gameplay remains low-text and accessible.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-080 - Implement tutorial state and action gating

- Plane work item ID: `c52fd411-3050-4470-a72d-48c88d769334`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 52

### Objective

Drive integrated tutorial prompts and permitted actions from level data without duplicating gameplay rules.

### Executor

agent:alfredo

### 32K context contract

- Risk class: context-required
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-080.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-046
- ART-TASK-073
- ART-TASK-080-CTX

### SPEC references

- ART-SPEC-TUT-001

### Architecture references

- ART-ARCH-CMD-003

### Allowed files

- application/Tutorial/**
- presentation/Tutorial/**
- tests/AstroRebelsTraffic.Tests/Tutorial/TutorialTests.cs

### Exact instructions

1. Represent current tutorial step and allowed ship IDs/actions.

2. Validate tutorial gate before path/dock mutation.

3. Advance only from domain/application facts.

4. Allow view to highlight but not force invalid state.

5. Persist completion through SaveData later.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Disallowed action rejects unchanged.
- Required valid action advances step.
- Tutorial can be disabled with zero rule effect.

### Acceptance criteria

- Tutorial does not replace command validation.
- State is deterministic.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-080-CTX - Build bounded context pack for ART-TASK-080

- Plane work item ID: `95fdb4c6-220c-4ba2-bee2-6bc585eefb40`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:alfredo`
- Type: `type:tooling`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 104

### Objective

Create the only normative and repository context that ART-TASK-080 may consume.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-046
- ART-TASK-073
- ART-TASK-000

### SPEC references

- ART-SPEC-TUT-001

### Architecture references

- ART-ARCH-CMD-003

### Allowed files

- docs/task-context/ART-TASK-080.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-TUT-001] and ARCH IDs [ART-ARCH-CMD-003].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-080' -SpecIds 'ART-SPEC-TUT-001' -ArchIds 'ART-ARCH-CMD-003' -OutputPath 'docs/task-context/ART-TASK-080.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-080.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-080 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-081 - Create the eight introductory tutorial levels â integration gate

- Plane work item ID: `ed8b617f-0e08-4cf2-b9f2-9d8a2ab0672d`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:nicolas`
- Type: `type:data`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 53

### Objective

Close ART-TASK-081 only after its context, implementation and validation subtasks are Done. This gate performs no implementation.

### Executor

agent:nicolas

### 32K context contract

- Risk class: gate
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-081.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-081-VAL

### SPEC references

- ART-SPEC-TUT-002

### Architecture references

- ART-ARCH-LEVEL-005

### Allowed files

- docs/task-context/ART-TASK-081.md

### Exact instructions

1. Confirm ART-TASK-081-CTX, ART-TASK-081-P1, ART-TASK-081-P2 and ART-TASK-081-VAL are Done in Plane.

2. Confirm validation evidence addresses every original acceptance criterion.

3. Record the four subtask IDs and evidence links in the completion comment.

4. Do not read source files or rerun broad commands in this gate.

### Commands

None.

### Validation

- All four required subtasks are Done and none reports an unresolved blocker.

### Acceptance criteria

- The original task closes as a traceability gate without consuming implementation context.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-081-CTX - Build bounded context pack for ART-TASK-081

- Plane work item ID: `8a697c9f-dab1-47d3-b3d4-eed23596806b`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:nicolas`
- Type: `type:tooling`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 160

### Objective

Create the only normative and repository context that ART-TASK-081 may consume.

### Executor

agent:nicolas

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-053
- ART-TASK-080
- ART-TASK-062
- ART-TASK-000

### SPEC references

- ART-SPEC-TUT-002

### Architecture references

- ART-ARCH-LEVEL-005

### Allowed files

- docs/task-context/ART-TASK-081.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-TUT-002] and ARCH IDs [ART-ARCH-LEVEL-005].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-081' -SpecIds 'ART-SPEC-TUT-002' -ArchIds 'ART-ARCH-LEVEL-005' -OutputPath 'docs/task-context/ART-TASK-081.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-081.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-081 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-081-P1 - Create the eight introductory tutorial levels â atomic implementation phase 1

- Plane work item ID: `d20a9bf8-599c-4f48-b548-93520d6c03ba`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:nicolas`
- Type: `type:data`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 161

### Objective

Perform only the first bounded half of ART-TASK-081; do not execute final validation or the remaining steps.

### Executor

agent:nicolas

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-081.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-081-CTX

### SPEC references

- ART-SPEC-TUT-002

### Architecture references

- ART-ARCH-LEVEL-005

### Allowed files

- levels/Definitions/tutorial/**

### Exact instructions

1. Create one level each for clear release, matching, docks, wrong-color pressure, directions, Medium, Large and prequeue.

2. Use only introduced mechanics.

### Commands

- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Changed files are within the task allowlist and the context pack exact-file list.
- No tool result exceeds 4,000 characters; verbose output is redirected to a file and summarized.
- The phase report lists unfinished original steps explicitly.

### Acceptance criteria

- Phase-one steps are implemented without claiming the original task complete.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-081-P2 - Create the eight introductory tutorial levels â atomic implementation phase 2

- Plane work item ID: `3c35cac6-d310-4cd7-924a-e8e4337a5dfb`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:nicolas`
- Type: `type:data`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 162

### Objective

Perform only the remaining bounded half of ART-TASK-081 using phase-one artifacts.

### Executor

agent:nicolas

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-081.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-081-P1

### SPEC references

- ART-SPEC-TUT-002

### Architecture references

- ART-ARCH-LEVEL-005

### Allowed files

- levels/Definitions/tutorial/**

### Exact instructions

1. Validate and solve each without assistance.

2. Record intended teaching action and solution.

### Commands

None.

### Validation

- Phase-one artifacts are present and unchanged except for required integration edits.
- Changed files are within the task allowlist and the context pack exact-file list.
- The phase report maps every original instruction to P1 or P2 evidence.

### Acceptance criteria

- All implementation instructions are covered; final acceptance is deferred to the validation phase.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-081-VAL - Create the eight introductory tutorial levels â bounded validation

- Plane work item ID: `f9a7c224-a55b-420e-8a9a-5f77008461a9`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:nicolas`
- Type: `type:test`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 163

### Objective

Validate ART-TASK-081 without implementing new functionality.

### Executor

agent:nicolas

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-081.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-081-P2

### SPEC references

- ART-SPEC-TUT-002

### Architecture references

- ART-ARCH-LEVEL-005

### Allowed files

- levels/Definitions/tutorial/**

### Exact instructions

1. Run only the original validation commands with concise output.

2. Record exit codes and the smallest relevant failure output.

3. Check every original acceptance criterion against observable evidence.

4. Do not repair failures; return BLOCKED with the exact failing phase.

### Commands

- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- All 8 levels validate and solve.
- Teaching order matches SPEC.
- No ad or booster is required.

### Acceptance criteria

- Each level has one clear teaching objective.
- Human review metadata remains required for production.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-082 - Implement linear progression and level unlocks

- Plane work item ID: `d151997c-f6a7-4b0d-9731-a24d527c7a5a`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 54

### Objective

Unlock the next level only after a recorded win and display ordered level selection.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-042
- ART-TASK-081
- ART-TASK-090

### SPEC references

- ART-SPEC-PROG-001

### Architecture references

- ART-ARCH-SAVE-002

### Allowed files

- application/Progression/**
- presentation/Screens/LevelSelect/**
- tests/AstroRebelsTraffic.Tests/Progression/ProgressionTests.cs

### Exact instructions

1. Store highest unlocked and completion set.

2. Apply idempotent win updates.

3. Do not add lives, score or stars.

4. Support future world grouping in display metadata only.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Winning N unlocks N+1 once.
- Loss/restart does not unlock.
- Corrupt/out-of-range progress is clamped safely.

### Acceptance criteria

- Progression is linear.
- Deferred economy features remain absent.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-090 - Define versioned SaveData and settings

- Plane work item ID: `d2c0d075-06a2-4aef-8717-644d5ecdd59c`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 55

### Objective

Separate persistent settings/progression/tutorial/inventory from GameState and attempt-local rescue state.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-018

### SPEC references

- ART-SPEC-SAVE-001
- ART-SPEC-SAVE-003
- ART-SPEC-AUDIO-001

### Architecture references

- ART-ARCH-SAVE-002

### Allowed files

- application/Save/SaveData.cs
- application/Settings/**
- tests/AstroRebelsTraffic.Tests/Save/SaveDataTests.cs

### Exact instructions

1. Add save schema version.

2. Store music and SFX separately.

3. Store progression and tutorial completion.

4. Add booster inventory only as disabled/empty extension data.

5. Exclude temporary reward docks and transient GameState.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Round trip preserves authorized fields.
- Temporary docks cannot appear in SaveData.

### Acceptance criteria

- SaveData is separate from GameState.
- Defaults are explicit and safe.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-091 - Implement ISaveStore and atomic local adapter

- Plane work item ID: `9243a8c5-7171-4e2d-9085-f034dbdaf74f`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 56

### Objective

Write validated saves atomically with last-known-good recovery and structured results.

### Executor

agent:alfredo

### 32K context contract

- Risk class: context-required
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-091.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-090
- ART-TASK-091-CTX

### SPEC references

- ART-SPEC-SAVE-002

### Architecture references

- ART-ARCH-SAVE-001
- ART-ARCH-SAVE-003

### Allowed files

- application/Ports/ISaveStore.cs
- infrastructure/Save/LocalSaveStore.cs
- tests/AstroRebelsTraffic.Tests/Save/LocalSaveStoreTests.cs

### Exact instructions

1. Write to temporary file.

2. Flush and close.

3. Replace primary atomically where supported.

4. Retain one valid backup.

5. Recover corruption without crash.

6. Inject storage path for tests.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Interrupted/corrupt primary recovers backup.
- Failed write preserves previous primary.
- No exception escapes expected corruption paths.

### Acceptance criteria

- Gameplay works with in-memory fake.
- No cloud policy is invented.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-091-CTX - Build bounded context pack for ART-TASK-091

- Plane work item ID: `0c89f2eb-ccff-4ea4-a33b-d06dfaa6a81a`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:alfredo`
- Type: `type:tooling`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 105

### Objective

Create the only normative and repository context that ART-TASK-091 may consume.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-090
- ART-TASK-000

### SPEC references

- ART-SPEC-SAVE-002

### Architecture references

- ART-ARCH-SAVE-001
- ART-ARCH-SAVE-003

### Allowed files

- docs/task-context/ART-TASK-091.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-SAVE-002] and ARCH IDs [ART-ARCH-SAVE-001,ART-ARCH-SAVE-003].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-091' -SpecIds 'ART-SPEC-SAVE-002' -ArchIds 'ART-ARCH-SAVE-001,ART-ARCH-SAVE-003' -OutputPath 'docs/task-context/ART-TASK-091.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-091.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-091 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-092 - Implement tested save migrations

- Plane work item ID: `8acba90f-d52d-4d90-905a-6ade50c94580`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:sofia`
- Type: `type:test`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 57

### Objective

Migrate every supported older SaveData schema stepwise and reject future versions safely.

### Executor

agent:sofia

### 32K context contract

- Risk class: context-required
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-092.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-091
- ART-TASK-092-CTX

### SPEC references

- ART-SPEC-SAVE-002

### Architecture references

- ART-ARCH-SAVE-004

### Allowed files

- application/Save/Migrations/**
- tests/AstroRebelsTraffic.Tests/Save/MigrationTests.cs
- tests/fixtures/save/**

### Exact instructions

1. Create explicit migration registry.

2. Add v1 golden fixture.

3. Never overwrite unknown future-version data.

4. Validate after each migration.

5. Back up before replacing migrated file.

### Commands

- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- v1 fixture loads current.
- Future version returns unsupported without overwrite.
- Migration is idempotent.

### Acceptance criteria

- No silent reinterpretation occurs.
- Each schema change requires a new fixture.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-092-CTX - Build bounded context pack for ART-TASK-092

- Plane work item ID: `b4a8243d-2ece-4020-b575-8bf55b70d5ce`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:sofia`
- Type: `type:tooling`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 106

### Objective

Create the only normative and repository context that ART-TASK-092 may consume.

### Executor

agent:sofia

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-091
- ART-TASK-000

### SPEC references

- ART-SPEC-SAVE-002

### Architecture references

- ART-ARCH-SAVE-004

### Allowed files

- docs/task-context/ART-TASK-092.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-SAVE-002] and ARCH IDs [ART-ARCH-SAVE-004].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-092' -SpecIds 'ART-SPEC-SAVE-002' -ArchIds 'ART-ARCH-SAVE-004' -OutputPath 'docs/task-context/ART-TASK-092.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-092.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-092 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-093 - Define analytics port and typed internal events

- Plane work item ID: `0797c5ec-59cc-4c6a-a666-0c4356a48ea4`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 58

### Objective

Map domain/application facts to provider-neutral allowlisted analytics records.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-040
- ART-TASK-046

### SPEC references

- ART-SPEC-AN-001
- ART-SPEC-AN-002

### Architecture references

- ART-ARCH-AN-001
- ART-ARCH-AN-002

### Allowed files

- application/Ports/IAnalyticsService.cs
- application/Analytics/**
- tests/AstroRebelsTraffic.Tests/Analytics/AnalyticsTests.cs

### Exact instructions

1. Create no-op adapter.

2. Map required categories.

3. Include allowed schema/level/attempt/move metadata.

4. Do not include state dumps or personal data.

5. Never block command resolution.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- No-op preserves gameplay.
- Required event mapping tests pass.
- Payload allowlist rejects forbidden fields.

### Acceptance criteria

- No provider SDK in domain/application contracts.
- Analytics failure is non-fatal.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-094 - Implement consent-aware buffered analytics adapter

- Plane work item ID: `db259e72-820f-4b04-8b96-d12041a67b63`
- State: **Backlog**
- Priority: **low**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:planned`
- Module: Unassigned
- Plane sequence: 59

### Objective

Buffer/retry provider delivery only after a provider and consent policy are approved.

### Executor

agent:alfredo

### 32K context contract

- Risk class: context-required
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-094.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-093
- ART-TASK-094-CTX

### SPEC references

- ART-SPEC-AN-003

### Architecture references

- ART-ARCH-AN-003

### Allowed files

- infrastructure/Analytics/**
- tests/AstroRebelsTraffic.Tests/Analytics/BufferedAdapterTests.cs

### Exact instructions

1. Keep provider implementation disabled by default.

2. Filter through consent and payload allowlist.

3. Bound queue size and retry.

4. Drop safely after policy limit.

5. Do not store sensitive payloads.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Disabled/no-network behavior never blocks.
- Buffer bounds and consent tests pass.

### Acceptance criteria

- No real provider is selected.
- Task may stop at adapter boundary until Product Owner decision.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-094-CTX - Build bounded context pack for ART-TASK-094

- Plane work item ID: `1823961e-abef-4aea-ab0c-b1965aa42688`
- State: **Backlog**
- Priority: **low**
- Executor: `agent:alfredo`
- Type: `type:tooling`
- Scope: `scope:planned`
- Module: Unassigned
- Plane sequence: 107

### Objective

Create the only normative and repository context that ART-TASK-094 may consume.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-093
- ART-TASK-000

### SPEC references

- ART-SPEC-AN-003

### Architecture references

- ART-ARCH-AN-003

### Allowed files

- docs/task-context/ART-TASK-094.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-AN-003] and ARCH IDs [ART-ARCH-AN-003].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-094' -SpecIds 'ART-SPEC-AN-003' -ArchIds 'ART-ARCH-AN-003' -OutputPath 'docs/task-context/ART-TASK-094.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-094.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-094 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-100 - Define rewarded and interstitial service ports

- Plane work item ID: `856b5880-a25f-4eb6-b6ae-86b41bbbbbcb`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 60

### Objective

Represent ad availability and outcomes without choosing or linking an SDK.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-046

### SPEC references

- ART-SPEC-ADS-001
- ART-SPEC-ADS-003
- ART-SPEC-ADS-004

### Architecture references

- ART-ARCH-ADS-001
- ART-ARCH-ADS-004

### Allowed files

- application/Ports/IRewardedAdService.cs
- application/Ports/IInterstitialAdService.cs
- application/Ads/AdResults.cs
- tests/AstroRebelsTraffic.Tests/Ads/AdPortTests.cs

### Exact instructions

1. Define completed-verified, unavailable, cancelled, failed and stale results.

2. Use placement IDs from configuration.

3. Provide fake and no-op adapters.

4. Keep interstitial policy outside domain.

5. Do not grant rewards in provider callbacks.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- All outcomes have tests.
- No-op/failure leaves GameState unchanged.

### Acceptance criteria

- No SDK dependency exists.
- Gameplay remains fully playable without ads.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-101 - Implement idempotent RewardGrantService

- Plane work item ID: `670eb77b-07e5-4390-a79b-58d59c3c0659`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 61

### Objective

Translate one verified unique reward token into exactly one authorized dock activation.

### Executor

agent:alfredo

### 32K context contract

- Risk class: context-required
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-101.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-031
- ART-TASK-100
- ART-TASK-101-CTX

### SPEC references

- ART-SPEC-ADS-001
- ART-SPEC-ADS-004

### Architecture references

- ART-ARCH-ADS-002
- ART-ARCH-ADS-003

### Allowed files

- application/Ads/RewardGrantService.cs
- tests/AstroRebelsTraffic.Tests/Ads/RewardGrantTests.cs

### Exact instructions

1. Validate placement and verified completion.

2. Reject duplicate/stale token.

3. Dispatch UnlockRewardDockCommand.

4. Persist token only as needed for idempotency within attempt/session.

5. Map failure without mutation.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Same token twice grants once.
- Cancelled/failed/unavailable grants zero.
- Four-dock maximum is enforced by domain rule.

### Acceptance criteria

- UI/provider never mutates GameState.
- Reward is attempt-local.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-101-CTX - Build bounded context pack for ART-TASK-101

- Plane work item ID: `38a26bb0-8770-434b-94c0-6d180014e099`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:alfredo`
- Type: `type:tooling`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 108

### Objective

Create the only normative and repository context that ART-TASK-101 may consume.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-031
- ART-TASK-100
- ART-TASK-000

### SPEC references

- ART-SPEC-ADS-001
- ART-SPEC-ADS-004

### Architecture references

- ART-ARCH-ADS-002
- ART-ARCH-ADS-003

### Allowed files

- docs/task-context/ART-TASK-101.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-ADS-001,ART-SPEC-ADS-004] and ARCH IDs [ART-ARCH-ADS-002,ART-ARCH-ADS-003].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-101' -SpecIds 'ART-SPEC-ADS-001,ART-SPEC-ADS-004' -ArchIds 'ART-ARCH-ADS-002,ART-ARCH-ADS-003' -OutputPath 'docs/task-context/ART-TASK-101.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-101.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-101 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-102 - Implement emergency dock offer policy

- Plane work item ID: `e3fd8aa3-22a6-4b78-90ae-158febf6e7b9`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 62

### Objective

Suggest, but never force, a +1 dock offer near deadlock or after loss.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-043
- ART-TASK-101

### SPEC references

- ART-SPEC-ADS-002

### Architecture references

- ART-ARCH-ADS-005

### Allowed files

- application/Ads/EmergencyDockOfferPolicy.cs
- tests/AstroRebelsTraffic.Tests/Ads/OfferPolicyTests.cs

### Exact instructions

1. Create separate risk evaluator.

2. Never call or alter DeadlockDetector.

3. Suppress during resolution/tutorial instruction.

4. Suppress after four rewarded docks.

5. Return presentation suggestion only.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Offer policy cannot change loss classification.
- No offer during locked states.
- Post-loss suggestion is optional.

### Acceptance criteria

- Core solvability ignores offers.
- No repeated interruption loop exists.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-110 - Implement deterministic Mystery Ship reveal

- Plane work item ID: `b6ea94db-a0c6-4cd6-8470-d66d85bef1f3`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:planned`
- Module: Unassigned
- Plane sequence: 63

### Objective

Reveal a predefined hidden color when path becomes clear or the already-clear ship is selected.

### Executor

agent:alfredo

### 32K context contract

- Risk class: context-required
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-110.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-022
- ART-TASK-041
- ART-TASK-050
- ART-TASK-110-CTX

### SPEC references

- ART-SPEC-ADV-001

### Architecture references

- ART-ARCH-ADV-002
- ART-ARCH-RES-007

### Allowed files

- domain/Rules/Advanced/MysteryRules.cs
- tests/AstroRebelsTraffic.Tests/Advanced/MysteryTests.cs

### Exact instructions

1. Require hidden color in validated level data.

2. Never choose color at runtime.

3. Scan hidden ships in stable ID order after grid removal.

4. Emit reveal before passenger settlement.

5. Keep reveal for attempt.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Blocked-to-clear transition reveals deterministically.
- Selecting clear hidden ship reveals before release.
- Randomness is absent.

### Acceptance criteria

- Footprint blocks normally while hidden.
- Disabled mechanic has zero effect.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-110-CTX - Build bounded context pack for ART-TASK-110

- Plane work item ID: `c740650e-e696-41e2-8820-075110b1162f`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:alfredo`
- Type: `type:tooling`
- Scope: `scope:planned`
- Module: Unassigned
- Plane sequence: 109

### Objective

Create the only normative and repository context that ART-TASK-110 may consume.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-022
- ART-TASK-041
- ART-TASK-050
- ART-TASK-000

### SPEC references

- ART-SPEC-ADV-001

### Architecture references

- ART-ARCH-ADV-002
- ART-ARCH-RES-007

### Allowed files

- docs/task-context/ART-TASK-110.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-ADV-001] and ARCH IDs [ART-ARCH-ADV-002,ART-ARCH-RES-007].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-110' -SpecIds 'ART-SPEC-ADV-001' -ArchIds 'ART-ARCH-ADV-002,ART-ARCH-RES-007' -OutputPath 'docs/task-context/ART-TASK-110.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-110.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-110 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-111 - Implement Scanner booster command

- Plane work item ID: `a9e700d4-f00e-4650-bbd0-82e887494864`
- State: **Backlog**
- Priority: **low**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:planned`
- Module: Unassigned
- Plane sequence: 64

### Objective

Reveal all eligible Mystery Ships through one deterministic command without changing colors.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-047
- ART-TASK-110

### SPEC references

- ART-SPEC-ADV-005

### Architecture references

- ART-ARCH-ADV-006

### Allowed files

- domain/Commands/UseScannerCommand.cs
- application/Boosters/ScannerService.cs
- tests/AstroRebelsTraffic.Tests/Advanced/ScannerTests.cs

### Exact instructions

1. Validate mechanic and inventory availability.

2. Snapshot before accepted consumption if undo policy covers it.

3. Reveal predefined colors.

4. Emit events in stable ship order.

5. Do nothing when no Mystery system exists.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Scanner changes only reveal and approved inventory state.
- Repeated unavailable use is rejected unchanged.

### Acceptance criteria

- No random color exists.
- Baseline solver excludes Scanner.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-112 - Implement ordered Reserve/Hangar state and entry rules

- Plane work item ID: `6e346e9e-99a7-46d3-a0a7-78e759f29c7a`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:planned`
- Module: Unassigned
- Plane sequence: 65

### Objective

Enter configured reserve ships after a grid ship leaves when target cells are clear.

### Executor

agent:alfredo

### 32K context contract

- Risk class: context-required
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-112.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-020
- ART-TASK-041
- ART-TASK-050
- ART-TASK-112-CTX

### SPEC references

- ART-SPEC-ADV-002

### Architecture references

- ART-ARCH-ADV-003
- ART-ARCH-RES-006

### Allowed files

- domain/State/ReserveState.cs
- domain/Rules/Advanced/ReserveRules.cs
- tests/AstroRebelsTraffic.Tests/Advanced/ReserveTests.cs

### Exact instructions

1. Represent full order and configured visible prefix.

2. Validate target zone, entry cells and per-release count.

3. Check entry after grid removal before passenger settlement.

4. Preserve blocked reserve order.

5. Include reserve in conservation, win and hashing.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Clear entry inserts correct next ship.
- Blocked entry waits unchanged.
- Visible prefix never exposes more than configured.

### Acceptance criteria

- Disabled reserve has zero effect.
- Entry is deterministic and terminates.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-112-CTX - Build bounded context pack for ART-TASK-112

- Plane work item ID: `9d4c133f-57e7-4797-9610-4d96e40ad52a`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:alfredo`
- Type: `type:tooling`
- Scope: `scope:planned`
- Module: Unassigned
- Plane sequence: 110

### Objective

Create the only normative and repository context that ART-TASK-112 may consume.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-020
- ART-TASK-041
- ART-TASK-050
- ART-TASK-000

### SPEC references

- ART-SPEC-ADV-002

### Architecture references

- ART-ARCH-ADV-003
- ART-ARCH-RES-006

### Allowed files

- docs/task-context/ART-TASK-112.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-ADV-002] and ARCH IDs [ART-ARCH-ADV-003,ART-ARCH-RES-006].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-112' -SpecIds 'ART-SPEC-ADV-002' -ArchIds 'ART-ARCH-ADV-003,ART-ARCH-RES-006' -OutputPath 'docs/task-context/ART-TASK-112.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-112.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-112 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-113 - Enable multiple shared-resource grid zones â integration gate

- Plane work item ID: `40a0cf56-460b-4f23-8daa-b709ea9d6d5b`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:planned`
- Module: Unassigned
- Plane sequence: 66

### Objective

Close ART-TASK-113 only after its context, implementation and validation subtasks are Done. This gate performs no implementation.

### Executor

agent:alfredo

### 32K context contract

- Risk class: gate
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-113.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-113-VAL

### SPEC references

- ART-SPEC-ADV-003

### Architecture references

- ART-ARCH-ADV-004

### Allowed files

- docs/task-context/ART-TASK-113.md

### Exact instructions

1. Confirm ART-TASK-113-CTX, ART-TASK-113-P1, ART-TASK-113-P2 and ART-TASK-113-VAL are Done in Plane.

2. Confirm validation evidence addresses every original acceptance criterion.

3. Record the four subtask IDs and evidence links in the completion comment.

4. Do not read source files or rerun broad commands in this gate.

### Commands

None.

### Validation

- All four required subtasks are Done and none reports an unresolved blocker.

### Acceptance criteria

- The original task closes as a traceability gate without consuming implementation context.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-113-CTX - Build bounded context pack for ART-TASK-113

- Plane work item ID: `e66fb5d6-dcc5-4d66-b06c-39b4a176baa5`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:alfredo`
- Type: `type:tooling`
- Scope: `scope:planned`
- Module: Unassigned
- Plane sequence: 164

### Objective

Create the only normative and repository context that ART-TASK-113 may consume.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-012
- ART-TASK-022
- ART-TASK-045
- ART-TASK-062
- ART-TASK-000

### SPEC references

- ART-SPEC-ADV-003

### Architecture references

- ART-ARCH-ADV-004

### Allowed files

- docs/task-context/ART-TASK-113.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-ADV-003] and ARCH IDs [ART-ARCH-ADV-004].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-113' -SpecIds 'ART-SPEC-ADV-003' -ArchIds 'ART-ARCH-ADV-004' -OutputPath 'docs/task-context/ART-TASK-113.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-113.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-113 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-113-P1 - Enable multiple shared-resource grid zones â atomic implementation phase 1

- Plane work item ID: `fe0ff463-0ee7-4ca5-b749-45d8eac5c8c9`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:planned`
- Module: Unassigned
- Plane sequence: 165

### Objective

Perform only the first bounded half of ART-TASK-113; do not execute final validation or the remaining steps.

### Executor

agent:alfredo

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-113.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-113-CTX

### SPEC references

- ART-SPEC-ADV-003

### Architecture references

- ART-ARCH-ADV-004

### Allowed files

- domain/Rules/Advanced/MultiZoneRules.cs
- presentation/Gameplay/Grid/ZoneLayout.cs
- tests/AstroRebelsTraffic.Tests/Advanced/MultiZoneTests.cs

### Exact instructions

1. Use existing zone collection; do not clone rules.

2. Validate path against ship zone boundary.

3. Share one dock/queue state.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug

### Validation

- Changed files are within the task allowlist and the context pack exact-file list.
- No tool result exceeds 4,000 characters; verbose output is redirected to a file and summarized.
- The phase report lists unfinished original steps explicitly.

### Acceptance criteria

- Phase-one steps are implemented without claiming the original task complete.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-113-P2 - Enable multiple shared-resource grid zones â atomic implementation phase 2

- Plane work item ID: `13ae5f98-d3aa-4cec-93cc-0f0505520882`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:planned`
- Module: Unassigned
- Plane sequence: 166

### Objective

Perform only the remaining bounded half of ART-TASK-113 using phase-one artifacts.

### Executor

agent:alfredo

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-113.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-113-P1

### SPEC references

- ART-SPEC-ADV-003

### Architecture references

- ART-ARCH-ADV-004

### Allowed files

- domain/Rules/Advanced/MultiZoneRules.cs
- presentation/Gameplay/Grid/ZoneLayout.cs
- tests/AstroRebelsTraffic.Tests/Advanced/MultiZoneTests.cs

### Exact instructions

1. Include all zones in win/deadlock/solver.

2. Render configurable zone layout.

### Commands

- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Phase-one artifacts are present and unchanged except for required integration edits.
- Changed files are within the task allowlist and the context pack exact-file list.
- The phase report maps every original instruction to P1 or P2 evidence.

### Acceptance criteria

- All implementation instructions are covered; final acceptance is deferred to the validation phase.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-113-VAL - Enable multiple shared-resource grid zones â bounded validation

- Plane work item ID: `90ff45dc-3400-4204-abda-6e59dfb41195`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:alfredo`
- Type: `type:test`
- Scope: `scope:planned`
- Module: Unassigned
- Plane sequence: 167

### Objective

Validate ART-TASK-113 without implementing new functionality.

### Executor

agent:alfredo

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-113.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-113-P2

### SPEC references

- ART-SPEC-ADV-003

### Architecture references

- ART-ARCH-ADV-004

### Allowed files

- domain/Rules/Advanced/MultiZoneRules.cs
- presentation/Gameplay/Grid/ZoneLayout.cs
- tests/AstroRebelsTraffic.Tests/Advanced/MultiZoneTests.cs

### Exact instructions

1. Run only the original validation commands with concise output.

2. Record exit codes and the smallest relevant failure output.

3. Check every original acceptance criterion against observable evidence.

4. Do not repair failures; return BLOCKED with the exact failing phase.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Two-zone fixture solves through shared docks.
- Ship in one zone never blocks another zone path.
- All zones required for win.

### Acceptance criteria

- No per-zone boarding copy exists.
- Single-zone behavior remains identical.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-114 - Resolve VIP Dock routing product decision

- Plane work item ID: `0770492c-e1e2-4d3c-8f52-7f71cf488649`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:paula`
- Type: `type:decision`
- Scope: `scope:planned`
- Module: Unassigned
- Plane sequence: 67

### Objective

Define exactly how a released ship is routed into the VIP Dock before any VIP gameplay code exists.

### Executor

agent:paula

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-101

### SPEC references

- ART-SPEC-ADV-004
- ART-SPEC-OPEN-002

### Architecture references

- ART-ARCH-ADV-005

### Allowed files

- docs/VIP_DOCK_DECISION.md

### Exact instructions

1. Choose activation source and attempt duration.

2. Define whether routing is automatic or player-commanded.

3. Define routing priority relative to standard docks.

4. Define deadlock eligibility.

5. Confirm no universal-color boarding.

6. Update SPEC/ARCH by approved change if required.

### Commands

None.

### Validation

- Decision answers every listed question.
- No TBD remains for VIP routing.

### Acceptance criteria

- Product Owner signs off.
- Implementation task remains blocked until Done.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-115 - Implement VIP Dock after routing approval â integration gate

- Plane work item ID: `6880767c-44fe-4c66-9100-95932042684b`
- State: **Backlog**
- Priority: **low**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:planned`
- Module: Unassigned
- Plane sequence: 68

### Objective

Close ART-TASK-115 only after its context, implementation and validation subtasks are Done. This gate performs no implementation.

### Executor

agent:alfredo

### 32K context contract

- Risk class: gate
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-115.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-115-VAL

### SPEC references

- ART-SPEC-ADV-004

### Architecture references

- ART-ARCH-ADV-005

### Allowed files

- docs/task-context/ART-TASK-115.md

### Exact instructions

1. Confirm ART-TASK-115-CTX, ART-TASK-115-P1, ART-TASK-115-P2 and ART-TASK-115-VAL are Done in Plane.

2. Confirm validation evidence addresses every original acceptance criterion.

3. Record the four subtask IDs and evidence links in the completion comment.

4. Do not read source files or rerun broad commands in this gate.

### Commands

None.

### Validation

- All four required subtasks are Done and none reports an unresolved blocker.

### Acceptance criteria

- The original task closes as a traceability gate without consuming implementation context.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-115-CTX - Build bounded context pack for ART-TASK-115

- Plane work item ID: `1331bd63-78ad-46d7-8cf0-c39832bd11ca`
- State: **Backlog**
- Priority: **low**
- Executor: `agent:alfredo`
- Type: `type:tooling`
- Scope: `scope:planned`
- Module: Unassigned
- Plane sequence: 168

### Objective

Create the only normative and repository context that ART-TASK-115 may consume.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-114
- ART-TASK-000

### SPEC references

- ART-SPEC-ADV-004

### Architecture references

- ART-ARCH-ADV-005

### Allowed files

- docs/task-context/ART-TASK-115.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-ADV-004] and ARCH IDs [ART-ARCH-ADV-005].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-115' -SpecIds 'ART-SPEC-ADV-004' -ArchIds 'ART-ARCH-ADV-005' -OutputPath 'docs/task-context/ART-TASK-115.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-115.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-115 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-115-P1 - Implement VIP Dock after routing approval â atomic implementation phase 1

- Plane work item ID: `4f549e14-c9d5-429a-9872-2dedfc8da52c`
- State: **Backlog**
- Priority: **low**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:planned`
- Module: Unassigned
- Plane sequence: 169

### Objective

Perform only the first bounded half of ART-TASK-115; do not execute final validation or the remaining steps.

### Executor

agent:alfredo

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-115.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-115-CTX

### SPEC references

- ART-SPEC-ADV-004

### Architecture references

- ART-ARCH-ADV-005

### Allowed files

- domain/State/VipDockState.cs
- domain/Rules/Advanced/VipDockRules.cs
- tests/AstroRebelsTraffic.Tests/Advanced/VipDockTests.cs

### Exact instructions

1. Copy approved routing verbatim into tests.

2. Model VIP outside eight standard docks.

3. Do not change ship color.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug

### Validation

- Changed files are within the task allowlist and the context pack exact-file list.
- No tool result exceeds 4,000 characters; verbose output is redirected to a file and summarized.
- The phase report lists unfinished original steps explicitly.

### Acceptance criteria

- Phase-one steps are implemented without claiming the original task complete.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-115-P2 - Implement VIP Dock after routing approval â atomic implementation phase 2

- Plane work item ID: `011f7045-471a-44c7-8581-717e64dcb2f1`
- State: **Backlog**
- Priority: **low**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:planned`
- Module: Unassigned
- Plane sequence: 170

### Objective

Perform only the remaining bounded half of ART-TASK-115 using phase-one artifacts.

### Executor

agent:alfredo

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-115.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-115-P1

### SPEC references

- ART-SPEC-ADV-004

### Architecture references

- ART-ARCH-ADV-005

### Allowed files

- domain/State/VipDockState.cs
- domain/Rules/Advanced/VipDockRules.cs
- tests/AstroRebelsTraffic.Tests/Advanced/VipDockTests.cs

### Exact instructions

1. Integrate exact win/deadlock eligibility.

2. Add command/event/UI integration.

### Commands

- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Phase-one artifacts are present and unchanged except for required integration edits.
- Changed files are within the task allowlist and the context pack exact-file list.
- The phase report maps every original instruction to P1 or P2 evidence.

### Acceptance criteria

- All implementation instructions are covered; final acceptance is deferred to the validation phase.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-115-VAL - Implement VIP Dock after routing approval â bounded validation

- Plane work item ID: `9fbcf327-0d10-452b-a8cd-2be9d4fbc0ec`
- State: **Backlog**
- Priority: **low**
- Executor: `agent:alfredo`
- Type: `type:test`
- Scope: `scope:planned`
- Module: Unassigned
- Plane sequence: 171

### Objective

Validate ART-TASK-115 without implementing new functionality.

### Executor

agent:alfredo

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-115.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-115-P2

### SPEC references

- ART-SPEC-ADV-004

### Architecture references

- ART-ARCH-ADV-005

### Allowed files

- domain/State/VipDockState.cs
- domain/Rules/Advanced/VipDockRules.cs
- tests/AstroRebelsTraffic.Tests/Advanced/VipDockTests.cs

### Exact instructions

1. Run only the original validation commands with concise output.

2. Record exit codes and the smallest relevant failure output.

3. Check every original acceptance criterion against observable evidence.

4. Do not repair failures; return BLOCKED with the exact failing phase.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Approved routing fixtures pass.
- Standard dock behavior is unchanged.
- VIP never provides universal-color boarding.

### Acceptance criteria

- No unresolved behavior was invented.
- Disabled VIP has zero effect.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-116 - Implement Extra Dock booster using authorized activation rule

- Plane work item ID: `1af1aa71-943c-40d4-88c3-621086a64a7d`
- State: **Backlog**
- Priority: **low**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:planned`
- Module: Unassigned
- Plane sequence: 69

### Objective

Consume the booster and activate one temporary rewarded standard dock using the same domain limit.

### Executor

agent:alfredo

### 32K context contract

- Risk class: context-required
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-116.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-047
- ART-TASK-031
- ART-TASK-116-CTX

### SPEC references

- ART-SPEC-ADV-005

### Architecture references

- ART-ARCH-ADV-006

### Allowed files

- domain/Commands/UseExtraDockCommand.cs
- application/Boosters/ExtraDockService.cs
- tests/AstroRebelsTraffic.Tests/Advanced/ExtraDockTests.cs

### Exact instructions

1. Validate booster enabled/inventory.

2. Snapshot before accepted move if applicable.

3. Dispatch existing dock activation rule.

4. Consume once only on success.

5. Keep attempt-local dock state out of progression save.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- One booster opens one dock.
- No fifth dock activation.
- Failure does not consume inventory.

### Acceptance criteria

- No duplicate dock rule exists.
- Baseline solvability excludes booster.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-116-CTX - Build bounded context pack for ART-TASK-116

- Plane work item ID: `ccc54cae-1baf-4326-87fe-b1db5beb207a`
- State: **Backlog**
- Priority: **low**
- Executor: `agent:alfredo`
- Type: `type:tooling`
- Scope: `scope:planned`
- Module: Unassigned
- Plane sequence: 111

### Objective

Create the only normative and repository context that ART-TASK-116 may consume.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-047
- ART-TASK-031
- ART-TASK-000

### SPEC references

- ART-SPEC-ADV-005

### Architecture references

- ART-ARCH-ADV-006

### Allowed files

- docs/task-context/ART-TASK-116.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-ADV-005] and ARCH IDs [ART-ARCH-ADV-006].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-116' -SpecIds 'ART-SPEC-ADV-005' -ArchIds 'ART-ARCH-ADV-006' -OutputPath 'docs/task-context/ART-TASK-116.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-116.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-116 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-120 - Create original art bible and asset acceptance checklist

- Plane work item ID: `ec9f83d7-d770-4867-a033-5832e04af2a3`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:lucia`
- Type: `type:art`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 70

### Objective

Define original cartoon sci-fi readability, scale, materials, faction cues and validation before production assets.

### Executor

agent:lucia

### 32K context contract

- Risk class: context-required
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-120.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-002
- ART-TASK-120-CTX

### SPEC references

- ART-SPEC-ART-001
- ART-SPEC-ART-007

### Architecture references

- ART-ARCH-PRES-004

### Allowed files

- docs/ART_BIBLE.md
- docs/ASSET_ACCEPTANCE.md

### Exact instructions

1. Document prohibited direct copying.

2. Define mobile readability and contrast.

3. Define ship/passenger/dock/faction symbol rules.

4. Define pivot, scale, material and license checks.

5. Define LOD/poly/texture budgets after reference-device profiling.

### Commands

None.

### Validation

- Checklist covers license, originality, readability and performance.
- Product Owner approves representative direction.

### Acceptance criteria

- No generated asset enters production without checklist.
- Puzzle readability has priority.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-120-CTX - Build bounded context pack for ART-TASK-120

- Plane work item ID: `c9506353-491c-43ad-bcef-e36e57ef0cca`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:lucia`
- Type: `type:tooling`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 112

### Objective

Create the only normative and repository context that ART-TASK-120 may consume.

### Executor

agent:lucia

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-002
- ART-TASK-000

### SPEC references

- ART-SPEC-ART-001
- ART-SPEC-ART-007

### Architecture references

- ART-ARCH-PRES-004

### Allowed files

- docs/task-context/ART-TASK-120.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-ART-001,ART-SPEC-ART-007] and ARCH IDs [ART-ARCH-PRES-004].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-120' -SpecIds 'ART-SPEC-ART-001,ART-SPEC-ART-007' -ArchIds 'ART-ARCH-PRES-004' -OutputPath 'docs/task-context/ART-TASK-120.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-120.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-120 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-121 - Produce validated Small, Medium and Large ship families â integration gate

- Plane work item ID: `5350084a-d6eb-435c-8f2a-48e42e9e9172`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:bruno`
- Type: `type:art`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 71

### Objective

Close ART-TASK-121 only after its context, implementation and validation subtasks are Done. This gate performs no implementation.

### Executor

agent:bruno

### 32K context contract

- Risk class: gate
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-121.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-121-VAL

### SPEC references

- ART-SPEC-ART-002
- ART-SPEC-ART-004
- ART-SPEC-ART-008

### Architecture references

- ART-ARCH-PRES-004

### Allowed files

- docs/task-context/ART-TASK-121.md

### Exact instructions

1. Confirm ART-TASK-121-CTX, ART-TASK-121-P1, ART-TASK-121-P2 and ART-TASK-121-VAL are Done in Plane.

2. Confirm validation evidence addresses every original acceptance criterion.

3. Record the four subtask IDs and evidence links in the completion comment.

4. Do not read source files or rerun broad commands in this gate.

### Commands

None.

### Validation

- All four required subtasks are Done and none reports an unresolved blocker.

### Acceptance criteria

- The original task closes as a traceability gate without consuming implementation context.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-121-CTX - Build bounded context pack for ART-TASK-121

- Plane work item ID: `3c0cf27a-0a6d-442f-b39f-b64a739239ff`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:bruno`
- Type: `type:tooling`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 172

### Objective

Create the only normative and repository context that ART-TASK-121 may consume.

### Executor

agent:bruno

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-120
- ART-TASK-075
- ART-TASK-000

### SPEC references

- ART-SPEC-ART-002
- ART-SPEC-ART-004
- ART-SPEC-ART-008

### Architecture references

- ART-ARCH-PRES-004

### Allowed files

- docs/task-context/ART-TASK-121.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-ART-002,ART-SPEC-ART-004,ART-SPEC-ART-008] and ARCH IDs [ART-ARCH-PRES-004].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-121' -SpecIds 'ART-SPEC-ART-002,ART-SPEC-ART-004,ART-SPEC-ART-008' -ArchIds 'ART-ARCH-PRES-004' -OutputPath 'docs/task-context/ART-TASK-121.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-121.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-121 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-121-P1 - Produce validated Small, Medium and Large ship families â atomic implementation phase 1

- Plane work item ID: `ce43002e-d1bf-4144-92de-85b4029abde0`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:bruno`
- Type: `type:art`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 173

### Objective

Perform only the first bounded half of ART-TASK-121; do not execute final validation or the remaining steps.

### Executor

agent:bruno

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-121.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-121-CTX

### SPEC references

- ART-SPEC-ART-002
- ART-SPEC-ART-004
- ART-SPEC-ART-008

### Architecture references

- ART-ARCH-PRES-004

### Allowed files

- assets/Art/Ships/**
- assets/Catalogs/ship_catalog.tres

### Exact instructions

1. Create silhouettes for lengths 1, 2 and 3.

2. Apply color plus faction symbol.

3. Provide orientation/propulsion cue.

### Commands

None.

### Validation

- Changed files are within the task allowlist and the context pack exact-file list.
- No tool result exceeds 4,000 characters; verbose output is redirected to a file and summarized.
- The phase report lists unfinished original steps explicitly.

### Acceptance criteria

- Phase-one steps are implemented without claiming the original task complete.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-121-P2 - Produce validated Small, Medium and Large ship families â atomic implementation phase 2

- Plane work item ID: `74af6c90-5a01-43f9-bde8-2b72ad70fa69`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:bruno`
- Type: `type:art`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 174

### Objective

Perform only the remaining bounded half of ART-TASK-121 using phase-one artifacts.

### Executor

agent:bruno

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-121.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-121-P1

### SPEC references

- ART-SPEC-ART-002
- ART-SPEC-ART-004
- ART-SPEC-ART-008

### Architecture references

- ART-ARCH-PRES-004

### Allowed files

- assets/Art/Ships/**
- assets/Catalogs/ship_catalog.tres

### Exact instructions

1. Clean, optimize, set pivots/scale and export through approved pipeline.

2. Validate in smallest dense-grid presentation.

### Commands

None.

### Validation

- Phase-one artifacts are present and unchanged except for required integration edits.
- Changed files are within the task allowlist and the context pack exact-file list.
- The phase report maps every original instruction to P1 or P2 evidence.

### Acceptance criteria

- All implementation instructions are covered; final acceptance is deferred to the validation phase.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-121-VAL - Produce validated Small, Medium and Large ship families â bounded validation

- Plane work item ID: `921023d0-2d0d-4c11-9522-7612c6f0e42c`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:bruno`
- Type: `type:test`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 175

### Objective

Validate ART-TASK-121 without implementing new functionality.

### Executor

agent:bruno

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-121.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-121-P2

### SPEC references

- ART-SPEC-ART-002
- ART-SPEC-ART-004
- ART-SPEC-ART-008

### Architecture references

- ART-ARCH-PRES-004

### Allowed files

- assets/Art/Ships/**
- assets/Catalogs/ship_catalog.tres

### Exact instructions

1. Run only the original validation commands with concise output.

2. Record exit codes and the smallest relevant failure output.

3. Check every original acceptance criterion against observable evidence.

4. Do not repair failures; return BLOCKED with the exact failing phase.

### Commands

None.

### Validation

- Three sizes are distinguishable without color.
- Direction is clear without relying only on arrow.
- Assets pass acceptance checklist.

### Acceptance criteria

- No complex ship rig is added.
- Catalog maps stable IDs only.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-122 - Produce accessible passenger presentation set â integration gate

- Plane work item ID: `dc905c9a-10c1-4cd0-8c43-8125b1a14fb1`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:lucia`
- Type: `type:art`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 72

### Objective

Close ART-TASK-122 only after its context, implementation and validation subtasks are Done. This gate performs no implementation.

### Executor

agent:lucia

### 32K context contract

- Risk class: gate
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-122.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-122-VAL

### SPEC references

- ART-SPEC-ART-003

### Architecture references

- ART-ARCH-PRES-003
- ART-ARCH-PRES-004

### Allowed files

- docs/task-context/ART-TASK-122.md

### Exact instructions

1. Confirm ART-TASK-122-CTX, ART-TASK-122-P1, ART-TASK-122-P2 and ART-TASK-122-VAL are Done in Plane.

2. Confirm validation evidence addresses every original acceptance criterion.

3. Record the four subtask IDs and evidence links in the completion comment.

4. Do not read source files or rerun broad commands in this gate.

### Commands

None.

### Validation

- All four required subtasks are Done and none reports an unresolved blocker.

### Acceptance criteria

- The original task closes as a traceability gate without consuming implementation context.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-122-CTX - Build bounded context pack for ART-TASK-122

- Plane work item ID: `f2fb6e12-12a7-4b2e-a86d-eb298e53eaa0`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:lucia`
- Type: `type:tooling`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 176

### Objective

Create the only normative and repository context that ART-TASK-122 may consume.

### Executor

agent:lucia

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-120
- ART-TASK-075
- ART-TASK-000

### SPEC references

- ART-SPEC-ART-003

### Architecture references

- ART-ARCH-PRES-003
- ART-ARCH-PRES-004

### Allowed files

- docs/task-context/ART-TASK-122.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-ART-003] and ARCH IDs [ART-ARCH-PRES-003,ART-ARCH-PRES-004].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-122' -SpecIds 'ART-SPEC-ART-003' -ArchIds 'ART-ARCH-PRES-003,ART-ARCH-PRES-004' -OutputPath 'docs/task-context/ART-TASK-122.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-122.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-122 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-122-P1 - Produce accessible passenger presentation set â atomic implementation phase 1

- Plane work item ID: `5e20f9ee-b531-4ce1-91b7-f59e719f623f`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:lucia`
- Type: `type:art`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 177

### Objective

Perform only the first bounded half of ART-TASK-122; do not execute final validation or the remaining steps.

### Executor

agent:lucia

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-122.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-122-CTX

### SPEC references

- ART-SPEC-ART-003

### Architecture references

- ART-ARCH-PRES-003
- ART-ARCH-PRES-004

### Allowed files

- assets/Art/Passengers/**
- assets/Catalogs/passenger_catalog.tres

### Exact instructions

1. Create base reusable variants.

2. Bind each logical color to suit/helmet color and symbol.

3. Rig only characters requiring animation.

### Commands

None.

### Validation

- Changed files are within the task allowlist and the context pack exact-file list.
- No tool result exceeds 4,000 characters; verbose output is redirected to a file and summarized.
- The phase report lists unfinished original steps explicitly.

### Acceptance criteria

- Phase-one steps are implemented without claiming the original task complete.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-122-P2 - Produce accessible passenger presentation set â atomic implementation phase 2

- Plane work item ID: `d1e6cc10-b14d-4649-b807-c8166a3dfa44`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:lucia`
- Type: `type:art`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 178

### Objective

Perform only the remaining bounded half of ART-TASK-122 using phase-one artifacts.

### Executor

agent:lucia

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-122.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-122-P1

### SPEC references

- ART-SPEC-ART-003

### Architecture references

- ART-ARCH-PRES-003
- ART-ARCH-PRES-004

### Allowed files

- assets/Art/Passengers/**
- assets/Catalogs/passenger_catalog.tres

### Exact instructions

1. Validate pooled reset requirements.

2. Test at 100-passenger density.

### Commands

None.

### Validation

- Phase-one artifacts are present and unchanged except for required integration edits.
- Changed files are within the task allowlist and the context pack exact-file list.
- The phase report maps every original instruction to P1 or P2 evidence.

### Acceptance criteria

- All implementation instructions are covered; final acceptance is deferred to the validation phase.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-122-VAL - Produce accessible passenger presentation set â bounded validation

- Plane work item ID: `67b829f6-06f7-4d56-baf6-05512d8aeb09`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:lucia`
- Type: `type:test`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 179

### Objective

Validate ART-TASK-122 without implementing new functionality.

### Executor

agent:lucia

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-122.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-122-P2

### SPEC references

- ART-SPEC-ART-003

### Architecture references

- ART-ARCH-PRES-003
- ART-ARCH-PRES-004

### Allowed files

- assets/Art/Passengers/**
- assets/Catalogs/passenger_catalog.tres

### Exact instructions

1. Run only the original validation commands with concise output.

2. Record exit codes and the smallest relevant failure output.

3. Check every original acceptance criterion against observable evidence.

4. Do not repair failures; return BLOCKED with the exact failing phase.

### Commands

None.

### Validation

- Every enabled color is distinguishable by symbol.
- Variants share materials where practical.
- Assets pass acceptance checklist.

### Acceptance criteria

- No logical passenger data is embedded in scene instances.
- Readability survives density target.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-123 - Implement required animation and VFX event mappings â integration gate

- Plane work item ID: `2f067f25-e23d-400d-b19f-e88d27dfa287`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:nicolas`
- Type: `type:art`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 73

### Objective

Close ART-TASK-123 only after its context, implementation and validation subtasks are Done. This gate performs no implementation.

### Executor

agent:nicolas

### 32K context contract

- Risk class: gate
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-123.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-123-VAL

### SPEC references

- ART-SPEC-ART-006
- ART-SPEC-ART-009

### Architecture references

- ART-ARCH-EVENT-002
- ART-ARCH-PRES-001

### Allowed files

- docs/task-context/ART-TASK-123.md

### Exact instructions

1. Confirm ART-TASK-123-CTX, ART-TASK-123-P1, ART-TASK-123-P2 and ART-TASK-123-VAL are Done in Plane.

2. Confirm validation evidence addresses every original acceptance criterion.

3. Record the four subtask IDs and evidence links in the completion comment.

4. Do not read source files or rerun broad commands in this gate.

### Commands

None.

### Validation

- All four required subtasks are Done and none reports an unresolved blocker.

### Acceptance criteria

- The original task closes as a traceability gate without consuming implementation context.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-123-CTX - Build bounded context pack for ART-TASK-123

- Plane work item ID: `dd4e8ec8-5dbb-4fdb-b91f-52194be5398f`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:nicolas`
- Type: `type:tooling`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 180

### Objective

Create the only normative and repository context that ART-TASK-123 may consume.

### Executor

agent:nicolas

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-073
- ART-TASK-121
- ART-TASK-122
- ART-TASK-000

### SPEC references

- ART-SPEC-ART-006
- ART-SPEC-ART-009

### Architecture references

- ART-ARCH-EVENT-002
- ART-ARCH-PRES-001

### Allowed files

- docs/task-context/ART-TASK-123.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-ART-006,ART-SPEC-ART-009] and ARCH IDs [ART-ARCH-EVENT-002,ART-ARCH-PRES-001].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-123' -SpecIds 'ART-SPEC-ART-006,ART-SPEC-ART-009' -ArchIds 'ART-ARCH-EVENT-002,ART-ARCH-PRES-001' -OutputPath 'docs/task-context/ART-TASK-123.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-123.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-123 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-123-P1 - Implement required animation and VFX event mappings â atomic implementation phase 1

- Plane work item ID: `98db5014-2288-4fdf-8dae-e09a7f801dc9`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:nicolas`
- Type: `type:art`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 181

### Objective

Perform only the first bounded half of ART-TASK-123; do not execute final validation or the remaining steps.

### Executor

agent:nicolas

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-123.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-123-CTX

### SPEC references

- ART-SPEC-ART-006
- ART-SPEC-ART-009

### Architecture references

- ART-ARCH-EVENT-002
- ART-ARCH-PRES-001

### Allowed files

- presentation/Vfx/**
- assets/Art/Vfx/**

### Exact instructions

1. Implement exit 0.2â0.4s and dock entry 0.2â0.4s.

2. Implement grouped boarding pulse.

3. Implement departure no longer than about 0.7s.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug

### Validation

- Changed files are within the task allowlist and the context pack exact-file list.
- No tool result exceeds 4,000 characters; verbose output is redirected to a file and summarized.
- The phase report lists unfinished original steps explicitly.

### Acceptance criteria

- Phase-one steps are implemented without claiming the original task complete.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-123-P2 - Implement required animation and VFX event mappings â atomic implementation phase 2

- Plane work item ID: `2e27083e-a767-4956-abc0-8cf07a241223`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:nicolas`
- Type: `type:art`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 182

### Objective

Perform only the remaining bounded half of ART-TASK-123 using phase-one artifacts.

### Executor

agent:nicolas

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-123.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-123-P1

### SPEC references

- ART-SPEC-ART-006
- ART-SPEC-ART-009

### Architecture references

- ART-ARCH-EVENT-002
- ART-ARCH-PRES-001

### Allowed files

- presentation/Vfx/**
- assets/Art/Vfx/**

### Exact instructions

1. Add trail, arrival flash, propulsion, error and win VFX.

2. Ensure skip/rebuild ends in authoritative state.

### Commands

- & 'C:\Users\eorod\Desktop\Godot_v4.7.1-stable_mono_win64\Godot_v4.7.1-stable_mono_win64_console.exe' --headless --path 'C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic' --editor --quit

### Validation

- Phase-one artifacts are present and unchanged except for required integration edits.
- Changed files are within the task allowlist and the context pack exact-file list.
- The phase report maps every original instruction to P1 or P2 evidence.

### Acceptance criteria

- All implementation instructions are covered; final acceptance is deferred to the validation phase.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-123-VAL - Implement required animation and VFX event mappings â bounded validation

- Plane work item ID: `96e050f4-c156-4ecc-8f7c-50ab68c85403`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:nicolas`
- Type: `type:test`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 183

### Objective

Validate ART-TASK-123 without implementing new functionality.

### Executor

agent:nicolas

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-123.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-123-P2

### SPEC references

- ART-SPEC-ART-006
- ART-SPEC-ART-009

### Architecture references

- ART-ARCH-EVENT-002
- ART-ARCH-PRES-001

### Allowed files

- presentation/Vfx/**
- assets/Art/Vfx/**

### Exact instructions

1. Run only the original validation commands with concise output.

2. Record exit codes and the smallest relevant failure output.

3. Check every original acceptance criterion against observable evidence.

4. Do not repair failures; return BLOCKED with the exact failing phase.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- & 'C:\Users\eorod\Desktop\Godot_v4.7.1-stable_mono_win64\Godot_v4.7.1-stable_mono_win64_console.exe' --headless --path 'C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic' --editor --quit

### Validation

- Timings meet targets.
- VFX never obscures state.
- Instant mode produces no stale view.

### Acceptance criteria

- Animation never changes logical outcome.
- Pools reset effects fully.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-124 - Implement music, SFX and independent settings â integration gate

- Plane work item ID: `d26a8dce-8984-4d24-83ba-e9425c1170da`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:nicolas`
- Type: `type:art`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 74

### Objective

Close ART-TASK-124 only after its context, implementation and validation subtasks are Done. This gate performs no implementation.

### Executor

agent:nicolas

### 32K context contract

- Risk class: gate
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-124.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-124-VAL

### SPEC references

- ART-SPEC-AUDIO-001

### Architecture references

- ART-ARCH-EVENT-002

### Allowed files

- docs/task-context/ART-TASK-124.md

### Exact instructions

1. Confirm ART-TASK-124-CTX, ART-TASK-124-P1, ART-TASK-124-P2 and ART-TASK-124-VAL are Done in Plane.

2. Confirm validation evidence addresses every original acceptance criterion.

3. Record the four subtask IDs and evidence links in the completion comment.

4. Do not read source files or rerun broad commands in this gate.

### Commands

None.

### Validation

- All four required subtasks are Done and none reports an unresolved blocker.

### Acceptance criteria

- The original task closes as a traceability gate without consuming implementation context.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-124-CTX - Build bounded context pack for ART-TASK-124

- Plane work item ID: `dcd1b0c5-e47e-4991-ab2e-256ca46eb79d`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:nicolas`
- Type: `type:tooling`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 184

### Objective

Create the only normative and repository context that ART-TASK-124 may consume.

### Executor

agent:nicolas

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-090
- ART-TASK-073
- ART-TASK-000

### SPEC references

- ART-SPEC-AUDIO-001

### Architecture references

- ART-ARCH-EVENT-002

### Allowed files

- docs/task-context/ART-TASK-124.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-AUDIO-001] and ARCH IDs [ART-ARCH-EVENT-002].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-124' -SpecIds 'ART-SPEC-AUDIO-001' -ArchIds 'ART-ARCH-EVENT-002' -OutputPath 'docs/task-context/ART-TASK-124.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-124.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-124 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-124-P1 - Implement music, SFX and independent settings â atomic implementation phase 1

- Plane work item ID: `8ccaa987-1b9e-463c-92d5-7bcdbfa9586a`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:nicolas`
- Type: `type:art`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 185

### Objective

Perform only the first bounded half of ART-TASK-124; do not execute final validation or the remaining steps.

### Executor

agent:nicolas

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-124.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-124-CTX

### SPEC references

- ART-SPEC-AUDIO-001

### Architecture references

- ART-ARCH-EVENT-002

### Allowed files

- audio/**
- assets/Audio/**
- presentation/Audio/AudioCoordinator.cs

### Exact instructions

1. Provide tap, movement, error, dock, boarding, full, departure, victory and defeat SFX.

2. Map events in AudioCoordinator.

3. Apply saved music and SFX values independently.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug

### Validation

- Changed files are within the task allowlist and the context pack exact-file list.
- No tool result exceeds 4,000 characters; verbose output is redirected to a file and summarized.
- The phase report lists unfinished original steps explicitly.

### Acceptance criteria

- Phase-one steps are implemented without claiming the original task complete.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-124-P2 - Implement music, SFX and independent settings â atomic implementation phase 2

- Plane work item ID: `9d8b4bc9-6935-4a82-962d-141034416fb2`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:nicolas`
- Type: `type:art`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 186

### Objective

Perform only the remaining bounded half of ART-TASK-124 using phase-one artifacts.

### Executor

agent:nicolas

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-124.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-124-P1

### SPEC references

- ART-SPEC-AUDIO-001

### Architecture references

- ART-ARCH-EVENT-002

### Allowed files

- audio/**
- assets/Audio/**
- presentation/Audio/AudioCoordinator.cs

### Exact instructions

1. Handle missing audio safely.

2. Validate licenses and loudness consistency.

### Commands

None.

### Validation

- Phase-one artifacts are present and unchanged except for required integration edits.
- Changed files are within the task allowlist and the context pack exact-file list.
- The phase report maps every original instruction to P1 or P2 evidence.

### Acceptance criteria

- All implementation instructions are covered; final acceptance is deferred to the validation phase.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-124-VAL - Implement music, SFX and independent settings â bounded validation

- Plane work item ID: `9ad249cf-3d63-4787-ae44-322a36b91962`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:nicolas`
- Type: `type:test`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 187

### Objective

Validate ART-TASK-124 without implementing new functionality.

### Executor

agent:nicolas

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-124.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-124-P2

### SPEC references

- ART-SPEC-AUDIO-001

### Architecture references

- ART-ARCH-EVENT-002

### Allowed files

- audio/**
- assets/Audio/**
- presentation/Audio/AudioCoordinator.cs

### Exact instructions

1. Run only the original validation commands with concise output.

2. Record exit codes and the smallest relevant failure output.

3. Check every original acceptance criterion against observable evidence.

4. Do not repair failures; return BLOCKED with the exact failing phase.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug

### Validation

- Every required category has a mapped asset or approved placeholder.
- Music mute does not mute SFX and vice versa.

### Acceptance criteria

- Domain has no audio dependency.
- Audio failure cannot block resolution.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-130 - Configure Android development export â integration gate

- Plane work item ID: `52297d87-bbe1-4d91-874b-e0d9d5e029b8`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:nicolas`
- Type: `type:release`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 75

### Objective

Close ART-TASK-130 only after its context, implementation and validation subtasks are Done. This gate performs no implementation.

### Executor

agent:nicolas

### 32K context contract

- Risk class: gate
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-130.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-130-VAL

### SPEC references

- ART-SPEC-PLAT-001

### Architecture references

- ART-ARCH-TEST-005

### Allowed files

- docs/task-context/ART-TASK-130.md

### Exact instructions

1. Confirm ART-TASK-130-CTX, ART-TASK-130-P1, ART-TASK-130-P2 and ART-TASK-130-VAL are Done in Plane.

2. Confirm validation evidence addresses every original acceptance criterion.

3. Record the four subtask IDs and evidence links in the completion comment.

4. Do not read source files or rerun broad commands in this gate.

### Commands

None.

### Validation

- All four required subtasks are Done and none reports an unresolved blocker.

### Acceptance criteria

- The original task closes as a traceability gate without consuming implementation context.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-130-CTX - Build bounded context pack for ART-TASK-130

- Plane work item ID: `892052b5-7d6e-40ea-a9f9-e109e8fdd2e7`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:nicolas`
- Type: `type:tooling`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 188

### Objective

Create the only normative and repository context that ART-TASK-130 may consume.

### Executor

agent:nicolas

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-070
- ART-TASK-005
- ART-TASK-000

### SPEC references

- ART-SPEC-PLAT-001

### Architecture references

- ART-ARCH-TEST-005

### Allowed files

- docs/task-context/ART-TASK-130.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-PLAT-001] and ARCH IDs [ART-ARCH-TEST-005].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-130' -SpecIds 'ART-SPEC-PLAT-001' -ArchIds 'ART-ARCH-TEST-005' -OutputPath 'docs/task-context/ART-TASK-130.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-130.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-130 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-130-P1 - Configure Android development export â atomic implementation phase 1

- Plane work item ID: `e1df1238-0ee8-4271-8769-3e24607b7302`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:nicolas`
- Type: `type:release`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 189

### Objective

Perform only the first bounded half of ART-TASK-130; do not execute final validation or the remaining steps.

### Executor

agent:nicolas

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-130.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-130-CTX

### SPEC references

- ART-SPEC-PLAT-001

### Architecture references

- ART-ARCH-TEST-005

### Allowed files

- export_presets.cfg
- android/**
- docs/ANDROID_BUILD.md

### Exact instructions

1. Install/verify Godot Android requirements.

2. Configure package ID, portrait, min/target SDK from current store requirements at execution time.

3. Store signing values outside repository.

### Commands

- & 'C:\Users\eorod\Desktop\Godot_v4.7.1-stable_mono_win64\Godot_v4.7.1-stable_mono_win64_console.exe' --headless --path 'C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic' --export-debug 'Android' build\android\AstroRebelsTraffic-debug.apk

### Validation

- Changed files are within the task allowlist and the context pack exact-file list.
- No tool result exceeds 4,000 characters; verbose output is redirected to a file and summarized.
- The phase report lists unfinished original steps explicitly.

### Acceptance criteria

- Phase-one steps are implemented without claiming the original task complete.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-130-P2 - Configure Android development export â atomic implementation phase 2

- Plane work item ID: `b17e4a9e-04c1-4287-baec-474d65904655`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:nicolas`
- Type: `type:release`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 190

### Objective

Perform only the remaining bounded half of ART-TASK-130 using phase-one artifacts.

### Executor

agent:nicolas

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-130.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-130-P1

### SPEC references

- ART-SPEC-PLAT-001

### Architecture references

- ART-ARCH-TEST-005

### Allowed files

- export_presets.cfg
- android/**
- docs/ANDROID_BUILD.md

### Exact instructions

1. Document exact export command.

2. Run on named mid-range device.

### Commands

None.

### Validation

- Phase-one artifacts are present and unchanged except for required integration edits.
- Changed files are within the task allowlist and the context pack exact-file list.
- The phase report maps every original instruction to P1 or P2 evidence.

### Acceptance criteria

- All implementation instructions are covered; final acceptance is deferred to the validation phase.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-130-VAL - Configure Android development export â bounded validation

- Plane work item ID: `481d8bde-03b8-4028-b49a-9cd1828ea14c`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:nicolas`
- Type: `type:test`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 191

### Objective

Validate ART-TASK-130 without implementing new functionality.

### Executor

agent:nicolas

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-130.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-130-P2

### SPEC references

- ART-SPEC-PLAT-001

### Architecture references

- ART-ARCH-TEST-005

### Allowed files

- export_presets.cfg
- android/**
- docs/ANDROID_BUILD.md

### Exact instructions

1. Run only the original validation commands with concise output.

2. Record exit codes and the smallest relevant failure output.

3. Check every original acceptance criterion against observable evidence.

4. Do not repair failures; return BLOCKED with the exact failing phase.

### Commands

- & 'C:\Users\eorod\Desktop\Godot_v4.7.1-stable_mono_win64\Godot_v4.7.1-stable_mono_win64_console.exe' --headless --path 'C:\Users\eorod\Desktop\Proyectos\juegos\AstroRebelsSpaceTraffic' --export-debug 'Android' build\android\AstroRebelsTraffic-debug.apk

### Validation

- Headless export exits 0.
- APK installs and launches on selected device.
- No secret is tracked.

### Acceptance criteria

- Android is first device-test platform.
- Safe areas and touch input work.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-131 - Configure iOS export and signing checklist

- Plane work item ID: `e7574aba-797a-4506-87d7-7685bb322f75`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:pedro`
- Type: `type:release`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 76

### Objective

Prepare iOS export settings and an explicit macOS/Xcode signing verification checklist.

### Executor

agent:pedro

### 32K context contract

- Risk class: context-required
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-131.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-070
- ART-TASK-005
- ART-TASK-131-CTX

### SPEC references

- ART-SPEC-PLAT-001

### Architecture references

- ART-ARCH-TEST-005

### Allowed files

- export_presets.cfg
- ios/**
- docs/IOS_BUILD.md

### Exact instructions

1. Define bundle identifier and portrait orientation.

2. Document required macOS, Xcode and signing assets.

3. Keep certificates/profiles outside repository.

4. Export and build on approved Mac.

5. Test safe areas, suspend/resume and audio settings.

### Commands

None.

### Validation

- Godot iOS export succeeds on Mac.
- Xcode build installs on named device.
- No signing secret is tracked.

### Acceptance criteria

- Unverified Windows-only claims are forbidden.
- Remaining Mac requirement is clearly reported.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-131-CTX - Build bounded context pack for ART-TASK-131

- Plane work item ID: `8643016f-34c1-4faf-996a-d5ce0f2ce1db`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:pedro`
- Type: `type:tooling`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 113

### Objective

Create the only normative and repository context that ART-TASK-131 may consume.

### Executor

agent:pedro

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-070
- ART-TASK-005
- ART-TASK-000

### SPEC references

- ART-SPEC-PLAT-001

### Architecture references

- ART-ARCH-TEST-005

### Allowed files

- docs/task-context/ART-TASK-131.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-PLAT-001] and ARCH IDs [ART-ARCH-TEST-005].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-131' -SpecIds 'ART-SPEC-PLAT-001' -ArchIds 'ART-ARCH-TEST-005' -OutputPath 'docs/task-context/ART-TASK-131.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-131.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-131 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-132 - Verify current store privacy, consent and tracking requirements

- Plane work item ID: `e3d8ebca-5849-48de-ab85-954705ca8ead`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:paula`
- Type: `type:decision`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 77

### Objective

Record current Android/iOS regional consent and tracking decisions before selecting production SDKs.

### Executor

agent:paula

### 32K context contract

- Risk class: context-required
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-132.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-100
- ART-TASK-130
- ART-TASK-131
- ART-TASK-132-CTX

### SPEC references

- ART-SPEC-ADS-005

### Architecture references

- ART-ARCH-ADS-001

### Allowed files

- docs/PRIVACY_AND_CONSENT_DECISION.md

### Exact instructions

1. Review current Google Play and Apple policies at execution time.

2. Select consent provider or document no-provider path.

3. Define data inventory and disclosures.

4. Define ATT behavior if applicable.

5. Approve ad/analytics SDKs separately.

### Commands

None.

### Validation

- Policy sources and review date are recorded.
- Every collected field has purpose, consent and retention decision.

### Acceptance criteria

- No SDK is integrated before approval.
- Gameplay works when consent is denied.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-132-CTX - Build bounded context pack for ART-TASK-132

- Plane work item ID: `15742403-ec2c-4e57-831d-c072f3b8b844`
- State: **Backlog**
- Priority: **medium**
- Executor: `agent:paula`
- Type: `type:tooling`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 114

### Objective

Create the only normative and repository context that ART-TASK-132 may consume.

### Executor

agent:paula

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-100
- ART-TASK-130
- ART-TASK-131
- ART-TASK-000

### SPEC references

- ART-SPEC-ADS-005

### Architecture references

- ART-ARCH-ADS-001

### Allowed files

- docs/task-context/ART-TASK-132.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-ADS-005] and ARCH IDs [ART-ARCH-ADS-001].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-132' -SpecIds 'ART-SPEC-ADS-005' -ArchIds 'ART-ARCH-ADS-001' -OutputPath 'docs/task-context/ART-TASK-132.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-132.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-132 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-140 - Create reference-device and profiler baseline

- Plane work item ID: `37f634ff-712d-4b87-8ce1-1c7ad649275b`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:sofia`
- Type: `type:decision`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 78

### Objective

Name representative mid-range Android/iOS devices and record empty/core-scene frame, memory and load baselines.

### Executor

agent:sofia

### 32K context contract

- Risk class: context-required
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-140.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-070
- ART-TASK-130
- ART-TASK-140-CTX

### SPEC references

- ART-SPEC-PERF-001
- ART-SPEC-PERF-003

### Architecture references

- ART-ARCH-PERF-002

### Allowed files

- docs/PERFORMANCE_BASELINE.md
- performance/reports/**

### Exact instructions

1. Select exact device models/OS versions.

2. Define measurement procedure and build type.

3. Record baseline 60 FPS frame timing, memory and load time.

4. Store profiler screenshots/data by dated report.

5. Do not claim iOS evidence without device run.

### Commands

None.

### Validation

- Reference devices are named.
- Baseline evidence is reproducible.
- Targets and measurement tolerances are recorded.

### Acceptance criteria

- Performance sign-off has objective devices.
- No unsupported claim is made.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-140-CTX - Build bounded context pack for ART-TASK-140

- Plane work item ID: `452acf25-cb90-4db0-93b6-ae033c41ccc7`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:sofia`
- Type: `type:tooling`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 115

### Objective

Create the only normative and repository context that ART-TASK-140 may consume.

### Executor

agent:sofia

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-070
- ART-TASK-130
- ART-TASK-000

### SPEC references

- ART-SPEC-PERF-001
- ART-SPEC-PERF-003

### Architecture references

- ART-ARCH-PERF-002

### Allowed files

- docs/task-context/ART-TASK-140.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-PERF-001,ART-SPEC-PERF-003] and ARCH IDs [ART-ARCH-PERF-002].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-140' -SpecIds 'ART-SPEC-PERF-001,ART-SPEC-PERF-003' -ArchIds 'ART-ARCH-PERF-002' -OutputPath 'docs/task-context/ART-TASK-140.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-140.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-140 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-141 - Optimize 100-passenger and 60-ship stress fixture â integration gate

- Plane work item ID: `e878eea7-a642-4b3b-a59f-0abb46c15051`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:nicolas`
- Type: `type:code`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 79

### Objective

Close ART-TASK-141 only after its context, implementation and validation subtasks are Done. This gate performs no implementation.

### Executor

agent:nicolas

### 32K context contract

- Risk class: gate
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-141.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-141-VAL

### SPEC references

- ART-SPEC-PERF-002
- ART-SPEC-PERF-004

### Architecture references

- ART-ARCH-PERF-003

### Allowed files

- docs/task-context/ART-TASK-141.md

### Exact instructions

1. Confirm ART-TASK-141-CTX, ART-TASK-141-P1, ART-TASK-141-P2 and ART-TASK-141-VAL are Done in Plane.

2. Confirm validation evidence addresses every original acceptance criterion.

3. Record the four subtask IDs and evidence links in the completion comment.

4. Do not read source files or rerun broad commands in this gate.

### Commands

None.

### Validation

- All four required subtasks are Done and none reports an unresolved blocker.

### Acceptance criteria

- The original task closes as a traceability gate without consuming implementation context.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-141-CTX - Build bounded context pack for ART-TASK-141

- Plane work item ID: `f85aa3cb-0248-4623-bb08-1f5df93c4c24`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:nicolas`
- Type: `type:tooling`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 192

### Objective

Create the only normative and repository context that ART-TASK-141 may consume.

### Executor

agent:nicolas

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-072
- ART-TASK-123
- ART-TASK-140
- ART-TASK-000

### SPEC references

- ART-SPEC-PERF-002
- ART-SPEC-PERF-004

### Architecture references

- ART-ARCH-PERF-003

### Allowed files

- docs/task-context/ART-TASK-141.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-PERF-002,ART-SPEC-PERF-004] and ARCH IDs [ART-ARCH-PERF-003].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-141' -SpecIds 'ART-SPEC-PERF-002,ART-SPEC-PERF-004' -ArchIds 'ART-ARCH-PERF-003' -OutputPath 'docs/task-context/ART-TASK-141.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-141.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-141 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-141-P1 - Optimize 100-passenger and 60-ship stress fixture â atomic implementation phase 1

- Plane work item ID: `ab0a9734-a3d0-4b53-a341-0e20d97d3e19`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:nicolas`
- Type: `type:code`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 193

### Objective

Perform only the first bounded half of ART-TASK-141; do not execute final validation or the remaining steps.

### Executor

agent:nicolas

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-141.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-141-CTX

### SPEC references

- ART-SPEC-PERF-002
- ART-SPEC-PERF-004

### Architecture references

- ART-ARCH-PERF-003

### Allowed files

- tests/fixtures/levels/stress/**
- presentation/Pooling/**
- performance/reports/**

### Exact instructions

1. Create deterministic stress fixture with at least 100 passengers and 60 ships.

2. Profile before changes.

3. Pool passenger/VFX Nodes.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug

### Validation

- Changed files are within the task allowlist and the context pack exact-file list.
- No tool result exceeds 4,000 characters; verbose output is redirected to a file and summarized.
- The phase report lists unfinished original steps explicitly.

### Acceptance criteria

- Phase-one steps are implemented without claiming the original task complete.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-141-P2 - Optimize 100-passenger and 60-ship stress fixture â atomic implementation phase 2

- Plane work item ID: `9b75508d-daad-4751-aa3d-74c412700763`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:nicolas`
- Type: `type:code`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 194

### Objective

Perform only the remaining bounded half of ART-TASK-141 using phase-one artifacts.

### Executor

agent:nicolas

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-141.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-141-P1

### SPEC references

- ART-SPEC-PERF-002
- ART-SPEC-PERF-004

### Architecture references

- ART-ARCH-PERF-003

### Allowed files

- tests/fixtures/levels/stress/**
- presentation/Pooling/**
- performance/reports/**

### Exact instructions

1. Share materials and remove hot scene-tree queries.

2. Reprofile on reference Android.

3. Record before/after evidence.

### Commands

- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Phase-one artifacts are present and unchanged except for required integration edits.
- Changed files are within the task allowlist and the context pack exact-file list.
- The phase report maps every original instruction to P1 or P2 evidence.

### Acceptance criteria

- All implementation instructions are covered; final acceptance is deferred to the validation phase.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-141-VAL - Optimize 100-passenger and 60-ship stress fixture â bounded validation

- Plane work item ID: `a8cd3e91-fa00-4d46-adc3-deaa11edc496`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:nicolas`
- Type: `type:test`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 195

### Objective

Validate ART-TASK-141 without implementing new functionality.

### Executor

agent:nicolas

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-141.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-141-P2

### SPEC references

- ART-SPEC-PERF-002
- ART-SPEC-PERF-004

### Architecture references

- ART-ARCH-PERF-003

### Allowed files

- tests/fixtures/levels/stress/**
- presentation/Pooling/**
- performance/reports/**

### Exact instructions

1. Run only the original validation commands with concise output.

2. Record exit codes and the smallest relevant failure output.

3. Check every original acceptance criterion against observable evidence.

4. Do not repair failures; return BLOCKED with the exact failing phase.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Stress fixture preserves 60 FPS target on reference Android or limitation is reported.
- No rule/parity test changes.
- Transient allocations are bounded.

### Acceptance criteria

- Optimization is evidence-driven.
- Canonical event/state order remains identical.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-142 - Move solver and generation off gameplay main thread â integration gate

- Plane work item ID: `ff762fab-e0fc-4065-a0cb-8d892ab0ca0e`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 80

### Objective

Close ART-TASK-142 only after its context, implementation and validation subtasks are Done. This gate performs no implementation.

### Executor

agent:alfredo

### 32K context contract

- Risk class: gate
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-142.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-142-VAL

### SPEC references

- ART-SPEC-PERF-005

### Architecture references

- ART-ARCH-PERF-001
- ART-ARCH-PERF-005

### Allowed files

- docs/task-context/ART-TASK-142.md

### Exact instructions

1. Confirm ART-TASK-142-CTX, ART-TASK-142-P1, ART-TASK-142-P2 and ART-TASK-142-VAL are Done in Plane.

2. Confirm validation evidence addresses every original acceptance criterion.

3. Record the four subtask IDs and evidence links in the completion comment.

4. Do not read source files or rerun broad commands in this gate.

### Commands

None.

### Validation

- All four required subtasks are Done and none reports an unresolved blocker.

### Acceptance criteria

- The original task closes as a traceability gate without consuming implementation context.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-142-CTX - Build bounded context pack for ART-TASK-142

- Plane work item ID: `95dfae74-9718-46c9-8bd7-c3dff3aac1aa`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:alfredo`
- Type: `type:tooling`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 196

### Objective

Create the only normative and repository context that ART-TASK-142 may consume.

### Executor

agent:alfredo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-062
- ART-TASK-064
- ART-TASK-140
- ART-TASK-000

### SPEC references

- ART-SPEC-PERF-005

### Architecture references

- ART-ARCH-PERF-001
- ART-ARCH-PERF-005

### Allowed files

- docs/task-context/ART-TASK-142.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-PERF-005] and ARCH IDs [ART-ARCH-PERF-001,ART-ARCH-PERF-005].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-142' -SpecIds 'ART-SPEC-PERF-005' -ArchIds 'ART-ARCH-PERF-001,ART-ARCH-PERF-005' -OutputPath 'docs/task-context/ART-TASK-142.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-142.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-142 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-142-P1 - Move solver and generation off gameplay main thread â atomic implementation phase 1

- Plane work item ID: `2eb195eb-17ee-4126-8048-c54444166233`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 197

### Objective

Perform only the first bounded half of ART-TASK-142; do not execute final validation or the remaining steps.

### Executor

agent:alfredo

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-142.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-142-CTX

### SPEC references

- ART-SPEC-PERF-005

### Architecture references

- ART-ARCH-PERF-001
- ART-ARCH-PERF-005

### Allowed files

- application/BackgroundWork/**
- solver/**
- generator/**
- tests/AstroRebelsTraffic.Tests/Performance/CancellationTests.cs

### Exact instructions

1. Accept deep-copied/immutable state.

2. Add cancellation token and explicit budget.

3. Marshal results without touching Nodes.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug

### Validation

- Changed files are within the task allowlist and the context pack exact-file list.
- No tool result exceeds 4,000 characters; verbose output is redirected to a file and summarized.
- The phase report lists unfinished original steps explicitly.

### Acceptance criteria

- Phase-one steps are implemented without claiming the original task complete.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-142-P2 - Move solver and generation off gameplay main thread â atomic implementation phase 2

- Plane work item ID: `56ff207a-f7a5-4954-939b-fa080c8b0d02`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:alfredo`
- Type: `type:code`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 198

### Objective

Perform only the remaining bounded half of ART-TASK-142 using phase-one artifacts.

### Executor

agent:alfredo

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-142.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-142-P1

### SPEC references

- ART-SPEC-PERF-005

### Architecture references

- ART-ARCH-PERF-001
- ART-ARCH-PERF-005

### Allowed files

- application/BackgroundWork/**
- solver/**
- generator/**
- tests/AstroRebelsTraffic.Tests/Performance/CancellationTests.cs

### Exact instructions

1. Cancel on session/screen close.

2. Prove gameplay command latency is unaffected.

### Commands

- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Phase-one artifacts are present and unchanged except for required integration edits.
- Changed files are within the task allowlist and the context pack exact-file list.
- The phase report maps every original instruction to P1 or P2 evidence.

### Acceptance criteria

- All implementation instructions are covered; final acceptance is deferred to the validation phase.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-142-VAL - Move solver and generation off gameplay main thread â bounded validation

- Plane work item ID: `21be0eb8-0a44-449c-8760-a03e72f76b8c`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:alfredo`
- Type: `type:test`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 199

### Objective

Validate ART-TASK-142 without implementing new functionality.

### Executor

agent:alfredo

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-142.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-142-P2

### SPEC references

- ART-SPEC-PERF-005

### Architecture references

- ART-ARCH-PERF-001
- ART-ARCH-PERF-005

### Allowed files

- application/BackgroundWork/**
- solver/**
- generator/**
- tests/AstroRebelsTraffic.Tests/Performance/CancellationTests.cs

### Exact instructions

1. Run only the original validation commands with concise output.

2. Record exit codes and the smallest relevant failure output.

3. Check every original acceptance criterion against observable evidence.

4. Do not repair failures; return BLOCKED with the exact failing phase.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Cancellation completes without leaked worker.
- Gameplay loop never waits for solver.
- Parity remains green.

### Acceptance criteria

- Production puzzle does not require online/background solver.
- Scene mutations stay on main thread.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-150 - Create full regression and property-test suite â integration gate

- Plane work item ID: `435372ec-a9d6-4e74-8e31-58f88f04a1e7`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:sofia`
- Type: `type:test`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 81

### Objective

Close ART-TASK-150 only after its context, implementation and validation subtasks are Done. This gate performs no implementation.

### Executor

agent:sofia

### 32K context contract

- Risk class: gate
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-150.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-150-VAL

### SPEC references

- ART-SPEC-QA-003

### Architecture references

- ART-ARCH-TEST-001
- ART-ARCH-TEST-002
- ART-ARCH-TEST-004

### Allowed files

- docs/task-context/ART-TASK-150.md

### Exact instructions

1. Confirm ART-TASK-150-CTX, ART-TASK-150-P1, ART-TASK-150-P2 and ART-TASK-150-VAL are Done in Plane.

2. Confirm validation evidence addresses every original acceptance criterion.

3. Record the four subtask IDs and evidence links in the completion comment.

4. Do not read source files or rerun broad commands in this gate.

### Commands

None.

### Validation

- All four required subtasks are Done and none reports an unresolved blocker.

### Acceptance criteria

- The original task closes as a traceability gate without consuming implementation context.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-150-CTX - Build bounded context pack for ART-TASK-150

- Plane work item ID: `5d47c5f4-c1d7-488d-ab3d-41dbbe00254b`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:sofia`
- Type: `type:tooling`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 200

### Objective

Create the only normative and repository context that ART-TASK-150 may consume.

### Executor

agent:sofia

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-063
- ART-TASK-073
- ART-TASK-000

### SPEC references

- ART-SPEC-QA-003

### Architecture references

- ART-ARCH-TEST-001
- ART-ARCH-TEST-002
- ART-ARCH-TEST-004

### Allowed files

- docs/task-context/ART-TASK-150.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-QA-003] and ARCH IDs [ART-ARCH-TEST-001,ART-ARCH-TEST-002,ART-ARCH-TEST-004].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-150' -SpecIds 'ART-SPEC-QA-003' -ArchIds 'ART-ARCH-TEST-001,ART-ARCH-TEST-002,ART-ARCH-TEST-004' -OutputPath 'docs/task-context/ART-TASK-150.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-150.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-150 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-150-P1 - Create full regression and property-test suite â atomic implementation phase 1

- Plane work item ID: `ef7e962d-1147-4366-82b2-924a9df4cb7a`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:sofia`
- Type: `type:test`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 201

### Objective

Perform only the first bounded half of ART-TASK-150; do not execute final validation or the remaining steps.

### Executor

agent:sofia

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-150.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-150-CTX

### SPEC references

- ART-SPEC-QA-003

### Architecture references

- ART-ARCH-TEST-001
- ART-ARCH-TEST-002
- ART-ARCH-TEST-004

### Allowed files

- tests/AstroRebelsTraffic.Tests/**
- tests/fixtures/**

### Exact instructions

1. Implement all ART-ARCH-TEST-002 fixtures.

2. Add randomized valid-state generators.

3. Print seed and minimized fixture on failure.

### Commands

- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Changed files are within the task allowlist and the context pack exact-file list.
- No tool result exceeds 4,000 characters; verbose output is redirected to a file and summarized.
- The phase report lists unfinished original steps explicitly.

### Acceptance criteria

- Phase-one steps are implemented without claiming the original task complete.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-150-P2 - Create full regression and property-test suite â atomic implementation phase 2

- Plane work item ID: `4b27ba20-b49d-448a-931d-f0a0aeadee0d`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:sofia`
- Type: `type:test`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 202

### Objective

Perform only the remaining bounded half of ART-TASK-150 using phase-one artifacts.

### Executor

agent:sofia

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-150.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-150-P1

### SPEC references

- ART-SPEC-QA-003

### Architecture references

- ART-ARCH-TEST-001
- ART-ARCH-TEST-002
- ART-ARCH-TEST-004

### Allowed files

- tests/AstroRebelsTraffic.Tests/**
- tests/fixtures/**

### Exact instructions

1. Add no-passenger-loss conservation properties.

2. Run headless scene smoke tests separately.

### Commands

None.

### Validation

- Phase-one artifacts are present and unchanged except for required integration edits.
- Changed files are within the task allowlist and the context pack exact-file list.
- The phase report maps every original instruction to P1 or P2 evidence.

### Acceptance criteria

- All implementation instructions are covered; final acceptance is deferred to the validation phase.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-150-VAL - Create full regression and property-test suite â bounded validation

- Plane work item ID: `4096670d-389c-4b72-8d50-4e55ef1cd2e8`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:sofia`
- Type: `type:test`
- Scope: `scope:core`
- Module: Unassigned
- Plane sequence: 203

### Objective

Validate ART-TASK-150 without implementing new functionality.

### Executor

agent:sofia

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-150.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-150-P2

### SPEC references

- ART-SPEC-QA-003

### Architecture references

- ART-ARCH-TEST-001
- ART-ARCH-TEST-002
- ART-ARCH-TEST-004

### Allowed files

- tests/AstroRebelsTraffic.Tests/**
- tests/fixtures/**

### Exact instructions

1. Run only the original validation commands with concise output.

2. Record exit codes and the smallest relevant failure output.

3. Check every original acceptance criterion against observable evidence.

4. Do not repair failures; return BLOCKED with the exact failing phase.

### Commands

- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- All required scenarios are present and pass.
- Random failures are reproducible by seed.
- Coverage gaps map to explicit SPEC IDs.

### Acceptance criteria

- Tests cite governing SPEC/ARCH IDs.
- No test fake duplicates gameplay logic.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-151 - Create production content validation report â integration gate

- Plane work item ID: `670aea95-ec6c-407f-8ec5-5dd8cd914cb7`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:sofia`
- Type: `type:test`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 82

### Objective

Close ART-TASK-151 only after its context, implementation and validation subtasks are Done. This gate performs no implementation.

### Executor

agent:sofia

### 32K context contract

- Risk class: gate
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-151.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-151-VAL

### SPEC references

- ART-SPEC-LEVEL-002
- ART-SPEC-QA-004

### Architecture references

- ART-ARCH-LEVEL-005

### Allowed files

- docs/task-context/ART-TASK-151.md

### Exact instructions

1. Confirm ART-TASK-151-CTX, ART-TASK-151-P1, ART-TASK-151-P2 and ART-TASK-151-VAL are Done in Plane.

2. Confirm validation evidence addresses every original acceptance criterion.

3. Record the four subtask IDs and evidence links in the completion comment.

4. Do not read source files or rerun broad commands in this gate.

### Commands

None.

### Validation

- All four required subtasks are Done and none reports an unresolved blocker.

### Acceptance criteria

- The original task closes as a traceability gate without consuming implementation context.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-151-CTX - Build bounded context pack for ART-TASK-151

- Plane work item ID: `0459af9f-e6e7-4787-8640-57018cef5905`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:sofia`
- Type: `type:tooling`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 204

### Objective

Create the only normative and repository context that ART-TASK-151 may consume.

### Executor

agent:sofia

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-054
- ART-TASK-065
- ART-TASK-081
- ART-TASK-000

### SPEC references

- ART-SPEC-LEVEL-002
- ART-SPEC-QA-004

### Architecture references

- ART-ARCH-LEVEL-005

### Allowed files

- docs/task-context/ART-TASK-151.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-LEVEL-002,ART-SPEC-QA-004] and ARCH IDs [ART-ARCH-LEVEL-005].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-151' -SpecIds 'ART-SPEC-LEVEL-002,ART-SPEC-QA-004' -ArchIds 'ART-ARCH-LEVEL-005' -OutputPath 'docs/task-context/ART-TASK-151.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-151.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-151 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-151-P1 - Create production content validation report â atomic implementation phase 1

- Plane work item ID: `077cfa72-020c-4536-90d2-e5b5980aec6b`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:sofia`
- Type: `type:test`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 205

### Objective

Perform only the first bounded half of ART-TASK-151; do not execute final validation or the remaining steps.

### Executor

agent:sofia

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-151.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-151-CTX

### SPEC references

- ART-SPEC-LEVEL-002
- ART-SPEC-QA-004

### Architecture references

- ART-ARCH-LEVEL-005

### Allowed files

- tools/Validation/**
- build/reports/level-validation.json

### Exact instructions

1. Load manifest.

2. Validate each definition.

3. Run baseline solver with approved budget.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug

### Validation

- Changed files are within the task allowlist and the context pack exact-file list.
- No tool result exceeds 4,000 characters; verbose output is redirected to a file and summarized.
- The phase report lists unfinished original steps explicitly.

### Acceptance criteria

- Phase-one steps are implemented without claiming the original task complete.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-151-P2 - Create production content validation report â atomic implementation phase 2

- Plane work item ID: `a9b8779d-1c46-4d36-818a-bea98039ded8`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:sofia`
- Type: `type:test`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 206

### Objective

Perform only the remaining bounded half of ART-TASK-151 using phase-one artifacts.

### Executor

agent:sofia

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-151.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-151-P1

### SPEC references

- ART-SPEC-LEVEL-002
- ART-SPEC-QA-004

### Architecture references

- ART-ARCH-LEVEL-005

### Allowed files

- tools/Validation/**
- build/reports/level-validation.json

### Exact instructions

1. Replay returned solution to exact win.

2. Record metrics and human review state.

3. Fail nonzero on any invalid/unknown/unsolved entry.

### Commands

- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Phase-one artifacts are present and unchanged except for required integration edits.
- Changed files are within the task allowlist and the context pack exact-file list.
- The phase report maps every original instruction to P1 or P2 evidence.

### Acceptance criteria

- All implementation instructions are covered; final acceptance is deferred to the validation phase.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-151-VAL - Create production content validation report â bounded validation

- Plane work item ID: `e6770e04-eeeb-4640-8f2c-9e21c72ed4e9`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:sofia`
- Type: `type:test`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 207

### Objective

Validate ART-TASK-151 without implementing new functionality.

### Executor

agent:sofia

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-151.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-151-P2

### SPEC references

- ART-SPEC-LEVEL-002
- ART-SPEC-QA-004

### Architecture references

- ART-ARCH-LEVEL-005

### Allowed files

- tools/Validation/**
- build/reports/level-validation.json

### Exact instructions

1. Run only the original validation commands with concise output.

2. Record exit codes and the smallest relevant failure output.

3. Check every original acceptance criterion against observable evidence.

4. Do not repair failures; return BLOCKED with the exact failing phase.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Report accounts for every production level.
- No assistance action appears in solutions.
- Failure returns nonzero and exact level/reason.

### Acceptance criteria

- Production content cannot bypass solver.
- Report is reproducible.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-152 - Run Android/iOS release-candidate verification â integration gate

- Plane work item ID: `b6086d46-2d8f-4e5b-82ff-c82c81a80f13`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:sofia`
- Type: `type:release`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 83

### Objective

Close ART-TASK-152 only after its context, implementation and validation subtasks are Done. This gate performs no implementation.

### Executor

agent:sofia

### 32K context contract

- Risk class: gate
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-152.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-152-VAL

### SPEC references

- ART-SPEC-QA-004

### Architecture references

- ART-ARCH-TEST-005

### Allowed files

- docs/task-context/ART-TASK-152.md

### Exact instructions

1. Confirm ART-TASK-152-CTX, ART-TASK-152-P1, ART-TASK-152-P2 and ART-TASK-152-VAL are Done in Plane.

2. Confirm validation evidence addresses every original acceptance criterion.

3. Record the four subtask IDs and evidence links in the completion comment.

4. Do not read source files or rerun broad commands in this gate.

### Commands

None.

### Validation

- All four required subtasks are Done and none reports an unresolved blocker.

### Acceptance criteria

- The original task closes as a traceability gate without consuming implementation context.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-152-CTX - Build bounded context pack for ART-TASK-152

- Plane work item ID: `5c7f00d0-a9fb-41ff-a7c1-931fe9850acc`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:sofia`
- Type: `type:tooling`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 208

### Objective

Create the only normative and repository context that ART-TASK-152 may consume.

### Executor

agent:sofia

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-124
- ART-TASK-130
- ART-TASK-131
- ART-TASK-141
- ART-TASK-151
- ART-TASK-000

### SPEC references

- ART-SPEC-QA-004

### Architecture references

- ART-ARCH-TEST-005

### Allowed files

- docs/task-context/ART-TASK-152.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-QA-004] and ARCH IDs [ART-ARCH-TEST-005].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-152' -SpecIds 'ART-SPEC-QA-004' -ArchIds 'ART-ARCH-TEST-005' -OutputPath 'docs/task-context/ART-TASK-152.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-152.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-152 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-152-P1 - Run Android/iOS release-candidate verification â atomic implementation phase 1

- Plane work item ID: `3bfd5287-d693-423d-8736-bdd863a674a7`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:sofia`
- Type: `type:release`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 209

### Objective

Perform only the first bounded half of ART-TASK-152; do not execute final validation or the remaining steps.

### Executor

agent:sofia

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-152.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-152-CTX

### SPEC references

- ART-SPEC-QA-004

### Architecture references

- ART-ARCH-TEST-005

### Allowed files

- docs/RELEASE_CHECKLIST.md
- performance/reports/release/**

### Exact instructions

1. Build signed candidates through approved secure process.

2. Run representative levels and stress fixture.

3. Test background/resume, safe areas, audio settings and corrupted save recovery.

### Commands

None.

### Validation

- Changed files are within the task allowlist and the context pack exact-file list.
- No tool result exceeds 4,000 characters; verbose output is redirected to a file and summarized.
- The phase report lists unfinished original steps explicitly.

### Acceptance criteria

- Phase-one steps are implemented without claiming the original task complete.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-152-P2 - Run Android/iOS release-candidate verification â atomic implementation phase 2

- Plane work item ID: `e499446a-bf06-4487-9263-ebd91a6828f5`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:sofia`
- Type: `type:release`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 210

### Objective

Perform only the remaining bounded half of ART-TASK-152 using phase-one artifacts.

### Executor

agent:sofia

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-152.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-152-P1

### SPEC references

- ART-SPEC-QA-004

### Architecture references

- ART-ARCH-TEST-005

### Allowed files

- docs/RELEASE_CHECKLIST.md
- performance/reports/release/**

### Exact instructions

1. Test every fake/staging ad outcome.

2. Record device, build hash and evidence.

3. Report every unverified item as not passed.

### Commands

None.

### Validation

- Phase-one artifacts are present and unchanged except for required integration edits.
- Changed files are within the task allowlist and the context pack exact-file list.
- The phase report maps every original instruction to P1 or P2 evidence.

### Acceptance criteria

- All implementation instructions are covered; final acceptance is deferred to the validation phase.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-152-VAL - Run Android/iOS release-candidate verification â bounded validation

- Plane work item ID: `d254ecee-5ea8-4727-b849-1efd814a1ca6`
- State: **Backlog**
- Priority: **high**
- Executor: `agent:sofia`
- Type: `type:test`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 211

### Objective

Validate ART-TASK-152 without implementing new functionality.

### Executor

agent:sofia

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-152.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-152-P2

### SPEC references

- ART-SPEC-QA-004

### Architecture references

- ART-ARCH-TEST-005

### Allowed files

- docs/RELEASE_CHECKLIST.md
- performance/reports/release/**

### Exact instructions

1. Run only the original validation commands with concise output.

2. Record exit codes and the smallest relevant failure output.

3. Check every original acceptance criterion against observable evidence.

4. Do not repair failures; return BLOCKED with the exact failing phase.

### Commands

None.

### Validation

- Android and iOS results are separately recorded.
- No unresolved P0/P1 defect remains.
- Performance and load targets have evidence.

### Acceptance criteria

- No simulated success is reported.
- Checklist links exact build artifacts/hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-153 - Final traceability and source-of-truth audit â integration gate

- Plane work item ID: `bd0a169f-1af2-4651-b9af-9c43c73aa161`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:ricardo`
- Type: `type:test`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 84

### Objective

Close ART-TASK-153 only after its context, implementation and validation subtasks are Done. This gate performs no implementation.

### Executor

agent:ricardo

### 32K context contract

- Risk class: gate
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-153.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-153-VAL

### SPEC references

- ART-SPEC-GOV-002
- ART-SPEC-QA-004

### Architecture references

- ART-ARCH-TRACE-001
- ART-ARCH-ACCEPT-001

### Allowed files

- docs/task-context/ART-TASK-153.md

### Exact instructions

1. Confirm ART-TASK-153-CTX, ART-TASK-153-P1, ART-TASK-153-P2 and ART-TASK-153-VAL are Done in Plane.

2. Confirm validation evidence addresses every original acceptance criterion.

3. Record the four subtask IDs and evidence links in the completion comment.

4. Do not read source files or rerun broad commands in this gate.

### Commands

None.

### Validation

- All four required subtasks are Done and none reports an unresolved blocker.

### Acceptance criteria

- The original task closes as a traceability gate without consuming implementation context.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-153-CTX - Build bounded context pack for ART-TASK-153

- Plane work item ID: `e9082ca2-93f0-4139-aa3b-72f57120cf75`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:ricardo`
- Type: `type:tooling`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 212

### Objective

Create the only normative and repository context that ART-TASK-153 may consume.

### Executor

agent:ricardo

### 32K context contract

- Risk class: safe
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: None required.
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-150
- ART-TASK-151
- ART-TASK-152
- ART-TASK-000

### SPEC references

- ART-SPEC-GOV-002
- ART-SPEC-QA-004

### Architecture references

- ART-ARCH-TRACE-001
- ART-ARCH-ACCEPT-001

### Allowed files

- docs/task-context/ART-TASK-153.md

### Exact instructions

1. Run the context extractor for SPEC IDs [ART-SPEC-GOV-002,ART-SPEC-QA-004] and ARCH IDs [ART-ARCH-TRACE-001,ART-ARCH-ACCEPT-001].

2. List at most six exact existing input files. Wildcards and directory-wide reads are forbidden.

3. Include file hashes and short symbol/heading locations, not complete file contents.

4. Stop if the pack exceeds 24,000 characters or any referenced ID is unresolved.

### Commands

- powershell -NoProfile -ExecutionPolicy Bypass -File tools\Context\Build-TaskContext.ps1 -TaskId 'ART-TASK-153' -SpecIds 'ART-SPEC-GOV-002,ART-SPEC-QA-004' -ArchIds 'ART-ARCH-TRACE-001,ART-ARCH-ACCEPT-001' -OutputPath 'docs/task-context/ART-TASK-153.md' -MaxChars 24000

### Validation

- Test-Path 'docs/task-context/ART-TASK-153.md' returns True.
- The reported character count is at most 24,000.
- Every requested requirement ID occurs exactly once in the pack.
- The pack contains no wildcard paths and names at most six readable implementation files.

### Acceptance criteria

- The executor of ART-TASK-153 can work without reading either full source-of-truth document.
- The context pack is deterministic for unchanged source hashes.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-153-P1 - Final traceability and source-of-truth audit â atomic implementation phase 1

- Plane work item ID: `63ad4e33-6adf-4709-adee-6ccd7a53dc64`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:ricardo`
- Type: `type:test`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 213

### Objective

Perform only the first bounded half of ART-TASK-153; do not execute final validation or the remaining steps.

### Executor

agent:ricardo

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-153.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-153-CTX

### SPEC references

- ART-SPEC-GOV-002
- ART-SPEC-QA-004

### Architecture references

- ART-ARCH-TRACE-001
- ART-ARCH-ACCEPT-001

### Allowed files

- docs/TRACEABILITY.md
- build/reports/traceability.json

### Exact instructions

1. Enumerate all implemented ART-SPEC IDs.

2. Map to ART-ARCH IDs, Plane task IDs, files and tests.

3. List planned/TBD systems and confirm disabled state.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug

### Validation

- Changed files are within the task allowlist and the context pack exact-file list.
- No tool result exceeds 4,000 characters; verbose output is redirected to a file and summarized.
- The phase report lists unfinished original steps explicitly.

### Acceptance criteria

- Phase-one steps are implemented without claiming the original task complete.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-153-P2 - Final traceability and source-of-truth audit â atomic implementation phase 2

- Plane work item ID: `696841eb-43fd-4083-823e-dc22125110ad`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:ricardo`
- Type: `type:test`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 214

### Objective

Perform only the remaining bounded half of ART-TASK-153 using phase-one artifacts.

### Executor

agent:ricardo

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-153.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-153-P1

### SPEC references

- ART-SPEC-GOV-002
- ART-SPEC-QA-004

### Architecture references

- ART-ARCH-TRACE-001
- ART-ARCH-ACCEPT-001

### Allowed files

- docs/TRACEABILITY.md
- build/reports/traceability.json

### Exact instructions

1. Search for duplicate rule implementations in UI/solver.

2. Record build/test/device evidence.

3. Fail audit on missing mapping or unauthorized feature.

### Commands

- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Phase-one artifacts are present and unchanged except for required integration edits.
- Changed files are within the task allowlist and the context pack exact-file list.
- The phase report maps every original instruction to P1 or P2 evidence.

### Acceptance criteria

- All implementation instructions are covered; final acceptance is deferred to the validation phase.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

## ART-TASK-153-VAL - Final traceability and source-of-truth audit â bounded validation

- Plane work item ID: `06f138e6-55f9-497f-8456-d2bf2bf8ac1a`
- State: **Backlog**
- Priority: **urgent**
- Executor: `agent:ricardo`
- Type: `type:test`
- Scope: `scope:product`
- Module: Unassigned
- Plane sequence: 215

### Objective

Validate ART-TASK-153 without implementing new functionality.

### Executor

agent:ricardo

### 32K context contract

- Risk class: bounded
- Maximum prompt-side task material: 24000 characters.
- Maximum readable implementation files: 6 exact files.
- Maximum single tool result: 4000 characters.
- Required context pack: docs/task-context/ART-TASK-153.md
- Never read the complete MASTER_SPEC, ARCHITECTURE, backlog generator, repository tree, build log or test log. Use exact IDs, exact files, bounded ranges and concise summaries.
- Start in a fresh OpenClaw session dedicated to this task ID.

### Dependencies

- ART-TASK-153-P2

### SPEC references

- ART-SPEC-GOV-002
- ART-SPEC-QA-004

### Architecture references

- ART-ARCH-TRACE-001
- ART-ARCH-ACCEPT-001

### Allowed files

- docs/TRACEABILITY.md
- build/reports/traceability.json

### Exact instructions

1. Run only the original validation commands with concise output.

2. Record exit codes and the smallest relevant failure output.

3. Check every original acceptance criterion against observable evidence.

4. Do not repair failures; return BLOCKED with the exact failing phase.

### Commands

- dotnet build AstroRebelsTraffic.csproj --configuration Debug
- dotnet test tests\AstroRebelsTraffic.Tests\AstroRebelsTraffic.Tests.csproj --configuration Debug --no-restore

### Validation

- Every implemented requirement has complete mapping.
- All planned-disabled systems are demonstrably inactive.
- Build, tests, level gate and device evidence are linked.

### Acceptance criteria

- SPEC and architecture remain authoritative.
- Release cannot be declared complete with audit failures.

### If validation fails

1. Stop. Do not mark this item Done.

2. Record the exact failing command, exit code and smallest relevant output.

3. Revert only this task's incomplete change if safe; never reset unrelated work.

4. Move the item to Blocked and identify the unmet dependency or decision.

### Required completion report

- Files changed
- Commands executed
- Build/test/validation result
- Acceptance criteria evidence
- Remaining limitation, or âNoneâ

---

