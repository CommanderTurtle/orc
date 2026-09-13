module Bl0g.Posts.N20260726RetrievalMd

let file = """---
layout: post
title: "retrieval: The Skill Labrador"
author: "CommanderTurtle"
date: 2026-07-26 04:00:00 +0000
tags: [project, tooling, ai-agents, skills, python, mcp]
---

**retrieval** keeps large specialist libraries out of both Hermes' and OMP's always-on skill inventories without making them hard to use. It builds one compact descriptor per skill, combines semantic ranking with an [IWE](https://iwe.md/) Markdown graph, and delegates the final choice to a short-lived, read-only OMP scout. The selected `SKILL.md` comes back verbatim in the same MCP response, so the calling agent can use it immediately. Each harness copies the complete package only into its own manifest-owned projection lane — a copy that survives context compaction and becomes natively discoverable after `/reload-skills` in Hermes or `/reload` in OMP. Human CLI cleanup removes a selected ephemeral copy without touching its canonical repository.

## What It Owns

One intentionally narrow responsibility: dormant knowledge discovery. Skills carry an explicit state — `native` skills already live in a harness-visible tree (their names suppress cold duplicates, but they are neither graphed nor embedded as candidates); `hidden` skills are installed OMP skills whose frontmatter deliberately omits them from prompt metadata, made semantically discoverable here; `cold` skills remain only in external repositories until selected; `archived` skills stay discoverable but dormant, with Hermes owning their lifecycle through `hermes curator`. The generated IWE catalog and Chroma collections are disposable indexes, and the projection manifest owns every temporary copy it is allowed to remove.

The non-ownership is stated just as explicitly. Context Mode owns its context database. Hermes and OMP own sessions, compaction, active skill discovery, and tool history. Librarian owns delegated synthesis and editable knowledge. `codebase-memory-mcp` owns repository graphs. Those sources can still be indexed through the administrative compatibility CLI, but they are disabled in the recommended configuration and are not exposed as Retrieval MCP tools.

## The Selection Flow

Six steps, fail-closed at the last one. Chroma ranks one short descriptor per hidden, cold, or archived skill semantically. IWE performs fuzzy title and BM25 search over the same skills and exposes controlled source/category graph links. Reciprocal-rank fusion produces a bounded candidate list. An ephemeral OMP RPC process then searches and reads the candidates using exactly two host-owned, read-only tools — native tools, MCPs, skills, rules, extensions, sessions, LSP, PTY, and the advisor are disabled in its isolated profile, and its HOME and XDG roots are private, so OMP's cross-harness capability discovery cannot import Zed, Claude, or other user MCP configs. The scout may select at most one skill, and it must first discover and inspect the selected ID; otherwise Retrieval fails closed. Finally, the canonical `SKILL.md` is returned verbatim: hidden skills already installed in the calling harness are not duplicated, every other selected package is projected atomically only into that harness's lane, symlinks are skipped, and file and byte limits are enforced.

## The Catalog and the Taxonomy

The IWE tree is derived from configured sources under `~/.local/share/retrieval/catalog`: readable skill cards plus a deliberately small category taxonomy, not another canonical library. IWE supplies fast structural and fuzzy graph navigation and has no built-in AI, and it stays an external local Rust CLI rather than a Python dependency — three deliberately distinct paths: the maintainable source at `~/Hermes/iwe`, the installed executable at `~/.cargo/bin/iwe`, and the generated graph. Retrieval uses only `iwe find`, `iwe retrieve`, and `iwe init`; it never invokes IWE write actions and never updates IWE automatically.

Categorization is conservative by rule. `taxonomy.toml` is the committed, stable vocabulary — existing IDs do not change as new libraries arrive. A skill may declare `retrieval_categories` in its frontmatter, `category-overrides.toml` is the ignored, human-owned assignment layer for upstream repositories that should remain untouched, and keyword matches may assign only categories already present in the taxonomy. A skill with no approved category enters the review queue and is excluded from both IWE and Chroma. In the README's words: Retrieval never invents a category automatically. The persistent watcher follows the intake root recursively, so a new or edited `SKILL.md` is categorized, reduced to its descriptor, and synchronized without polling on searches — no separate source entry or MCP restart needed.

## The Commit Arc

Twenty-six commits between July 26 and August 6, 2026, all mine. The July 26 burst — twenty commits — builds the whole service in a day: a source-aware Hermes retrieval service that follows Diogenes' embedding configuration, a model kept warm across MCP calls, complete skill instruction bundles loaded on demand, ordered session history preserved and reconstructed, opt-in agent workflows routed without activation, a bounded knowledge-routing skill, safe indexing of explicitly installed symlinked skills, deduplication of skills shared across sources and of same-named variants, and the public uv-native release with its LICENSE. July 27 keeps the inotify indexing self-healing. Then the August 5–6 refinement: refactoring retrieval into an IWE-backed skill scout, persistent skill intake with taxonomy review, the completed dual-harness catalog and appliance, and keeping the scout's compaction local.

## Why It Matters Here

This session runs on it: the dormant specialist skills that surface mid-conversation come from this exact flow — one descriptor, one scout, one verbatim `SKILL.md`. A specialist library stops costing prompt tokens on every turn the moment it lives behind a scouted boundary instead of inside the system prompt. [diogenes](/blog/2026-07-25-diogenes/) provides the embedding configuration it follows; [Librarian](/blog/2026-07-26-librarian/) owns the knowledge the retrieved skills act on. Different layers, one stack.

[github.com/CommanderTurtle/retrieval](https://github.com/CommanderTurtle/retrieval) · [iwe.md](https://iwe.md/)

---

#### xkcd of the day, 7/26 - Recursive Trucker's Hitch #3276

![xkcd of the day](https://imgs.xkcd.com/comics/recursive_truckers_hitch_2x.png)

[[grokipedia - dead sea scrolls]](https://grokipedia.com/page/Dead_Sea_Scrolls)

"""

let render() = file
