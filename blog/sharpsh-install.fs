module Bl0g.InstallSh

let file = """#!/usr/bin/env bash
set -Eeuo pipefail

MANIFEST_URL="${SHEL_INSTALL_MANIFEST_URL:-https://shel.sh/install-manifest.json}"
AI_INSTALL_URL="${SHEL_AI_INSTALL_URL:-https://shel.sh/install-ai.sh}"
PROJECTS_ROOT="${SHEL_PROJECTS_ROOT:-$HOME/Projects}"
TRACKS=""
DRY_RUN=0
ASSUME_YES=0

usage() {
  cat <<'USAGE'
sHEL workstation installer

Usage:
  install.sh [--track site,libraries,ai] [--root PATH]
             [--manifest PATH_OR_URL] [--dry-run] [--yes]

Tracks:
  site       Orc, Reactor, Preview, Tools, and their build prerequisites
  libraries Regedited, Macrohard guidance, and Sandwich
  ai         The dedicated Linux/WSL AI stack from install-ai.sh

With no --track, one short menu selects the work to perform. Existing Git
worktrees are fast-forwarded only; local work is never reset or replaced.
USAGE
}

while (($#)); do
  case "$1" in
    --track) shift; TRACKS="${1:?--track requires a value}" ;;
    --root) shift; PROJECTS_ROOT="${1:?--root requires a path}" ;;
    --manifest) shift; MANIFEST_URL="${1:?--manifest requires a path or URL}" ;;
    --dry-run) DRY_RUN=1 ;;
    --yes|-y) ASSUME_YES=1 ;;
    --help|-h) usage; exit 0 ;;
    *) printf 'Unknown option: %s\n' "$1" >&2; usage >&2; exit 2 ;;
  esac
  shift
done

[[ "$(uname -s)" == Linux ]] || {
  printf 'Use https://shel.sh/install.ps1 on Windows.\n' >&2
  exit 1
}

say() { printf '\n\033[1;35m%s\033[0m\n' "$*"; }
note() { printf '  %s\n' "$*"; }
die() { printf 'sHEL installer: %s\n' "$*" >&2; exit 1; }
quote_cmd() { printf '%q ' "$@"; }
run() {
  if ((DRY_RUN)); then printf '  + '; quote_cmd "$@"; printf '\n'; else "$@"; fi
}
run_in() {
  local directory="$1"; shift
  if ((DRY_RUN)); then
    printf '  + (cd %q && ' "$directory"; quote_cmd "$@"; printf ')\n'
  else
    (cd "$directory" && "$@")
  fi
}
selected() { [[ ",${1// /}," == *",$2,"* ]]; }
prompt_tracks() {
  ((ASSUME_YES)) && { printf 'site,libraries,ai'; return; }
  [[ -r /dev/tty && -w /dev/tty ]] || die "Pass --track when running non-interactively."
  cat >/dev/tty <<'MENU'

Choose one or more tracks:
  1  Site tools
  2  Libraries
  3  AI workstation
MENU
  local answer
  printf 'Selection [1,2,3]: ' >/dev/tty
  IFS= read -r answer </dev/tty
  answer="${answer:-1,2,3}"
  answer="${answer//1/site}"
  answer="${answer//2/libraries}"
  answer="${answer//3/ai}"
  printf '%s' "$answer"
}

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
  run "${SUDO[@]}" apt-get update
  run "${SUDO[@]}" apt-get install -y "${missing[@]}"
}
ensure_uv() {
  command -v uv >/dev/null 2>&1 && return
  if ((DRY_RUN)); then note "Install uv from https://astral.sh/uv/install.sh"; else
    curl -LsSf https://astral.sh/uv/install.sh | sh
    export PATH="$HOME/.local/bin:$HOME/.cargo/bin:$PATH"
  fi
}
ensure_bun() {
  command -v bun >/dev/null 2>&1 && return
  if ((DRY_RUN)); then note "Install Bun from https://bun.sh/install"; else
    curl -fsSL https://bun.sh/install | bash
    export BUN_INSTALL="$HOME/.bun" PATH="$HOME/.bun/bin:$PATH"
  fi
}
ensure_rust() {
  command -v cargo >/dev/null 2>&1 && return
  if ((DRY_RUN)); then note "Install Rust from https://sh.rustup.rs"; else
    curl --proto '=https' --tlsv1.2 -sSf https://sh.rustup.rs | sh -s -- -y
    # shellcheck disable=SC1091
    source "$HOME/.cargo/env"
  fi
}
ensure_dotnet() {
  command -v dotnet >/dev/null 2>&1 && return
  if ((DRY_RUN)); then
    note "Install .NET SDK 10 from Microsoft's ${ID}/${VERSION_ID} repository."
  else
    local feed="$TMP_ROOT/packages-microsoft-prod.deb"
    curl -fsSL "https://packages.microsoft.com/config/${ID}/${VERSION_ID}/packages-microsoft-prod.deb" -o "$feed"
    "${SUDO[@]}" dpkg -i "$feed"
    "${SUDO[@]}" apt-get update
    "${SUDO[@]}" apt-get install -y dotnet-sdk-10.0
  fi
}
ensure_pwsh() {
  command -v pwsh >/dev/null 2>&1 && return
  ensure_dotnet
  if ((DRY_RUN)); then
    note "Install PowerShell from Microsoft's ${ID}/${VERSION_ID} repository."
  else
    "${SUDO[@]}" apt-get install -y powershell
  fi
}

TMP_ROOT="$(mktemp -d)"
trap 'rm -rf -- "$TMP_ROOT"' EXIT
MANIFEST_FILE="$TMP_ROOT/install-manifest.json"
fetch_manifest() {
  if [[ -f "$MANIFEST_URL" ]]; then cp -- "$MANIFEST_URL" "$MANIFEST_FILE"; else
    curl -fsSL "$MANIFEST_URL" -o "$MANIFEST_FILE"
  fi
  python3 - "$MANIFEST_FILE" <<'PY' || die "Unsupported installer manifest."
import json, sys
with open(sys.argv[1], encoding="utf-8") as stream:
    value = json.load(stream)
assert value.get("schema") == 1 and isinstance(value.get("repositories"), dict)
PY
}
repo_value() {
  python3 - "$MANIFEST_FILE" "$1" "$2" <<'PY'
import json, sys
with open(sys.argv[1], encoding="utf-8") as stream:
    print(json.load(stream)["repositories"][sys.argv[2]][sys.argv[3]])
PY
}
repo_remote() {
  local destination="$1" expected="$2" remote actual
  expected="${expected%/}"; expected="${expected%.git}"
  while IFS= read -r remote; do
    actual="$(git -C "$destination" remote get-url "$remote" 2>/dev/null || true)"
    actual="${actual%/}"; actual="${actual%.git}"
    if [[ "${actual,,}" == "${expected,,}" ]]; then
      printf '%s' "$remote"
      return 0
    fi
  done < <(git -C "$destination" remote)
  return 1
}
sync_repo() {
  local key="$1" destination="$2" url branch remote
  url="$(repo_value "$key" url)"; branch="$(repo_value "$key" branch)"
  if [[ -d "$destination/.git" ]]; then
    remote="$(repo_remote "$destination" "$url")" \
      || die "$destination has no remote for $url"
    run_in "$destination" git fetch "$remote" "$branch"
    run_in "$destination" git merge --ff-only "$remote/$branch"
  elif [[ -e "$destination" ]]; then
    die "$destination exists but is not a Git worktree."
  else
    run mkdir -p "$(dirname "$destination")"
    run git clone --branch "$branch" --single-branch "$url" "$destination"
  fi
}

install_site() {
  say "Site tools"
  apt_install build-essential pkg-config libssl-dev python3 ruby-full ruby-dev
  ensure_uv; ensure_bun; ensure_rust; ensure_dotnet; ensure_pwsh
  sync_repo orc "$PROJECTS_ROOT/orc"
  sync_repo reactor "$PROJECTS_ROOT/reactor"
  sync_repo preview "$PROJECTS_ROOT/preview"
  sync_repo tools "$PROJECTS_ROOT/tools"
  run_in "$PROJECTS_ROOT/reactor" cargo build --release
  run_in "$PROJECTS_ROOT/preview" cargo build --release
  note "Orc: $PROJECTS_ROOT/orc"
  note "Render: cd \"$PROJECTS_ROOT/orc\" && dotnet fsi GenerateConfig.fsx render-all .rendered --clean"
  note "Preview GUI: $PROJECTS_ROOT/preview/target/release/orc-preview"
  note "Scaffold Zensical with uvx zensical; Jekyll with bundle; Vite with bun create vite."
}

install_libraries() {
  say "Libraries"
  apt_install build-essential pkg-config libssl-dev
  ensure_bun; ensure_rust
  sync_repo regedited "$PROJECTS_ROOT/regedited"
  sync_repo sandwich "$PROJECTS_ROOT/sandwich"
  run_in "$PROJECTS_ROOT/regedited" cargo build --release
  run_in "$PROJECTS_ROOT/regedited" bash scripts/pathadd.sh
  run_in "$PROJECTS_ROOT/sandwich" bash install.sh
  note "Macrohard is Windows-only. Use install.ps1 with Qt 6.9.3 for that project."
}

install_ai() {
  say "AI workstation"
  local script="$TMP_ROOT/install-ai.sh"
  if [[ -f "${BASH_SOURCE[0]%/*}/install-ai.sh" ]]; then
    script="${BASH_SOURCE[0]%/*}/install-ai.sh"
  else
    curl -fsSL "$AI_INSTALL_URL" -o "$script"
  fi
  local args=(--manifest "$MANIFEST_URL")
  ((DRY_RUN)) && args+=(--dry-run)
  ((ASSUME_YES)) && args+=(--yes)
  # The delegated installer receives --dry-run itself, so execute it in both modes.
  bash "$script" "${args[@]}"
}

say "sHEL workstation installer"
[[ -r /etc/os-release ]] || die "A Debian/Ubuntu-family Linux or WSL environment is required."
# shellcheck disable=SC1091
source /etc/os-release
[[ "${ID:-} ${ID_LIKE:-}" == *debian* || "${ID:-}" == ubuntu ]] \
  || die "Automatic packages currently support Debian/Ubuntu-family systems only."
apt_install git curl ca-certificates python3
fetch_manifest
run mkdir -p "$PROJECTS_ROOT"
TRACKS="${TRACKS:-$(prompt_tracks)}"
for track in ${TRACKS//,/ }; do
  [[ "$track" == site || "$track" == libraries || "$track" == ai ]] \
    || die "Unknown track: $track"
done
selected "$TRACKS" site && install_site
selected "$TRACKS" libraries && install_libraries
selected "$TRACKS" ai && install_ai

say "Complete"
note "Projects: $PROJECTS_ROOT"
note "Every start command is printed by the selected track; no model is launched."
"""

let render() = file
