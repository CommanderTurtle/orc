module Muz.Source.Toolkit.TimeJs

let file = """// Exact rational quarter-note beats. Convert to floating point only for weights,
// statistics and drawing, never to decide which side of a barline a note is on.
const gcd = (a, b) => { a = a < 0n ? -a : a; while (b) [a, b] = [b, a % b]; return a || 1n; };
export function rat(value) {
  if (Array.isArray(value)) {
    if (value.length !== 2 || !value.every(Number.isSafeInteger)) throw Error('Unsafe engine time fraction.');
    return reduce(BigInt(value[0]), BigInt(value[1]));
  }
  if (value && typeof value.n === 'bigint') return value;
  const text = String(value);
  if (/^-?\d+\/\d+$/.test(text)) { const [a, b] = text.split('/'); return reduce(BigInt(a), BigInt(b)); }
  const match = /^(-?)(\d+)(?:\.(\d+))?(?:e([+-]?\d+))?$/i.exec(text);
  if (!match || text.length > 60 || Math.abs(Number(match[4] || 0)) > 20) throw Error(`Invalid beat value: ${text}`);
  const decimals = (match[3] || '').length - Number(match[4] || 0);
  const n = BigInt(match[2] + (match[3] || '')) * (match[1] ? -1n : 1n);
  return decimals < 0 ? reduce(n * 10n ** BigInt(-decimals), 1n) : reduce(n, 10n ** BigInt(decimals));
}
function reduce(n, d) {
  if (d <= 0n) throw Error('Beat denominators must be positive.');
  const g = gcd(n, d); return { n: n / g, d: d / g };
}
export const add = (a, b) => reduce(a.n * b.d + b.n * a.d, a.d * b.d);
export const sub = (a, b) => reduce(a.n * b.d - b.n * a.d, a.d * b.d);
export const mul = (a, b) => reduce(a.n * b.n, a.d * b.d);
export const cmp = (a, b) => a.n * b.d < b.n * a.d ? -1 : a.n * b.d > b.n * a.d ? 1 : 0;
export const min = (a, b) => cmp(a, b) < 0 ? a : b;
export const max = (a, b) => cmp(a, b) > 0 ? a : b;
export const real = a => Number(a.n) / Number(a.d);
export const exact = a => a.d === 1n ? String(a.n) : `${a.n}/${a.d}`;
export const zero = rat(0);
"""

let render() = file
