# Diogenes documentation rebuild — handoff ledger

This file records the finished documentation pass and the checks used to verify
it. It sits outside `docs/`, so Zensical does not publish it.

## Working locations

- [x] Editable F# site source: `C:\Users\turtleuser\Documents\Dev\Website Stuff\orc\orc\dio`
- [x] Diogenes reference checkout: `C:\Users\turtleuser\Documents\Dev\linux\Diogenes-Reference`
- [x] Reference revision reviewed: `31d62b59`
- [x] Preview route: `http://127.0.0.1:4003`
- [x] Preview keeps rendered Markdown, CSS, JavaScript, templates, and build output in its temporary worktree.
- [ ] Commit or publish the site. This was left for the user.

## Editorial acceptance

- [x] All published prose was rewritten for Diogenes.
- [x] Pages describe routes, modules, symbols, settings, payloads, files, and commands.
- [x] Configuration and extension guides contain complete snippets rather than summary-only prose.
- [x] Outputs, validation behavior, and recovery steps are included where they apply.
- [x] Unsupported topics were omitted rather than filled with speculative material.
- [x] Comparison copy, attribution pages, citation footers, and topic crosswalks were removed.
- [x] The supplied disallowed-word list returns zero hits across 53 developer-documentation source files. The supplied About essay is preserved as user-provided prose and excluded from that stylistic scan.
- [x] Comparison-name scan returns zero hits across published source.
- [x] F# wrappers remain the editable format for every published page and custom asset.

## Visual system

- [x] Home uses tiny lowercase `diogenes` type and the repository tagline: `bloated with materialism, nihilistic in theory.`
- [x] Home is reduced to install, quickstart, features, and repository entry links.
- [x] Promotional cards, metrics, badges, and announcement copy were removed.
- [x] The exported Three.js candle is centered and visible on every route.
- [x] Automatic rotation is disabled. Pointer rotation and wheel zoom are enabled on Home only.
- [x] Leaving Home resets the camera to its baseline; documentation routes use a static candle and ordinary page scrolling.
- [x] Home text selection is disabled while form fields retain normal text selection.
- [x] The original hardwood table texture is retained.
- [x] The camera uses the closer export-inspired framing. The zoomed-out experiment was rejected.
- [x] Article surfaces remain translucent so the candle is visible without obstructing text.
- [x] Dark documentation styling and restrained orange accents are applied throughout.
- [x] Desktop and narrow-width layouts were inspected in Preview.

## Zensical and Preview

- [x] `zensical.fs` contains the full 47-route navigation tree.
- [x] Instant navigation, search, following TOC, code controls, content tabs, details, admonitions, footnotes, math, and task lists are enabled.
- [x] Mermaid fences render as diagrams.
- [x] Checked-in Three.js is used for the candle runtime.
- [x] `README.md` documents Preview, `wrap-batch`, navigation updates, and verification.
- [x] `sharppy-sync_nav.fs` remains available for interactive navigation maintenance.
- [x] A clean Zensical build completes with `No issues found`.

## Published content map

### Home and getting started

- [x] `/` — `docs/sharpmd-README.fs`
- [x] `/getting-started/` — `docs/getting-started/indexmd.fs`
- [x] `/getting-started/installation/` — `docs/getting-started/sharpmd-installation.fs`
- [x] `/getting-started/quickstart/` — `docs/getting-started/sharpmd-quickstart.fs`
- [x] `/getting-started/first-session/` — `docs/getting-started/sharpmd-first-session.fs`
- [x] `/about/diogenes/` — supplied essay and painting, linked from Home and omitted from the documentation navigation tree

### Configuration

- [x] `/configuration/` — configuration entry points and file map
- [x] `/configuration/settings/` — settings API, environment, persistence, and validation
- [x] `/configuration/models/` — providers, model endpoints, role selection, and local endpoints
- [x] `/configuration/interface/` — interface settings, themes, and keyboard behavior
- [x] `/configuration/security/` — instructions, approvals, authentication, and tool policy

### Workspace

- [x] `/workspace/` — workspace route map
- [x] `/workspace/chat-sessions/` — chat, session storage, forks, resume, export, and deletion
- [x] `/workspace/tools-agents/` — tool calls, approvals, agent runs, and event flow
- [x] `/workspace/memory-rag/` — memories, skills, retrieval, and mutation
- [x] `/workspace/documents/` — document APIs, editor state, versioning, and conversion
- [x] `/workspace/productivity/` — email, notes, tasks, and calendar payloads
- [x] `/workspace/media/` — gallery, uploads, image requests, STT, TTS, and voice

### Deep Research

- [x] `/research/` — research entry points and stored run data
- [x] `/research/modes/` — request schema, mode selection, rounds, progress, and cancellation
- [x] `/research/sources/` — report records, source handling, HTML generation, and download
- [x] `/research/arxiv/` — arXiv report stages, math, diagrams, and export
- [x] `/research/narrative/` — fiction and nonfiction project stages
- [x] `/research/recovery/` — reconnect, incomplete runs, export, and diagnostics

### Operations

- [x] `/operations/` — operator route map
- [x] `/operations/services/` — service discovery, start, stop, restart, status, and logs
- [x] `/operations/venvs-shell/` — configured environments and browser terminal sessions
- [x] `/operations/engines/` — cookbook jobs and native engine execution
- [x] `/operations/runtime-topology/` — backend, frontend, data, worker, and queue paths
- [x] `/operations/deployment/` — launch, health checks, backup, verify, and restore

### Extending

- [x] `/extending/` — extension entry-point map
- [x] `/extending/skills/` — skill schema, registration, frontmatter, and reload
- [x] `/extending/mcp-tools/` — MCP registration and a complete custom-tool example
- [x] `/extending/api-cli/` — tokens, synchronous chat API, CLI, webhooks, and companion routes
- [x] `/extending/integrations/` — integrations, hooks, services, and frontend registration

### Guides

- [x] `/guides/workflows/` — steering, plan/edit/test flow, review, and commits
- [x] `/guides/multi-agent/` — agents, jobs, queues, automation, and interruption
- [x] `/guides/troubleshooting/` — logs, health routes, stream failures, storage, and recovery

### Architecture

- [x] `/architecture/` — repository and component map
- [x] `/architecture/backend/` — FastAPI startup, middleware, routing, sessions, streams, and tools
- [x] `/architecture/frontend/` — SPA modules, stores, requests, streams, editor, and tests
- [x] `/architecture/data-security/` — persistence, atomic writes, auth, untrusted input, and test paths

### Reference and development

- [x] `/reference/cli/` — launchers and CLI command tables
- [x] `/reference/configuration/` — settings catalog and ranges
- [x] `/reference/storage/` — data directory and record layouts
- [x] `/reference/feature-matrix/` — implementation coverage by interface
- [x] `/reference/glossary/` — chat stream event names and payloads
- [x] `/about/contributing/` — development setup, source map, tests, and contribution flow

## Corrections verified against the Diogenes checkout

- [x] Backup examples use `scripts/odysseus-backup snapshot`, `list`, `verify`, and `restore` with their supported switches.
- [x] Restore documentation notes the external `ODYSSEUS_DATA_DIR` limitation.
- [x] CLI option tables match the launchers and argument parsers.
- [x] Webhook creation uses multipart `FormData` and supported event names.
- [x] Skill creation uses the `SkillAddRequest` fields and supported frontmatter.
- [x] Planned-job execution sends both the planned job and confirmation token.
- [x] Calendar examples use `summary`, `dtstart`, `dtend`, and `calendar_href`.
- [x] Session examples use `/api/session` and `/api/sessions` as implemented.
- [x] Host-shell creation handles the returned `sessions` collection.
- [x] `POST /api/v1/chat` is documented as a synchronous `message` request with `ody_` bearer-token scope and session continuation.
- [x] Source references use concrete repository paths and symbol names.

## Final verification record

- [x] Clean Zensical build: 48 content pages, 49 generated HTML files including `404.html`.
- [x] HTTP route pass: 48 checked, 0 failures.
- [x] Local link pass: 4,977 references checked, 0 missing targets.
- [x] Anchor pass: 1,827 anchors checked, 0 missing anchors.
- [x] Search index generated: `search.json`.
- [x] Concrete path-and-symbol pass: 35 references checked, 0 misses.
- [x] Method-and-route pass: 248 references checked, 0 unmatched implemented routes.
- [x] Published Markdown inventory: 48 pages and 23,923 words.
- [x] Developer-documentation scan: 53 files, 0 disallowed-word hits, 0 comparison-name hits. The supplied About essay is not rewritten by this scan.
- [x] About article body matches the supplied Markdown byte-for-byte after newline normalization; the checked-in image matches the supplied image SHA-256.
- [x] Source whitespace scan returns 0 trailing-whitespace hits.
- [x] Source directory contains no `site`, `.cache`, or `__pycache__` build directories.
- [x] Home, article, Mermaid, tabs, code copy, navigation, and narrow-width states were inspected in Preview.

## Remaining handoff action

- [ ] Review the untracked `dio/` directory in the parent repository, then commit and publish it when ready.
- [ ] Leave the unrelated parent entry `.github/config/deploy-dio.fs` untouched unless it is intentionally included later.
