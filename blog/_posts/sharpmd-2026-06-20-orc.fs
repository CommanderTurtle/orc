module Bl0g.Posts.N20260620OrcMd

let file = """---
layout: post
title: "orc: The Cross-Repo Pages Orchestrator Behind sHEL"
author: "CommanderTurtle"
date: 2026-06-20 04:00:00 +0000
tags: [project, fsharp, zensical, github-pages, infrastructure]
---

Every site in the sHEL family — this blog, docs.shel.sh, app.shel.sh, llm.shel.sh, a.shel.sh, and the rest — is built from a single repository: **orc**, an F# cross-repo pages orchestrator. Its README calls it "F# Zensical for MkDocs — Cross-Repo Pages Orchestrator," a continuation of the older [fsharp-material](https://github.com/CommanderTurtle/fsharp-material) MkDocs implementation, and its one-line pitch is the whole architecture: *write type-safe F# configurations, build beautiful static sites, and deploy them using dynamic content in F#.* The repo started on June 20, 2026 — the same day [sHEL was introduced](/blog/2026-06-20-introducing-shel/) — with a wrapper lineage that runs back to material (May 25) and zensical (June 8), both covered in the [fsharp-zensical post](/blog/2026-05-25-fsharp-zensical/). This is the account of how it works, as of the September 8 documentation pass.

## Everything Is a Wrapper

The load-bearing idea: every file on every site is a Zensical F# module. An `index.html` becomes `index.fs`, a Markdown post becomes `sharpmd-….fs`, a YAML config becomes a `sharpyml` — UTF-8 BOM, a `ConvertedFiles.…` module, the original content inside triple quotes, and a `render()` that returns it. The [fsharp-zensical post](/blog/2026-05-25-fsharp-zensical/) covers the wrapper format and its safety rules in depth; what matters here is what the wrapper buys at scale. HTML can be written as a typed Giraffe DSL instead of text, site configuration becomes type-checked F# instead of loose YAML, and repeated binary assets collapse into a shared-string catalog: the generator reconciles inline Base64 against a per-site `sharedstrings.fs` by hash, reuses known entries, and appends only new ones — which is how a site with embedded images stays diffable. The price of all of it is roughly a 6 MB one-time overhead per site after the F# builds.

## Auto-Detection, Ephemeral Builds, Separate Repos

You do not configure which framework a folder uses. Folders declare their stack by marker files — a `GEMFILE`, `node_modules`, or a `zensical.fs` — and the orchestrator detects the schema automatically. When [sharpendabot](https://github.com/CommanderTurtle/orc) sees a change it generates the workflow YAMLs; each generated `deploy-X` build then runs in a temporary `bun`/`uv` environment, deletes its build files, and pushes the fully built site to an entirely separate GitHub repository over token-authenticated git. The routing lives in `.github/config/` as `deploy-*.fs` records — repo name, CNAME, and a `UseSharedStrings` flag per site — so the topology of the whole sHEL fleet is inspectable as F# data rather than buried in Actions YAML.

The commit log shows the machinery running: of orc's 269 commits, 85 are authored by `sharpendabot[bot]`, in the exact rhythm of the pipeline — "Generate files from F# sources" followed by "Cleanup generated workflows" — interleaved with the 184 human commits. The generator is not a one-shot import; it is the steady state of the repo.

## The Generator's Surface

The README is blunt about how much machinery is actually load-bearing: "Nearly everything is done by two yamls - a deploy yaml and a translator yaml," with the rest present as "legacy/compatibility code for this repo to preserve iteration functionality." The generator itself (`src/generator/Generator.fsproj`) exposes the pipeline as CLI verbs: `wrap-batch` and `wrap-file` for imports, `shared-list` and `shared-asset` for poking the Base64 catalog without opening the large F# file, and `dotnet fsi GenerateConfig.fsx render-site` / `render-changes` for testing renders against the same catalog pointer. The `/throw/` verb is the shortcut path — it bundles legacy files automatically, wrapping a stray `something.html` into an `index.fs`. The edge cases are documented honestly: jinja-style HTML override files and codegolf quines break the DSL parser, so those folders get renamed to `.raw` before wrapping and back afterwards. And the cost is stated in one line: "Adding FS functionality to your site is only around 6 MB overhead (once) - after building F#. Which I find very cool." New sites can skip the archaeology entirely — a `clonable` branch carries the bare template.

## The Topology

Ten site folders, each deployed to its own repository and subdomain:

| Folder | Target | Serves |
|--------|--------|--------|
| `blog` | CommanderTurtle.github.io | this blog |
| `docs` | docs-pages | docs.shel.sh |
| `app` | app-pages | app.shel.sh (adspace, macro, make…) |
| `pages` | blog-pages | shel.sh root (projects, about, …) |
| `llm` | llm-pages | llm.shel.sh |
| `link` | a-pages | a.shel.sh (ln.kr) |
| `lab` | prov | the lab surface |
| `net` | net-docs | the net documentation site |
| `dio`, `vite` | dio-pages, reactproj | the remaining two |

The README still counts "seven site deployments" — the tree has grown past the prose. The point stands either way: one push to orc configures the whole fleet, and every project covered on this blog lives in it. The [adspace](/blog/2025-11-01-adspace/) templates sit in `app/adspace/`, the [macrohard](/blog/2026-06-11-macrohard/) editor source in `app/macro`, the [captcha](/blog/2026-06-20-captcha-side-project/) and quine toys in `pages/`, the [countku](/blog/2026-07-28-countku-side-project/) JavaScript math library — "requiring all math to be written in type-safe Haiku" — out of `app/` at app.shel.sh/countku, and this post is a file in `blog/_posts/`.

## Local Development Is a Poller

Running the fleet locally is the job of [reactor](https://github.com/CommanderTurtle/reactor), the lightweight Rust poller described in the [introducing-shel post](/blog/2026-06-20-introducing-shel/): it watches the orc checkout, re-renders only the changed F# files, and side-hosts whatever each site needs — `jekyll serve` for the blog, Vite for the React app, zensical serve for docs — on local ports. That is the exact loop this entire revamp ran on: edit a `.fs` file, watch the renderer rewrite the staging tree, let the local server rebuild, and verify the live page seconds later without touching a deploy pipeline.

## The Numbers

Two hundred sixty-nine commits from the June 20 initial commit to the September 8 README update — seventy-two of them on launch day alone. June is the build-out — 182 commits in the same week the sHEL family launched, the app/ tree landing and being restructured within days. July and August settle into maintenance (17 and 20 commits), and September opens a second wave (50): feature-matrix auditing and bug fixes, a z-index takeover fix, and the Zensical wrapping documentation adjusted to match what the generator actually does. Zero stars, zero forks, zero open issues — internal machinery, deliberately. The fleet runs on two classic GitHub tokens — `$GH_PAGES_TOKEN` for the pushes and `$SHARPENDABOT_TOKEN` for the bot, scoped to `admin:repo_hook, codespace, project, repo, workflow, write:packages`, nothing broader. The bet behind orc is that a personal web presence should be as maintainable as a codebase: one source of truth, one bot, one config directory, and every site regenerable from F# at any time.

[github.com/CommanderTurtle/orc](https://github.com/CommanderTurtle/orc) · [docs.shel.sh](https://docs.shel.sh/)

---

#### xkcd of the day, 6/20 - Side Effect #3261

![xkcd of the day](https://imgs.xkcd.com/comics/side_effect_2x.png)

[[a really cool site on poetry in programming]](https://dreamsongs.com/)

"""

let render() = file
