module ConvertedFiles.Docs.XmlProject.CountkuMd

let file = """# Countku: JS Encoding Technique

Countku is a JavaScript encoding technique designed for character counting and positional reference in literal-safe string operations. It expands to a full library for handling text encoding transformations with predictable character boundaries, useful in environments where precise character positions matter.

---

## Overview

???+ note "What this page covers"
    This page documents the Countku JavaScript encoding technique:

    - **Core Concept** — Character position tracking through encoding transformations
    - **Encoding/Decoding** — Position-marked string representation
    - **Position Tracking** — Mapping original positions to Base64 positions
    - **Library Architecture** — Proposed modules for full implementation

    For Base64 encoding details, see [Base64 Encoding](base64.md). For URL encoding, see [Encoding](../../wikispace/security/encoding.md). For the GitHub project implementation, see [Projects: Countku](../../projects/countku.md).

---

## Core Concept

Countku addresses the problem of character position drift when strings are encoded, decoded, or transformed through multiple encoding layers. In `cmd.exe` scripting and web development, string manipulation often requires knowing exact character positions — a requirement that breaks when encoding transformations change byte lengths or introduce multi-byte characters.

The technique establishes a counting protocol that:

1. Marks character boundaries explicitly
2. Tracks position through encoding transformations
3. Provides reversible encoding without position loss

---

## Basic Implementation

```javascript
/**
 * Countku encoder: marks character positions in a string
 * @param {string} input - Raw text string
 * @returns {string} Countku-encoded string with position markers
 */
function countkuEncode(input) {
    const markers = [];
    let position = 0;
    
    for (const char of input) {
        const byteLength = new TextEncoder().encode(char).length;
        markers.push({
            char: char,
            start: position,
            end: position + byteLength,
            bytes: byteLength
        });
        position += byteLength;
    }
    
    return {
        original: input,
        markers: markers,
        totalBytes: position,
        toString: function() {
            return this.markers.map(m => 
                `${m.start}:${m.char}`
            ).join('|');
        }
    };
}

/**
 * Countku decoder: reconstructs string from position markers
 * @param {string} encoded - Countku-encoded string
 * @returns {string} Original text
 */
function countkuDecode(encoded) {
    return encoded
        .split('|')
        .map(segment => segment.split(':')[1])
        .join('');
}

// Example usage
const encoded = countkuEncode("Hello & test > value");
console.log(encoded.toString());
// Output: 0:H|1:e|2:l|3:l|4:o|5: |6:&|9: |10:t|11:e|12:s|13:t|14: |15:>|16: |17:v|18:a|19:l|20:u|21:e
```

---

## Position Tracking Through Encoding

The primary use case is tracking character positions through Base64 and URL encoding transformations:

```javascript
/**
 * Track positions through Base64 encoding
 * @param {CountkuResult} countku - Countku-encoded result
 * @returns {Object} Mapping between original and Base64 positions
 */
function trackBase64Positions(countku) {
    const utf8Bytes = new TextEncoder().encode(countku.original);
    const base64 = btoa(String.fromCharCode(...utf8Bytes));
    
    const mapping = [];
    let byteIndex = 0;
    
    for (const marker of countku.markers) {
        // Each 3 bytes = 4 Base64 characters
        const bytesBefore = byteIndex;
        const bytesAfter = byteIndex + marker.bytes;
        
        const b64Start = Math.floor(bytesBefore / 3) * 4 + 
            (bytesBefore % 3 === 1 ? 2 : bytesBefore % 3 === 2 ? 3 : 0);
        const b64End = Math.floor((bytesAfter - 1) / 3) * 4 + 
            ((bytesAfter - 1) % 3 === 0 ? 1 : (bytesAfter - 1) % 3 === 1 ? 2 : 3);
        
        mapping.push({
            original: marker.start,
            base64: [b64Start, b64End],
            character: marker.char
        });
        
        byteIndex += marker.bytes;
    }
    
    return { base64, mapping };
}
```

---

## Full Library Proposal

The expansion to a full library would include:

| Module | Purpose |
|--------|---------|
| `countku.encode` | Position-marked encoding |
| `countku.decode` | Position-aware decoding |
| `countku.track.html` | Track positions through HTML entity encoding |
| `countku.track.base64` | Track positions through Base64 |
| `countku.track.url` | Track positions through percent-encoding |
| `countku.transform` | Apply transformations while preserving positions |
| `countku.slice` | Slice by original positions after encoding |

---

## Related Pages

- [Base64 Encoding](base64.md) — Base64 position mapping details
- [Encoding](../../wikispace/security/encoding.md) — URL and HTML encoding reference
- [Projects: Countku](../../projects/countku.md) — Full project documentation

## Related Deep Hole

- [JavaScript TextEncoder API](https://developer.mozilla.org/en-US/docs/Web/API/TextEncoder) — UTF-8 encoding in browsers
- [Base64 Position Mapping](https://stackoverflow.com/questions/ask) — Character position tracking through encoding
"""

let render() = file
