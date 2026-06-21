module ConvertedFiles.Events.N2025.N11.N10DataengconfRaw

let file = """---
layout: page
title: "sHEL at DataEngConf"
subtitle: "📍 Berlin, Germany &bull; November 10, 2025"
permalink: /events/2025/11/10-dataengconf.html
---

<div class="container-narrow">

<div class="admonition admonition-note">
  <div class="admonition-title">Past Event</div>
  <div class="admonition-content">
    <p>This event has concluded. <a href="/blog/">Check our blog</a> for a recap post.</p>
  </div>
</div>

<h2>Presentation</h2>

<p><strong>"Literal-Safe Data Substrates: A New Approach"</strong></p>

<p>sHEL core maintainer presented sHEL's approach to data safety — how literal-by-default design eliminates an entire class of injection vulnerabilities without sacrificing developer experience.</p>

<h2>Key Takeaways</h2>

<ul>
  <li>Injection attacks cost the industry billions annually — and most are preventable with better data handling</li>
  <li>sHEL's <code>literal&lt;T&gt;</code> type guarantee makes injection impossible at the type level</li>
  <li>Performance benchmarks show zero overhead from safety guarantees</li>
  <li>Drop-in compatibility with existing Unix tools enables gradual adoption</li>
</ul>

<h2>Slides & Recording</h2>

<p><a href="https://github.com/CommanderTurtle/docs-pages/discussions" target="_blank" rel="noopener">View slides on GitHub Discussions</a></p>

<p><a href="/events/" class="btn btn-ghost">← Back to Events</a></p>

</div>
"""

let render() = file
