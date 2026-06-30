module ConvertedFiles.Layouts.HomeRaw

let file = """---
layout: base
---

<!-- Hero Section -->
<section class="hero-section">
  <div class="hero-bg-pattern"></div>
  <div class="wrapper hero-content">
    <div class="hero-title reveal">
        <img src="{{ '/assets/images/shel-title-dark.png' | relative_url }}" alt="sHEL" height="auto" style="display:block; margin:0 auto;"">
    </div>
    <h4 class="hero-title reveal reveal-delay-1">
      The <span class="gradient-text">Highly-Robust</span> and <span class="gradient-text">Low-Overhead</span> framework for devs
    </h4>
    <p class="hero-subtitle reveal reveal-delay-2">
      Volatile and fast database automation for everyone. Open-Source.
    </p>
    <div class="hero-cta-group reveal reveal-delay-3">
      <a href="{{ site.start_url }}" class="btn btn-primary">Get Started</a>
      <a href="{{ site.deep_url }}" class="btn btn-secondary">View on DeepWiki</a>
    </div><br>
    <div class="hero-badge reveal reveal-delay-4">
      <span>🐢</span>
      <span>All the protection of a turtle, none of the soft underbelly</span>
    </div>
  </div>
</section>

{{ content }}"""

let render() = file
