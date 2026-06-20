module Imported.ContactMd

let file = """---
layout: page
title: Contact
subtitle: Get in touch with the sHEL team.
permalink: /contact/
---

<div class="contact-grid">
  <div class="contact-form">
    <h3 style="margin-top: 0; margin-bottom: 24px;">Send us a message</h3>
    <form action="https://formspree.io/f/hello@shel.sh" method="POST">
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
        <h4>Email</h4>
        <a href="mailto:hello@shel.sh">hello@shel.sh</a>
      </div>
    </div>

    <div class="info-item">
      <div class="info-icon">💬</div>
      <div>
        <h4>Slack</h4>
        <a href="https://slack.shel.sh" target="_blank" rel="noopener">slack.shel.sh</a>
        <p>Fastest response for technical questions</p>
      </div>
    </div>

    <div class="info-item">
      <div class="info-icon">🐛</div>
      <div>
        <h4>Bug Reports</h4>
        <a href="https://github.com/CommanderTurtle/docs-pages/issues" target="_blank" rel="noopener">GitHub Issues</a>
        <p>For bugs and feature requests</p>
      </div>
    </div>

    <div class="info-item">
      <div class="info-icon">🏢</div>
      <div>
        <h4>Office Hours</h4>
        <p>Every Thursday, 4pm UTC</p>
        <p><a href="https://slack.shel.sh" target="_blank" rel="noopener">Join us on Slack</a></p>
      </div>
    </div>
  </div>
</div>
"""

let render() = file
