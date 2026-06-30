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


## Countku

A constraint-based language game that uses English syllable counting as its mathematical foundation. Players construct expressions where the total syllable count of the words must equal a target number.

[Countku Documentation](countku.md){ data-preview }

---

## CAPTCHA System

A multi-modal CAPTCHA and anti-bot system combining dice-based authentication, invisible Unicode steganography, and CSS selector parsing.

[CAPTCHA Documentation](captcha.md){ data-preview }

---

## Blobs

Random information on the Web Audio API, as well as a blob library of useful Unicode characters for technical applications.

[Blob Documentation](surroundtest-freeblobs.md){ data-preview }

---

## Regedited

A fast plaintext parse-ment database written in Rust. Reimagines structured data storage by combining safetensors-style memory mapping with typed hex-word addressing, enabling O(1) section jumps on multi-gigabyte files.

[Regedited Documentation](regedited.md){ data-preview }

---

## Macrohard

A visual workflow automation platform extending Tasket++ with a ComfyUI-style node editor, IF/THEN/ELSE checkpoint branching, and a typed HTTP trigger daemon. Complete extension utlizing Tasket as a backend library.

[Macrohard Documentation](./macrohard.md){ data-preview }

---

## Related Deep Hole

- [shel.sh GitHub Repository](https://github.com/CommanderTurtle/orc#f-zensical-for-mkdocs--cross-repo-pages-orchestrator){:rel="noopener noreferrer" target="blank"} — Source code for all projects
- [Countku Game](https://app.shel.sh/countku){:rel="noopener noreferrer" target="blank"} — Play Countku online
- [CAPTCHA Demo](https://vibe.shel.sh/projects/captcha/docs/){:rel="noopener noreferrer" target="blank"} — Live CAPTCHA demonstration
- [Regedited](./regedited.md){ data-preview } — Source code and documentation
- [CMD](../xml-project/index.md){ data-preview } — Reproducable format for boolean if-then in C
- [Gemma](./nvfp4.md){ data-preview } — Document on powershell oneliner harnessing a local agent
"""

let render() = file
