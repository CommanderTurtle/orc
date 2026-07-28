module CountkuWorlds

open System.Text.Encodings.Web
open System.Text.Json

// The first 21 worlds are explicit five-landing art direction. Dark Crossing
// owns 100–104; deterministic compound worlds begin exactly at 105.

type WorldPalette = {
    accent: string
    accentSoft: string
    gold: string
    mint: string
    moon: string
    panel: string
    line: string
    glowA: string
    glowB: string
    top: string
    middle: string
    bottom: string
    treeFilter: string
}

type WorldEntry = {
    id: string
    minimum: int
    label: string
    sigil: string
    description: string
    palette: WorldPalette
}

let private palette
    accent accentSoft gold mint moon panel line
    glowA glowB top middle bottom treeFilter =
    {
        accent = accent
        accentSoft = accentSoft
        gold = gold
        mint = mint
        moon = moon
        panel = panel
        line = line
        glowA = glowA
        glowB = glowB
        top = top
        middle = middle
        bottom = bottom
        treeFilter = treeFilter
    }

let private world
    id minimum label sigil description palette =
    {
        id = id
        minimum = minimum
        label = label
        sigil = sigil
        description = description
        palette = palette
    }

// The first twenty-one worlds are deliberately authored. At 105 and beyond,
// Countku switches to a deterministic adjective/noun registry and golden-angle
// color walk, so the trail can continue forever without changing a save.
let private authoredWorlds =
    [
        world "sakura-trail" 0 "Sakura Trail" "桜"
            "The native pink trail: quiet petals, first landings, and an open road."
            (palette "#ff83b8" "#ffd0e3" "#ffd57a" "#8ff0cd" "#d9e3ff"
                "rgba(17, 17, 41, 0.94)" "rgba(211, 220, 255, 0.17)"
                "rgba(113, 127, 230, 0.18)" "rgba(255, 107, 161, 0.15)"
                "#0b0b1c" "#171830" "#29182f"
                "saturate(0.82) hue-rotate(12deg) contrast(1.12)")

        world "white-forest" 5 "White Forest" "白"
            "Pale leaves and young green light make the first change unmistakable."
            (palette "#ecfff7" "#ffffff" "#f3e7a4" "#9ee8c7" "#eaf4ff"
                "rgba(9, 25, 24, 0.95)" "rgba(227, 255, 246, 0.2)"
                "rgba(213, 255, 240, 0.18)" "rgba(152, 226, 190, 0.15)"
                "#071513" "#102723" "#1a332c"
                "grayscale(0.5) sepia(0.18) hue-rotate(72deg) brightness(1.22)")

        world "lantern-vale" 10 "Lantern Vale" "灯"
            "A warm path begins answering the player with its own light."
            (palette "#ffbc76" "#ffe7bd" "#ffd16c" "#9ce7cc" "#e8efff"
                "rgba(31, 19, 20, 0.95)" "rgba(255, 222, 184, 0.18)"
                "rgba(255, 169, 87, 0.21)" "rgba(142, 220, 195, 0.11)"
                "#170b11" "#2c181a" "#3a2520"
                "sepia(0.46) hue-rotate(326deg) saturate(1.18)")

        world "cedar-echo" 15 "Cedar Echo" "杉"
            "Deep wood, restrained gold, and a score that leaves room for breath."
            (palette "#9dd6ad" "#e1f4dc" "#e8c978" "#8ed9c7" "#d6e6f2"
                "rgba(10, 24, 21, 0.95)" "rgba(205, 240, 219, 0.17)"
                "rgba(87, 164, 120, 0.2)" "rgba(214, 177, 91, 0.1)"
                "#07120e" "#13241b" "#243126"
                "sepia(0.26) hue-rotate(82deg) saturate(0.86)")

        world "amber-steppe" 20 "Amber Steppe" "琥"
            "The first full score movement opens beneath a long amber horizon."
            (palette "#eeb66b" "#ffe6b5" "#ffd487" "#a6e0c4" "#e7e7dd"
                "rgba(29, 20, 12, 0.95)" "rgba(255, 222, 170, 0.18)"
                "rgba(242, 169, 73, 0.21)" "rgba(176, 222, 181, 0.1)"
                "#160f08" "#2d2112" "#41331c"
                "sepia(0.65) hue-rotate(343deg) saturate(1.02)")

        world "maple-passage" 25 "Maple Passage" "楓"
            "Copper leaves turn the trail into a deliberate autumn crossing."
            (palette "#ff9677" "#ffe0d0" "#ffc96d" "#a7dfc6" "#f3dfdf"
                "rgba(34, 15, 19, 0.95)" "rgba(255, 209, 195, 0.18)"
                "rgba(255, 121, 91, 0.2)" "rgba(206, 76, 111, 0.13)"
                "#190a10" "#321923" "#42271f"
                "sepia(0.52) hue-rotate(323deg) saturate(1.3)")

        world "indigo-harbor" 30 "Indigo Harbor" "藍"
            "A cool harbor receives the rhythm and reflects it in slower waves."
            (palette "#a9b7ff" "#e3e8ff" "#cad6ff" "#85dfd0" "#dce8ff"
                "rgba(9, 12, 35, 0.95)" "rgba(198, 210, 255, 0.18)"
                "rgba(94, 113, 244, 0.22)" "rgba(89, 208, 221, 0.11)"
                "#05081a" "#101838" "#18274c"
                "grayscale(0.16) hue-rotate(38deg) saturate(0.76)")

        world "silver-orchard" 35 "Silver Orchard" "銀"
            "Moonlit branches sharpen the contrast without losing the bloom."
            (palette "#dce7f0" "#ffffff" "#e9d7a0" "#a9e6d3" "#f1f7ff"
                "rgba(13, 18, 27, 0.95)" "rgba(230, 240, 250, 0.19)"
                "rgba(191, 214, 235, 0.18)" "rgba(151, 225, 207, 0.1)"
                "#090d14" "#161e2a" "#28313a"
                "grayscale(0.72) hue-rotate(32deg) brightness(1.12)")

        world "vermilion-gate" 40 "Vermilion Gate" "朱"
            "A bright threshold introduces a firmer pulse and ceremonial red."
            (palette "#ff776c" "#ffd2c9" "#ffcf72" "#8ed9bd" "#f3dde3"
                "rgba(34, 9, 14, 0.95)" "rgba(255, 190, 184, 0.19)"
                "rgba(255, 76, 66, 0.22)" "rgba(236, 153, 71, 0.12)"
                "#1a060b" "#350f17" "#48221b"
                "sepia(0.48) hue-rotate(318deg) saturate(1.45)")

        world "quiet-tundra" 45 "Quiet Tundra" "静"
            "The road widens into cold air, muted edges, and patient silence."
            (palette "#b9dcf5" "#eaf7ff" "#e5ddaa" "#a6e1d2" "#edf7ff"
                "rgba(8, 19, 28, 0.95)" "rgba(210, 235, 250, 0.18)"
                "rgba(123, 197, 238, 0.18)" "rgba(177, 226, 220, 0.1)"
                "#061019" "#102635" "#1b3541"
                "grayscale(0.38) hue-rotate(43deg) saturate(0.7) brightness(1.08)")

        world "moon-garden" 50 "Moon Garden" "月"
            "An indigo garden slows the player just enough to hear every interval."
            (palette "#aebcff" "#e2e8ff" "#cddcff" "#8ed9cc" "#eef2ff"
                "rgba(8, 9, 31, 0.95)" "rgba(202, 211, 255, 0.18)"
                "rgba(87, 109, 231, 0.22)" "rgba(151, 118, 223, 0.11)"
                "#050619" "#111438" "#20224b"
                "grayscale(0.22) hue-rotate(48deg) saturate(0.78)")

        world "copper-shrine" 55 "Copper Shrine" "銅"
            "Old copper and moss create a grounded pause before the higher trail."
            (palette "#c9966a" "#efd6b9" "#e3bc6b" "#9fd6b0" "#e6dfd8"
                "rgba(24, 17, 12, 0.95)" "rgba(234, 207, 178, 0.17)"
                "rgba(183, 117, 67, 0.19)" "rgba(114, 169, 111, 0.11)"
                "#120c08" "#281c12" "#382b1d"
                "sepia(0.68) hue-rotate(338deg) saturate(0.88)")

        world "cobalt-torrent" 60 "Cobalt Torrent" "蒼"
            "Blue current drives a more restless movement through the same calm form."
            (palette "#76a8ff" "#d6e4ff" "#b8d8ff" "#7fe1d6" "#dfeaff"
                "rgba(5, 13, 36, 0.95)" "rgba(176, 202, 255, 0.18)"
                "rgba(49, 103, 237, 0.24)" "rgba(62, 206, 203, 0.12)"
                "#03091c" "#0b1b42" "#153260"
                "grayscale(0.12) hue-rotate(41deg) saturate(0.96)")

        world "jade-horizon" 65 "Jade Horizon" "翠"
            "A long jade line makes every exact landing feel newly visible."
            (palette "#82d7b6" "#dcf7eb" "#d8dc8b" "#8ce4cd" "#e2f6ef"
                "rgba(7, 27, 23, 0.95)" "rgba(190, 239, 220, 0.18)"
                "rgba(54, 184, 137, 0.21)" "rgba(187, 215, 88, 0.1)"
                "#041510" "#0d2d24" "#194438"
                "sepia(0.1) hue-rotate(88deg) saturate(1.1)")

        world "saffron-hollow" 70 "Saffron Hollow" "黄"
            "A bright hollow turns restraint into warmth without blinding the page."
            (palette "#e9c56d" "#fff0bd" "#ffd46d" "#9bdac2" "#f4ead3"
                "rgba(31, 24, 8, 0.95)" "rgba(244, 225, 171, 0.18)"
                "rgba(221, 169, 50, 0.21)" "rgba(136, 211, 176, 0.1)"
                "#171103" "#30260b" "#453719"
                "sepia(0.72) hue-rotate(356deg) saturate(1.06)")

        world "violet-summit" 75 "Violet Summit" "紫"
            "The summit brings high violet air and a melody with wider intervals."
            (palette "#c29cff" "#eadcff" "#dfc5ff" "#9fded0" "#eee5ff"
                "rgba(20, 8, 37, 0.95)" "rgba(222, 194, 255, 0.18)"
                "rgba(147, 82, 245, 0.22)" "rgba(104, 216, 204, 0.11)"
                "#0d041b" "#21103c" "#352255"
                "grayscale(0.08) hue-rotate(286deg) saturate(1.14)")

        world "frost-pavilion" 80 "Frost Pavilion" "霜"
            "Glass-cold harmonics and soft frost make the eighth movement spacious."
            (palette "#bceaff" "#ecfaff" "#d7eaff" "#9ee2d6" "#f4fbff"
                "rgba(7, 20, 31, 0.95)" "rgba(210, 239, 255, 0.18)"
                "rgba(119, 212, 250, 0.2)" "rgba(179, 232, 226, 0.1)"
                "#05121b" "#102a3a" "#1d4050"
                "grayscale(0.46) hue-rotate(38deg) saturate(0.68) brightness(1.13)")

        world "crimson-current" 85 "Crimson Current" "紅"
            "A dark red current adds tension while the underlying grammar stays exact."
            (palette "#ff667d" "#ffcbd3" "#f1bd70" "#8ad6bf" "#ead9df"
                "rgba(37, 7, 17, 0.95)" "rgba(255, 178, 193, 0.18)"
                "rgba(239, 48, 81, 0.23)" "rgba(178, 62, 113, 0.13)"
                "#1b030b" "#360a18" "#4d1721"
                "sepia(0.32) hue-rotate(307deg) saturate(1.52)")

        world "obsidian-bloom" 90 "Obsidian Bloom" "黒"
            "Nearly black petals retain a narrow line of living color."
            (palette "#d794d9" "#f1d9f2" "#d7b86c" "#86cbb4" "#dddce7"
                "rgba(9, 7, 13, 0.97)" "rgba(214, 183, 218, 0.15)"
                "rgba(137, 71, 142, 0.2)" "rgba(83, 163, 139, 0.09)"
                "#050306" "#100b12" "#211622"
                "grayscale(0.72) hue-rotate(281deg) saturate(0.72)")

        world "ashen-crown" 95 "Ashen Crown" "灰"
            "Color drains toward the crossing; only the crown keeps a warm edge."
            (palette "#c7c1bd" "#ebe6e2" "#c9ad6d" "#9fc5b4" "#dfdfe3"
                "rgba(13, 12, 13, 0.97)" "rgba(219, 214, 208, 0.15)"
                "rgba(149, 142, 137, 0.17)" "rgba(184, 145, 77, 0.08)"
                "#080708" "#171516" "#292524"
                "grayscale(0.88) sepia(0.08) brightness(0.93)")

        world "dark-crossing" 100 "Dark Crossing" "闇"
            "The trail reaches grayscale, the harmony turns ominous, and the road continues."
            (palette "#aaaeb6" "#e1e3e8" "#baa56f" "#8ea99f" "#d8dbe0"
                "rgba(5, 6, 8, 0.98)" "rgba(190, 195, 205, 0.14)"
                "rgba(103, 108, 119, 0.17)" "rgba(142, 123, 83, 0.07)"
                "#020304" "#090b0e" "#15171b"
                "grayscale(1) contrast(1.15) brightness(0.72)")
    ]

let private prefixes =
    [
        "Silent"; "Solar"; "Verdant"; "Frosted"; "Obsidian"
        "Velvet"; "Cobalt"; "Golden"; "Lunar"; "Scarlet"
        "Glass"; "Distant"; "Cedar"; "Ivory"; "Ember"
        "Hidden"; "Radiant"; "Dusky"; "Astral"; "Wild"
    ]

let private suffixes =
    [
        "Passage"; "Forest"; "Harbor"; "Garden"; "Horizon"
        "Archive"; "Sanctum"; "Crossing"; "Orchard"; "Summit"
        "Torrent"; "Lantern"; "Threshold"; "Grove"; "Trail"
        "Valley"; "Pavilion"; "Current"; "Shrine"; "Steppe"; "Crown"
    ]

let render () =
    let options = JsonSerializerOptions()
    options.WriteIndented <- true
    options.PropertyNamingPolicy <- JsonNamingPolicy.CamelCase
    options.Encoder <- JavaScriptEncoder.UnsafeRelaxedJsonEscaping

    let authoredJson =
        JsonSerializer.Serialize(authoredWorlds |> List.toArray, options)
    let prefixesJson =
        JsonSerializer.Serialize(prefixes |> List.toArray, options)
    let suffixesJson =
        JsonSerializer.Serialize(suffixes |> List.toArray, options)

    """// Generated by Orc from sharpjs-countku-worlds.fs.
// Edit the F# source; do not hand-edit this rendered module.
const authored = __AUTHORED_JSON__;
const prefixes = __PREFIXES_JSON__;
const suffixes = __SUFFIXES_JSON__;

export const WORLD_INTERVAL = 5;
export const AUTHORED_WORLDS = Object.freeze(
  authored.map((entry) => Object.freeze({{
    ...entry,
    palette: Object.freeze(entry.palette)
  }}))
);

const normalizeCount = (value) =>
  Math.max(0, Math.floor(Number(value) || 0));

function proceduralWorld(correct) {{
  const worldIndex = Math.floor(normalizeCount(correct) / WORLD_INTERVAL);
  const proceduralIndex = Math.max(0, worldIndex - AUTHORED_WORLDS.length);
  const prefix = prefixes[proceduralIndex % prefixes.length];
  const suffix = suffixes[
    (proceduralIndex * 11 + Math.floor(proceduralIndex / 7) * 5 + 1)
      % suffixes.length
  ];
  const hue = (proceduralIndex * 137.508 + 208) % 360;
  const companion = (hue + 58) % 360;
  const warm = (hue + 122) % 360;

  return Object.freeze({{
    id: `endless-${{worldIndex}}`,
    minimum: worldIndex * WORLD_INTERVAL,
    label: `${{prefix}} ${{suffix}}`,
    sigil: "∞",
    description:
      "An endless, deterministic world generated from the road already traveled.",
    palette: Object.freeze({{
      accent: `hsl(${{hue}} 82% 72%)`,
      accentSoft: `hsl(${{hue}} 78% 89%)`,
      gold: `hsl(${{warm}} 72% 72%)`,
      mint: `hsl(${{companion}} 66% 72%)`,
      moon: `hsl(${{(hue + 24) % 360}} 48% 88%)`,
      panel: `hsla(${{hue}} 38% 8% / 0.96)`,
      line: `hsla(${{hue}} 65% 88% / 0.17)`,
      glowA: `hsla(${{hue}} 78% 62% / 0.20)`,
      glowB: `hsla(${{companion}} 66% 58% / 0.11)`,
      top: `hsl(${{hue}} 48% 5%)`,
      middle: `hsl(${{hue}} 42% 12%)`,
      bottom: `hsl(${{companion}} 36% 18%)`,
      treeFilter:
        `grayscale(0.18) hue-rotate(${{Math.round(hue - 330)}}deg) ` +
        "saturate(0.92) contrast(1.08)"
    }})
  }});
}}

export function worldForCount(correct) {{
  const count = normalizeCount(correct);
  for (let index = AUTHORED_WORLDS.length - 1; index >= 0; index -= 1) {{
    if (count >= AUTHORED_WORLDS[index].minimum) {{
      if (index === AUTHORED_WORLDS.length - 1 && count >= 105) {{
        return proceduralWorld(count);
      }}
      return AUTHORED_WORLDS[index];
    }}
  }}
  return AUTHORED_WORLDS[0];
}}

export function nextWorldForCount(correct) {{
  const count = normalizeCount(correct);
  const minimum = (Math.floor(count / WORLD_INTERVAL) + 1) * WORLD_INTERVAL;
  return worldForCount(minimum);
}}

export function applyWorldPalette(target, world) {{
  const palette = world.palette;
  const values = {{
    "--ck-sakura": palette.accent,
    "--ck-sakura-soft": palette.accentSoft,
    "--ck-gold": palette.gold,
    "--ck-mint": palette.mint,
    "--ck-moon": palette.moon,
    "--ck-panel": palette.panel,
    "--ck-line": palette.line,
    "--ck-world-glow-a": palette.glowA,
    "--ck-world-glow-b": palette.glowB,
    "--ck-world-top": palette.top,
    "--ck-world-middle": palette.middle,
    "--ck-world-bottom": palette.bottom,
    "--ck-tree-filter": palette.treeFilter
  }};
  for (const [name, value] of Object.entries(values)) {{
    target.style.setProperty(name, value);
  }}
}}
"""
    |> fun template ->
        template
            .Replace("{{", "{")
            .Replace("}}", "}")
            .Replace("__AUTHORED_JSON__", authoredJson)
            .Replace("__PREFIXES_JSON__", prefixesJson)
            .Replace("__SUFFIXES_JSON__", suffixesJson)
