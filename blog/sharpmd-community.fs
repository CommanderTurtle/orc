module Imported.CommunityMd

let file = """---
layout: page
title: Community
subtitle: Get involved with the sHEL project.
permalink: /community/
---

<div class="container-narrow">

<h2>Welcome to the sHEL Community</h2>

<p>We're building sHEL in the open, and we'd love for you to be part of it. Whether you're reporting bugs, contributing code, writing documentation, or just asking questions — every contribution matters.</p>

<div class="admonition admonition-note">
  <div class="admonition-title">Code of Conduct</div>
  <div class="admonition-content">
    <p>We are committed to providing a friendly, safe, and welcoming environment for all. Please be kind, respectful, and constructive in all interactions.</p>
  </div>
</div>

<h3>How to Contribute</h3>

<div class="contrib-grid">
  <div class="contrib-card">
    <div class="contrib-icon">🐛</div>
    <h4>Report Bugs</h4>
    <p>Found an issue? <a href="https://github.com/CommanderTurtle/docs-pages/issues" target="_blank" rel="noopener">File a bug report</a> on GitHub. Include steps to reproduce, expected vs. actual behavior, and your environment.</p>
  </div>
  <div class="contrib-card">
    <div class="contrib-icon">💻</div>
    <h4>Contribute Code</h4>
    <p>Check out our <a href="https://github.com/CommanderTurtle/docs-pages" target="_blank" rel="noopener">GitHub repository</a> and see the <a href="{{ site.docs_url }}/contributing/">Contributing Guide</a> for setup instructions, coding standards, and the PR process.</p>
  </div>
  <div class="contrib-card">
    <div class="contrib-icon">📝</div>
    <h4>Write Documentation</h4>
    <p>Great docs make great projects. Help us improve guides, fix typos, or add examples. Every page in our docs has an "Edit" link.</p>
  </div>
  <div class="contrib-card">
    <div class="contrib-icon">💬</div>
    <h4>Answer Questions</h4>
    <p>Help others in <a href="https://slack.shel.sh" target="_blank" rel="noopener">Slack</a> or on <a href="https://github.com/CommanderTurtle/docs-pages/discussions" target="_blank" rel="noopener">GitHub Discussions</a>. Sharing knowledge strengthens the community.</p>
  </div>
  <div class="contrib-card">
    <div class="contrib-icon">📢</div>
    <h4>Spread the Word</h4>
    <p>Tweet about sHEL, write blog posts, give talks, or star us on GitHub. Every bit of visibility helps.</p>
  </div>
</div>

<h3 style="margin-top: 48px;">Community Channels</h3>

<div class="community-grid" style="margin-top: 24px;">
  <a href="https://github.com/CommanderTurtle/docs-pages" class="community-card" target="_blank" rel="noopener">
    <div class="community-icon">⭐</div>
    <h4>Star on GitHub</h4>
    <p>Show your support</p>
  </a>
  <a href="https://slack.shel.sh" class="community-card" target="_blank" rel="noopener">
    <div class="community-icon">💬</div>
    <h4>Join Slack</h4>
    <p>Real-time community chat</p>
  </a>
  <a href="https://x.com/commanderturtle" class="community-card" target="_blank" rel="noopener">
    <div class="community-icon">🐦</div>
    <h4>Follow on X</h4>
    <p>News and updates</p>
  </a>
  <a href="{{ '/feed.xml' | relative_url }}" class="community-card">
    <div class="community-icon">📡</div>
    <h4>RSS Feed</h4>
    <p>Subscribe for updates</p>
  </a>
</div>

<h3 style="margin-top: 48px;">Acknowledgments</h3>

<p>sHEL is made possible by the contributions of <a href="https://github.com/CommanderTurtle/docs-pages/graphs/contributors" target="_blank" rel="noopener">dozens of community members</a>. Thank you to everyone who has helped shape this project.</p>

</div>
"""

let render() = file
