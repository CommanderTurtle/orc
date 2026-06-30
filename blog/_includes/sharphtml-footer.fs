module ConvertedFiles.Includes.FooterRaw

let file = """<footer class="site-footer h-card">
  <data class="u-url" value="{{ '/' | relative_url }}"></data>

  <div class="wrapper">
    <div class="footer-grid">
      <div class="footer-brand">
        <div class="footer-logo">shel.sh</div>
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
          <li><a href="{{ site.github_url }}/macrohelp/blob/main/tasket-http-daemon/BUILD-FRESH-WINDOWS.md#fresh-windows-qt6-build-quick-start">Getting Started</a></li>
          <li><a href="{{ site.docs_url }}/xml-project/">API Reference</a></li>
          <li><a href="{{ '/contact/' | relative_url }}">Contact</a></li>
        </ul>
      </div>

      <div class="footer-links">
        <h4>Connect</h4>
        <ul>
          <li><a href="{{ site.twitter_url }}" target="_blank" rel="noopener">X / Twitter</a></li>
          <li><a href="{{ site.slack_url }}" target="_blank" rel="noopener">Slack</a></li>
          <li><a href="{{ site.linkedin_url }}" target="_blank" rel="noopener">LinkedIn</a></li>
          <li><a href="{{ '/feed.xml' | relative_url }}">RSS Feed</a></li>
        </ul>
      </div>
    </div>

    <div class="footer-bottom">
      <p>&trade; {{ site.time | date: '%Y' }} Turtle Protect, Inc. - a florida-based project. Non-profit development frameworks are released under the AGPLv3 License.</p>
      <div class="social-links">
        {%- include social.html -%}
      </div>
    </div>
  </div>
</footer>
"""

let render() = file
