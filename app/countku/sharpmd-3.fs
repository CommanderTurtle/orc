module ConvertedFiles.Countku.N3Md

let file = """# Sakura Count Ninja - Engine Reference Manual

## Overview

The Countku engine converts English word phrases into executable JavaScript math expressions, with automatic 5-7-5 haiku structure validation. It powers the **Countku** game mode in Sakura Count Ninja.

---

## 1. Database Tables

### 1.1 COUNTKU_DB (Word Dictionary)

Single-word entries indexed by lowercase word. Each entry has:

| Field | Type | Description |
|-------|------|-------------|
| `syl` | number | Syllable count for haiku validation |
| `type` | string | `number`, `operator`, `function`, `constant`, `helper`, `decimal`, `multiplier`, `ordinal`, `noise`, `special` |
| `val` | string | Math expression value (for numbers, operators, functions) |
| `role` | string | Sub-type for `special` entries (e.g., `decimal_zero` for "oh") |
| `pAction` | boolean | $P_Action flag: sets `prepMode = 'action'` |
| `pPassiv` | boolean | $P_Passiv flag: sets `prepMode = 'passiv'` |
| `nDiv/nMul/nAdd/nSub` | boolean | Noun operator flags (division, multiplication, addition, subtraction) |
| `closeFunc` | boolean | Closes open function parens when encountered |
| `andRole` | boolean | Tracks "and" usage for $AndMatrix state |
| `sylOf` | number | Extra syllables when followed by "of" |

**Key Entries:**

| Word | Type | Value | Syl |
|------|------|-------|-----|
| zero | number | 0 | 2 |
| zed | number | 0 | 1 |
| oh | special | 0 (decimal only) | 1 |
| one-nineteen | number | 1-19 | 1-3 |
| twenty-ninety | number | 20-90 | 2-3 |
| hundred | multiplier | *100 | 2 |
| thousand | multiplier | *1000 | 2 |
| million | multiplier | *1000000 | 2 |
| point | decimal | . | 1 |
| plus | operator | + | 1 |
| minus | operator | - | 2 |
| times | operator | * | 1 |
| divided | operator | / (prefix) | 3 |
| by | helper | - | 1 |
| over | operator | / | 2 |
| modulo | operator | % | 3 |
| squared | operator | **2 | 1 |
| cubed | operator | **3 | 1 |
| halved | operator | /2 | 1 |
| doubled | operator | *2 | 2 |
| tripled | operator | *3 | 2 |
| quadrupled | operator | *4 | 3 |
| pi | constant | Math.PI | 1 |
| e | constant | Math.E | 1 |
| log | function | Math.log( | 1 |
| root | function | Math.sqrt( | 1 |
| sine | function | Math.sin( | 1 |
| cosine | function | Math.cos( | 2 |
| tan | function | Math.tan( | 1 |
| sqrt | function | Math.sqrt( | 1 |
| cbrt | function | Math.cbrt( | 1 |
| abs | function | Math.abs( | 1 |
| the | helper | noise | 1 |
| of | helper | noise | 1 |
| and | helper | digit linker | 1 |
| to | helper | power trigger (v6) | 1 |
| with | helper | $P_Action | 1 |
| using | helper | $P_Action | 2 |
| by | helper | $P_Action | 1 |
| under | helper | $P_Passiv | 2 |
| undergoing | helper | $P_Passiv | 4 |
| addition | helper | $N_Add (+) | 3 |
| subtraction | helper | $N_Sub (-) | 3 |
| multiplication | helper | $N_Mul (*) | 5 |
| division | helper | $N_Div (/) | 3 |

### 1.2 COUNTKU_MULTI (Multi-Word Patterns)

Longest-first matching patterns for phrases that span multiple words:

| Words | Math | Syl | Op | Notes |
|-------|------|-----|----|-------|
| to the power of | ** | 5 | d17 | Power trigger (v6 deferred) |
| to the power | ** | 4 | d17 | Short power trigger |
| square root of | Math.sqrt( | 4 | d06 | |
| cube root of | Math.cbrt( | 4 | d07 | |
| nth root of | Math.pow($,1/N) | 4 | d08 | Ordinal placeholder |
| natural log of | Math.log( | 4 | d16 | |
| log base N of | Math.log($)/Math.log(N) | 5 | d18 | With base parameter |
| inverse of | 1/$ | 4 | d09 | |
| sine of | Math.sin( | 2 | d10 | |
| cosine of | Math.cos( | 3 | d11 | |
| tangent of | Math.tan( | 3 | d12 | |
| secant of | 1/Math.cos( | 3 | d13 | |
| cosecant of | 1/Math.sin( | 4 | d14 | |
| cotangent of | 1/Math.tan( | 4 | d15 | |
| arcsine of | Math.asin( | 3 | | |
| arccosine of | Math.acos( | 4 | | |
| arctangent of | Math.atan( | 4 | | |
| half of | (1/2)* | 2 | d37 | Sets pendingHalf |
| double | 2* | 2 | d38 | Sets pendingDouble |
| twice | 2* | 1 | | |
| the influence of | - | 5 | noise | $P00_Noise |
| the total of | - | 4 | noise | $P00_Noise |
| the effect of | - | 4 | noise | $P00_Noise |
| an effect of | - | 4 | noise | $P00_Noise |
| a total of | - | 4 | noise | $P00_Noise |
| under the influence of | - | 7 | noise | $P00_Noise |
| subtraction from | FLIP_SUB | 4 | d41 | B - A flip |
| multiplied by | * | 5 | | |
| divided by | / | 4 | | |
| euler's number | Math.E | 5 | | |

### 1.3 COUNTKU_ORDINALS

| Word | Value | Syl |
|------|-------|-----|
| first | 1 | 1 |
| second | 2 | 2 |
| third | 3 | 1 |
| fourth | 4 | 1 |
| fifth | 5 | 1 |
| sixth | 6 | 1 |
| seventh | 7 | 2 |
| eighth | 8 | 1 |
| ninth | 9 | 1 |
| tenth | 10 | 1 |
| eleventh | 11 | 3 |
| twelfth | 12 | 1 |
| nth | N | 1 |

### 1.4 ORDINAL_COMPOSERS (v6)

Composing ordinals that combine with following single-digit ordinals:

| Word | Base Value |
|------|------------|
| twentieth | 20 |
| thirtieth | 30 |
| fortieth | 40 |
| fiftieth | 50 |
| sixtieth | 60 |
| seventieth | 70 |
| eightieth | 80 |
| ninetieth | 90 |

*Usage:* "sixty eighth" → 60 + 8 = 68

---

## 2. Engine Architecture

### 2.1 Tokenization Pipeline

```
Input: "the square root of nine plus two"
  ↓
[Clean] Strip punctuation, commas, trailing .!?
  ↓
[Multi-word Match] Longest-first pattern matching
  ↓
[Token Stream] [{type:'multi', pattern:d06, words:['the','square','root','of']}, 
                 {type:'single', word:'nine'}, 
                 {type:'single', word:'plus'}, 
                 {type:'single', word:'two'}]
  ↓
[convertTokens] Process tokens → JS math expression
  ↓
Output: "Math.sqrt(9)+2"
```

### 2.2 convertTokens() State Machine (v6)

**Per-token state:**
| Variable | Purpose |
|----------|---------|
| `parts[]` | Accumulated expression fragments |
| `openParens` | Count of unclosed parentheses |
| `lastWasNumber` | Previous token was a number |
| `prepMode` | null / 'action' / 'passiv' |
| `expectingFuncClose` | Function opened, waiting for arg |
| `inDecimal` | Inside decimal (after "point") |
| `pendingHalf/Double` | d37/d38 prefix operators |

**Deferred emission state (v6):**
| Variable | Purpose |
|----------|---------|
| `powerMode` | null / 'to' / 'ordinal' |
| `powerDegree` | Stored degree for ordinal power |
| `powerBaseExpr` | Base expression string |
| `powerWrap` | 'full' (entire expr) / 'lastTerm' |
| `prefixParts` | Parts before last term (for lastTerm wrap) |
| `rootMode` | Boolean: in root mode |
| `rootDegree` | Root degree string |
| `toReverso` | Boolean: 1/N reversal |
| `toOrdinalDegree` | Captured ordinal degree |

### 2.3 $P_Action vs $P_Passiv Semantics

| Flag | Trigger Words | Scope | Example Input | Output |
|------|--------------|-------|---------------|--------|
| $P_Action | using, with, by | Entire preceding expression | `five plus three using the power of two` | `(5+3)**2` |
| $P_Passiv | undergoing, under | Only last term | `five plus three under the power of two` | `5+(3)**2` |

**Implementation:**
- `$P_Action`: `powerBaseExpr = parts.join('')` (everything)
- `$P_Passiv`: `splitLastTerm(parts)` splits at last top-level operator

### 2.4 splitLastTerm()

Splits `parts` array at the last top-level operator:

```javascript
// Input parts: ['5', '+', '3', '*', '2']
// Depth tracking: + is at depth 0, * is at depth 0
// Last top-level op: '*'
// Result: { before: ['5', '+', '3', '*'], term: '2' }

// Input parts: ['Math.sin(', '1', ')', '+', '5']
// Depth: Math.sin( → depth 1, ) → depth 0, + at depth 0
// Result: { before: ['Math.sin(', '1', ')', '+'], term: '5' }
```

### 2.5 sumDigitGroups()

Sums consecutive numeric tokens:

```javascript
// Input:  ['1000', '800', '58', '+', '3']
// Output: ['1858', '+', '3']
//
// Input:  ['10', '5', '*', '2']
// Output: ['15', '*', '2']
```

---

## 3. Conversion Examples

### 3.1 Basic Arithmetic

| Input | Expression | Result |
|-------|-----------|--------|
| one plus two | 1+2 | 3 |
| five minus three | 5-3 | 2 |
| four times six | 4*6 | 24 |
| eight divided by two | 8/2 | 4 |
| ten over five | 10/5 | 2 |

### 3.2 Number Composition

| Input | Expression | Notes |
|-------|-----------|-------|
| twenty one | 21 | Tens + ones |
| one hundred | 100 | Base + multiplier |
| one hundred twenty three | 123 | Hundreds + tens + ones |
| three thousand four hundred fifty six | 3456 | sumDigitGroups |
| one point five | 1.5 | Decimal |
| one point oh five | 1.05 | Oh as decimal zero |

### 3.3 Functions

| Input | Expression | Result |
|-------|-----------|--------|
| the square root of sixteen | Math.sqrt(16) | 4 |
| the cube root of twenty seven | Math.cbrt(27) | 3 |
| the sine of zero | Math.sin(0) | 0 |
| the natural log of e | Math.log(Math.E) | 1 |
| the absolute value of minus five | Math.abs(-5) | 5 |

### 3.4 Powers (v6)

| Input | Expression | Notes |
|-------|-----------|-------|
| two to the power of three | (2)**3 | 8 |
| five to the sixtieth | (5)**60 | Deferred |
| ten to the fourth | (10)**4 | Ordinal degree |
| three squared | 3**2 | Postfix |
| four cubed | 4**3 | Postfix |

### 3.5 Roots (v6)

| Input | Expression | Notes |
|-------|-----------|-------|
| the fourth root of sixteen | (16)**(1/4) | 2 |
| a fiftieth of five | (5)**(1/50) | "of" trigger |
| the tessaric root of one hundred | (100)**(1/4) | Composed ordinal |
| the four hundred sixty eighth root of ten | (10)**(1/468) | Multi-word ordinal |

### 3.6 $P_Action / $P_Passiv (v6)

| Input | Expression | Mode |
|-------|-----------|------|
| five plus three using the power of two | (5+3)**2 | $P_Action: full expr |
| five plus three under the power of two | 5+(3)**2 | $P_Passiv: last term |

### 3.7 Scaling

| Input | Expression | Result |
|-------|-----------|--------|
| half of ten | (1/2)*10 | 5 |
| double five | 2*5 | 10 |
| twice three | 2*3 | 6 |
| ten halved | 10/2 | 5 |
| six doubled | 6*2 | 12 |

---

## 4. Haiku Validator

### 4.1 Fallover Syllable System

Automatic 5-7-5 line detection without explicit delimiters:

```
Current line syllables + next word syllables > target?
  Yes → Start new line
  No  → Add to current line
```

**Example:** "the sine of zero plus the log of one and two"

| Word | Syl | Line Accum | Action |
|------|-----|-----------|--------|
| the | 1 | 1 | Line 1 |
| sine | 1 | 2 | Line 1 |
| of | 1 | 3 | Line 1 |
| zero | 2 | 5 | Line 1 (full) |
| plus | 1 | 1 | Line 2 |
| the | 1 | 2 | Line 2 |
| log | 1 | 3 | Line 2 |
| of | 1 | 4 | Line 2 |
| one | 1 | 5 | Line 2 |
| and | 1 | 6 | Line 2 |
| two | 1 | 7 | Line 2 (full) |

### 4.2 Anti-Splice Words

Words that cannot be split across line boundaries:

```
minus, multiplied, divided, seventeen, seventy, eleven,
hundred, thousand, million, billion, logarithm, absolute,
tangent, cosine, cotangent, secant, cosecant, number, power,
subtracted, subtraction, influence, undergoing, quadrupling,
addition, product, modulo, quadrupled, tripled, euler's,
halving, doubling, tripling, total, effect
```

### 4.3 Variant Tracking

Users must pick ONE variant per category and stick with it:

| Category | Options | Notes |
|----------|---------|-------|
| Zero | zero (2), zed (1), oh (1) | Pick one, can't mix |
| Multiply | times (1), multiplied by (5) | Pick one, can't mix |
| Euler | e (1), euler's number (5) | Pick one, can't mix |

---

## 5. Technical Details

### 5.1 Class Architecture

```javascript
class CountkuConverter {
  convertTokens(tokens) → { expr, parts }  // Main conversion (v6 deferred)
  convertPhrase(phrase) → expr|null        // Tokenize + convert
  countSyllables(phrase) → number          // Syllable count
  tokenize(text) → tokens[]                // Multi-word + single-word
  splitLastTerm(parts) → { before, term }  // v6: $P_Passiv scope
  sumDigitGroups(parts) → parts[]          // v6: digit summing
  resetVariants()                          // Reset variant tracker
  checkVariant(word) → error|null          // Variant consistency
  getSyllables(word) → number|null         // Syllable lookup
}

class HaikuValidator {
  validate(phrase) → { isHaiku, error, lines[] }
}
```

### 5.2 Mode Switching

| Mode | Base | Input Type | Validation |
|------|------|-----------|------------|
| Normal | 10 | JS math expression | Expression evaluation |
| Hard | 2 | JS math expression | Expression evaluation, result shown in binary |
| WTF | 16 | JS math expression | Expression evaluation, result shown in hex |
| Countku | 10 | English words (haiku) | Haiku 5-7-5 + word-to-math conversion |

### 5.3 handleSubmit Flow

```
1. Prevent default form submission
2. Get input value
3. If Countku mode:
   a. Validate haiku structure (5-7-5)
   b. If invalid → shake, show error, return
   c. Convert words to math expression
   d. If conversion error → shake, show error, return
   e. If null → shake, show error, return
   f. exprToEvaluate = converted expression
4. Temporarily set mode to 'normal' (prevent re-conversion)
5. evaluateExpression(exprToEvaluate)
6. Restore original mode
7. Compare result to targetNumber (currentNumber + 1)
8. If match → success animation, increment
9. If no match → failure, end game
```

### 5.4 File Structure

```
index.html              # Standalone single-file application
archive/
  last-stable (v1.0.0).html    # Stable baseline
  version-unknown (v1.1).html  # Live deployment variant
  version-unknown (v1.2).html  # Updated variant
  sakura-count-ninja-v6-*.html # v6 iterations
changelog.md            # Version history
database.txt            # Original specification document
engine-readme.md        # This file
```
"""

let render() = file
