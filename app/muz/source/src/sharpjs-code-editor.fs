module Muz.Source.Src.CodeEditorJs

let file = """// Presentation only. The native muz parser owns validity and source locations.
const escape = value => value.replaceAll('&', '&amp;').replaceAll('<', '&lt;').replaceAll('>', '&gt;').replaceAll('"', '&quot;');
const words = new Set(['let', 'fn', 'use', 'as', 'if', 'else', 'true', 'false', 'null']);
const lex = /\/\/[^\r\n]*|\/\*[\s\S]*?(?:\*\/|$)|"(?:\\[\s\S]|[^"\\])*"?|'(?:\\[\s\S]|[^'\\])*'?|\b\d+(?:\.\d+)?(?:[eE][+-]?\d+)?(?:bars?|b|ms|s|hz|Hz|dB)?\b|\b[A-Za-z_]\w*\b/g;
export function tokens(source) {
  return [...source.matchAll(lex)].map(m => {
    const text = m[0];
    const kind = text.startsWith('//') || text.startsWith('/*') ? 'comment' : /^["']/.test(text) ? 'string' : /^\d/.test(text) ? 'number' : words.has(text) ? 'keyword' : /^\s*\(/.test(source.slice(m.index + text.length)) ? 'function' : '';
    return { start: m.index, end: m.index + text.length, kind };
  });
}
export function diagnosticSpan(source, diagnostic, path) {
  const loc = diagnostic?.location;
  if (!loc || !Number.isSafeInteger(loc.line) || !Number.isSafeInteger(loc.column) || loc.line < 1 || loc.column < 1) return;
  if (loc.path && loc.path !== path && loc.path !== '/project/' + path) return;
  const lines = source.split(/\r\n|[\n\r\u2028\u2029]/), line = lines[loc.line - 1];
  if (line === undefined) return;
  let offset = 0, index = 1;
  for (const match of source.matchAll(/\r\n|[\n\r\u2028\u2029]/g)) { if (index++ >= loc.line) break; offset = match.index + match[0].length; }
  const prefix = [...line].slice(0, loc.column - 1).join('');
  const start = offset + prefix.length, width = Math.max(1, Math.min(200, loc.width || 1));
  const end = start + [...line.slice(prefix.length)].slice(0, width).join('').length;
  return { start, end: Math.max(start + 1, end), line: loc.line, message: diagnostic.message || 'Invalid muz source.' };
}
export function highlighted(source, diagnostic, path, enabled = true) {
  const span = diagnosticSpan(source, diagnostic, path), parts = [];
  const emit = (from, to, kind = '') => {
    if (to <= from) return;
    const value = escape(source.slice(from, to));
    parts.push(kind ? `<span class="code-${kind}">${value}</span>` : value);
  };
  const segment = (from, to, kind = '') => {
    if (span && from < span.end && to > span.start) {
      const a = Math.max(from, span.start), b = Math.min(to, span.end); emit(from, a, kind);
      parts.push(`<span class="code-error" title="${escape(span.message)}">`); emit(a, b, kind); parts.push('</span>'); emit(b, to, kind);
    } else emit(from, to, kind);
  };
  let cursor = 0;
  for (const token of enabled ? tokens(source) : []) { segment(cursor, token.start); segment(token.start, token.end, token.kind); cursor = token.end; }
  segment(cursor, source.length);
  // A final blank line and EOF diagnostic must still occupy a visible cell.
  if (span && span.start >= source.length) parts.push(`<span class="code-error" title="${escape(span.message)}"> </span>`);
  return parts.join('') + '\n';
}
export class CodeEditor {
  constructor(check, navigate) {
    this.check = check; this.input = document.getElementById('editor'); this.paint = document.getElementById('code-colors'); this.state = document.getElementById('lint-state');
    this.input.addEventListener('scroll', () => this.scroll());
    this.state.onclick = () => {
      const span = diagnosticSpan(this.source || '', this.diagnostic, this.path);
      if (span) { this.input.focus(); this.input.setSelectionRange(span.start, Math.min(span.end, this.source.length)); this.input.scrollTop = Math.max(0, (span.line - 4) * 22.1); this.scroll(); }
      else if (this.diagnostic?.location?.path) navigate?.(this.diagnostic);
    };
  }
  scroll() { this.paint.scrollTop = this.input.scrollTop; this.paint.scrollLeft = this.input.scrollLeft; }
  setSource(source, path, code = true) {
    if (source === this.source && path === this.path && code === this.code) return;
    this.source = source; this.path = path; this.code = code; this.diagnostic = undefined; clearTimeout(this.timer);
    this.version = (this.version || 0) + 1; this.draw();
    this.state.textContent = code ? 'Parsing…' : 'Text'; this.state.title = code ? 'Native muz parser' : 'Source text / asset';
    if (code) { const version = this.version; this.timer = setTimeout(async () => {
      try { await this.check({ source, path }); if (version === this.version && !this.diagnostic) { this.state.textContent = 'Syntax ✓'; this.state.title = 'Native muz syntax is valid. Compile checks names, types and the audio graph.'; } }
      catch (error) { if (version === this.version) this.showDiagnostic(error.diagnostic || { message: error.message }); }
    }, 600); }
  }
  showDiagnostic(diagnostic) {
    if (!diagnostic) return;
    this.diagnostic = diagnostic; const span = diagnosticSpan(this.source, diagnostic, this.path);
    this.state.textContent = span ? `Line ${span.line} · error` : 'Diagnostic'; this.state.title = diagnostic.message; this.draw();
  }
  accepted() {
    this.diagnostic = undefined; this.draw(); this.state.textContent = this.code ? 'Syntax ✓' : 'Text';
    this.state.title = this.code ? 'Source accepted by muz.' : 'Source text / asset';
  }
  draw() {
    this.paint.innerHTML = highlighted(this.source, this.diagnostic, this.path, this.code && this.source.length <= 256 * 1024);
    this.input.setAttribute('aria-invalid', String(Boolean(diagnosticSpan(this.source, this.diagnostic, this.path)))); this.scroll();
  }
}
"""

let render() = file
