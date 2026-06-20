module Imported.Layouts.PageHtml

let file = """---
layout: base
---

<div class="wrapper" style="padding-top: 40px; padding-bottom: 80px;">
  <article class="post">
    {%- if page.title -%}
    <header class="post-header" style="margin-bottom: 40px;">
      <h1 class="post-title">{{ page.title | escape }}</h1>
      {%- if page.subtitle -%}
        <p style="color: var(--text-muted); font-size: 1.125rem; margin-top: 8px;">{{ page.subtitle }}</p>
      {%- endif -%}
    </header>
    {%- endif -%}

    <div class="post-content">
      {{ content }}
    </div>
  </article>
</div>
"""

let render() = file
