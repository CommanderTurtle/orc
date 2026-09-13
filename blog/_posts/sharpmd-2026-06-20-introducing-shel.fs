module Bl0g.Posts.N20260620IntroducingShelMd

let file = """---
layout: post
title: "Introducing sHEL: All the Protection of a Turtle, Without the Soft Underbelly"
author: "sHEL Team"
date: 2026-06-20 09:00:00 +0000
tags: [announcement, introduction, sHEL]
---

There's a moment in every automation script where data meets the Windows command line and something gets mangled. A quote, a percent sign, a caret, a `&` in the wrong place — and suddenly the data isn't data anymore. It's *instructions to the parser*. The value `C:\Users\nick&co\file "2"&"2"` doesn't survive a `cmd.exe` round-trip as a value; it survives as a syntax error, a truncated string, or — in the worst case — as a command you didn't write.

**sHEL** is the project I built to make that moment go away. The site description says what it says: *all the protection of a turtle, without the soft underbelly. Volatile, literal-safe, automation-friendly data substrate.*

That description is the first branding I went with, and it's still the one. But I want to be precise about what each of those words actually means, because sHEL is less a product with a roadmap and more a *discipline* that a collection of tools has to obey.

## The Problem: cmd.exe Is a Parser, Not a Container

The core technical problem, written out in the docs: storing and transmitting data that contains `cmd.exe` special characters **without triggering unwanted parser interpretation**.

This isn't a JSON-vs-YAML debate. It's the Windows command-line pipeline — the `FOR /F` family, `findstr`, delayed expansion with `!var!`, the `^` and `%%` escape rules — treating your *content* as *syntax*. Every one of those primitives is fine when you're scripting; every one of them is a bug when your data flows through it. The shell reads `&` and runs a command. It reads `!x!` and expands a variable you didn't set. It reads `%%` and substitutes a loop token. Your data walks in as a string and walks out as whatever the parser decided it meant.

The other classic data formats share the disease at a different level — injection, ambiguity, toolchain fragmentation — but sHEL was born specifically from the command-line wound, because that's the one I kept getting cut by.

## Literal-Safe Handling

The answer is a set of primitives, all built on one rule: **data is always treated as a literal**. No escaping conventions to get wrong, no context where a character changes meaning. The primitives that make it work, as documented:

- **Base64 encoding for media embedding** — images and other media travel as `data:` URIs inside the pages that use them. Self-contained, dependency-free, immune to every path and quote problem. The sHEL pages ship their own assets inside the document.
- **`cmd.exe` command literacy** — a written-up command surface: the `FOR /F` family, `findstr` for pattern matching, `TYPE` for file output, and the delayed expansion system, each documented with its escape rules. You don't fight the parser; you know it, and you route around it.
- **Clipboard automation patterns** — moving literal data between processes without a shell ever touching it.
- **The Haiku Numbersystem variable naming convention** — a naming discipline where the structure of the name carries the semantics (this is the same convention that countku's rulebook is built on).
- **Countku JS encoding** — the countku engine as an encoding layer: English-phrase math that has to survive a full 5-7-5 syllabic validation *and* an expression parse before it executes.
- **Invisible-Unicode CAPTCHA systems** — steganographic payloads hidden in characters like U+FFA0 that survive copy-paste, defeat OCR, and read as noise in a hex dump. (More in the [captcha post](/blog/2026-06-20-captcha-side-project/).)
- **The F# Zensical architecture** — the site and tooling layer itself, which I'll cover next.

These primitives combine into processing pipelines that can handle any character data without corruption. That's the "literal-safe" in the name: not "we added escaping," but "the character never becomes syntax."

## Volatile, Literal-Safe, Automation-Friendly

The three adjectives in the description aren't marketing. They're the design contract:

**Volatile** — processing is in-memory first. Data flows through pipelines as literals; persistence is an explicit, optional step you take when you decide a value is worth keeping. Nothing is implicitly written. Nothing lingers in a format you didn't choose.

**Literal-safe** — covered above. The invariant: content never becomes control flow.

**Automation-friendly** — output is structured for machine consumption. The pages, the feeds, the app surfaces — they're built so that a script can read what a human reads, without scraping. The blog you're reading is generated from F# source through a deterministic pipeline; the same source that renders this sentence also feeds the RSS, the subdomains, and the docs.

## The Platform: One Orchestrator, Many Subdomains

The practical shape of sHEL is a **multi-subdomain deployment**, and the interesting part is how it's built. The source of truth is a single F# repository — the Zensical orchestrator — where every site, page, and post is a type-safe F# file: HTML rendered as Giraffe view trees, markdown and config wrapped in F# modules, the whole thing compiled.

From that one repo, GitHub Actions builds each site folder locally and pushes the output to **entirely separate repositories** using token-authenticated git. The mapping is explicit in the deploy configs:

| Source folder | Deploy target | Live surface |
|---|---|---|
| `blog/` | `CommanderTurtle.github.io` | [shel.sh](https://shel.sh/) — this blog, Jekyll + minima |
| `pages/` | `blog-pages` | [vibe.shel.sh](https://vibe.shel.sh/) — the sHEL content site (shells, about, projects) |
| `app/` | `app-pages` | [app.shel.sh](https://app.shel.sh/) — the apps (macro, countku, forms) |
| `docs/` | `docs-pages` | [docs.shel.sh](https://docs.shel.sh/) — the documentation |
| `link/` | `a-pages` | [a.shel.sh](https://a.shel.sh/) — the link surface |

Each subdomain is an independent deploy: one broken page never takes down another surface, and each surface can evolve on its own cadence. The orchestrator is what keeps them in sync — it's the turtle shell around the whole system.

And the docs live at [docs.shel.sh](https://docs.shel.sh/): the core technical documentation for literal-safe handling, plus the Symbols Archive, the XML Project, individual Projects, a Wikispace, and the Deep Hole. The documentation itself follows the mantra — it's written the way the system works, literal-safe and structured, rather than prose about a system.

## What sHEL Protects

The public site asks the question the whole project answers: *what would you like to protect?* The shells:

- **life** — leaving a legacy for family. I'm a licensed life-insurance agent (Florida-based, which the site is candid about), and the life shell is where I sell what I'm actually certified for: affordable plans for families, with a CRM dashboard form generator — a basic HTML/Base64 encapsulator in "Lead Generator" clothing — at [turtleprotect.org](https://turtleprotect.org/).
- **estate** — mortgage protection.
- **money** — indexing your funds; annuities for lifelong income.
- **privacy** — identity protection, vulnerability management, and the opinion that accessibility is a skill, so the goal is to be *fluent in tech*.
- **internet** — cookies, data monetization, the tools you already have.
- **health** — finding reliable health and nutrition information without drowning.
- **oh no** — hair loss. Getting old is hard. We've all been there.
- **equity** and **assets** — bare currency investments, property, IP filing with AI oversight.

The point isn't that it's all finance. It's that the *protection framing* is real: a turtle shell is what you put around the things you want to keep safe, and sHEL is the shell you put around data, around a website, around a form, around a business. The turtle is the brand, the metaphor, and — in the case of the insurance license — the literal business.

## The Timeline

sHEL didn't start with the site. The earliest dated artifact is the **Terms of Service, last updated 02/24/2026** — the project and the legal entity (Turtle Protect, Inc.) existed by late February, with the documentation and the literal-safe system taking shape in the months that followed.

Then the engine: in **May 2026** the MkDocs implementation landed ([fsharp-material](https://github.com/CommanderTurtle/fsharp-material), 2026-05-25), and in **June 2026** it became the orchestrator — [fsharp-zensical](https://github.com/CommanderTurtle/fsharp-zensical) (2026-06-08), then the continuation repo that builds this very site (the `orc` upload of 2026-06-20, which is also the date this post is dated, because the whole platform went live that week).

That June launch was a week of "everything at once": the vLLM NVFP4 fork, the F# orchestrator, the registry-in-Rust project, and the sHEL platform itself, all in flight. Since then the system has been compounding — the countku engine's v8.1 matrix fidelity pass, the 2FAgamblah casino overlay, the documentation's expansion into the Deep Hole.

If you want the details of how any of this is actually built, the docs are the source of truth. If you want to see the philosophy in action, the rest of this blog is it — every post on here is generated by the same literal-safe pipeline.

[shel.sh](https://shel.sh/) · [docs.shel.sh](https://docs.shel.sh/) · [app.shel.sh](https://app.shel.sh/) · [turtleprotect.org](https://turtleprotect.org/) · [GitHub](https://github.com/CommanderTurtle)

---

#### xkcd of the day, 6/20 - Side Effect #3261

![xkcd of the day](https://imgs.xkcd.com/comics/side_effect_2x.png)

[[how small can a todo list get in c]](https://github.com/codegolf/todo/issues/2)

"""

let render() = file
