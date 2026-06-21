module ConvertedFiles.Docs.XmlProject.CaptchaUnicodeMd

let file = """# Invisible Unicode and CAPTCHA Systems

Invisible Unicode characters can be used to encode hidden data within apparently normal text. This technique has applications in steganography, copyright marking, and CAPTCHA systems that are resistant to optical character recognition while remaining readable to humans.

---

## Overview

???+ note "What this page covers"
    This page documents invisible Unicode character techniques:

    - **Invisible Characters** — Zero-width spaces, joiners, and non-joiners
    - **Steganographic Encoding** — Binary data hidden in visible text carriers
    - **CAPTCHA Systems** — Text-based verification using invisible validation markers
    - **Comparison** — Unicode CAPTCHA vs traditional image CAPTCHA

    For LSB image steganography, see [Steganography](../../wikispace/security/steganography.md). For Base64 encoding of hidden payloads, see [Base64 Encoding](base64.md).

---

## Invisible Unicode Characters

The Unicode standard includes several characters that render invisibly or as zero-width space in most fonts:

```mermaid
flowchart TD
    subgraph Invisible["Invisible Character Set"]
        direction TB
        ZWS["U+200B<br/>Zero Width Space"]
        ZWNJ["U+200C<br/>Zero Width Non-Joiner<br/>(= binary 0)"]
        ZWJ["U+200D<br/>Zero Width Joiner<br/>(= binary 1)"]
        WJ["U+2060<br/>Word Joiner"]
        BOM["U+FEFF<br/>BOM / ZW No-Break Space"]
        SHY["U+00AD<br/>Soft Hyphen"]
        CGJ["U+034F<br/>Combining Grapheme Joiner"]
    end

    subgraph Encoding["Binary Encoding"]
        direction TB
        B0["Binary 0<br/>\u200B"]
        B1["Binary 1<br/>\u200C"]
    end

    ZWNJ -->|"Maps to"| B0
    ZWJ -->|"Maps to"| B1

    style Invisible fill:#4a90d9
    style Encoding fill:#7ed321
```

| Character | Code Point | Name | Usage |
|-----------|-----------|------|-------|
| U+200B | `\u200B` | Zero Width Space | Word boundary without visible space |
| U+200C | `\u200C` | Zero Width Non-Joiner | Prevents character joining (Arabic) |
| U+200D | `\u200D` | Zero Width Joiner | Forces character joining |
| U+2060 | `\u2060` | Word Joiner | Prevents line breaks |
| U+FEFF | `\uFEFF` | Byte Order Mark / Zero Width No-Break Space | File header or invisible marker |
| U+00AD | `\u00AD` | Soft Hyphen | Optional hyphenation point |
| U+034F | `\u034F` | Combining Grapheme Joiner | Modifies combining character behavior |

---

## Steganographic Encoding

Binary data can be encoded using pairs of invisible characters:

```javascript
/**
 * Encode binary data as invisible Unicode characters
 * @param {string} visibleText - The visible carrier text
 * @param {string} hiddenData - Data to hide (will be Base64 encoded)
 * @returns {string} Text with invisible payload
 */
function encodeInvisible(visibleText, hiddenData) {
    const b64 = btoa(hiddenData);
    let binary = '';
    for (const char of b64) {
        binary += char.charCodeAt(0).toString(2).padStart(8, '0');
    }
    
    const ZERO = '\u200B';  // Zero Width Space = 0
    const ONE = '\u200C';   // Zero Width Non-Joiner = 1
    
    let result = '';
    let bitIndex = 0;
    
    for (const char of visibleText) {
        result += char;
        // Insert 2-3 invisible bits after each visible character
        if (bitIndex < binary.length) {
            const bitsToInsert = Math.min(2, binary.length - bitIndex);
            for (let i = 0; i < bitsToInsert; i++) {
                result += binary[bitIndex] === '1' ? ONE : ZERO;
                bitIndex++;
            }
        }
    }
    
    return result;
}

/**
 * Decode invisible payload from text
 * @param {string} encoded - Text with invisible payload
 * @returns {string} Hidden data
 */
function decodeInvisible(encoded) {
    let binary = '';
    for (const char of encoded) {
        if (char === '\u200B') binary += '0';
        else if (char === '\u200C') binary += '1';
    }
    
    let b64 = '';
    for (let i = 0; i < binary.length; i += 8) {
        const byte = binary.slice(i, i + 8);
        if (byte.length < 8) break;
        b64 += String.fromCharCode(parseInt(byte, 2));
    }
    
    return atob(b64);
}
```

---

## CAPTCHA with Invisible Unicode

A CAPTCHA system can use invisible characters to verify human interaction:

```mermaid
sequenceDiagram
    participant Client
    participant Server

    Server->>Server: Select random word<br/>Generate validation token
    Server->>Server: encodeInvisible(word, token)
    Server->>Client: Send challenge text<br/>(visible word + invisible token)
    Client->>Client: Display visible word<br/>User types response
    Client->>Server: Submit response text
    Server->>Server: decodeInvisible(response)
    Server->>Server: Compare extracted token
    Server->>Client: Validation result
```

```javascript
/**
 * Generate a text-based CAPTCHA with invisible validation marker
 * @returns {Object} CAPTCHA challenge and validation token
 */
function generateCaptcha() {
    const words = ['apple', 'river', 'mountain', 'galaxy', 'crystal'];
    const visibleWord = words[Math.floor(Math.random() * words.length)];
    
    // Create validation token from word hash
    const token = btoa(visibleWord + Date.now()).slice(0, 16);
    
    // Embed token as invisible characters
    const challenge = encodeInvisible(visibleWord, token);
    
    return {
        challenge: challenge,  // Display this text
        token: token,          // Store server-side
        validate: (response) => {
            const decoded = decodeInvisible(response);
            return decoded === token;
        }
    };
}
```

This approach differs from traditional image CAPTCHAs:

| Aspect | Image CAPTCHA | Unicode CAPTCHA |
|--------|--------------|-----------------|
| OCR resistance | Visual distortion | Text appears normal |
| Accessibility | Screen readers fail | Screen readers work |
| Data size | Image bytes (~5KB) | Text characters (~50B) |
| Bandwidth | Higher | Minimal |
| Bot detection | Image analysis | Unicode extraction required |

---

## Related Pages

- [Base64 Encoding](base64.md) — Payload encoding before invisible embedding
- [Steganography](../../wikispace/security/steganography.md) — LSB image and audio steganography
- [Encoding](../../wikispace/security/encoding.md) — URL encoding and HTML entities

## Related Deep Hole

- [Unicode Invisible Characters](https://invisible-characters.com/) — Reference of invisible Unicode code points
- [Steganography Using Zero-Width Characters](https://330k.github.io/misc_tools/unicode_steganography.html) — Online tool for invisible encoding
- [Aem1k Invisible Text](https://aem1k.com/) — JavaScript and Unicode experiments
- [Code Golf: Invisible Code](https://codegolf.stackexchange.com/questions/tagged/whitespace) — Community challenges with invisible characters
"""

let render() = file
