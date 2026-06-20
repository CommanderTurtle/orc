module Imported.Includes.FooterHtml

let file = """<footer class="site-footer h-card">
  <data class="u-url" value="{{ '/' | relative_url }}"></data>

  <div class="wrapper">
    <div class="footer-grid">
      <div class="footer-brand">
        <div class="footer-logo">sHEL</div>
        <p>{{ site.description | escape }}</p>
      </div>

      <div class="footer-links">
        <h4>Project</h4>
        <ul>
          <li><a href="{{ '/blog/' | relative_url }}">Blog</a></li>
          <li><a href="{{ '/events/' | relative_url }}">Events</a></li>
          <li><a href="{{ site.docs_url }}">Documentation</a></li>
          <li><a href="{{ '/community/' | relative_url }}">Community</a></li>
        </ul>
      </div>

      <div class="footer-links">
        <h4>Resources</h4>
        <ul>
          <li><a href="https://github.com/CommanderTurtle/docs-pages" target="_blank" rel="noopener">GitHub</a></li>
          <li><a href="{{ site.docs_url }}/getting-started/">Getting Started</a></li>
          <li><a href="{{ site.docs_url }}/api-reference/">API Reference</a></li>
          <li><a href="{{ '/contact/' | relative_url }}">Contact</a></li>
        </ul>
      </div>

      <div class="footer-links">
        <h4>Connect</h4>
        <ul>
          <li><a href="https://x.com/commanderturtle" target="_blank" rel="noopener">X / Twitter</a></li>
          <li><a href="https://slack.shel.sh" target="_blank" rel="noopener">Slack</a></li>
          <li><a href="https://linkedin.com/company/shel-project" target="_blank" rel="noopener">LinkedIn</a></li>
          <li><a href="{{ '/feed.xml' | relative_url }}">RSS Feed</a></li>
        </ul>
      </div>
    </div>

    <div class="footer-bottom">
      <p>&copy; {{ site.time | date: '%Y' }} sHEL Project. Released under the MIT License.</p>
      <div class="social-links">
        {%- include social.html -%}
      </div>
    </div>
  </div>
</footer>
"""

let render() = file
