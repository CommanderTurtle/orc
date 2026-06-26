module ConvertedFiles.Docs.Projects.SurroundtestFreeblobsMd

let file = """# Blobs

Blobs is a curated library of useful Unicode characters for technical applications including steganography, formatting, and symbol reference.

Also some sound information

---

## Overview

???+ note "What this page covers"
    This page documents utilities:

    - **SurroundTest** — Web Audio API multi-channel surround sound testing (found randomly)
    - **FreeBlobs** — Unicode character reference for invisible characters, brackets, math symbols, box drawing, and arrows

    For invisible Unicode steganography applications, see [CAPTCHA Unicode](../xml-project/captcha-unicode.md). For encoding reference, see [Encoding](../wikispace/security/encoding.md).

---

## SurroundTest

SurroundTest (`is.gd/surroundtest`) is a web-based audio test for multi-channel surround sound systems. It provides channel isolation tests, phase checks, and frequency sweeps through a standard web browser.

### Architecture

```mermaid
flowchart TD
    subgraph Browser["Web Browser"]
        direction TB
        WA["Web Audio API"]
        subgraph Tests["Test Signals"]
            direction TB
            T1["Channel Isolation<br/>440Hz sine"]
            T2["Phase Check<br/>Pink noise"]
            T3["Bass Management<br/>20-200Hz sweep"]
            T4["Frequency Response<br/>20Hz-20kHz sweep"]
        end
        WA --> Tests
        Tests --> OUT["Audio Output<br/>(Multi-channel)"]
    end

    subgraph Configurations["Supported Layouts"]
        direction LR
        C1["Stereo 2.0"]
        C2["5.1 Surround"]
        C3["7.1 Surround"]
        C4["Atmos 7.1.4"]
    end

    OUT --> Configurations

    style Browser fill:#4a90d9
    style Configurations fill:#7ed321
```

### Technical Implementation

The test uses the Web Audio API to generate and route test tones to individual output channels:

```javascript
// Channel isolation test
const audioContext = new AudioContext();
const channels = audioContext.destination.channelCount;

function testChannel(channelIndex) {
    const oscillator = audioContext.createOscillator();
    const panner = audioContext.createPanner();
    const gain = audioContext.createGain();
    
    oscillator.type = 'sine';
    oscillator.frequency.value = 440; // A4 note
    
    // Route to specific channel using channel merger
    const merger = audioContext.createChannelMerger(channels);
    gain.connect(merger, 0, channelIndex);
    merger.connect(audioContext.destination);
    
    gain.gain.value = 0.5;
    oscillator.start();
    
    // Label the channel
    const labels = ['Left', 'Right', 'Center', 'LFE', 'Surround Left', 'Surround Right', 'Rear Left', 'Rear Right'];
    return labels[channelIndex] || `Channel ${channelIndex}`;
}
```

### Supported Configurations

| Configuration | Channels | Speaker Layout |
|-------------|----------|----------------|
| Mono | 1 | Single speaker |
| Stereo | 2 | Left, Right |
| 2.1 | 3 | Left, Right, Subwoofer |
| 3.0 | 3 | Left, Center, Right |
| 3.1 | 4 | Left, Center, Right, Subwoofer |
| 4.0 (Quad) | 4 | Front Left, Front Right, Rear Left, Rear Right |
| 4.1 | 5 | Quad + Subwoofer |
| 5.0 | 5 | Front L/R, Center, Surround L/R |
| 5.1 | 6 | Front L/R, Center, LFE, Surround L/R |
| 6.1 | 7 | 5.1 + Rear Center |
| 7.1 | 8 | Front L/R, Center, LFE, Side L/R, Rear L/R |
| 7.1.2 | 10 | 7.1 + Front Height L/R |
| 7.1.4 | 12 | 7.1 + Front Height L/R + Rear Height L/R |
| 9.1.4 | 14 | 7.1.4 + Wide L/R |

### Test Patterns

| Test | Purpose | Signal |
|------|---------|--------|
| Channel Identification | Verify correct speaker wiring | 440Hz sine per channel, sequential |
| Phase Check | Verify all speakers in phase | Pink noise, alternating polarity |
| Bass Management | Verify subwoofer crossover | Frequency sweep 20-200Hz |
| Delay Calibration | Time-align speakers | Impulse, measure arrival time |
| Frequency Response | Room acoustic analysis | Logarithmic sweep 20Hz-20kHz |
| Dynamic Range | System headroom | 1kHz tone at -60dB to 0dB |

---

## FreeBlobs

FreeBlobs is a reference library of Unicode characters useful for technical applications including steganography, text formatting, terminal output, and symbol substitution.

### Invisible and Zero-Width Characters

```mermaid
flowchart TD
    subgraph Invisible["Invisible / Zero-Width"]
        direction LR
        I1["U+200B<br/>ZW Space"]
        I2["U+200C<br/>ZW Non-Joiner"]
        I3["U+200D<br/>ZW Joiner"]
        I4["U+2060<br/>Word Joiner"]
        I5["U+FEFF<br/>BOM"]
        I6["U+00AD<br/>Soft Hyphen"]
    end

    style Invisible fill:#4a90d9
```

| Character | Code Point | Name | Usage |
|-----------|-----------|------|-------|
| `ﾠ` | U+FFA0 | Halfwidth Hangul Filler | Steganographic bit encoding (1) |
| `​` | U+200B | Zero Width Space | Word boundary, steganographic bit (0) |
| `‌` | U+200C | Zero Width Non-Joiner | Prevents character joining |
| `‍` | U+200D | Zero Width Joiner | Forces character joining |
| `⁠` | U+2060 | Word Joiner | Prevents line breaks |
| `﻿` | U+FEFF | Byte Order Mark / ZWNBSP | File header, invisible marker |
| `­` | U+00AD | Soft Hyphen | Optional hyphenation |
| `͏` | U+034F | Combining Grapheme Joiner | Modifies combining behavior |
| `״` | U+05F4 | Hebrew Punctuation Gershayim | Alternative invisible delimiter |
| `᠆` | U+1806 | Mongolian Todo Soft Hyphen | Rare invisible character |

### Bracket and Quotation Variants

| Character | Code Point | Name | Usage |
|-----------|-----------|------|-------|
| `「` | U+300C | Left Corner Bracket | Japanese quotation |
| `」` | U+300D | Right Corner Bracket | Japanese quotation |
| `『` | U+300E | Left White Corner Bracket | Japanese nested quotation |
| `』` | U+300F | Right White Corner Bracket | Japanese nested quotation |
| `【` | U+3010 | Left Black Lenticular Bracket | Title marker |
| `】` | U+3011 | Right Black Lenticular Bracket | Title marker |
|〖| U+3016 | Left White Lenticular Bracket | Annotation |
|〗| U+3017 | Right White Lenticular Bracket | Annotation |

### Mathematical Symbols

| Character | Code Point | Name | Usage |
|-----------|-----------|------|-------|
| `×` | U+00D7 | Multiplication Sign | Cross product |
| `÷` | U+00F7 | Division Sign | Obelus |
| `−` | U+2212 | Minus Sign | Proper subtraction |
| `±` | U+00B1 | Plus-Minus Sign | Tolerance |
| `∓` | U+2213 | Minus-Plus Sign | Inverse tolerance |
| `≈` | U+2248 | Almost Equal To | Approximation |
| `≠` | U+2260 | Not Equal To | Inequality |
| `≤` | U+2264 | Less-Than or Equal To | Comparison |
| `≥` | U+2265 | Greater-Than or Equal To | Comparison |
| `∞` | U+221E | Infinity | Limits |
| `∅` | U+2205 | Empty Set | Null set |
| `∈` | U+2208 | Element Of | Set membership |
| `∉` | U+2209 | Not an Element Of | Set exclusion |
| `∩` | U+2229 | Intersection | Set intersection |
| `∪` | U+222A | Union | Set union |
| `⊂` | U+2282 | Subset Of | Subset |
| `⊃` | U+2283 | Superset Of | Superset |
| `∴` | U+2234 | Therefore | Logical conclusion |
| `∵` | U+2235 | Because | Logical premise |

### Box Drawing Characters

| Character | Code Point | Name | Usage |
|-----------|-----------|------|-------|
| `─` | U+2500 | Box Drawings Light Horizontal | Table borders |
| `│` | U+2502 | Box Drawings Light Vertical | Table borders |
| `┌` | U+250C | Box Drawings Light Down and Right | Corner |
| `┐` | U+2510 | Box Drawings Light Down and Left | Corner |
| `└` | U+2514 | Box Drawings Light Up and Right | Corner |
| `┘` | U+2518 | Box Drawings Light Up and Left | Corner |
| `├` | U+251C | Box Drawings Light Vertical and Right | T-junction |
| `┤` | U+2524 | Box Drawings Light Vertical and Left | T-junction |
| `┬` | U+252C | Box Drawings Light Down and Horizontal | T-junction |
| `┴` | U+2534 | Box Drawings Light Up and Horizontal | T-junction |
| `┼` | U+253C | Box Drawings Light Vertical and Horizontal | Cross |
| `═` | U+2550 | Box Drawings Double Horizontal | Double border |
| `║` | U+2551 | Box Drawings Double Vertical | Double border |
| `╔` | U+2554 | Box Drawings Double Down and Right | Double corner |
| `╗` | U+2557 | Box Drawings Double Down and Left | Double corner |
| `╚` | U+255A | Box Drawings Double Up and Right | Double corner |
| `╝` | U+255D | Box Drawings Double Up and Left | Double corner |

### Arrows

| Character | Code Point | Name | Usage |
|-----------|-----------|------|-------|
| `←` | U+2190 | Leftwards Arrow | Direction |
| `↑` | U+2191 | Upwards Arrow | Direction |
| `→` | U+2192 | Rightwards Arrow | Direction |
| `↓` | U+2193 | Downwards Arrow | Direction |
| `↔` | U+2194 | Left Right Arrow | Bidirectional |
| `↕` | U+2195 | Up Down Arrow | Vertical bidirectional |
| `⇐` | U+21D0 | Leftwards Double Arrow | Implication |
| `⇒` | U+21D2 | Rightwards Double Arrow | Implication |
| `⇔` | U+21D4 | Left Right Double Arrow | Equivalence |
| `⟶` | U+27F6 | Long Rightwards Arrow | Mapping |

---

## Related Pages

- [CAPTCHA Unicode](../xml-project/captcha-unicode.md){ data-preview } — Invisible Unicode steganography
- [Encoding](../wikispace/security/encoding.md){ data-preview } — Base64, URL, HTML encoding reference

## Related Deep Hole

- [SurroundTest](https://is.gd/surroundtest){:rel="noopener noreferrer" target="blank"} — Online surround sound test
- [Web Audio API Specification](https://webaudio.github.io/web-audio-api/){:rel="noopener noreferrer" target="blank"} — W3C standard
- [Unicode Character Database](https://unicode.org/ucd/){:rel="noopener noreferrer" target="blank"} — Official Unicode character data
- [Invisible Characters Reference](https://invisible-characters.com/){:rel="noopener noreferrer" target="blank"} — Zero-width and invisible characters
- [Unicode Box Drawing Characters](https://unicode.org/charts/PDF/U2500.pdf){:rel="noopener noreferrer" target="blank"} — Box drawing chart
- [W3 Schools XML Editor](https://www.w3schools.com/XML/tryit.asp?filename=try_dom_loadxmltext){:rel="noopener noreferrer" target="blank"}
"""

let render() = file
