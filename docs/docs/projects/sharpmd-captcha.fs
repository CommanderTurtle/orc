module ConvertedFiles.Docs.Projects.CaptchaMd

let file = """# CAPTCHA System

A multi-modal CAPTCHA and anti-bot system combining dice-based authentication, invisible Unicode steganography, and CSS selector parsing. The system provides layered bot detection that is resistant to automated solving while remaining accessible to human users.

---

## Overview

???+ note "What this page covers"
    Multi-modal CAPTCHA system with four verification layers: dice authentication overlay, invisible Unicode steganography (U+FFA0), parsel CSS validation, and quine self-replication. For the invisible Unicode character reference, see [SurroundTest + FreeBlobs](surroundtest-freeblobs.md). For the related XML project encoding work, see [CAPTCHA Unicode](../xml-project/captcha-unicode.md).

---

## Architecture Overview

The CAPTCHA system consists of four distinct verification layers:

```mermaid
flowchart TD
    U["User Request"] --> L1["Layer 1<br/>Dice Overlay"]
    L1 -->|"Pass"| L2["Layer 2<br/>Invisible Unicode<br/>Encoder"]
    L2 -->|"Pass"| L3["Layer 3<br/>Parsel CSS<br/>Selector"]
    L3 -->|"Pass"| L4["Layer 4<br/>Quine<br/>Self-Replication"]
    L4 -->|"Pass"| A["Access<br/>Granted"]
    
    L1 -->|"Fail"| B["Block"]
    L2 -->|"Fail"| B
    L3 -->|"Fail"| B
    L4 -->|"Fail"| B
    
    style A fill:#4a7c59,color:#fff
    style B fill:#8B0000,color:#fff
    style L1 fill:#2d5a3a,color:#fff
    style L4 fill:#5a3a2d,color:#fff
```

Each layer operates independently. A bot must defeat all four layers simultaneously to pass verification.

---

## Layer 1: Dice Authentication Overlay

A full-screen overlay that requires the user to roll virtual dice and match a target pattern. The implementation uses particle physics for visual effects and timing analysis for bot detection.

### Implementation

Three ingredients are added to an existing page:

1. **CSS styling** in `<head>` — Full-screen overlay, particle animations, dice styling
2. **Overlay HTML** in `<body>` — The visual interface (wheel screen, ready screen, roll screen, result screen)
3. **JavaScript** at end of `<body>` — Game logic, timing analysis, verification

### CSS Components

```css
#gambling-auth-overlay {
    position: fixed;
    top: 0;
    left: 0;
    width: 100vw;
    height: 100vh;
    background: rgba(0, 0, 0, 0.95);
    z-index: 999999;
    display: none;
    font-family: 'Segoe UI', system-ui, sans-serif;
}

#gambling-auth-overlay.active {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
}

.bg-particles {
    position: absolute;
    width: 100%;
    height: 100%;
    overflow: hidden;
    pointer-events: none;
}

.particle {
    position: absolute;
    width: 4px;
    height: 4px;
    background: rgba(255, 255, 255, 0.3);
    border-radius: 50%;
    animation: float 15s infinite;
}

@keyframes float {
    0%, 100% { transform: translateY(100vh) rotate(0deg); opacity: 0; }
    10% { opacity: 1; }
    90% { opacity: 1; }
    100% { transform: translateY(-100vh) rotate(720deg); opacity: 0; }
}
```

### Bot Detection via Timing Analysis

The system measures interaction patterns that are difficult for bots to replicate:

| Measurement | Human Typical | Bot Typical | Threshold |
|-------------|--------------|-------------|-----------|
| Initial click delay | 200-2000ms | <50ms or >5000ms | 100-3000ms |
| Dice roll duration | 800-3000ms | Instant or uniform | 500-5000ms |
| Mouse movement entropy | High (jitter) | Low (linear) | >0.7 entropy |
| Touch event pressure | Variable | Constant | Standard deviation >0.1 |
| Result verification time | 500-2000ms | <100ms | 200-3000ms |

### Trigger Integration

Any clickable element can trigger the overlay:

```html
<!-- Button trigger -->
<button onclick="GamblingAuth.init()">Secure Login</button>

<!-- Link trigger -->
<a href="#" onclick="GamblingAuth.init(); return false;">Authenticate</a>

<!-- Div trigger -->
<div onclick="GamblingAuth.init()" style="cursor:pointer;">Click to verify</div>
```

---

## Layer 2: Invisible Unicode Encoder

The invisible encoder uses the Halfwidth Hangul Filler character (`ﾠ`, U+FFA0) to embed executable JavaScript within apparently normal text. This technique creates a steganographic channel where the visible text is irrelevant — the actual code is encoded in the presence or absence of invisible characters.

### Encoding Algorithm

```javascript
/**
 * Invisible Unicode Encoder
 * Encodes JavaScript source into visible text using U+FFA0 as the '1' bit
 */
const InvisibleEncoder = {
    // The invisible character: U+FFA0 HALFWIDTH HANGUL FILLER
    INVISIBLE: '\uFFA0',
    
    /**
     * Encode JavaScript code into a carrier string
     * @param {string} code - JavaScript source to hide
     * @param {string} mask - Visible carrier text (can be anything)
     * @returns {string} Text containing invisible-encoded JavaScript
     */
    encode: function(code, mask) {
        // Convert each character to 8-bit binary
        let binary = '';
        for (let i = 0; i < code.length; i++) {
            binary += code.charCodeAt(i).toString(2).padStart(8, '0');
        }
        
        // Map binary to visible/invisible characters
        let result = '';
        let maskIdx = 0;
        for (let i = 0; i < binary.length; i++) {
            if (binary[i] === '1') {
                result += this.INVISIBLE;
            } else {
                // Use a visible character from the mask
                result += mask[maskIdx % mask.length];
                maskIdx++;
            }
        }
        
        return result;
    },
    
    /**
     * Decode invisible-encoded text back to JavaScript
     * @param {string} encoded - Text with invisible characters
     * @returns {string} Original JavaScript source
     */
    decode: function(encoded) {
        let binary = '';
        for (let i = 0; i < encoded.length; i++) {
            binary += encoded[i] === this.INVISIBLE ? '1' : '0';
        }
        
        let result = '';
        for (let i = 0; i < binary.length; i += 8) {
            const byte = binary.slice(i, i + 8);
            if (byte.length < 8) break;
            result += String.fromCharCode(parseInt(byte, 2));
        }
        
        return result;
    }
};
```

### Proxy-Based Execution

The decoded JavaScript is executed through a Proxy object that intercepts property access:

```javascript
// INVISIBLE CODE STARTS HERE
new Proxy({}, {
    get: (_, n) => eval(
        [...n].map(n => +("\uFFA0" > n))
        .join``
        .replace(/.{8}/g, n => String.fromCharCode(+("0b" + n)))
    )
});
// INVISIBLE CODE ENDS HERE
```

This technique:
1. Creates an empty object wrapped in a Proxy
2. Intercepts all property access (`obj.anything`)
3. Converts the property name to binary by checking if each character is less than U+FFA0
4. Groups binary into 8-bit bytes
5. Converts bytes to characters via `String.fromCharCode`
6. Executes the resulting string as JavaScript via `eval`

### Security Properties

| Property | Analysis |
|----------|----------|
| Copy-paste resistance | Invisible characters survive copy-paste in most environments |
| OCR resistance | Invisible characters cannot be optically recognized |
| Screen reader resistance | Screen readers typically skip U+FFA0 |
| Binary analysis resistance | Appears as random text in hex dumps |
| Length overhead | 8x expansion (1 byte = 8 visible/invisible choices) |

---

## Layer 3: Parsel CSS Selector Validation

Parsel validates that the client can correctly parse CSS selectors, a capability that distinguishes full browser engines from simplified HTTP clients.

### Validation Method

The server generates a random CSS selector and asks the client to identify matching elements:

```javascript
// Server generates challenge
const challenge = {
    selector: 'div[data-verify]:not(.bot) > span:nth-child(3)',
    expected: ['element-id-42', 'element-id-73'],
    timeout: 5000
};

// Client must execute querySelectorAll and return matching IDs
const matches = document.querySelectorAll(challenge.selector);
const result = Array.from(matches).map(el => el.id);

// Server validates
if (JSON.stringify(result.sort()) === JSON.stringify(challenge.expected.sort())) {
    // Pass
}
```

### Selector Complexity Progression

| Level | Example | Purpose |
|-------|---------|---------|
| 1 | `#id` | Basic ID selection |
| 2 | `.class[attr]` | Attribute presence |
| 3 | `:not(.class)` | Negation pseudo-class |
| 4 | `> child` | Direct child combinator |
| 5 | `~ sibling` | General sibling combinator |
| 6 | `:nth-child(2n+1)` | Structural pseudo-class |
| 7 | `:is(a, b, c)` | Matches-any pseudo-class |
| 8 | Complex nested | Full combinator chain |

---

## Layer 4: Quine Self-Replication

The quine layer verifies that the page HTML is intact and unmodified by requiring the client to reproduce a cryptographic hash of the page source.

### Implementation

```html
<!DOCTYPE html>
<html>
<head>
    <script>
        // Verify page integrity
        async function verifyIntegrity() {
            const response = await fetch(window.location.href);
            const html = await response.text();
            const hash = await crypto.subtle.digest('SHA-256', 
                new TextEncoder().encode(html)
            );
            const hashHex = Array.from(new Uint8Array(hash))
                .map(b => b.toString(16).padStart(2, '0'))
                .join('');
            
            // Compare with server-provided expected hash
            return hashHex === expectedHash;
        }
    </script>
</head>
<body>
    <!-- The page is a quine: it can reproduce itself -->
</body>
</html>
```

---

## Integration Guide

### Adding to Existing Pages

The CAPTCHA system is designed for non-intrusive integration. The dice overlay is the primary visible layer; other layers operate transparently.

```html
<!DOCTYPE html>
<html>
<head>
    <title>My Website</title>
    <!-- 1. PASTE CAPTCHA CSS HERE -->
    <style>
        #gambling-auth-overlay { /* ... */ }
    </style>
</head>
<body>
    <!-- Your existing content -->
    <h1>Welcome</h1>
    <button onclick="GamblingAuth.init()">Login</button>
    
    <!-- 2. PASTE OVERLAY HTML HERE -->
    <div id="gambling-auth-overlay">...</div>
    
    <!-- 3. PASTE JAVASCRIPT HERE -->
    <script src="captcha.js"></script>
</body>
</html>
```

---

## Related Deep Hole

- [CAPTCHA Project Repository](https://github.com/CommanderTurtle/CommanderTurtle.github.io/tree/master/projects/captcha) — Source code and documentation
- [CAPTCHA Documentation](https://github.com/CommanderTurtle/CommanderTurtle.github.io/blob/master/projects/captcha/docs/index.md) — Implementation guide (187 lines)
- [Invisible Encoder](https://github.com/CommanderTurtle/CommanderTurtle.github.io/blob/master/projects/captcha/invisible/encoder) — U+FFA0 steganographic encoder
- [Aem1k Invisible Code](https://aem1k.com/) — JavaScript and Unicode experiments
- [Invisible Unicode Characters](https://invisible-characters.com/) — Reference of invisible Unicode code points
- [Code Golf: Whitespace](https://codegolf.stackexchange.com/questions/tagged/whitespace) — Community invisible character challenges
"""

let render() = file
