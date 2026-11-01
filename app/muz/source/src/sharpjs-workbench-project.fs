module Muz.Source.Src.WorkbenchProjectJs

let file = """import { normalizeProject } from './project.js';
// Project data crosses the published browser host boundary, never native file
// authority. Unsupported resources fail before replacing either workspace.
export function toWorkbench(input) {
  const project = normalizeProject(input), workbenchAssets = Object.create(null);
  if (Object.keys(project.assets).length > 256) throw Error('The upstream browser host supports 256 assets. Keep this project in Studio.');
  let total = 0;
  for (const [path, base64] of Object.entries(project.assets)) {
    const ext = path.split('.').at(-1).toLowerCase(), formats = { mid: 'midi', midi: 'midi', wav: 'wav', flac: 'flac' };
    const format = Object.hasOwn(formats, ext) ? formats[ext] : undefined;
    if (!format) throw Error(`The upstream browser host does not support this asset type: ${path}. Keep this project in Studio.`);
    const size = base64.length / 4 * 3 - (base64.endsWith('==') ? 2 : base64.endsWith('=') ? 1 : 0); total += size;
    if (size > 16_000_000 || total > 64_000_000) throw Error('The upstream browser host allows 16 MB per asset / 64 MB total. Keep this project in Studio.');
    workbenchAssets[path] = { format, base64 };
  }
  return { ...project, workbenchAssets };
}
"""

let render() = file
