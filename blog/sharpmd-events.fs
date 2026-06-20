module Imported.EventsMd

let file = """---
layout: page
title: Events
subtitle: Upcoming and past events, meetups, and workshops.
permalink: /events/
---

## Event Calendar

<div class="calendar-controls" style="display:flex;align-items:center;justify-content:center;gap:20px;margin-bottom:20px;">
  <button id="cal-prev" aria-label="Previous month" style="display:flex;align-items:center;justify-content:center;width:36px;height:36px;border-radius:var(--radius-sm);border:1px solid var(--border-primary);background:var(--bg-card);color:var(--text-secondary);cursor:pointer;transition:all 0.2s;">
    <svg viewBox="0 0 16 16" fill="none" stroke="currentColor" stroke-width="2" style="width:16px;height:16px;"><path d="M10 3L5 8l5 5"/></svg>
  </button>
  <h3 id="cal-month-title" style="font-size:1.25rem;font-weight:600;color:var(--text-primary);margin:0;min-width:180px;text-align:center;">January 2026</h3>
  <button id="cal-next" aria-label="Next month" style="display:flex;align-items:center;justify-content:center;width:36px;height:36px;border-radius:var(--radius-sm);border:1px solid var(--border-primary);background:var(--bg-card);color:var(--text-secondary);cursor:pointer;transition:all 0.2s;">
    <svg viewBox="0 0 16 16" fill="none" stroke="currentColor" stroke-width="2" style="width:16px;height:16px;"><path d="M6 3l5 5-5 5"/></svg>
  </button>
</div>

<p style="color: var(--text-muted); font-size: 0.875rem; margin-top: -8px; margin-bottom: 20px;">Click a highlighted day to view its events. Use the arrow buttons to navigate months. Days with multiple events show a popup.</p>

<div class="calendar-legend">
  <span class="legend-item"><span class="legend-dot" style="background: #3b82f6;"></span>Meetup</span>
  <span class="legend-item"><span class="legend-dot" style="background: #22c55e;"></span>Office Hours</span>
  <span class="legend-item"><span class="legend-dot" style="background: #eab308;"></span>Release</span>
  <span class="legend-item"><span class="legend-dot" style="background: #ec4899;"></span>Workshop</span>
  <span class="legend-item"><span class="legend-dot" style="background: #06b6d4;"></span>SIG Meeting</span>
  <span class="legend-item"><span class="legend-dot" style="background: #6366f1;"></span>Virtual</span>
</div>

<!-- August 2025 -->
<div class="cal-month" id="cal-2025-08" data-year="2025" data-month="7" style="display:none">
<div class="calendar-grid">
  <div class="calendar-day-header">Sun</div>
  <div class="calendar-day-header">Mon</div>
  <div class="calendar-day-header">Tue</div>
  <div class="calendar-day-header">Wed</div>
  <div class="calendar-day-header">Thu</div>
  <div class="calendar-day-header">Fri</div>
  <div class="calendar-day-header">Sat</div>

  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day"><span class="day-number">1</span></div>
  <div class="calendar-day"><span class="day-number">2</span></div>

  <div class="calendar-day"><span class="day-number">3</span></div>
  <div class="calendar-day"><span class="day-number">4</span></div>
  <div class="calendar-day"><span class="day-number">5</span></div>
  <div class="calendar-day"><span class="day-number">6</span></div>
  <div class="calendar-day"><span class="day-number">7</span></div>
  <div class="calendar-day"><span class="day-number">8</span></div>
  <div class="calendar-day"><span class="day-number">9</span></div>

  <div class="calendar-day"><span class="day-number">10</span></div>
  <div class="calendar-day"><span class="day-number">11</span></div>
  <div class="calendar-day" data-events='[{"title":"sHEL Office Hours #12","url":"/events/2025/08/12-office-hours-12.html","color":"#22c55e"}]'>
    <span class="day-number">12</span>
    <div class="event-dots"><span class="event-dot event-dot-office-hours"></span></div>
  </div>
  <div class="calendar-day"><span class="day-number">13</span></div>
  <div class="calendar-day"><span class="day-number">14</span></div>
  <div class="calendar-day"><span class="day-number">15</span></div>
  <div class="calendar-day"><span class="day-number">16</span></div>

  <div class="calendar-day"><span class="day-number">17</span></div>
  <div class="calendar-day"><span class="day-number">18</span></div>
  <div class="calendar-day"><span class="day-number">19</span></div>
  <div class="calendar-day"><span class="day-number">20</span></div>
  <div class="calendar-day"><span class="day-number">21</span></div>
  <div class="calendar-day"><span class="day-number">22</span></div>
  <div class="calendar-day"><span class="day-number">23</span></div>

  <div class="calendar-day"><span class="day-number">24</span></div>
  <div class="calendar-day"><span class="day-number">25</span></div>
  <div class="calendar-day"><span class="day-number">26</span></div>
  <div class="calendar-day"><span class="day-number">27</span></div>
  <div class="calendar-day"><span class="day-number">28</span></div>
  <div class="calendar-day"><span class="day-number">29</span></div>
  <div class="calendar-day"><span class="day-number">30</span></div>

  <div class="calendar-day"><span class="day-number">31</span></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
</div>
</div>

<!-- September 2025 -->
<div class="cal-month" id="cal-2025-09" data-year="2025" data-month="8" style="display:none">
<div class="calendar-grid">
  <div class="calendar-day-header">Sun</div>
  <div class="calendar-day-header">Mon</div>
  <div class="calendar-day-header">Tue</div>
  <div class="calendar-day-header">Wed</div>
  <div class="calendar-day-header">Thu</div>
  <div class="calendar-day-header">Fri</div>
  <div class="calendar-day-header">Sat</div>

  <div class="calendar-day empty"></div>
  <div class="calendar-day"><span class="day-number">1</span></div>
  <div class="calendar-day"><span class="day-number">2</span></div>
  <div class="calendar-day"><span class="day-number">3</span></div>
  <div class="calendar-day"><span class="day-number">4</span></div>
  <div class="calendar-day" data-events='[{"title":"Community Meetup #3","url":"/events/2025/09/05-meetup-3.html","color":"#3b82f6"}]'>
    <span class="day-number">5</span>
    <div class="event-dots"><span class="event-dot event-dot-meetup"></span></div>
  </div>
  <div class="calendar-day"><span class="day-number">6</span></div>

  <div class="calendar-day"><span class="day-number">7</span></div>
  <div class="calendar-day"><span class="day-number">8</span></div>
  <div class="calendar-day"><span class="day-number">9</span></div>
  <div class="calendar-day"><span class="day-number">10</span></div>
  <div class="calendar-day"><span class="day-number">11</span></div>
  <div class="calendar-day"><span class="day-number">12</span></div>
  <div class="calendar-day"><span class="day-number">13</span></div>

  <div class="calendar-day"><span class="day-number">14</span></div>
  <div class="calendar-day"><span class="day-number">15</span></div>
  <div class="calendar-day"><span class="day-number">16</span></div>
  <div class="calendar-day"><span class="day-number">17</span></div>
  <div class="calendar-day"><span class="day-number">18</span></div>
  <div class="calendar-day"><span class="day-number">19</span></div>
  <div class="calendar-day"><span class="day-number">20</span></div>

  <div class="calendar-day"><span class="day-number">21</span></div>
  <div class="calendar-day"><span class="day-number">22</span></div>
  <div class="calendar-day"><span class="day-number">23</span></div>
  <div class="calendar-day"><span class="day-number">24</span></div>
  <div class="calendar-day"><span class="day-number">25</span></div>
  <div class="calendar-day"><span class="day-number">26</span></div>
  <div class="calendar-day"><span class="day-number">27</span></div>

  <div class="calendar-day"><span class="day-number">28</span></div>
  <div class="calendar-day"><span class="day-number">29</span></div>
  <div class="calendar-day"><span class="day-number">30</span></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
</div>
</div>

<!-- October 2025 -->
<div class="cal-month" id="cal-2025-10" data-year="2025" data-month="9" style="display:none">
<div class="calendar-grid">
  <div class="calendar-day-header">Sun</div>
  <div class="calendar-day-header">Mon</div>
  <div class="calendar-day-header">Tue</div>
  <div class="calendar-day-header">Wed</div>
  <div class="calendar-day-header">Thu</div>
  <div class="calendar-day-header">Fri</div>
  <div class="calendar-day-header">Sat</div>

  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day"><span class="day-number">1</span></div>
  <div class="calendar-day"><span class="day-number">2</span></div>
  <div class="calendar-day"><span class="day-number">3</span></div>
  <div class="calendar-day"><span class="day-number">4</span></div>

  <div class="calendar-day"><span class="day-number">5</span></div>
  <div class="calendar-day"><span class="day-number">6</span></div>
  <div class="calendar-day"><span class="day-number">7</span></div>
  <div class="calendar-day"><span class="day-number">8</span></div>
  <div class="calendar-day"><span class="day-number">9</span></div>
  <div class="calendar-day"><span class="day-number">10</span></div>
  <div class="calendar-day"><span class="day-number">11</span></div>

  <div class="calendar-day"><span class="day-number">12</span></div>
  <div class="calendar-day"><span class="day-number">13</span></div>
  <div class="calendar-day"><span class="day-number">14</span></div>
  <div class="calendar-day"><span class="day-number">15</span></div>
  <div class="calendar-day"><span class="day-number">16</span></div>
  <div class="calendar-day"><span class="day-number">17</span></div>
  <div class="calendar-day"><span class="day-number">18</span></div>

  <div class="calendar-day"><span class="day-number">19</span></div>
  <div class="calendar-day"><span class="day-number">20</span></div>
  <div class="calendar-day"><span class="day-number">21</span></div>
  <div class="calendar-day"><span class="day-number">22</span></div>
  <div class="calendar-day"><span class="day-number">23</span></div>
  <div class="calendar-day"><span class="day-number">24</span></div>
  <div class="calendar-day"><span class="day-number">25</span></div>

  <div class="calendar-day"><span class="day-number">26</span></div>
  <div class="calendar-day"><span class="day-number">27</span></div>
  <div class="calendar-day"><span class="day-number">28</span></div>
  <div class="calendar-day"><span class="day-number">29</span></div>
  <div class="calendar-day"><span class="day-number">30</span></div>
  <div class="calendar-day"><span class="day-number">31</span></div>
  <div class="calendar-day empty"></div>
</div>
</div>

<!-- November 2025 -->
<div class="cal-month" id="cal-2025-11" data-year="2025" data-month="10" style="display:none">
<div class="calendar-grid">
  <div class="calendar-day-header">Sun</div>
  <div class="calendar-day-header">Mon</div>
  <div class="calendar-day-header">Tue</div>
  <div class="calendar-day-header">Wed</div>
  <div class="calendar-day-header">Thu</div>
  <div class="calendar-day-header">Fri</div>
  <div class="calendar-day-header">Sat</div>

  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day"><span class="day-number">1</span></div>

  <div class="calendar-day"><span class="day-number">2</span></div>
  <div class="calendar-day"><span class="day-number">3</span></div>
  <div class="calendar-day"><span class="day-number">4</span></div>
  <div class="calendar-day"><span class="day-number">5</span></div>
  <div class="calendar-day"><span class="day-number">6</span></div>
  <div class="calendar-day"><span class="day-number">7</span></div>
  <div class="calendar-day"><span class="day-number">8</span></div>

  <div class="calendar-day"><span class="day-number">9</span></div>
  <div class="calendar-day" data-events='[{"title":"sHEL at DataEngConf","url":"/events/2025/11/10-dataengconf.html","color":"#f97316"}]'>
    <span class="day-number">10</span>
    <div class="event-dots"><span class="event-dot event-dot-conference"></span></div>
  </div>
  <div class="calendar-day"><span class="day-number">11</span></div>
  <div class="calendar-day"><span class="day-number">12</span></div>
  <div class="calendar-day"><span class="day-number">13</span></div>
  <div class="calendar-day"><span class="day-number">14</span></div>
  <div class="calendar-day"><span class="day-number">15</span></div>

  <div class="calendar-day"><span class="day-number">16</span></div>
  <div class="calendar-day"><span class="day-number">17</span></div>
  <div class="calendar-day"><span class="day-number">18</span></div>
  <div class="calendar-day"><span class="day-number">19</span></div>
  <div class="calendar-day"><span class="day-number">20</span></div>
  <div class="calendar-day"><span class="day-number">21</span></div>
  <div class="calendar-day"><span class="day-number">22</span></div>

  <div class="calendar-day"><span class="day-number">23</span></div>
  <div class="calendar-day"><span class="day-number">24</span></div>
  <div class="calendar-day"><span class="day-number">25</span></div>
  <div class="calendar-day"><span class="day-number">26</span></div>
  <div class="calendar-day"><span class="day-number">27</span></div>
  <div class="calendar-day"><span class="day-number">28</span></div>
  <div class="calendar-day"><span class="day-number">29</span></div>

  <div class="calendar-day"><span class="day-number">30</span></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
</div>
</div>

<!-- December 2025 -->
<div class="cal-month" id="cal-2025-12" data-year="2025" data-month="11" style="display:none">
<div class="calendar-grid">
  <div class="calendar-day-header">Sun</div>
  <div class="calendar-day-header">Mon</div>
  <div class="calendar-day-header">Tue</div>
  <div class="calendar-day-header">Wed</div>
  <div class="calendar-day-header">Thu</div>
  <div class="calendar-day-header">Fri</div>
  <div class="calendar-day-header">Sat</div>

  <div class="calendar-day empty"></div>
  <div class="calendar-day"><span class="day-number">1</span></div>
  <div class="calendar-day"><span class="day-number">2</span></div>
  <div class="calendar-day"><span class="day-number">3</span></div>
  <div class="calendar-day"><span class="day-number">4</span></div>
  <div class="calendar-day"><span class="day-number">5</span></div>
  <div class="calendar-day"><span class="day-number">6</span></div>

  <div class="calendar-day"><span class="day-number">7</span></div>
  <div class="calendar-day"><span class="day-number">8</span></div>
  <div class="calendar-day"><span class="day-number">9</span></div>
  <div class="calendar-day"><span class="day-number">10</span></div>
  <div class="calendar-day"><span class="day-number">11</span></div>
  <div class="calendar-day"><span class="day-number">12</span></div>
  <div class="calendar-day"><span class="day-number">13</span></div>

  <div class="calendar-day"><span class="day-number">14</span></div>
  <div class="calendar-day"><span class="day-number">15</span></div>
  <div class="calendar-day"><span class="day-number">16</span></div>
  <div class="calendar-day"><span class="day-number">17</span></div>
  <div class="calendar-day"><span class="day-number">18</span></div>
  <div class="calendar-day"><span class="day-number">19</span></div>
  <div class="calendar-day"><span class="day-number">20</span></div>

  <div class="calendar-day"><span class="day-number">21</span></div>
  <div class="calendar-day"><span class="day-number">22</span></div>
  <div class="calendar-day"><span class="day-number">23</span></div>
  <div class="calendar-day"><span class="day-number">24</span></div>
  <div class="calendar-day"><span class="day-number">25</span></div>
  <div class="calendar-day"><span class="day-number">26</span></div>
  <div class="calendar-day"><span class="day-number">27</span></div>

  <div class="calendar-day"><span class="day-number">28</span></div>
  <div class="calendar-day"><span class="day-number">29</span></div>
  <div class="calendar-day"><span class="day-number">30</span></div>
  <div class="calendar-day"><span class="day-number">31</span></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
</div>
</div>

<!-- January 2026 -->
<div class="cal-month" id="cal-2026-01" data-year="2026" data-month="0">
<div class="calendar-grid">
  <div class="calendar-day-header">Sun</div>
  <div class="calendar-day-header">Mon</div>
  <div class="calendar-day-header">Tue</div>
  <div class="calendar-day-header">Wed</div>
  <div class="calendar-day-header">Thu</div>
  <div class="calendar-day-header">Fri</div>
  <div class="calendar-day-header">Sat</div>

  <div class="calendar-day empty"></div>
  <div class="calendar-day"><span class="day-number">1</span></div>
  <div class="calendar-day" data-events='[{"title":"sHEL Office Hours #13","url":"/events/2026/01/02-office-hours-13.html","color":"#22c55e"}]'>
    <span class="day-number">2</span>
    <div class="event-dots"><span class="event-dot event-dot-office-hours"></span></div>
  </div>
  <div class="calendar-day"><span class="day-number">3</span></div>
  <div class="calendar-day" data-events='[{"title":"Community Meetup #4","url":"/events/2026/01/04-meetup-4.html","color":"#3b82f6"}]'>
    <span class="day-number">4</span>
    <div class="event-dots"><span class="event-dot event-dot-meetup"></span></div>
  </div>
  <div class="calendar-day"><span class="day-number">5</span></div>
  <div class="calendar-day"><span class="day-number">6</span></div>

  <div class="calendar-day"><span class="day-number">7</span></div>
  <div class="calendar-day"><span class="day-number">8</span></div>
  <div class="calendar-day today" data-events='[{"title":"sHEL SIG-Schema Meeting","url":"/events/2026/01/09-sig-schema.html","color":"#06b6d4"},{"title":"Weekly Virtual Hangout","url":"/events/2026/01/09-virtual-hangout.html","color":"#6366f1"}]'>
    <span class="day-number">9</span>
    <div class="event-dots"><span class="event-dot event-dot-sig-meeting"></span><span class="event-dot event-dot-virtual"></span></div>
  </div>
  <div class="calendar-day"><span class="day-number">10</span></div>
  <div class="calendar-day"><span class="day-number">11</span></div>
  <div class="calendar-day"><span class="day-number">12</span></div>
  <div class="calendar-day" data-events='[{"title":"sHEL Office Hours #14","url":"/events/2026/01/13-office-hours-14.html","color":"#22c55e"}]'>
    <span class="day-number">13</span>
    <div class="event-dots"><span class="event-dot event-dot-office-hours"></span></div>
  </div>

  <div class="calendar-day"><span class="day-number">14</span></div>
  <div class="calendar-day" data-events='[{"title":"sHEL v1.0 Release Party","url":"/events/2026/01/15-release-party.html","color":"#eab308"}]'>
    <span class="day-number">15</span>
    <div class="event-dots"><span class="event-dot event-dot-release"></span></div>
    <span class="event-count">1 event</span>
  </div>
  <div class="calendar-day"><span class="day-number">16</span></div>
  <div class="calendar-day"><span class="day-number">17</span></div>
  <div class="calendar-day"><span class="day-number">18</span></div>
  <div class="calendar-day"><span class="day-number">19</span></div>
  <div class="calendar-day"><span class="day-number">20</span></div>

  <div class="calendar-day"><span class="day-number">21</span></div>
  <div class="calendar-day"><span class="day-number">22</span></div>
  <div class="calendar-day"><span class="day-number">23</span></div>
  <div class="calendar-day"><span class="day-number">24</span></div>
  <div class="calendar-day"><span class="day-number">25</span></div>
  <div class="calendar-day"><span class="day-number">26</span></div>
  <div class="calendar-day"><span class="day-number">27</span></div>

  <div class="calendar-day"><span class="day-number">28</span></div>
  <div class="calendar-day"><span class="day-number">29</span></div>
  <div class="calendar-day"><span class="day-number">30</span></div>
  <div class="calendar-day"><span class="day-number">31</span></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
</div>
</div>

<!-- February 2026 -->
<div class="cal-month" id="cal-2026-02" data-year="2026" data-month="1" style="display:none">
<div class="calendar-grid">
  <div class="calendar-day-header">Sun</div>
  <div class="calendar-day-header">Mon</div>
  <div class="calendar-day-header">Tue</div>
  <div class="calendar-day-header">Wed</div>
  <div class="calendar-day-header">Thu</div>
  <div class="calendar-day-header">Fri</div>
  <div class="calendar-day-header">Sat</div>

  <div class="calendar-day"><span class="day-number">1</span></div>
  <div class="calendar-day"><span class="day-number">2</span></div>
  <div class="calendar-day"><span class="day-number">3</span></div>
  <div class="calendar-day"><span class="day-number">4</span></div>
  <div class="calendar-day"><span class="day-number">5</span></div>
  <div class="calendar-day"><span class="day-number">6</span></div>
  <div class="calendar-day"><span class="day-number">7</span></div>

  <div class="calendar-day"><span class="day-number">8</span></div>
  <div class="calendar-day"><span class="day-number">9</span></div>
  <div class="calendar-day"><span class="day-number">10</span></div>
  <div class="calendar-day"><span class="day-number">11</span></div>
  <div class="calendar-day"><span class="day-number">12</span></div>
  <div class="calendar-day"><span class="day-number">13</span></div>
  <div class="calendar-day"><span class="day-number">14</span></div>

  <div class="calendar-day"><span class="day-number">15</span></div>
  <div class="calendar-day"><span class="day-number">16</span></div>
  <div class="calendar-day"><span class="day-number">17</span></div>
  <div class="calendar-day"><span class="day-number">18</span></div>
  <div class="calendar-day"><span class="day-number">19</span></div>
  <div class="calendar-day"><span class="day-number">20</span></div>
  <div class="calendar-day"><span class="day-number">21</span></div>

  <div class="calendar-day" data-events='[{"title":"sHEL Workshop: Building Data Pipelines","url":"/events/2026/02/22-workshop-pipelines.html","color":"#ec4899"}]'>
    <span class="day-number">22</span>
    <div class="event-dots"><span class="event-dot event-dot-workshop"></span></div>
  </div>
  <div class="calendar-day"><span class="day-number">23</span></div>
  <div class="calendar-day"><span class="day-number">24</span></div>
  <div class="calendar-day"><span class="day-number">25</span></div>
  <div class="calendar-day"><span class="day-number">26</span></div>
  <div class="calendar-day"><span class="day-number">27</span></div>
  <div class="calendar-day"><span class="day-number">28</span></div>
</div>
</div>

<!-- March 2026 -->
<div class="cal-month" id="cal-2026-03" data-year="2026" data-month="2" style="display:none">
<div class="calendar-grid">
  <div class="calendar-day-header">Sun</div>
  <div class="calendar-day-header">Mon</div>
  <div class="calendar-day-header">Tue</div>
  <div class="calendar-day-header">Wed</div>
  <div class="calendar-day-header">Thu</div>
  <div class="calendar-day-header">Fri</div>
  <div class="calendar-day-header">Sat</div>

  <div class="calendar-day"><span class="day-number">1</span></div>
  <div class="calendar-day"><span class="day-number">2</span></div>
  <div class="calendar-day"><span class="day-number">3</span></div>
  <div class="calendar-day"><span class="day-number">4</span></div>
  <div class="calendar-day"><span class="day-number">5</span></div>
  <div class="calendar-day"><span class="day-number">6</span></div>
  <div class="calendar-day"><span class="day-number">7</span></div>

  <div class="calendar-day"><span class="day-number">8</span></div>
  <div class="calendar-day"><span class="day-number">9</span></div>
  <div class="calendar-day"><span class="day-number">10</span></div>
  <div class="calendar-day"><span class="day-number">11</span></div>
  <div class="calendar-day"><span class="day-number">12</span></div>
  <div class="calendar-day"><span class="day-number">13</span></div>
  <div class="calendar-day"><span class="day-number">14</span></div>

  <div class="calendar-day"><span class="day-number">15</span></div>
  <div class="calendar-day"><span class="day-number">16</span></div>
  <div class="calendar-day"><span class="day-number">17</span></div>
  <div class="calendar-day"><span class="day-number">18</span></div>
  <div class="calendar-day"><span class="day-number">19</span></div>
  <div class="calendar-day"><span class="day-number">20</span></div>
  <div class="calendar-day"><span class="day-number">21</span></div>

  <div class="calendar-day"><span class="day-number">22</span></div>
  <div class="calendar-day"><span class="day-number">23</span></div>
  <div class="calendar-day"><span class="day-number">24</span></div>
  <div class="calendar-day"><span class="day-number">25</span></div>
  <div class="calendar-day"><span class="day-number">26</span></div>
  <div class="calendar-day"><span class="day-number">27</span></div>
  <div class="calendar-day"><span class="day-number">28</span></div>

  <div class="calendar-day"><span class="day-number">29</span></div>
  <div class="calendar-day"><span class="day-number">30</span></div>
  <div class="calendar-day"><span class="day-number">31</span></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
</div>
</div>

<!-- April 2026 -->
<div class="cal-month" id="cal-2026-04" data-year="2026" data-month="3" style="display:none">
<div class="calendar-grid">
  <div class="calendar-day-header">Sun</div>
  <div class="calendar-day-header">Mon</div>
  <div class="calendar-day-header">Tue</div>
  <div class="calendar-day-header">Wed</div>
  <div class="calendar-day-header">Thu</div>
  <div class="calendar-day-header">Fri</div>
  <div class="calendar-day-header">Sat</div>

  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day"><span class="day-number">1</span></div>
  <div class="calendar-day"><span class="day-number">2</span></div>
  <div class="calendar-day"><span class="day-number">3</span></div>
  <div class="calendar-day"><span class="day-number">4</span></div>

  <div class="calendar-day"><span class="day-number">5</span></div>
  <div class="calendar-day"><span class="day-number">6</span></div>
  <div class="calendar-day"><span class="day-number">7</span></div>
  <div class="calendar-day"><span class="day-number">8</span></div>
  <div class="calendar-day"><span class="day-number">9</span></div>
  <div class="calendar-day"><span class="day-number">10</span></div>
  <div class="calendar-day"><span class="day-number">11</span></div>

  <div class="calendar-day"><span class="day-number">12</span></div>
  <div class="calendar-day"><span class="day-number">13</span></div>
  <div class="calendar-day"><span class="day-number">14</span></div>
  <div class="calendar-day"><span class="day-number">15</span></div>
  <div class="calendar-day"><span class="day-number">16</span></div>
  <div class="calendar-day"><span class="day-number">17</span></div>
  <div class="calendar-day"><span class="day-number">18</span></div>

  <div class="calendar-day"><span class="day-number">19</span></div>
  <div class="calendar-day"><span class="day-number">20</span></div>
  <div class="calendar-day"><span class="day-number">21</span></div>
  <div class="calendar-day"><span class="day-number">22</span></div>
  <div class="calendar-day"><span class="day-number">23</span></div>
  <div class="calendar-day"><span class="day-number">24</span></div>
  <div class="calendar-day"><span class="day-number">25</span></div>

  <div class="calendar-day"><span class="day-number">26</span></div>
  <div class="calendar-day"><span class="day-number">27</span></div>
  <div class="calendar-day"><span class="day-number">28</span></div>
  <div class="calendar-day"><span class="day-number">29</span></div>
  <div class="calendar-day"><span class="day-number">30</span></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
</div>
</div>

<!-- May 2026 -->
<div class="cal-month" id="cal-2026-05" data-year="2026" data-month="4" style="display:none">
<div class="calendar-grid">
  <div class="calendar-day-header">Sun</div>
  <div class="calendar-day-header">Mon</div>
  <div class="calendar-day-header">Tue</div>
  <div class="calendar-day-header">Wed</div>
  <div class="calendar-day-header">Thu</div>
  <div class="calendar-day-header">Fri</div>
  <div class="calendar-day-header">Sat</div>

  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day"><span class="day-number">1</span></div>
  <div class="calendar-day"><span class="day-number">2</span></div>

  <div class="calendar-day"><span class="day-number">3</span></div>
  <div class="calendar-day"><span class="day-number">4</span></div>
  <div class="calendar-day"><span class="day-number">5</span></div>
  <div class="calendar-day"><span class="day-number">6</span></div>
  <div class="calendar-day"><span class="day-number">7</span></div>
  <div class="calendar-day"><span class="day-number">8</span></div>
  <div class="calendar-day"><span class="day-number">9</span></div>

  <div class="calendar-day"><span class="day-number">10</span></div>
  <div class="calendar-day"><span class="day-number">11</span></div>
  <div class="calendar-day"><span class="day-number">12</span></div>
  <div class="calendar-day"><span class="day-number">13</span></div>
  <div class="calendar-day"><span class="day-number">14</span></div>
  <div class="calendar-day"><span class="day-number">15</span></div>
  <div class="calendar-day"><span class="day-number">16</span></div>

  <div class="calendar-day"><span class="day-number">17</span></div>
  <div class="calendar-day"><span class="day-number">18</span></div>
  <div class="calendar-day"><span class="day-number">19</span></div>
  <div class="calendar-day"><span class="day-number">20</span></div>
  <div class="calendar-day"><span class="day-number">21</span></div>
  <div class="calendar-day"><span class="day-number">22</span></div>
  <div class="calendar-day"><span class="day-number">23</span></div>

  <div class="calendar-day"><span class="day-number">24</span></div>
  <div class="calendar-day"><span class="day-number">25</span></div>
  <div class="calendar-day"><span class="day-number">26</span></div>
  <div class="calendar-day"><span class="day-number">27</span></div>
  <div class="calendar-day"><span class="day-number">28</span></div>
  <div class="calendar-day"><span class="day-number">29</span></div>
  <div class="calendar-day"><span class="day-number">30</span></div>

  <div class="calendar-day"><span class="day-number">31</span></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
</div>
</div>

<!-- June 2026 -->
<div class="cal-month" id="cal-2026-06" data-year="2026" data-month="5" style="display:none">
<div class="calendar-grid">
  <div class="calendar-day-header">Sun</div>
  <div class="calendar-day-header">Mon</div>
  <div class="calendar-day-header">Tue</div>
  <div class="calendar-day-header">Wed</div>
  <div class="calendar-day-header">Thu</div>
  <div class="calendar-day-header">Fri</div>
  <div class="calendar-day-header">Sat</div>

  <div class="calendar-day empty"></div>
  <div class="calendar-day"><span class="day-number">1</span></div>
  <div class="calendar-day"><span class="day-number">2</span></div>
  <div class="calendar-day"><span class="day-number">3</span></div>
  <div class="calendar-day"><span class="day-number">4</span></div>
  <div class="calendar-day"><span class="day-number">5</span></div>
  <div class="calendar-day"><span class="day-number">6</span></div>

  <div class="calendar-day"><span class="day-number">7</span></div>
  <div class="calendar-day"><span class="day-number">8</span></div>
  <div class="calendar-day"><span class="day-number">9</span></div>
  <div class="calendar-day"><span class="day-number">10</span></div>
  <div class="calendar-day"><span class="day-number">11</span></div>
  <div class="calendar-day"><span class="day-number">12</span></div>
  <div class="calendar-day"><span class="day-number">13</span></div>

  <div class="calendar-day"><span class="day-number">14</span></div>
  <div class="calendar-day"><span class="day-number">15</span></div>
  <div class="calendar-day"><span class="day-number">16</span></div>
  <div class="calendar-day"><span class="day-number">17</span></div>
  <div class="calendar-day"><span class="day-number">18</span></div>
  <div class="calendar-day"><span class="day-number">19</span></div>
  <div class="calendar-day"><span class="day-number">20</span></div>

  <div class="calendar-day"><span class="day-number">21</span></div>
  <div class="calendar-day"><span class="day-number">22</span></div>
  <div class="calendar-day"><span class="day-number">23</span></div>
  <div class="calendar-day"><span class="day-number">24</span></div>
  <div class="calendar-day"><span class="day-number">25</span></div>
  <div class="calendar-day"><span class="day-number">26</span></div>
  <div class="calendar-day"><span class="day-number">27</span></div>

  <div class="calendar-day"><span class="day-number">28</span></div>
  <div class="calendar-day"><span class="day-number">29</span></div>
  <div class="calendar-day"><span class="day-number">30</span></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
</div>
</div>

<!-- July 2026 -->
<div class="cal-month" id="cal-2026-07" data-year="2026" data-month="6" style="display:none">
<div class="calendar-grid">
  <div class="calendar-day-header">Sun</div>
  <div class="calendar-day-header">Mon</div>
  <div class="calendar-day-header">Tue</div>
  <div class="calendar-day-header">Wed</div>
  <div class="calendar-day-header">Thu</div>
  <div class="calendar-day-header">Fri</div>
  <div class="calendar-day-header">Sat</div>

  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day"><span class="day-number">1</span></div>
  <div class="calendar-day"><span class="day-number">2</span></div>
  <div class="calendar-day"><span class="day-number">3</span></div>
  <div class="calendar-day"><span class="day-number">4</span></div>

  <div class="calendar-day"><span class="day-number">5</span></div>
  <div class="calendar-day"><span class="day-number">6</span></div>
  <div class="calendar-day"><span class="day-number">7</span></div>
  <div class="calendar-day"><span class="day-number">8</span></div>
  <div class="calendar-day"><span class="day-number">9</span></div>
  <div class="calendar-day"><span class="day-number">10</span></div>
  <div class="calendar-day"><span class="day-number">11</span></div>

  <div class="calendar-day"><span class="day-number">12</span></div>
  <div class="calendar-day"><span class="day-number">13</span></div>
  <div class="calendar-day"><span class="day-number">14</span></div>
  <div class="calendar-day"><span class="day-number">15</span></div>
  <div class="calendar-day"><span class="day-number">16</span></div>
  <div class="calendar-day"><span class="day-number">17</span></div>
  <div class="calendar-day"><span class="day-number">18</span></div>

  <div class="calendar-day"><span class="day-number">19</span></div>
  <div class="calendar-day"><span class="day-number">20</span></div>
  <div class="calendar-day"><span class="day-number">21</span></div>
  <div class="calendar-day"><span class="day-number">22</span></div>
  <div class="calendar-day"><span class="day-number">23</span></div>
  <div class="calendar-day"><span class="day-number">24</span></div>
  <div class="calendar-day"><span class="day-number">25</span></div>

  <div class="calendar-day"><span class="day-number">26</span></div>
  <div class="calendar-day"><span class="day-number">27</span></div>
  <div class="calendar-day"><span class="day-number">28</span></div>
  <div class="calendar-day"><span class="day-number">29</span></div>
  <div class="calendar-day"><span class="day-number">30</span></div>
  <div class="calendar-day"><span class="day-number">31</span></div>
  <div class="calendar-day empty"></div>
</div>
</div>

<!-- August 2026 -->
<div class="cal-month" id="cal-2026-08" data-year="2026" data-month="7" style="display:none">
<div class="calendar-grid">
  <div class="calendar-day-header">Sun</div>
  <div class="calendar-day-header">Mon</div>
  <div class="calendar-day-header">Tue</div>
  <div class="calendar-day-header">Wed</div>
  <div class="calendar-day-header">Thu</div>
  <div class="calendar-day-header">Fri</div>
  <div class="calendar-day-header">Sat</div>

  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day"><span class="day-number">1</span></div>
  <div class="calendar-day"><span class="day-number">2</span></div>

  <div class="calendar-day"><span class="day-number">3</span></div>
  <div class="calendar-day"><span class="day-number">4</span></div>
  <div class="calendar-day"><span class="day-number">5</span></div>
  <div class="calendar-day"><span class="day-number">6</span></div>
  <div class="calendar-day"><span class="day-number">7</span></div>
  <div class="calendar-day"><span class="day-number">8</span></div>
  <div class="calendar-day"><span class="day-number">9</span></div>

  <div class="calendar-day"><span class="day-number">10</span></div>
  <div class="calendar-day"><span class="day-number">11</span></div>
  <div class="calendar-day"><span class="day-number">12</span></div>
  <div class="calendar-day"><span class="day-number">13</span></div>
  <div class="calendar-day"><span class="day-number">14</span></div>
  <div class="calendar-day"><span class="day-number">15</span></div>
  <div class="calendar-day"><span class="day-number">16</span></div>

  <div class="calendar-day"><span class="day-number">17</span></div>
  <div class="calendar-day"><span class="day-number">18</span></div>
  <div class="calendar-day"><span class="day-number">19</span></div>
  <div class="calendar-day"><span class="day-number">20</span></div>
  <div class="calendar-day"><span class="day-number">21</span></div>
  <div class="calendar-day"><span class="day-number">22</span></div>
  <div class="calendar-day"><span class="day-number">23</span></div>

  <div class="calendar-day"><span class="day-number">24</span></div>
  <div class="calendar-day"><span class="day-number">25</span></div>
  <div class="calendar-day"><span class="day-number">26</span></div>
  <div class="calendar-day"><span class="day-number">27</span></div>
  <div class="calendar-day"><span class="day-number">28</span></div>
  <div class="calendar-day"><span class="day-number">29</span></div>
  <div class="calendar-day"><span class="day-number">30</span></div>

  <div class="calendar-day"><span class="day-number">31</span></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
  <div class="calendar-day empty"></div>
</div>
</div>

<script>
(function() {
  // ====== SET DEFAULT MONTH HERE ======
  // Format: "YYYY-MM" (e.g. "2026-06" for June 2026)
  // The calendar will start on this month. If not found, falls back to index 0.
  var DEFAULT_MONTH = "2026-06";
  // ====================================

  var MONTH_NAMES = ["January","February","March","April","May","June","July","August","September","October","November","December"];
  var months = document.querySelectorAll(".cal-month");
  var titleEl = document.getElementById("cal-month-title");
  var currentIdx = 0;

  function showMonth(idx) {
    if (idx < 0) idx = 0;
    if (idx >= months.length) idx = months.length - 1;
    currentIdx = idx;
    for (var i = 0; i < months.length; i++) {
      months[i].style.display = (i === idx) ? "" : "none";
    }
    var y = months[idx].getAttribute("data-year");
    var m = parseInt(months[idx].getAttribute("data-month"));
    titleEl.textContent = MONTH_NAMES[m] + " " + y;
  }

  // Find the month matching DEFAULT_MONTH
  var parts = DEFAULT_MONTH.split("-");
  var targetYear = parts[0];
  var targetMonth = parseInt(parts[1]) - 1; // 0-based
  var foundIdx = -1;
  for (var i = 0; i < months.length; i++) {
    if (months[i].getAttribute("data-year") === targetYear &&
        parseInt(months[i].getAttribute("data-month")) === targetMonth) {
      foundIdx = i;
      break;
    }
  }
  showMonth(foundIdx >= 0 ? foundIdx : 0);

  document.getElementById("cal-prev").addEventListener("click", function() { showMonth(currentIdx - 1); });
  document.getElementById("cal-next").addEventListener("click", function() { showMonth(currentIdx + 1); });
})();
</script>

---

## Upcoming Events

<div class="events-list">
  <a href="/events/2026/01/15-release-party.html" class="event-card reveal">
    <div class="event-date">
      <div class="event-day">15</div>
      <div class="event-month">Jan 2026</div>
    </div>
    <div class="event-details">
      <div class="event-meta">
        <span class="event-type-badge badge-release">Release</span>
        <span>&#127758; Virtual &bull; 6:00 PM UTC</span>
      </div>
      <h3>sHEL v1.0 Release Party</h3>
      <p>Join us to celebrate the v1.0 release! We'll demo new features, share the roadmap, and hang out with the community.</p>
    </div>
  </a>

  <a href="/events/2026/02/22-workshop-pipelines.html" class="event-card reveal reveal-delay-1">
    <div class="event-date">
      <div class="event-day">22</div>
      <div class="event-month">Feb 2026</div>
    </div>
    <div class="event-details">
      <div class="event-meta">
        <span class="event-type-badge badge-workshop">Workshop</span>
        <span>&#128205; San Francisco, CA &bull; 10:00 AM PST</span>
      </div>
      <h3>sHEL Workshop: Building Data Pipelines</h3>
      <p>A hands-on workshop covering advanced pipeline patterns, performance tuning, and real-world use cases.</p>
    </div>
  </a>

  <a href="/events/2026/03/20-meetup-5.html" class="event-card reveal reveal-delay-2">
    <div class="event-date">
      <div class="event-day">20</div>
      <div class="event-month">Mar 2026</div>
    </div>
    <div class="event-details">
      <div class="event-meta">
        <span class="event-type-badge badge-meetup">Meetup</span>
        <span>&#127758; Virtual &bull; 3:00 PM UTC</span>
      </div>
      <h3>Community Meetup #5</h3>
      <p>Monthly community catchup. Discussion on schema validation, new plugin API, and community contributions.</p>
    </div>
  </a>

  <a href="/events/2026/04/22-workshop-schema.html" class="event-card reveal">
    <div class="event-date">
      <div class="event-day">22</div>
      <div class="event-month">Apr 2026</div>
    </div>
    <div class="event-details">
      <div class="event-meta">
        <span class="event-type-badge badge-workshop">Workshop</span>
        <span>&#128205; Berlin, Germany &bull; 2:00 PM CET</span>
      </div>
      <h3>Spring Workshop: Schema Design</h3>
      <p>Deep dive into sHEL schema design patterns, validation strategies, and performance optimization.</p>
    </div>
  </a>
</div>

## Past Events

<div class="events-list">
  <a href="/events/2025/11/10-dataengconf.html" class="event-card reveal">
    <div class="event-date">
      <div class="event-day">10</div>
      <div class="event-month">Nov 2025</div>
    </div>
    <div class="event-details">
      <div class="event-meta">
        <span class="event-type-badge badge-conference">Conference</span>
        <span>&#128205; Berlin, Germany</span>
      </div>
      <h3>sHEL at DataEngConf</h3>
      <p>Presentation on "Literal-Safe Data Substrates: A New Approach" with live demos and Q&A.</p>
    </div>
  </a>

  <a href="/events/2025/09/05-meetup-3.html" class="event-card reveal reveal-delay-1">
    <div class="event-date">
      <div class="event-day">05</div>
      <div class="event-month">Sep 2025</div>
    </div>
    <div class="event-details">
      <div class="event-meta">
        <span class="event-type-badge badge-meetup">Meetup</span>
        <span>&#127758; Virtual</span>
      </div>
      <h3>Community Meetup #3</h3>
      <p>Monthly community catchup. Discussion on schema validation, new plugin API, and community contributions.</p>
    </div>
  </a>

  <a href="/events/2025/08/12-office-hours-12.html" class="event-card reveal reveal-delay-2">
    <div class="event-date">
      <div class="event-day">12</div>
      <div class="event-month">Aug 2025</div>
    </div>
    <div class="event-details">
      <div class="event-meta">
        <span class="event-type-badge badge-office-hours">Office Hours</span>
        <span>&#127758; Virtual &bull; 4:00 PM UTC</span>
      </div>
      <h3>sHEL Office Hours #12</h3>
      <p>Open Q&A with the core team. Bring your questions about schema design, performance, or contribution.</p>
    </div>
  </a>
</div>
"""

let render() = file
