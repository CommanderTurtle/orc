module Imported.Includes.HeaderHtml

let file = """<header class="site-header" id="site-header">
  <div class="wrapper">
    <a class="site-title" rel="author" href="{{ '/' | relative_url }}">
      <picture>
        <source srcset="{{ '/assets/images/shel-title-dark.png' | relative_url }}" media="(prefers-color-scheme: dark)">
        <img src="{{ '/assets/images/shel-title-light.png' | relative_url }}" alt="sHEL" height="32" style="display: block;">
      </picture>
    </a>

    <nav class="site-nav">
      <input type="checkbox" id="nav-trigger" class="nav-trigger" />
      <label for="nav-trigger" class="menu-icon">
        <span class="menu-line"></span>
        <span class="menu-line"></span>
        <span class="menu-line"></span>
      </label>

      <ul class="nav-items">
        <li><a href="{{ '/blog/' | relative_url }}">Blog</a></li>
        <li><a href="{{ '/events/' | relative_url }}">Events</a></li>
        <li><a href="{{ '/community/' | relative_url }}">Community</a></li>
        <li><a href="{{ '/contact/' | relative_url }}">Contact</a></li>
        <li><a href="{{ site.docs_url }}" class="nav-docs" target="_blank" rel="noopener">Docs ↗</a></li>
      </ul>
    </nav>
  </div>
</header>
"""

let render() = file
