module Bl0g.EventsMd
open EventsCalendar

let head = """---
layout: page
title: Events
subtitle: Every post and every repo launch, in the order it happened &mdash; plus the life around it.
permalink: /events/
---
<style>
.ev-legend { list-style: none; padding: 0; margin: 1rem 0 1.5rem; }
.ev-legend li { margin: .35rem 0; color: var(--text-secondary, #57606a); font-size: .92rem; }
.ev-dot { display: inline-block; width: .55em; height: .55em; border-radius: 50%; margin-right: .45em; }
.ev-dot-post { background: #EAB33D; }
.ev-dot-repo { background: #5B8DB8; }
.ev-month { margin: 2.1rem 0; }
.ev-month h3 { font-size: .95rem; font-weight: 600; letter-spacing: .06em; text-transform: uppercase; color: var(--text-secondary, #57606a); border-bottom: 1px solid var(--border-primary, rgba(0,0,0,.1)); padding-bottom: .45rem; margin-bottom: .6rem; }
.ev-day { display: flex; gap: 1rem; align-items: baseline; padding: .3rem 0; }
.ev-date { flex: 0 0 3.2rem; font-size: .85rem; color: var(--text-secondary, #57606a); font-variant-numeric: tabular-nums; }
.ev-items { display: flex; flex-wrap: wrap; gap: .35rem 1.1rem; }
.ev-link { text-decoration: none; color: var(--text-primary, #1b1f23); font-size: .95rem; }
.ev-link:hover { text-decoration: underline; color: #B8860B; }
.ev-repo:hover { color: #2C5F8A; }
.ev-quiet { font-style: italic; color: var(--text-secondary, #57606a); font-size: .9rem; padding: .3rem 0; }
.ev-sources { margin-top: 2.5rem; padding-top: 1rem; border-top: 1px solid var(--border-primary, rgba(0,0,0,.1)); color: var(--text-secondary, #57606a); font-size: .85rem; }
.ev-dot-life { background: #22C55E; }
.ev-life:hover { color: #16A34A; }
.ev-cal { margin: 1.75rem 0 2rem; border: 1px solid var(--border-primary, rgba(0,0,0,.1)); border-radius: 8px; background: var(--bg-card, #fff); }
.ev-cal > summary { cursor: pointer; padding: .8rem 1rem; font-weight: 600; color: var(--text-primary, #1b1f23); user-select: none; list-style: none; }
.ev-cal > summary::-webkit-details-marker { display: none; }
.ev-cal > summary::before { content: "\25B8  "; }
.ev-cal[open] > summary::before { content: "\25BE  "; }
.ev-cal-body { padding: 1rem; }
.ev-cal-hint { color: var(--text-muted, #57606a); font-size: .875rem; margin-top: -8px; margin-bottom: 20px; }
</style>

Nothing here is scheduled; the page is a record, not a diary of intent. It
covers two kinds of dot &mdash; everything that shipped, in the order it
shipped &mdash; plus the off-grid life around it. Three markers are in play:

<ul class="ev-legend">
<li><i class="ev-dot ev-dot-post"></i>Blog post &mdash; the link opens the post.</li>
<li><i class="ev-dot ev-dot-repo"></i>Repo launch &mdash; the link opens the GitHub repository.</li>
<li><i class="ev-dot ev-dot-life"></i>Life event &mdash; an off-grid story, written up as a full post under <code>/events/</code>.</li>
</ul>
"""

let tail = """<p class="ev-sources">Dates are UTC. Post dates come from the Jekyll frontmatter of each published article; repo launch dates come from GitHub creation records; life events were recovered from memory and cross-checked against the public record. Last checked 2026-09-12.</p>
"""

let render() = head + calendarBlock() + "\n\n## The Ledger\n\n" + calendarHtml() + tail
