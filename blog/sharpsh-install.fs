module ConvertedFiles.InstallSh

let file = """#!/usr/bin/env bash
set -Eeuo pipefail

MANIFEST_URL="${SHEL_INSTALL_MANIFEST_URL:-https://shel.sh/install-manifest.json}"
PROJECTS_ROOT="${SHEL_PROJECTS_ROOT:-$HOME/Projects}"
DRY_RUN=0
ASSUME_YES=0
MANIFEST_FILE=""

usage() {
  cat <<'USAGE'
sHEL workstation installer

Usage:
  install.sh [--dry-run] [--yes] [--root PATH] [--manifest PATH_OR_URL]

The interactive installer can install a new clone or configure an existing one.
It provides three independent tracks:
  Site Building; Libraries; AI (Diogenes on Linux/WSL).

--dry-run   Print planned commands without changing the machine.
--yes       Accept package-manager confirmation prompts (questions remain).
--root      Parent directory for cloned projects (default: ~/Projects).
--manifest  Override the shared installer manifest.
USAGE
}

while (($#)); do
  case "$1" in
    --dry-run) DRY_RUN=1 ;;
    --yes|-y) ASSUME_YES=1 ;;
    --root) shift; PROJECTS_ROOT="${1:?--root requires a path}" ;;
    --manifest) shift; MANIFEST_URL="${1:?--manifest requires a path or URL}" ;;
    --help|-h) usage; exit 0 ;;
    *) printf 'Unknown option: %s\n' "$1" >&2; usage >&2; exit 2 ;;
  esac
  shift
done

if [[ -r /dev/tty && -w /dev/tty ]]; then
  TTY=/dev/tty
elif [[ -t 0 ]]; then
  TTY=/dev/stdin
else
  printf 'This installer is interactive. Run it from a terminal.\n' >&2
  exit 1
fi

say() { printf '\n\033[1;35m%s\033[0m\n' "$*"; }
note() { printf '  %s\n' "$*"; }
die() { printf 'sHEL installer: %s\n' "$*" >&2; exit 1; }
quote_cmd() { printf '%q ' "$@"; }
run() {
  if ((DRY_RUN)); then
    printf '  + '; quote_cmd "$@"; printf '\n'
  else
    "$@"
  fi
}
run_in() {
  local directory="$1"; shift
  if ((DRY_RUN)); then
    printf '  + (cd %q && ' "$directory"; quote_cmd "$@"; printf ')\n'
  else
    (cd "$directory" && "$@")
  fi
}
prompt() {
  local label="$1" default="${2-}" answer
  if [[ -n "$default" ]]; then
    printf '%s [%s]: ' "$label" "$default" >"$TTY"
  else
    printf '%s: ' "$label" >"$TTY"
  fi
  IFS= read -r answer <"$TTY"
  printf '%s' "${answer:-$default}"
}
confirm() {
  local label="$1" default="${2:-y}" answer suffix
  [[ "$default" == y ]] && suffix='Y/n' || suffix='y/N'
  answer="$(prompt "$label ($suffix)" "$default")"
  [[ "${answer,,}" == y || "${answer,,}" == yes ]]
}
selected() {
  local csv=",$1," needle="$2"
  [[ "${csv// /}" == *",$needle,"* ]]
}

[[ -r /etc/os-release ]] || die "Debian or Ubuntu is required."
# shellcheck disable=SC1091
source /etc/os-release
case "${ID:-}:${ID_LIKE:-}" in
  debian:*|ubuntu:*|*:*\ debian\ *) ;;
  *) die "Unsupported distribution '${PRETTY_NAME:-unknown}'. Use Debian or Ubuntu." ;;
esac

SUDO=()
if ((EUID != 0)); then
  command -v sudo >/dev/null 2>&1 || die "sudo is required for system packages."
  SUDO=(sudo)
fi

apt_install() {
  local missing=() package
  for package in "$@"; do
    dpkg-query -W -f='${Status}' "$package" 2>/dev/null | grep -q 'install ok installed' || missing+=("$package")
  done
  ((${#missing[@]})) || return 0
  say "System packages"
  note "Installing: ${missing[*]}"
  if ((DRY_RUN)); then
    local dry_flags=()
    ((ASSUME_YES)) && dry_flags=(-y)
    run "${SUDO[@]}" apt-get update
    run "${SUDO[@]}" apt-get install "${dry_flags[@]}" "${missing[@]}"
  else
    "${SUDO[@]}" apt-get update
    local flags=()
    ((ASSUME_YES)) && flags=(-y)
    "${SUDO[@]}" apt-get install "${flags[@]}" "${missing[@]}"
  fi
}

fetch_manifest() {
  MANIFEST_FILE="$(mktemp)"
  trap 'rm -f "${MANIFEST_FILE:-}"' EXIT
  if [[ -f "$MANIFEST_URL" ]]; then
    cp "$MANIFEST_URL" "$MANIFEST_FILE"
  else
    command -v curl >/dev/null 2>&1 || apt_install curl ca-certificates
    curl -fsSL "$MANIFEST_URL" -o "$MANIFEST_FILE"
  fi
}
repo_value() {
  jq -er --arg key "$1" --arg field "$2" '.repositories[$key][$field]' "$MANIFEST_FILE"
}
clone_or_update() {
  local key="$1" destination="$2" url branch
  url="$(repo_value "$key" url)"
  branch="$(repo_value "$key" branch)"
  if [[ -d "$destination/.git" ]]; then
    note "Updating $key in $destination"
    run_in "$destination" git fetch origin "$branch"
    run_in "$destination" git merge --ff-only "origin/$branch"
  elif [[ -e "$destination" ]]; then
    die "$destination exists but is not a Git worktree."
  else
    run git clone --branch "$branch" --single-branch "$url" "$destination"
  fi
}
prepare_repository() {
  local key="$1" destination="$2"
  if [[ "$INSTALL_MODE" == configure ]]; then
    if [[ ! -d "$destination/.git" ]]; then
      if confirm "No $key clone was found at $destination. Install it now?" y; then
        clone_or_update "$key" "$destination"
        return
      fi
      die "Configure requires an existing Git clone: $destination"
    fi
    if confirm "Fetch and fast-forward $key before configuring it?" y; then
      clone_or_update "$key" "$destination"
    else
      note "Using the existing $key worktree without changing its revision."
    fi
  else
    clone_or_update "$key" "$destination"
  fi
}
install_reference() {
  local key="$1" slug="$2" label="$3"
  local destination="$REFERENCES_ROOT/$slug"
  if confirm "Clone or update $label in the separate references folder?" n; then
    run mkdir -p "$REFERENCES_ROOT"
    clone_or_update "$key" "$destination"
    note "Reference: $destination"
  fi
}
ensure_uv() {
  command -v uv >/dev/null 2>&1 && return
  say "uv"
  if ((DRY_RUN)); then
    note "Install uv with Astral's official installer."
  else
    curl -LsSf https://astral.sh/uv/install.sh | sh
    export PATH="$HOME/.local/bin:$HOME/.cargo/bin:$PATH"
    command -v uv >/dev/null 2>&1 || die "uv installed but is not on PATH; reopen the shell and rerun."
  fi
}
ensure_rust() {
  command -v cargo >/dev/null 2>&1 && return
  say "Rust"
  if ((DRY_RUN)); then
    note "Install Rust with rustup."
  else
    curl --proto '=https' --tlsv1.2 -sSf https://sh.rustup.rs | sh -s -- -y
    # shellcheck disable=SC1091
    source "$HOME/.cargo/env"
  fi
}
ensure_bun() {
  command -v bun >/dev/null 2>&1 && return
  say "Bun"
  if ((DRY_RUN)); then
    note "Install Bun with its official installer."
  else
    curl -fsSL https://bun.sh/install | bash
    export BUN_INSTALL="$HOME/.bun"
    export PATH="$BUN_INSTALL/bin:$PATH"
  fi
}
ensure_zed() {
  command -v zed >/dev/null 2>&1 && return
  say "Zed"
  if ((DRY_RUN)); then
    note "Install Zed with its official Linux installer: https://zed.dev/docs/linux"
  else
    curl -f https://zed.dev/install.sh | sh
    export PATH="$HOME/.local/bin:$PATH"
  fi
}
ensure_dotnet() {
  command -v dotnet >/dev/null 2>&1 && return
  say ".NET SDK"
  if ((DRY_RUN)); then
    note "Install the current .NET SDK from Microsoft's Debian repository."
    return
  fi
  local deb="/tmp/packages-microsoft-prod.deb"
  curl -fsSL "https://packages.microsoft.com/config/${ID}/${VERSION_ID}/packages-microsoft-prod.deb" -o "$deb"
  "${SUDO[@]}" dpkg -i "$deb"
  rm -f "$deb"
  "${SUDO[@]}" apt-get update
  "${SUDO[@]}" apt-get install -y dotnet-sdk-10.0
}
ensure_pwsh() {
  command -v pwsh >/dev/null 2>&1 && return
  ensure_dotnet
  if ((DRY_RUN)); then
    note "Install PowerShell from Microsoft's Debian repository."
  else
    "${SUDO[@]}" apt-get install -y powershell
  fi
}

say "sHEL workstation installer"
note "Debian/Ubuntu detected: ${PRETTY_NAME}"
note "Projects directory: $PROJECTS_ROOT"
note "No GPU driver, Docker daemon, account, token, or secret is modified automatically."

apt_install git curl ca-certificates jq
fetch_manifest
mkdir_args=(-p "$PROJECTS_ROOT")
run mkdir "${mkdir_args[@]}"
REFERENCES_ROOT="$PROJECTS_ROOT/references"

cat >"$TTY" <<'MODE'

Would you like to:
  1  Install — create new clones and initialize selected frameworks
  2  Configure — work with existing clones without replacing their files
MODE
mode_choice="$(prompt 'Choose a mode' '1')"
case "$mode_choice" in
  1|install) INSTALL_MODE=install ;;
  2|configure) INSTALL_MODE=configure ;;
  *) die "Choose Install (1) or Configure (2)." ;;
esac

say "Recommended workstation tools"
for recommended in zed bun uv; do
  if command -v "$recommended" >/dev/null 2>&1; then
    note "$recommended: detected at $(command -v "$recommended")"
  else
    note "$recommended: not detected"
  fi
done
note "Zed is the recommended editor; Bun and uv are the JavaScript and Python authorities used by this suite."
if confirm "Install any missing recommended tools now?" y; then
  ensure_zed
  ensure_bun
  ensure_uv
fi

cat >"$TTY" <<'MENU'

Which parts would you like to work with?
  1  Site Building — Orc, site frameworks, Reactor, Preview, and Tools
  2  Libraries — Regedited, Macrohard, and/or Sandwich
  3  AI — Diogenes local workstation (Linux/WSL, optional GPU)
MENU
kits="$(prompt 'Choose one or more numbers, comma-separated' '1,2,3')"

if selected "$kits" 3; then
  say "Diogenes"
  apt_install build-essential pkg-config libssl-dev python3-dev tmux docker.io docker-compose
  ensure_uv
  diogenes_dir="$(prompt 'Diogenes clone path' "$PROJECTS_ROOT/diogenes")"
  prepare_repository diogenes "$diogenes_dir"

  if command -v nvidia-smi >/dev/null 2>&1; then
    note "NVIDIA GPU detected. CUDA availability will be checked by Diogenes."
    [[ -x "$diogenes_dir/scripts/check-docker-gpu.sh" ]] && run_in "$diogenes_dir" bash scripts/check-docker-gpu.sh
  elif command -v rocm-smi >/dev/null 2>&1 || [[ -e /dev/kfd ]]; then
    note "AMD GPU detected. ROCm availability will be checked by Diogenes."
    [[ -x "$diogenes_dir/scripts/check-docker-amd-gpu.sh" ]] && run_in "$diogenes_dir" bash scripts/check-docker-amd-gpu.sh
  else
    note "No CUDA/ROCm runtime was detected. Diogenes can run CPU services, but local model serving benefits greatly from a supported GPU."
  fi

  if confirm "Create Diogenes' Python 3.13.12 environment now?" y; then
    run_in "$diogenes_dir" bash ./uvsetup.sh
  else
    note "Later: cd \"$diogenes_dir\" && ./uvsetup.sh"
  fi
  note "Start later with: cd \"$diogenes_dir\" && ./startwithuv.sh"
  note "Optional MCPs, model engines, and services are installed from Diogenes' own GUI."
fi

generate_site_config() {
  local slug="$1" target_repo="$2" cname="$3" config_dir="$4"
  local module_slug
  module_slug="$(printf '%s' "$slug" | tr -cs '[:alnum:]' '_' | sed -E 's/(^|_)([a-z])/\U\2/g')"
  cat >"$config_dir/deploy-$slug.fs" <<EOF
module Config.Workflows.Deploy${module_slug}

let render() =
    Config.Workflows.DeployCommon.render {
        WorkflowName = "Deploy ${slug^}"
        SourceFolder = "$slug"
        TargetRepo = "$target_repo"
        TargetBranch = "main"
        TokenName = "GH_PAGES_TOKEN"
        Cname = "$cname"
    }
EOF
}

wrap_scaffold() {
  local generator_project="$1" scaffold="$2" destination="$3"
  run mkdir -p "$destination"
  run dotnet run --project "$generator_project" -- wrap-site "$scaffold" "$destination"
}
enable_vite_tailwind() {
  local scaffold="$1"
  run_in "$scaffold" bun add --dev tailwindcss @tailwindcss/vite
  if ((DRY_RUN)); then
    note "Register @tailwindcss/vite in Vite config and import Tailwind from the primary stylesheet."
    return
  fi
  python3 - "$scaffold" <<'PY'
import pathlib, re, sys

root = pathlib.Path(sys.argv[1])
configs = [p for name in ("vite.config.ts", "vite.config.js", "vite.config.mts", "vite.config.mjs")
           if (p := root / name).exists()]
if not configs:
    config = root / "vite.config.ts"
    text = '''import { defineConfig } from 'vite'
import tailwindcss from '@tailwindcss/vite'

export default defineConfig({
  plugins: [tailwindcss()],
})
'''
else:
    config = configs[0]
    text = config.read_text(encoding="utf-8")
    if "@tailwindcss/vite" not in text:
        text = "import tailwindcss from '@tailwindcss/vite'\n" + text
    if "tailwindcss()" not in text:
        text, count = re.subn(r"plugins\s*:\s*\[", "plugins: [tailwindcss(), ", text, count=1)
        if count != 1:
            raise SystemExit(f"Could not locate plugins array in {config.name}")
config.write_text(text, encoding="utf-8")

styles = [p for name in ("src/index.css", "src/style.css", "src/app.css", "style.css")
          if (p := root / name).exists()]
if not styles:
    style = root / "src" / "style.css"
    style.parent.mkdir(parents=True, exist_ok=True)
    style.write_text('@import "tailwindcss";\n', encoding="utf-8")
else:
    style = styles[0]
    css = style.read_text(encoding="utf-8")
    if '@import "tailwindcss";' not in css:
        style.write_text('@import "tailwindcss";\n' + css, encoding="utf-8")
PY
}
detect_import_profile() {
  local input="$1" leaf package current parent_leaf
  if [[ -f "$input" ]]; then
    current="$(dirname "$input")"
    while [[ "$current" != "/" && -n "$current" ]]; do
      parent_leaf="$(basename "$current")"
      case "$parent_leaf" in app|blog|docs|pages|prov|vite) printf '%s' "$parent_leaf"; return ;; esac
      [[ "$(dirname "$current")" == "$current" ]] && break
      current="$(dirname "$current")"
    done
    printf 'app'
    return
  fi
  leaf="$(basename "$input")"
  case "$leaf" in app|blog|docs|pages|prov|vite) printf '%s' "$leaf"; return ;; esac
  [[ -f "$input/zensical.toml" ]] && { printf 'docs'; return; }
  [[ -d "$input/captcha" ]] && { printf 'pages'; return; }
  [[ -f "$input/Gemfile" || -f "$input/_config.yml" ]] && { printf 'blog'; return; }
  package="$input/package.json"
  [[ -f "$package" ]] && grep -qE '"vite"[[:space:]]*:' "$package" && { printf 'vite'; return; }
  printf 'app'
}
rename_generated_files() {
  local root="$1" old="$2" new="$3" file renamed
  while IFS= read -r -d '' file; do
    renamed="${file//$old/$new}"
    [[ "$renamed" == "$file" ]] || mv -- "$file" "$renamed"
  done < <(find "$root" -type f -name "*${old}*" -print0)
}
move_generated_indexes() {
  local root="$1" file parent target
  while IFS= read -r -d '' file; do
    parent="$(dirname "$(dirname "$file")")"
    target="$parent/index.fs"
    [[ ! -e "$target" ]] || die "Index normalization would overwrite $target"
    mv -- "$file" "$target"
    rmdir -- "$(dirname "$file")"
  done < <(find "$root" -type f -path '*/index/index.fs' -print0)
}
import_orc_site() {
  local input="$1" destination="$2" profile="$3" generator_project="$4" tools_dir="$5"
  if ((DRY_RUN)); then
    note "Stage $input, apply convert-comments.ps1, run wrap-batch with the '$profile' rules from .github/wraps.txt, and write $destination."
    return
  fi
  [[ ! -e "$destination" ]] || die "Import destination already exists: $destination"
  local work source output captcha
  work="$(mktemp -d)"
  source="$work/source"
  output="$work/output"
  mkdir -p "$source" "$output"
  if [[ -f "$input" ]]; then
    cp -- "$input" "$source/$(basename "$input")"
  else
    tar -C "$input" \
      --exclude=.git --exclude=.github --exclude=.venv --exclude=.cache \
      --exclude=.bundle --exclude=.jekyll-cache --exclude=bin --exclude=obj \
      --exclude=node_modules --exclude=site --exclude=_site --exclude=dist \
      --exclude=public --exclude=output -cf - . | tar -C "$source" -xf -
  fi

  [[ -f "$tools_dir/convert-comments.ps1" ]] || die "Missing comment migration tool: $tools_dir/convert-comments.ps1"
  run pwsh -NoProfile -File "$tools_dir/convert-comments.ps1" -Path "$source" -Apply

  case "$profile" in
    blog|docs)
      while IFS= read -r -d '' file; do mv -- "$file" "${file%.*}.raw"; done < <(find "$source" -type f -iname '*.html' -print0)
      ;;
    pages)
      captcha="$source/captcha"
      if [[ -d "$captcha" ]]; then
        while IFS= read -r -d '' file; do mv -- "$file" "${file%.*}.raw"; done < <(find "$captcha" -mindepth 2 -type f -iname '*.html' -print0)
      fi
      ;;
  esac

  run dotnet run --project "$generator_project" -- wrap-batch "$source" "$output"
  case "$profile" in
    app|prov) move_generated_indexes "$output" ;;
    vite)
      move_generated_indexes "$output"
      rename_generated_files "$output" sharpmd-index indexmd
      ;;
    blog|docs)
      rename_generated_files "$output" sharpraw sharphtml
      rename_generated_files "$output" sharpmd-index indexmd
      [[ "$profile" == docs ]] && rename_generated_files "$output" sharpoml-zensical zensical
      ;;
    pages)
      captcha="$output/captcha"
      if [[ -d "$captcha" ]]; then
        rename_generated_files "$captcha" sharpraw sharphtml
        rename_generated_files "$captcha" sharphtml-index index
        move_generated_indexes "$captcha"
      fi
      rename_generated_files "$output" sharpmd-index indexmd
      ;;
  esac
  mkdir -p "$destination"
  cp -a "$output/." "$destination/"
  rm -rf -- "$work"
}
rename_orc_modules() {
  local repo_root="$1" check_directory="$2" tools_dir="$3"
  if ((DRY_RUN)); then
    note "Audit and apply collision-free module names from Tools/modulefix.ps1."
    return
  fi
  [[ -f "$tools_dir/modulefix.ps1" ]] || die "Missing module naming tool: $tools_dir/modulefix.ps1"
  python3 - "$repo_root" "$check_directory" "$tools_dir/modulefix.ps1" <<'PY'
import json, pathlib, re, subprocess, sys

repo, check, tool = map(pathlib.Path, sys.argv[1:])
result = subprocess.run(
    ["pwsh", "-NoProfile", "-File", str(tool), "-RepoRoot", str(repo),
     "-CheckDirectory", str(check), "-Format", "Json"],
    check=True, capture_output=True, text=True,
)
plan = json.loads(result.stdout)
# Duplicate generic names in the imported files are why this pass exists.
# Abort only when two proposed names would still collide.
blocked = [row for row in plan["Files"] if row["Status"] == "ProposalCollision"]
if blocked:
    for row in blocked:
        print(f"{row['File']}: {row['Status']} ({row['Current']} -> {row['Suggested']})", file=sys.stderr)
    raise SystemExit("Module names were not changed because modulefix reported a collision.")

for row in plan["Files"]:
    if row["Status"] == "Aligned":
        continue
    path = check / row["File"]
    source = path.read_text(encoding="utf-8-sig")
    updated = source
    current, suggested, declaration = row["Current"], row["Suggested"], row["Declaration"]
    if declaration == "module" and current:
        updated, count = re.subn(
            rf"^(\s*module\s+(?:rec\s+)?){re.escape(current)}(\s*)$",
            rf"\g<1>{suggested}\g<2>", source, count=1, flags=re.MULTILINE,
        )
    elif declaration == "namespace" and current:
        updated, count = re.subn(
            rf"^(\s*namespace\s+){re.escape(current)}(\s*)$",
            rf"\g<1>{suggested}\g<2>", source, count=1, flags=re.MULTILINE,
        )
    elif declaration == "missing":
        updated, count = f"module {suggested}\n\n{source}", 1
    else:
        print(f"Review manually: {row['File']} ({declaration}).")
        continue
    if count != 1 or updated == source:
        raise SystemExit(f"Could not apply modulefix proposal to {row['File']}")
    path.write_text(updated, encoding="utf-8", newline="")
    print(f"{row['File']}: {current} -> {suggested}")
PY
}

if selected "$kits" 1; then
  say "Orc site workspace"
  apt_install build-essential pkg-config libssl-dev python3 ruby-full ruby-dev
  ensure_dotnet
  ensure_rust
  ensure_uv
  ensure_bun
  ensure_pwsh

  orc_dir="$(prompt 'Orc clone path' "$PROJECTS_ROOT/orc")"
  orc_was_new=0
  [[ -d "$orc_dir/.git" ]] || orc_was_new=1
  prepare_repository orc "$orc_dir"

  # The template branch stays sparse; the deployment/rendering authority can be
  # overlaid from main. Existing worktrees are never overlaid without confirmation.
  refresh_overlay=1
  if [[ "$INSTALL_MODE" == configure ]] && ! confirm "Refresh Orc's renderer and deployment authority from main?" y; then
    refresh_overlay=0
  fi
  if ((refresh_overlay && !DRY_RUN)); then
    overlay_branch="$(repo_value orc overlayBranch)"
    git -C "$orc_dir" fetch origin "$overlay_branch:refs/remotes/origin/$overlay_branch"
    git -C "$orc_dir" show "origin/$overlay_branch:GenerateConfig.fsx" >"$orc_dir/GenerateConfig.fsx"
    mkdir -p "$orc_dir/.github/config/shared"
    git -C "$orc_dir" show "origin/$overlay_branch:.github/config/shared/deploy-common.fs" >"$orc_dir/.github/config/shared/deploy-common.fs"
    git -C "$orc_dir" show "origin/$overlay_branch:src/generator/Program.fs" >"$orc_dir/src/generator/Program.fs"
  elif ((refresh_overlay)); then
    note "Overlay the renderer, importer, and deployment authority from Orc main."
  else
    note "Preserving the existing Orc renderer and deployment files."
  fi

  generator_work="$(mktemp -d)"
  generator_project="$generator_work/src/generator"
  if ((DRY_RUN)); then
    note "Compile Orc's site importer from a disposable copy so tracked bin/obj files stay clean."
  else
    cp -a "$orc_dir/src" "$generator_work/src"
  fi

  sites=()
  if ((orc_was_new)); then
    # The clonable branch carries examples; a newly initialized tree should contain
    # only the sites selected in this questionnaire.
    if ((!DRY_RUN)); then
      find "$orc_dir/.github/config" -maxdepth 1 -type f -name 'deploy-*.fs' -delete
    else
      note "Remove Orc's sample deployment records before generating the selected sites."
    fi
  else
    while IFS= read -r existing_site; do
      [[ -n "$existing_site" ]] && sites+=("$existing_site")
    done < <(sed -nE 's/^[[:space:]]*SourceFolder[[:space:]]*=[[:space:]]*"([^"]+)".*/\1/p' "$orc_dir"/.github/config/deploy-*.fs 2>/dev/null | sort -u)

    for config_file in "$orc_dir"/.github/config/deploy-*.fs; do
      [[ -f "$config_file" ]] || continue
      if ! grep -qE '^[[:space:]]*Cname[[:space:]]*=' "$config_file"; then
        if ((!DRY_RUN)); then
          sed -i '/TokenName[[:space:]]*=/a\        Cname = ""' "$config_file"
        else
          note "Add an empty Cname field to $(basename "$config_file")."
        fi
      fi
    done
  fi

  extras="$(prompt 'Orc companion projects: reactor,preview,tools (comma-separated; use none for none)' 'reactor,preview,tools')"
  if [[ ",${extras// /}," == *,reactor,* ]]; then
    ensure_rust
    reactor_dir="$(prompt 'Reactor clone path' "$PROJECTS_ROOT/reactor")"
    prepare_repository reactor "$reactor_dir"
    run_in "$reactor_dir" cargo build --release
  fi
  if [[ ",${extras// /}," == *,preview,* ]]; then
    ensure_rust; ensure_pwsh; ensure_dotnet; ensure_uv; ensure_bun
    preview_dir="$(prompt 'Preview clone path' "$PROJECTS_ROOT/preview")"
    prepare_repository preview "$preview_dir"
    run_in "$preview_dir" cargo build --release
  fi
  if [[ ",${extras// /}," == *,tools,* ]]; then
    tools_dir="$(prompt 'Tools clone path' "$PROJECTS_ROOT/tools")"
    prepare_repository tools "$tools_dir"
  fi

  if confirm "Do you have existing site files to import into Orc?" n; then
    if [[ -z "${tools_dir:-}" ]]; then
      tools_dir="$(prompt 'Tools clone path (required for safe import)' "$PROJECTS_ROOT/tools")"
      prepare_repository tools "$tools_dir"
    fi
    import_count="$(prompt 'How many existing sites or individual HTML files?' '1')"
    [[ "$import_count" =~ ^[1-9][0-9]*$ ]] || die "Import count must be a positive integer."
    for ((import_index=1; import_index<=import_count; import_index++)); do
      say "Import $import_index of $import_count"
      input_path="$(prompt 'Existing site folder or individual HTML file' '')"
      if ((!DRY_RUN)); then
        [[ -e "$input_path" ]] || die "Import path does not exist: $input_path"
        detected_profile="$(detect_import_profile "$input_path")"
      else
        detected_profile=app
      fi
      note "Detected wraps.txt profile: $detected_profile"
      profile="$(prompt 'wraps.txt profile: app, blog, docs, pages, prov, vite' "$detected_profile")"
      case "$profile" in app|blog|docs|pages|prov|vite) ;; *) die "Unknown import profile: $profile" ;; esac
      suggested_slug="$(basename "${input_path%/}")"
      suggested_slug="${suggested_slug%.*}"
      [[ -n "$suggested_slug" ]] || suggested_slug="import$import_index"
      slug="$(prompt 'Orc destination folder slug' "$suggested_slug")"
      [[ "$slug" =~ ^[a-z0-9][a-z0-9_-]*$ ]] || die "Use lowercase letters, digits, underscore, or dash for folder slugs."
      target_repo="$(prompt 'GitHub Pages target repository name' "$slug")"
      cname="$(prompt 'CNAME (blank for github.io default)' '')"
      destination="$orc_dir/$slug"
      import_orc_site "$input_path" "$destination" "$profile" "$generator_project" "$tools_dir"
      sites+=("$slug")
      generate_site_config "$slug" "$target_repo" "$cname" "$orc_dir/.github/config"
      if confirm "Rename generated F# modules from Tools/modulefix proposals?" y; then
        rename_orc_modules "$orc_dir" "$destination" "$tools_dir"
      fi
    done
  fi

  default_count=1
  [[ "$INSTALL_MODE" == configure ]] && default_count=0
  count="$(prompt 'How many new site folders should be added?' "$default_count")"
  [[ "$count" =~ ^[0-9]+$ ]] || die "Site count must be zero or a positive integer."
  for ((i=1; i<=count; i++)); do
    say "Site $i of $count"
    slug="$(prompt 'Folder slug' "site$i")"
    [[ "$slug" =~ ^[a-z0-9][a-z0-9_-]*$ ]] || die "Use lowercase letters, digits, underscore, or dash for folder slugs."
    framework="$(prompt 'Framework: static, zensical, jekyll, vite, netdocs' 'static')"
    case "$framework" in static|zensical|jekyll|vite|netdocs) ;; *) die "Unknown framework: $framework" ;; esac
    target_repo="$(prompt 'GitHub Pages target repository name' "$slug")"
    cname="$(prompt 'CNAME (blank for github.io default)' '')"
    destination="$orc_dir/$slug"
    [[ ! -e "$destination" ]] || die "Site folder already exists: $destination"
    scaffold="$(mktemp -d)"
    sites+=("$slug")

    case "$framework" in
      static)
        cat >"$scaffold/index.html" <<EOF
<!doctype html>
<html lang="en">
<head><meta charset="utf-8"><meta name="viewport" content="width=device-width,initial-scale=1"><title>${slug^}</title></head>
<body><main><h1>${slug^}</h1><p>Rendered from Orc's F# source tree.</p></main></body>
</html>
EOF
        ;;
      zensical)
        run_in "$scaffold" uv init --bare
        run_in "$scaffold" uv add --dev zensical
        run_in "$scaffold" uv run zensical new .
        note "Zensical initialized with its canonical starter: https://docs.zensical.org"
        install_reference zensicalDocs zensical-docs "the official Zensical documentation (https://github.com/zensical/docs)"
        ;;
      jekyll)
        command -v jekyll >/dev/null 2>&1 || run gem install --user-install jekyll bundler
        user_gem_dir="$(ruby -e 'print Gem.user_dir')"
        export PATH="$user_gem_dir/bin:$PATH"
        note "Recommended theme: Minima — https://github.com/jekyll/minima"
        if confirm "Use the recommended Minima theme?" y; then
          run_in "$scaffold" jekyll new . --force
          if confirm "Enable the fuller Minima starter configuration?" y; then
            if ((DRY_RUN)); then
              note "Write stable Minima configuration with feed, SEO, navigation, excerpts, and social-link examples."
            else
              cat >"$scaffold/_config.yml" <<EOF
title: ${slug^}
description: A site built with Orc and Jekyll.
url: "${cname:+https://$cname}"
baseurl: ""
theme: minima
show_excerpts: true
github_username: ""
twitter_username: ""
rss: rss
header_pages:
  - about.md
plugins:
  - jekyll-feed
  - jekyll-seo-tag
exclude:
  - .bundle
  - vendor
EOF
              [[ -f "$scaffold/about.md" ]] || cat >"$scaffold/about.md" <<EOF
---
layout: page
title: About
permalink: /about/
---

About ${slug^}.
EOF
            fi
          fi
          install_reference minima minima "the official Minima source and documentation (https://github.com/jekyll/minima)"
          install_reference vllmMinima vllm-minima-blog "vLLM's archived Minima blog as a populated reference"
        else
          run_in "$scaffold" jekyll new . --blank --force
        fi
        run_in "$scaffold" bundle install
        ;;
      vite)
        vite_template="$(prompt 'Vite template (vanilla-ts, react-ts, vue-ts, etc.)' 'vanilla-ts')"
        run_in "$scaffold" bun create vite . --template "$vite_template" --no-interactive
        run_in "$scaffold" bun install
        note "Tailwind uses the current official @tailwindcss/vite plugin flow."
        if confirm "Add Tailwind CSS to this Vite site?" y; then
          enable_vite_tailwind "$scaffold"
        fi
        install_reference openclawSite openclaw-site "OpenClaw's Bun/Astro production site (custom CSS, not a Tailwind template)"
        ;;
      netdocs)
        mkdir -p "$scaffold/docs"
        cat >"$scaffold/appsettings.json" <<EOF
{
  "Netdocs": {
    "site_name": "${slug^}",
    "site_url": "${cname:+https://$cname}",
    "docs_dir": "docs",
    "site_dir": "site"
  }
}
EOF
        cat >"$scaffold/docs/index.md" <<EOF
# ${slug^}

Built with Netdocs and rendered from Orc's F# source tree.
EOF
        ;;
    esac

    wrap_scaffold "$generator_project" "$scaffold" "$destination"
    rm -rf "$scaffold"
    generate_site_config "$slug" "$target_repo" "$cname" "$orc_dir/.github/config"
  done

  if ((!DRY_RUN)); then
    python3 - "$orc_dir/GenerateConfig.fsx" "${sites[@]}" <<'PY'
import pathlib, re, sys
path = pathlib.Path(sys.argv[1])
sites = sys.argv[2:]
text = path.read_text(encoding="utf-8")
replacement = "let defaultSiteFolders =\\n    [ " + "; ".join(f'"{site}"' for site in sites) + " ]"
text, count = re.subn(r'let defaultSiteFolders =\\s*\\[[^\\]]*\\]', replacement, text, count=1)
if count != 1:
    raise SystemExit("Could not update defaultSiteFolders in GenerateConfig.fsx")
path.write_text(text, encoding="utf-8")
PY
    dotnet fsi "$orc_dir/GenerateConfig.fsx" render-workflows "$orc_dir/.rendered/workflows" --clean
  else
    note "Generate defaultSiteFolders and deployment configs for: ${sites[*]}"
  fi

  ports=()
  for ((i=0; i<${#sites[@]}; i++)); do ports+=("$((4000 + i*111))"); done
  port_csv="$(IFS=,; echo "${ports[*]-}")"
  note "Required repository secrets: GH_PAGES_TOKEN and SHARPENDABOT_TOKEN."
  note "Review: $orc_dir/.github/config/deploy-*.fs"
  note "Also review: $orc_dir/.github/config/shared/deploy-common.fs"
  note "Automation entrypoint: $orc_dir/.github/workflows/sharpendabot.yml"
  if [[ -n "$port_csv" ]]; then
    note "Preview ports: $port_csv"
    [[ ",${extras// /}," == *,preview,* ]] && note "Preview: \"${preview_dir:-$PROJECTS_ROOT/preview}/target/release/orc-preview\" --repo \"$orc_dir\" --output \"$PROJECTS_ROOT/orc-preview\" --ports \"$port_csv\""
  else
    note "No deployment sites are configured yet."
  fi
  if [[ -n "${generator_work:-}" && -d "$generator_work" ]]; then
    rm -rf -- "$generator_work"
  fi
fi

if selected "$kits" 2; then
  cat >"$TTY" <<'LIBS'

Libraries (choose one or more, comma-separated):
  1  Regedited — Rust-backed registry/text tooling
  2  Macrohard — Windows desktop automation (not available natively on Debian)
  3  Sandwich — Bun-only JavaScript compatibility layer
LIBS
  libraries="$(prompt 'Library choices' '1,3')"

  if selected "$libraries" 1; then
    ensure_rust
    regedited_dir="$(prompt 'Regedited clone path' "$PROJECTS_ROOT/regedited")"
    prepare_repository regedited "$regedited_dir"
    run_in "$regedited_dir" cargo build --release
    run_in "$regedited_dir" bash ./scripts/pathadd.sh
  fi
  if selected "$libraries" 2; then
    note "Macrohard requires Windows 10/11 and Qt 6.9.3. Run the Windows installer for this selection."
  fi
  if selected "$libraries" 3; then
    sandwich_dir="$(prompt 'Sandwich clone path' "$PROJECTS_ROOT/sandwich")"
    prepare_repository sandwich "$sandwich_dir"
    run_in "$sandwich_dir" bash ./install.sh
    if ((!DRY_RUN)); then
      export PATH="$HOME/.local/bin:$HOME/.bun/bin:$PATH"
      command -v sandwich >/dev/null 2>&1 && run sandwich doctor
    fi
  fi
fi

say "Complete"
note "Open a new shell (or source ~/.bashrc) so newly added PATH entries are active."
note "Projects: $PROJECTS_ROOT"
"""

let render() = file
