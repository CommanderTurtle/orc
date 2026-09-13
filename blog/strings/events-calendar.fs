module EventsCalendar

type Receipt = {
    Date: string
    Title: string
    Url: string
    Note: string
    IsPost: bool
    IsLife: bool
}

let esc (s: string) =
    s.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;")

let private postRow (d: string) (t: string) (u: string) : Receipt =
    { Date = d; Title = t; Url = u; Note = ""; IsPost = true; IsLife = false }

let private repoRow (d: string) (name: string) (tagline: string) : Receipt =
    { Date = d; Title = name + " — " + tagline; Url = "https://github.com/CommanderTurtle/" + name; Note = ""; IsPost = false; IsLife = false }

let private lifeRow (d: string) (t: string) (u: string) (note: string) : Receipt =
    { Date = d; Title = t; Url = u; Note = note; IsPost = false; IsLife = true }

let private receipts: Receipt list = [
    // Blog posts (dates from Jekyll frontmatter)
    postRow "2025-11-01" "adspace: The Redirect Engine That Could (Still)" "/blog/2025-11-01-adspace/"
    postRow "2026-06-05" "Gemma 4 on Blackwell: A Three-Act Saga of Pain and Glory" "/blog/2026-06-05-gemma4-blackwell-nvfp4/"
    postRow "2026-06-11" "macrohard & macrohelp: Not Your Average Macro Extension" "/blog/2026-06-11-macrohard/"
    postRow "2026-06-20" "2FAgamblah: The Casino You Have to Beat to Log In" "/blog/2026-06-20-captcha-side-project/"
    postRow "2026-06-20" "Introducing sHEL: All the Protection of a Turtle, Without the Soft Underbelly" "/blog/2026-06-20-introducing-shel/"
    postRow "2026-07-27" "Deep Dive: The sHEL Schema System — A Database Engine in Your Clipboard" "/blog/2026-07-27-shel-schema-deep-dive/"
    postRow "2026-07-28" "countku: A Number System More Convoluted Than All Prime Numbers" "/blog/2026-07-28-countku-side-project/"
    postRow "2026-07-26" "retrieval: The Skill Labrador" "/blog/2026-07-26-retrieval/"
    postRow "2026-05-25" "F# as a Deployment Engine: From Material for MkDocs to Zensical" "/blog/2026-05-25-fsharp-zensical/"
    postRow "2026-06-08" "So I Rewrote the Windows Registry in Rust" "/blog/2026-06-08-regedited/"
    postRow "2026-07-16" "firebending: The Model Server That Waits For You" "/blog/2026-07-16-firebending/"
    postRow "2026-08-04" "leetcoder: Puppeteering, With Receipts" "/blog/2026-08-04-leetcoder/"
    postRow "2026-07-26" "librarian: The Wikifier That Dreams" "/blog/2026-07-26-librarian/"
    postRow "2026-08-04" "persephone: The Gateway That Is Not a Harness" "/blog/2026-08-04-persephone/"
    postRow "2026-08-27" "localflame: The Web Search That Never Calls Home" "/blog/2026-08-27-localflame/"
    postRow "2026-08-23" "seamingly-epic: The Math That Hides The Join Lines" "/blog/2026-08-23-seamingly-epic/"
    postRow "2026-09-01" "vitality: Giving Source To Projects That Refuse To Have Any" "/blog/2026-09-01-vitality/"
    postRow "2026-09-01" "radio: A Desktop QML World, Shipped As Static Files" "/blog/2026-09-01-radio/"
    postRow "2026-09-02" "mk.it: Private Browser-Based Conversion, OCR, Base64, and Archive Tools" "/blog/2026-09-02-mk-it/"
    postRow "2026-08-08" "vox: The Fork That Became An Audio Backbone" "/blog/2026-08-08-vox/"
    postRow "2026-07-25" "diogenes: Bloated with Materialism, Nihilistic in Theory" "/blog/2026-07-25-diogenes/"
    postRow "2026-09-02" "llm: A Chat Interface With No Backend To Own" "/blog/2026-09-02-llm/"
    postRow "2026-09-01" "ln.kr: The Shortest URL That Is Also A Document" "/blog/2026-09-01-ln-kr/"
    postRow "2026-08-10" "mm-tools: Cutting Out The Cloud" "/blog/2026-08-10-mm-tools/"
    postRow "2026-06-20" "orc: The Cross-Repo Pages Orchestrator Behind sHEL" "/blog/2026-06-20-orc/"
    postRow "2026-07-28" "preview: The Deploy Topology, Rehearsed At Home" "/blog/2026-07-28-preview/"
    postRow "2026-07-26" "sandwich: An Oven Factory" "/blog/2026-07-26-sandwich/"
    postRow "2026-09-12" "context-mode: The Other Half of the Context Problem" "/blog/2026-09-12-context-mode/"
    // Repository launches (dates from GitHub creation records; the two blank Skyrim forks are excluded)
    repoRow "2026-02-21" "hacker-turtle" "Hacker is a Jekyll theme for GitHub Pages"
    repoRow "2026-05-02" "aemki-git-wiki" "05-02-2026 snapshot archive"
    repoRow "2026-05-25" "fsharp-material" "F# Material for MkDocs"
    repoRow "2026-06-08" "fsharp-zensical" "F# Zensical for Github Pages"
    repoRow "2026-06-08" "regedited" "dangerously grep a million-line markdown file"
    repoRow "2026-06-11" "macrohard" "not your average macro extension"
    repoRow "2026-06-15" "bumblebee" "speak like bumblebee"
    repoRow "2026-06-16" "macrohelp" "a small json writer helping record Tasket++ flows at scale"
    repoRow "2026-06-20" "orc" "fsharp webapp orchestrator"
    repoRow "2026-07-21" "context-mode" "Context window optimization for AI coding agents. Sandboxes tool output (98% reduction), persists session memory, and enforces routing across 17 platforms via MCP + hooks."
    repoRow "2026-07-26" "sandwich" "delicious bread only"
    repoRow "2026-07-27" "diogenes" "bloated with materialism, nihilistic in theory."
    repoRow "2026-07-27" "librarian" "A Hermes JSON-RPC fork of thecodacus/understory"
    repoRow "2026-07-27" "retrieval" "golden retriever for hermes agent"
    repoRow "2026-07-28" "preview" "a previewer for fsharp orchestrator"
    repoRow "2026-07-28" "reactor" "a small rust reactor for fsharp rendering"
    repoRow "2026-07-28" "tools" "miscellaneous tools for F# site QoL"
    repoRow "2026-08-05" "leetcoder" "A Hermes native MCP for puppeteering Oh-My-Pi"
    repoRow "2026-08-05" "persephone" "OGGGG-GCL for Oh-My-Pi"
    repoRow "2026-08-08" "vox" "Fork -- windward47--vox"
    repoRow "2026-08-10" "ideogram4" "Fork--ideogram-oss--ideogram4"
    repoRow "2026-08-10" "mm-tools" "Multimedia Frontend Wrappers for AI tooling"
    repoRow "2026-08-14" "firebending" "you're the /v1/chat/completions"
    repoRow "2026-08-24" "seamingly-epic" "A native rust program built for 8192x8192 (or higher) grid seamline removal for Nvidia Pixel DiT."
    repoRow "2026-08-27" "localflame" "A native DSH web-search/web-query patch for locally hosted Firecrawl"
    repoRow "2026-09-02" "ln.kr" "A static previewer inspired by ha.mr compression"
    repoRow "2026-09-02" "mk.it" "Make.It, inspired by convert.to.it, adding markdown combination, OCR, and extra conversion additions"
    repoRow "2026-09-02" "omarchy-webapp-shell" "usage of plugin store requires omarchy? Why not just webapp?"
    repoRow "2026-09-02" "vitality" "a vitification process, gifting vitality upon any node"
    repoRow "2026-09-03" "llm" "a native js harness for local models, on a static page. Inbuilt OCR and AnyDoc"
    // Life events (recovered from memory, cross-checked against the public record)
    lifeRow "2026-02-21" "First Site Online: Forking the Hacker Theme" "/events/first-site-online/" "The first public site ships on a fork of the GitHub Pages Hacker theme."
    lifeRow "2026-03-22" "Ninety-Nine-Ninety: A Ski Week in Park City" "/events/ninety-nine-ninety-ski-week/" "Ski week in Park City, mid wind-down of the record-low-snow season."
    lifeRow "2026-04-20" "AI Engineer Miami: Two Days in ER Glasses" "/events/ai-engineer-miami/" "First two days of AI Engineer Miami, opening Frontier Tech Week."
]

/// Posts sort first within a day, then repo launches, then life events.
let private rank (r: Receipt) = if r.IsPost then 0 elif r.IsLife then 2 else 1

let calendarHtml () : string =
    let sorted = receipts |> List.sortBy (fun r -> (r.Date, rank r, r.Title))
    let byDay = sorted |> List.groupBy (fun r -> r.Date)
    let minDate = receipts |> List.minBy (fun r -> r.Date) |> fun r -> r.Date
    let maxDate = receipts |> List.maxBy (fun r -> r.Date) |> fun r -> r.Date
    let monthOf (d: string) = d.Substring(0, 7)
    let months =
        let rec walk y m acc =
            let key = sprintf "%04d-%02d" y m
            if key > maxDate.Substring(0, 7) then
                List.rev acc
            else
                walk (if m = 12 then y + 1 else y) (if m = 12 then 1 else m + 1) (key :: acc)
        walk (int (minDate.Substring(0, 4))) (int (minDate.Substring(5, 2))) []
    let names = [ "January"; "February"; "March"; "April"; "May"; "June"; "July"; "August"; "September"; "October"; "November"; "December" ]
    let abbr = [ "Jan"; "Feb"; "Mar"; "Apr"; "May"; "Jun"; "Jul"; "Aug"; "Sep"; "Oct"; "Nov"; "Dec" ]
    let dayLabel (d: string) = sprintf "%s %02d" abbr.[int (d.Substring(5, 2)) - 1] (int (d.Substring(8, 2)))
    let monthTitle (key: string) = sprintf "%s %d" names.[int (key.Substring(5, 2)) - 1] (int (key.Substring(0, 4)))
    let itemHtml (r: Receipt) =
        let cls = if r.IsPost then "ev-post" elif r.IsLife then "ev-life" else "ev-repo"
        let dot = if r.IsPost then "ev-dot-post" elif r.IsLife then "ev-dot-life" else "ev-dot-repo"
        let titleAttr = if String.IsNullOrEmpty(r.Note) then "" else sprintf " title=\"%s\"" (esc r.Note)
        sprintf "<a class=\"ev-link %s\" href=\"%s\"%s><i class=\"ev-dot %s\"></i>%s</a>" cls (esc r.Url) titleAttr dot (esc r.Title)
    let parts = ResizeArray<string>()
    for month in months do
        let days = byDay |> List.filter (fun (day, _) -> monthOf day = month)
        parts.Add(sprintf "<section class=\"ev-month\"><h3>%s</h3>" (monthTitle month))
        if days.IsEmpty then
            parts.Add("<p class=\"ev-quiet\">Quiet.</p>")
        else
            for day, rs in days do
                let items = rs |> List.map itemHtml |> String.concat ""
                parts.Add(sprintf "<div class=\"ev-day\"><span class=\"ev-date\">%s</span><span class=\"ev-items\">%s</span></div>" (dayLabel day) items)
        parts.Add("</section>")
    String.concat "\n" parts + "\n"

type CalEvent = { Date: string; Title: string; Url: string; Color: string }

let private eventColor (r: Receipt) = if r.IsPost then "#EAB33D" elif r.IsLife then "#22C55E" else "#5B8DB8"

let private calEvents: CalEvent list =
    receipts
    |> List.map (fun r -> { Date = r.Date; Title = r.Title; Url = r.Url; Color = eventColor r })

let private jsonEscape (s: string) = s.Replace("\"", "\\\"").Replace("'", "\u2019")
let private attrEscape (s: string) = s.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;")

let private eventJson (evs: CalEvent list) =
    let row (e: CalEvent) =
        let url = if String.IsNullOrEmpty e.Url then "#" else e.Url
        sprintf "{\"title\":\"%s\",\"url\":\"%s\",\"color\":\"%s\"}" (jsonEscape e.Title) (jsonEscape url) e.Color
    attrEscape ("[" + (evs |> List.map row |> String.concat ",") + "]")

let private monthsBetween (sy0: int) (sm0: int) (ey: int) (em: int) =
    let acc = ResizeArray<int * int>()
    let mutable y = sy0
    let mutable m = sm0
    while compare (y, m) (ey, em) <= 0 do
        acc.Add((y, m))
        if m = 12 then (y <- y + 1; m <- 1) else (m <- m + 1)
    acc |> Seq.toList

let private monthGrid (y: int) (m: int) (byDay: Map<int, CalEvent list>) (visible: bool) =
    let first = DateTime(y, m, 1)
    let lead = int first.DayOfWeek
    let dim = DateTime.DaysInMonth(y, m)
    let cells = ResizeArray<string>()
    for _ in 0 .. lead - 1 do
        cells.Add("<div class=\"calendar-day empty\"></div>")
    for d in 1 .. dim do
        match byDay.TryFind d with
        | Some evs ->
            let dots =
                evs
                |> List.map (fun e -> sprintf "<span class=\"event-dot\" style=\"background:%s\"></span>" e.Color)
                |> String.concat ""
            cells.Add(
                sprintf "<div class=\"calendar-day\" data-events='%s'><span class=\"day-number\">%d</span><div class=\"event-dots\">%s</div></div>"
                    (eventJson evs) d dots)
        | None ->
            cells.Add(sprintf "<div class=\"calendar-day\"><span class=\"day-number\">%d</span></div>" d)
    let headers =
        [ "Sun"; "Mon"; "Tue"; "Wed"; "Thu"; "Fri"; "Sat" ]
        |> List.map (fun h -> sprintf "<div class=\"calendar-day-header\">%s</div>" h)
        |> String.concat ""
    let styleAttr = if visible then "" else " style=\"display:none\""
    sprintf "<!-- %04d-%02d -->\n<div class=\"cal-month\" id=\"cal-%04d-%02d\" data-year=\"%d\" data-month=\"%d\"%s>\n<div class=\"calendar-grid\">\n%s\n%s\n</div>\n</div>"
        y m y m y m styleAttr headers (String.concat "\n" cells)

let private core () : string * string * string =
    let now = DateTime.UtcNow
    let dataMax =
        calEvents
        |> List.maxBy (fun e -> e.Date)
        |> fun e -> (int (e.Date.Substring(0, 4)), int (e.Date.Substring(5, 2)))
    let nowYm = (now.Year, now.Month)
    let cmp (ay, am) (by, bm) =
        match compare ay by with
        | 0 -> compare am bm
        | c -> c
    let endYm = if (cmp nowYm dataMax) > 0 then nowYm else dataMax
    let startYm = (2025, 11)
    let defaultYm = if (cmp nowYm startYm) >= 0 && (cmp nowYm endYm) <= 0 then nowYm else endYm
    let (sy, sm) = startYm
    let (ey, em) = endYm
    let (dy, dm) = defaultYm
    let ms = monthsBetween sy sm ey em
    let byMonth = calEvents |> List.groupBy (fun e -> e.Date.Substring(0, 7)) |> Map.ofList
    let lookup (key: string) =
        match byMonth.TryFind key with
        | Some evs -> evs |> List.groupBy (fun e -> int (e.Date.Substring(8, 2))) |> Map.ofList
        | None -> Map.empty
    let defKey = sprintf "%04d-%02d" dy dm
    let names = [ "January"; "February"; "March"; "April"; "May"; "June"; "July"; "August"; "September"; "October"; "November"; "December" ]
    let defTitle = sprintf "%s %d" names.[dm - 1] dy
    let grids =
        ms
        |> List.map (fun (y, m) ->
            let key = sprintf "%04d-%02d" y m
            monthGrid y m (lookup key) (key = defKey))
        |> String.concat "\n\n"
    (defTitle, grids, defKey)

/// Month navigation script. Ids must be unique per page; this site renders one
/// calendar, inline on the events page.
let private calendarScript (defKey: string) : string =
    let scriptText = """
<script>
(function() {
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
    titleEl.textContent = MONTH_NAMES[m - 1] + " " + y;
  }

  var DEFAULT_MONTH = "__DEF__";
  var parts = DEFAULT_MONTH.split("-");
  var targetYear = parts[0];
  var targetMonth = parseInt(parts[1]);
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
"""
    scriptText.Replace("__DEF__", defKey)

/// Collapsed inline calendar: the original baseline visual (arrow controls,
/// month title, legend, pre-rendered grids, day popups) wrapped in a
/// <details> block. No iframe, so no nested document and no scroll trap.
let calendarBlock () : string =
    let (defTitle, grids, defKey) = core()
    let controlsTpl =
        """<div class="calendar-controls" style="display:flex;align-items:center;justify-content:center;gap:20px;margin-bottom:20px;">
  <button id="cal-prev" aria-label="Previous month" style="display:flex;align-items:center;justify-content:center;width:36px;height:36px;border-radius:var(--radius-sm);border:1px solid var(--border-primary);background:var(--bg-card);color:var(--text-secondary);cursor:pointer;transition:all 0.2s;">
    <svg viewBox="0 0 16 16" fill="none" stroke="currentColor" stroke-width="2" style="width:16px;height:16px;"><path d="M10 3L5 8l5 5"/></svg>
  </button>
  <h3 id="cal-month-title" style="font-size:1.25rem;font-weight:600;color:var(--text-primary);margin:0;min-width:180px;text-align:center;">%TITLE%</h3>
  <button id="cal-next" aria-label="Next month" style="display:flex;align-items:center;justify-content:center;width:36px;height:36px;border-radius:var(--radius-sm);border:1px solid var(--border-primary);background:var(--bg-card);color:var(--text-secondary);cursor:pointer;transition:all 0.2s;">
    <svg viewBox="0 0 16 16" fill="none" stroke="currentColor" stroke-width="2" style="width:16px;height:16px;"><path d="M6 3l5 5-5 5"/></svg>
  </button>
</div>

<p class="ev-cal-hint">Days with events show colored dots &mdash; click a day to see its entries. Use the arrow buttons to navigate months.</p>

<div class="calendar-legend">
  <span class="legend-item"><span class="legend-dot" style="background: #EAB33D;"></span>Blog post</span>
  <span class="legend-item"><span class="legend-dot" style="background: #5B8DB8;"></span>Repo launch</span>
  <span class="legend-item"><span class="legend-dot" style="background: #22C55E;"></span>Life event</span>
</div>"""
    let controls = controlsTpl.Replace("%TITLE%", defTitle)
    """<details class="ev-cal">
<summary>Expand Calendar</summary>
<div class="ev-cal-body">
"""
    + controls
    + "\n"
    + grids
    + "\n"
    + calendarScript defKey
    + """
</div>
</details>
"""
