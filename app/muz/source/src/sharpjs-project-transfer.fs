module Muz.Source.Src.ProjectTransferJs

let file = """import { normalizeProject } from './project.js';
// Same-origin, one-use handoff avoids packing large local sample projects into
// URLs. Public Copy link remains the existing portable ln.kr wire format.
async function database() {
  return new Promise((resolve, reject) => {
    const request = indexedDB.open('muzstatic-handoff', 1);
    request.onupgradeneeded = () => request.result.createObjectStore('projects', { keyPath: 'id' });
    request.onsuccess = () => resolve(request.result); request.onerror = () => reject(request.error);
  });
}
export async function writeHandoff(input) {
  const project = normalizeProject(input), db = await database(), id = crypto.randomUUID(), now = Date.now();
  try {
    await new Promise((resolve, reject) => {
      const tx = db.transaction('projects', 'readwrite'), store = tx.objectStore('projects'), request = store.getAll();
      request.onsuccess = () => {
        const records = request.result.sort((a, b) => a.created - b.created);
        const retained = records.filter(record => record.created > now - 15 * 60000).slice(-7);
        const keep = new Set(retained.map(record => record.id));
        for (const record of records) if (!keep.has(record.id)) store.delete(record.id);
        store.put({ id, created: now, project });
      };
      tx.oncomplete = resolve; tx.onerror = tx.onabort = () => reject(tx.error || Error('Local transfer failed. Use a Project export instead.'));
    });
    return '#handoff:' + id;
  } finally { db.close(); }
}
export async function readHandoff(fragment) {
  const id = fragment.match(/^#handoff:([a-f\d-]{36})$/i)?.[1];
  if (!id) throw Error('Invalid local project transfer.');
  const db = await database(); let record;
  try {
    await new Promise((resolve, reject) => {
      const tx = db.transaction('projects', 'readwrite'), store = tx.objectStore('projects'), request = store.get(id);
      request.onsuccess = () => { record = request.result; store.delete(id); };
      tx.oncomplete = resolve; tx.onerror = tx.onabort = () => reject(tx.error || Error('Local transfer failed.'));
    });
  } finally { db.close(); }
  if (!record || record.created < Date.now() - 15 * 60000) throw Error('This local transfer expired or was already opened. Send the project again from the original tab.');
  return normalizeProject(record.project);
}
"""

let render() = file
