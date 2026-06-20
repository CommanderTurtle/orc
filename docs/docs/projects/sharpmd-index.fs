module ConvertedFiles.Docs.Projects.IndexMd

let file = """# Projects

Documentation for individual projects developed as part of the sHEL ecosystem. Each project has its own repository or directory within the main sHEL GitHub Pages repository.

---

## Overview

???+ note "What this page covers"
    This page serves as the index for all sHEL ecosystem projects:

    - **Countku** — Constraint-based language game using English syllable counting
    - **CAPTCHA System** — Multi-modal anti-bot system with invisible Unicode steganography
    - **SurroundTest + FreeBlobs** — Web Audio API surround sound test and Unicode character library
    - **Regedited** — Rust plaintext parse-ment database with O(1) section jumps
    - **Macrohard** — Visual workflow automation with ComfyUI-style node editor

    Each project links to its detailed documentation page below.

---

## Project Index

```mermaid
flowchart TD
    subgraph Projects["sHEL Ecosystem Projects"]
        direction LR
        C["Countku<br/>(Game)"]
        CAP["CAPTCHA<br/>(Security)"]
        S["SurroundTest<br/>(Audio)"]
        F["FreeBlobs<br/>(Unicode)"]
        R["Regedited<br/>(Database)"]
        M["Macrohard<br/>(Automation)"]
    end

    C -->|"Syllable counting<br/>constraints"| CAP
    S -->|"Web Audio API"| C
    F -->|"Invisible chars<br/>steganography"| CAP
    R -->|"Rust parser"| M

    style C fill:#4a90d9
    style CAP fill:#7ed321
    style S fill:#f5a623
    style F fill:#9013fe
    style R fill:#bd10e0
    style M fill:#d0021b
```

---

## Countku

A constraint-based language game that uses English syllable counting as its mathematical foundation. Players construct expressions where the total syllable count of the words must equal a target number.

[Countku Documentation](countku.md)

---

## CAPTCHA System

A multi-modal CAPTCHA and anti-bot system combining dice-based authentication, invisible Unicode steganography, and CSS selector parsing.

[CAPTCHA Documentation](captcha.md)

---

## SurroundTest + FreeBlobs

SurroundTest provides the definitive online surround sound test via Web Audio API. FreeBlobs is a curated library of useful Unicode characters for technical applications.

[SurroundTest + FreeBlobs Documentation](surroundtest-freeblobs.md)

---

## Regedited

A fast plaintext parse-ment database written in Rust. Reimagines structured data storage by combining safetensors-style memory mapping with typed hex-word addressing, enabling O(1) section jumps on multi-gigabyte files.

[Regedited Documentation](regedited.md)

---

## Macrohard

A visual workflow automation platform extending Tasket++ with a ComfyUI-style node editor, IF/THEN/ELSE checkpoint branching, and a typed HTTP trigger daemon. Complete rewrite of ScheduledPasteAndKeys in C++ and TypeScript.

[Macrohard Documentation](macrohard.md)

---

## Related Deep Hole

- [sHEL GitHub Repository](https://github.com/CommanderTurtle/CommanderTurtle.github.io) — Source code for all projects
- [Countku Game](https://commanderturtle.github.io/projects/) — Play Countku online
- [CAPTCHA Demo](https://commanderturtle.github.io/projects/captcha/) — Live CAPTCHA demonstration
- [SurroundTest](https://is.gd/surroundtest) — Online surround sound test
- [Regedited GitHub](https://github.com/CommanderTurtle/regedited) — Rust plaintext database
- [Macrohard GitHub](https://github.com/CommanderTurtle/macrohard) — Visual workflow automation
"""

let render() = file
