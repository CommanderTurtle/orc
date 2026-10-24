module ComfyUI.Assets.CloudPreviewUtilCkXtm3f0JsMap

let file = """{"version":3,"file":"cloudPreviewUtil-CkXtm3f0.js","names":[],"sources":["../../src/platform/distribution/cloudPreviewUtil.ts"],"sourcesContent":["import { getMediaTypeFromFilename } from '@/utils/formatUtil'\n\nimport { isCloud } from './types'\n\n/**\n * Appends `res=512` to the given URLSearchParams when in cloud mode\n * and the file is an image (or filename is unknown).\n *\n * The cloud backend resizes images server-side to prevent\n * the frontend from loading very large originals for previews.\n */\nexport function appendCloudResParam(\n  params: URLSearchParams,\n  filename?: string\n): void {\n  if (!isCloud) return\n  if (\n    filename &&\n    (getMediaTypeFromFilename(filename) !== 'image' ||\n      filename.toLowerCase().endsWith('.svg'))\n  )\n    return\n  params.set('res', '512')\n}\n"],"mappings":"wEAWA,SAAgB,oBACd,EACA,EACM,CASR"}"""

let render() = file
