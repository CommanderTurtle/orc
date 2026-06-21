module ConvertedFiles.Docs.Wikispace.Security.CompressionMd

let file = """# Compression

Data compression reduces the number of bits needed to represent information. Compression algorithms fall into two categories: lossless (fully reversible, original data recoverable bit-for-bit) and lossy (irreversible, discards less perceptible information). This page covers practical compression tools and their application in the sHEL workflow.

---

## Overview

???+ note "What this page covers"
    This page documents compression algorithms and practical tools:

    - **Lossless Compression** — DEFLATE (ZIP/GZIP), LZMA (7-Zip), Brotli, Zstd
    - **Windows Native** — CompactOS NTFS compression, makecab/expand
    - **Lossy Compression** — JPEG for photographs, OGG/MP3 for audio
    - **Compression Ratios** — Reference table by content type

    For data encoding schemes (Base64, URL encoding), see [Encoding](encoding.md). For steganographic data hiding, see [Steganography](steganography.md).

---

## Lossless Compression

### Algorithm Comparison

```mermaid
flowchart LR
    subgraph Speed["Compression Speed"]
        direction LR
        ZS["Zstd<br/>Very Fast"]
        DEF["DEFLATE<br/>Fast"]
        BR["Brotli<br/>Fast"]
        LZ["LZMA<br/>Slow"]
    end

    subgraph Ratio["Compression Ratio"]
        direction LR
        DEF2["DEFLATE<br/>Moderate"]
        ZS2["Zstd<br/>Moderate"]
        BR2["Brotli<br/>High"]
        LZ2["LZMA<br/>Highest"]
    end

    style ZS fill:#7ed321
    style ZS2 fill:#7ed321
    style LZ fill:#f5a623
    style LZ2 fill:#7ed321
    style BR fill:#4a90d9
    style BR2 fill:#4a90d9
```

| Algorithm | Speed | Ratio | Best For |
|-----------|-------|-------|----------|
| DEFLATE | Fast | Moderate | General purpose, ZIP |
| LZMA | Slow | High | Archival storage, 7-Zip |
| Brotli | Fast | High | Web content, text |
| Zstd | Very fast | Moderate | Real-time compression |

### DEFLATE (ZIP/GZIP)

DEFLATE combines LZ77 dictionary coding with Huffman entropy coding. It is the basis of ZIP, GZIP, and PNG compression.

```powershell
# PowerShell compression
Compress-Archive -Path "source" -DestinationPath "archive.zip" -CompressionLevel Optimal

# GZIP (single file)
gzip -9 file.txt       # -9 = maximum compression

# ZIP with password (AES-256)
7z a -tzip -mem=AES256 -p archive.zip files/
```

### LZMA (7-Zip)

LZMA (Lempel-Ziv-Markov chain Algorithm) provides higher compression ratios than DEFLATE at the cost of speed. 7-Zip is the standard implementation.

```bash
# Maximum compression
7z a -t7z -m0=lzma2 -mx=9 archive.7z source/

# Multithreaded
7z a -t7z -m0=lzma2 -mx=9 -mmt=4 archive.7z source/
```

---

## Windows Native Compression

### CompactOS (NTFS Compression)

```batch
REM Compress directory with NTFS compression
compact /c /s:"C:\path" /i /Q

REM Decompress
compact /u /s:"C:\path" /i /Q

REM Compress with LZX (better ratio, Windows 10+)
compact /c /s:"C:\path" /exe:lzx

REM Query compression status
compact /q "C:\path"
```

### makecab and expand

```batch
REM Create CAB archive
makecab "largefile.txt" "archive.cab"

REM Extract CAB
expand "archive.cab" -F:* "C:\destination"
```

---

## Lossy Compression

### JPEG

JPEG uses discrete cosine transform (DCT) quantization. Quality levels 80-90 provide the best visual-quality-to-file-size ratio for photographs.

```python
from PIL import Image
img = Image.open("photo.png")
img.save("photo.jpg", quality=85, optimize=True)
```

### MP3/OGG Audio

Lossy audio compression uses psychoacoustic models to discard frequencies below human hearing thresholds.

```bash
# OGG Vorbis (recommended for general use)
oggenc -q 5 input.wav       # Quality 5 = ~160 kbps

# MP3
lame -V 2 input.wav output.mp3    # V2 = ~190 kbps, transparent
```

---

## Compression Ratio Reference

| Content Type | Raw | ZIP (DEFLATE) | 7z (LZMA) | Brotli |
|-------------|-----|---------------|-----------|--------|
| Text (source code) | 100% | 20-30% | 10-15% | 15-20% |
| Executable binaries | 100% | 50-60% | 40-50% | 45-55% |
| Photographs (lossless) | 100% | 90-95% | 85-90% | 88-92% |
| Photographs (JPEG 85) | 10-15% | — | — | — |
| JSON/XML | 100% | 10-20% | 5-10% | 8-12% |

---

## Related Pages

- [Encoding](encoding.md) — Base64, URL encoding, HTML entities
- [Steganography](steganography.md) — Data hiding in compressed media

## Related Deep Hole

- [zlib Technical Documentation](https://zlib.net/manual.html) — DEFLATE implementation details
- [7-Zip Format Specification](https://www.7-zip.org/7z.html) — LZMA container format
- [RFC 7932: Brotli Compressed Data Format](https://datatracker.ietf.org/doc/html/rfc7932) — Brotli specification
"""

let render() = file
