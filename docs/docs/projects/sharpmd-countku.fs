module ConvertedFiles.Docs.Projects.CountkuMd

let file = """# Countku

Countku is a constraint-based language game that uses English syllable counting as its mathematical foundation. Players construct expressions where the total syllable count of the words must equal a target number. The game operates on the principle that English words can be decomposed into phonetic substrings with known syllable counts, and that these substrings can be combined through mathematical operations to reach precise numerical targets.

---

## Overview

???+ note "What this page covers"
    Countku is a constraint-based language game using English syllable counting as its mathematical foundation. This page documents game rules, database structure, the parsing algorithm, and JavaScript implementation. Play the game at [app.shel.sh/countku](https://app.shel.sh/countku){:rel="noopener noreferrer" target="blank"}. For the related source-code and numbering system, see [the source code](https://github.com/CommanderTurtle/orc/blob/main/app/countku/index.fs){:rel="noopener noreferrer" target="blank"}.

---

## Game Rules

A valid countku consists of a sequence of English words whose syllable counts combine via standard mathematical precedence to equal the target number. The game is unambiguous: every valid countku must evaluate to exactly one number.

### Construction

```mermaid
flowchart TD
    I["Input: 'three hundred and forty-two'"] --> T["Tokenize"]
    T --> G["Grammar Check"]
    G -->|"Valid"| S["Count Syllables"]
    S --> C{"Equals<br/>Target?"}
    C -->|"Yes"| V["VALID COUNTKU"]
    C -->|"No"| X["Invalid"]
    G -->|"Invalid"| X
    
    style V fill:#4a7c59,color:#fff
    style X fill:#5a3a2d,color:#fff
```

1. **Base numbers**: Words with known syllable counts form the foundation. Examples include:
   - "one" (1), "two" (2), "three" (3), "four" (4), "five" (5), "six" (6), "seven" (7), "eight" (8), "nine" (9), "ten" (10)
   - "eleven" (3), "twelve" (1), "thirteen" (2), "fourteen" (2), "fifteen" (2)
   - "twenty" (2), "thirty" (2), "forty" (2), "fifty" (2), "sixty" (2), "seventy" (3), "eighty" (2), "ninety" (2)
   - "hundred" (2), "thousand" (2), "million" (2), "billion" (2), "trillion" (2)

2. **Mathematical operations**: Operations combine base numbers:
   - Addition: "plus", "and" (+)
   - Subtraction: "minus" (-)
   - Multiplication: "times", "multiplied by" (x)
   - Division: "divided by", "over" (/)
   - Functions: "sin", "cos", "tan", "log", "sqrt", "cbrt", "pow"
   - Constants: "pi", "tau", "phi", "e"

3. **Grammar**: A well-formed countku follows the grammatical pattern:
   - Optional scale word ("hundred", "thousand", "million", "billion", "trillion")
   - Base number ("one" through "ninety-nine")
   - Optional mathematical suffix (operation + another countku)

### Precedence

Standard mathematical order of operations applies:

1. Parentheses (grouping)
2. Functions (sin, cos, log, etc.)
3. Exponents and roots (sqrt, cbrt, pow)
4. Multiplication and division
5. Addition and subtraction

### Validation

A countku is valid if and only if:

1. Every word is recognized by the countku database
2. Every word has an unambiguous syllable count
3. The grammatical structure follows the precedence rules
4. The total syllable count equals the target number
5. No circular references exist in the definition

---

## Syllable Appendix:

Database Structure for Scale Words, Function Words, and Constants

- [[view]](https://app.shel.sh/countku/1#data-matricies){:rel="noopener noreferrer" target="blank"}
- [[view raw]](https://app.shel.sh/countku/1.md){:rel="noopener noreferrer" target="blank"}

---

## Parsing Algorithm

The countku parser operates in three phases:

### Phase 1: Lexical Analysis

The input string is split into tokens. Each token is matched against the database. Multi-word operations ("divided by", "multiplied by") are matched before single-word operations to prevent partial matching.

```
Input: "three hundred and forty-two"
Tokens: ["three" (IsBase, 2), "hundred" (IsScale, 2), "and" (IsMathOp, 1), "forty" (IsBase, 2), "-" (punctuation), "two" (IsBase, 1)]
```

### Phase 2: Syntactic Analysis

Tokens are arranged into an abstract syntax tree (AST) following grammatical rules:

```plain
Number := Base [Scale] [Suffix]
Suffix := MathOp Number
```

The parser handles the special case of "and" as a conjunction that can indicate either addition or simply connect a scale to its remainder:

- "three hundred and forty-two" = 342 (not 300 + 42 = 342)
- "three hundred plus forty-two" = 300 + 42 = 342

### Phase 3: Evaluation

The AST is evaluated by summing syllable counts, actively available in the database syllable tree.

The actual countku target is the syllable count, not the numerical value. So:

- "three hundred and forty-two" has 7 syllables, so it is a countku for the number 7
- To get 342, you would need a countku with exactly 342 syllables

---

## JavaScript Implementation

The countku engine is implemented in JavaScript as a browser-based game:

```javascript
// Core parsing function
function parseCountku(input) {
    const tokens = tokenize(input);
    const ast = buildAST(tokens);
    return evaluateSyllables(ast);
}

// Tokenization
function tokenize(input) {
    // Normalize: lowercase, remove extra spaces
    const normalized = input.toLowerCase().trim().replace(/\s+/g, ' ');
    
    // Multi-word operations first
    const multiWordOps = ['divided by', 'multiplied by', 'square root of', 'cube root of'];
    let working = normalized;
    const tokens = [];
    
    // ... tokenization logic
    return tokens;
}
```

---

## Variants

### Countku v7.3 / v7.4

Version 7 introduces enhanced grammatical support and an expanded database:

- **Compound numbers**: "forty-two" (hyphenated) vs "forty two" (space-separated)
- **Fractional expressions**: "one half", "three quarters"
- **Negative numbers**: "negative five", "minus three"
- **Scientific notation**: "ten to the power of six"

There are also a number of other touchups perfected like logarithms, exponents, and trigonometry (pythagorean rules work)

### Engine Reference Manual

The engine reference manual (3.md) documents the full API:

| Method | Description |
|--------|-------------|
| `CountkuEngine.parse(input)` | Parse a countku string |
| `CountkuEngine.validate(ast)` | Validate an AST |
| `CountkuEngine.evaluate(ast)` | Count syllables in an AST |
| `CountkuEngine.suggest(target)` | Suggest countkus for a target number |
| `CountkuEngine.generate(target, complexity)` | Generate random valid countkus |

---

## Related Deep Hole

- [Sokka in avatar](https://avatar.fandom.com/wiki/Transcript:The_Tales_of_Ba_Sing_Se:~:text=at%20Kenji%27s%20statement.-,The%20Tale%20of%20Sokka,-Scene%20changes%20to){:rel="noopener noreferrer" target="blank"} - Sokka's haiku scene in Avatar the Last Airbender
- [Countku Engine Reference](https://app.shel.sh/countku/3.md){:rel="noopener noreferrer" target="blank"} — Engine documentation
- [Syllable Counting in English](https://en.wikipedia.org/wiki/English_phonology){:rel="noopener noreferrer" target="blank"} — Phonological foundation
- [Constraint Satisfaction Problems](https://en.wikipedia.org/wiki/Constraint_satisfaction_problem){:rel="noopener noreferrer" target="blank"} — Mathematical basis
- [jsfuck](https://jsfuck.com/){:rel="noopener noreferrer" target="blank"} — Inspiration for future use as a mathematical invalidator
"""

let render() = file
