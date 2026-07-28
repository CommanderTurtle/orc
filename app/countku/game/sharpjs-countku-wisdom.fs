module CountkuWisdom

open System.Text.Encodings.Web
open System.Text.Json

// This file is the large authored string bank. Keep catalogs here so
// app/countku/index.fs remains the compact host page and parser source.

type FieldLine = {
    id: string
    persona: string
    title: string
    era: string
    body: string
    sourceKind: string
    sourceLabel: string
    sourceUrl: string
}

type AdvisorTheme = {
    id: string
    persona: string
    sigil: string
    title: string
    era: string
    sourceLabel: string
    sourceUrl: string
    openings: string list
    centers: string list
    closings: string list
}

type AdvisorEntry = {
    id: string
    persona: string
    sigil: string
    category: string
    title: string
    era: string
    lines: string list
    body: string
    unlockAt: int
    sourceKind: string
    sourceLabel: string
    sourceUrl: string
    sourceAccessed: string
}

// This file is the authored string bank. The working page imports only the
// generated JavaScript module; none of these registries are copied into
// index.fs.
module FieldDialogue =
    let private scene
        id persona title era body sourceLabel sourceUrl =
        {
            id = id
            persona = persona
            title = title
            era = era
            body = body
            sourceKind = "scene"
            sourceLabel = sourceLabel
            sourceUrl = sourceUrl
        }

    let private original id persona title body =
        {
            id = id
            persona = persona
            title = title
            era = "Countku field note"
            body = body
            sourceKind = "original"
            sourceLabel = "Original Countku dialogue"
            sourceUrl = ""
        }

    // Exactly twenty brief scene lines. Each entry links back to its episode
    // transcript so the scene, speaker, and wording remain inspectable.
    let avatarScenes =
        [
            scene "avatar-pride-source" "Iroh" "The source of shame"
                "Avatar · Bitter Work"
                "Pride is not the opposite of shame, but its source."
                "Bitter Work transcript"
                "https://avatar.fandom.com/wiki/Transcript%3ABitter_Work"

            scene "avatar-many-places" "Iroh" "Many places"
                "Avatar · Bitter Work"
                "It is important to draw wisdom from many different places."
                "Bitter Work transcript"
                "https://avatar.fandom.com/wiki/Transcript%3ABitter_Work"

            scene "avatar-life-happens" "Iroh" "Wherever you are"
                "Avatar · City of Walls and Secrets"
                "Life happens wherever you are, whether you make it or not."
                "City of Walls and Secrets transcript"
                "https://avatar.fandom.com/wiki/Transcript%3ACity_of_Walls_and_Secrets"

            scene "avatar-power-overrated" "Iroh" "Power, reconsidered"
                "Avatar · The Crossroads of Destiny"
                "Perfection and power are overrated."
                "The Crossroads of Destiny transcript"
                "https://avatar.fandom.com/wiki/Transcript%3AThe_Crossroads_of_Destiny"

            scene "avatar-dark-tunnel" "Iroh" "The dark tunnel"
                "Avatar · The Crossroads of Destiny"
                "Sometimes, life is like this dark tunnel."
                "The Crossroads of Destiny transcript"
                "https://avatar.fandom.com/wiki/Transcript%3AThe_Crossroads_of_Destiny"

            scene "avatar-five-seven-five" "Macmu-Ling" "Remarkable oaf"
                "Avatar · The Tales of Ba Sing Se"
                "Five, seven, then five, syllables mark a haiku. Remarkable oaf."
                "The Tales of Ba Sing Se transcript"
                "https://avatar.fandom.com/wiki/Transcript%3AThe_Tales_of_Ba_Sing_Se"

            scene "avatar-help-another" "Iroh" "Help someone else"
                "Korra · A New Spiritual Age"
                "Sometimes the best way to solve your own problems is to help someone else."
                "A New Spiritual Age transcript"
                "https://avatar.fandom.com/wiki/Transcript%3AA_New_Spiritual_Age"

            scene "avatar-light-inside" "Iroh" "Light inside"
                "Korra · A New Spiritual Age"
                "But you have light and peace inside of you."
                "A New Spiritual Age transcript"
                "https://avatar.fandom.com/wiki/Transcript%3AA_New_Spiritual_Age"

            scene "avatar-hard-forgive" "Aang" "The harder act"
                "Avatar · The Southern Raiders"
                "It's easy to do nothing, but it's hard to forgive."
                "The Southern Raiders transcript"
                "https://avatar.fandom.com/wiki/Transcript%3AThe_Southern_Raiders"

            scene "avatar-first-healing" "Aang" "The first step"
                "Avatar · The Southern Raiders"
                "Forgiveness is the first step you have to take to begin healing."
                "The Southern Raiders transcript"
                "https://avatar.fandom.com/wiki/Transcript%3AThe_Southern_Raiders"

            scene "avatar-separation" "Guru Pathik" "The great illusion"
                "Avatar · The Guru"
                "The greatest illusion of this world is the illusion of separation."
                "The Guru transcript"
                "https://avatar.fandom.com/wiki/Transcript%3AThe_Guru"

            scene "avatar-no-despair" "Iroh" "Do not surrender"
                "Avatar · Avatar Day"
                "You must never give in to despair."
                "Avatar Day transcript"
                "https://avatar.fandom.com/wiki/Transcript%3AAvatar_Day"

            scene "avatar-give-hope" "Iroh" "Hope is given"
                "Avatar · Avatar Day"
                "In the darkest times, hope is something you give yourself."
                "Avatar Day transcript"
                "https://avatar.fandom.com/wiki/Transcript%3AAvatar_Day"

            scene "avatar-tea-stranger" "Iroh" "A true delight"
                "Avatar · The Chase"
                "Sharing tea with a fascinating stranger is one of life's true delights."
                "The Chase transcript"
                "https://avatar.fandom.com/wiki/Transcript%3AThe_Chase"

            scene "avatar-let-love-help" "Iroh" "Let love help"
                "Avatar · The Chase"
                "There is nothing wrong with letting the people who love you help you."
                "The Chase transcript"
                "https://avatar.fandom.com/wiki/Transcript%3AThe_Chase"

            scene "avatar-destiny-funny" "Iroh" "A funny thing"
                "Avatar · The Western Air Temple"
                "Destiny is a funny thing."
                "The Western Air Temple transcript"
                "https://avatar.fandom.com/wiki/Transcript%3AThe_Western_Air_Temple"

            scene "avatar-open-future" "Iroh" "An open future"
                "Avatar · The Western Air Temple"
                "You never know how things are going to work out."
                "The Western Air Temple transcript"
                "https://avatar.fandom.com/wiki/Transcript%3AThe_Western_Air_Temple"

            scene "avatar-true-mind" "Avatar Aang" "The true mind"
                "Korra · Turf Wars, Part Three"
                "The true mind can weather all the lies and illusions without being lost."
                "Turf Wars Part Three transcript"
                "https://avatar.fandom.com/wiki/Transcript%3ATurf_Wars_Part_Three"

            scene "avatar-earthly-tether" "Guru Laghima" "Become wind"
                "Korra · Enter the Void"
                "Let go your earthly tether. Enter the void. Empty and become wind."
                "Enter the Void transcript"
                "https://avatar.fandom.com/wiki/Transcript%3AEnter_the_Void"

            scene "avatar-never-angry" "Iroh" "The way home"
                "Avatar · Sozin's Comet"
                "I was never angry with you."
                "The Old Masters transcript"
                "https://avatar.fandom.com/wiki/Transcript%3ASozin%27s_Comet%2C_Part_2%3A_The_Old_Masters"
        ]

    let originals =
        [
            original "field-oak-count-now" "Professor Oak's echo"
                "A time and place"
                "Professor Oak's words echoed: “There's a time and place for everything. We count now.”"

            original "field-breath-before-proof" "The road"
                "Before the proof"
                "Breathe once. The answer is not improved by arriving tense."

            original "field-cube-eight" "The road"
                "Under the influence"
                "The cube root of eight under the influence of the power of eight, type shit."

            original "field-small-form" "The road"
                "Seventeen"
                "A tiny form can still carry an unnecessarily large idea."

            original "field-moon-math" "The road"
                "Moon arithmetic"
                "The moon has declined to show its work. Countku has filed an appeal."

            original "field-patient-root" "The road"
                "Root patience"
                "A root does not hurry. It simply keeps being correct underground."

            original "field-no-padding" "The road"
                "No padding"
                "The cleanest landing is the one that did not need extra furniture."

            original "field-ordinal-museum" "The road"
                "Old names"
                "Quartic, tessaric, tetradic: the museum gift shop remains open."

            original "field-silver-sandwich" "The road"
                "A silver sandwich"
                "Clouds have two sides. The snack situation remains mathematically unresolved."

            original "field-threshold" "The road"
                "Five more"
                "The next forest is five exact landings away. It is already choosing a color."

            original "field-sokka-six" "The road"
                "One too many"
                "A sixth syllable approaches. The bouncer has noticed."

            original "field-equation-listens" "The road"
                "Listening"
                "Say the equation plainly enough and even the forest starts counting."
        ]

    let all = avatarScenes @ originals

module AdvisorHaiku =
    let private theme
        id persona sigil title era sourceLabel sourceUrl
        openings centers closings =
        {
            id = id
            persona = persona
            sigil = sigil
            title = title
            era = era
            sourceLabel = sourceLabel
            sourceUrl = sourceUrl
            openings = openings
            centers = centers
            closings = closings
        }

    // Every line in these registries is authored to its declared 5-7-5 slot.
    // The build combines them deterministically, creating sixty-five distinct
    // advisor meetings without shipping a wall of text in the working page.
    let themes =
        [
            theme "mathematics" "Lantern Geometer" "∑" "The patient proof"
                "Euler, number, and proof"
                "Euler Archive"
                "https://eulerarchive.maa.org/"
                [
                    "Numbers cross the bridge"
                    "Patterns turn the key"
                    "Curves remember light"
                    "Proof walks without noise"
                    "Zero holds its ground"
                ]
                [
                    "Patient symbols shape the road"
                    "A pattern waits to be seen"
                    "The arc returns to its start"
                    "Old questions open new doors"
                    "Deep knowledge makes effort small"
                ]
                [
                    "The whole path grows clear"
                    "One sum, many roads"
                    "The curve bends, not truth"
                    "Exactness can sing"
                    "The pattern breathes on"
                ]

            theme "poetry" "Road Poet" "句" "The cut and the echo"
                "Bashō and the short form"
                "The Narrow Road to the Deep North"
                "https://en.wikisource.org/wiki/The_Narrow_Road_to_the_Deep_North"
                [
                    "A short line holds worlds"
                    "Silence counts as form"
                    "The old pond keeps time"
                    "Petals mark the pause"
                    "One image turns thought"
                ]
                [
                    "A season enters one word"
                    "The line ends; the echo stays"
                    "Small forms can hold a wide sky"
                    "The cut makes two views converse"
                    "Plain words leave the deepest mark"
                ]
                [
                    "Let the pause remain"
                    "The image walks home"
                    "Meaning follows breath"
                    "One line opens twice"
                    "The season stays near"
                ]

            theme "confucius" "Patient Teacher" "仁" "Practice and reflection"
                "The Analects"
                "Project Gutenberg · The Analects"
                "https://www.gutenberg.org/ebooks/3330"
                [
                    "Study then reflect"
                    "Kindness shapes the path"
                    "Learning wakes the mind"
                    "Practice steadies thought"
                    "Honor roots the self"
                ]
                [
                    "A question keeps wisdom near"
                    "Thought and study share one lamp"
                    "The careful learner looks back"
                    "Good conduct begins within"
                    "The honest path needs no mask"
                ]
                [
                    "The next step is yours"
                    "Begin with the self"
                    "Keep the question warm"
                    "Walk then look again"
                    "Let practice take root"
                ]

            theme "strategy" "Quiet Strategist" "策" "Before the first move"
                "Sun Tzu and deliberate position"
                "Project Gutenberg · The Art of War"
                "https://www.gutenberg.org/ebooks/132"
                [
                    "Know the ground you cross"
                    "Quiet plans move first"
                    "Shape follows the field"
                    "Patience reads the wind"
                    "The right place bends fate"
                ]
                [
                    "The wise path avoids the wall"
                    "Deep knowledge makes effort small"
                    "The empty road hides its force"
                    "A patient move changes scale"
                    "Clear eyes prepare before steps"
                ]
                [
                    "Win before you move"
                    "Let the field decide"
                    "The quiet line holds"
                    "Know yourself then cross"
                    "Leave no wasted step"
                ]

            theme "shinto" "Shrine Archivist" "祓" "Renewal at the gate"
                "Shinto ritual and renewal"
                "Kokugakuin · Encyclopedia of Shinto"
                "https://d-museum.kokugakuin.ac.jp/eos/"
                [
                    "Clear water, clear mind"
                    "The gate marks a change"
                    "Rites can shape the day"
                    "Old cedar keeps watch"
                    "Renewal starts small"
                ]
                [
                    "A clean path begins in care"
                    "Each season teaches return"
                    "The threshold asks for respect"
                    "Names carry the weight we give"
                    "Still water mirrors the sky"
                ]
                [
                    "Step lightly, then bow"
                    "The old grove stays near"
                    "Begin clean again"
                    "The threshold opens"
                    "Care makes room for awe"
                ]

            theme "evolution" "Field Naturalist" "枝" "Changes that take root"
                "Darwin and adaptive form"
                "Project Gutenberg · On the Origin of Species"
                "https://www.gutenberg.org/ebooks/1228"
                [
                    "Small changes take root"
                    "Life branches through time"
                    "Forms answer the world"
                    "Chance walks beside need"
                    "Old traits find new homes"
                ]
                [
                    "Each answer bears its own cost"
                    "The patient years shape the wing"
                    "A slight edge can alter paths"
                    "The fit changes with the field"
                    "What thrives depends on the place"
                ]
                [
                    "Time keeps every mark"
                    "The branch tells the tale"
                    "No form stands alone"
                    "The field writes the shape"
                    "Small steps alter worlds"
                ]

            theme "stoicism" "Porch Philosopher" "選" "The next right act"
                "Epictetus and Marcus Aurelius"
                "Project Gutenberg · Meditations"
                "https://www.gutenberg.org/ebooks/2680"
                [
                    "Guard the inner gate"
                    "Choice lives in the pause"
                    "Events pass through us"
                    "Judgment colors pain"
                    "The mind meets the storm"
                ]
                [
                    "The next choice belongs to you"
                    "You choose the meaning you keep"
                    "A clear act answers the day"
                    "The storm cannot name your mind"
                    "Meet what arrives without masks"
                ]
                [
                    "The helm stays with you"
                    "Hold the center still"
                    "Choose the next right act"
                    "Let judgment rest now"
                    "The storm passes through"
                ]

            theme "wasan" "Sangaku Keeper" "算" "Proof beneath the eaves"
                "Edo-period Japanese mathematics"
                "National Diet Library · Japanese Mathematics"
                "https://www.ndl.go.jp/math/e/"
                [
                    "Wooden tablets speak"
                    "Old sums climb the shrine"
                    "Sangaku keeps watch"
                    "Circles meet the beam"
                    "Proof hangs under eaves"
                ]
                [
                    "Geometry becomes prayer"
                    "A bright theorem greets the dawn"
                    "Old shrines keep questions alive"
                    "Each diagram honors craft"
                    "A circle answers a square"
                ]
                [
                    "The beam holds the proof"
                    "Old craft becomes new"
                    "The shape bows to thought"
                    "The temple learns math"
                    "The answer hangs near"
                ]

            theme "tao" "Water Listener" "道" "The yielding road"
                "The Tao Te Ching"
                "Project Gutenberg · Tao Te Ching"
                "https://www.gutenberg.org/ebooks/216"
                [
                    "Water finds the low"
                    "Soft paths wear down stone"
                    "The empty cup waits"
                    "Stillness holds the wheel"
                    "Valleys remain wide"
                ]
                [
                    "The yielding path can endure"
                    "Usefulness grows from empty"
                    "Still centers can turn the wheel"
                    "No fixed shape survives each stream"
                    "The way appears as we walk"
                ]
                [
                    "Bend and still remain"
                    "The open hand holds"
                    "Let the current teach"
                    "Less force, farther roads"
                    "Return without fear"
                ]

            theme "zen" "Bell Keeper" "無" "The room already here"
                "Zen practice and direct attention"
                "Sacred Books of the East"
                "https://www.sacred-texts.com/bud/zen/index.htm"
                [
                    "One bell ends the fog"
                    "Sit before the fact"
                    "Breath returns the room"
                    "No thought needs a crown"
                    "Dust settles by dawn"
                ]
                [
                    "A question dissolves in breath"
                    "The answer comes when chased least"
                    "No mirror owns what it shows"
                    "The still seat crosses great miles"
                    "One clear act outlives the noise"
                ]
                [
                    "Leave the door unbarred"
                    "The bell rings once more"
                    "Sit down, then stand up"
                    "The room was right here"
                    "Nothing needs a name"
                ]

            theme "psychology" "Habit Cartographer" "習" "The loop that learns"
                "William James and the study of habit"
                "Project Gutenberg · Principles of Psychology"
                "https://www.gutenberg.org/ebooks/57628"
                [
                    "Habits build the floor"
                    "Attention feeds form"
                    "Small rewards steer feet"
                    "The story shapes choice"
                    "Practice changes sight"
                ]
                [
                    "A habit becomes a road"
                    "Noticed cues can change the loop"
                    "Attention makes signals loud"
                    "A pause can rewrite response"
                    "The practiced path asks less thought"
                ]
                [
                    "Make the cue easy"
                    "Notice, pause, then choose"
                    "Reward follows form"
                    "The loop learns from you"
                    "Practice changes ease"
                ]

            theme "physics" "Orbit Reader" "軌" "The law beneath the arc"
                "Motion, light, and scale"
                "OpenStax · University Physics"
                "https://openstax.org/details/books/university-physics-volume-1"
                [
                    "Stars count without clocks"
                    "Light bends on the road"
                    "Space keeps quiet time"
                    "Atoms trade their songs"
                    "Gravity writes arcs"
                ]
                [
                    "Small laws shape a distant star"
                    "A curved path still follows rules"
                    "The void hums beneath each form"
                    "Old light arrives from afar"
                    "Orbits remember each pull"
                ]
                [
                    "The arc closes home"
                    "Each law leaves a trace"
                    "The old light finds us"
                    "Space keeps the secret"
                    "The orbit comes round"
                ]

            theme "craft" "Careful Builder" "作" "The honest seam"
                "Software craft and deliberate tools"
                "Original Countku field notes"
                ""
                [
                    "Tools shape willing hands"
                    "A clean edge saves time"
                    "Good names carry weight"
                    "Small parts keep their word"
                    "Plain code leaves a trail"
                ]
                [
                    "A clear seam keeps change contained"
                    "A short path can still explain"
                    "Each true name removes one doubt"
                    "Good tools vanish into use"
                    "The craft lives in careful cuts"
                ]
                [
                    "Let the code read plain"
                    "The seam holds the change"
                    "Names become small maps"
                    "Make each part honest"
                    "The tool leaves no scar"
                ]

            theme "humanism" "Wayside Humanist" "縁" "Room at the fire"
                "Montaigne and humane attention"
                "Project Gutenberg · Essays of Montaigne"
                "https://www.gutenberg.org/ebooks/3600"
                [
                    "Kindness crosses time"
                    "One voice steadies two"
                    "The stranger bears worlds"
                    "Questions open doors"
                    "Shared bread softens walls"
                ]
                [
                    "Deep listening can change the room"
                    "Strangers can carry your key"
                    "Gentle acts outlive the hour"
                    "Honest words make room for two"
                    "We learn through another's eyes"
                ]
                [
                    "Leave room at the fire"
                    "The door opens both"
                    "Kindness keeps its reach"
                    "Listen past the words"
                    "The stranger walks home"
                ]
        ]

    let checkpoints =
        [
            yield! [ 5 .. 5 .. 100 ]
            yield! [ 120 .. 20 .. 1000 ]
        ]

    let entries =
        checkpoints
        |> List.mapi (fun index unlockAt ->
            let theme = themes[index % themes.Length]
            let opening = theme.openings[index % theme.openings.Length]
            let center = theme.centers[(index * 2 + 1) % theme.centers.Length]
            let closing = theme.closings[(index * 3 + 2) % theme.closings.Length]
            let lines = [ opening; center; closing ]
            {
                id = $"advisor-{unlockAt}-{theme.id}"
                persona = theme.persona
                sigil = theme.sigil
                category = "advisor-haiku"
                title = theme.title
                era = theme.era
                lines = lines
                body = System.String.Join("\n", lines)
                unlockAt = unlockAt
                sourceKind = "countku-haiku"
                sourceLabel = theme.sourceLabel
                sourceUrl = theme.sourceUrl
                sourceAccessed = "2026-07-28"
            })

let render () =
    let options = JsonSerializerOptions()
    options.WriteIndented <- true
    options.PropertyNamingPolicy <- JsonNamingPolicy.CamelCase
    options.Encoder <- JavaScriptEncoder.UnsafeRelaxedJsonEscaping

    let advisorJson =
        JsonSerializer.Serialize(AdvisorHaiku.entries |> List.toArray, options)
    let fieldJson =
        JsonSerializer.Serialize(FieldDialogue.all |> List.toArray, options)
    let sceneJson =
        JsonSerializer.Serialize(FieldDialogue.avatarScenes |> List.toArray, options)

    """// Generated by Orc from sharpjs-countku-wisdom.fs.
// Edit the F# source bank; do not hand-edit this rendered module.
const advisors = __ADVISOR_JSON__;
const fields = __FIELD_JSON__;
const scenes = __SCENE_JSON__;

export const ADVISOR_BANK = Object.freeze(
  advisors.map((entry) => Object.freeze({{
    ...entry,
    lines: Object.freeze([...entry.lines])
  }}))
);

export const FIELD_MESSAGES = Object.freeze(
  fields.map((entry) => Object.freeze(entry))
);

export const AVATAR_SCENE_LINES = Object.freeze(
  scenes.map((entry) => Object.freeze(entry))
);

const normalizeLevel = (value) =>
  Math.max(0, Math.floor(Number(value) || 0));

export function advisorAtLevel(level) {{
  const exact = normalizeLevel(level);
  return ADVISOR_BANK.find((entry) => entry.unlockAt === exact) ?? null;
}}

export function fieldMessageAtLevel(level) {{
  const exact = normalizeLevel(level);
  if (exact === 2) {{
    return FIELD_MESSAGES.find(
      (entry) => entry.id === "field-oak-count-now"
    ) ?? null;
  }}
  if (exact < 2 || exact % 3 !== 2 || exact % 5 === 0) return null;
  const pool = FIELD_MESSAGES.filter(
    (entry) => entry.id !== "field-oak-count-now"
  );
  const index = Math.floor(exact / 3) % pool.length;
  return pool[index];
}}
"""
    |> fun template ->
        template
            .Replace("{{", "{")
            .Replace("}}", "}")
            .Replace("__ADVISOR_JSON__", advisorJson)
            .Replace("__FIELD_JSON__", fieldJson)
            .Replace("__SCENE_JSON__", sceneJson)
