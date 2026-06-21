module ConvertedFiles.Docs.Wikispace.Security.SteganographyMd

let file = System.String.Join("\"\"\"", [|
    """# Steganography

Steganography is the practice of concealing data within other non-secret data, such that the existence of the hidden data is not apparent. Unlike encryption, which protects the content of a message, steganography protects the existence of the message. It is most commonly implemented by embedding data in the least significant bits (LSB) of image pixel values, audio sample data, or other digital carrier media.

---

## Overview

???+ note "What this page covers"
    This page documents steganographic data hiding techniques:

    - **LSB Image Steganography** — Embedding data in RGB pixel least significant bits
    - **Capacity Analysis** — Storage limits by image resolution and color depth
    - **Statistical Detection** — Chi-square, RS analysis, and visual attacks
    - **Audio Steganography** — LSB embedding in 16-bit PCM WAV samples

    For encryption of message content before hiding, see [Encryption](encryption.md). For compression of carrier files, see [Compression](compression.md).

---

## LSB Image Steganography

The least significant bit of each color channel in an RGB pixel can be modified without perceptibly changing the image appearance. With 3 bytes per pixel (RGB), a 1920x1080 image can store approximately 750 KB of hidden data.

### Bit Embedding Process

```mermaid
flowchart TD
    subgraph Original["Original Byte"]
        direction LR
        B7["b7"]
        B6["b6"]
        B5["b5"]
        B4["b4"]
        B3["b3"]
        B2["b2"]
        B1["b1"]
        B0["b0"]
    end

    subgraph Hidden["Hidden Bit"]
        H["1"]
    end

    subgraph Modified["Modified Byte"]
        direction LR
        M7["b7"]
        M6["b6"]
        M5["b5"]
        M4["b4"]
        M3["b3"]
        M2["b2"]
        M1["b1"]
        M0["1"]
    end

    Original -->|"Replace LSB"| Modified
    H -->|"Insert"| Modified

    style B0 fill:#d0021b
    style M0 fill:#7ed321
    style Hidden fill:#f5a623
```

### Encoding Procedure

1. Convert the secret message to a bit string
2. Append a null terminator (16 zero bits) to mark the end
3. For each bit, replace the least significant bit of the next color channel byte
4. Write the modified pixel data to a new image file

### Python Reference Implementation

```python
from PIL import Image
import numpy as np

def embed_lsb(carrier_path: str, data: str, output_path: str) -> None:
    """
    """Embed a text message in the LSBs of an RGB image."""
    """
    img = Image.open(carrier_path).convert('RGB')
    pixels = np.array(img, dtype=np.uint8)
    flat = pixels.ravel()

    # Convert message to bits with null terminator
    bits = ''.join(format(ord(c), '08b') for c in data) + '0000000000000000'

    if len(bits) > len(flat):
        raise ValueError(f"Carrier too small: needs {len(bits)} bits, has {len(flat)}")

    for i, bit in enumerate(bits):
        flat[i] = (flat[i] & ~1) | int(bit)

    Image.fromarray(pixels).save(output_path)

def extract_lsb(carrier_path: str) -> str:
    """
    """Extract a text message from the LSBs of an RGB image."""
    """
    img = Image.open(carrier_path).convert('RGB')
    pixels = np.array(img, dtype=np.uint8)
    flat = pixels.ravel()

    bits = ''.join(str(byte & 1) for byte in flat)
    chars = []
    for i in range(0, len(bits), 8):
        byte = bits[i:i+8]
        if len(byte) < 8:
            break
        code = int(byte, 2)
        if code == 0:
            break
        chars.append(chr(code))
    return ''.join(chars)
```

### Capacity Analysis

| Image Resolution | Color Depth | Raw Capacity |
|------------------|-------------|-------------|
| 1920 x 1080 | 24-bit RGB | 777,600 bytes (759 KB) |
| 4096 x 2160 | 24-bit RGB | 3,317,760 bytes (3.16 MB) |
| 1920 x 1080 | 32-bit RGBA | 1,036,800 bytes (1.01 MB) |

---

## Statistical Detection

LSB steganography is vulnerable to statistical analysis. Several attack methods exist:

```mermaid
flowchart TD
    subgraph Detection["Detection Methods"]
        direction TB
        CHI["Chi-Square<br/>LSB distribution<br/>vs 50/50 expected"]
        RS["RS Analysis<br/>Regular/Singular<br/>group measurement"]
        VIS["Visual Attack<br/>Bit plane<br/>examination"]
        SIZE["File Size<br/>PNG compression<br/>ratio anomaly"]
    end

    subgraph Counter["Countermeasures"]
        direction TB
        ADAPT["Adaptive LSB<br/>(variable rate)"]
        BMP["BMP format<br/>(no compression)"]
    end

    Detection -->|"Defend against"| Counter

    style Detection fill:#d0021b
    style Counter fill:#7ed321
```

| Attack | Method | Detectable Pattern |
|--------|--------|--------------------|
| Chi-square | Compare LSB distribution to expected 50/50 | Non-uniform bit distribution |
| RS analysis | Measure regular/singular groups | Increased singular groups |
| Visual attack | Examine bit planes individually | Structured patterns in low bit planes |
| File size | Compare to uncompressed equivalent | PNG compression ratio anomaly |

Countermeasures include adaptive LSB embedding (varying the embedding rate across the image) and using lossless compression-resistant formats like BMP rather than JPEG.

---

## Audio Steganography

The same LSB technique applies to uncompressed audio formats (WAV). Each 16-bit sample provides one hidden bit with imperceptible quality degradation.

```python
import wave

def embed_wav_lsb(carrier_path: str, data: str, output_path: str) -> None:
    """
    """Embed data in LSB of 16-bit PCM WAV samples."""
    """
    with wave.open(carrier_path, 'rb') as w:
        nchannels = w.getnchannels()
        sampwidth = w.getsampwidth()
        framerate = w.getframerate()
        nframes = w.getnframes()
        frames = w.readframes(nframes)

    samples = np.frombuffer(frames, dtype=np.int16)
    bits = ''.join(format(ord(c), '08b') for c in data) + '0000000000000000'

    if len(bits) > len(samples):
        raise ValueError("Audio too short for message")

    for i, bit in enumerate(bits):
        samples[i] = (samples[i] & ~1) | int(bit)

    with wave.open(output_path, 'wb') as w:
        w.setnchannels(nchannels)
        w.setsampwidth(sampwidth)
        w.setframerate(framerate)
        w.writeframes(samples.tobytes())
```

---

## Related Pages

- [Encryption](encryption.md) — Encrypt message content before hiding
- [Compression](compression.md) — Compress carrier files
- [Encoding](encoding.md) — Base64, hex, and URL encoding

## Related Deep Hole

- [Wikipedia: Steganography](https://en.wikipedia.org/wiki/Steganography) — Overview of techniques and history
- [Provos, N., & Honeyman, P. (2003). Hide and Seek: An Introduction to Steganography. IEEE Security & Privacy, 1(3), 32-44.](https://doi.org/10.1109/MSECP.2003.1203220) — Academic introduction to the field
- [Fridrich, J., Goljan, M., & Du, R. (2001). Detecting LSB Steganography in Color and Gray-Scale Images. Magazine of IEEE Multimedia, 8(4), 22-28.](https://doi.org/10.1109/93.959097) — RS analysis detection method
"""
|])

let render() = file
