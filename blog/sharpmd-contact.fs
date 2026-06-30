module ConvertedFiles.ContactMd

let file = """---
layout: page
title: Contact
subtitle: Get in touch with the sHEL team.
permalink: /contact/
---

<div class="contact-grid">
  <div class="contact-form">
    <h3 style="margin-top: 0; margin-bottom: 24px;">Send us a message</h3>
    <form id="sHEL-contact-form">
      <div class="form-group">
        <label for="name">Name</label>
        <input type="text" id="name" name="name" required placeholder="Your name">
      </div>
      <div class="form-group">
        <label for="email">Email</label>
        <input type="email" id="email" name="email" required placeholder="you@example.com">
      </div>
      <div class="form-group">
        <label for="subject">Subject</label>
        <input type="text" id="subject" name="subject" placeholder="What's this about?">
      </div>
      <div class="form-group">
        <label for="message">Message</label>
        <textarea id="message" name="message" required placeholder="Your message..."></textarea>
      </div>
      <button type="submit" class="btn btn-primary">Send Message</button>
    </form>
  </div>

  <div class="contact-info">
    <h3 style="margin-top: 0; margin-bottom: 24px;">Other ways to reach us</h3>

    <div class="info-item">
      <div class="info-icon">📧</div>
      <div>
        <h4>Email (icloud private address)</h4>
        <a href="mailto:clement.keynote-1e@shel.sh">clement.keynote-1e@icloud.com</a>
      </div>
    </div>

    <div class="info-item">
      <div class="info-icon">💬</div>
      <div>
        <h4>Slack</h4>
        <a href="{{ site.slack_url }}" target="_blank" rel="noopener">&lbrack; redirect to slack &rbrack;</a>
        <p>Fastest response for technical questions</p>
      </div>
    </div>

    <div class="info-item">
      <div class="info-icon">🫂</div>
      <div>
        <h4>Support</h4>
        <a href="https://app.shel.sh/support" target="_blank" rel="noopener" title="app.shel.sh/support">Problem? Support.</a>
        <p>For bugs and framework issues</p>
      </div>
    </div>

    <div class="info-item">
      <div class="info-icon">🏢</div>
      <div>
        <h4>Office Hours</h4>
        <p>Every Sunday, 4pm EST</p>
        <p><a href="{{ site.slack_url }}" target="_blank" rel="noopener">Join us on Slack</a></p>
      </div>
    </div>
  </div>
</div>
"""

let render() = file
