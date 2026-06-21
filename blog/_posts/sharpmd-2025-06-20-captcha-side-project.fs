module ConvertedFiles.Posts.N20250620CaptchaSideProjectMd

let file = """---
layout: post
title: "Turtle Protect: An Independent Shelling Company"
author: "CommanderTurtle"
date: 2025-06-20 14:00:00 +0000
tags: [side-project, security, web, captcha, anti-bot]
---

Most CAPTCHA solutions ask you to replace your entire page architecture. ReCAPTCHA wants its script in your head, its badge on your footer, and its external API calls on every form submission. hCaptcha isn't much different. They're effective but heavy — external dependencies, user tracking, significant page weight, and a UX that treats every visitor as a suspected bot first and a human second.

**Turtle Protect** takes a different approach. It's a drop-in CAPTCHA overlay — you don't replace anything. Think of it like adding three ingredients to a recipe you already have.

## The Philosophy

The project tagline is *"an independent shelling company"* — a play on words that captures the ethos. Independent: no external API calls, no third-party dependencies, no tracking. Shelling: the protective outer layer. Company: it just keeps you company on your existing page, no drama.

The core insight is that most sites don't need fortress-level bot protection. They need a sensible gate that keeps out automated abuse without annoying legitimate users or loading external scripts.

## How It Works

The implementation is intentionally minimal. You add three things to your existing HTML:

1. A small JavaScript snippet that loads the overlay
2. A button trigger element (can be your existing submit button)
3. A lightweight CSS file for the overlay styling

When the user clicks the protected button, an overlay appears with the CAPTCHA challenge. Upon successful completion, the overlay dismisses and the original form submission proceeds normally. The existing page logic doesn't change — Turtle Protect just intercepts, verifies, and releases.

The docs show the full integration pattern:

```html
<!DOCTYPE html>
<html>
<head>
  <!-- Your existing stuff like title, other CSS -->
  <link rel="stylesheet" href="turtle-protect.css">
</head>
<body>
  <!-- Your existing content -->
  <h1>Welcome to My Site</h1>
  <button id="login-btn">Login</button>

  <script src="turtle-protect.js"></script>
  <script>
    TurtleProtect.guard('#login-btn', {
      onSuccess: function() {
        // Your original login logic here
      }
    });
  </script>
</body>
</html>
```

## The "sickh" CAPTCHA

The project includes a reference implementation called the **"sickh" CAPTCHA** (a stylized spelling of "sick" — as in, *that's sick*). It's an anti-bot button that's easily placeable anywhere on an existing page. The overlay pattern means it works with vanilla HTML, React, Vue, or any framework — since it operates at the DOM level, your framework doesn't need to know it exists.

The full implementation guide with the overlay diagram and step-by-step integration is in the project docs:

- **Project page**: [shel.sh/projects/captcha](https://shel.sh/projects/captcha)
- **Documentation**: [shel.sh/projects/captcha/docs](https://shel.sh/projects/captcha/docs)
- **Raw docs**: [shel.sh/projects/captcha/docs/raw.txt](https://shel.sh/projects/captcha/docs/raw.txt)

## Why Not Just Use reCAPTCHA?

Three reasons:

**Privacy**: Turtle Protect makes zero external network requests. No Google servers, no tracking cookies, no behavioral profiling. Your users' interactions stay on your domain.

**Weight**: The entire library is under 5KB gzipped. reCAPTCHA's script alone is ~150KB, plus the badge, plus the verification request.

**Control**: You own the challenge generation, the validation logic, and the UX. Want to change the challenge type? It's your code. Want to customize the styling? It's your CSS. No API keys to manage, no quota limits, no terms-of-service changes.

## Current Status

Turtle Protect is functional and documented. The overlay implementation works across modern browsers. The project is actively maintained as a side project — the kind of tool you build because you need it yourself, then share because others probably need it too.

The captcha philosophy mirrors the broader sHEL approach: literal-safe, dependency-light, and respectful of the user. No external calls. No hidden tracking. Just a simple shell that keeps the bots out and the humans flowing through.

[View the docs](https://shel.sh/projects/captcha/docs) | [See it in action](https://shel.sh/projects/captcha)
"""

let render() = file
