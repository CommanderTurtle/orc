module Muz.Source.Toolkit.PngJs

let file = """import { deflateSync } from 'node:zlib';

const crcTable = new Uint32Array(256).map((_, i) => {
  let n = i; for (let b = 0; b < 8; b++) n = n & 1 ? 0xedb88320 ^ (n >>> 1) : n >>> 1; return n >>> 0;
});
function chunk(type, data) {
  const name = Buffer.from(type), result = Buffer.alloc(data.length + 12);
  result.writeUInt32BE(data.length); name.copy(result, 4); Buffer.from(data).copy(result, 8);
  let crc = 0xffffffff; for (const byte of Buffer.concat([name, Buffer.from(data)])) crc = crcTable[(crc ^ byte) & 255] ^ (crc >>> 8);
  result.writeUInt32BE((crc ^ 0xffffffff) >>> 0, data.length + 8); return result;
}
export function encodePNG(width, height, rgba, metadata = {}) {
  if (!Number.isInteger(width) || !Number.isInteger(height) || width < 1 || height < 1 || width * height > 4_000_000 || rgba.length !== width * height * 4) throw Error('Invalid PNG dimensions/pixels.');
  const header = Buffer.alloc(13); header.writeUInt32BE(width); header.writeUInt32BE(height, 4); header[8] = 8; header[9] = 6;
  const scan = Buffer.alloc(height * (width * 4 + 1));
  for (let y = 0; y < height; y++) Buffer.from(rgba.buffer, rgba.byteOffset + y * width * 4, width * 4).copy(scan, y * (width * 4 + 1) + 1);
  const description = Buffer.concat([Buffer.from('muz-study\0\0\0\0\0'), Buffer.from(JSON.stringify(metadata), 'utf8')]);
  return Buffer.concat([Buffer.from([137, 80, 78, 71, 13, 10, 26, 10]), chunk('IHDR', header), chunk('iTXt', description), chunk('IDAT', deflateSync(scan, { level: 9 })), chunk('IEND', Buffer.alloc(0))]);
}
"""

let render() = file
