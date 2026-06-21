module Config.Workflows.DeployCommon

type SiteDeploy = {
    WorkflowName: string
    SourceFolder: string
    TargetRepo: string
    TargetBranch: string
    TokenName: string
}

let render (site: SiteDeploy) =
    sprintf """# ================= Improved State Mechanics ================= #
# State guideline -->  site.WorkflowName        // 1
# State guideline -->  site.SourceFolder        // 2
# State guideline -->  site.SourceFolder        // 3
# State guideline -->  site.SourceFolder        // 4  (bool2 check)
# State guideline -->  site.SourceFolder        // 5  (bool3 check)
# State guideline -->  site.SourceFolder        // 6  (bool4 check)
# State guideline -->  site.SourceFolder        // 7  (bool5 check)
# State guideline -->  site.SourceFolder        // 8  (rm output)
# State guideline -->  site.SourceFolder        // 9  (.deploy)
# State guideline -->  site.SourceFolder        // 10 (render-site src)
# State guideline -->  site.SourceFolder        // 11 (output dir)
# State guideline -->  site.SourceFolder        // 12 (cd output)
# State guideline -->  site.TargetRepo          // 13
# State guideline -->  site.TargetBranch        // 14
# State guideline -->  site.TokenName           // 15
# State guideline -->  site.SourceFolder        // 16 (deploy msg)
# State guideline -->  site.SourceFolder        // 17 (cleanup output)
# State guideline -->  site.SourceFolder        // 18 (.deploy cleanup)
# State guideline -->  site.SourceFolder        // 19 (create bool2 path)
# State guideline -->  site.SourceFolder        // 20 (git add bool2)
# State guideline -->  site.SourceFolder        // 21 (disable-actions hashFiles)
# State guideline -->  site.TokenName           // 22 (disable-actions checkout token)
# State guideline -->  site.TokenName           // 23 (disable-actions API token)
# State guideline -->  site.SourceFolder        // 24 (rm bool2)
# State guideline -->  site.SourceFolder        // 25 (git rm bool2)
# State guideline -->  site.SourceFolder        // 26 (create bool3)
# State guideline -->  site.SourceFolder        // 27 (git add bool3)
# State guideline -->  site.SourceFolder        // 28 (cleanup-branch hashFiles)
# State guideline -->  site.TokenName           // 29 (cleanup-branch checkout token)
# State guideline -->  site.TargetRepo          // 30
# State guideline -->  site.TargetBranch        // 31
# State guideline -->  site.SourceFolder        // 32 (rm bool3)
# State guideline -->  site.SourceFolder        // 33 (git rm bool3)
# State guideline -->  site.SourceFolder        // 34 (create bool4)
# State guideline -->  site.SourceFolder        // 35 (git add bool4)
# State guideline -->  site.SourceFolder        // 36 (enable-actions hashFiles)
# State guideline -->  site.TokenName           // 37 (enable-actions checkout token)
# State guideline -->  site.TokenName           // 38 (enable-actions API token)
# State guideline -->  site.SourceFolder        // 39 (rm bool4)
# State guideline -->  site.SourceFolder        // 40 (git rm bool4)
# State guideline -->  site.SourceFolder        // 41 (create bool5)
# State guideline -->  site.SourceFolder        // 42 (git add bool5)
# State guideline -->  site.SourceFolder        // 43 (finalize hashFiles)
# State guideline -->  site.TokenName           // 44 (finalize checkout token)
# State guideline -->  site.SourceFolder        // 45 (rm bool5)
# State guideline -->  site.SourceFolder        // 46 (git rm bool5)

name: %s

on:
  push:
    branches: [ main ]
    paths:
      - '%s/**'
      - '.github/config/deploy-*.fs'
      - '.github/config/shared/deploy-common.fs'
      - 'GenerateConfig.fsx'
  workflow_dispatch:

permissions:
  contents: write

concurrency:
  group: "deploy-%s"
  cancel-in-progress: false

jobs:
  build-and-deploy:
    runs-on: ubuntu-latest
    if: ${{ hashFiles('%s/bool2') == '' && hashFiles('%s/bool3') == '' && hashFiles('%s/bool4') == '' && hashFiles('%s/bool5') == '' }}
    steps:
      - uses: actions/checkout@v6

      - uses: actions/setup-dotnet@v5
        with:
          dotnet-version: '10.0.x'

      - uses: actions/setup-python@v6
        with:
          python-version: '3.x'

      - uses: astral-sh/setup-uv@v6

      - uses: oven-sh/setup-bun@v2

      - uses: ruby/setup-ruby@v1
        with:
          ruby-version: '3.4'
          bundler-cache: false

      - name: Render F# source tree to output
        timeout-minutes: 10
        run: |
          rm -rf "%s/output" ".deploy/%s"
          dotnet fsi GenerateConfig.fsx render-site "%s" "%s/output" --clean

      - name: Detect and build site
        timeout-minutes: 15
        shell: bash
        run: |
          set -euo pipefail
          cd "%s/output"

          if [ -f "zensical.toml" ]; then
            echo "Detected Zensical site"
            uv venv --python 3.12.10 --seed --managed-python
            source .venv/bin/activate
            uv pip install zensical
            zensical build
            deactivate
            rm -rf .venv
            rm -rf .cache
            publish="$PWD/site"
          elif [ -f "Gemfile" ]; then
            echo "Detected Jekyll site"
            bundle install
            bundle exec jekyll build --disable-disk-cache
            rm -rf Gemfile.lock
            publish="$PWD/_site"
          elif [ -f "package.json" ]; then
            echo "Detected JavaScript package site"
            bun install
            bun run build
            rm -rf node_modules
            rm -rf bun.lock
            publish="$PWD/dist"
          else
            echo "Detected static push site"
            publish="$PWD"
          fi

          test -d "$publish"
          echo "PUBLISH_DIR=$publish" >> "$GITHUB_ENV"
          echo "SOURCE_OUTPUT=$PWD" >> "$GITHUB_ENV"

      - name: Scrub generated source-only files
        shell: bash
        run: |
          set -euo pipefail
          find "$PUBLISH_DIR" \( -name '*.fs' -o -name '*.fsx' -o -name '.gitignore' -o -name '.gitattributes' -o -name '.nojekyll' -o -name 'CNAME' \) -delete

      - name: Deploy to target repo
        env:
          GH_PAGES_TOKEN: ${{ secrets.GH_PAGES_TOKEN }}
          GITHUB_TOKEN: ${{ secrets.GITHUB_TOKEN }}
        shell: bash
        run: |
          set -euo pipefail
          OWNER="${{ github.repository_owner }}"
          REPO="%s"
          BRANCH="%s"
          TOKEN="${%s:-${GITHUB_TOKEN}}"
          REMOTE_URL="https://x-access-token:${TOKEN}@github.com/${OWNER}/${REPO}.git"

          cd "$PUBLISH_DIR"
          preserve_dir="$(mktemp -d)"
          if git clone --depth 1 --branch "${BRANCH}" "${REMOTE_URL}" "${preserve_dir}/target" 2>/dev/null; then
            if [ -f "${preserve_dir}/target/CNAME" ]; then
              cp "${preserve_dir}/target/CNAME" CNAME
              echo "Preserved existing target CNAME"
            fi
          else
            echo "No existing target branch to preserve"
          fi
          rm -rf "$preserve_dir"

          git init
          git config user.name "github-actions[bot]"
          git config user.email "github-actions[bot]@users.noreply.github.com"
          git remote add target "${REMOTE_URL}" 2>/dev/null || \
            git remote set-url target "${REMOTE_URL}"
          git add .
          git commit -m "Deploy %s [skip ci]" || echo "No changes"
          git push target HEAD:"${BRANCH}" --force

      - name: Cleanup rendered output
        if: always()
        shell: bash
        run: |
          rm -rf "%s/output" ".deploy/%s"

      - name: Create bool2 (advance to phase 2)
        shell: bash
        run: |
          set -euo pipefail
          TIMESTAMP=$(date -u +"%%Y-%%m-%%dT%%H:%%M:%%SZ")
          COMMIT=$(git rev-parse --short HEAD || echo "unknown")
          cat > "%s/bool2" <<EOF
          # DeployCommon State File
          # Created: $TIMESTAMP
          # Commit: $COMMIT
          # Phase: 2 (disable actions)
          EOF
          git config user.name "github-actions[bot]"
          git config user.email "github-actions[bot]@users.noreply.github.com"
          git add "%s/bool2"
          git commit -m "Create bool2 state file" || true
          git push || true

  disable-actions:
    runs-on: ubuntu-latest
    if: ${{ hashFiles('%s/bool2') != '' }}
    steps:
      - uses: actions/checkout@v6
        with:
          token: ${{ secrets.%s }}
          fetch-depth: 0

      - name: Disable GitHub Actions
        env:
          TOKEN: ${{ secrets.%s }}
        run: |
          curl -X PUT \
            -H "Authorization: token $TOKEN" \
            -H "Accept: application/vnd.github+json" \
            https://api.github.com/repos/${{ github.repository }}/actions/permissions \
            -d '{"enabled": false}'

      - name: Advance state bool2 -> bool3
        shell: bash
        run: |
          set -euo pipefail
          rm -f "%s/bool2" || true
          git rm "%s/bool2" 2>/dev/null || true
          TIMESTAMP=$(date -u +"%%Y-%%m-%%dT%%H:%%M:%%SZ")
          COMMIT=$(git rev-parse --short HEAD || echo "unknown")
          cat > "%s/bool3" <<EOF
          # DeployCommon State File
          # Created: $TIMESTAMP
          # Commit: $COMMIT
          # Phase: 3 (cleanup branch)
          EOF
          git config user.name "github-actions[bot]"
          git config user.email "github-actions[bot]@users.noreply.github.com"
          git add "%s/bool3"
          git commit -m "Advance state to bool3" || true
          git push || true

  cleanup-branch:
    runs-on: ubuntu-latest
    if: ${{ hashFiles('%s/bool3') != '' }}
    steps:
      - uses: actions/checkout@v6
        with:
          token: ${{ secrets.%s }}
          fetch-depth: 0

      - name: Delete everything except CNAME and LICENSE in target
        env:
          GH_PAGES_TOKEN: ${{ secrets.GH_PAGES_TOKEN }}
        shell: bash
        run: |
          set -euo pipefail
          OWNER="${{ github.repository_owner }}"
          REPO="%s"
          BRANCH="%s"
          TOKEN="${GH_PAGES_TOKEN}"
          REMOTE_URL="https://x-access-token:${TOKEN}@github.com/${OWNER}/${REPO}.git"

          workdir="$(mktemp -d)"
          git clone --depth 1 --branch "${BRANCH}" "${REMOTE_URL}" "${workdir}"
          cd "${workdir}"

          find . -maxdepth 1 ! -name 'CNAME' ! -name 'LICENSE' ! -name '.git' -exec rm -rf {} +
          git add -A
          git commit -m "Phase 3 cleanup: keep only CNAME and LICENSE" || true
          git push origin HEAD:"${BRANCH}" --force

      - name: Advance state bool3 -> bool4
        shell: bash
        run: |
          set -euo pipefail
          rm -f "%s/bool3" || true
          git rm "%s/bool3" 2>/dev/null || true
          TIMESTAMP=$(date -u +"%%Y-%%m-%%dT%%H:%%M:%%SZ")
          COMMIT=$(git rev-parse --short HEAD || echo "unknown")
          cat > "%s/bool4" <<EOF
          # DeployCommon State File
          # Created: $TIMESTAMP
          # Commit: $COMMIT
          # Phase: 4 (enable actions)
          EOF
          git config user.name "github-actions[bot]"
          git config user.email "github-actions[bot]@users.noreply.github.com"
          git add "%s/bool4"
          git commit -m "Advance state to bool4" || true
          git push || true

  enable-actions:
    runs-on: ubuntu-latest
    if: ${{ hashFiles('%s/bool4') != '' }}
    steps:
      - uses: actions/checkout@v6
        with:
          token: ${{ secrets.%s }}
          fetch-depth: 0

      - name: Re-enable GitHub Actions
        env:
          TOKEN: ${{ secrets.%s }}
        run: |
          curl -X PUT \
            -H "Authorization: token $TOKEN" \
            -H "Accept: application/vnd.github+json" \
            https://api.github.com/repos/${{ github.repository }}/actions/permissions \
            -d '{"enabled": true}'

      - name: Advance state bool4 -> bool5
        shell: bash
        run: |
          set -euo pipefail
          rm -f "%s/bool4" || true
          git rm "%s/bool4" 2>/dev/null || true
          TIMESTAMP=$(date -u +"%%Y-%%m-%%dT%%H:%%M:%%SZ")
          COMMIT=$(git rev-parse --short HEAD || echo "unknown")
          cat > "%s/bool5" <<EOF
          # DeployCommon State File
          # Created: $TIMESTAMP
          # Commit: $COMMIT
          # Phase: 5 (complete)
          EOF
          git config user.name "github-actions[bot]"
          git config user.email "github-actions[bot]@users.noreply.github.com"
          git add "%s/bool5"
          git commit -m "Advance state to bool5 (complete)" || true
          git push || true

  finalize:
    runs-on: ubuntu-latest
    if: ${{ hashFiles('%s/bool5') != '' }}
    steps:
      - uses: actions/checkout@v6
        with:
          token: ${{ secrets.%s }}
          fetch-depth: 0

      - name: Finalize - remove bool5 (reset state machine)
        shell: bash
        run: |
          set -euo pipefail
          rm -f "%s/bool5" || true
          git rm "%s/bool5" 2>/dev/null || true
          git config user.name "github-actions[bot]"
          git config user.email "github-actions[bot]@users.noreply.github.com"
          git commit -m "Finalize: reset state machine [skip ci]" || true
          git push || true
"""
        site.WorkflowName
        site.SourceFolder
        site.SourceFolder
        site.SourceFolder
        site.SourceFolder
        site.SourceFolder
        site.SourceFolder
        site.SourceFolder
        site.SourceFolder
        site.SourceFolder
        site.SourceFolder
        site.SourceFolder
        site.TargetRepo
        site.TargetBranch
        site.TokenName
        site.SourceFolder
        site.SourceFolder
        site.SourceFolder
        site.SourceFolder
        site.SourceFolder
        site.SourceFolder
        site.TokenName
        site.TokenName
        site.SourceFolder
        site.SourceFolder
        site.SourceFolder
        site.SourceFolder
        site.SourceFolder
        site.TokenName
        site.TargetRepo
        site.TargetBranch
        site.SourceFolder
        site.SourceFolder
        site.SourceFolder
        site.SourceFolder
        site.SourceFolder
        site.TokenName
        site.TokenName
        site.SourceFolder
        site.SourceFolder
        site.SourceFolder
        site.SourceFolder
        site.SourceFolder
        site.TokenName
        site.SourceFolder
        site.SourceFolder
