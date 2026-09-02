module ConvertedFiles.Radio.Themes.IndexJson

let file = """{
  "schemaVersion": 1,
  "source": "https://learn.omacom.io/2/the-omarchy-manual/52/themes",
  "themes": [
    {
      "id": "tokyo-night",
      "name": "Tokyo Night",
      "file": "tokyo-night.json"
    },
    {
      "id": "catppuccin",
      "name": "Catppuccin",
      "file": "catppuccin.json",
      "default": true
    },
    {
      "id": "lumon",
      "name": "Lumon",
      "file": "lumon.json"
    }
  ]
}
"""

let render() = file
