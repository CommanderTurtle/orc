module Muz.Source.Src.ZipJs

let file = """const encode = value => typeof value === 'string' ? new TextEncoder().encode(value) : value instanceof Uint8Array ? value : new Uint8Array(value);
const crcTable = Uint32Array.from({ length: 256 }, (_, i) => { for (let bit = 0; bit < 8; bit++) i = i & 1 ? 0xedb88320 ^ (i >>> 1) : i >>> 1; return i >>> 0; });
export function crc32(bytes) { let crc = 0xffffffff; for (const byte of bytes) crc = crcTable[(crc ^ byte) & 255] ^ (crc >>> 8); return (crc ^ 0xffffffff) >>> 0; }
// ZIP/STORE needs no CDN, worker bundle, compression library or native process.
export function zipArchive(entries) {
  const parts = [], directory = [], names = new Set(); let offset = 0, directorySize = 0;
  if (entries.length > 65535) throw Error('Archive exceeds 65,535 files.');
  for (const [path, content] of entries) {
    if (!path || path.startsWith('/') || /[\\\x00-\x1f]/.test(path) || path.split('/').some(p => !p || p === '..' || p === '.') || names.has(path)) throw Error('Invalid or duplicate archive path.');
    names.add(path);
    const name = encode(path), bytes = encode(content), crc = crc32(bytes);
    if (name.length > 65535 || offset + bytes.length + name.length + 30 > 512 * 1024 * 1024) throw Error('Archive exceeds the 512 MiB browser limit.');
    const local = new Uint8Array(30 + name.length), l = new DataView(local.buffer);
    l.setUint32(0, 0x04034b50, true); l.setUint16(4, 20, true); l.setUint16(6, 0x800, true); l.setUint16(12, 33, true);
    l.setUint32(14, crc, true); l.setUint32(18, bytes.length, true); l.setUint32(22, bytes.length, true); l.setUint16(26, name.length, true); local.set(name, 30);
    const central = new Uint8Array(46 + name.length), c = new DataView(central.buffer);
    c.setUint32(0, 0x02014b50, true); c.setUint16(4, 20, true); c.setUint16(6, 20, true); c.setUint16(8, 0x800, true); c.setUint16(14, 33, true);
    c.setUint32(16, crc, true); c.setUint32(20, bytes.length, true); c.setUint32(24, bytes.length, true); c.setUint16(28, name.length, true); c.setUint32(42, offset, true); central.set(name, 46);
    parts.push(local, bytes); directory.push(central); offset += local.length + bytes.length; directorySize += central.length;
  }
  const end = new Uint8Array(22), e = new DataView(end.buffer);
  e.setUint32(0, 0x06054b50, true); e.setUint16(8, entries.length, true); e.setUint16(10, entries.length, true); e.setUint32(12, directorySize, true); e.setUint32(16, offset, true);
  if (offset + directorySize + 22 > 512 * 1024 * 1024) throw Error('Archive exceeds the 512 MiB browser limit.');
  return new Blob([...parts, ...directory, end], { type: 'application/zip' });
}
"""

let render() = file
