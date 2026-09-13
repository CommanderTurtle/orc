module Bl0g.Posts.N20260620CaptchaSideProjectMd

let file = """---
layout: post
title: "2FAgamblah: The Casino You Have to Beat to Log In"
author: "CommanderTurtle"
date: 2026-06-20 14:00:00 +0000
tags: [side-project, security, web, captcha, anti-bot, js]
---

Most CAPTCHA solutions ask you to *prove* you're a human. ReCAPTCHA wants its script in your head, its badge in your footer, and a server round-trip on every form submission. hCaptcha isn't much different. They're effective but heavy — external dependencies, behavioral profiling, significant page weight, and a UX that treats every visitor as a suspected bot first and a human second.

**Turtle Protect** — working name, still the best name — asks you to do something else instead: *play a casino and win your way into the page.* The reference implementation is called **2FAgamblah**, and it is exactly what it sounds like. Two-factor authentication, gamblified.

The project tagline is *"an independent shelling company."* Independent: no external API calls, no third-party dependencies, no tracking pixels. Shelling: the protective outer layer. Company: it just keeps you company on the page you already have. You don't replace your architecture; you add a gate.

## The Gate Has Ten Screens

The gambling overlay is a single self-contained file — 3,400-some lines of scoped CSS, HTML, and one `GamblingAuth` JavaScript object — that runs a ten-screen state machine before it will let you through. The screen IDs tell the story better than I can:

```
login-screen → wheel-screen → ready-screen → blackjack-screen
→ password-screen → horse-screen → dice-screen → roulette-screen
→ finalgame-screen → success-screen
```

Each stage is a different way of testing for the same thing, which is why no single automation strategy can clear the chain:

1. **The Wheel.** You spin a casino wheel that picks your *loading time* — `wheelValues: [0.5, 1, 2, 3, 5, 8, 10, 15]` seconds — then sit through a fake-but-convincing progress bar. Bots that want to skip the animation can't, because the timer is real. The overlay also traps the `Escape` key while active, so there's no accidental bail.
2. **Blackjack.** A real 52-card deck, properly shuffled with a Fisher–Yates pass. You have to make a legal winning hand (or at least not bust your way out of it) to earn the reveal.
3. **Password Reveal.** The system generated a 16-character password at initialization from a 72-character alphabet — and only now, after winning at cards, shows it to you.
4. **Login.** You type the password back in. Wrong, and the screen shakes, the border flashes red, and you try again. This is the actual second factor: the password you just earned is the credential the challenge issues.
5. **Horse Race.** Pick one of five horses — *Thunder Bolt, Lightning Strike, Midnight Runner, Golden Gallop, Storm Chaser (Trust)* — then watch them race with per-lane random speeds and 💨 dust particles trailing the leader. Pick wrong and you retry.
6. **Dice.** Roll for doubles. The dice visually tumble through up to 15 rapid rolls before settling, and only a matching pair passes.
7. **Russian Roulette.** The dark one. You choose how many bullets to load — one or three into a six-chamber cylinder — spin the barrel (a 5,000-degree rotation with the winning chamber computed from the final offset), then pull the trigger. A bang sends you back to re-spin; a click advances you. The stick figure in the corner watches you do it.
8. **The Black Door.** After six games of chance, you walk into a cinematic: fade to black, *"you are alone..."*, another fade, *"wait... you see something"*, and then — the Dark Brotherhood's Black Door, full screen, with the audio from the Skyrim quest playing. You have to answer the riddle by typing the passphrase. Get it wrong and the door says **"You are not worthy"** and offers you a single button: `<walk away>`.
9. **Success.** The door opens. `onComplete` fires. Your original form submission proceeds exactly as if the gate had never been there.

The whole thing is framed as anti-bot because *it is* — but the framing is deliberate. No bot is going to sit through a six-game casino gauntlet, memorize a password, and then answer an audio riddle in an Elder Scrolls quest for the value of one form submission. The games *are* the computation: every stage has timing, randomness, and state that a headless client has to model.

## Four Layers, Documented

The overlay is Layer 1. The project documentation at [docs.shel.sh/projects/captcha](https://docs.shel.sh/projects/captcha/) lays out the rest of the system as four independent verification layers — a bot has to defeat all of them simultaneously.

**Layer 1: the overlay.** Beyond the games, the docs specify *timing analysis* as the detection mechanism, with thresholds tuned to human behavior:

| Measurement | Human typical | Bot typical |
|---|---|---|
| Initial click delay | 200–2000 ms | <50 ms or >5000 ms |
| Dice roll duration | 800–3000 ms | instant or uniform |
| Mouse movement entropy | high (jitter) | low (linear) |
| Touch event pressure | variable | constant |

A bot can beat a specific game; it can't produce human-timing distributions across six of them at once.

**Layer 2: the invisible Unicode encoder.** This one's my favorite. The Halfwidth Hangul Filler character — `ﾠ`, U+FFA0 — is invisible in nearly every rendering context. The encoder maps each bit of your payload to the *presence or absence* of that character, and a one-line decoder embedded in the visible text recovers the bytes:

```js
const library = `new Proxy({},{get:(_,n)=>eval([...n].map(n=>+("ﾠ">n)).join``
  .replace(/.{8}/g,n=>String.fromCharCode(+("0b"+n))))}).`;
```

Read it slowly: a `Proxy` wraps an empty object; every property access `obj.anything` gets intercepted; the property name is itself the steganographic payload — each character is compared against U+FFA0 to extract a bit, bits are grouped into bytes, bytes become characters, and the result is `eval`'d. The visible text can say anything. The actual code is hiding in the whitespace. It survives copy-paste, defeats OCR (you can't optically recognize a character you can't see), defeats screen readers (they skip U+FFA0), and reads as random noise in a hex dump. The cost is an 8x length expansion, which is fine, because the payload is a redirect and a quine.

The reference for this technique comes from aem1k, a codegolfer and security analyst whose [invisible encoder](https://aem1k.com/invisible) the docs link directly. The live 2FAgamblah page uses the same trick in `leaveBigly` — if you open the devtools on the success screen you'll find a wall of `ㅤ` characters that *is* code.

**Layer 3: Parsel CSS selector validation.** The server generates a random CSS selector — say `div[data-verify]:not(.bot) > span:nth-child(3)` — and the client must run `querySelectorAll` and return the matching element IDs. The point is capability testing: a full browser engine parses selectors natively; a simplified HTTP client can't even represent a DOM. The docs define an eight-level complexity progression from bare `#id` up through attribute selectors, `:not()`, the `>` child combinator, `~` siblings, `:nth-child(2n+1)`, `:is()`, and finally full combinator chains.

**Layer 4: the fire quine.** The [quine page](https://aem1k.com/fire/quine/) is a 203-byte self-replicating program in pure HTML+JS that renders an ever-growing field of flame-colored ASCII:

```
<body bgcolor=🔥 onload=setInterval(e='for(h="",a[I++*I%17+578]=i=89;
i++<630;h+=i%30?(x=a[i]=~~((a[i]+a[i+1]+a[i+29]+a[i+30])/4))&&
e[i%142].fontcolor(5<x&&"#FF0"):"\\n")p.innerHTML=h',a=[I=30])><pre id=p>
```

It's appended to the invisible redirect *and* runs on-screen. The docs are candid about its role: it's "a self-replicating element on the screen that would lag out someone using inspect element." Go ahead and try it — Ctrl+Shift+I. The quine keeps drawing, the page keeps lagging, and your inspector tab becomes a second flame. It's the anti-devtools layer: the tool you'd reach for to cheat is the one that breaks.

## Integration: Three Ingredients

The gate is designed for non-intrusive drop-in. Your existing page keeps working; you add three pieces:

1. **The CSS** — pasted into your `<head>`, fully scoped under `#gambling-auth-overlay` with every animation prefixed `ga-` so it can't pollute the host page.
2. **The overlay HTML** — one `<div id="gambling-auth-overlay">` pasted anywhere in your `<body>`.
3. **The JavaScript** — at the very bottom, before `</body>`.

Then any clickable element becomes the trigger:

```html
<button onclick="GamblingAuth.init()">Secure Login</button>

<a href="#" onclick="GamblingAuth.init(); return false;">Authenticate</a>
```

Because the overlay operates at the DOM level, it's framework-agnostic — vanilla HTML, React, Vue, whatever. Your framework doesn't need to know it exists. On success, `GamblingAuth` calls the `onComplete` callback you passed to `init` and your original logic runs. Intercept, verify, release.

## Why Not Just Use reCAPTCHA?

Three reasons, unchanged since the project started:

**Privacy.** Zero external network requests. No Google servers, no tracking cookies, no behavioral profiling — the whole gate runs inside the document.

**Control.** You own the challenge, the validation, and the UX. Want a seventh game? It's your code. Want different branding? It's your CSS. No API keys, no quotas, no terms-of-service change breaking your login flow at 3 AM.

**Weight and dependencies.** One file, no SDK, no badge, no widget injection into your document tree.

## The Timeline

The captcha work landed with the sHEL site rebuild: the docs project (docs-pages) went up in early June 2026, and the 2FAgamblah overlay itself was committed to the site repo on **June 20, 2026** — the same week as the vLLM fork, fsharp-zensical, and regedited, which is about when the "everything at once" phase of 2026 happened. It's since been touched a few times (a "vibe adjustment" pass in late July, further refinements in August and September), but the architecture — ten screens, four layers, one quine — has been stable since that first upload.

The philosophy mirrors the broader sHEL approach: dependency-light, self-contained, and a little bit weird. No external calls. No hidden tracking. Just a shell that keeps the bots out — and, on the off chance a bot makes it through all six games, an Elder Scrolls door that tells them they're not worthy.

[View the docs](https://docs.shel.sh/projects/captcha/) | [See the quine](https://aem1k.com/fire/quine/) | [The invisible encoder](https://aem1k.com/invisible)

---

#### xkcd of the day, 6/20 - Side Effect #3261

![xkcd of the day](https://imgs.xkcd.com/comics/side_effect_2x.png)

[[the freedom situation surrounding bambu printers]](https://www.youtube.com/watch?v=7hqVwizTico)

"""

let render() = file
