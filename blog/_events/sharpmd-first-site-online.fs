module Bl0g.EventsFirstSiteOnlineMd

let file = """---
layout: post
title: "First Site Online: Forking the Hacker Theme"
author: "CommanderTurtle"
date: 2026-02-21 04:00:00 +0000
tags: [life, github-pages, jekyll, turtle-protect]
---

Before sHEL had a name, before the blog, before any of the repos that make up the orbit, there was a site. It went live on February 21, 2026, and the whole thing fit inside one afternoon's worth of commits.

## The Fork

The starting point was [pages-themes/hacker](https://github.com/pages-themes/hacker) &mdash; the stock "Hacker" theme from the GitHub Pages themes family, the black-terminal-on-white kind of thing that looks like someone's shell prompt decided to get a job. Forked at **19:49 UTC**, and the first commit landed ten minutes later at 19:59, re-pointing the GitHub and blog links in the default layout. By 20:21 the blog-view button got a new emoji &mdash; a monocle face &mdash; plus corrected button text and a cleaned-up comment/downloads section. That evening's work was done.

The next day closed the loop: a final pass over `default.html` at 01:21 UTC, and a LICENSE update at 23:29 UTC. Six commits total across the fork's history, five of them mine, all inside roughly thirty hours. The config stayed deliberately stock &mdash; title "Hacker theme", `theme: jekyll-theme-hacker`, downloads enabled &mdash; because the point was never to build a theme. The point was to have *a* public surface, wired to my GitHub, pointing at a blog that didn't exist yet, under a domain that would eventually become home to everything else: **turtleprotect.io/org**, which later became [vibe.shel.sh](https://vibe.shel.sh).

## Why It Matters

A fork with zero stars, zero forks, and 38 files is not infrastructure. It is a flag planted in the ground. The repo itself ([CommanderTurtle/hacker-turtle](https://github.com/CommanderTurtle/hacker-turtle)) still reads like a museum piece: the upstream README untouched, the demo homepage intact, my five edits sitting on top like a coat rack in an otherwise empty house.

What the timeline shows, if you read it for what it is, is velocity of *commitment*, not code. Ten minutes from fork to first edit means the decision to go public had already been made; the afternoon was just paperwork. Four months later, on June 20, the name **sHEL** shipped with [its introduction post](/blog/2026-06-20-introducing-shel/) and the whole orbit around it started spinning. But the first public byte was the hacker theme, wearing a monocle.

The archive services never crawled the original domain &mdash; there are no snapshots of turtleprotect.io anywhere, so the site exists today only in the fork and in memory. Which is rather the point of writing this down.

## The Lanyard Thread

One detail worth carrying forward: the domain's owner. The current incarnation of the site, [vibe.shel.sh](https://vibe.shel.sh), still carries the footer on its database pages: *"Turtle Protect is a florida-based project. 🐢"* Same entity, same turtle, four months later. When that became a physical object &mdash; a lanyard reading "Turtle Protect, CEO" &mdash; happened in April, in Miami. [That story is here](/events/ai-engineer-miami/).
"""

let render() = file
