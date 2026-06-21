module ConvertedFiles.Layouts.PostRaw

let file = """---
layout: base
---

<div class="post-layout">
  <div class="post-main">
    <article class="post h-entry" itemscope itemtype="http://schema.org/BlogPosting">

      <header class="post-header">
        <h1 class="post-title p-name" itemprop="name headline">{{ page.title | escape }}</h1>
        <div class="post-meta-bar">
          <div class="author-avatar">{{ page.author | default: site.author.name | slice: 0 }}</div>
          <span itemprop="author" itemscope itemtype="http://schema.org/Person">
            <span class="p-author h-card" itemprop="name">{{ page.author | default: site.author.name }}</span>
          </span>
          <span>&bull;</span>
          {%- assign date_format = site.minima.date_format | default: "%b %-d, %Y" -%}
          <time datetime="{{ page.date | date_to_xmlschema }}" itemprop="datePublished">
            {{ page.date | date: date_format }}
          </time>
          {%- if page.modified_date -%}
            <span>&bull;</span>
            <time datetime="{{ page.modified_date | date_to_xmlschema }}" itemprop="dateModified">
              Updated {{ page.modified_date | date: date_format }}
            </time>
          {%- endif -%}
        </div>
        {% if page.tags %}
          <div class="blog-tags" style="margin-top: 12px;">
            {% for tag in page.tags %}
              <a href="{{ '/blog/tags/' | append: tag | relative_url }}" class="tag">{{ tag }}</a>{% unless forloop.last %} {% endunless %}
            {% endfor %}
          </div>
        {% endif %}
      </header>

      <div class="post-content e-content" itemprop="articleBody">
        {{ content }}
      </div>

      <a class="u-url" href="{{ page.url | relative_url }}" hidden></a>
    </article>
  </div>

  <aside class="post-sidebar">
    <nav class="toc-nav" id="toc-nav" aria-label="Table of Contents">
      <h4>On this page</h4>
      <ul id="toc-list"></ul>
    </nav>
  </aside>
</div>
"""

let render() = file
