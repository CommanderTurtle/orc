module Bl0g.Posts.N20260901VitalityMd

let file = """---
layout: post
title: "vitality: Giving Source To Projects That Refuse To Have Any"
author: "CommanderTurtle"
date: 2026-09-01 04:00:00 +0000
tags: [project, typescript, vite, tooling, windows, bun]
---

Most scaffolders work backwards from an empty directory: pick a template, install a mountain, hope the result matches what you actually had. Vitality does the opposite. It takes a browser project that *already works* — a built site, a generated bundle, a pile of HTML and ES modules that renders fine in the browser but lives nowhere a real toolchain can reach — and turns it into a conventional, **unbuilt** TypeScript/Vite source project. The README calls it a source giver, and the definition matters: it does not install dependencies, does not run the source, and does not create a `dist/`. You get handed `SOURCE/mywrap` — `index.html`, `src/main.ts`, `src/app/`, a pinned `vite.config.ts`, `tsconfig.json`, `package.json` — and then you run `bun install`, `bun run serve`, `bun run build` yourself, deliberately.

```
vitality give --dir "some\\path\\regex-safe"
```

Two questions at most — public base path, and whether to inline every imported asset (`assetsInlineLimit: Infinity` or leave Vite's default) — and it writes the wrapper. Nothing else happens until you decide it should.

## The Project Defined By What It Refuses

Read the guarantees list in the README and the whole philosophy falls out. Vitality:

- treats source paths as **literal filesystem paths, never regular expressions**;
- refuses to overwrite an existing wrapper;
- publishes through a temporary sibling, so a failed conversion leaves no partial destination;
- excludes dependency, VCS, cache, coverage, prior-build, docs, and test trees;
- omits `.env*` files — secrets do not migrate;
- preserves the source package's runtime dependencies;
- records displaced `dev`, `serve`, `build`, and `preview` scripts under `source:*` names so the old scripts survive, renamed;
- supplies its own pinned Vite and TypeScript toolchain instead of trusting a global or source-local install.

And the invariant underneath all of it: **the source directory is never changed.** This is a converter with a one-way door — everything flows out of your tree, nothing writes back into it, and if the conversion dies halfway, the temp-sibling publish means the failure mode is "nothing happened" rather than "half a wrapper."

## Finding The Site Inside The Mess

The hard problem is detection, and the heuristics are conservative to the point of stiffness. If `SOURCE/index.html` exists, it's the entry — done. If not, Vitality searches for nested site roots: the unique shallowest `index.html` wins, so `docs/index.html` still works from the repository root. A root entry always wins. And if two equally shallow candidates exist, it **refuses to guess** — point `--dir` at the intended directory. No tie-breaker magic, no first-match-wins. (That last behavior is exactly what the final commit of the project, "Support nested static site roots", added at 03:05 on September 2 — the edge case arrived after everything else was done, and got its own commit.)

Only secondary HTML that is actually *reachable from the root runtime graph* becomes a Vite page entry, and those pages keep their original routes. Documentation, tests, archived demos, and orphan `index.html` files are not copied as production pages. Client-side routers — React Router included — remain ordinary application code and are not mistaken for filesystem pages. Get that wrong and your dist suddenly contains a page for every route your router knows about; Vitality draws the line at reachability.

Local ES-module graphs move beneath `src/app/`: detected `.js`, `.jsx`, and `.mjs` modules become `.ts`, `.tsx`, and `.mts`, with their local imports and HTML entry references rewritten to the new literal paths. Everything else — existing TypeScript, CSS, JSON, images, framework dependencies, runtime assets — stays available to Vite untouched. When ready, a single-page source converges to the boring compact topology (`dist/index.html`, `assets/index.js`, `assets/index.css`), and a genuinely multi-page source emits only its routable pages and the chunks they require. Vitality never mirrors the source repository into `dist/`.

## The Small Details That Show Up In Production

Three behaviors are the difference between a demo converter and one you'd run on a real deployment:

1. **Base path honesty.** The configured base is written straight into Vite's shared `base` option — `/`, `/project/`, `./`, empty, or absolute HTTP(S) — so the generated `dist/` lands correctly on a domain root, a GitHub Pages subpath, or an embedded relative directory with zero post-build editing.
2. **Runtime URL manifests, not asset registries.** If a reachable JSON manifest resolves sibling files by URL at runtime, Vitality places that minimal relational graph in `public/` — preserving browser URL semantics and the configured base without turning the rest of the repository into public build output. Classic non-module scripts take the same path with `%BASE_URL%` references. Static-host control files (`404.html`, `CNAME`, `.nojekyll`, `_headers`, `_redirects`) are preserved at the selected site root — the small files that make a static host behave like the site it's serving.
3. **Inlining is one option, not a subsystem.** Answering the inline question controls exactly one Vite setting. There is no asset registry, Blob protocol, repository copier, or alternate embedding system — imported-asset behavior remains Vite's behavior, which is the whole point of handing the project to Vite in the first place.

## Install On Windows, Honestly

The README spends real space on a problem most tools assume away: `bun link` places the executable shim in Bun's global bin directory, which on Windows is normally `%USERPROFILE%\\.bun\\bin` — but a Winget installation of Bun may not add it to `PATH` automatically. So the docs carry both the per-session PowerShell fix and the permanent user-`PATH` version (checking the split `Path` value before appending, so a second run is a no-op), plus the bash equivalent. A tool whose own install step silently fails on the platform it targets most has a support queue; a tool that documents the failure mode doesn't.

The option surface stays small: `--output` (defaults to `SOURCE/mywrap`), `--base`, `--inline yes|no`, and `--dry-run`. There is deliberately **no install option**, because generation never installs.

## The Test Suite Is The Specification

`npm test` pins exactly the behaviors above, one test family per refusal: literal Windows-safe paths, base normalization, uninstalled generation, JS/JSX/MJS-to-TypeScript entry mapping, reachable-versus-orphan HTML, multi-page routing, source-script preservation, large-asset inlining, secret exclusion, exact single-page `dist/` topology, and transactional output. Read that list as a changelog of failure modes the project decided not to have — each entry corresponds to a way a naive converter could quietly corrupt a working site, and each one is now load-bearing in the suite.

## Five Commits, One Evening

The history is small and the shape tells the story: born **Friday, September 1, 15:53 UTC** ("feat: add Vitality Vite wrapper"), immediately disciplined (repository text files forced onto LF at 15:53:43, Bun global-bin setup documented at 16:06), a fix pass at 16:54 to make the generated projects proper native Vite sources, and the nested-static-site-root support at **03:05 the next morning**. Five commits across eleven hours, licensed AGPL v3.0-only — a complete tool, defined mostly by its refusals, finished before breakfast.

[github.com/CommanderTurtle/vitality](https://github.com/CommanderTurtle/vitality)

---

#### xkcd of the day, 9/1 - Geology Class #3292

![xkcd of the day](https://imgs.xkcd.com/comics/geology_class_2x.png)

[[the original keyboard sharing app]](https://github.com/symless/synergy)

"""

let render() = file
