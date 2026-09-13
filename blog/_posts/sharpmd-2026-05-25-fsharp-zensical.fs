module Bl0g.Posts.N20260525FsharpZensicalMd

let file = System.String.Join("\"\"\"", [|
    """---
layout: post
title: "F# as a Deployment Engine: From Material for MkDocs to Zensical"
author: "CommanderTurtle"
date: 2026-05-25 04:00:00 +0000
tags: [fsharp, zensical, mkdocs, github-pages, html2giraffe, engineering]
---

There's a question that comes up more often than I'd expect when people see the
sHEL repos for the first time: *why F#?* Not "why did you pick this language" —
it's more like, "wait, your *deployment engine*, your *build system*, your
*GitHub Actions workflows*... are written in F#? On purpose? What are you
smoking?"

Fair question. This post is the answer, and it's the story of a two-repo
arc: [fsharp-material](https://github.com/CommanderTurtle/fsharp-material),
born on May 25, 2026 as "F# Material for MkDocs," and its rebranded successor
[fsharp-zensical](https://github.com/CommanderTurtle/fsharp-zensical), created
on June 8, 2026 — the engine that this very site, docs.shel.sh, app.shel.sh,
and everything else in the sHEL universe is built on. (Where it went from
there — an orchestrator called [orc](https://github.com/CommanderTurtle/orc)
that builds *this blog* — is the subject of another post; this one is about
the machine underneath.)

## The starting point: Material for MkDocs, May 25, 2026

Before there was Zensical, there was fsharp-material. It started on the 25th
of May as a straightforward idea: take Material for MkDocs — which, honestly,
is one of the best documentation theme ecosystems out there — and drive it
entirely from F# source files. Every config, every page, every workflow: F#.
No YAML by hand. No TOML by hand. No "I'll just tweak this config file
quickly" that turns into a half-migrated mess.

The commit graph from that day is fun to look at: fifty-four commits total in
the repo's life, and the first day alone was twenty-some, most of them README
churn. The README was being written *as a living document* — "Add ASCII art
section," "Update README to use HTML for ASCII art," "Refactor README to
remove ASCII art and add F# code," "Fix formatting of mathematical notation."
One day, one document, iterated until it was right. That's the sHEL
methodology in miniature: the docs are the product, and the product gets
redesigned in public until it holds up.

By end of day one the shape was fixed:

- A `.github/config/` tree of F# sources — `deploy-docs.fs`, `deploy-website.fs`,
  `deploy-app.fs`, `deploy-blog.fs`, `dependabot.fs`, `pr-check.fs` — that
  generate the workflow YAML at build time.
- A `Components.fs` API surface for the reusable page pieces.
- A `sharpendabot` state machine (more on this below) that keeps dependency
  updates deterministic instead of flappy.
- The core conversion story: **F# source → Markdown → HTML via MkDocs**, with
  F# doing the Markdown generation so that any page can compute, branch, and
  interpolate.

The key architectural decision from day one: every piece of site content is an
F# module whose body is a string. For example, an `indexmd.fs` file:

```fsharp
module ConvertedFiles.IndexMd

let file = """
    """---
title: My Page
---

# My Page

{card}

!!! tip "Zensical Features"
    Admonitions, tabs, Mermaid diagrams all work!
"""
    """

let render() = file
```

That string *is* the page. The build unwraps every such module — the
"Zensical unwrap step" — writes the resulting Markdown/TOML/YAML out as
generated files, and then hands off to the normal build pipeline (MkDocs for
docs, Jekyll for the blog, static hosting for the app). The F# is the source
of truth; the generated files are disposable.

## Rebrand to Zensical, June 8, 2026

Nine days later, on June 8, the project got its real name: fsharp-zensical,
"F# Zensical for Github Pages." The zensical repo's commit graph is short
(19 commits) and tells the story: initial commit at 20:43, then
`.github-repo-config.fs.example` (the multi-domain mapping config), the YML
uploads, `.nojekyll` and `.gitignore` — the whole "make this a deployable
template" sequence — and README updates through the end of June.

The rename wasn't cosmetic. "Material for MkDocs" described the first
deployment target. "Zensical" describes the *engine*, which is what the
project actually was: a fully-fledged F# deployment engine where Material
MkDocs was the first template the way the Zensical engine is the first
template *for the engine*. The README says it plainly: "Deployments to *any*
repository are made with F# as a wrapper. The included template is for
Zensical static sites."

And because the two repos share a purpose, their READMEs are mirror images —
the same ~981-line document in both, documenting the same engine. One repo,
two hats: the Material flavor and the Zensical flavor.

## The "why F#" question, answered properly

The README has a section on this, but the real answer is in the
documentation — a "why F#" page under
[documentation/](https://github.com/CommanderTurtle/fsharp-zensical/tree/main/documentation)
— and it rests on one language feature: **F# triple-quoted verbatim strings**.

Here are the rules that matter:

1. **No escape processing at all.** A `"""
    """`-delimited string does not
   interpret backslashes, quotes, percent signs, angle brackets — nothing.
   `C:\Users\test` stays `C:\Users\test`. `\n` stays the two characters
   backslash-n. `%2F` stays `%2F`. This is why embedding JavaScript, CSS, or
   SVG in F# source is *boring* — there is no escape hell, because there is
   no escaping.

2. **F# 9 quote-juggling.** You can explicitly jump in and out of string
   mode inside a triple-quoted string. A lone `"` inside is just a quote.
   And a backslash before a quote (\"") is the one-off escape when you need
   to keep a quote pair from colliding with the delimiter. So the string
   that looks like it can't exist — text containing both lone quotes and
   triple-quote-looking sequences — is expressible. This is exactly the
   feature that makes "content as data" sane in F# when other languages
   would reach for a templating engine.

3. **The engine's own wrapper strategy.** When a file *does* contain literal
   triple-quote sequences (like the F# code samples in this very post, or
   any docs page that shows F# source showing F# source), the wrapper can't
   be a single verbatim string. The engine handles it by splitting the
   content at the offending sequences and joining the pieces:

   ```fsharp
   module ConvertedFiles.Posts.N20250510FsharpZensicalMd

   let file = System.String.Join("\"\"\"", [|
       """
    """# F# as a Deployment Engine
       ...up to the first embedded triple quote...
       """
    """
       """
    """<the chunk that contained triple quotes, now a lone quote pair>"""
    """
       """
    """...the rest of the doc..."""
    """
       |])

   let render() = file
   ```

   This isn't a hack layered on top — it's the *programmatic* route, produced
   by the `wrap-file` command in the generator:

   ```bash
   dotnet run --project src/generator -- wrap-file page.md page.fs
   dotnet run --project src/generator -- wrap-batch pages/ out/
   ```

   So the workflow for any tricky document is: write the `.md` the way you
   would normally write it, point the wrapper at it, and get back a
   guaranteed-parseable `.fs`. The wrapper handles F# fine — including F#
   source that contains its own wrappers.

4. **Everything downstream is type-checked.** The unwrapped content is a
   string value with a `render()` entry point, the module name encodes the
   destination path, and the whole tree is one F# program that compiles.
   A typo in a page is a *compile error* with file and line, not a 404 you
   discover from a search-engine click three weeks later.

That last point is the one that keeps me coming back. In YAML, a missing
colon is a mystery. In F#, it's `error FS0010: Unexpected token` and a
pointer to the exact spot.

## One engine, four subdomains

The other reason F#-source configs pay off: **multi-subdomain GitHub Pages**.

GitHub Pages' hard rule is one site per repository. The sHEL universe needs
four:

| Folder  | Deploys To              | Domain          |
| ------- | ----------------------- | --------------- |
| `main/` | `website` branch        | `shel.sh`       |
| `docs/` | `docs` branch           | `docs.shel.sh`  |
| `app/`  | `applications` branch   | `app.shel.sh`   |
| `blog/` | `blog` branch           | `blog.shel.sh`  |

The Zensical engine overcomes the one-site limit by building locally in CI
and pushing the built output to **entirely separate repositories** using
GitHub token authentication — the repo mapping lives in
`.github-repo-config.fs` (an F# module with an `owner` binding that
auto-detects from `GITHUB_REPOSITORY_OWNER` and a `Cname` table for the
custom domains). Each subdomain folder carries its own generated
`zensical.toml`, `pyproject.toml`, `.nojekyll`, and `.gitignore`. During
initialization, Actions pull the latest Zensical, **.NET 10 LTS**, `uv`,
Giraffe ViewEngine, and AngleSharp — the whole toolchain pinned and
reproducible, no "works on my machine" in the deployment path.

## html2giraffe: drop HTML in `/throw/`, get F# back

The other half of the engine is
[html2giraffe](https://github.com/CommanderTurtle/fsharp-zensical/tree/main/src/html2giraffe):
a converter that turns HTML into **proper Giraffe.ViewEngine DSL**. The
intended workflow is deliberately low-ceremony:

```bash
# Drop any HTML file into /throw/
cp my-page.html throw/
git add . && git push
# The workflow parses it element-by-element,
# generates pages/my-page/index.fs with proper Giraffe DSL,
# and renders it to HTML for deployment
```

Input a one-liner like `<h1>Hello World</h1>` comes back as:

```fsharp
module Views
open Giraffe.ViewEngine

let page =
    div [ _class "container" ] [
        h1 [] [ str "Hello World" ]
    ]
```

Type-safe, composable, diffable HTML. For the parts that aren't markup —
`<script>` and `<style>` blocks — the converter emits them inside
triple-quoted `rawText` strings, so embedded JavaScript with regexes,
quotes, and backslash paths survives verbatim (again: no escaping).

The full CLI (this is the current state, verified against the repo):

```bash
dotnet run --project src/generator -- convert <input.html> <output.fs>
dotnet run --project src/generator -- batch <input-dir> <output-dir>
dotnet run --project src/generator -- wrap-file <input> <output>
dotnet run --project src/generator -- wrap-batch <input-dir> <output-dir>
dotnet run --project src/generator -- shared-asset <site-dir> <asset>
dotnet run --project src/generator -- shared-list <site-dir>
dotnet run --project src/generator -- wrap-site <input-dir> <output-dir>
dotnet run --project src/generator -- verify
```

`wrap-site` is the meta one: re-import a rendered site tree back into F#
source, so a hand-built static site can be *absorbed* into the pipeline and
then re-rendered through it. And `verify` checks conversion integrity.

## sharpendabot: a state machine instead of a flaky workflow

Dependency updates in CI are usually a coin flip — merge conflicts, half
applied updates, workflows that pass on a rerun. The Zensical approach is a
**deterministic state machine**: four actions (create PR, commit, merge,
close) across ten states, with exactly ten of the 4×10=52 possible
action/state combinations valid, and the machine re-evaluating on a fixed
30-minute cadence. Each step is a GitHub Action whose behavior is a pure
function of the current state; a "PR exists and checks passed" state means
"commit the merge," a "commit exists" state means "open the PR," and so on.
The result: updates that always land the same way, in the order
PR → commit → commit → PR, with no retry-and-pray. The state machine is
itself configured in F# (`.github/config/sharpendabot.fs`), so even the
workflow that updates the F# toolchain is F#-configured.

There's also a shared **bidirectional YML ↔ F# sync**: encode workflow state
back to F# sources so the config you see in the repo is the config that runs.

## The shared component library

Because pages are F# strings composed from values, the engine ships a
`Components.fs` library — cards, grids, badges, hero sections, admonitions —
plus AST-manipulation utilities (tree walking, text search, class injection,
structural transforms) for the generated trees. A "card" is a value you
interpolate into any page with `{card}`; the same component can appear on
the apex site, the docs site, and the blog with zero duplication.

## Where it lives now

The project didn't stop at Zensical. It grew into
[orc](https://github.com/CommanderTurtle/orc) — the orchestrator that
generates *this blog's* F# sources and builds it — with the generator and
html2giraffe living on under `src/generator` and `src/html2giraffe`. That
meta story (a blog post about the engine being written *through* the engine,
with a live Rust preview server rendering the F# as I edit it) deserves its
own post; the TODO list says "post: orc" and it's queued.

What I'd actually say to the "why F#?" question, in one sentence: because
the alternative is maintaining your entire website as a pile of text files
that nothing checks, and F# turns that pile into a *program* — type-checked,
testable, and boring in exactly the way infrastructure should be.

[Read the Zensical docs](https://github.com/CommanderTurtle/fsharp-zensical/tree/main/documentation) ·
[Material for MkDocs repo](https://github.com/CommanderTurtle/fsharp-material) ·
[html2giraffe source](https://github.com/CommanderTurtle/fsharp-zensical/tree/main/src/html2giraffe) ·
[orc — the orchestrator](https://github.com/CommanderTurtle/orc)

---

#### xkcd of the day, 5/25 - Flag Design #3250

![xkcd of the day](https://imgs.xkcd.com/comics/flag_design_2x.png)

[[is templeos real or a joke]](https://templeos.org/)

"""
|])

let render() = file
