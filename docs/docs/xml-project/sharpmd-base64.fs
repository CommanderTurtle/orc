module ConvertedFiles.Docs.XmlProject.Base64Md

let file = """# Base64 Encoding for Media Embedding

Base64 is a binary-to-text encoding scheme specified in RFC 4648. It represents binary data using an alphabet of 64 printable ASCII characters, making it safe for transport through text-based systems such as HTML, CSS, JSON, and `cmd.exe` pipelines. In the context of the sHEL project, Base64 serves as the literal-safe transport mechanism for embedding binary media directly within HTML documents without external file dependencies.

---

## Overview

???+ note "What this page covers"
    Base64 encoding and decoding for media embedding in HTML, PowerShell utility functions, CSS background embedding, and `cmd.exe` Base64 operations via PowerShell. For the related clipboard automation patterns, see [Clipboard Automation](clipboard-automation.md). For the complete Base64 alphabet reference, see [Symbols Archive](../symbols/index.md).

---

## Encoding Principle

Base64 operates by dividing the input byte stream into 6-bit groups (yielding values 0-63), then mapping each value to a character in the standard alphabet `[A-Za-z0-9+/]`. When the input length is not divisible by 3, padding characters (`=`) are appended to complete the final quantum.

```mermaid
flowchart LR
    subgraph "Input: abc"
        B1["01100001"]
        B2["01100010"]
        B3["01100011"]
    end
    
    B1 --> C1["011000"]
    B1 --> C2["010110"]
    B2 --> C3["001001"]
    B3 --> C4["100011"]
    
    C1 --> D1["Y"]
    C2 --> D2["W"]
    C3 --> D3["J"]
    C4 --> D4["j"]
    
    subgraph "Output: YWJj"
        D1
        D2
        D3
        D4
    end

    style B1 fill:#2d5a3a,color:#fff
    style B2 fill:#2d5a3a,color:#fff
    style B3 fill:#2d5a3a,color:#fff
    style D1 fill:#4a7c59,color:#fff
    style D2 fill:#4a7c59,color:#fff
    style D3 fill:#4a7c59,color:#fff
    style D4 fill:#4a7c59,color:#fff
```

| Input Bytes | Binary | 6-bit Groups | Output Characters |
|-------------|--------|-------------|--------------------|
| `abc` | `01100001 01100010 01100011` | `011000 010110 001001 100011` | `YWJj` |
| `ab` | `01100001 01100010` | `011000 010110 001000` (pad) | `YWI=` |
| `a` | `01100001` | `011000 010000` (2 pads) | `YQ==` |

Each Base64 character encodes 6 bits of information. The encoding produces a 33% overhead compared to raw binary: every 3 bytes (24 bits) become 4 characters. For image embedding, this tradeoff is acceptable because it eliminates HTTP round-trips for external assets and avoids file path handling.

---

## PowerShell Base64 Utilities

The following PowerShell functions perform common Base64 operations for media embedding. These are exact implementations used in the sHEL workflow.

### Clipboard to Base64

Captures the current clipboard content and outputs its Base64 representation:

```powershell
# Read clipboard and encode as Base64
[Convert]::ToBase64String([System.Text.Encoding]::UTF8.GetBytes((Get-Clipboard)))

# For binary clipboard data (e.g., copied from an image editor)
[Convert]::ToBase64String((Get-Clipboard -Format Image).Save([System.IO.MemoryStream]::new()))
```

### File to Base64

Reads a binary file and produces the Base64 string suitable for embedding:

```powershell
# Encode any file as Base64
[Convert]::ToBase64String([IO.File]::ReadAllBytes("path\to\file.png"))

# With line wrapping (for readability in HTML)
[Convert]::ToBase64String([IO.File]::ReadAllBytes("file.png")) -replace ".{76}","`$&`r`n"
```

### PNG to ICO Conversion

Windows favors ICO format for icons. This function converts a PNG image to multi-resolution ICO format:

```powershell
Add-Type -AssemblyName System.Drawing

function ConvertTo-Icon {
    param([string]$InputPath, [string]$OutputPath, [int[]]$Sizes = @(16,32,48,256))
    $png = [System.Drawing.Image]::FromFile((Resolve-Path $InputPath))
    $memStream = New-Object IO.MemoryStream
    $binWriter = New-Object IO.BinaryWriter($memStream)
    $binWriter.Write([short]0)      # Reserved
    $binWriter.Write([short]1)      # Type: icon
    $binWriter.Write([short]$Sizes.Count)  # Image count
    foreach ($size in $Sizes) {
        $thumb = New-Object System.Drawing.Bitmap($png, $size, $size)
        $iconStream = New-Object IO.MemoryStream
        $thumb.Save($iconStream, [System.Drawing.Imaging.ImageFormat]::Png)
        $binWriter.Write([byte]$size)       # Width
        $binWriter.Write([byte]$size)       # Height
        $binWriter.Write([byte]0)           # Colors
        $binWriter.Write([byte]0)           # Reserved
        $binWriter.Write([short]1)          # Color planes
        $binWriter.Write([short]32)         # Bits per pixel
        $binWriter.Write([int]$iconStream.Length)  # Data size
        $binWriter.Write([int](6 + 16 * $Sizes.Count))  # Data offset (updated later)
    }
    # Write image data...
    [IO.File]::WriteAllBytes($OutputPath, $memStream.ToArray())
}
```

---

## HTML Figure Embedding

Base64-encoded images and audio are embedded in HTML using the `data:` URI scheme. The general format is:

```
data:[media-type];base64,[base64-data]
```

### Image Embedding

```html
<figure>
  <img src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mNk+M9QDwADhgGAWjR9awAAAABJRU5ErkJggg=="
       alt="Embedded image">
  <figcaption>Figure 1: Embedded PNG via Base64 data URI</figcaption>
</figure>
```

### Audio Embedding

```html
<figure>
  <audio controls>
    <source src="data:audio/mpeg;base64,/+MYxAAAAANIAAAAAExBTUUzLjEwMKqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqq//uQZAAA..."
            type="audio/mpeg">
  </audio>
  <figcaption>Figure 2: Embedded audio via Base64</figcaption>
</figure>
```

!!! note "MIME Type Requirements"
    The `type` attribute in the `<source>` element and the media type in the `data:` URI must match. Common audio MIME types: `audio/mpeg` for MP3, `audio/wav` for WAV, `audio/ogg` for OGG Vorbis, `audio/aac` for AAC.

---

## CSS Background Embedding

Base64 data URIs can also be used in CSS for inline background images:

```css
.icon-flag {
  background-image: url("data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAALCAMAAABBPP0LAAAAGFBMVEUAAAD...");
  width: 16px;
  height: 11px;
  display: inline-block;
}
```

This technique is used for small UI icons where eliminating an HTTP request outweighs the Base64 overhead.

---

## cmd.exe Base64 via PowerShell

From a batch script, PowerShell can be invoked for Base64 operations:

```batch
REM Encode a string to Base64
FOR /F "delims=" %%A IN ('powershell -NoP -C "[Convert]::ToBase64String([Text.Encoding]::UTF8.GetBytes('Hello World'))"') DO SET "b64=%%A"

REM Decode Base64 to string
FOR /F "delims=" %%A IN ('powershell -NoP -C "[Text.Encoding]::UTF8.GetString([Convert]::FromBase64String('SGVsbG8gV29ybGQ='))"') DO SET "text=%%A"

REM Encode a file to Base64
FOR /F "delims=" %%A IN ('powershell -NoP -C "[Convert]::ToBase64String([IO.File]::ReadAllBytes('image.png'))"') DO SET "img_b64=%%A"
```

---

## Decoding Base64

### PowerShell

```powershell
# String
[Text.Encoding]::UTF8.GetString([Convert]::FromBase64String("SGVsbG8gV29ybGQ="))

# To file
[IO.File]::WriteAllBytes("output.png", [Convert]::FromBase64String($base64String))
```

### Python

```python
import base64

# String
decoded = base64.b64decode("SGVsbG8gV29ybGQ=").decode('utf-8')

# To file
with open("output.png", "wb") as f:
    f.write(base64.b64decode(base64_string))
```

### JavaScript (Browser)

```javascript
// String
const decoded = atob("SGVsbG8gV29ybGQ=");

// Uint8Array (for binary data)
const binary = Uint8Array.from(atob(base64String), c => c.charCodeAt(0));
```

---

## Related Deep Hole

- [Stack Overflow: Base64 encoding and decoding in PowerShell](https://stackoverflow.com/questions/37043146) — Various methods for Base64 encode/decode
- [Stack Overflow: Embed Base64 image in HTML](https://stackoverflow.com/questions/1207190) — Data URI scheme browser support and limitations
- [RFC 4648: The Base16, Base32, and Base64 Data Encodings](https://datatracker.ietf.org/doc/html/rfc4648) — Official IETF specification
- [MDN: Data URLs](https://developer.mozilla.org/en-US/docs/Web/HTTP/Basics_of_HTTP/Data_URLs) — Mozilla documentation on data URI syntax and usage
"""

let render() = file
