module ConvertedFiles.Assets.CountkuMarkSvg

let file = """<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512" role="img" aria-labelledby="title desc">
  <title id="title">Countku Sakura Trail mark</title>
  <desc id="desc">A pixel-styled sentence mark over a moonlit sakura gradient.</desc>
  <defs>
    <linearGradient id="night" x1="0" y1="0" x2="1" y2="1">
      <stop offset="0" stop-color="#252553"/>
      <stop offset="1" stop-color="#090817"/>
    </linearGradient>
    <linearGradient id="moon" x1="0" y1="0" x2="1" y2="1">
      <stop offset="0" stop-color="#8ff0cd"/>
      <stop offset="1" stop-color="#d9e3ff"/>
    </linearGradient>
  </defs>
  <rect width="512" height="512" rx="96" fill="url(#night)"/>
  <path fill="#ff83b8" d="M78 106h44v44H78zm44-44h44v44h-44zm302 42h-38v38h38zm-38 38h-38v38h38z"/>
  <rect x="92" y="92" width="328" height="328" rx="72" fill="none" stroke="#ffd0e3" stroke-width="18"/>
  <rect x="130" y="130" width="252" height="252" rx="48" fill="url(#moon)"/>
  <text x="256" y="322" fill="#12132c" font-family="serif" font-size="230" font-weight="700" text-anchor="middle">句</text>
</svg>
"""

let render() = file
