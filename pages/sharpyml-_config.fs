module ConvertedFiles.ConfigYml

let file = """remote_theme: commanderturtle/hacker-turtle
plugins:
- jekyll-remote-theme
title: [Turtle Protect]
description: [an independent shelling company...]
markdown : GFM
github:
  home_url: https://vibe.shel.sh/home/
  about_url: https://vibe.shel.sh/about/
  blog_url: https://vibe.shel.sh/blog/
  shells_url: https://vibe.shel.sh/shells/
"""

let render() = file
