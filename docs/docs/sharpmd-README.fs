module ConvertedFiles.Docs.READMEMd

let file = """---
hide:
  - navigation
  - toc
---

# Welcome to sHEL

<figure>
  <img src="./assets/logos/shel-logo-text-light.png" alt="sHEL Light" class="logo-light" style="display: block; margin: 0 auto; width: 60%;">
  <img src="./assets/logos/shel-logo-text-dark.png" alt="sHEL Dark" class="logo-dark" style="display: block; margin: 0 auto; width: 60%;">
</figure>

<p style="text-align:center">
<strong>All the protection of a turtle without the soft underbelly.</strong>
</p>

<p style="text-align:center">
<script async defer src="https://buttons.github.io/buttons.js"></script>
<a class="github-button" href="https://github.com/CommanderTurtle/docs-pages" data-show-count="true" data-size="large" aria-label="Star">Star</a>
<a class="github-button" href="https://github.com/CommanderTurtle/docs-pages/subscription" data-show-count="true" data-icon="octicon-eye" data-size="large" aria-label="Watch">Watch</a>
<a class="github-button" href="https://github.com/CommanderTurtle/docs-pages/fork" data-show-count="true" data-icon="octicon-repo-forked" data-size="large" aria-label="Fork">Fork</a>
</p>

sHEL is a volatile, literal-safe, automation-friendly data substrate written for low-level communication.

Originally developed for using [boolean structure](https://en.wikipedia.org/wiki/Boolean_data_type) in multi-line assembly, sHEL has evolved into a reliable communication infrastructure for automation and LLMs.

## Where to Get Started

- Run open-source automation without an LLM? Start with [Flows](projects/macrohard.md)
- Build applications with sHEL using strongly-typed markdown, XML, and F#? See creating a [Markdown Registry](projects/regedited.md)
- Begin web development with F#? Learn the [Sharp Orchestrator](xml-project/fsharp-zensical.md)

## Development

- [Roadmap](xml-project/index.md)
- [Releases](https://github.com/CommanderTurtle?tab=repositories)

## What sHEL Is

sHEL can be used as:

- A full schema system
- A query language
- A serializer/deserializer
- A macro-friendly API
- A clipboard-based KV store
- A Markdown dashboard generator
- A "CMD database engine" with indexing

sHEL feels like:

- Redis
- Jinja2
- SQLite
- A templating engine
- A dashboard generator
- And a macro system

...all fused into one.

---

## Overview

???+ note "What sHEL provides"
    The sHEL documentation system is organized into five main sections:

    - **[Symbols Archive](symbols/index.md)** — Character reference, Base64 alphabet, stereograms
    - **[XML Project](xml-project/index.md)** — Literal-safe cmd.exe data handling, Base64, clipboard automation
    - **[Projects](projects/index.md)** — Individual sHEL ecosystem projects: Countku, CAPTCHA, Regedited, Macrohard
    - **[Wikispace](wikispace/index.md)** — Systems administration, networking, security, AI tooling
    - **[Deep Hole](deep-hole/index.md)** — Curated external resources and cultural references

---

## Learn More

- [sHEL Blog](https://shel.sh/blog) -- Company and infrastructure updates
- [sHEL Math](https://app.shel.sh/countku) -- Derive mathematics from passive literary devices and strings
- [sHEL Meetups](https://shel.sh/events) -- Community events and gatherings
"""

let render() = file
