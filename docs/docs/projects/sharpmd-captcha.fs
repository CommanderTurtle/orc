module ConvertedFiles.Docs.Projects.CaptchaMd

let file = """# CAPTCHA System

A multi-modal CAPTCHA and anti-bot system combining dice-based authentication, invisible Unicode steganography for hiding the redirect, and CSS selector parsing. The system provides layered bot detection that is resistant to automated solving while remaining accessible to human users. It also implements [black door validation](https://www.reddit.com/r/tasker/comments/30g6vl/how_to_root_my_automated_skyrim_themed_lock_screen/){:rel="noopener noreferrer" target="blank"}.

---

## Overview

???+ note "What this page covers"
    Multi-modal CAPTCHA system with four verification layers: dice authentication overlay, Unicode steganography, and CSS validation. For the invisible Unicode character reference, see [aem1k.com/invisible/encoder](https://aem1k.com/invisible){:rel="noopener noreferrer" target="blank"}. For related tutorializing, see the [legacy vibe documentation](https://vibe.shel.sh/projects/captcha/docs/){:rel="noopener noreferrer" target="blank"}.

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
// converts a given string into a sequence of [] symbols
function convert(input) {
  return [...input].map(c => {
    // Convert character to 8-bit binary
    const binary = c.charCodeAt(0).toString(2).padStart(8, '0');

    // Map each bit to the corresponding invisible character
    return [...binary].map(b => b == "0" ? "\uFFA0" : "\u3164").join('');
    // return binary;
  }).join('');
}

const library = `new Proxy({},{get:(_,n)=>eval([...n].map(n=>+("ﾠ">n)).join\`\`.replace(/.{8}/g,n=>String.fromCharCode(+("0b"+n))))}).
// INVISIBLE CODE STARTS HERE`;

function convertInput(){
  const newValue = convert(document.getElementById('input').value);
  document.getElementById('output').value = `${library}
${newValue}
// INVISIBLE CODE ENDS HERE`;
}

document.getElementById('input').addEventListener('input', (event) => {
  convertInput();
});

document.getElementById('convert').addEventListener('click', (event) => {
  convertInput()
  event.preventDefault();
});

document.getElementById('run').addEventListener('click', (event) => {
  event.preventDefault();
  eval(document.getElementById('output').value);
});

convertInput();
```

The relevant understanding comes from [aem1k](https://aem1k.com){:rel="noopener noreferrer" target="blank"}, a professional codegolfer and security analyst.


This technique:

1. Creates an empty object wrapped in a Proxy
2. Intercepts all property access (`obj.anything`)
3. Converts the property name to binary by checking if each character is less than U+FFA0
4. Groups binary into 8-bit bytes
5. Converts bytes to characters via `String.fromCharCode`
6. Executes the resulting string as JavaScript via `eval`

```javascript
window.open("https://example.com/projects", "_blank", "noopener");window.location.replace("https://example.com/fireplaceholder"); // Example dual-redirect eval      //
```

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

## Layer 4: Fun Quines

[The quine layer](https://aem1k.com/fire/quine/){:rel="noopener noreferrer" target="blank"} was actually just an extra addition appended to the redirect, as well as a self-replicating element on the screen that would lag out someone using`inspect element`. Go ahead and try! Ctrl+Shift+I 

---

# Implementation

[source code](https://vibe.shel.sh/projects/captcha/docs/raw.txt){:rel="noopener noreferrer" target="blank"} - The CAPTCHA system is designed for non-intrusive integration. The button to activate (you add this) is the primary visible layer; other layers operate transparently.


### Where to Put the Three Parts

#### Your Existing HTML Structure..

```html
<!DOCTYPE html>
<html>
<head>
    <!-- Your existing stuff like title, other CSS -->
</head>
<body>
    <!-- Your existing content -->
    <h1>Welcome to My Site</h1>
    <button>Login</button>
</body>
</html>
```

??? tip "1. The Styling (CSS) → Goes in `<head>`"
    Copy everything between `<style>` and `</style>` from my code, and paste it inside your `<head>` tags:

    ```html
    <head>
        <!-- Your existing stuff -->
        <style>
            /* PASTE THE ENTIRE CSS BLOCK HERE */
            #gambling-auth-overlay {
                position: fixed;
                /* ... everything else ... */
            }
        </style>
    </head>
    ```

??? tip "2. The Overlay HTML → Goes in `<body>`"
    Copy the big div that starts with `<div id="gambling-auth-overlay">` and paste it **anywhere** inside your `<body>` (usually at the bottom is cleanest):

    ```html
    <body>
        <!-- Your existing content stays here -->
        <h1>Welcome to My Site</h1>

        <!-- PASTE THE OVERLAY DIV HERE -->
        <div id="gambling-auth-overlay">
            <!-- All the screens inside -->
        </div>
    </body>
    ```

??? tip "3. The JavaScript → Goes at the very bottom before `</body>`"
    Copy the `<script>` section and paste it right before your closing `</body>` tag:

    ```html
    <body>
        <!-- Your content -->
        <!-- The overlay div from step 2 -->

        <!-- PASTE JAVASCRIPT HERE -->
        <script>
            const GamblingAuth = {
                // All the code...
            };
        </script>
    </body>
    ```

??? tip "How to Call It (Button vs Link)"

    **❌ Don't use href** - that tries to navigate to a new page. Instead:

    **Option A: Button (Best)**
    ```html
    <button onclick="GamblingAuth.init()">Login</button>
    ```

    **Option B: Link that looks like a button**
    ```html
    <a href="#" onclick="GamblingAuth.init(); return false;" style="text-decoration:none;">
        <button>Login</button>
    </a>
    ```

    **Option C: Any clickable element**
    ```html
    <div onclick="GamblingAuth.init()" style="cursor:pointer; background:blue; color:white; padding:10px;">
        Click here to authenticate
    </div>
    ```

??? tip "Complete Minimal Example"

    Here's what your final file should look like if you started with almost nothing:

    ```html
    <!DOCTYPE html>
    <html lang="en">
    <head>
        <meta charset="UTF-8">
        <title>My Website</title>

        <!-- STEP 1: PASTE ALL THE CSS HERE -->
        <style>
            #gambling-auth-overlay {
                position: fixed;
                top: 0; left: 0; width: 100vw; height: 100vh;
                /* ... rest of the CSS from the code ... */
            }
            /* ... all the way to the end of the style section ... */
        </style>
    </head>
    <body>
        <!-- Your existing page content -->
        <h1>My Awesome Website</h1>
        <p>Please log in to continue</p>

        <!-- This button triggers the overlay -->
        <button onclick="GamblingAuth.init()">Secure Login</button>

        <!-- STEP 2: PASTE THE OVERLAY HTML HERE -->
        <div id="gambling-auth-overlay">
            <div class="bg-particles" id="particles"></div>
            <!-- All the screen divs (wheel-screen, ready-screen, etc.) -->
        </div>

        <!-- STEP 3: PASTE THE JAVASCRIPT HERE -->
        <script>
            const GamblingAuth = {
                // All the JavaScript code...
            };
        </script>
    </body>
    </html>
    ```

    **Pro tip:** If you have an existing CSS file, you can put the overlay CSS there instead of in `<style>` tags. Same for JavaScript - if you have a `.js` file, you can paste the script there and include it with `<script src="yourfile.js"></script>` at the bottom.

    Does that make sense? The overlay sits "on top" of your page (like a popup) but it's built into the same file!


---

## Related Deep Hole

- [CAPTCHA Project Repository](https://github.com/CommanderTurtle/orc/tree/main/pages/projects/captcha){:rel="noopener noreferrer" target="blank"} — Source code and documentation
- [CAPTCHA Documentation](https://vibe.shel.sh/projects/captcha/docs/){:rel="noopener noreferrer" target="blank"} — Implementation guide
- [Invisible Encoder](https://vibe.shel.sh/projects/captcha/invisible/encoder){:rel="noopener noreferrer" target="blank"} — U+FFA0 steganographic encoder
- [Aem1k Codegolf](https://aem1k.com/){:rel="noopener noreferrer" target="blank"} — JavaScript and Unicode experiments
- [Invisible Unicode Characters](https://invisible-characters.com/){:rel="noopener noreferrer" target="blank"} — Reference of invisible Unicode code points
- [Code Golf: Whitespace](https://codegolf.stackexchange.com/questions/tagged/whitespace){:rel="noopener noreferrer" target="blank"} — Community invisible character challenges
"""

let render() = file
