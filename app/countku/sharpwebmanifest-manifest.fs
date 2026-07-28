module ConvertedFiles.ManifestWebmanifest

let file = """{
  "id": "./",
  "name": "Countku — Sakura Trail",
  "short_name": "Countku",
  "description": "Compose exact mathematical English in a 5-7-5 form.",
  "start_url": "./",
  "scope": "./",
  "display": "standalone",
  "orientation": "any",
  "background_color": "#090817",
  "theme_color": "#12132c",
  "categories": ["education", "games"],
  "icons": [
    {
      "src": "game/assets/countku-mark.svg",
      "sizes": "any",
      "type": "image/svg+xml",
      "purpose": "any maskable"
    }
  ]
}
"""

let render() = file
