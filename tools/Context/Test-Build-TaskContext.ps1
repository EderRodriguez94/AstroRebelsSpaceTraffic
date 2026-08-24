# Deterministic, parameterless self-test for Build-TaskContext.ps1.
[CmdletBinding()]
param()
$ErrorActionPreference = 'Stop'
$extractor = Join-Path $PSScriptRoot 'Build-TaskContext.ps1'
$temp = Join-Path ([IO.Path]::GetTempPath()) ('AstroRebelsContext-' + [guid]::NewGuid().ToString('N'))
New-Item -ItemType Directory -Path $temp | Out-Null
function Invoke-Case([string]$Name, [scriptblock]$Action) {
    try { & $Action; Write-Host "PASS: $Name"; return $true }
    catch { Write-Host "FAIL: $Name - $($_.Exception.Message)"; return $false }
}
try {
    $spec = Join-Path $temp 'spec.md'; $arch = Join-Path $temp 'arch.md'
    Set-Content $spec "### ART-SPEC-TEST-001`r`nRequired behavior.`r`n`r`n### ART-SPEC-OTHER-001`r`nOther behavior." -Encoding UTF8
    Set-Content $arch "### ART-ARCH-TEST-001`r`nRequired organization." -Encoding UTF8
    $out = Join-Path $temp 'out.md'
    $results = @()
    $results += Invoke-Case 'success' { & $extractor -TaskId ART-TEST -SpecIds ART-SPEC-TEST-001 -ArchIds ART-ARCH-TEST-001 -OutputPath $out -MaxChars 24000 -ExactFileList @($spec, $arch); if (-not (Test-Path $out)) { throw 'output was not created' } }
    $results += Invoke-Case 'missing ID' { try { & $extractor -TaskId ART-TEST -SpecIds ART-SPEC-MISSING -ArchIds @() -OutputPath $out -MaxChars 24000 -ExactFileList @($spec); throw 'missing ID was accepted' } catch { if ($_.Exception.Message -notmatch 'Missing requirement ID') { throw } } }
    $results += Invoke-Case 'duplicate ID' { try { & $extractor -TaskId ART-TEST -SpecIds @('ART-SPEC-TEST-001','ART-SPEC-TEST-001') -ArchIds @() -OutputPath $out -MaxChars 24000 -ExactFileList @($spec); throw 'duplicate ID was accepted' } catch { if ($_.Exception.Message -notmatch 'Duplicate Spec ID') { throw } } }
    $results += Invoke-Case 'MaxChars limit' { try { & $extractor -TaskId ART-TEST -SpecIds ART-SPEC-TEST-001 -ArchIds @() -OutputPath $out -MaxChars 10 -ExactFileList @($spec); throw 'size limit was not enforced' } catch { if ($_.Exception.Message -notmatch 'exceeds MaxChars') { throw } } }
    if (@($results | Where-Object { -not $_ }).Count -gt 0) { exit 1 }
    Write-Host 'All four test cases passed.'
    exit 0
}
finally { if (Test-Path $temp) { Remove-Item $temp -Recurse -Force } }
