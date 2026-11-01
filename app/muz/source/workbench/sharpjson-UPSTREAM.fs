module Muz.Source.Workbench.UPSTREAMJson

let file = """{
  "repository": "https://github.com/apage43/muzpad.git",
  "revision": "0f5e53fb88950291a649cdea00baac37d43bef1e",
  "engine": {
    "repository": "https://github.com/apage43/muz.git",
    "revision": "f648c86737f0b995e9c86181bab09075d2700d91",
    "local": true,
    "dirty": true
  },
  "dependencies": {
    "@codemirror/commands": "6.11.0",
    "@codemirror/language": "6.12.4",
    "@codemirror/search": "6.7.2",
    "@codemirror/state": "6.7.4",
    "@codemirror/view": "6.43.11",
    "@lezer/highlight": "1.2.3",
    "codemirror": "6.0.2",
    "dompurify": "3.4.17",
    "fflate": "0.8.3",
    "marked": "18.0.13",
    "vite": "8.3.5"
  },
  "integrationSha256": "a369ba8d788c5f0451e32e49e15b16698b8a9d1c1173b5fdfc45ea7417870ca2"
}"""

let render() = file
