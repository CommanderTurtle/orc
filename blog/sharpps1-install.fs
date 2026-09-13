module Bl0g.InstallPs1

let file = """param(
    [ValidateSet("site", "libraries", "ai")]
    [string[]]$Track,
    [string]$ProjectsRoot = (Join-Path $HOME "Projects"),
    [string]$Manifest = $(if ($env:SHEL_INSTALL_MANIFEST_URL) { $env:SHEL_INSTALL_MANIFEST_URL } else { "https://shel.sh/install-manifest.json" }),
    [switch]$DryRun,
    [switch]$Yes
)

$ErrorActionPreference = "Stop"
$AiInstallUrl = if ($env:SHEL_AI_INSTALL_URL) { $env:SHEL_AI_INSTALL_URL } else { "https://shel.sh/install-ai.sh" }

function Write-Section([string]$Text) {
    Write-Host "`n$Text" -ForegroundColor Magenta
}

function Write-Note([string]$Text) {
    Write-Host "  $Text"
}

function Invoke-Step {
    param([Parameter(ValueFromRemainingArguments = $true)][object[]]$Command)
    if ($DryRun) {
        Write-Note ("+ " + (($Command | ForEach-Object { '"' + ($_ -replace '"', '\"') + '"' }) -join " "))
        return
    }
    if ($Command.Count -eq 0) { throw "Invoke-Step requires a command." }
    $executable = [string]$Command[0]
    $arguments = @($Command | Select-Object -Skip 1)
    & $executable @arguments
    if ($LASTEXITCODE -ne 0) { throw "Command failed: $($Command -join ' ')" }
}

function Invoke-In {
    param(
        [string]$Directory,
        [Parameter(ValueFromRemainingArguments = $true)][object[]]$Command
    )
    if ($DryRun) {
        Write-Note ("+ (cd `"$Directory`"; " + ($Command -join " ") + ")")
        return
    }
    Push-Location $Directory
    try { Invoke-Step @Command } finally { Pop-Location }
}

function Refresh-Path {
    $machine = [Environment]::GetEnvironmentVariable("Path", "Machine")
    $user = [Environment]::GetEnvironmentVariable("Path", "User")
    $env:Path = "$machine;$user;$HOME\.cargo\bin;$HOME\.local\bin;$HOME\.bun\bin"
}

function Ensure-WingetPackage([string]$Command, [string]$Id) {
    if (Get-Command $Command -ErrorAction SilentlyContinue) { return }
    if (-not (Get-Command winget -ErrorAction SilentlyContinue)) {
        throw "winget is required to install $Id."
    }
    Invoke-Step winget install --id $Id --exact --accept-package-agreements --accept-source-agreements
    if (-not $DryRun) { Refresh-Path }
}

function Get-InstallerManifest {
    if (Test-Path -LiteralPath $Manifest) {
        return Get-Content -Raw -LiteralPath $Manifest | ConvertFrom-Json
    }
    return Invoke-RestMethod -Uri $Manifest
}

function Get-Repo([string]$Key) {
    $repo = $script:InstallerManifest.repositories.$Key
    if (-not $repo) { throw "Repository '$Key' is missing from the installer manifest." }
    return $repo
}

function Get-RepoRemote([string]$Destination, [string]$ExpectedUrl) {
    $expected = (($ExpectedUrl.TrimEnd('/')) -replace '\.git$', '').ToLowerInvariant()
    $names = @(& git -C $Destination remote)
    if ($LASTEXITCODE -ne 0) { throw "Could not list remotes for $Destination." }
    foreach ($name in $names) {
        $value = (& git -C $Destination remote get-url $name 2>$null | Select-Object -First 1)
        if ($LASTEXITCODE -ne 0 -or -not $value) { continue }
        $normalized = (($value.Trim().TrimEnd('/')) -replace '\.git$', '').ToLowerInvariant()
        if ($normalized -eq $expected) { return $name }
    }
    throw "$Destination has no remote for $ExpectedUrl"
}

function Sync-Repo([string]$Key, [string]$Destination) {
    $repo = Get-Repo $Key
    if (Test-Path (Join-Path $Destination ".git")) {
        $remote = Get-RepoRemote $Destination $repo.url
        Invoke-In $Destination git fetch $remote $repo.branch
        Invoke-In $Destination git merge --ff-only "$remote/$($repo.branch)"
    }
    elseif (Test-Path $Destination) {
        throw "$Destination exists but is not a Git worktree."
    }
    else {
        if ($DryRun) { Write-Note "+ mkdir `"$([IO.Path]::GetDirectoryName($Destination))`"" }
        else { New-Item -ItemType Directory -Force -Path ([IO.Path]::GetDirectoryName($Destination)) | Out-Null }
        Invoke-Step git clone --branch $repo.branch --single-branch $repo.url $Destination
    }
}

function ConvertTo-BashLiteral([string]$Value) {
    return "'" + $Value.Replace("'", "'\''") + "'"
}

function Ensure-Wsl {
    if (-not (Get-Command wsl.exe -ErrorAction SilentlyContinue)) {
        throw "WSL is required for the AI and Sandwich routes. Run 'wsl --install', finish first-run setup, then rerun."
    }
    if (-not $DryRun) {
        & wsl.exe -e sh -lc "true" | Out-Null
        if ($LASTEXITCODE -ne 0) { throw "Start the WSL distribution once, then rerun." }
    }
}

function Invoke-Wsl([string]$Command) {
    if ($DryRun) { Write-Note "+ wsl.exe bash -lc $Command"; return }
    & wsl.exe -e bash -lc $Command
    if ($LASTEXITCODE -ne 0) { throw "WSL command failed." }
}

function Install-SiteTools {
    Write-Section "Site tools"
    Ensure-WingetPackage git "Git.Git"
    Ensure-WingetPackage dotnet "Microsoft.DotNet.SDK.10"
    Ensure-WingetPackage cargo "Rustlang.Rustup"
    Ensure-WingetPackage uv "astral-sh.uv"
    Ensure-WingetPackage bun "Oven-sh.Bun"
    Ensure-WingetPackage pwsh "Microsoft.PowerShell"
    Ensure-WingetPackage ruby "RubyInstallerTeam.RubyWithDevKit.3.4"
    Sync-Repo "orc" (Join-Path $ProjectsRoot "orc")
    Sync-Repo "reactor" (Join-Path $ProjectsRoot "reactor")
    Sync-Repo "preview" (Join-Path $ProjectsRoot "preview")
    Sync-Repo "tools" (Join-Path $ProjectsRoot "tools")
    Invoke-In (Join-Path $ProjectsRoot "reactor") cargo build --release
    Invoke-In (Join-Path $ProjectsRoot "preview") cargo build --release
    Write-Note "Orc: $ProjectsRoot\orc"
    Write-Note "Render: cd `"$ProjectsRoot\orc`"; dotnet fsi GenerateConfig.fsx render-all .rendered --clean"
    Write-Note "Preview GUI: $ProjectsRoot\preview\target\release\orc-preview.exe"
    Write-Note "Scaffold Zensical with uvx zensical; Jekyll with bundle; Vite with bun create vite."
}

function Install-Libraries {
    Write-Section "Libraries"
    Ensure-WingetPackage git "Git.Git"
    Ensure-WingetPackage cargo "Rustlang.Rustup"
    Ensure-WingetPackage bun "Oven-sh.Bun"
    Sync-Repo "regedited" (Join-Path $ProjectsRoot "regedited")
    Sync-Repo "macrohard" (Join-Path $ProjectsRoot "macrohard")
    Invoke-In (Join-Path $ProjectsRoot "regedited") cargo build --release
    Invoke-In (Join-Path $ProjectsRoot "regedited") powershell -ExecutionPolicy Bypass -File .\scripts\pathadd.ps1
    Write-Note "Macrohard requires Qt 6.9.3. Install with:"
    Write-Note "  cd `"$ProjectsRoot\macrohard`"; .\install.ps1 -QtPath C:\Qt\6.9.3\mingw_64"

    Ensure-Wsl
    $sandwich = Get-Repo "sandwich"
    $qBranch = ConvertTo-BashLiteral $sandwich.branch
    $qUrl = ConvertTo-BashLiteral $sandwich.url
    $command = 'set -Eeuo pipefail; mkdir -p "$HOME/Projects"; ' +
        'if [ -d "$HOME/Projects/sandwich/.git" ]; then ' +
        'git -C "$HOME/Projects/sandwich" fetch origin ' + $qBranch + '; ' +
        'git -C "$HOME/Projects/sandwich" merge --ff-only origin/' + $sandwich.branch + '; ' +
        'else git clone --branch ' + $qBranch + ' --single-branch ' + $qUrl +
        ' "$HOME/Projects/sandwich"; fi; ' +
        'cd "$HOME/Projects/sandwich" && bash install.sh'
    Invoke-Wsl $command
}

function Install-Ai {
    Write-Section "AI workstation"
    Ensure-Wsl
    $aiArgs = @("--manifest", (ConvertTo-BashLiteral $Manifest))
    if ($DryRun) { $aiArgs += "--dry-run" }
    if ($Yes) { $aiArgs += "--yes" }
    $command = 'set -Eeuo pipefail; f=$(mktemp); trap ''rm -f "$f"'' EXIT; curl -fsSL ' +
        (ConvertTo-BashLiteral $AiInstallUrl) + ' -o "$f"; bash "$f" ' + ($aiArgs -join " ")
    Invoke-Wsl $command
}

Write-Section "sHEL workstation installer"
if (-not $Track -or $Track.Count -eq 0) {
    if ($Yes) {
        $Track = @("site", "libraries", "ai")
    }
    else {
        Write-Host @"
Choose one or more tracks:
  1  Site tools
  2  Libraries
  3  AI workstation (WSL)
"@
        $choice = Read-Host "Selection [1,2,3]"
        if (-not $choice) { $choice = "1,2,3" }
        $Track = @()
        if ($choice -match "1") { $Track += "site" }
        if ($choice -match "2") { $Track += "libraries" }
        if ($choice -match "3") { $Track += "ai" }
    }
}

$script:InstallerManifest = Get-InstallerManifest
if ($script:InstallerManifest.schema -ne 1) { throw "Unsupported installer manifest." }
if (-not $DryRun) { New-Item -ItemType Directory -Force -Path $ProjectsRoot | Out-Null }
foreach ($item in $Track | Select-Object -Unique) {
    switch ($item) {
        "site" { Install-SiteTools }
        "libraries" { Install-Libraries }
        "ai" { Install-Ai }
    }
}

Write-Section "Complete"
Write-Note "Projects: $ProjectsRoot"
Write-Note "Open a new terminal for newly installed PATH entries. No model was launched."
"""

let render() = file
