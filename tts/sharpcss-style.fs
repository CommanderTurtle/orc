module TTS.StyleCss

let file = """@font-face {
  font-family: system;
  src: local("Inter"), local("Segoe UI");
}
:root {
  color-scheme: dark;
  --bg: #101516;
  --panel: #171e1f;
  --line: #2c3738;
  --muted: #91a4a5;
  --text: #e9f0ed;
  --accent: #9de7c6;
  --code: #b3c6df;
  font-family: system, ui-sans-serif, sans-serif;
  font-size: 15px;
  background: var(--bg);
  color: var(--text);
}
* {
  box-sizing: border-box;
}
body {
  margin: 0;
}
button,
select,
input,
textarea,
a.button {
  font: inherit;
}
button,
a.button,
.file-button {
  cursor: pointer;
}
button,
a.button {
  display: inline-flex;
  align-items: center;
  justify-content: center;
  gap: 0.5rem;
  padding: 0.65rem 1rem;
  border: 1px solid var(--line);
  border-radius: 9px;
  background: #20292a;
  color: var(--text);
  text-decoration: none;
  transition:
    background 0.15s,
    border-color 0.15s;
}
button:hover,
a.button:hover {
  background: #2b3939;
  border-color: #5c7471;
}
button:disabled {
  opacity: 0.4;
  cursor: wait;
}
:focus-visible {
  outline: 2px solid var(--accent);
  outline-offset: 3px;
}
.quiet {
  background: transparent;
  border-color: transparent;
  color: var(--muted);
}
.primary {
  background: var(--accent);
  color: #10271e;
  border-color: var(--accent);
  font-weight: 600;
}
.primary:hover {
  background: #c2f2db;
  color: #10271e;
}
.hint,
.muted {
  color: var(--muted);
  line-height: 1.6;
}
.hint {
  font-size: 0.8rem;
}
p {
  margin: 0.6rem 0 1.3rem;
}
h1,
h2 {
  margin: 0;
  font-weight: 500;
  letter-spacing: -0.035em;
}
h1 {
  font-size: clamp(2rem, 4.2vw, 3rem);
}
h2 {
  font-size: 1rem;
}
header,
footer {
  max-width: 1260px;
  margin: auto;
  display: flex;
  align-items: center;
  padding: 1.4rem 2rem;
  gap: 1.6rem;
}
header {
  border-bottom: 1px solid var(--line);
}
a {
  color: var(--accent);
}
.brand {
  text-decoration: none;
  color: var(--text);
  font-size: 1.15rem;
  font-weight: 650;
  display: flex;
  align-items: center;
  gap: 0.6rem;
}
.mark {
  color: var(--accent);
  font-size: 2rem;
  line-height: 1;
}
.local {
  font-size: 0.75rem;
  color: var(--muted);
  display: flex;
  align-items: center;
  gap: 0.4rem;
}
.local i {
  width: 6px;
  height: 6px;
  border-radius: 50%;
  background: var(--accent);
}
header .quiet {
  margin-left: auto;
  font-size: 0.75rem;
}
main {
  max-width: 1180px;
  margin: auto;
  padding: 2.5rem 2rem;
}
.intro {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 2rem;
}
.eyebrow {
  font:
    0.68rem ui-monospace,
    monospace;
  letter-spacing: 0.16em;
  color: var(--accent);
  margin: 0 0 1rem;
}
.intro .muted {
  margin: 0.6rem 0 0;
}
.ambient {
  height: 90px;
  display: flex;
  gap: 6px;
  align-items: center;
  padding-right: 1rem;
}
.ambient b {
  display: block;
  width: 5px;
  height: 25%;
  background: var(--accent);
  border-radius: 9px;
  opacity: 0.35;
}
.ambient b:nth-child(3n) {
  height: 65%;
}
.ambient b:nth-child(4n) {
  height: 90%;
}
.ambient b:nth-child(5n) {
  height: 45%;
}
.modes {
  display: grid;
  grid-template-columns: repeat(3, 1fr);
  gap: 1rem;
  margin-bottom: 1.5rem;
}
.modes button {
  padding: 1rem;
  justify-content: start;
  color: var(--muted);
  background: transparent;
  gap: 0.8rem;
  font-size: 0.7rem;
}
.modes strong {
  font-weight: 500;
  font-size: 1rem;
  color: var(--text);
}
.modes span {
  margin-left: auto;
}
.modes [aria-pressed="true"] {
  border-color: #79b69c;
  background: #192922;
  box-shadow: inset 0 2px var(--accent);
}
.studio {
  display: grid;
  grid-template-columns: 255px 1fr;
  border: 1px solid var(--line);
  border-radius: 16px;
  overflow: hidden;
  background: var(--panel);
  min-height: 450px;
}
.studio[hidden],
[hidden] {
  display: none !important;
}
aside {
  padding: 1.5rem;
  border-right: 1px solid var(--line);
  background: #141b1c;
}
aside h2 {
  margin-bottom: 1.4rem;
}
label {
  display: block;
  color: var(--muted);
  font-size: 0.8rem;
  margin-bottom: 1rem;
}
select,
textarea,
input[type="text"] {
  width: 100%;
  border: 1px solid var(--line);
  border-radius: 8px;
  background: #101718;
  color: var(--text);
  padding: 0.7rem;
  outline: none;
}
select {
  margin-top: 0.5rem;
  font-size: 0.85rem;
}
textarea {
  resize: vertical;
  line-height: 1.65;
}
label textarea {
  margin-top: 0.6rem;
  font-size: 0.85rem;
}
input[type="range"] {
  width: 100%;
  accent-color: var(--accent);
  margin-top: 1rem;
}
.range-label output {
  float: right;
  font-variant-numeric: tabular-nums;
}
.workspace {
  padding: 1.5rem 1.7rem;
  min-width: 0;
  display: flex;
  flex-direction: column;
  gap: 1rem;
}
.section-head,
.actions {
  display: flex;
  justify-content: space-between;
  align-items: center;
  gap: 1rem;
}
.section-head > div,
.actions > div {
  display: flex;
  gap: 0.5rem;
}
.section-head button {
  font-size: 0.75rem;
  padding: 0.4rem 0.6rem;
}
.file-button {
  font-size: 0.75rem;
  color: var(--accent);
  margin: 0;
  padding: 0.4rem;
  border: 1px dashed var(--line);
  border-radius: 6px;
}
.file-button input,
.drop input {
  position: absolute;
  width: 1px;
  height: 1px;
  opacity: 0;
}
.file-button:focus-within,
.drop:focus-within {
  outline: 2px solid var(--accent);
}
#script,
#document {
  min-height: 275px;
  flex: 1;
  border-color: transparent;
  background: transparent;
  padding: 0;
  font-size: 1rem;
}
#document {
  font-family: ui-monospace, monospace;
  font-size: 0.9rem;
}
#script:focus,
#document:focus {
  outline: none;
}
textarea:focus {
  border-color: #6caa90;
}
.player {
  padding-top: 1rem;
  border-top: 1px solid var(--line);
}
audio {
  width: 100%;
  margin: 0.8rem 0;
}
.player .section-head {
  font-size: 0.8rem;
  color: var(--muted);
}
.player .actions button,
.player .actions a {
  font-size: 0.8rem;
}
.capture {
  height: 150px;
  position: relative;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
}
.capture canvas {
  position: absolute;
  inset: 25px 0;
  width: 100%;
  height: 90px;
  opacity: 0.75;
  pointer-events: none;
}
.capture p {
  z-index: 1;
  background: var(--panel);
  padding: 0.3rem 0.7rem;
  font-size: 0.75rem;
  margin: 0.6rem 0;
  color: var(--muted);
}
.mic {
  z-index: 1;
  background: var(--accent);
  color: #132d22;
  width: 60px;
  height: 60px;
  border-radius: 50%;
  border: 0;
  box-shadow: 0 0 0 8px #9de7c60a;
}
.mic svg {
  width: 25px;
  fill: none;
  stroke: currentColor;
  stroke-width: 1.7;
  stroke-linecap: round;
}
.mic.recording {
  background: #f4ad8e;
  box-shadow: 0 0 0 10px #f4ad8e10;
}
.drop {
  border: 1px dashed #3c5050;
  border-radius: 10px;
  text-align: center;
  padding: 1rem;
  margin: 0;
  color: var(--text);
  font-size: 0.85rem;
  cursor: pointer;
}
.drop span {
  display: block;
  margin-top: 0.4rem;
  font-size: 0.7rem;
  color: var(--muted);
}
.drop.over {
  border-color: var(--accent);
  background: #9de7c60a;
}
#transcript {
  min-height: 140px;
  background: #101718;
}
.pending {
  font-size: 0.85rem;
  color: var(--accent);
  font-style: italic;
  min-height: 1.2rem;
  margin: -0.5rem 0 0;
}
.status-bar {
  display: flex;
  align-items: center;
  gap: 1rem;
  margin-top: 1.2rem;
  min-height: 35px;
  font:
    0.75rem ui-monospace,
    monospace;
  color: var(--muted);
}
.status-bar button {
  margin-left: auto;
  font-size: 0.75rem;
}
.status-bar progress {
  width: 120px;
  height: 5px;
  accent-color: var(--accent);
}
.status-bar.error {
  color: #f4ad8e;
}
pre {
  font:
    0.8rem/1.65 ui-monospace,
    monospace;
  background: #0e1415;
  border: 1px solid var(--line);
  padding: 1rem;
  border-radius: 8px;
  white-space: pre-wrap;
  overflow-wrap: anywhere;
  max-height: 400px;
  overflow: auto;
  color: var(--code);
}
footer {
  border-top: 1px solid var(--line);
  color: var(--muted);
  font-size: 0.7rem;
}
footer span {
  margin-right: auto;
}
footer a {
  color: var(--muted);
  text-decoration: none;
}
@media (max-width: 800px) {
  main {
    padding: 1.8rem 1rem;
  }
  header,
  footer {
    padding: 1rem;
    gap: 1rem;
  }
  .studio {
    grid-template-columns: 1fr;
  }
  .studio aside {
    border-right: 0;
    border-bottom: 1px solid var(--line);
    display: grid;
    grid-template-columns: 1fr 1fr;
    gap: 0.6rem 1rem;
  }
  .studio aside h2,
  .studio aside > p {
    grid-column: 1/-1;
    margin-bottom: 0.3rem;
  }
  .studio aside label {
    margin: 0;
  }
  .studio aside label:has(#prompt) {
    grid-column: 1/-1;
  }
  .modes {
    gap: 0.5rem;
  }
  .modes button {
    padding: 0.8rem 0.6rem;
    gap: 0.4rem;
  }
  .modes span {
    display: none;
  }
  .modes strong {
    font-size: 0.85rem;
  }
  .ambient {
    display: none;
  }
  .workspace {
    padding: 1.3rem;
  }
  footer {
    flex-wrap: wrap;
  }
  #tts-size {
    grid-row: 2;
  }
  .actions {
    flex-wrap: wrap;
  }
  .local {
    display: none;
  }
}
@media (prefers-reduced-motion: reduce) {
  * {
    transition: none !important;
  }
}
"""

let render() = file
