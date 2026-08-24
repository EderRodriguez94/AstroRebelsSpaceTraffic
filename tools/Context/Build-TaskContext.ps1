# Build-TaskContext.ps1 - bounded extraction of explicitly requested requirements.
[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)][ValidateNotNullOrEmpty()][string]$TaskId,
    [Parameter(Mandatory = $true)][AllowEmptyCollection()][string[]]$SpecIds,
    [Parameter(Mandatory = $true)][AllowEmptyCollection()][string[]]$ArchIds,
    [Parameter(Mandatory = $true)][string]$OutputPath,
    [Parameter(Mandatory = $true)][ValidateRange(1, 2147483647)][int]$MaxChars,
    [string[]]$ExactFileList = @()
)
$ErrorActionPreference = 'Stop'
function Assert-UniqueIds([string[]]$Ids, [string]$Kind) {
    $duplicates = @($Ids | Group-Object | Where-Object Count -gt 1 | Select-Object -ExpandProperty Name)
    if ($duplicates.Count -gt 0) { throw "Duplicate $Kind ID(s): $($duplicates -join ', ')" }
}
function Get-SourceFiles {
    if ($ExactFileList.Count -gt 0) {
        if (@($ExactFileList | Where-Object { $_ -match '[*?]' }).Count -gt 0) { throw 'Wildcard input file lists are not allowed.' }
        if ($ExactFileList.Count -gt 6) { throw "More than six input files provided. Maximum: 6, Actual: $($ExactFileList.Count)" }
        return @($ExactFileList)
    }
    $root = (Resolve-Path (Join-Path $PSScriptRoot '..\..')).Path
    return @((Join-Path $root 'docs\ASTRO_REBELS_TRAFFIC_MASTER_SPEC_EN.md'), (Join-Path $root 'docs\ASTRO_REBELS_TRAFFIC_ARCHITECTURE_EN.md'))
}
function Find-Requirement([string]$Content, [string]$Id, [string]$Path) {
    $escaped = [regex]::Escape($Id)
    $matches = @([regex]::Matches($Content, "(?im)^(?<level>#{2,6})\s+.*?\b$escaped\b.*$"))
    if ($matches.Count -eq 0) { throw "Missing requirement ID '$Id' in '$Path'." }
    if ($matches.Count -gt 1) { throw "Duplicate requirement ID '$Id' in '$Path'." }
    $match = $matches[0]; $level = $match.Groups['level'].Value.Length; $start = $match.Index; $after = $match.Index + $match.Length
    $next = [regex]::Match($Content.Substring($after), "(?im)^#{1,$level}\s+.*$")
    $end = if ($next.Success) { $after + $next.Index } else { $Content.Length }
    return $Content.Substring($start, $end - $start).Trim()
}
try {
    Assert-UniqueIds $SpecIds 'Spec'; Assert-UniqueIds $ArchIds 'Arch'; $files = Get-SourceFiles
    foreach ($file in $files) { if (-not (Test-Path -LiteralPath $file -PathType Leaf)) { throw "Input file not found: '$file'." } }
    $contents = @{}; foreach ($file in $files) { $contents[$file] = Get-Content -LiteralPath $file -Raw -Encoding UTF8 }
    $parts = [Collections.Generic.List[string]]::new(); $parts.Add("# Task: $TaskId"); $parts.Add('')
    foreach ($id in @($SpecIds + $ArchIds)) {
        $matches = @($files | Where-Object { $contents[$_] -match "(?im)^#{2,6}\s+.*\b$([regex]::Escape($id))\b" } | ForEach-Object { Find-Requirement $contents[$_] $id $_ })
        if ($matches.Count -eq 0) { throw "Missing requirement ID '$id'." }; if ($matches.Count -gt 1) { throw "Duplicate requirement ID '$id' across input files." }
        $parts.Add($matches[0]); $parts.Add('')
    }
    $parts.Add('## Source files'); foreach ($file in $files) { $hash = (Get-FileHash -LiteralPath $file -Algorithm SHA256).Hash; $parts.Add("- $file - $hash") }
    $output = ($parts -join "`r`n") + "`r`n"; if ($output.Length -gt $MaxChars) { throw "Output exceeds MaxChars limit: $($output.Length) > $MaxChars." }
    $directory = Split-Path -Parent $OutputPath; if ($directory -and -not (Test-Path -LiteralPath $directory)) { New-Item -ItemType Directory -Path $directory -Force | Out-Null }
    [IO.File]::WriteAllText($OutputPath, $output, (New-Object Text.UTF8Encoding($false))); Write-Host "Context written: $OutputPath ($($output.Length) characters)"
}
catch { Write-Error $_.Exception.Message; exit 1 }
