module ConvertedFiles.Countku.N2Md

let file = """# Sakura Count Ninja - Changelog

## Version 6.0 (2025-05-17) - Deferred Emission Engine

### Core Architecture
- **Deferred Emission Engine**: Complete rewrite of `convertTokens()` with deferred power/root mode handling
- **$P_Action vs $P_Passiv Implementation**: Prepositional flags now control parenthesis scope
  - `$P_Action` (by, beside, executing, using): Wraps ENTIRE preceding expression → `(expr)**N`
  - `$P_Passiv` (with, to, for, under): Wraps only immediately preceding term → `expr-(term)**N`
- **splitLastTerm()**: New helper method splits expression at last top-level operator for $P_Passiv wrapping
- **sumDigitGroups()**: New helper method sums consecutive digit groups (e.g., `['1000','800','58']` → `['1858']`)

### Power & Root Control (v6 Features)
- `"to" as power trigger**: `five to the sixtieth` = 5^60
  - Supports reverso mode: `two to the one fifth` = 2^(1/5)
- **"of" as root trigger**: `a fiftieth of five` = 5^(1/50)
- **Ordinal powers**: `ten to the fourth` = 10^4
- **Multi-word ordinals**: `the four hundred sixty eighth root of ten` works correctly
- **Deferred emission**: Power/root modes save base/degree, collect argument, emit at end of tokens

### Bug Fixes
- **Fixed broken buttons** (critical): Rebuilt from clean v1.1 base after `handleSubmit` corruption in previous edit attempts
- **Tessaric root bug**: Fixed ordinal auto-closing before multipliers could compose (e.g., "tessaric root of one hundred" no longer produces `Math.pow(1,1/4)*100`)
- **"to" consumption bug**: "to" is now checked BEFORE database lookup, preventing it from being consumed as a noise/helper token

### Engine Data Structures
- Added `ORDINAL_COMPOSERS` mapping for composed ordinals (twentieth, thirtieth, ..., ninetieth)
- Variant groups: zero/zed/oh, times/multiplied, e/euler's — pick one, can't mix

### v6.5 Bug Fixes (2025-05-17)
- **"type shit" noise**: Added 'shit' as standalone noise entry. "type shit" now correctly evaluates as noise (2 syllables, no math)
- **"with" unknown word**: Added 'with' to COUNTKU_DB with `pAction: true` flag
- **"by" unknown word**: Added 'by' to COUNTKU_DB with `pAction: true` flag  
- **"under" pPassiv**: Added `pPassiv: true` to 'under' DB entry so $P_Passiv power triggers work
- **"for" pPassiv**: Added 'for' to DB with `pPassiv: true`
- **"beside" / "executing" pAction**: Added to DB with `pAction: true`
- **"base" helper**: Added 'base' to DB for "log base N" support
- **Systematic ordinals**: Added 36 systematic/Latin/Greek ordinals (quadratic, cubic, quartic, quintic, sextic, septic, octic, nonic, decic, undecic, duodecic, etc.)
- **`-tieth` standalone ordinals**: Added twentieth, thirtieth, ..., ninetieth to COUNTKU_ORDINALS
- **Large ordinal roots**: Fixed root degree extraction for composed ordinals with multipliers (e.g., "million and forty seventh" = 1000047)
- **Ordinal power degree**: Fixed power degree extraction for multi-word ordinal expressions
- **"and" after function**: "and" now outputs `+` when following a function close (e.g., "log of one and two" → `Math.log(1)+2`)
- **Function close + composition**: Fixed function auto-close to not interfere with number composition (e.g., "fifth root of thirty two" → `Math.pow(32,1/5)`)
- **Multi-word ordinal root patterns**: Fixed `Math.pow($,1/N)` patterns to use proper `Math.pow(` opening with degree tracking
- **Root prefix preservation**: Root mode now preserves prefix expression separately from argument (e.g., "five minus the root of five" → `5-Math.sqrt(5)`)
- **Scale composition**: Added `+` insertion between multiplier and following digits (e.g., "one hundred twenty three" → `1*100+23`)
- **`evalPowerExp()`**: New helper evaluates exponent parts with multipliers (e.g., `['*1000000','42']` → `1000042`)
- **`degreeParts` extraction**: New approach for extracting trailing numeric parts for degree calculation

### v7.2 (2025-05-17) — -ed Form Support
- **`-ed` forms work after `with/using {a}`**: "ten with a subtracted three" → `10-3`
  - `subtracted` → `-` (subtraction)
  - `multiplied` → `*` (multiplication)
  - `divided` → `/` (division)
  - `added` → `+` (addition)
- **Optional trailing preposition**: "with a multiplied by three" → `10*3` (by/using/with are noise)
- **`subtracted` as $N_Sub**: Changed from noise to noun operator with `nSub: true`
- **`added` as $N_Add**: Changed from noise to noun operator with `nAdd: true`
- **`multiplied` as $N_Mul**: Changed from noise to noun operator with `nMul: true`
- **`subtracted from` FLIP_SUB**: Bare form "ten subtracted from three" → `(3)-(10)` via nounOpPending
- **Removed `subtracted from` multi-word pattern**: Now handled via nounOpPending for consistency
- **FLIP_SUB actually flips**: Was removing marker without swapping; now produces `(B)-(A)`
- **Bare -ed forms return null**: "subtracted three" alone is invalid (needs `with/using {a}`)

### v7.4 (2025-05-17) — Trig Parenthesis Fix
- **`funcArgOpen` generalizes `logArgOpen`**: All function arguments now stay open for number composition
  - `the sine of thirty eight` → `Math.sin(38)` (was `Math.sin(30)8`)
  - `the secant of thirty two` → `(1/Math.cos(32))` (was `(1/Math.cos(32`)
  - `the cosecant of forty three` → `(1/Math.sin(43))`
  - `the cotangent of fifty four` → `(1/Math.tan(54))`
- **Secant/cosecant/cotangent open TWO parens**: `(1/Math.cos(` opens both fraction and function parens
- **`maybeCloseFunc` closes double parens**: Extra `)` for secant/cosecant/cotangent fraction paren
- **Single-word secant/cosecant/cotangent handling**: `math.startsWith('(1/')` opens 2 parens
- **`maybeCloseFunc(i)` always passes index**: Number composition path was calling without index, breaking `nextWouldCompose`

### v7.3 (2025-05-17) — Logarithm System Overhaul
- **Log argument concatenation**: `the logarithm of thirty eight` → `Math.log(38)/Math.log(10)` — composed numbers now stay inside log arguments
- **`base` after non-natural log**: `the logarithm of eight base five` → `Math.log(8)/Math.log(5)` — changes the log base
- **`base` DISALLOWED after natural log**: `the natural logarithm of eight base five` → `Math.log(8)` — base + following number consumed as noise
- **`to/with/by/using {a/the} logarithm` applies to previous number**: `five with the logarithm` → `Math.log(5)/Math.log(10)`
- **`to/with/by/using {a/the} natural logarithm` applies to previous number**: `five with the natural logarithm` → `Math.log(5)`
- **`to` deferred power trigger skips log patterns**: `five to the logarithm` no longer enters power mode — logPendMode takes precedence
- **`logArgOpen` + `nextWouldCompose`**: New mechanism prevents function auto-close from breaking number composition inside log arguments
- **End-of-method close parens loop**: Now includes `pendingLogBase` denominator (was only in `maybeCloseFunc`)
- **`base` noise after natural log**: Consumes both `base` token and following number token

### v7.1 (2025-05-17) — Noun Operator Preposition Gating
- **Noun operators are now gated on approved prepositions**: `division`/`multiplication`/`addition`/`subtraction` only produce math with specific prepositions
  - `division`: by, with, using (from → `/`; anything else → noise)
  - `multiplication`: by, with, using, of (to → noise; anything else → noise)
  - `addition`: with, by, using (to → noise; anything else → noise)
  - `subtraction`: by, with, using, of (from → `__FLIP__`; anything else → noise)
- **`to` ** glitch fixed**: `"multiplication to"` and `"addition to"` no longer produce `**N` — they produce noise instead
- **Noise words added**: `multiplying`, `divided`, `subtracted`, `added` (all standalone noise)
- **Subtraction `from`**: Uses d41 `__FLIP__` marker for flip subtraction (B - A)
- **Noun op pending state**: `nounOpPending` stores operator until next token validates it

### v7.0 (2025-05-17) — Deferred Emission on v1.2 Base
- **Reverted to v1.2 as source of truth**: Abandoned over-engineered v6 approach
- **Deferred power/root mode**: Added v6-style deferred emission ON TOP of stable v1.2
  - `"to"` trigger: `five to the million and forty second` → `(5)**1000042`
  - `"root"` trigger: `five minus the million and forty seventh root of five` → `5-Math.pow(5,1/1000047)`
  - Degree accumulation with `degreeSum`/`degreeLast` tracks multipliers + composed ordinals
  - Removed conflicting ordinal+root multi-word patterns (now handled by deferred mode)
- **Logarithm change-of-base**: Default `log` → `Math.log(N)/Math.log(10)`; `natural log` → `Math.log(N)`
- **Ordinal-as-base log**: `fourteenth log of six` → `Math.log(6)/Math.log(14)` (ordinal popped from parts)
- **Noise words**: `'type'` and `'shit'` added as standalone noise entries
- **Preposition fixes**: `'with'` and `'by'` get `pAction: true`; reset `lastWasNumber` on prepositions
- **`-teenth`/`-tieth` ordinals**: Added to COUNTKU_ORDINALS (fourteenth, twentieth, thirtieth, ..., ninetieth)
- **Systematic ordinals**: 36 Latin/Greek ordinals from database doc (quadratic, cubic, ..., duodecic)
- **Scale composition**: `+` inserted between multiplier and following digits
- **Decimal composition**: Fixed `one point zero five` → `1.05` with `decimalContext` flag
- **`quadrillion` multiplier**: Added to DB

---

## Version 1.2 (2025-05-17)

### Updates
- Additional database entries and refinements
- Continued integration of markdown database bit flags (Table 1)

---

## Version 1.1 (2025-05-16) - Live Deployment Variant

### Features
- HTML literals approach: Word definitions in `<span data-word="..." data-math="..." data-syllables="N">` elements
- JS reads word data via `dataset` attributes
- Dual-check system: HaikuValidator (5-7-5 structure) + CountkuConverter (word-to-math) both must pass
- Fallover syllable system: Cumulative syllable counting — if next word exceeds line target, start new line
- 4 game modes: Normal (Base 10), Hard (Base 2), WTF (Base 16), Countku (Word Math Haiku)

### Database Integration
- Integrated Table 1 bit flags from markdown database as grammar engine
- `$P_Action` / `$P_Passiv` prepositional flag support (engine support, not full deferred emission)
- Multi-word pattern matching (longest-first tokenization)

---

## Version 1.0.0 (2025-05-16) - Last Stable

### Features
- Core word-to-math conversion engine
- Haiku validator with 5-7-5 automatic line detection (no delimiters)
- Basic operators: +, -, *, /, ^
- Functions: ln(), log(), sqrt(), sin(), cos(), arcsin()
- Constants: pi, e
- Decimal support via "point"
- Special zero variants: zero, zed, oh
- Scaling: half of, double, twice, halved, doubled, tripled, quadrupled
- Powers: squared, cubed, to the power of
- Roots: square root of, cube root of, nth root of
- Trigonometry: sine of, cosine of, tangent of and inverses
- Logarithms: natural log of, logarithm of, log base N of
- Postfix power operators (squared/cubed) with function paren closure
- Function auto-close: Operators inside function arguments close the function paren
- Variant tracking system with conflict detection
- Anti-splice word list for haiku validation
- Number composition: simple numbers combine (e.g., "twenty one" = 21)
- Multiplier composition: hundred, thousand, million, billion
- Decimal composition: "one point oh five" = 1.05
- Flip subtraction: "subtraction from" pattern (B - A instead of A - B)

### Technical Implementation
- `CountkuConverter` class with `convertTokens()` → `{expr, parts}`
- `HaikuValidator` class with `validate()` → `{isHaiku, error, lines}`
- `handleSubmit()` with mode-specific branching
- `evaluateExpression()` for safe math evaluation
- Ninja animation system (idle, run, jump states)
- Streak tracking and end-game dashboard
- Sound effects for correct/incorrect answers

---

## Original Concept (by u/CommanderT1562)

Countku: A base-ten number system more convoluted than all prime numbers. Haikus must relate to nature — numbers ARE nature.

**Core Rules:**
- 5-7-5 syllable structure strictly enforced
- No cutting words across line breaks (e.g., "ze-" on line 1, "ro" on line 2)
- Decimal is always "point"
- Zero can be "oh" (1 syl), "zed" (1 syl), or "zero" (2 syl) — pick one per thread
- "Type shit" and other 2-syllable memes are legal BS words (syllable padding, no math effect)
- Word must be finished at end of a Ku (no "one point zero Oh" cheating)

**Reference:** https://www.reddit.com/r/haikusbot/comments/1p1aq85/countku_expert_level_counting/
"""

let render() = file
