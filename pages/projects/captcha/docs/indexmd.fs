module ConvertedFiles.Projects.Captcha.Docs.IndexMd

let file = """[[view raw]](./raw.txt)

[[view page in action] - uses example button (easily placable anywhere on existing page)](../)

Like so:

<br>

<img src="data:image/png;base64,""" + Image.CaptchaOverlayExample + """" alt="ACCESSIBILITY" style="max-width:100;width:300px;height:auto;"><br><span style="font-size:13px; color:#666;">Figure 1 — How to implement overlay</span>
<br>

# For implementation of a "sickh" captcha / anti-bot button:

You don't need to replace your whole file! Think of it like adding three ingredients to your existing recipe. Here's exactly where everything goes:

## Your Existing HTML Structure

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

## Where to Put the Three Parts

### 1. The Styling (CSS) → Goes in `<head>`
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

### 2. The Overlay HTML → Goes in `<body>`
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

### 3. The JavaScript → Goes at the very bottom before `</body>`
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

## How to Call It (Button vs Link)

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

## Complete Minimal Example

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

Want [invisible.js?](../invisible/encoder)

```powershell
<# Any function definition: #>
new Proxy({},{get:(_,n)=>eval([...n].map(n=>+("ﾠ">n)).join``.replace(/.{8}/g,n=>String.fromCharCode(+("0b"+n))))}).
// INVISIBLE CODE STARTS HERE
            ... a bunch of junk ...
// INVISIBLE CODE ENDS HERE

# Example 1: Regular Redirect
window.location.href = "https://example.com";

# Example 2: Open In New Tab
window.open("https://example.com", "_blank");
# This is the js equivalent of <a href="…" target="_blank">

# Example 3: Hard Replace Current Tab (no back button, lol)
window.location.replace("https://example.com");

###############################################
<# Replace or make a function like below ⇣⇣⇣⇣ #>
###############################################

something-random: function() {
new Proxy({},{get:(_,n)=>eval(
    [...n]
        .map(n => +("ﾠ" > n))
        .join``
        .replace(/.{8}/g, n => String.fromCharCode(+("0b" + n)))
)})[
..... put it on this line ..... treat //START //END as if they were the brackets on nearby lines
];
},
```
"""

let render() = file
