module Imported.IndexMd

let file = """---
layout: home
title: null
---

<!-- Features Section -->
<section class="section" id="features">
  <div class="wrapper">
    <div class="section-header reveal">
      <h2>Why sHEL?</h2>
      <p>A data substrate designed for the modern era — literal-safe, automation-friendly, and fast.</p>
    </div>
    <div class="feature-grid">
      <div class="feature-card reveal reveal-delay-1">
        <div class="feature-icon">🛡️</div>
        <h3>Literal-Safe by Design</h3>
        <p>No more escaping nightmares. sHEL handles literals naturally, making data injection impossible by design. Your data is safe from the moment it enters the shell.</p>
      </div>
      <div class="feature-card reveal reveal-delay-2">
        <div class="feature-icon">⚡</div>
        <h3>Volatile & Fast</h3>
        <p>Built for speed. sHEL's volatile nature means zero persistence overhead — data flows through without touching disk unless you want it to. Perfect for high-throughput pipelines.</p>
      </div>
      <div class="feature-card reveal reveal-delay-3">
        <div class="feature-icon">🤖</div>
        <h3>Automation-Friendly</h3>
        <p>Structured output that machines love. sHEL produces predictable, parseable results every time. No more regex-fragile screen scraping or output parsing.</p>
      </div>
      <div class="feature-card reveal reveal-delay-1">
        <div class="feature-icon">🔧</div>
        <h3>Drop-in Compatible</h3>
        <p>Works with your existing toolchain. Pipe sHEL into jq, awk, or any standard Unix tool. Migration is gradual — adopt sHEL at your own pace.</p>
      </div>
      <div class="feature-card reveal reveal-delay-2">
        <div class="feature-icon">📦</div>
        <h3>Composable Pipelines</h3>
        <p>Build complex data workflows from simple, reusable components. Each sHEL command is a pure function — predictable inputs, predictable outputs.</p>
      </div>
      <div class="feature-card reveal reveal-delay-3">
        <div class="feature-icon">🌐</div>
        <h3>Cross-Platform</h3>
        <p>Runs everywhere. Linux, macOS, Windows — sHEL provides a consistent data substrate across all platforms. One format, any environment.</p>
      </div>
    </div>
  </div>
</section>

<!-- Install Section -->
<section class="section install-section" id="install">
  <div class="wrapper">
    <div class="section-header reveal">
      <h2>Get sHEL</h2>
      <p>Install in seconds, use for a lifetime.</p>
    </div>
    <div class="install-block reveal">
      <div class="install-tabs">
        <button class="tab-btn active" data-tab="macos">macOS</button>
        <button class="tab-btn" data-tab="linux">Linux</button>
        <button class="tab-btn" data-tab="windows">Windows</button>
        <button class="tab-btn" data-tab="cargo">Cargo</button>
        <button class="tab-btn" data-tab="docker">Docker</button>
      </div>
      <div class="code-wrapper">
        <div class="code-block" id="install-code">
          <span class="code-prompt">$</span>brew install shel
        </div>
      </div>
    </div>
    <div style="text-align: center; margin-top: 24px;">
      <p style="color: var(--text-muted); font-size: 0.875rem;">
        See the <a href="{{ site.docs_url }}/getting-started/">full installation guide</a> for more options.
      </p>
    </div>
  </div>
</section>

<!-- Stats Section -->
<section class="section" id="stats">
  <div class="wrapper">
    <div class="stats-bar reveal">
      <div class="stat-item">
        <div class="stat-number">50+</div>
        <div class="stat-label">Contributors</div>
      </div>
      <div class="stat-item">
        <div class="stat-number">1.2k</div>
        <div class="stat-label">GitHub Stars</div>
      </div>
      <div class="stat-item">
        <div class="stat-number">10M+</div>
        <div class="stat-label">Downloads</div>
      </div>
      <div class="stat-item">
        <div class="stat-number">0.3ms</div>
        <div class="stat-label">Avg. Latency</div>
      </div>
    </div>
  </div>
</section>

<!-- Community Section -->
<section class="section section-alt" id="community">
  <div class="wrapper">
    <div class="section-header reveal">
      <h2>Join the Community</h2>
      <p>Connect with other sHEL users, contributors, and enthusiasts.</p>
    </div>
    <div class="community-grid">
      <a href="https://github.com/CommanderTurtle/docs-pages" class="community-card reveal reveal-delay-1" target="_blank" rel="noopener">
        <div class="community-icon">💻</div>
        <h4>GitHub</h4>
        <p>Star us, file issues, contribute code</p>
      </a>
      <a href="https://slack.shel.sh" class="community-card reveal reveal-delay-2" target="_blank" rel="noopener">
        <div class="community-icon">💬</div>
        <h4>Slack</h4>
        <p>Real-time chat with the community</p>
      </a>
      <a href="https://x.com/commanderturtle" class="community-card reveal reveal-delay-3" target="_blank" rel="noopener">
        <div class="community-icon">🐦</div>
        <h4>X / Twitter</h4>
        <p>Updates, tips, and announcements</p>
      </a>
      <a href="{{ '/events/' | relative_url }}" class="community-card reveal reveal-delay-1">
        <div class="community-icon">📅</div>
        <h4>Events</h4>
        <p>Meetups, talks, and workshops</p>
      </a>
    </div>
  </div>
</section>

<!-- Resources Section -->
<section class="section" id="resources">
  <div class="wrapper">
    <div class="section-header reveal">
      <h2>Resources</h2>
      <p>Everything you need to get the most out of sHEL.</p>
    </div>
    <div class="resource-grid">
      <a href="{{ site.docs_url }}/getting-started/" class="resource-card reveal reveal-delay-1">
        <div class="resource-icon">📖</div>
        <div class="resource-content">
          <h4>Documentation</h4>
          <p>Comprehensive guides, API reference, and tutorials.</p>
        </div>
      </a>
      <a href="{{ site.docs_url }}/tutorials/" class="resource-card reveal reveal-delay-2">
        <div class="resource-icon">🎓</div>
        <div class="resource-content">
          <h4>Tutorials</h4>
          <p>Step-by-step tutorials for common use cases.</p>
        </div>
      </a>
      <a href="{{ '/blog/' | relative_url }}" class="resource-card reveal reveal-delay-3">
        <div class="resource-icon">📝</div>
        <div class="resource-content">
          <h4>Blog</h4>
          <p>Latest news, deep dives, and community spotlights.</p>
        </div>
      </a>
      <a href="{{ site.docs_url }}/examples/" class="resource-card reveal reveal-delay-1">
        <div class="resource-icon">🔍</div>
        <div class="resource-content">
          <h4>Examples</h4>
          <p>Real-world examples and sample configurations.</p>
        </div>
      </a>
    </div>
  </div>
</section>
"""

let render() = file
