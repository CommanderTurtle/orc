module ConvertedFiles.ConfigYml

let file = """# Welcome to Jekyll!
#
# This config file is meant for settings that affect your whole blog, values
# which you are expected to set up once and rarely edit after that. If you find
# yourself editing this file very often, consider using Jekyll's data files
# feature for the data you need to update frequently.
#
# For technical reasons, this file is *NOT* reloaded automatically when you use
# 'bundle exec jekyll serve'. If you change this file, please restart the server process.
#
# If you need help with YAML syntax, here are some quick references for you:
# https://learn-the-web.algonquindesign.ca/topics/markdown-yaml-cheat-sheet/#yaml
# https://learnxinyminutes.com/docs/yaml/
#
# Site settings
# These are used to personalize your new site. If you look in the HTML files,
# you will see them accessed via {{ site.title }}, {{ site.email }}, and so on.
# You can create any custom variable you would like, and they will be accessible
# in the templates via {{ site.myvariable }}.

title: sHEL
email: hello@shel.sh
description: >- # this means to ignore newlines until "baseurl:"
  All the protection of a turtle without the soft underbelly.
  Volatile, literal-safe, automation-friendly data substrate.

baseurl: "/" # the subpath of your site, e.g. /blog
url: "https://shel.sh" # the base hostname & protocol for your site, e.g. http://example.com

# Docs link (external)
docs_url: "https://docs.shel.sh"
# Automation app link (external)
start_url: "https://app.shel.sh/macro"
# Deepwiki url (external)
deep_url: "https://deepwiki.com/CommanderTurtle/regedited"

# Re-inclusion of socials (See social_links below)
github_url: "https://github.com/CommanderTurtle"
twitter_url: "https://x.com/commanderturtle"
linkedin_url: "https://linkedin.com/company/turtleprotectinc"
slack_url: "https://shelsh.slack.com"

# Author information
author:
  name: sHEL Contributors
  email: clement.keynote-1e@icloud.com

# Build settings
theme: minima
plugins:
  - jekyll-feed
  - jekyll-seo-tag
  - jekyll-gfm-admonitions
  - jekyll-redirect-from

# Minima-specific settings
minima:
  # Minima skin selection.
  # Available skins are:
  # classic      -- Default, light color scheme.
  # dark         -- Dark variant.
  # auto         -- Adaptive based on system pref (classic/dark).
  # classic_skin -- Force classic even with auto.
  # dark_skin    -- Force dark even with auto.
  skin: auto
  
  # Social links in footer
  social_links:
    - { platform: github,  user_url: "https://github.com/CommanderTurtle/" }
    - { platform: twitter, user_url: "https://x.com/commanderturtle" }
    - { platform: linkedin, user_url: "https://linkedin.com/company/turtleprotectinc" }
    - { platform: slack, user_url: "https://slack.shel.sh" }

# Navigation pages
nav_pages:
  - blog.md
  - events.md
  - community.md
  - contact.md

# Pagination
paginate: 10
paginate_path: "/blog/page/:num/"

# Collections
collections:
  posts:
    output: true
    permalink: /blog/:year-:month-:day-:title/

# Defaults
defaults:
  - scope:
      path: ""
      type: "posts"
    values:
      layout: "post"
      author: "sHEL Team"
  - scope:
      path: ""
      type: "pages"
    values:
      layout: "page"

# Exclude from processing.
# The following items will not be processed, by default.
# Any item listed under the `exclude:` key here will be automatically added to
# the internal "default list".
#
# Excluded items can be processed by explicitly listing the directories or
# their entries' file path in the `include:` list.
#
# exclude:
#   - .sass-cache/
#   - .jekyll-cache/
#   - gemfiles/
#   - Gemfile
#   - Gemfile.lock
#   - node_modules/
#   - vendor/bundle/
#   - vendor/cache/
#   - vendor/gems/
#   - vendor/ruby/

exclude:
  - README.md

"""

let render() = file
