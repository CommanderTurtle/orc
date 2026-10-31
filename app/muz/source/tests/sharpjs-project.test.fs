module Muz.Source.Tests.ProjectTestJs

let file = """import { test, expect } from 'bun:test';
import { normalizeProject, parseProject, projectPath, importFiles } from '../src/project.js';

test('plain source and multi-file project preserve exact text', () => {
  const source = '// 🌿\nlet x = "é";\r\nx\n';
  expect(parseProject(source).files['song.muz']).toBe(source);
  const project = normalizeProject({ entry: 'song.muz', files: { 'song.muz': source, 'lib/a.muz': '42', 'notes.md': '# note\n' } });
  expect(parseProject(JSON.stringify(project), 'project.json')).toEqual(project);
});
test('reject ambiguous/escaping paths and invalid entries', () => {
  for (const p of ['../a.muz', '/a.muz', 'a//b.muz', 'a/./b.muz', 'x\\b.muz', '__proto__/a.muz', 'C:/a.muz']) expect(() => projectPath(p)).toThrow();
  expect(() => normalizeProject({ entry: 'missing.muz', files: { 'a.muz': '42' } })).toThrow();
  expect(() => parseProject('<html>Login</html>')).toThrow();
});
test('folder import retains module and asset paths', async () => {
  const source = new File(['42'], 'song.muz'); Object.defineProperty(source, 'webkitRelativePath', { value: 'project/song.muz' });
  const asset = new File([new Uint8Array([1, 2, 3])], 'sample.wav'); Object.defineProperty(asset, 'webkitRelativePath', { value: 'project/audio/sample.wav' });
  const p = await importFiles([source, asset]);
  expect(p.entry).toBe('song.muz'); expect(p.assets['audio/sample.wav']).toBe('AQID');
});
"""

let render() = file
