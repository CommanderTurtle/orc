module Imported.Layouts.HomeHtml

let file = """---
layout: base
---

<!-- Hero Section -->
<section class="hero-section">
  <div class="hero-bg-pattern"></div>
  <div class="wrapper hero-content">
    <div class="hero-badge reveal">
      <span>🐢</span>
      <span>All the protection of a turtle, none of the soft underbelly</span>
    </div>
    <h1 class="hero-title reveal reveal-delay-1">
      The <span class="gradient-text">sHEL</span> Data Substrate
    </h1>
    <p class="hero-subtitle reveal reveal-delay-2">
      Volatile, literal-safe, automation-friendly. sHEL is a new kind of data format that brings the reliability of a shell with the flexibility of modern data interchange.
    </p>
    <div class="hero-cta-group reveal reveal-delay-3">
      <a href="{{ site.docs_url }}" class="btn btn-primary">Get Started</a>
      <a href="https://github.com/CommanderTurtle/docs-pages" class="btn btn-secondary">View on GitHub</a>
    </div>
  </div>
</section>

{{ content }}
"""

let render() = file
