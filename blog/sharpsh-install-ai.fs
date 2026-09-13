module Bl0g.InstallAiSh

let file = """#!/usr/bin/env bash
set -Eeuo pipefail

MANIFEST_URL="${SHEL_INSTALL_MANIFEST_URL:-https://shel.sh/install-manifest.json}"
DRY_RUN=0
ASSUME_YES=0
SYNC_ONLY=0
SKIP_SYSTEM=0

HERMES_ROOT="${SHEL_HERMES_ROOT:-$HOME/Hermes}"
DEEPSEEK_ROOT="${SHEL_DEEPSEEK_ROOT:-$HOME/Deepseek}"
ODYSSEUS_ROOT="${SHEL_ODYSSEUS_ROOT:-$HOME/Odysseus}"
MM_TOOLS_ROOT="${SHEL_MM_TOOLS_ROOT:-$HOME/multimedia}"

usage() {
  cat <<'USAGE'
sHEL Linux AI workstation installer

Usage:
  install-ai.sh [--dry-run] [--yes] [--sync-only] [--skip-system]
                [--manifest PATH_OR_URL]

This Linux/WSL-only route owns these explicit locations:
  ~/Odysseus/Diogenes       Diogenes
  ~/Odysseus/ninfer/ninfer  NInfer source and Docker image context
  ~/multimedia              mm-tools
  ~/Deepseek/localflame     Firecrawl MCP integration
  ~/Hermes                  harness integrations and local services

The defaults can be changed with SHEL_HERMES_ROOT, SHEL_DEEPSEEK_ROOT,
SHEL_ODYSSEUS_ROOT, and SHEL_MM_TOOLS_ROOT.

--sync-only    Clone or fast-forward source trees, but do not install or integrate.
--skip-system  Do not install apt packages. User-space tools are still checked.
--dry-run      Print mutating commands without running them.
--yes          Accept the single setup confirmation.
USAGE
}

while (($#)); do
  case "$1" in
    --dry-run) DRY_RUN=1 ;;
    --yes|-y) ASSUME_YES=1 ;;
    --sync-only) SYNC_ONLY=1 ;;
    --skip-system) SKIP_SYSTEM=1 ;;
    --manifest) shift; MANIFEST_URL="${1:?--manifest requires a path or URL}" ;;
    --help|-h) usage; exit 0 ;;
    *) printf 'Unknown option: %s\n' "$1" >&2; usage >&2; exit 2 ;;
  esac
  shift
done

[[ "$(uname -s)" == Linux ]] || {
  printf 'install-ai.sh supports Linux and WSL only.\n' >&2
  exit 1
}

say() { printf '\n\033[1;35m%s\033[0m\n' "$*"; }
note() { printf '  %s\n' "$*"; }
die() { printf 'sHEL AI installer: %s\n' "$*" >&2; exit 1; }
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
confirm_setup() {
  ((ASSUME_YES)) && return 0
  [[ -r /dev/tty && -w /dev/tty ]] || die "Run interactively, or pass --yes."
  local answer
  printf 'Continue with this layout? [Y/n]: ' >/dev/tty
  IFS= read -r answer </dev/tty
  [[ -z "$answer" || "${answer,,}" == y || "${answer,,}" == yes ]]
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
  if ((DRY_RUN)); then
    note "Install uv from https://astral.sh/uv/install.sh"
  else
    curl -LsSf https://astral.sh/uv/install.sh | sh
    export PATH="$HOME/.local/bin:$HOME/.cargo/bin:$PATH"
  fi
  ((DRY_RUN)) || command -v uv >/dev/null 2>&1 || die "uv is not on PATH after installation."
}

ensure_bun() {
  command -v bun >/dev/null 2>&1 && return
  if ((DRY_RUN)); then
    note "Install Bun from https://bun.sh/install"
  else
    curl -fsSL https://bun.sh/install | bash
    export BUN_INSTALL="$HOME/.bun"
    export PATH="$BUN_INSTALL/bin:$PATH"
  fi
  ((DRY_RUN)) || command -v bun >/dev/null 2>&1 || die "Bun is not on PATH after installation."
}

TMP_ROOT="$(mktemp -d)"
trap 'rm -rf -- "$TMP_ROOT"' EXIT
MANIFEST_FILE="$TMP_ROOT/install-manifest.json"

fetch_manifest() {
  if [[ -f "$MANIFEST_URL" ]]; then
    cp -- "$MANIFEST_URL" "$MANIFEST_FILE"
  else
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
  expected="${expected%/}"
  expected="${expected%.git}"
  while IFS= read -r remote; do
    actual="$(git -C "$destination" remote get-url "$remote" 2>/dev/null || true)"
    actual="${actual%/}"
    actual="${actual%.git}"
    if [[ "${actual,,}" == "${expected,,}" ]]; then
      printf '%s' "$remote"
      return 0
    fi
  done < <(git -C "$destination" remote)
  return 1
}

sync_repo() {
  local key="$1" destination="$2" url branch remote
  url="$(repo_value "$key" url)"
  branch="$(repo_value "$key" branch)"
  if [[ -d "$destination/.git" ]]; then
    note "Fast-forward $destination"
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

ensure_repo() {
  local key="$1" destination="$2" url branch
  url="$(repo_value "$key" url)"
  branch="$(repo_value "$key" branch)"
  if [[ -d "$destination/.git" ]]; then
    repo_remote "$destination" "$url" >/dev/null \
      || die "$destination has no remote for $url"
    note "Preserve owner-managed checkout $destination"
  elif [[ -e "$destination" ]]; then
    die "$destination exists but is not a Git worktree."
  else
    run mkdir -p "$(dirname "$destination")"
    run git clone --branch "$branch" --single-branch "$url" "$destination"
  fi
}

run_script() {
  local directory="$1" script="$2"; shift 2
  if [[ ! -f "$directory/$script" ]]; then
    if ((DRY_RUN)); then
      printf '  + (cd %q && bash %q ' "$directory" "$script"
      quote_cmd "$@"
      printf ')\n'
      return
    fi
    die "Missing $directory/$script"
  fi
  run_in "$directory" bash "$script" "$@"
}

say "sHEL Linux AI workstation"
note "Hermes projects: $HERMES_ROOT"
note "DeepSeek projects: $DEEPSEEK_ROOT"
note "Diogenes and NInfer: $ODYSSEUS_ROOT"
note "mm-tools: $MM_TOOLS_ROOT"
note "No model is downloaded or launched by this installer."
confirm_setup || { note "Cancelled."; exit 0; }

if ((SKIP_SYSTEM == 0 && SYNC_ONLY == 0)); then
  [[ -r /etc/os-release ]] || die "A Debian/Ubuntu-family Linux environment is required for package setup."
  # shellcheck disable=SC1091
  source /etc/os-release
  [[ "${ID:-} ${ID_LIKE:-}" == *debian* || "${ID:-}" == ubuntu ]] \
    || die "Automatic packages currently support Debian/Ubuntu-family systems only. Use --skip-system elsewhere."
  say "System prerequisites"
  apt_install git curl ca-certificates jq build-essential cmake ninja-build pkg-config \
    libssl-dev python3-dev tmux docker.io docker-compose ffmpeg libgl1 libglib2.0-0
  ensure_uv
  ensure_bun
else
  for command in git curl python3; do command -v "$command" >/dev/null 2>&1 || die "$command is required."; done
fi

fetch_manifest

say "Source trees"
sync_repo sandwich "$HERMES_ROOT/sandwich"
sync_repo diogenes "$ODYSSEUS_ROOT/Diogenes"
sync_repo ninfer "$ODYSSEUS_ROOT/ninfer/ninfer"
sync_repo mmTools "$MM_TOOLS_ROOT"
sync_repo localflame "$DEEPSEEK_ROOT/localflame"
sync_repo camofoxMcp "$HERMES_ROOT/camofox-mcp"
sync_repo camofoxBrowser "$HERMES_ROOT/camofox/camofox-browser"
ensure_repo firecrawl "$HERMES_ROOT/firecrawl/firecrawl"
sync_repo contextMode "$HERMES_ROOT/context-mode"
sync_repo hermesWorkspace "$HERMES_ROOT/hermes-workspace"
sync_repo leetcoder "$HERMES_ROOT/leetcoder"
sync_repo librarian "$HERMES_ROOT/librarian"
sync_repo persephone "$HERMES_ROOT/persephone"
sync_repo retrieval "$HERMES_ROOT/retrieval"
sync_repo codebaseMemory "$HERMES_ROOT/codebase-memory-mcp"

if ((SYNC_ONLY)); then
  say "Sync complete"
  note "No package, harness, integration, model, or service was changed."
  exit 0
fi

say "Harnesses"
run_script "$HERMES_ROOT/sandwich" install.sh
export PATH="$HOME/.local/bin:$HOME/.bun/bin:$HOME/.cargo/bin:$PATH"
if ! command -v omp >/dev/null 2>&1; then
  run bun add --global @oh-my-pi/pi-coding-agent
fi
if ! command -v dsh >/dev/null 2>&1; then
  run bun add --global @deepseek-ai/dsh
fi
if ! command -v hermes >/dev/null 2>&1; then
  if ((DRY_RUN)); then
    note "Install Hermes from https://hermes-agent.nousresearch.com/install.sh"
  else
    curl -fsSL https://hermes-agent.nousresearch.com/install.sh -o "$TMP_ROOT/hermes-install.sh"
    bash "$TMP_ROOT/hermes-install.sh"
    export PATH="$HOME/.local/bin:$PATH"
  fi
fi
if [[ ! -d "$HOME/.bun/install/global/node_modules/firecrawl-cli" ]] ||
   [[ ! -d "$HOME/.bun/install/global/node_modules/@firecrawl/anydoc" ]]; then
  run bun add --global firecrawl-cli @firecrawl/anydoc
fi

say "Diogenes and NInfer"
if [[ ! -x "$ODYSSEUS_ROOT/Diogenes/.venv/bin/python" ]]; then
  run_script "$ODYSSEUS_ROOT/Diogenes" uvsetup.sh
else
  note "Diogenes environment already exists."
fi
if command -v docker >/dev/null 2>&1; then
  if docker info >/dev/null 2>&1; then
    if ! docker image inspect ninfer:local >/dev/null 2>&1; then
      run_in "$ODYSSEUS_ROOT/ninfer/ninfer" docker build -t ninfer:local .
    else
      note "NInfer Docker image already exists."
    fi
  else
    note "Docker is installed but not available to this user. Start Docker, then run:"
    note "  cd \"$ODYSSEUS_ROOT/ninfer/ninfer\" && docker build -t ninfer:local ."
  fi
fi

say "Harness integrations"
run_script "$DEEPSEEK_ROOT/localflame" install.sh --target all
run_script "$HERMES_ROOT/camofox/camofox-browser" integrate.sh
run_script "$HERMES_ROOT/camofox-mcp" integrate.sh
run_script "$HERMES_ROOT/context-mode" integrate.sh
if [[ -f "$HERMES_ROOT/codebase-memory-mcp/install-local.sh" ]]; then
  run_script "$HERMES_ROOT/codebase-memory-mcp" install-local.sh
else
  run_script "$HERMES_ROOT/codebase-memory-mcp" install.sh
fi
if [[ -f "$HERMES_ROOT/codebase-memory-mcp/integrate-local.sh" ]]; then
  run_script "$HERMES_ROOT/codebase-memory-mcp" integrate-local.sh
else
  note "Codebase Memory has no separate integration helper in this checkout."
fi
run_script "$HERMES_ROOT/leetcoder" install.sh
run_script "$HERMES_ROOT/retrieval" setup.sh
run_script "$HERMES_ROOT/persephone" scripts/install.sh
run_script "$HERMES_ROOT/persephone" scripts/integrate.sh
run_script "$HERMES_ROOT/hermes-workspace" install.sh
run_script "$HERMES_ROOT/hermes-workspace" integrate.sh

if [[ -f "$HERMES_ROOT/librarian/.env" ]]; then
  run_script "$HERMES_ROOT/librarian" integrate.sh
else
  note "Librarian needs its one-time model/backend choice:"
  note "  cd \"$HERMES_ROOT/librarian\" && bun run setup"
fi

say "Ready"
cat <<STARTS
Start Diogenes:
  cd "$ODYSSEUS_ROOT/Diogenes" && ./startwithuv.sh

Start the local web stack, then restart the Hermes gateway:
  cd "$HERMES_ROOT/hermes-workspace" && ./start-stack.sh
  hermes gateway restart

Finish the local Firecrawl overlay after the Translate model is available:
  cd "$MM_TOOLS_ROOT/translate" && ./starthttp.sh
  cd "$MM_TOOLS_ROOT/translate/underbelly" && ./integrate.sh --dry-run
  ./integrate.sh && ./integrate.sh --verify

Start or stop Firecrawl from its existing Compose checkout:
  cd "$HERMES_ROOT/firecrawl/firecrawl" && docker compose up -d
  cd "$HERMES_ROOT/firecrawl/firecrawl" && docker compose down

Open Diogenes -> Services -> Venvs to start an mm-tools UI from:
  $MM_TOOLS_ROOT

Build or configure NInfer models from Diogenes -> Services -> Venvs -> NInfer.
NInfer browser clients need --cors in each editable one-line serve command.

Finish optional credential-bearing setup only when needed:
  cd "$HERMES_ROOT/librarian" && bun run setup
  edit ~/.config/persephone/config.json and ~/.config/persephone/.env
  persephone install-service --start
STARTS
"""

let render() = file
