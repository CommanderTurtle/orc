module Imported.Posts.N20250815IntroducingShelMd

let file = """---
layout: post
title: "Introducing sHEL: A New Kind of Data Substrate"
author: "sHEL Team"
date: 2025-08-15 09:00:00 +0000
tags: [announcement, introduction]
---

Today we're excited to introduce **sHEL** — a volatile, literal-safe, automation-friendly data substrate that brings the reliability of a turtle shell to your data pipelines.

## The Problem

Modern data interchange is fragile. JSON, YAML, TOML — they all suffer from the same fundamental issues:

- **Injection vulnerabilities** — unescaped strings open the door to injection attacks
- **Parsing ambiguity** — subtle syntax differences break parsers across implementations
- **Tooling fragmentation** — every format needs its own toolchain

## Our Solution

sHEL takes a different approach. Inspired by the Unix philosophy, sHEL treats data as a stream of literal-safe tokens that flow through composable pipelines.

### Key Design Principles

1. **Literal-Safe by Default** — Data is always treated as literals. No escaping, no injection.
2. **Volatile Operations** — Fast, in-memory processing with optional persistence.
3. **Automation-First** — Structured output designed for machine consumption.

## Quick Example

Here's what sHEL looks like in practice:

```bash
# Parse a log file and extract structured data
cat app.log | shel parse --format json | jq '.level == "ERROR"'

# The output is always predictable, always safe
{
  "timestamp": "2025-08-15T09:00:00Z",
  "level": "ERROR",
  "message": "Connection timeout",
  "literal": true
}
```

## What's Next

This is just the beginning. We're building:

- A rich plugin ecosystem
- IDE integrations
- Visual pipeline builders
- Enterprise features

[Get started today]({{ site.docs_url }}/getting-started/) and let us know what you think!
"""

let render() = file
