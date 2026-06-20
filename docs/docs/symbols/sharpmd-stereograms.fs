module ConvertedFiles.Docs.Symbols.StereogramsMd

let file = System.String.Join("\"\"\"", [|
    """# Stereograms

Stereograms encode three-dimensional depth information within two-dimensional images through patterned repetition and controlled horizontal displacement. The technique relies on the brain's ability to fuse two slightly different views into a single perception of depth, and serves as a practical demonstration of encoding structured information within seemingly random data.

---

## Overview

???+ note "What this page covers"
    This page documents stereogram construction and viewing:

    - **SIRDS Structure** — Carrier pattern and depth encoding layers
    - **Depth Encoding** — Pixel shift values and perceived position mapping
    - **Generation Algorithm** — Step-by-step construction from a depth map
    - **Viewing Technique** — Divergent viewing instructions
    - **Encoding Metaphor** — Parallel to Base64 and data encoding systems

    For symbol reference and Base64 alphabet, see [Symbols Archive](index.md). For encoding principles, see [Encoding](../wikispace/security/encoding.md).

---

## Single Image Random Dot Stereograms (SIRDS)

A SIRDS consists of a tiled random pattern where horizontal pixel shifts correspond to depth values in a hidden depth map. When viewed with the eyes focused beyond the image plane (divergent viewing), the brain resolves the disparity between left and right eye patterns into a perception of three-dimensional form.

### Structure

```mermaid
flowchart TD
    subgraph Carrier["Carrier Pattern"]
        direction LR
        C1["[ABCDEFGH]"]
        C2["[ABCDEFGH]"]
        C3["[ABCDEFGH]"]
    end

    subgraph Depth["Depth Encoding"]
        direction LR
        D1["[ABCDEFGH]"]
        D2["[-ABCDEFG]"]
        D3["[--ABCDEF]"]
    end

    subgraph Perception["Perceived Depth"]
        P1["Screen plane"]
        P2["Slightly behind"]
        P3["Deepest point"]
    end

    Carrier -->|"Apply depth map<br/>shifts"| Depth
    Depth -->|"Brain fuses<br/>disparate views"| Perception

    style Carrier fill:#4a90d9
    style Depth fill:#7ed321
    style Perception fill:#f5a623
```

The stereogram contains two functional layers:

1. **Carrier pattern**: A repeating tile of random noise or texture, typically 64-128 pixels wide
2. **Depth encoding**: Controlled horizontal shifts applied to the carrier pattern based on a depth map

```
Normal repeat:  [ABCDEFGH][ABCDEFGH][ABCDEFGH]
Depth shift 1:  [ABCDEFGH][-ABCDEFG][--ABCDEF]
                       ^5px left   ^10px left
```

A pixel shifted left relative to its neighbors in the carrier pattern appears recessed (deeper). A pixel shifted right appears to protrude (closer to the viewer).

### Depth Encoding Values

| Depth Value | Pixel Shift | Perceived Position |
|-------------|-------------|--------------------|
| 0 (background) | 0 pixels | At screen plane |
| 1 | +2 pixels | Slightly behind screen |
| 2 | +4 pixels | Moderate depth |
| 3 | +6 pixels | Deepest point |
| -1 | -2 pixels | Slightly in front of screen |
| -2 | -4 pixels | Closest to viewer |

---

## Generation Algorithm

The core procedure for constructing a random-dot stereogram from a depth map:

1. Create a random noise tile of width `T` (typically 64 pixels) and height `H`
2. Initialize the output image by tiling the noise pattern horizontally
3. For each column `x` from `T` to `width - 1`:
   - Compute depth `d` at position `x` from the depth map
   - Compute shift `s = round(d * max_shift / max_depth)`
   - Copy pixel from column `x - T + s` to column `x`
4. The result is a single image where depth information is encoded in the horizontal displacement of the tiled pattern

### Python Reference Implementation

```python
import numpy as np
from PIL import Image

def generate_sirds(depth_map: np.ndarray, tile_width: int = 64,
                   max_shift: int = 8, noise_density: float = 0.5) -> Image.Image:
    """
    """Generate a Single Image Random Dot Stereogram.

    :param depth_map: 2D array (0-255) where higher values = deeper
    :param tile_width: Width of the repeating noise tile in pixels
    :param max_shift: Maximum horizontal shift in pixels
    :param noise_density: Density of dots in the carrier pattern (0-1)
    :returns: PIL Image containing the stereogram
    """
    """
    height, width = depth_map.shape

    # Step 1: Create random noise tile
    tile = np.random.random((height, tile_width)) < noise_density
    tile = (tile * 255).astype(np.uint8)

    # Step 2: Initialize output by tiling
    output = np.zeros((height, width), dtype=np.uint8)
    for x in range(0, width, tile_width):
        end_x = min(x + tile_width, width)
        output[:, x:end_x] = tile[:, :end_x - x]

    # Step 3: Apply depth-based shifts
    for x in range(tile_width, width):
        # Average depth across the column for stability
        avg_depth = int(depth_map[:, x].mean())
        shift = int((avg_depth / 255.0) * max_shift)
        source_x = x - tile_width + shift
        if 0 <= source_x < width:
            output[:, x] = output[:, source_x]

    return Image.fromarray(output)
```

---

## Viewing Technique

Divergent viewing (looking through the image plane) is the standard technique:

1. Hold the image at arm's length, approximately 50-60 cm from the eyes
2. Relax focus, looking through the image as if focusing on a distant point behind it
3. Allow the two halves of the stereogram to overlap in perception
4. A three-dimensional form will emerge from the apparent noise pattern
5. Alternatively, the cross-eyed technique (focusing in front of the image plane) also works but inverts the depth perception

---

## Stereogram as Encoding Metaphor

The stereogram illustrates principles applicable to data encoding systems:

```mermaid
flowchart LR
    subgraph Stereo["Stereogram"]
        direction TB
        S1["Carrier: Random dots"]
        S2["Hidden data: Depth map"]
        S3["Extraction: Eye convergence"]
        S4["Redundancy: Tile repetition"]
    end

    subgraph Data["Data Encoding"]
        direction TB
        D1["Carrier: Base64 alphabet"]
        D2["Hidden data: Binary payload"]
        D3["Extraction: Decode algorithm"]
        D4["Redundancy: Padding (=)"]
    end

    S1 -->|"Maps to"| D1
    S2 -->|"Maps to"| D2
    S3 -->|"Maps to"| D3
    S4 -->|"Maps to"| D4

    style Stereo fill:#4a90d9
    style Data fill:#7ed321
```

| Principle | Stereogram | Data Encoding |
|-----------|-----------|---------------|
| Carrier signal | Random dot pattern | Base64 alphabet (A-Z, a-z, 0-9, +, /) |
| Hidden data | Depth map pixel shifts | Binary data represented as ASCII characters |
| Extraction method | Eye convergence / divergence | Decoding algorithm |
| Redundancy | Pattern tile repetition | Base64 padding characters (=) |
| Information density | Tile width vs image width | Characters per byte of original data |

The parallel is instructive: just as a stereogram's effective depth resolution depends on the density of the dot pattern and the maximum horizontal shift, Base64 encoding density depends on the ratio of meaningful payload characters to padding overhead. SVG path optimization before Base64 encoding reduces the size of the depth map before it is embedded in the carrier, maximizing the information-to-noise ratio.

---

## Related Pages

- [Symbols Archive](index.md) — Character reference and Base64 alphabet
- [Encoding](../wikispace/security/encoding.md) — Base64, URL, and HTML encoding

## Related Deep Hole

- [Wikipedia: Autostereogram](https://en.wikipedia.org/wiki/Autostereogram) — Technical description of SIRDS construction and viewing methods
- [Wikipedia: Random dot stereogram](https://en.wikipedia.org/wiki/Random_dot_stereogram) — History of the technique from vision research
- [Thimbleby, H. W., Inglis, I. H., & Witten, I. H. (1994). Displaying 3D Images: Algorithms for Single-Image Random-Dot Stereograms. IEEE Computer, 27(6), 38-48.](https://doi.org/10.1109/2.292701) — Original academic paper on SIRDS algorithms
"""
|])

let render() = file
