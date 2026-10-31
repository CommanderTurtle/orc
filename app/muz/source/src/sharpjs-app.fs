module Muz.Source.Src.AppJs

let file = """import { normalizeProject, importFiles, projectPath } from './project.js';
import { sourceFragment } from './links.js';
const $ = id => document.getElementById(id);
const base = new URL('.', import.meta.url);
let project, selected, dirty = true, compiled, acceptedRevision = -1, revision = 0, sharingTimer, draftTimer, shownFrame = 0;
let playing = false, audio, player, gain, generation = 0, pullPending = false, exportWorker, busy = false, abortOperation;
let engine, data, solos = new Set();
class RPC {
  constructor(name) {
    this.worker = new Worker(new URL(name, base), { type: 'module' }); this.pending = new Map(); this.sequence = 0;
    this.worker.onmessage = ({ data: d }) => {
      const p = this.pending.get(d.id); if (!p) return;
      if (d.progress !== undefined) { p.progress?.(d.progress); return; }
      clearTimeout(p.timer); this.pending.delete(d.id);
      d.error ? p.reject(Object.assign(Error(d.error), { diagnostic: d.diagnostic })) : p.resolve(d.result);
    };
    this.worker.onerror = event => { event.preventDefault(); this.close(Error(event.message || 'Worker failed.')); };
  }
  call(operation, input, timeout = 30000, progress) {
    return new Promise((resolve, reject) => {
      const id = ++this.sequence;
      const timer = timeout ? setTimeout(() => this.close(Error('Operation timed out. The worker was stopped; your source is preserved.')), timeout) : null;
      this.pending.set(id, { resolve, reject, timer, progress }); this.worker.postMessage({ id, operation, input });
    });
  }
  close(error = Error('Cancelled.')) { this.worker.terminate(); this.dead = true; for (const p of this.pending.values()) { clearTimeout(p.timer); p.reject(error); } this.pending.clear(); }
}
function message(text, error = false) { $('messages').textContent = text; $('messages').classList.toggle('error', error); }
function status(text) { $('status').textContent = text; }
function time(frames, rate = audio?.sampleRate || 48000) { const s = frames / rate; return `${Math.floor(s / 60)}:${(s % 60).toFixed(1).padStart(4, '0')}`; }
function urlFor(fragment) { const u = new URL(location.href); u.search = ''; u.hash = fragment; return u.href; }
function setFragment(fragment) { try { history.replaceState(null, '', urlFor(fragment)); $('link-state').textContent = `${fragment.startsWith('#s') ? 'Source link' : 'Embedded project'} · ${fragment.length.toLocaleString()} chars`; } catch { $('link-state').textContent = 'URL too large; download Project instead'; } }
function getData() { if (!data || data.dead) data = new RPC('data-worker.js'); return data; }
function getEngine() { if (!engine || engine.dead) { engine = new RPC('engine-worker.js'); acceptedRevision = -1; } return engine; }
function lines() { const n = $('editor').value.split('\n').length; $('line-numbers').textContent = Array.from({ length: n }, (_, i) => i + 1).join('\n'); $('file-info').textContent = `${n} lines · UTF-8`; }
function filesUI() {
  $('file').replaceChildren(); $('entry').replaceChildren();
  for (const path of Object.keys(project.files)) {
    $('file').add(new Option(path, path)); if (path.endsWith('.muz')) $('entry').add(new Option(path, path));
  }
  for (const path of Object.keys(project.assets)) $('file').add(new Option(`${path} [asset]`, path));
  $('file').value = selected; $('entry').value = project.entry; $('project-title').value = project.title;
  const asset = !(selected in project.files);
  $('editor').readOnly = asset; $('editor').value = asset ? `${selected}\n\nBinary asset · ${Math.floor(project.assets[selected].length * .75).toLocaleString()} bytes\nIncluded in saved projects and embedded links.` : project.files[selected]; lines();
}
async function saveDraft() {
  const db = await new Promise((resolve, reject) => { const r = indexedDB.open('muzstatic', 1); r.onupgradeneeded = () => r.result.createObjectStore('draft'); r.onsuccess = () => resolve(r.result); r.onerror = () => reject(r.error); });
  try { await new Promise((resolve, reject) => { const tx = db.transaction('draft', 'readwrite'); tx.objectStore('draft').put(project, 'current'); tx.oncomplete = resolve; tx.onerror = () => reject(tx.error); }); } finally { db.close(); }
}
async function readDraft() {
  const db = await new Promise((resolve, reject) => { const r = indexedDB.open('muzstatic', 1); r.onupgradeneeded = () => r.result.createObjectStore('draft'); r.onsuccess = () => resolve(r.result); r.onerror = () => reject(r.error); });
  try { return await new Promise((resolve, reject) => { const r = db.transaction('draft').objectStore('draft').get('current'); r.onsuccess = () => resolve(r.result); r.onerror = () => reject(r.error); }); } finally { db.close(); }
}
function edited() {
  revision++; dirty = true; status('Edited · compile to apply');
  clearTimeout(draftTimer); draftTimer = setTimeout(() => saveDraft().catch(() => status('Draft storage unavailable · use Project ↓')), 300);
  clearTimeout(sharingTimer); const rev = revision;
  sharingTimer = setTimeout(async () => { try { const fragment = await getData().call('share', project); if (revision === rev) setFragment(fragment); } catch (e) { if (revision === rev) $('link-state').textContent = e.message; } }, 950);
}
async function stop(reset = true) {
  generation++; playing = false; shownFrame = 0; $('position').textContent = time(0); $('play').textContent = '▶ Play';
  player?.port.postMessage({ type: 'clear' });
  if (reset && compiled && engine && !engine.dead) await engine.call('reset');
  drawScores();
}
async function install(value, fragment) {
  await stop(false); project = normalizeProject(value); selected = project.entry; revision++; acceptedRevision = -1; compiled = undefined; dirty = true; solos.clear();
  $('tracks').replaceChildren(); $('empty-score').hidden = false; $('score-info').textContent = 'Not compiled'; $('tempo').textContent = '— BPM'; $('duration').textContent = '—';
  filesUI(); await saveDraft().catch(() => {});
  if (fragment) setFragment(fragment); else edited();
  message('Project loaded. Compile or Play when ready.'); status('Local workspace');
}
async function audioSetup() {
  if (!audio) {
    audio = new AudioContext({ sampleRate: 48000 });
    await audio.audioWorklet.addModule(new URL('player-worklet.js', base));
    player = new AudioWorkletNode(audio, 'muzstatic-player', { numberOfInputs: 0, numberOfOutputs: 1, outputChannelCount: [2] });
    gain = audio.createGain(); gain.gain.value = Number($('volume').value) / 100;
    player.connect(gain).connect(audio.destination);
    player.port.onmessage = ({ data: d }) => {
      if (d.type === 'need') fill().catch(fail);
      if (d.type === 'position') { shownFrame = d.frame; $('position').textContent = time(shownFrame); drawScores(); }
      if (d.type === 'ended') { playing = false; $('play').textContent = '▶ Replay'; status('Playback finished'); }
    };
  }
  await audio.resume();
}
async function fill() {
  if (pullPending || !compiled) return;
  pullPending = true; const gen = generation;
  try {
    const chunk = await getEngine().call('pull', { frames: 16384, rate: audio.sampleRate });
    if (gen === generation) player.port.postMessage({ type: 'chunk', pcm: chunk.pcm, done: chunk.done }, [chunk.pcm.buffer]);
  } finally { pullPending = false; if (gen !== generation) player?.port.postMessage({ type: 'retry' }); }
}
async function compile() {
  await stop(false); const rev = revision;
  message('Compiling with muz…'); status('Compiling');
  const rpc = getEngine();
  abortOperation = () => rpc.close();
  const result = await rpc.call('compile', { project, rate: audio?.sampleRate || 48000 });
  if (rev !== revision) { status('Edited during compilation · compile again'); return false; }
  compiled = result; acceptedRevision = rev; dirty = false; solos.clear();
  $('duration').textContent = time(result.frames + (result.tail || 0) * (audio?.sampleRate || 48000));
  $('tempo').textContent = `${result.bpm} BPM · ${result.meter.join('/')}`;
  $('score-info').textContent = `${result.tracks.length} tracks`; $('empty-score').hidden = true;
  buildScores();
  message([`Compiled ${result.title || project.entry}.`, ...result.diagnostics.map(d => `${d.severity}: ${d.track} · ${d.message}`)].join('\n'));
  status('Compiled · ready'); return true;
}
async function play() {
  if (playing) { playing = false; player.port.postMessage({ type: 'pause' }); $('play').textContent = '▶ Resume'; status('Paused'); return; }
  await audioSetup();
  if (dirty || acceptedRevision !== revision || engine?.dead) { if (!await compile()) return; }
  else if (shownFrame >= compiled.frames + (compiled.tail || 0) * audio.sampleRate - 128) await stop();
  if (!shownFrame) await fill();
  playing = true; player.port.postMessage({ type: 'play' }); $('play').textContent = 'Ⅱ Pause'; status('Playing');
}
function buildScores() {
  $('tracks').replaceChildren();
  compiled.tracks.forEach((track, index) => {
    const section = document.createElement('section'); section.className = 'track';
    const head = document.createElement('div'); head.className = 'track-head';
    const name = document.createElement('span'); name.className = 'track-id'; name.textContent = track.name || track.id; name.style.color = colors[index % colors.length];
    const count = document.createElement('span'); count.className = 'note-count'; count.textContent = `${track.notes.length} notes`;
    const solo = document.createElement('button'); solo.textContent = 'Solo'; solo.setAttribute('aria-pressed', 'false');
    solo.onclick = () => action(async () => { solos.has(track.id) ? solos.delete(track.id) : solos.add(track.id); solo.setAttribute('aria-pressed', String(solos.has(track.id))); await getEngine().call('solo', [...solos]); });
    const canvas = document.createElement('canvas'); canvas.setAttribute('aria-label', `Score for ${track.id}`); canvas.setAttribute('role', 'img');
    head.append(name, count, solo); section.append(head, canvas); $('tracks').append(section);
  }); drawScores();
}
const colors = ['#89d6b4', '#94b8ed', '#d5acf0', '#edc28f', '#e894ad', '#85cbd2'];
function drawScores() {
  if (!compiled) return;
  const span = Math.max(1, compiled.frames);
  [...$('tracks').querySelectorAll('canvas')].forEach((canvas, index) => {
    const width = Math.max(1, canvas.clientWidth), height = 82, dpr = window.devicePixelRatio || 1;
    canvas.width = width * dpr; canvas.height = height * dpr;
    const ctx = canvas.getContext('2d'); ctx.scale(dpr, dpr);
    ctx.strokeStyle = '#22313e'; ctx.lineWidth = .5;
    for (let x = 0; x < 17; x++) { ctx.beginPath(); ctx.moveTo(x * width / 16, 0); ctx.lineTo(x * width / 16, height); ctx.stroke(); }
    const notes = compiled.tracks[index].notes;
    const low = Math.min(48, ...notes.slice(0, 20000).map(n => n.pitch)), high = Math.max(72, ...notes.slice(0, 20000).map(n => n.pitch));
    ctx.fillStyle = colors[index % colors.length];
    for (const n of notes) { ctx.globalAlpha = .35 + Math.max(0, Math.min(1, n.velocity)) * .65; ctx.fillRect(n.at / span * width, 6 + (high - n.pitch) / (high - low + 1) * 68, Math.max(2, n.dur / span * width - 1), 3); }
    ctx.globalAlpha = 1;
    if (shownFrame) { const x = Math.min(width, shownFrame / compiled.frames * width); ctx.strokeStyle = '#fff'; ctx.beginPath(); ctx.moveTo(x, 0); ctx.lineTo(x, height); ctx.stroke(); }
  });
}
function download(bytes, name, type) { const url = URL.createObjectURL(new Blob([bytes], { type })); const a = document.createElement('a'); a.href = url; a.download = name; a.click(); setTimeout(() => URL.revokeObjectURL(url), 30000); }
function filename(suffix) { return (project.title.replace(/[^\w .-]/g, '_') || 'song') + suffix; }
async function share(mode) {
  $('share-status').textContent = 'Preparing…';
  try {
    const fragment = mode === 'embedded' ? await getData().call('share', project) : sourceFragment($('source-input').value, mode === 'super');
    const url = urlFor(fragment); $('share-output').value = url; setFragment(fragment);
    try { await navigator.clipboard.writeText(url); $('share-status').textContent = `Copied · ${url.length.toLocaleString()} characters`; } catch { $('share-output').select(); $('share-status').textContent = 'Select and copy the URL below.'; }
  } catch (e) { $('share-status').textContent = e.message; }
}
function fail(e) { playing = false; player?.port.postMessage({ type: 'pause' }); $('play').textContent = '▶ Play'; message(e.message, true); status('Stopped · source preserved'); }
async function action(fn) {
  if (busy) return; busy = true; $('cancel').hidden = false;
  try { await fn(); } catch (e) { fail(e); } finally { busy = false; abortOperation = undefined; $('cancel').hidden = true; }
}
async function openLink(input) {
  const rpc = getData(); abortOperation = () => rpc.close(); message('Resolving project link…'); status('Loading');
  if (/^(?:https:\/\/gist\.github\.com\/[^/]+\/)?[a-f\d]{32,40}(?:\/|$)/i.test(input.trim())) {
    await install(await rpc.call('gist', input, 35000));
  } else { const result = await rpc.call('resolve', input, 35000); await install(result.project, result.fragment); message(`Loaded ${project.entry}${result.sources.length ? '\n' + result.sources.join('\n') : ' from embedded data'}.`); }
}
$('editor').addEventListener('input', () => { project.files[selected] = $('editor').value; lines(); edited(); });
$('editor').addEventListener('scroll', () => { $('line-numbers').scrollTop = $('editor').scrollTop; });
$('editor').addEventListener('keydown', e => { if (e.key === 'Tab' && !e.shiftKey) { e.preventDefault(); const field = $('editor'); field.setRangeText('  ', field.selectionStart, field.selectionEnd, 'end'); field.dispatchEvent(new Event('input')); } });
$('project-title').oninput = () => { project.title = $('project-title').value; edited(); };
$('file').onchange = () => { selected = $('file').value; filesUI(); };
$('entry').onchange = () => { project.entry = $('entry').value; edited(); };
$('add-file').onclick = () => { const input = prompt('Project-relative source path', 'module.muz'); if (!input) return; try { const path = projectPath(input); if (!/\.(muz|md)$/.test(path) || path in project.files || path in project.assets) throw Error('Choose a new .muz or .md path.'); project.files[path] = ''; selected = path; filesUI(); edited(); } catch (e) { fail(e); } };
$('remove-file').onclick = () => { if (selected === project.entry) return message('Choose a different entry before removing this file.'); if (!confirm(`Remove ${selected} from this project?`)) return; delete project.files[selected]; delete project.assets[selected]; selected = project.entry; filesUI(); edited(); };
$('compile').onclick = () => action(compile); $('play').onclick = () => playing ? play().catch(fail) : action(play); $('stop').onclick = () => stop().catch(fail);
$('volume').oninput = () => { if (gain) gain.gain.setTargetAtTime(Number($('volume').value) / 100, audio.currentTime, .02); };
$('open-link').onclick = () => $('link-dialog').showModal();
$('link-form').onsubmit = e => { e.preventDefault(); const input = $('link-input').value; $('link-dialog').close(); action(() => openLink(input)); };
$('open-files').onclick = () => $('file-input').click(); $('open-folder').onclick = () => $('folder-input').click();
for (const id of ['file-input', 'folder-input']) $(id).onchange = () => action(async () => { const value = await importFiles($(id).files); $(id).value = ''; await install(value); });
$('share').onclick = () => $('share-dialog').showModal();
$('share-embedded').onclick = () => share('embedded'); $('share-source').onclick = () => share('source'); $('share-super').onclick = () => share('super');
$('save-project').onclick = () => download(JSON.stringify(normalizeProject(project), null, 2), filename('.muzproject.json'), 'application/json');
$('export-midi').onclick = () => action(async () => { if (dirty || acceptedRevision !== revision) { if (!await compile()) return; } const bytes = await getEngine().call('midi'); download(bytes, filename('.mid'), 'audio/midi'); message('MIDI exported by the muz engine.'); });
$('export-wav').onclick = () => action(async () => {
  exportWorker = new RPC('engine-worker.js'); abortOperation = () => exportWorker.close();
  try { const bytes = await exportWorker.call('wav', { project, rate: 48000 }, 0, p => { status(`Exporting WAV · ${Math.floor(p * 100)}%`); }); download(bytes, filename('.wav'), 'audio/wav'); message('WAV exported · 48 kHz · stereo · PCM24'); status('Export complete'); } finally { exportWorker.close(); exportWorker = undefined; }
});
$('cancel').onclick = () => abortOperation?.();
$('new').onclick = () => action(async () => { if (!confirm('Start a new project? Download Project first to keep a separate copy.')) return; await install(await template()); });
document.querySelectorAll('dialog .close').forEach(b => b.onclick = () => b.closest('dialog').close());
document.addEventListener('keydown', e => { if ((e.ctrlKey || e.metaKey) && (e.key.toLowerCase() === 's' || e.key === 'Enter') && !document.querySelector('dialog[open]')) { e.preventDefault(); if (e.key === 'Enter' && playing) play().catch(fail); else action(e.key === 'Enter' ? play : compile); } });
document.addEventListener('dragover', e => { e.preventDefault(); document.body.classList.add('dragging'); });
document.addEventListener('dragleave', e => { if (!e.relatedTarget) document.body.classList.remove('dragging'); });
document.addEventListener('drop', e => { e.preventDefault(); document.body.classList.remove('dragging'); if (e.dataTransfer.files.length) action(async () => install(await importFiles(e.dataTransfer.files))); });
window.addEventListener('resize', drawScores);
window.addEventListener('hashchange', () => { if (location.hash) action(() => openLink(location.hash)); });
let library;
$('reference').onclick = () => action(async () => { if (!library) { library = await fetch(new URL('library.json', base)).then(r => r.json()); library.forEach((m, i) => $('library').add(new Option(m.name, i))); $('library-source').textContent = library[0]?.source || ''; } $('reference-dialog').showModal(); });
$('library').onchange = () => { $('library-source').textContent = library[Number($('library').value)].source; };
async function template() { return normalizeProject({ title: 'Untitled', entry: 'song.muz', files: { 'song.muz': await fetch(new URL('template.muz', base)).then(r => { if (!r.ok) throw Error('Missing bundled template.'); return r.text(); }) } }); }
try {
  const provenance = await fetch(new URL('engine.json', base)).then(r => r.json());
  $('engine-version').textContent = provenance.revision.slice(0, 7);
  $('provenance').textContent = `Engine ${provenance.revision}${provenance.local ? ' · local source' : ' · pinned upstream'}${provenance.dirty ? ' · includes local edits' : ''}. Built without desktop features. No runtime CDN or proxy.`;
  const hash = location.hash, query = new URL(location.href).searchParams;
  const draft = await readDraft().catch(() => undefined);
  project = normalizeProject(draft || await template()); selected = project.entry; filesUI();
  const link = query.get('source') || query.get('url') || (query.get('gist') ? 'https://gist.github.com/unknown/' + query.get('gist') : hash);
  if (link) await action(() => openLink(link));
  else { message(draft ? 'Local draft restored.' : 'Ready. Edit the bundled muz template, or open a project.'); status('Local workspace'); }
} catch (e) { fail(e); }
"""

let render() = file
