module Comfy.Assets.ManifestP9przInPJson

let file = """{
  "name": "ComfyUI",
  "short_name": "ComfyUI",
  "description": "ComfyUI: AI image generation platform",
  "start_url": "/",
  "icons": [
    {
      "src": "/comfy/assets/images/comfy-icon-192.png",
      "sizes": "192x192",
      "type": "image/png",
      "purpose": "any maskable"
    },
    {
      "src": "/comfy/assets/images/comfy-icon-512.png",
      "sizes": "512x512",
      "type": "image/png",
      "purpose": "any maskable"
    }
  ],
  "display": "standalone"
}
"""

let render() = file
