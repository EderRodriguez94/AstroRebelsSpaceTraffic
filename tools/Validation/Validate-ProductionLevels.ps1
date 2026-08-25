[CmdletBinding()]
param(
    [string]$DefinitionsPath = "levels/Definitions/tutorial",
    [string]$ReportPath = "build/reports/level-validation.json"
)

$ErrorActionPreference = "Stop"
$files = @(Get-ChildItem -LiteralPath $DefinitionsPath -Filter "*.json" -File | Sort-Object Name)
$errors = [System.Collections.Generic.List[string]]::new()
$entries = [System.Collections.Generic.List[object]]::new()

foreach ($file in $files) {
    try { $level = Get-Content -LiteralPath $file.FullName -Raw | ConvertFrom-Json }
    catch { $errors.Add("$($file.Name):invalid_json"); continue }
    $required = @("schema_version", "level_id", "zones")
    foreach ($name in $required) {
        if ($null -eq $level.$name) { $errors.Add("$($file.Name):missing_$name") }
    }
    if ($level.schema_version -ne 1) { $errors.Add("$($file.Name):schema_version") }
    if ([string]::IsNullOrWhiteSpace([string]$level.level_id)) { $errors.Add("$($file.Name):level_id") }
    if (@($level.zones).Count -eq 0) { $errors.Add("$($file.Name):zones") }
    $entries.Add([ordered]@{ level_id = $level.level_id; path = $file.FullName; valid_shape = ($errors.Count -eq 0); solver = "pending" })
}

$report = [ordered]@{
    generated_at_utc = [DateTime]::UtcNow.ToString("o")
    source = (Resolve-Path $DefinitionsPath).Path
    entries = $entries
    entry_count = $entries.Count
    shape_valid = ($errors.Count -eq 0)
    solver_status = "pending"
    errors = @($errors | Sort-Object)
}
$parent = Split-Path -Parent $ReportPath
New-Item -ItemType Directory -Force -Path $parent | Out-Null
$report | ConvertTo-Json -Depth 8 | Set-Content -LiteralPath $ReportPath -Encoding utf8
if ($errors.Count -gt 0) { exit 1 }
