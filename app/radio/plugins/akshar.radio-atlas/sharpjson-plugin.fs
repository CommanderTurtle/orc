module Radio.Plugins.AksharRadioAtlas.PluginJson

let file = """{
  "schemaVersion": 1,
  "id": "akshar.radio-atlas",
  "name": "Radio Atlas",
  "version": "0.1.4",
  "description": "Explore live radio on a rotatable globe and play stations through Omarchy's media controls.",
  "license": "MIT",
  "source": {
    "repository": "https://github.com/AksharP5/omarchy-radio-atlas",
    "commit": "1738fa116522ed5dffc1bec53144a3b9f2ac7204",
    "sourceDate": "2026-08-31T21:56:09-04:00",
    "dirty": false,
    "digest": "sha256:5cd7bd1ac201199d617f014556a9444a382fc4bbbf397a01f2abb2b67cb81dcb",
    "manifest": "source/manifest.json"
  },
  "omarchy": {
    "schemaVersion": 1,
    "kinds": [
      "overlay",
      "bar-widget"
    ],
    "entryPoints": {
      "overlay": "RadioAtlas.qml",
      "barWidget": "BarWidget.qml"
    }
  },
  "qmlweb": {
    "shell": "qmlweb/OmarchyShell.qml",
    "compatibility": "adapter-required",
    "nativeBoundaries": [
      "external-player",
      "filesystem",
      "hyprland",
      "omarchy-ui",
      "process",
      "shell-ipc",
      "wayland"
    ]
  },
  "runtime": {
    "mode": "iframe-adapter",
    "adapter": "radio-atlas",
    "entry": "app/index.html"
  }
}
"""

let render() = file
