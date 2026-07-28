module ConvertedFiles.Assets.SkepticalScholarSvg

let file = """<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 128 160" role="img" aria-labelledby="title description" shape-rendering="crispEdges">
  <title id="title">The skeptical scholar</title>
  <description id="description">An original pixel scholar holding a scroll and studying the player's equation.</description>
  <defs>
    <linearGradient id="robe" x1="0" y1="0" x2="0" y2="1">
      <stop offset="0" stop-color="#3a2d62"/>
      <stop offset="1" stop-color="#17132c"/>
    </linearGradient>
  </defs>
  <g stroke="#120d22" stroke-width="4">
    <path fill="#191329" d="M46 12h36v8h10v16H36V20h10z"/>
    <path fill="#2b2048" d="M38 32h52v42H38z"/>
    <path fill="#d9a779" d="M42 38h44v42H42z"/>
    <path fill="#231730" d="M42 38h44v10H42z"/>
    <path fill="#21172d" d="M46 52h14v6H46zm28-2h12v6H74z"/>
    <path fill="#f3dfc2" d="M50 56h8v4h-8zm26-2h8v4h-8z"/>
    <path fill="#7c4051" d="M59 68h18v5H59z"/>
    <path fill="#d9a779" d="M54 80h20v10H54z"/>
    <path fill="url(#robe)" d="M34 88h60l16 62H18z"/>
    <path fill="#5e4f91" d="M50 88h28l-4 56H54z"/>
    <path fill="#d9a779" d="M20 100h18v24H20zm70 0h18v24H90z"/>
    <path fill="#e8d39c" d="M70 108h42v30H70z"/>
    <path fill="#a9844f" d="M74 113h34v4H74zm0 8h28v4H74zm0 8h32v4H74z"/>
    <path fill="#cfd7ff" d="M34 28h60v7H34z"/>
    <path fill="#8ca2ef" d="M56 20h16v15H56z"/>
  </g>
</svg>

"""

let render() = file
