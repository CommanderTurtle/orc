module Imported.BlogMd

let file = """---
layout: page
title: Blog
subtitle: News, updates, and deep dives from the sHEL project.
permalink: /blog/
---

<div class="blog-list">
  {% for post in site.posts %}
    <article class="blog-card reveal">
      <div class="blog-meta">
        <div class="blog-date-day">{{ post.date | date: "%-d" }}</div>
        <div class="blog-date-month">{{ post.date | date: "%b %Y" }}</div>
      </div>
      <div class="blog-content">
        <h3><a href="{{ post.url | relative_url }}">{{ post.title }}</a></h3>
        <p>{{ post.excerpt | strip_html | truncatewords: 30 }}</p>
        {% if post.tags %}
          <div class="blog-tags">
            {% for tag in post.tags %}
              <span class="tag">{{ tag }}</span>
            {% endfor %}
          </div>
        {% endif %}
      </div>
    </article>
  {% endfor %}
</div>

{% if site.posts.size == 0 %}
<div class="text-center" style="padding: 80px 0;">
  <p style="font-size: 3rem; margin-bottom: 16px;">📝</p>
  <h3>No posts yet</h3>
  <p style="color: var(--text-muted);">Check back soon for updates from the sHEL project.</p>
</div>
{% endif %}
"""

let render() = file
