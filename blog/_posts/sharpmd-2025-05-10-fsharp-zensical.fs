module ConvertedFiles.Posts.N20250510FsharpZensicalMd

let file = System.String.Join("\"\"\"", [|
    """---
layout: post
title: "fsharp-zensical: F# Meets Material for MkDocs"
author: "CommanderTurtle"
date: 2025-05-10 09:00:00 +0000
tags: [project, fsharp, zensical, docs, giraffe, dsl]
---

Documentation sites have a familiar shape: Markdown files, a static site generator, some theme customization, and a CI pipeline that builds on push. Most teams reach for MkDocs (with Material), Docusaurus, or Hugo. But what if your docs need to integrate with F# code? What if you want type-safe HTML generation, a Giraffe ViewEngine DSL, and the full Zensical (Material for MkDocs) feature set — admonitions, tabs, Mermaid diagrams — all while keeping the ability to drop raw HTML into the pipeline?

That's the question **fsharp-zensical** answers.

## What It Is

fsharp-zensical is a complete **F# → GitHub Pages** workflow using Zensical (Material for MkDocs) with full F# and DSL support. It's designed as a cross-repo pages orchestrator: each site folder (`main/`, `docs/`, `app/`, `blog/`) builds locally, and GitHub Actions push artifacts to entirely separate repositories using token-authenticated git. Think of it as a monorepo docs system where each subdomain gets its own repo and its own deployment pipeline.

The project is a continuation of the original `fsharp-material` work, restructured for maintainability and expanded with new features.

## Architecture Overview

The system is organized around **site folders**, each representing a distinct documentation property:

| Folder | Purpose |
|--------|---------|
| `main/` | Primary landing page |
| `docs/` | Technical documentation |
| `app/` | Application guides |
| `blog/` | Blog posts and announcements |

Each folder contains its own F# source files, markdown content, and build configuration. The shared infrastructure lives at the root: `Directory.Build.props`, `GenerateConfig.fsx`, and the GitHub Actions workflows in `.github/`.

## Two Page Types

The system supports two distinct page construction patterns:

**1. Standalone HTML (`index.fs`)**

For pages with complex JavaScript interactivity or heavy F# logic — the page is built entirely with Giraffe ViewEngine DSL:

```fsharp
module Blog.MyPage
open Giraffe.ViewEngine

let render () =
    html [] [
        head [] [ title [] [ str "My Page" ] ]
        body [] [
            h1 [] [ str "Hello from F#!" ]
            script [] [
                rawText """
    """
                console.log("Hello!");
                """
    """
            ]
        ]
    ]
    |> RenderView.AsString.htmlDocument
```

**2. F# with Markdown (`indexmd.fs`)**

For documentation-heavy pages that need Zensical features — the F# generates components that get embedded in markdown frontmatter:

```fsharp
module Docs.MyPage
open Giraffe.ViewEngine

let card =
    div [ _class "card" ] [
        h3 [] [ str "Welcome" ]
        p [] [ str "Type-safe components!" ]
    ]
    |> RenderView.AsString.htmlNode

let content = $"""
    """
---
title: My Page
---
# My Page
{card}
!!! tip "Zensical Features"
    Admonitions, tabs, Mermaid diagrams all work!
"""
    """
```

The markdown passes through Zensical (Material for MkDocs), so you get the full feature set: admonitions, code annotation, content tabs, Mermaid diagrams, and the complete visual theme.

## The HTML-to-DSL Converter

One of the most practical features is the `/throw/` folder. Drop any HTML file in there, push to GitHub, and a workflow automatically:

1. Parses the HTML element-by-element
2. Generates `pages/my-page/index.fs` with proper Giraffe ViewEngine DSL
3. Renders the output HTML for deployment

This means designers can work in raw HTML (or export from Figma, or paste from Tailwind templates), and the system converts it to type-safe F# DSL automatically. For `<script>` and `<style>` blocks, the converter uses triple-quoted strings — no escaping needed.

Input HTML:
```html
<div class="container">
  <h1>Hello World</h1>
  <p>Welcome to my site</p>
</div>
```

Output F#:
```fsharp
module Views
open Giraffe.ViewEngine

let page =
    div [ _class "container" ] [
        h1 [] [ str "Hello World" ]
        p [] [ str "Welcome to my site" ]
    ]
```

## Shared Modules

The `src/` folder contains reusable components: AST manipulation utilities, tree walking functions, and shared Giraffe view helpers. The `blog/` and `documentation/` folders contain the actual content. The `pages/` folder holds generated output from the HTML-to-DSL converter.

## GitHub Actions Pipeline

The CI/CD setup is token-based. GitHub Actions build each site folder locally, then push the generated output to separate repositories — one per subdomain. This means `docs.yoursite.com`, `blog.yoursite.com`, and `app.yoursite.com` can all originate from the same monorepo but deploy independently.

## Why F# for Documentation?

The usual objection: "Why not just use plain Markdown?" The answer is type safety and composability. When your documentation includes generated API references, version matrices, or dynamic content pulled from other sources, having a full programming language at your disposal — with compile-time checking — beats template string substitution every time.

The Giraffe ViewEngine DSL is particularly well-suited for this because it's just F# functions. No template syntax to learn. No magic string interpolation. Just functions composing functions, with the full power of the F# type system catching errors before they reach production.

## Project Structure

```
fsharp-zensical/
├── .github/              # CI/CD workflows
├── app/                  # Application docs site
├── blog/                 # Blog site
├── docs/                 # Technical docs site
├── documentation/        # Project documentation
├── main/                 # Landing page
├── pages/                # Generated pages from HTML
├── src/                  # Shared F# modules
├── throw/                # HTML drop zone for conversion
├── Directory.Build.props # MSBuild properties
├── GenerateConfig.fsx    # Config generation script
└── html2giraffe.sln      # Solution file
```

98.7% F#, 1.3% HTML. AGPL-3.0 licensed.

[View on GitHub](https://github.com/CommanderTurtle/fsharp-zensical) | [Documentation](https://github.com/CommanderTurtle/fsharp-zensical#documentation)
"""
|])

let render() = file
