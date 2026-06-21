module ConvertedFiles.Docs.Wikispace.Security.EncodingMd

let file = """# Encoding

Encoding transforms data from one representation to another without compression or encryption. Unlike encryption, encoding does not use keys and provides no security — it is purely a format transformation. This page covers the encoding schemes used in the sHEL project for safe data transport through restricted channels.

---

## Overview

???+ note "What this page covers"
    This page documents encoding schemes for data transformation:

    - **Base64 (RFC 4648)** — Binary-to-text encoding for data URIs and MIME
    - **URL Encoding** — Percent-encoding for safe URL transmission
    - **HTML Entities** — Character encoding for browser contexts
    - **Hexadecimal** — Byte-to-text representation
    - **Format Comparison** — Size, safety, and readability matrix

    For Base64 in the context of the XML Project, see [Base64 Encoding](../../xml-project/base64.md). For compression algorithms, see [Compression](compression.md). For encryption, see [Encryption](encryption.md).

---

## Base64 (RFC 4648)

Base64 encodes binary data using 64 printable ASCII characters. It is the standard mechanism for embedding binary data in text-based formats.

```mermaid
flowchart LR
    subgraph Input["Binary Input"]
        direction TB
        B1["01001000 01100101"]
        B2["01101100 01101100"]
        B3["01101111"]
    end

    subgraph Process["Base64 Process"]
        P1["Split into<br/>6-bit groups"]
        P2["Map to<br/>A-Z a-z 0-9 + /"]
        P3["Pad with =<br/>if needed"]
    end

    subgraph Output["Base64 Output"]
        O1["SGVs bG8="]
    end

    Input --> P1 --> P2 --> P3 --> Output

    style Input fill:#4a90d9
    style Output fill:#7ed321
```

| Variant | Alphabet | Padding | Use Case |
|---------|----------|---------|----------|
| Standard | `[A-Za-z0-9+/]` | `=` | Email (MIME), data URIs |
| URL-safe | `[A-Za-z0-9-_]` | `=` or none | URL parameters, filenames |
| Base64 for filenames | `[A-Za-z0-9+-]` | none | Unix filenames |

### PowerShell

```powershell
# Encode
$base64 = [Convert]::ToBase64String([Text.Encoding]::UTF8.GetBytes("text"))

# Decode
$text = [Text.Encoding]::UTF8.GetString([Convert]::FromBase64String($base64))
```

---

## URL Encoding (Percent-Encoding)

URL encoding replaces unsafe ASCII characters with a `%` followed by two hexadecimal digits. Defined in RFC 3986.

| Character | Encoded | Character | Encoded |
|-----------|---------|-----------|---------|
| space | `%20` or `+` | `&` | `%26` |
| `?` | `%3F` | `=` | `%3D` |
| `/` | `%2F` | `#` | `%23` |

```powershell
[System.Web.HttpUtility]::UrlEncode("hello world & test")
# Output: hello+world+%26+test

[System.Web.HttpUtility]::UrlDecode("hello+world+%26+test")
# Output: hello world & test
```

---

## HTML Entities

HTML entity encoding prevents browser interpretation of special characters as markup.

| Character | Entity | Numeric | Must Encode In |
|-----------|--------|---------|----------------|
| `&` | `&amp;` | `&#38;` | All contexts |
| `<` | `&lt;` | `&#60;` | Element content, attributes |
| `>` | `&gt;` | `&#62;` | Element content |
| `"` | `&quot;` | `&#34;` | Double-quoted attributes |
| `'` | `&#x27;` | `&#39;` | Single-quoted attributes |

---

## Hexadecimal Encoding

Hex encoding represents each byte as two hexadecimal characters (0-9, A-F). It doubles the size of the data but is human-readable and safe for all text contexts.

```powershell
# Encode to hex
$hex = -join ([Text.Encoding]::UTF8.GetBytes("text") | ForEach-Object { $_.ToString("x2") })
# Output: 74657874

# Decode from hex
$bytes = for ($i = 0; $i -lt $hex.Length; $i += 2) {
    [Convert]::ToByte($hex.Substring($i, 2), 16)
}
[Text.Encoding]::UTF8.GetString($bytes)
```

---

## Character Encoding Comparison

| Encoding | Output Size (relative to binary) | Safe for URLs | Safe for HTML | Human Readable |
|----------|----------------------------------|---------------|---------------|----------------|
| Base64 | 133% | Standard: No; URL-safe: Yes | Yes | Partially |
| Hex | 200% | Yes | Yes | Yes |
| URL Encode | Variable (100-300%) | Yes | Partially | Yes |
| HTML Entities | Variable (100-500%) | No | Yes | Yes |

---

## Related Pages

- [Base64 Encoding](../../xml-project/base64.md) — Detailed Base64 documentation in XML Project
- [Compression](compression.md) — DEFLATE, LZMA, Brotli compression
- [Encryption](encryption.md) — AES, RSA, TLS encryption

## Related Deep Hole

- [RFC 4648: Base64 Data Encodings](https://datatracker.ietf.org/doc/html/rfc4648) — Base64 specification
- [RFC 3986: URI Generic Syntax](https://datatracker.ietf.org/doc/html/rfc3986) — Percent-encoding rules
- [HTML Living Standard: Named Character References](https://html.spec.whatwg.org/multipage/named-characters.html) — Complete entity list
"""

let render() = file
