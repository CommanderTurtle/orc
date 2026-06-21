module ConvertedFiles.Docs.XmlProject.FsharpZensicalMd

let file = """# F# Zensical Architecture

The Zensical documentation system is built on a hybrid architecture combining F# server-side rendering with MkDocs-style static site generation. This page documents the architectural decisions, component structure, and migration path from MkDocs Material to the F# Zensical system.

!!! tip "Info"
    Originally inspired by Type-Safe XML Literals, this project allows you to encode documentation sites like this one, in solely F# code.

My link on GitHub:

[CommanderTurtle/fsharp-zensical](https://github.com/CommanderTurtle/fsharp-zensical)

---

## Overview

???+ note "What this page covers"
    This page documents the F# Zensical documentation system architecture:

    - **Architecture** — F# parser, Giraffe ViewEngine templates, static output
    - **Component Structure** — Parser layer, template layer, configuration
    - **MkDocs Migration** — Feature mapping from mkdocs.yml to zensical.toml
    - **Giraffe ViewEngine** — F# HTML DSL as Jinja2 replacement
    - **Type Providers** — Compile-time configuration validation
    - **Asset Pipeline** — Sass/PostCSS stylesheets, TypeScript JavaScript
    - **Deployment** — GitHub Pages and Docker containerization

---

## Architecture Overview

```mermaid
flowchart TD
    subgraph Source["Documentation Source"]
        direction TB
        MD[".md Markdown Files"]
        TOML["zensical.toml<br/>Config"]
        CSS["SCSS Stylesheets"]
        TS["TypeScript Source"]
    end

    subgraph Build["Zensical Build Pipeline"]
        direction TB
        PARSE["Zensical Parser<br/>(F# / Markdig)"]
        CONF["TOML Config<br/>(Tomlyn + Type Provider)"]
        ASSET["Asset Pipeline<br/>(Sass + TypeScript)"]
    end

    subgraph Output["Static Output"]
        direction TB
        HTML["HTML Pages"]
        CSS_OUT["styles.css"]
        JS_OUT["bundle.js"]
    end

    subgraph Deploy["Deployment"]
        GHP["GitHub Pages"]
        CDN["CDN / Nginx"]
    end

    MD --> PARSE
    TOML --> CONF
    CSS --> ASSET
    TS --> ASSET
    PARSE --> HTML
    CONF --> PARSE
    ASSET --> CSS_OUT
    ASSET --> JS_OUT
    HTML --> Deploy
    CSS_OUT --> Deploy
    JS_OUT --> Deploy

    style Build fill:#4a90d9
    style Source fill:#7ed321
```

Zensical replaces Python-based MkDocs with an F#-native documentation pipeline while preserving the Material for MkDocs visual identity. The system uses F# type providers for compile-time configuration validation and Giraffe as the web framework for serving documentation.

---

## Component Structure

### Parser Layer

| Component | Technology | Purpose |
|-----------|-----------|---------|
| Markdown engine | Markdig | .NET markdown parser with extensions |
| TOML parser | Tomlyn | Configuration file parsing |
| YAML frontmatter | YamlDotNet | Page metadata extraction |
| Type provider | F# Type Providers | Compile-time config validation |

### Template Layer

| Component | Technology | Purpose |
|-----------|-----------|---------|
| View engine | Giraffe ViewEngine | F#-native HTML DSL |
| Layout system | Nested functions | Master pages, partials |
| Asset pipeline | Sass/PostCSS | Stylesheet compilation |
| JavaScript | Vanilla JS | Client-side interactions |

### Configuration

Zensical uses TOML configuration (zensical.toml) instead of MkDocs' YAML:

```toml
[site]
name = "sHEL Documentation"
url = "https://docs.shel.sh"
description = "sHEL Environment Literacy documentation"

[theme]
name = "material"
primary_color = "#4a7c59"
accent_color = "#7cb342"
font = "Roboto"

[nav]
"Symbols Archive" = "symbols/index.md"
"XML Project" = "xml-project/index.md"

[plugins]
search = true
minify = true
social_cards = true

[extensions]
admonition = true
codehilite = true
tables = true
tabs = true
pymdownx = ["superfences", "highlight", "tabbed"]
```

---

## MkDocs Migration

### Feature Mapping

```mermaid
flowchart LR
    subgraph MkDocs["MkDocs (Python)"]
        direction TB
        M1["mkdocs.yml"]
        M2["nav:"]
        M3["plugins:"]
        M4["markdown_extensions"]
        M5["Jinja2 Templates"]
    end

    subgraph Zensical["Zensical (F#)"]
        direction TB
        Z1["zensical.toml"]
        Z2["[nav]"]
        Z3["[plugins]"]
        Z4["[extensions]"]
        Z5["Giraffe ViewEngine"]
    end

    M1 -->|"Maps to"| Z1
    M2 --> Z2
    M3 --> Z3
    M4 --> Z4
    M5 --> Z5

    style MkDocs fill:#f5a623
    style Zensical fill:#4a90d9
```

| MkDocs Feature | Zensical Equivalent | Status |
|----------------|---------------------|--------|
| mkdocs.yml | zensical.toml | Implemented |
| nav: | [nav] section | Implemented |
| plugins: | [plugins] section | Partial |
| markdown_extensions | [extensions] section | Implemented |
| extra_css | [assets] stylesheets | Implemented |
| extra_javascript | [assets] scripts | Implemented |
| site_name | [site] name | Implemented |
| site_url | [site] url | Implemented |
| theme: name | [theme] name | Implemented |

### PyMdownX Extensions

The following PyMDownX extensions are supported in Zensical:

| Extension | Purpose |
|-----------|---------|
| `admonition` | Call-out boxes (note, warning, danger, tip) |
| `codehilite` | Syntax highlighting |
| `superfences` | Nested code blocks, custom fences |
| `highlight` | Line highlighting, line numbers |
| `tabbed` | Tabbed content containers |
| `emoji` | Emoji shortcodes |
| `tasklist` | Checkbox task lists |
| `arithmatex` | MathJax/KaTeX math rendering |
| `details` | Collapsible content |
| `keys` | Keyboard key rendering |

---

## Giraffe ViewEngine

The template system uses Giraffe ViewEngine, an F# DSL for HTML generation:

```fsharp
open Giraffe.ViewEngine

// Layout template
let masterLayout (title: string) (content: XmlNode) =
    html [ _lang "en" ] [
        head [] [
            title [] [ str title ]
            link [ _rel "stylesheet"; _href "/assets/styles.css" ]
        ]
        body [] [
            nav [ _class "md-nav" ] [
                // Navigation tree
            ]
            main [ _class "md-main" ] [
                article [ _class "md-content" ] [
                    content
                ]
            ]
        ]
    ]

// Page rendering
let renderPage (page: MarkdownPage) =
    masterLayout page.Title page.Content
```

### Comparison with MkDocs Jinja2

| Aspect | MkDocs (Jinja2) | Zensical (ViewEngine) |
|--------|-----------------|----------------------|
| Syntax | `{{ variable }}` | `str variable` |
| Control flow | `{% if %}`, `{% for %}` | F# `if`, `List.map` |
| Partials | `{% include %}` | Function composition |
| Filters | `\| upper`, `\| safe` | F# pipeline operators |
| Extensibility | Python plugins | F# modules |

---

## Type Provider Validation

F# Type Providers enable compile-time validation of configuration:

```fsharp
// Configuration is validated at compile time, not runtime
type ZensicalConfig = TomlProvider<"zensical.toml">

let config = ZensicalConfig.Load("zensical.toml")

// These are compile-time validated:
let siteName = config.Site.Name  // string, guaranteed to exist
let nav = config.Nav             // Navigation tree, structure validated
let theme = config.Theme.Name    // string, must be valid theme name
```

Benefits over runtime validation:

| Aspect | Runtime (Python/MkDocs) | Compile-time (F#/Zensical) |
|--------|------------------------|---------------------------|
| Error detection | At build time | At compile time |
| IDE support | None | IntelliSense, autocomplete |
| Refactoring | Error-prone | Type-safe |
| Documentation | Docstrings | Inferred types |

---

## Asset Pipeline

```mermaid
flowchart TD
    subgraph Styles["Stylesheets"]
        direction TB
        S1["src/scss/_variables.scss"]
        S2["src/scss/_layout.scss"]
        S3["src/scss/_components.scss"]
        S4["src/scss/main.scss"]
        S4 -->|"Sass<br/>compilation"| CSS["dist/assets/styles.css"]
    end

    subgraph Scripts["JavaScript"]
        direction TB
        J1["src/js/navigation.ts"]
        J2["src/js/search.ts"]
        J3["src/js/code-blocks.ts"]
        J4["src/js/main.ts"]
        J4 -->|"TypeScript<br/>compilation"| JS["dist/assets/bundle.js"]
    end

    style Styles fill:#4a90d9
    style Scripts fill:#7ed321
```

---

## Deployment

### GitHub Pages

```bash
# Build documentation
zensical build

# Deploy to GitHub Pages
zensical deploy --provider github-pages --repo user/repo

# Or manually:
# Output is in site/ directory
# Push to gh-pages branch
```

### Docker

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /docs
COPY . .
RUN dotnet tool restore
RUN zensical build

FROM nginx:alpine
COPY --from=build /docs/site /usr/share/nginx/html
```

---

## Related Pages

- [Base64 Encoding](base64.md) — Data encoding for asset embedding
- [cmd.exe Literacy](cmd-literacy.md) — Windows command-line patterns

## Related Deep Hole

- [F# History (HOPL)](https://fsharp.org/history/hopl-final/hopl-fsharp.pdf) — History of F# at ACM SIGPLAN HOPL conference
- [Giraffe ViewEngine](https://github.com/giraffe-fsharp/Giraffe) — F# HTML DSL
- [Markdig Documentation](https://github.com/xoofx/markdig) — .NET markdown parser
- [Tomlyn GitHub](https://github.com/xoofx/Tomlyn) — TOML parser for .NET
- [MkDocs Material Documentation](https://squidfunk.github.io/mkdocs-material/) — Reference theme
- [deepwiki.com/ultrabug/mkdocs-static-i18n](https://deepwiki.com/ultrabug/mkdocs-static-i18n) — i18n plugin
- [deepwiki.com/oprypin/mkdocs-gen-files](https://deepwiki.com/oprypin/mkdocs-gen-files) — Programmatic file generation
- [deepwiki.com/zhaoterryy/mkdocs-pdf-export-plugin](https://deepwiki.com/zhaoterryy/mkdocs-pdf-export-plugin) — PDF export
- [deepwiki.com/nuitsjp/mkdocs-mermaid-to-image](https://deepwiki.com/nuitsjp/mkdocs-mermaid-to-image) — Mermaid diagram conversion
"""

let render() = file
