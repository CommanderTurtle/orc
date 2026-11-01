module Muz.Source.Tests.EditorTestJs

let file = """import { test, expect } from 'bun:test';
import { tokens, diagnosticSpan, highlighted } from '../src/code-editor.js';

test('syntax colors preserve every source character, quotes and comments are opaque', () => {
  const source = '// fn fake()\nlet x = "<script>if(1)</script>";\n/* song(42) */\nsong({tempo:120, length:2bars})\n';
  const colors = tokens(source);
  expect(colors.filter(t => t.kind === 'function').map(t => source.slice(t.start, t.end))).toEqual(['song']);
  expect(colors.filter(t => t.kind === 'number').map(t => source.slice(t.start, t.end))).toEqual(['120', '2bars']);
  const html = highlighted(source, undefined, 'song.muz');
  expect(html).not.toContain('<script>'); expect(html).toContain('&lt;script&gt;');
  expect(html.replace(/<[^>]*>/g, '').replaceAll('&lt;', '<').replaceAll('&gt;', '>').replaceAll('&quot;', '"').replaceAll('&amp;', '&')).toBe(source + '\n');
});
test('native Unicode columns map to exact textarea spans and stay file-scoped', () => {
  const source = '// 😀\r\nlet x = "é"; invalid\n';
  const diagnostic = { message: 'Unknown <value>', location: { path: '/project/song.muz', line: 2, column: 14, width: 7 } };
  const span = diagnosticSpan(source, diagnostic, 'song.muz'); expect(source.slice(span.start, span.end)).toBe('invalid');
  expect(diagnosticSpan(source, diagnostic, 'other.muz')).toBeUndefined();
  expect(highlighted(source, diagnostic, 'song.muz')).toContain('class="code-error" title="Unknown &lt;value&gt;"');
  const eof = { message: 'expected expression', location: { path: 'song.muz', line: 1, column: 1, width: 1 } };
  expect(highlighted('', eof, 'song.muz')).toContain('code-error');
});
"""

let render() = file
