module ConvertedFiles.InstallPs1

let file = """[CmdletBinding()]
param(
    [switch]$DryRun,
    [switch]$Yes,
    [string]$ProjectsRoot = (Join-Path $HOME "Projects"),
    [string]$Manifest = "https://shel.sh/install-manifest.json",
    [string]$WslDistribution = "Debian"
)

$ErrorActionPreference = "Stop"
$ProgressPreference = "SilentlyContinue"
$script:InstallerVersion = "1"

function Write-Section([string]$Text) {
    Write-Host ""
    Write-Host $Text -ForegroundColor Magenta
}
function Write-Note([string]$Text) {
    Write-Host "  $Text"
}
function Invoke-Step {
    param(
        [Parameter(Mandatory)][string]$Executable,
        [Parameter(ValueFromRemainingArguments)][string[]]$Arguments
    )
    if ($DryRun) {
        Write-Host ("  + {0} {1}" -f $Executable, ($Arguments -join " "))
        return
    }
    & $Executable @Arguments
    if ($LASTEXITCODE -ne 0) {
        throw "$Executable exited with code $LASTEXITCODE"
    }
}
function Invoke-In {
    param(
        [Parameter(Mandatory)][string]$WorkingPath,
        [Parameter(Mandatory)][string]$Executable,
        [Parameter(ValueFromRemainingArguments)][string[]]$Arguments
    )
    if ($DryRun) {
        Write-Host ("  + (cd {0}; {1} {2})" -f $WorkingPath, $Executable, ($Arguments -join " "))
        return
    }
    Push-Location $WorkingPath
    try { Invoke-Step $Executable @Arguments }
    finally { Pop-Location }
}
function Read-Default([string]$Label, [string]$Default = "") {
    $suffix = if ($Default) { " [$Default]" } else { "" }
    $answer = Read-Host "$Label$suffix"
    if ([string]::IsNullOrWhiteSpace($answer)) { return $Default }
    return $answer.Trim()
}
function Confirm-Choice([string]$Label, [bool]$Default = $true) {
    $hint = if ($Default) { "Y/n" } else { "y/N" }
    $answer = (Read-Default "$Label ($hint)" $(if ($Default) { "y" } else { "n" })).ToLowerInvariant()
    return $answer -in @("y", "yes")
}
function Test-Selection([string]$Csv, [string]$Value) {
    return (($Csv -split ",").Trim() -contains $Value)
}
function Refresh-Path {
    $machine = [Environment]::GetEnvironmentVariable("Path", "Machine")
    $user = [Environment]::GetEnvironmentVariable("Path", "User")
    $env:Path = "$machine;$user"
}
function Ensure-WingetPackage {
    param([string]$Command, [string]$Id)
    if (Get-Command $Command -ErrorAction SilentlyContinue) { return }
    Write-Section "Installing $Id"
    Invoke-Step winget install --id $Id --exact --accept-package-agreements --accept-source-agreements `
        $(if ($Yes) { "--silent" } else { "--interactive" })
    if (-not $DryRun) { Refresh-Path }
}
function Get-Manifest {
    if (Test-Path -LiteralPath $Manifest) {
        return Get-Content -Raw -LiteralPath $Manifest | ConvertFrom-Json
    }
    return Invoke-RestMethod -Uri $Manifest
}
function Get-Repo([string]$Key) {
    return $script:SuiteManifest.repositories.$Key
}
function Sync-Repository([string]$Key, [string]$Destination) {
    $repo = Get-Repo $Key
    if (Test-Path (Join-Path $Destination ".git")) {
        Write-Note "Updating $Key in $Destination"
        Invoke-In $Destination git fetch origin $repo.branch
        Invoke-In $Destination git merge --ff-only "origin/$($repo.branch)"
    }
    elseif (Test-Path $Destination) {
        throw "$Destination exists but is not a Git worktree."
    }
    else {
        Invoke-Step git clone --branch $repo.branch --single-branch $repo.url $Destination
    }
}
function Use-Repository([string]$Key, [string]$Destination) {
    if ($script:InstallMode -eq "configure") {
        if (-not (Test-Path (Join-Path $Destination ".git"))) {
            if (Confirm-Choice "No $Key clone was found at $Destination. Install it now?" $true) {
                Sync-Repository $Key $Destination
                return
            }
            throw "Configure requires an existing Git clone: $Destination"
        }
        if (Confirm-Choice "Fetch and fast-forward $Key before configuring it?" $true) {
            Sync-Repository $Key $Destination
        }
        else {
            Write-Note "Using the existing $Key worktree without changing its revision."
        }
    }
    else {
        Sync-Repository $Key $Destination
    }
}
function Install-Reference([string]$Key, [string]$Slug, [string]$Label) {
    if (Confirm-Choice "Clone or update $Label in the separate references folder?" $false) {
        $destination = Join-Path $script:ReferencesRoot $Slug
        Sync-Repository $Key $destination
        Write-Note "Reference: $destination"
    }
}
function ConvertTo-BashLiteral([string]$Value) {
    return "'" + $Value.Replace("'", "'""'""'") + "'"
}
function ConvertTo-BashPath([string]$Value) {
    if ($Value -notmatch '^(~/|/)[A-Za-z0-9._ /-]*$') {
        throw "WSL paths must be absolute or start with ~/ and contain only letters, digits, spaces, dot, underscore, slash, or dash."
    }
    if ($Value -eq "~") { return '"$HOME"' }
    if ($Value.StartsWith("~/")) {
        $tail = $Value.Substring(2).Replace('"', '\"')
        return ('"$HOME/{0}"' -f $tail)
    }
    return ConvertTo-BashLiteral $Value
}
function Test-WslDistribution([string]$Name) {
    if (-not (Get-Command wsl.exe -ErrorAction SilentlyContinue)) { return $false }
    $installed = @(& wsl.exe --list --quiet 2>$null) |
        ForEach-Object { (($_ -replace "`0", "").Trim()) } |
        Where-Object { $_ }
    return $installed -contains $Name
}
function Ensure-Wsl {
    if (Test-WslDistribution $WslDistribution) { return }
    Write-Section "Windows Subsystem for Linux"
    Write-Note "Diogenes and Sandwich run inside WSL. Installing $WslDistribution."
    Invoke-Step wsl.exe --install --distribution $WslDistribution
    if (-not $DryRun) {
        throw "Finish the $WslDistribution first-run account setup, then rerun this installer."
    }
}
function Invoke-WslBash([string]$Command) {
    if ($DryRun) {
        Write-Host "  + wsl.exe -d $WslDistribution -- bash -lc $Command"
        return
    }
    & wsl.exe -d $WslDistribution -- bash -lc $Command
    if ($LASTEXITCODE -ne 0) { throw "WSL command exited with code $LASTEXITCODE" }
}
function Install-WslRepository([string]$Key, [string]$Destination, [string]$AfterSync = "") {
    $repo = Get-Repo $Key
    $qDest = ConvertTo-BashPath $Destination
    $qUrl = ConvertTo-BashLiteral $repo.url
    $qBranch = ConvertTo-BashLiteral $repo.branch
    $sync = if ($script:InstallMode -eq "install") {
        $true
    } else {
        Confirm-Choice "Fetch and fast-forward $Key before configuring it?" $true
    }
    $mode = ConvertTo-BashLiteral $script:InstallMode
    $syncLiteral = if ($sync) { "1" } else { "0" }
    $command = @"
set -Eeuo pipefail
install_mode=$mode
sync_existing=$syncLiteral
mkdir -p "`$(dirname $qDest)"
if [ "`$install_mode" = configure ] && [ ! -d $qDest/.git ]; then
  echo 'Configure requires an existing Git clone: $Destination' >&2
  exit 1
elif [ -d $qDest/.git ] && [ "`$sync_existing" = 1 ]; then
  git -C $qDest fetch origin $qBranch
  git -C $qDest merge --ff-only origin/$($repo.branch)
elif [ -d $qDest/.git ]; then
  echo 'Using the existing $key worktree without changing its revision.'
elif [ -e $qDest ]; then
  echo '$Destination exists but is not a Git worktree.' >&2
  exit 1
else
  git clone --branch $qBranch --single-branch $qUrl $qDest
fi
cd $qDest
$AfterSync
"@
    Invoke-WslBash $command
}
function Write-Utf8NoBom([string]$Path, [string]$Content) {
    if ($DryRun) {
        Write-Note "Write $Path"
        return
    }
    $parent = Split-Path -Parent $Path
    if ($parent) { New-Item -ItemType Directory -Force -Path $parent | Out-Null }
    [IO.File]::WriteAllText($Path, $Content, [Text.UTF8Encoding]::new($false))
}
function New-DeployConfig([string]$OrcDir, [string]$Slug, [string]$TargetRepo, [string]$Cname) {
    $module = (($Slug -split "[^A-Za-z0-9]+" | ForEach-Object {
        if ($_) { $_.Substring(0,1).ToUpperInvariant() + $_.Substring(1) }
    }) -join "")
    $title = $Slug.Substring(0,1).ToUpperInvariant() + $Slug.Substring(1)
    $body = @"
module Config.Workflows.Deploy$module

let render() =
    Config.Workflows.DeployCommon.render {
        WorkflowName = "Deploy $title"
        SourceFolder = "$Slug"
        TargetRepo = "$TargetRepo"
        TargetBranch = "main"
        TokenName = "GH_PAGES_TOKEN"
        Cname = "$Cname"
    }
"@
    Write-Utf8NoBom (Join-Path $OrcDir ".github\config\deploy-$Slug.fs") $body
}
function Convert-ScaffoldToOrc([string]$GeneratorProject, [string]$Scaffold, [string]$Destination) {
    if (-not $DryRun) { New-Item -ItemType Directory -Force -Path $Destination | Out-Null }
    Invoke-Step dotnet run --project $GeneratorProject -- wrap-site $Scaffold $Destination
}
function Enable-ViteTailwind([string]$Scaffold) {
    Invoke-In $Scaffold bun add --dev tailwindcss "@tailwindcss/vite"
    if ($DryRun) {
        Write-Note "Register @tailwindcss/vite in Vite config and import Tailwind from the primary stylesheet."
        return
    }
    $config = @("vite.config.ts", "vite.config.js", "vite.config.mts", "vite.config.mjs") |
        ForEach-Object { Join-Path $Scaffold $_ } |
        Where-Object { Test-Path $_ } |
        Select-Object -First 1
    if (-not $config) {
        $config = Join-Path $Scaffold "vite.config.ts"
        $source = @"
import { defineConfig } from 'vite'
import tailwindcss from '@tailwindcss/vite'

export default defineConfig({
  plugins: [tailwindcss()],
})
"@
    }
    else {
        $source = Get-Content -Raw $config
        if ($source -notmatch "@tailwindcss/vite") {
            $source = "import tailwindcss from '@tailwindcss/vite'`n" + $source
        }
        if ($source -notmatch "tailwindcss\(\)") {
            $updated = [regex]::Replace($source, 'plugins\s*:\s*\[', 'plugins: [tailwindcss(), ', 1)
            if ($updated -eq $source) { throw "Could not locate plugins array in $(Split-Path -Leaf $config)." }
            $source = $updated
        }
    }
    Write-Utf8NoBom $config $source

    $style = @("src\index.css", "src\style.css", "src\app.css", "style.css") |
        ForEach-Object { Join-Path $Scaffold $_ } |
        Where-Object { Test-Path $_ } |
        Select-Object -First 1
    if (-not $style) { $style = Join-Path $Scaffold "src\style.css" }
    $css = if (Test-Path $style) { Get-Content -Raw $style } else { "" }
    if ($css -notmatch '@import\s+"tailwindcss"') {
        Write-Utf8NoBom $style ('@import "tailwindcss";' + "`n" + $css)
    }
}
function Get-SiteImportProfile([string]$InputPath) {
    $resolved = Resolve-Path -LiteralPath $InputPath -ErrorAction Stop
    if (Test-Path -LiteralPath $resolved.Path -PathType Leaf) {
        $matches = [regex]::Matches(
            (Split-Path -Parent $resolved.Path),
            '(?i)(?:^|[\\/])(app|blog|docs|pages|prov|vite)(?=[\\/]|$)'
        )
        if ($matches.Count) { return $matches[$matches.Count - 1].Groups[1].Value.ToLowerInvariant() }
        # A standalone HTML file follows the app recipe in wraps.txt: wrap it,
        # then normalize a generated index/index.fs when present.
        return "app"
    }
    $root = $resolved.Path
    $leaf = Split-Path -Leaf $root
    if ($leaf -in @("app", "blog", "docs", "pages", "prov", "vite")) { return $leaf }
    if (Test-Path (Join-Path $root "zensical.toml")) { return "docs" }
    if (Test-Path (Join-Path $root "captcha")) { return "pages" }
    if ((Test-Path (Join-Path $root "Gemfile")) -or (Test-Path (Join-Path $root "_config.yml"))) { return "blog" }
    $package = Join-Path $root "package.json"
    if ((Test-Path $package) -and ((Get-Content -Raw $package) -match '"vite"\s*:')) { return "vite" }
    return "app"
}
function Rename-GeneratedFiles([string]$Root, [string]$Old, [string]$New) {
    @(Get-ChildItem -LiteralPath $Root -Recurse -File) |
        Where-Object { $_.Name.IndexOf($Old, [StringComparison]::Ordinal) -ge 0 } |
        ForEach-Object {
            Rename-Item -LiteralPath $_.FullName -NewName $_.Name.Replace($Old, $New)
        }
}
function Move-GeneratedIndexFiles([string]$Root) {
    @(Get-ChildItem -LiteralPath $Root -Recurse -File -Filter "index.fs") |
        Where-Object { $_.Directory.Name -eq "index" } |
        ForEach-Object {
            $target = Join-Path $_.Directory.Parent.FullName "index.fs"
            if (Test-Path $target) { throw "Index normalization would overwrite $target" }
            Move-Item -LiteralPath $_.FullName -Destination $target
            Remove-Item -LiteralPath $_.Directory.FullName -Force
        }
}
function Invoke-OrcSiteImport {
    param(
        [string]$InputPath,
        [string]$Destination,
        [string]$Profile,
        [string]$GeneratorProject,
        [string]$ToolsDir
    )
    if ($DryRun) {
        Write-Note "Stage $InputPath, apply convert-comments.ps1, run wrap-batch with the '$Profile' rules from .github/wraps.txt, and write $Destination."
        return
    }
    if (Test-Path $Destination) { throw "Import destination already exists: $Destination" }
    $resolved = Resolve-Path -LiteralPath $InputPath -ErrorAction Stop
    $work = Join-Path ([IO.Path]::GetTempPath()) ("shel-import-" + [guid]::NewGuid().ToString("N"))
    $source = Join-Path $work "source"
    $output = Join-Path $work "output"
    New-Item -ItemType Directory -Force -Path $source, $output | Out-Null
    try {
        if (Test-Path -LiteralPath $resolved.Path -PathType Leaf) {
            Copy-Item -LiteralPath $resolved.Path -Destination (Join-Path $source (Split-Path -Leaf $resolved.Path))
        }
        else {
            & robocopy.exe $resolved.Path $source /E /R:2 /W:1 /XD .git .github .venv .cache .bundle .jekyll-cache bin obj node_modules site _site dist public output | Out-Host
            if ($LASTEXITCODE -ge 8) { throw "robocopy failed with code $LASTEXITCODE" }
        }

        $commentTool = Join-Path $ToolsDir "convert-comments.ps1"
        if (-not (Test-Path $commentTool)) { throw "Missing comment migration tool: $commentTool" }
        Invoke-Step pwsh -NoProfile -File $commentTool -Path $source -Apply

        if ($Profile -in @("blog", "docs")) {
            Get-ChildItem -LiteralPath $source -Recurse -File -Filter "*.html" |
                Rename-Item -NewName { $_.BaseName + ".raw" }
        }
        elseif ($Profile -eq "pages") {
            $captcha = Join-Path $source "captcha"
            if (Test-Path $captcha) {
                Get-ChildItem -LiteralPath $captcha -Recurse -File -Filter "*.html" |
                    Rename-Item -NewName { $_.BaseName + ".raw" }
                Get-ChildItem -LiteralPath $captcha -File -Filter "*.raw" |
                    Rename-Item -NewName { $_.BaseName + ".html" }
            }
        }

        Invoke-Step dotnet run --project $GeneratorProject -- wrap-batch $source $output

        switch ($Profile) {
            { $_ -in @("app", "prov") } {
                Move-GeneratedIndexFiles $output
            }
            "vite" {
                Move-GeneratedIndexFiles $output
                Rename-GeneratedFiles $output "sharpmd-index" "indexmd"
            }
            { $_ -in @("blog", "docs") } {
                Rename-GeneratedFiles $output "sharpraw" "sharphtml"
                Rename-GeneratedFiles $output "sharpmd-index" "indexmd"
                if ($Profile -eq "docs") {
                    Rename-GeneratedFiles $output "sharpoml-zensical" "zensical"
                }
            }
            "pages" {
                $captchaOutput = Join-Path $output "captcha"
                if (Test-Path $captchaOutput) {
                    Rename-GeneratedFiles $captchaOutput "sharpraw" "sharphtml"
                    Rename-GeneratedFiles $captchaOutput "sharphtml-index" "index"
                    Move-GeneratedIndexFiles $captchaOutput
                }
                Rename-GeneratedFiles $output "sharpmd-index" "indexmd"
            }
        }

        New-Item -ItemType Directory -Force -Path $Destination | Out-Null
        Copy-Item -Path (Join-Path $output "*") -Destination $Destination -Recurse -Force
    }
    finally {
        if (Test-Path $work) { Remove-Item -LiteralPath $work -Recurse -Force }
    }
}
function Rename-OrcModules([string]$RepoRoot, [string]$CheckDirectory, [string]$ToolsDir) {
    if ($DryRun) {
        Write-Note "Audit and apply collision-free module names from Tools/modulefix.ps1."
        return
    }
    $moduleTool = Join-Path $ToolsDir "modulefix.ps1"
    if (-not (Test-Path $moduleTool)) { throw "Missing module naming tool: $moduleTool" }
    $json = & pwsh -NoProfile -File $moduleTool -RepoRoot $RepoRoot -CheckDirectory $CheckDirectory -Format Json
    if ($LASTEXITCODE -ne 0) { throw "modulefix.ps1 exited with code $LASTEXITCODE" }
    $plan = ($json -join "`n") | ConvertFrom-Json
    # A current-name collision is exactly what this pass repairs. Only refuse a
    # plan when modulefix says two files would receive the same proposed name.
    $blocked = @($plan.Files | Where-Object { $_.Status -eq "ProposalCollision" })
    if ($blocked.Count) {
        $blocked | Format-Table File, Current, Suggested, Status -AutoSize
        throw "Module names were not changed because modulefix reported a collision."
    }
    foreach ($row in @($plan.Files)) {
        if ($row.Status -eq "Aligned") { continue }
        $file = Join-Path $CheckDirectory $row.File
        $source = Get-Content -Raw -LiteralPath $file
        $updated = $source
        if ($row.Declaration -eq "module" -and $row.Current) {
            $pattern = '(?m)^(\s*module\s+(?:rec\s+)?)' + [regex]::Escape($row.Current) + '(\s*)$'
            $updated = [regex]::Replace($source, $pattern, ('$1' + $row.Suggested + '$2'), 1)
        }
        elseif ($row.Declaration -eq "namespace" -and $row.Current) {
            $pattern = '(?m)^(\s*namespace\s+)' + [regex]::Escape($row.Current) + '(\s*)$'
            $updated = [regex]::Replace($source, $pattern, ('$1' + $row.Suggested + '$2'), 1)
        }
        elseif ($row.Declaration -eq "missing") {
            $updated = "module $($row.Suggested)`n`n" + $source
        }
        else {
            Write-Note "Review manually: $($row.File) ($($row.Declaration))."
            continue
        }
        if ($updated -eq $source) { throw "Could not apply modulefix proposal to $($row.File)" }
        Write-Utf8NoBom $file $updated
        Write-Note "$($row.File): $($row.Current) -> $($row.Suggested)"
    }
}

Write-Section "sHEL workstation installer"
Write-Note "Windows 11 uses native tools for Orc and libraries; Diogenes and Sandwich use WSL."
Write-Note "Projects directory: $ProjectsRoot"
Write-Note "No GPU driver, Docker daemon, account, token, or secret is modified automatically."

if (-not (Get-Command winget -ErrorAction SilentlyContinue)) {
    throw "winget is required. Install or update App Installer from Microsoft Store."
}
Ensure-WingetPackage git "Git.Git"
$script:SuiteManifest = Get-Manifest
if (-not $DryRun) { New-Item -ItemType Directory -Force -Path $ProjectsRoot | Out-Null }
$script:ReferencesRoot = Join-Path $ProjectsRoot "references"

Write-Host @"

Would you like to:
  1  Install - create new clones and initialize selected frameworks
  2  Configure - work with existing clones without replacing their files
"@
$modeChoice = (Read-Default "Choose a mode" "1").ToLowerInvariant()
$script:InstallMode = switch ($modeChoice) {
    { $_ -in @("1", "install") } { "install"; break }
    { $_ -in @("2", "configure") } { "configure"; break }
    default { throw "Choose Install (1) or Configure (2)." }
}

Write-Section "Recommended workstation tools"
foreach ($tool in @("zed", "bun", "uv")) {
    $command = Get-Command $tool -ErrorAction SilentlyContinue
    Write-Note $(if ($command) { "$tool`: detected at $($command.Source)" } else { "$tool`: not detected" })
}
Write-Note "Zed is the recommended editor; Bun and uv are the JavaScript and Python authorities used by this suite."
if (Confirm-Choice "Install any missing recommended tools now?" $true) {
    Ensure-WingetPackage zed "ZedIndustries.Zed"
    Ensure-WingetPackage bun "Oven-sh.Bun"
    Ensure-WingetPackage uv "astral-sh.uv"
}

Write-Host @"

Which parts would you like to work with?
  1  Site Building - Orc, site frameworks, Reactor, Preview, and Tools
  2  Libraries - Regedited, Macrohard, and/or Sandwich
  3  AI - Diogenes local workstation (Linux/WSL, optional GPU)
"@
$kits = Read-Default "Choose one or more numbers, comma-separated" "1,2,3"

if (Test-Selection $kits "3") {
    Write-Section "Diogenes"
    Ensure-Wsl
    $linuxRoot = Read-Default "WSL projects directory" "~/Projects"
    $diogenesPath = Read-Default "Diogenes clone path in WSL" "$linuxRoot/diogenes"
    $setup = if (Confirm-Choice "Create Diogenes' Python 3.13.12 environment now?" $true) {
        "bash ./uvsetup.sh"
    } else {
        "echo 'Later: cd $linuxRoot/diogenes && ./uvsetup.sh'"
    }
    $bootstrap = @"
if ! command -v curl >/dev/null || ! command -v git >/dev/null; then
  sudo apt-get update
  sudo apt-get install -y git curl ca-certificates build-essential pkg-config libssl-dev python3-dev tmux
fi
if ! command -v uv >/dev/null; then
  curl -LsSf https://astral.sh/uv/install.sh | sh
  export PATH="`$HOME/.local/bin:`$PATH"
fi
if command -v nvidia-smi >/dev/null; then
  echo 'NVIDIA GPU detected; running Diogenes CUDA diagnostics.'
  [ -x scripts/check-docker-gpu.sh ] && bash scripts/check-docker-gpu.sh || true
elif command -v rocm-smi >/dev/null || [ -e /dev/kfd ]; then
  echo 'AMD GPU detected; running Diogenes ROCm diagnostics.'
  [ -x scripts/check-docker-amd-gpu.sh ] && bash scripts/check-docker-amd-gpu.sh || true
else
  echo 'No CUDA/ROCm runtime detected. CPU services work, but local model serving benefits from a supported GPU.'
fi
$setup
"@
    Install-WslRepository "diogenes" $diogenesPath $bootstrap
    Write-Note "Start later in WSL: cd $diogenesPath && ./startwithuv.sh"
    Write-Note "Optional MCPs, model engines, and services are installed from Diogenes' own GUI."
}

if (Test-Selection $kits "1") {
    Write-Section "Orc site workspace"
    Ensure-WingetPackage dotnet "Microsoft.DotNet.SDK.10"
    Ensure-WingetPackage cargo "Rustlang.Rustup"
    Ensure-WingetPackage uv "astral-sh.uv"
    Ensure-WingetPackage bun "Oven-sh.Bun"
    Ensure-WingetPackage pwsh "Microsoft.PowerShell"

    $orcDir = Read-Default "Orc clone path" (Join-Path $ProjectsRoot "orc")
    $orcWasNew = -not (Test-Path (Join-Path $orcDir ".git"))
    Use-Repository "orc" $orcDir
    $overlay = (Get-Repo "orc").overlayBranch
    $refreshOverlay = $script:InstallMode -eq "install" -or
        (Confirm-Choice "Refresh Orc's renderer and deployment authority from main?" $true)
    if ($DryRun -and $refreshOverlay) {
        Write-Note "Overlay the renderer, importer, and deployment authority from Orc $overlay."
    }
    elseif ($refreshOverlay) {
        Invoke-In $orcDir git fetch origin "${overlay}:refs/remotes/origin/${overlay}"
        $generate = & git -C $orcDir show "origin/${overlay}:GenerateConfig.fsx"
        if ($LASTEXITCODE -ne 0) { throw "Could not read GenerateConfig.fsx from Orc $overlay." }
        Write-Utf8NoBom (Join-Path $orcDir "GenerateConfig.fsx") ($generate -join "`n")
        $deployCommon = & git -C $orcDir show "origin/${overlay}:.github/config/shared/deploy-common.fs"
        if ($LASTEXITCODE -ne 0) { throw "Could not read deploy-common.fs from Orc $overlay." }
        Write-Utf8NoBom (Join-Path $orcDir ".github\config\shared\deploy-common.fs") ($deployCommon -join "`n")
        $importer = & git -C $orcDir show "origin/${overlay}:src/generator/Program.fs"
        if ($LASTEXITCODE -ne 0) { throw "Could not read Program.fs from Orc $overlay." }
        Write-Utf8NoBom (Join-Path $orcDir "src\generator\Program.fs") ($importer -join "`n")
    }
    else {
        Write-Note "Preserving the existing Orc renderer and deployment files."
    }

    $generatorWork = Join-Path ([IO.Path]::GetTempPath()) ("shel-generator-" + [guid]::NewGuid().ToString("N"))
    $generatorProject = Join-Path $generatorWork "src\generator"
    if ($DryRun) {
        Write-Note "Compile Orc's site importer from a disposable copy so tracked bin/obj files stay clean."
    }
    else {
        New-Item -ItemType Directory -Force -Path $generatorWork | Out-Null
        Copy-Item -LiteralPath (Join-Path $orcDir "src") -Destination (Join-Path $generatorWork "src") -Recurse
    }

    $sites = [Collections.Generic.List[string]]::new()
    $deployFiles = @(Get-ChildItem (Join-Path $orcDir ".github\config") -Filter "deploy-*.fs" -File -ErrorAction SilentlyContinue)
    if ($orcWasNew) {
        if ($DryRun) {
            Write-Note "Remove Orc's sample deployment records before generating the selected sites."
        }
        else {
            foreach ($deployFile in $deployFiles) {
                Remove-Item -LiteralPath $deployFile.FullName -Force
            }
        }
    }
    else {
        foreach ($deployFile in $deployFiles) {
            $configSource = Get-Content -Raw $deployFile.FullName
            $sourceMatch = [regex]::Match($configSource, 'SourceFolder\s*=\s*"([^"]+)"')
            if ($sourceMatch.Success -and -not $sites.Contains($sourceMatch.Groups[1].Value)) {
                $sites.Add($sourceMatch.Groups[1].Value)
            }
            if ($configSource -notmatch '(?m)^\s*Cname\s*=') {
                if ($DryRun) {
                    Write-Note "Add an empty Cname field to $($deployFile.Name)."
                }
                else {
                    $configSource = [regex]::Replace(
                        $configSource,
                        '(?m)^(\s*TokenName\s*=.*)$',
                        '$1' + "`n        Cname = `"`"",
                        1
                    )
                    Write-Utf8NoBom $deployFile.FullName $configSource
                }
            }
        }
    }

    $extras = Read-Default "Orc companion projects: reactor,preview,tools (comma-separated; use none for none)" "reactor,preview,tools"
    if (Test-Selection $extras "reactor") {
        $reactor = Read-Default "Reactor clone path" (Join-Path $ProjectsRoot "reactor")
        Use-Repository "reactor" $reactor
        Invoke-In $reactor cargo build --release
    }
    if (Test-Selection $extras "preview") {
        $preview = Read-Default "Preview clone path" (Join-Path $ProjectsRoot "preview")
        Use-Repository "preview" $preview
        Invoke-In $preview cargo build --release
    }
    if (Test-Selection $extras "tools") {
        $tools = Read-Default "Tools clone path" (Join-Path $ProjectsRoot "tools")
        Use-Repository "tools" $tools
    }

    if (Confirm-Choice "Do you have existing site files to import into Orc?" $false) {
        if (-not $tools) {
            $tools = Read-Default "Tools clone path (required for safe import)" (Join-Path $ProjectsRoot "tools")
            Use-Repository "tools" $tools
        }
        $importCountText = Read-Default "How many existing sites or individual HTML files?" "1"
        $importCount = 0
        if (-not [int]::TryParse($importCountText, [ref]$importCount) -or $importCount -lt 1) {
            throw "Import count must be a positive integer."
        }
        for ($importIndex = 1; $importIndex -le $importCount; $importIndex++) {
            Write-Section "Import $importIndex of $importCount"
            $inputPath = Read-Default "Existing site folder or individual HTML file" ""
            if (-not $DryRun -and -not (Test-Path -LiteralPath $inputPath)) {
                throw "Import path does not exist: $inputPath"
            }
            $detected = if ($DryRun -and -not (Test-Path -LiteralPath $inputPath)) {
                "app"
            } else {
                Get-SiteImportProfile $inputPath
            }
            Write-Note "Detected wraps.txt profile: $detected"
            $profile = (Read-Default "wraps.txt profile: app, blog, docs, pages, prov, vite" $detected).ToLowerInvariant()
            if ($profile -notin @("app", "blog", "docs", "pages", "prov", "vite")) {
                throw "Unknown import profile: $profile"
            }
            $suggestedSlug = if ($inputPath) {
                [IO.Path]::GetFileNameWithoutExtension($inputPath.TrimEnd('\', '/'))
            } else { "import$importIndex" }
            $slug = (Read-Default "Orc destination folder slug" $suggestedSlug).ToLowerInvariant()
            if ($slug -notmatch "^[a-z0-9][a-z0-9_-]*$") {
                throw "Use lowercase letters, digits, underscore, or dash for folder slugs."
            }
            $targetRepo = Read-Default "GitHub Pages target repository name" $slug
            $cname = Read-Default "CNAME (blank for github.io default)" ""
            $destination = Join-Path $orcDir $slug
            Invoke-OrcSiteImport $inputPath $destination $profile $generatorProject $tools
            if (-not $sites.Contains($slug)) { $sites.Add($slug) }
            New-DeployConfig $orcDir $slug $targetRepo $cname
            if (Confirm-Choice "Rename generated F# modules from Tools/modulefix proposals?" $true) {
                Rename-OrcModules $orcDir $destination $tools
            }
        }
    }

    $defaultCount = if ($script:InstallMode -eq "configure") { "0" } else { "1" }
    $countText = Read-Default "How many new site folders should be added?" $defaultCount
    $count = 0
    if (-not [int]::TryParse($countText, [ref]$count) -or $count -lt 0) {
        throw "Site count must be zero or a positive integer."
    }
    for ($i = 1; $i -le $count; $i++) {
        Write-Section "Site $i of $count"
        $slug = (Read-Default "Folder slug" "site$i").ToLowerInvariant()
        if ($slug -notmatch "^[a-z0-9][a-z0-9_-]*$") {
            throw "Use lowercase letters, digits, underscore, or dash for folder slugs."
        }
        $framework = (Read-Default "Framework: static, zensical, jekyll, vite, netdocs" "static").ToLowerInvariant()
        if ($framework -notin @("static","zensical","jekyll","vite","netdocs")) {
            throw "Unknown framework: $framework"
        }
        $targetRepo = Read-Default "GitHub Pages target repository name" $slug
        $cname = Read-Default "CNAME (blank for github.io default)" ""
        $destination = Join-Path $orcDir $slug
        if (Test-Path $destination) { throw "Site folder already exists: $destination" }
        $scaffold = Join-Path ([IO.Path]::GetTempPath()) ("shel-site-" + [guid]::NewGuid().ToString("N"))
        if (-not $DryRun) { New-Item -ItemType Directory -Force -Path $scaffold | Out-Null }
        $sites.Add($slug)
        $title = $slug.Substring(0,1).ToUpperInvariant() + $slug.Substring(1)
        $siteUrl = if ($cname) { "https://$cname" } else { "" }

        switch ($framework) {
            "static" {
                $staticHtml = @(
                    "<!doctype html>",
                    '<html lang="en">',
                    '<head><meta charset="utf-8"><meta name="viewport" content="width=device-width,initial-scale=1"><title>' + $title + '</title></head>',
                    "<body><main><h1>$title</h1><p>Rendered from Orc's F# source tree.</p></main></body>",
                    "</html>"
                ) -join "`n"
                Write-Utf8NoBom (Join-Path $scaffold "index.html") $staticHtml
            }
            "zensical" {
                Invoke-In $scaffold uv init --bare
                Invoke-In $scaffold uv add --dev zensical
                Invoke-In $scaffold uv run zensical new .
                Write-Note "Zensical initialized with its canonical starter: https://docs.zensical.org"
                Install-Reference "zensicalDocs" "zensical-docs" "the official Zensical documentation (https://github.com/zensical/docs)"
            }
            "jekyll" {
                Ensure-WingetPackage ruby "RubyInstallerTeam.RubyWithDevKit.3.4"
                if (-not (Get-Command jekyll -ErrorAction SilentlyContinue)) {
                    Invoke-Step gem install jekyll bundler
                    Refresh-Path
                }
                Write-Note "Recommended theme: Minima - https://github.com/jekyll/minima"
                if (Confirm-Choice "Use the recommended Minima theme?" $true) {
                    Invoke-In $scaffold jekyll new . --force
                    if (Confirm-Choice "Enable the fuller Minima starter configuration?" $true) {
                        $minimaConfig = @(
                            "title: $title",
                            "description: A site built with Orc and Jekyll.",
                            "url: `"$siteUrl`"",
                            'baseurl: ""',
                            "theme: minima",
                            "show_excerpts: true",
                            'github_username: ""',
                            'twitter_username: ""',
                            "rss: rss",
                            "header_pages:",
                            "  - about.md",
                            "plugins:",
                            "  - jekyll-feed",
                            "  - jekyll-seo-tag",
                            "exclude:",
                            "  - .bundle",
                            "  - vendor"
                        ) -join "`n"
                        Write-Utf8NoBom (Join-Path $scaffold "_config.yml") $minimaConfig
                        if (-not $DryRun -and -not (Test-Path (Join-Path $scaffold "about.md"))) {
                            $aboutPage = @(
                                "---",
                                "layout: page",
                                "title: About",
                                "permalink: /about/",
                                "---",
                                "",
                                "About $title."
                            ) -join "`n"
                            Write-Utf8NoBom (Join-Path $scaffold "about.md") $aboutPage
                        }
                    }
                    Install-Reference "minima" "minima" "the official Minima source and documentation (https://github.com/jekyll/minima)"
                    Install-Reference "vllmMinima" "vllm-minima-blog" "vLLM's archived Minima blog as a populated reference"
                }
                else {
                    Invoke-In $scaffold jekyll new . --blank --force
                }
                Invoke-In $scaffold bundle install
            }
            "vite" {
                $template = Read-Default "Vite template (vanilla-ts, react-ts, vue-ts, etc.)" "vanilla-ts"
                Invoke-In $scaffold bun create vite . --template $template --no-interactive
                Invoke-In $scaffold bun install
                Write-Note "Tailwind uses the current official @tailwindcss/vite plugin flow."
                if (Confirm-Choice "Add Tailwind CSS to this Vite site?" $true) {
                    Enable-ViteTailwind $scaffold
                }
                Install-Reference "openclawSite" "openclaw-site" "OpenClaw's Bun/Astro production site (custom CSS, not a Tailwind template)"
            }
            "netdocs" {
                $netdocsSettings = @(
                    "{",
                    '  "Netdocs": {',
                    "    `"site_name`": `"$title`",",
                    "    `"site_url`": `"$siteUrl`",",
                    '    "docs_dir": "docs",',
                    '    "site_dir": "site"',
                    "  }",
                    "}"
                ) -join "`n"
                Write-Utf8NoBom (Join-Path $scaffold "appsettings.json") $netdocsSettings
                Write-Utf8NoBom (Join-Path $scaffold "docs\index.md") "# $title`n`nBuilt with Netdocs and rendered from Orc's F# source tree.`n"
            }
        }
        Convert-ScaffoldToOrc $generatorProject $scaffold $destination
        if (-not $DryRun -and (Test-Path $scaffold)) { Remove-Item -LiteralPath $scaffold -Recurse -Force }
        New-DeployConfig $orcDir $slug $targetRepo $cname
    }

    if (-not $DryRun) {
        $configPath = Join-Path $orcDir "GenerateConfig.fsx"
        $source = Get-Content -Raw $configPath
        $list = ($sites | ForEach-Object { '"' + $_ + '"' }) -join "; "
        $replacement = "let defaultSiteFolders =`n    [ $list ]"
        $updated = [regex]::Replace($source, 'let defaultSiteFolders =\s*\[[^\]]*\]', $replacement, 1)
        if ($updated -eq $source) { throw "Could not update defaultSiteFolders in GenerateConfig.fsx" }
        Write-Utf8NoBom $configPath $updated
        Invoke-In $orcDir dotnet fsi GenerateConfig.fsx render-workflows .rendered/workflows --clean
    }
    else {
        Write-Note "Generate defaultSiteFolders and deployment configs for: $($sites -join ', ')"
    }

    $ports = if ($sites.Count -gt 0) {
        0..($sites.Count - 1) | ForEach-Object { 4000 + ($_ * 111) }
    } else { @() }
    $portCsv = $ports -join ","
    Write-Note "Required repository secrets: GH_PAGES_TOKEN and SHARPENDABOT_TOKEN."
    Write-Note "Review: $orcDir\.github\config\deploy-*.fs"
    Write-Note "Also review: $orcDir\.github\config\shared\deploy-common.fs"
    Write-Note "Automation entrypoint: $orcDir\.github\workflows\sharpendabot.yml"
    if ($portCsv) {
        Write-Note "Preview ports: $portCsv"
        if (Test-Selection $extras "preview") {
            Write-Note "Preview: $preview\target\release\orc-preview.exe --repo `"$orcDir`" --output `"$ProjectsRoot\orc-preview`" --ports `"$portCsv`""
        }
    }
    else {
        Write-Note "No deployment sites are configured yet."
    }
    if (-not $DryRun -and (Test-Path $generatorWork)) {
        Remove-Item -LiteralPath $generatorWork -Recurse -Force
    }
}

if (Test-Selection $kits "2") {
    Write-Host @"

Libraries (choose one or more, comma-separated):
  1  Regedited - Rust-backed registry/text tooling
  2  Macrohard - Windows desktop automation
  3  Sandwich - Bun-only JavaScript compatibility layer in WSL
"@
    $libraries = Read-Default "Library choices" "1,2,3"
    if (Test-Selection $libraries "1") {
        Ensure-WingetPackage cargo "Rustlang.Rustup"
        $regedited = Read-Default "Regedited clone path" (Join-Path $ProjectsRoot "regedited")
        Use-Repository "regedited" $regedited
        Invoke-In $regedited cargo build --release
        Invoke-In $regedited powershell -ExecutionPolicy Bypass -File .\scripts\pathadd.ps1
    }
    if (Test-Selection $libraries "2") {
        Ensure-WingetPackage cmake "Kitware.CMake"
        Ensure-WingetPackage bun "Oven-sh.Bun"
        $macrohard = Read-Default "Macrohard clone path" (Join-Path $ProjectsRoot "macrohard")
        Use-Repository "macrohard" $macrohard
        $qtPath = Read-Default "Qt 6.9.3 kit path (for example C:\Qt\6.9.3\mingw_64)" ""
        if ($qtPath) {
            Write-Note "Macrohard's canonical installer may request elevation for its service and firewall rule."
            Invoke-In $macrohard powershell -ExecutionPolicy Bypass -File .\install.ps1 -QtPath $qtPath
        }
        else {
            Write-Note "Macrohard cloned but not built. Install Qt 6.9.3, then run .\install.ps1 -QtPath <kit>."
        }
    }
    if (Test-Selection $libraries "3") {
        Ensure-Wsl
        $linuxRoot = Read-Default "WSL projects directory" "~/Projects"
        $sandwichPath = Read-Default "Sandwich clone path in WSL" "$linuxRoot/sandwich"
        $bootstrap = @'
if ! command -v curl >/dev/null || ! command -v git >/dev/null; then
  sudo apt-get update
  sudo apt-get install -y git curl ca-certificates
fi
bash ./install.sh
export PATH="$HOME/.local/bin:$HOME/.bun/bin:$PATH"
command -v sandwich >/dev/null && sandwich doctor
'@
        Install-WslRepository "sandwich" $sandwichPath $bootstrap
    }
}

Write-Section "Complete"
Write-Note "Open a new PowerShell window so newly installed PATH entries are active."
Write-Note "Projects: $ProjectsRoot"
"""

let render() = file
