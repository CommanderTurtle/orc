module CountkuDialogue

open System.Text.Encodings.Web
open System.Text.Json

// These inert literals are a Regedited jump table over the authored entry
// ranges below. They are never evaluated by the renderer. Their first code
// zone can be read as i4100z1, i4200z1, i4300z1, or i4400z1; Regedited keeps
// later line pointers aligned when a zone is changed through its write API.
module RegeditedCatalogue =
    let EarlyTrail = """
regedited open
index: 4100
1x000006C : 1x0000105 : 0x0000000 : 0x0000000 : 0x0000000 : 0x0000000
1 | 9 | 0 | 0 | 0 | 0 | 0 | 0 | 0
early trail dialogue
unlock levels 1 through 9
CountkuDialogue.entries
---
"""

    let ApprenticeTrail = """
regedited open
index: 4200
1x0000106 : 1x000018B : 0x0000000 : 0x0000000 : 0x0000000 : 0x0000000
10 | 22 | 0 | 0 | 0 | 0 | 0 | 0 | 0
apprentice trail dialogue
unlock levels 10 through 22
CountkuDialogue.entries
---
"""

    let AdeptTrail = """
regedited open
index: 4300
1x000018C : 1x0000205 : 0x0000000 : 0x0000000 : 0x0000000 : 0x0000000
25 | 45 | 0 | 0 | 0 | 0 | 0 | 0 | 0
adept trail dialogue
unlock levels 25 through 45
CountkuDialogue.entries
---
"""

    let SageTrail = """
regedited open
index: 4400
1x0000206 : 1x000025C : 0x0000000 : 0x0000000 : 0x0000000 : 0x0000000
50 | 125 | 0 | 0 | 0 | 0 | 0 | 0 | 0
sage trail dialogue
unlock levels 50 through 125
CountkuDialogue.entries
---
"""

// This is authored data, not parser logic. Orc compiles it into
// countku-dialogue.js during the normal render-site pass.
type DialogueEntry = {
    id: string
    persona: string
    sigil: string
    category: string
    title: string
    era: string
    body: string
    unlockAt: int
    sourceKind: string
    sourceLabel: string
    sourceUrl: string
    sourceAccessed: string
}

let private institutional
    id persona sigil category title era body unlockAt
    sourceLabel sourceUrl =
    {
        id = id
        persona = persona
        sigil = sigil
        category = category
        title = title
        era = era
        body = body
        unlockAt = unlockAt
        sourceKind = "institutional"
        sourceLabel = sourceLabel
        sourceUrl = sourceUrl
        sourceAccessed = "2026-07-27"
    }

let private original
    id persona sigil category title era body unlockAt =
    {
        id = id
        persona = persona
        sigil = sigil
        category = category
        title = title
        era = era
        body = body
        unlockAt = unlockAt
        sourceKind = "original"
        sourceLabel = "Original Countku dialogue"
        sourceUrl = ""
        sourceAccessed = ""
    }

let private entries =
    [
        institutional
            "basho-road"
            "Road Poet"
            "句"
            "poetry"
            "A road made of seventeen"
            "Edo period · poetry"
            """Matsuo Bashō is a central figure in the history of haiku. Countku borrows the discipline of a short form, not any claim that mathematics has only one poetic shape."""
            1
            "National Diet Library · Matsuo Bashō authority record"
            "https://id.ndl.go.jp/auth/ndlna/00270778"

        original
            "scholar-first-landing"
            "Skeptical Scholar"
            "問"
            "trail"
            "The target moved"
            "Sakura Trail · field note"
            """Seventeen syllables, an exact value, and somehow the target moved. I remain skeptical, but less comfortably than before."""
            1

        institutional
            "soroban-arrival"
            "Lantern Geometer"
            "算"
            "wasan"
            "A quicker instrument changes the road"
            "Early Edo period · wasan"
            """Before the soroban spread in Japan, computing rods were used for everyday calculation. A faster hand tool did more than save time: it widened where mathematics could be practiced."""
            2
            "National Diet Library · Early Edo Period"
            "https://www.ndl.go.jp/math/e/s1/1.html"

        original
            "elementalist-balance"
            "Wandering Elementalist"
            "風"
            "philosophy"
            "Balance is not sameness"
            "Original trail philosophy"
            """Balance is not sameness. It is the equality sign still holding after both sides have spoken."""
            2

        institutional
            "seki-notation"
            "Lantern Geometer"
            "算"
            "wasan"
            "Notation changes what can be seen"
            "Edo period · wasan"
            """Seki Takakazu developed notation that made mathematical expressions and several unknown quantities easier to describe. Notation is not merely decoration; it changes which problems are practical to think through."""
            3
            "National Diet Library · Seki Takakazu"
            "https://www.ndl.go.jp/math/e/s1/2.html"

        original
            "poet-counts-silence"
            "Road Poet"
            "句"
            "poetry"
            "Silence has a syllable budget"
            "Sakura Trail · field note"
            """A short form does not make thought small. It makes every unnecessary word confess."""
            3

        original
            "scholar-cube-root"
            "Skeptical Scholar"
            "問"
            "trail"
            "The cube root has witnesses"
            "Sakura Trail · field note"
            """The cube root under the influence of a power has entered the record. The syntax is theatrical. The value, annoyingly, is exact."""
            4

        institutional
            "jinkoki-curiosity"
            "Lantern Geometer"
            "算"
            "wasan"
            "A textbook can invite a sequel"
            "Early Edo period · Jinkōki"
            """Jinkōki mixed practical calculation with challenging idai problems. Those puzzles stirred curiosity, and later books answered by presenting new problems of their own."""
            5
            "National Diet Library · Early Edo Period"
            "https://www.ndl.go.jp/math/e/s1/1.html"

        institutional
            "norinaga-text"
            "Shrine Archivist"
            "清"
            "shinto-studies"
            "Read the old words carefully"
            "Edo period · kokugaku"
            """Motoori Norinaga completed Naobinomitama in 1771 and later included it with Kojikiden. Countku's smaller lesson is to understand a rule's language before compressing it."""
            5
            "Kokugakuin University · Encyclopedia of Shinto"
            "https://d-museum.kokugakuin.ac.jp/eos/detail/?id=8791"

        original
            "elementalist-obstacle"
            "Wandering Elementalist"
            "風"
            "philosophy"
            "Move through, not against"
            "Original trail philosophy"
            """Wind does not argue with the mountain. Your expression did not argue with the target; it found a route through."""
            6

        institutional
            "tengenjutsu-crossing"
            "Lantern Geometer"
            "算"
            "wasan"
            "A method crosses borders and changes"
            "East Asian mathematics · Edo period"
            """Tengenjutsu reached Japan through Chinese mathematical writing. Wasan scholars studied it, adapted it, and expanded what the method could express."""
            7
            "National Diet Library · Early Edo Period"
            "https://www.ndl.go.jp/math/e/s1/1.html"

        original
            "scholar-log-disguise"
            "Skeptical Scholar"
            "問"
            "trail"
            "The logarithm wore a sentence"
            "Sakura Trail · field note"
            """You disguised a logarithm as ordinary English and expected nobody to notice. The target noticed. It approved."""
            7

        institutional
            "wasan-many-roads"
            "Lantern Geometer"
            "算"
            "wasan"
            "The same number can wear another notation"
            "Edo period · wasan"
            """Wasan addressed algebra, geometry, pi, and trigonometric questions with terms and symbols different from Western mathematics. Notation is a choice of road, not the number itself."""
            8
            "National Diet Library · Wasan introduction"
            "https://www.ndl.go.jp/math/e/introduction.html"

        original
            "poet-image-proof"
            "Road Poet"
            "句"
            "poetry"
            "An image can carry a proof"
            "Sakura Trail · field note"
            """The line gives the mind an image. The equation gives the image a spine."""
            9

        institutional
            "seki-many-unknowns"
            "Lantern Geometer"
            "算"
            "wasan"
            "More than one unknown may speak"
            "Edo period · Seki school"
            """Seki's notation helped expressions describe more than one unknown and made elimination in simultaneous equations easier. Clear symbols gave difficult relationships room to be handled."""
            10
            "National Diet Library · Seki Takakazu"
            "https://www.ndl.go.jp/math/e/s1/2.html"

        original
            "elementalist-precision"
            "Wandering Elementalist"
            "風"
            "philosophy"
            "Precision without rigidity"
            "Original trail philosophy"
            """Water takes the shape it needs. Precision is not rigidity; it is arriving without leaking meaning."""
            10

        institutional
            "misogi-distinction"
            "Shrine Archivist"
            "清"
            "shinto-studies"
            "Renewal is not erasure"
            "Shinto studies · terminology"
            """Misogi names ablution and is closely linked with harae, yet the terms originally referred to distinct practices. Precision matters even when two ideas travel together."""
            12
            "Kokugakuin University · Misogi"
            "https://d-museum.kokugakuin.ac.jp/eos/detail/?id=8723"

        original
            "scholar-exponent-ambition"
            "Skeptical Scholar"
            "問"
            "trail"
            "An exponent with ambition"
            "Sakura Trail · field note"
            """The exponent arrived with unreasonable ambition. You gave it a grammatical title and sent it to work."""
            12

        institutional
            "jinkoki-practical-play"
            "Lantern Geometer"
            "算"
            "wasan"
            "Usefulness and play can share a page"
            "Edo period · Jinkōki"
            """Shinpen Jinkōki included multiplication and division alongside field areas, river works, geometric progressions, and recreational problems. Practicality did not require boredom."""
            15
            "National Diet Library · Jinkoki"
            "https://www.ndl.go.jp/math/e/s2/1.html"

        institutional
            "makoto-sincerity"
            "Shrine Archivist"
            "清"
            "shinto-studies"
            "Let the expression mean what it says"
            "Shinto studies · basic terms"
            """Makoto can refer to sincerity, earnestness, and a heart free of falsehood. On this trail, the playful version is simple: let the expression mean what it says."""
            15
            "Kokugakuin University · Makoto"
            "https://d-museum.kokugakuin.ac.jp/eos/detail/?id=8728"

        original
            "poet-revision"
            "Road Poet"
            "句"
            "poetry"
            "Revision is a second instrument"
            "Sakura Trail · field note"
            """The first line found the thought. The second draft found the line."""
            16

        institutional
            "sangaku-offering"
            "Lantern Geometer"
            "算"
            "wasan"
            "A problem may be offered in public"
            "Edo period · sangaku"
            """Sangaku were mathematical problems written on votive tablets and dedicated at shrines and temples. Many presented colored geometric figures: public mathematics with a visible sense of beauty."""
            18
            "National Diet Library · Sangaku"
            "https://www.ndl.go.jp/math/e/s1/c5.html"

        original
            "elementalist-fire-denominator"
            "Wandering Elementalist"
            "火"
            "philosophy"
            "Drama and consequence"
            "Original trail philosophy"
            """A flame is dramatic. A denominator quietly decides whether the village survives. Respect quiet operators."""
            18

        institutional
            "wasan-practice"
            "Lantern Geometer"
            "算"
            "wasan"
            "A problem can be an invitation"
            "Edo period · wasan schools"
            """Wasan schools used exercises and friendly competition to develop mathematical skill. The next target can be an invitation to find another exact expression."""
            20
            "National Diet Library · Wasan as a hobby"
            "https://www.ndl.go.jp/math/e/s1/3.html"

        institutional
            "kotodama-words"
            "Shrine Archivist"
            "言"
            "shinto-studies"
            "Words are treated as consequential"
            "Shinto studies · kotodama"
            """Kotodama refers to power understood as residing in words or manifested through their intonation. Countku does not turn that belief into a claim; it uses the historical idea as a reminder that wording changes experience."""
            20
            "Kokugakuin University · Kotodama"
            "https://d-museum.kokugakuin.ac.jp/eos/detail/?id=8660"

        original
            "scholar-sixty-four"
            "Skeptical Scholar"
            "問"
            "trail"
            "Sixty-four has entered the chat"
            "Sakura Trail · field note"
            """The thirteenth power of sixty-four has entered the chat. Nobody invited it. The arithmetic remains valid."""
            22

        institutional
            "sangaku-travelers"
            "Lantern Geometer"
            "算"
            "wasan"
            "Problems traveled with teachers"
            "Edo period · sangaku"
            """Itinerant wasan scholars taught while traveling. Yamaguchi Kazu recorded hundreds of mathematical-tablet problems encountered across the country, preserving a road map made of questions."""
            25
            "National Diet Library · Sangaku"
            "https://www.ndl.go.jp/math/e/s1/c5.html"

        original
            "poet-constraint"
            "Road Poet"
            "句"
            "poetry"
            "Constraint is a lantern"
            "Sakura Trail · field note"
            """A limit does not only close doors. Sometimes it lights the one door worth opening."""
            25

        institutional
            "seki-polygons"
            "Lantern Geometer"
            "算"
            "wasan"
            "From three sides to twenty"
            "Edo period · Seki Takakazu"
            """Seki demonstrated area calculations for regular polygons from the equilateral triangle through the regular twenty-sided polygon. A family of cases can reveal the shape of a method."""
            28
            "National Diet Library · Seki Takakazu"
            "https://www.ndl.go.jp/math/e/s1/2.html"

        original
            "elementalist-grounding"
            "Wandering Elementalist"
            "土"
            "philosophy"
            "Ground the flourish"
            "Original trail philosophy"
            """Let the sentence whirl if it wishes. The final value still needs somewhere solid to stand."""
            30

        institutional
            "kegare-condition"
            "Shrine Archivist"
            "清"
            "shinto-studies"
            "A condition is not an identity"
            "Shinto studies · kegare"
            """The Encyclopedia of Shinto describes kegare as a condition associated with pollution and taboo, distinct from deliberate transgression. The useful design lesson is not theological equivalence: diagnose a state without making it a permanent identity."""
            30
            "Kokugakuin University · Kegare"
            "https://d-museum.kokugakuin.ac.jp/eos/detail/?id=8664"

        institutional
            "sangaku-simple-expression"
            "Lantern Geometer"
            "算"
            "wasan"
            "Beauty can end in a simple expression"
            "Edo period · sangaku"
            """Many sangaku problems used beautiful geometric figures and arrived at answers expressible with compact formulas. Visual richness and concise resolution need not be enemies."""
            35
            "National Diet Library · Sangaku"
            "https://www.ndl.go.jp/math/e/s1/c5.html"

        original
            "scholar-algebra-apology"
            "Skeptical Scholar"
            "問"
            "trail"
            "Algebra has filed a complaint"
            "Sakura Trail · field note"
            """You bent English until algebra apologized. The complaint was dismissed on numerical grounds."""
            35

        institutional
            "norito-order"
            "Shrine Archivist"
            "言"
            "shinto-studies"
            "Language can carry an order of practice"
            "Shinto studies · norito"
            """The Engishiki preserves norito associated with a sequence of court and shrine rites. The historical record shows language serving not only expression, but ordered practice."""
            40
            "Kokugakuin University · Norito"
            "https://d-museum.kokugakuin.ac.jp/eos/detail/?id=8632"

        original
            "elementalist-empty-space"
            "Wandering Elementalist"
            "空"
            "philosophy"
            "Leave room for the result"
            "Original trail philosophy"
            """An expression crowded with cleverness can forget why it began. Leave enough empty space for the answer to arrive."""
            40

        institutional
            "katsuyo-breadth"
            "Lantern Geometer"
            "算"
            "wasan"
            "A single collection can hold many scales"
            "Edo period · Seki school"
            """Katsuyō Sanpō ranges across number theory, finite series and Bernoulli numbers, regular polygons, and calculations of pi. Mathematical identity can be broad without becoming shapeless."""
            45
            "National Diet Library · Seki Takakazu and the Seki School"
            "https://www.ndl.go.jp/math/e/s2/2.html"

        original
            "poet-exactness"
            "Road Poet"
            "句"
            "poetry"
            "Exactness can still sing"
            "Sakura Trail · field note"
            """A number does not become less exact because the road to it had rhythm."""
            45

        institutional
            "wasan-survived"
            "Lantern Geometer"
            "算"
            "wasan"
            "A tradition can change roles and continue"
            "Meiji and later · regional education"
            """Wasan left the modern public-school curriculum, yet regional private schools continued using it to answer mathematical curiosity. A practice can survive by finding a different social role."""
            50
            "National Diet Library · End of Wasan"
            "https://www.ndl.go.jp/math/e/s1/6.html"

        institutional
            "ento-salt-water"
            "Shrine Archivist"
            "清"
            "shinto-studies"
            "Preparation has material form"
            "Shinto studies · ritual implements"
            """Entō is salt water used in preparatory purification. Its documented ritual use is a reminder that preparation is often concrete: a vessel, a sequence, and an action rather than a vague intention."""
            50
            "Kokugakuin University · Entō"
            "https://d-museum.kokugakuin.ac.jp/eos/detail/?id=9651"

        original
            "scholar-wasan-sage"
            "Skeptical Scholar"
            "問"
            "trail"
            "The ledger is getting unreasonable"
            "Sakura Trail · field note"
            """At this point the ledger suggests you are doing this on purpose. I preferred the earlier hypothesis."""
            60

        institutional
            "wasan-practical-science"
            "Lantern Geometer"
            "算"
            "wasan"
            "Usefulness can outlive a label"
            "Meiji transition · mathematics"
            """As Western mathematics entered Japanese institutions, people trained in wasan helped teach the new curriculum. Skills crossed the change even when the category name did not."""
            75
            "National Diet Library · End of Wasan"
            "https://www.ndl.go.jp/math/e/s1/6.html"

        original
            "elementalist-many-roads"
            "Wandering Elementalist"
            "風"
            "philosophy"
            "One target, many roads"
            "Original trail philosophy"
            """The number is not offended by another route. Only the traveler mistakes familiarity for necessity."""
            75

        institutional
            "recreation-generalized"
            "Lantern Geometer"
            "算"
            "wasan"
            "Play can reveal the general rule"
            "Edo period · recreational mathematics"
            """Seki-school materials did more than repeat recreational problems: they extracted and generalized them. Play becomes research when the example is asked to reveal its structure."""
            100
            "National Diet Library · Seki Takakazu and the Seki School"
            "https://www.ndl.go.jp/math/e/s2/2.html"

        original
            "poet-hundred"
            "Road Poet"
            "句"
            "poetry"
            "A hundred exact landings"
            "Sakura Trail · field note"
            """The trail did not become shorter. You became fluent in seeing where it bends."""
            100

        original
            "scholar-last-word"
            "Skeptical Scholar"
            "問"
            "trail"
            "Skepticism, revised"
            "Sakura Trail · field note"
            """I have reviewed the evidence. Countku remains absurd. It is now, regrettably, demonstrably absurd."""
            125
    ]

let render () =
    let options = JsonSerializerOptions()
    options.WriteIndented <- true
    options.Encoder <- JavaScriptEncoder.UnsafeRelaxedJsonEscaping

    let json =
        JsonSerializer.Serialize(entries |> List.toArray, options)

    $"""// Generated by Orc from sharpjs-countku-dialogue.fs.
// Edit the F# source; do not hand-edit this rendered module.
const entries = {json};

export const DIALOGUE_BANK = Object.freeze(entries.map(Object.freeze));
export const DIALOGUE_CATEGORIES = Object.freeze(
  [...new Set(entries.map((entry) => entry.category))]
);
"""
