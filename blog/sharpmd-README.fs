module ConvertedFiles.READMEMd

let file = """# sHEL Blog

Jekyll-based blog and landing site for the sHEL project.

## Features

- **Landing page** with hero section, feature cards, multi-tab install block, stats bar, community cards, and resource links
- **Blog** with post listing, scrollable TOC sidebar on posts, and copy-to-clipboard code blocks
- **Events** page with functional calendar grid, clickable days, event popups, and event detail pages
- **Community** page with contribution guidelines and channel links
- **Contact** page with form and info section
- **Vibrant deep dark theme** with sHEL green accents
- **Smooth scroll reveal animations** with blur-to-focus effect
- **Responsive design** with mobile navigation
- **Atom RSS feed**

## Quick Start (Jekyll Tutorial)

New to Jekyll? Here's everything you need to know.

### What is Jekyll?

Jekyll is a static site generator. You write content in Markdown (and HTML), and Jekyll turns it into a complete website. No database, no server-side code — just fast, secure static files.

Key concepts:
- **Markdown (.md)** — Simple text format for writing content (like this README)
- **YAML Front Matter** — Metadata at the top of each file between `---` lines (title, date, tags, etc.)
- **Liquid** — Templating language for dynamic content `{{ variable }}` and logic `{% if %}`
- **Layouts** — HTML templates that wrap your content (`_layouts/`)
- **Includes** — Reusable HTML snippets (`_includes/`)
- **Assets** — CSS, JS, images (`assets/`)

### Prerequisites

You need Ruby installed (which comes with `gem`, the Ruby package manager).

```bash
# Check if Ruby is installed
ruby --version

# Check if gem is available
gem --version
```

If Ruby is not installed:
- **macOS**: `brew install ruby` (or use the system Ruby at `/usr/bin/ruby`)
- **Linux**: `sudo apt-get install ruby-full` (Debian/Ubuntu) or `sudo dnf install ruby` (Fedora)
- **Windows**: Install [RubyInstaller](https://rubyinstaller.org/)

### Install Dependencies

```bash
# Navigate to the project directory
cd shel-blog

# Install Bundler (Ruby's dependency manager)
gem install bundler

# Install all gems specified in Gemfile
bundle install
```

What this does:
- `gem` — Ruby's package manager (like `npm` for Node or `pip` for Python)
- `bundler` — Manages gem versions so everyone uses the same ones
- `Gemfile` — Lists all required gems (jekyll, minima theme, plugins)
- `bundle install` — Reads Gemfile and installs everything listed

### Serve Locally

```bash
# Start the Jekyll development server
bundle exec jekyll serve

# Or with live reload (auto-refreshes browser on file changes)
bundle exec jekyll serve --livereload
```

Then open [http://localhost:4000](http://localhost:4000) in your browser.

The server watches for file changes and rebuilds automatically.

### Build for Production

```bash
# Generate the static site in the _site/ directory
bundle exec jekyll build

# Or build with production environment
JEKYLL_ENV=production bundle exec jekyll build
```

The built site is output to `_site/`. Upload these files to any static host.

### Useful Commands

| Command | What it does |
|---------|-------------|
| `bundle exec jekyll serve` | Start dev server at localhost:4000 |
| `bundle exec jekyll serve --drafts` | Include draft posts |
| `bundle exec jekyll serve --livereload` | Auto-refresh browser |
| `bundle exec jekyll build` | Build site to `_site/` |
| `bundle exec jekyll clean` | Remove `_site/` and caches |
| `bundle update` | Update all gems to latest versions |

### Common Issues

**`bundle install` fails with permission errors**
: macOS system Ruby is protected. Use `sudo gem install bundler` or install Ruby via Homebrew.

**`webrick` not found**
: Ruby 3.0+ doesn't include webrick. Run `bundle add webrick`.

**Changes not showing up**
: Restart the server (`Ctrl+C`, then `bundle exec jekyll serve` again). Jekyll sometimes misses file changes in `_config.yml`.

## Project Structure

```
shel-blog/
├── _config.yml              # Site configuration
├── Gemfile                  # Ruby dependencies
├── index.md                 # Homepage (hero + all sections)
├── blog.md                  # Blog listing page
├── events.md                # Events page with calendar
├── community.md             # Community page
├── contact.md               # Contact page
├── feed.xml                 # Atom RSS feed
├── _layouts/                # Page templates
│   ├── base.html            # Root layout (header + footer + JS)
│   ├── home.html            # Homepage layout (adds hero)
│   ├── post.html            # Blog post (with TOC sidebar)
│   └── page.html            # Standard page layout
├── _includes/               # Reusable components
│   ├── head.html            # <head> section (meta, CSS, favicon)
│   ├── header.html          # Navigation bar
│   ├── footer.html          # Site footer
│   └── social.html          # Social icons
├── _posts/                  # Blog posts
│   └── YYYY-MM-DD-title.md  # Post naming convention
├── _sass/minima/            # Stylesheets
│   ├── custom-variables.scss # Color scheme variables
│   └── custom-styles.scss    # All component styles
├── assets/
│   ├── css/style.scss       # Minima entry point
│   ├── js/main.js           # Copy buttons, TOC, calendar, tabs
│   └── images/              # sHEL brand images
└── events/                  # Event detail pages
    └── YYYY/MM/
        └── DD-event-slug.html
```

### Adding a Blog Post

1. Create a new file in `_posts/` with the naming convention: `YYYY-MM-DD-title.md`
2. Add YAML front matter at the top:

```yaml
---
layout: post
title: "Your Post Title"
author: "Your Name"
date: 2025-12-25 10:00:00 +0000
tags: [announcement, technical]
---

Your post content here in **Markdown**.
```

3. Jekyll will automatically include it in the blog listing

### Adding an Event

1. Add the event to `events.md` in the calendar grid and events list
2. Create a detail page at `events/YYYY/MM/DD-event-slug.html`
3. Link the event card to the detail page

### Customizing Styles

Edit `_sass/minima/custom-styles.scss` for style changes. CSS custom properties (variables) are defined at the top and automatically adapt for dark mode via `prefers-color-scheme`.

## Theme

Uses the [minima](https://github.com/jekyll/minima) theme at commit `5ce4006d175e6e5278bb63a0aad1a85e3bf2370b` with heavy customizations:
- Vibrant deep dark color scheme (`#0a0a0f` background)
- sHEL green accent color (`#4a7c59`)
- Custom CSS properties for smooth light/dark transitions via `prefers-color-scheme`
"""

let render() = file
