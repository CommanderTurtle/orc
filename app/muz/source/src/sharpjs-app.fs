module Muz.Source.Src.AppJs

let file = """import { normalizeProject, importFiles, projectPath } from './project.js';
import { sourceFragment } from './links.js';
import { audibleTracks, beatToFrame, clampFrame } from './timeline.js';
import { applyStudioEdit, studioSource } from './studio-source.js';
import { StudioView } from './studio-view.js';
import { normalizeCatalog, loadCatalog, importCatalog } from './catalog.js';
import { zipArchive } from './zip.js';
import { exportDawproject } from './dawproject.js';
import { CodeEditor } from './code-editor.js';
import { writeHandoff, readHandoff } from './project-transfer.js';
import { toWorkbench } from './workbench-project.js';
const $ = id => document.getElementById(id);
const base = new URL('.', import.meta.url);
let project, selected, dirty = true, compiled, acceptedRevision = -1, revision = 0, sharingTimer, draftTimer, shownFrame = 0;
let playing = false, audio, player, gain, generation = 0, pullPending = false, exportWorker, busy = false, abortOperation;
let engine, data, solos = new Set(), mutes = new Set(), markers = [], scrubbing = false, seekBusy = false, queuedSeek, liveTimer;
let loopStart = 0, loopEnd = 0, undo = [], redo = [], lastCheckpoint = 0, inspectionOffset = 0, inspectionNext;
let lintWorker, lintIdle, revisions = [], revisionSequence = 0, seekResume = false;
const snapshot = () => ({ ...project, files: { ...project.files }, assets: { ...project.assets }, ...(project.studio ? { studio: structuredClone(project.studio) } : {}) });
function historyUI() { $('undo').disabled = !undo.length; $('redo').disabled = !redo.length; }
function checkpoint(group = false) { if (!group || Date.now() - lastCheckpoint > 650) { undo.push(snapshot()); if (undo.length > 40) undo.shift(); lastCheckpoint = Date.now(); } redo = []; historyUI(); }
const totalFrames = () => compiled ? compiled.frames + Math.round((compiled.tail || 0) * compiled.rate) : 0;
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
const codeEditor = new CodeEditor(async input => {
  clearTimeout(lintIdle); if (!lintWorker || lintWorker.dead) lintWorker = new RPC('engine-worker.js');
  try { return await lintWorker.call('lint', input, 10000); }
  finally { const worker = lintWorker; lintIdle = setTimeout(() => { worker.close(); if (lintWorker === worker) lintWorker = undefined; }, 30000); }
}, diagnostic => {
  const path = diagnostic.location.path.replace(/^\/project\//, '');
  if (path in project.files) { selected = path; filesUI(); codeEditor.showDiagnostic(diagnostic); }
});
function message(text, error = false) { $('messages').textContent = text; $('messages').classList.toggle('error', error); }
function status(text) { $('status').textContent = text; }
function time(frames, rate = audio?.sampleRate || 48000) { const s = frames / rate; return `${Math.floor(s / 60)}:${(s % 60).toFixed(1).padStart(4, '0')}`; }
function urlFor(fragment) { const u = new URL(location.href); u.search = ''; u.hash = fragment; return u.href; }
function setFragment(fragment) { try { history.replaceState(null, '', urlFor(fragment)); $('link-state').textContent = `${fragment.startsWith('#s') ? 'Source link' : 'Embedded project'} · ${fragment.length.toLocaleString()} chars`; } catch { $('link-state').textContent = 'URL too large; download Project instead'; } }
function getData() { if (!data || data.dead) data = new RPC('data-worker.js'); return data; }
function getEngine() { if (!engine || engine.dead) { engine = new RPC('engine-worker.js'); acceptedRevision = -1; } return engine; }
function lines() { const n = $('editor').value.split('\n').length; $('line-numbers').textContent = Array.from({ length: n }, (_, i) => i + 1).join('\n'); $('file-info').textContent = `${n} lines · UTF-8`; codeEditor.setSource($('editor').value, selected, selected in project.files && selected.endsWith('.muz')); }
function filesUI() {
  $('file').replaceChildren(); $('entry').replaceChildren();
  for (const path of Object.keys(project.files)) {
    $('file').add(new Option(path, path)); if (path.endsWith('.muz')) $('entry').add(new Option(path, path));
  }
  for (const path of Object.keys(project.assets)) $('file').add(new Option(`${path} [asset]`, path));
  $('file').value = selected; $('entry').value = project.entry; $('project-title').value = project.title;
  const asset = !(selected in project.files);
  $('editor').readOnly = asset || selected === project.studio?.generated; $('editor').value = asset ? `${selected}\n\nBinary asset · ${Math.floor(project.assets[selected].length * .75).toLocaleString()} bytes\nIncluded in saved projects and embedded links.` : project.files[selected]; lines();
  $('detach-studio').hidden = !project.studio;
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
  scheduleLive();
}
function scheduleLive() {
  clearTimeout(liveTimer);
  if ($('live').checked && dirty && compiled && !busy && !seekBusy) liveTimer = setTimeout(() => action(compile), 800);
}
function positionUI() {
  if (!scrubbing) { $('position').textContent = time(shownFrame, compiled?.rate); $('seek').value = shownFrame; }
  for (const { marker, width } of markers) { marker.style.display = shownFrame ? 'block' : 'none'; marker.style.transform = `translateX(${Math.min(width, shownFrame / Math.max(1, compiled.frames) * width)}px)`; }
  piano.position(shownFrame);
}
function loopUI() {
  if (!compiled) return;
  loopStart = clampFrame(loopStart, compiled.frames); loopEnd = clampFrame(loopEnd || compiled.frames, compiled.frames);
  if (loopEnd <= loopStart) { loopStart = 0; loopEnd = compiled.frames; }
  $('loop-label').textContent = `${time(loopStart, compiled.rate)}–${time(loopEnd, compiled.rate)}`;
  player?.port.postMessage({ type: 'loop', range: $('loop-enabled').checked ? [loopStart, loopEnd] : null });
}
async function stop(reset = true) {
  generation++; playing = false; seekResume = false; scrubbing = false; shownFrame = 0; $('position').textContent = time(0); $('play').textContent = '▶ Play';
  queuedSeek = undefined; player?.port.postMessage({ type: 'clear', epoch: generation });
  if (reset && compiled && engine && !engine.dead) await engine.call('reset');
  positionUI();
}
async function install(value, fragment) {
  await stop(false); project = normalizeProject(value); selected = project.entry; revision++; acceptedRevision = -1; compiled = undefined; dirty = true; solos.clear(); mutes.clear(); undo = []; redo = []; markers = []; loopStart = 0; loopEnd = 0; historyUI();
  $('tracks').replaceChildren(); $('empty-score').hidden = false; $('score-info').textContent = 'Not compiled'; $('tempo').textContent = '— BPM'; $('duration').textContent = '—';
  $('seek').disabled = true; $('piano-track').replaceChildren();
  revisions = []; revisionSequence = 0; revisionUI();
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
      if (d.epoch !== generation) return;
      if (d.type === 'need') fill().catch(fail);
      if (d.type === 'position') { shownFrame = d.frame; positionUI(); }
      if (d.type === 'loop') requestSeek(d.frame, true);
      if (d.type === 'ended') { playing = false; $('play').textContent = '▶ Replay'; status('Playback finished'); }
    };
    player.port.postMessage({ type: 'clear', epoch: generation, frame: shownFrame }); loopUI();
  }
  await audio.resume();
}
async function fill() {
  if (pullPending || !compiled) return;
  pullPending = true; const gen = generation;
  try {
    const chunk = await getEngine().call('pull', { frames: 16384, rate: audio.sampleRate });
    if (gen === generation) player.port.postMessage({ type: 'chunk', epoch: gen, pcm: chunk.pcm, done: chunk.done }, [chunk.pcm.buffer]);
  } finally { pullPending = false; if (gen !== generation) player?.port.postMessage({ type: 'retry' }); }
}
async function compile() {
  const rev = revision, candidate = snapshot(), retaining = compiled && engine && !engine.dead && acceptedRevision >= 0;
  if (!retaining) await stop(false);
  message('Compiling with muz…'); status('Compiling');
  const rpc = getEngine();
  abortOperation = () => rpc.close();
  let result;
  try { result = await rpc.call(retaining ? 'revise' : 'compile', { project: candidate, rate: audio?.sampleRate || 48000 }); }
  catch (error) { error.sourceRevision = rev; throw error; }
  compiled = result; acceptedRevision = rev; dirty = rev !== revision;
  if (!dirty) codeEditor.accepted();
  if (revisions.at(-1)?.sourceRevision !== rev) { revisions.push({ id: ++revisionSequence, sourceRevision: rev, project: candidate, time: new Date().toLocaleTimeString() }); if (revisions.length > 20) revisions.shift(); revisionUI(); }
  const ids = new Set(result.tracks.map(t => t.id)); solos = new Set([...solos].filter(id => ids.has(id))); mutes = new Set([...mutes].filter(id => ids.has(id)));
  await syncAudition();
  $('duration').textContent = time(result.frames + (result.tail || 0) * (audio?.sampleRate || 48000));
  $('tempo').textContent = `${Math.round(result.bpm * 1000) / 1000} BPM · ${result.meter.join('/')}`;
  $('score-info').textContent = `${result.tracks.length} tracks`; $('empty-score').hidden = true;
  buildScores();
  piano.update(result); $('seek').disabled = false; $('seek').max = totalFrames();
  $('section').replaceChildren(new Option('Sections', ''), ...result.sections.map(s => new Option(s.name, beatToFrame(s.start, result)))); loopUI(); positionUI();
  message([`Compiled ${result.title || project.entry}.`, ...result.diagnostics.map(d => `${d.severity}: ${d.track} · ${d.message}`)].join('\n'));
  status(dirty ? 'Accepted revision applied · newer edits pending' : playing ? 'Playing · revision applied' : 'Compiled · ready'); return !dirty;
}
async function play() {
  if (seekBusy) { playing = !playing; seekResume = playing; $('play').textContent = playing ? 'Ⅱ Pause' : '▶ Resume'; return; }
  if (playing) { playing = false; player.port.postMessage({ type: 'pause' }); $('play').textContent = '▶ Resume'; status('Paused'); return; }
  await audioSetup();
  if (dirty || acceptedRevision !== revision || engine?.dead) { if (!await compile()) return; }
  else if (shownFrame >= compiled.frames + (compiled.tail || 0) * audio.sampleRate - 128) await stop();
  if (!shownFrame) await fill();
  playing = true; player.port.postMessage({ type: 'play' }); $('play').textContent = 'Ⅱ Pause'; status('Playing');
}
async function requestSeek(frame, resume = playing) {
  if (!compiled) return;
  seekResume = resume; playing = resume;
  queuedSeek = { frame: clampFrame(frame, totalFrames()), resume };
  if (seekBusy) return; seekBusy = true;
  try {
    while (queuedSeek) {
      const target = queuedSeek; queuedSeek = undefined;
      const gen = ++generation; player?.port.postMessage({ type: 'clear', epoch: gen, frame: target.frame });
      status('Seeking'); const rpc = getEngine();
      const result = await rpc.call('seek', { frame: target.frame }, 60000, p => { if (gen === generation && !queuedSeek) status(`Seeking · ${Math.floor(p * 100)}%`); });
      if (gen !== generation) continue;
      shownFrame = result.frame; positionUI();
      if (queuedSeek) continue;
      if (seekResume && !result.done) { await audioSetup(); await fill(); playing = true; player.port.postMessage({ type: 'play', epoch: gen }); $('play').textContent = 'Ⅱ Pause'; status('Playing'); }
      else { playing = false; $('play').textContent = '▶ Resume'; status('Paused'); }
    }
  } catch (e) { fail(e); } finally { seekBusy = false; scheduleLive(); }
}
async function syncAudition() { if (compiled && engine && !engine.dead) await engine.call('audition', audibleTracks(compiled.tracks, solos, mutes)); }
async function studioEdit(id, patch) {
  if (busy) throw Error('Wait for the current operation to finish.');
  const candidate = normalizeProject(applyStudioEdit(project, id, patch)); checkpoint(); project = candidate;
  if (!(selected in project.files) && !(selected in project.assets)) selected = project.entry;
  filesUI(); edited(); await action(compile, true);
}
function view(name) {
  for (const key of ['arrangement', 'piano', 'inspect']) { $(key + '-panel').hidden = name !== key; $('view-' + key).setAttribute('aria-pressed', String(name === key)); }
  if (name === 'piano') piano.draw(); if (name === 'inspect' && compiled) inspect().catch(e => message(e.message, true));
}
const piano = new StudioView({ apply: studioEdit, seek: beat => requestSeek(beatToFrame(beat, compiled)), report: text => message(text, true), addTrack: () => {
  if (!compiled) return message('Compile a project first.');
  const id = prompt('New track id', 'new-track'); if (!id) return;
  if (compiled.tracks.some(t => t.id === id)) return message('That track id already exists.', true);
  studioEdit(id, { added: true, preset: 'glass-lead', notes: [] }).catch(fail);
} });
async function inspect() {
  if (!compiled) return;
  const rev = acceptedRevision, selectedView = $('inspect-view').value;
  const result = await getEngine().call('inspect', { view: selectedView, page: { offset: inspectionOffset, limit: 50 } });
  if (rev !== acceptedRevision || selectedView !== $('inspect-view').value) return;
  inspectionNext = result.next;
  $('inspect-output').textContent = JSON.stringify(result.rows, null, 2);
  $('inspect-info').textContent = `${Math.min(result.total, inspectionOffset + 1)}–${inspectionOffset + result.rows.length} / ${result.total}`;
  $('inspect-prev').disabled = inspectionOffset === 0; $('inspect-next').disabled = result.next === null;
}
let catalogPacks, catalogValue, catalogSelection = new Set(), catalogAbort;
function catalogRows() {
  const query = $('catalog-search').value.toLowerCase();
  return (catalogValue?.files || []).filter(file => file.path.toLowerCase().includes(query)).slice(0, 250);
}
function catalogCount() {
  const chosen = catalogValue?.files.filter(file => catalogSelection.has(file.path)) || [];
  $('catalog-count').textContent = `${chosen.length} selected · ${(chosen.reduce((n, f) => n + (f.bytes || f.text?.length || 0), 0) / 1048576).toFixed(1)} MiB`;
}
function drawCatalog() {
  $('catalog-files').replaceChildren();
  for (const resource of catalogRows()) {
    const row = document.createElement('label'); row.className = 'catalog-row';
    const check = document.createElement('input'); check.type = 'checkbox'; check.checked = catalogSelection.has(resource.path);
    check.onchange = () => { check.checked ? catalogSelection.add(resource.path) : catalogSelection.delete(resource.path); catalogCount(); };
    const name = document.createElement('span'); name.textContent = resource.path;
    const size = document.createElement('small'); size.textContent = resource.text !== undefined ? 'source' : `${((resource.bytes || 0) / 1048576).toFixed(2)} MiB${resource.sha256 ? ' · SHA-256' : ''}`;
    row.append(check, name, size); $('catalog-files').append(row);
  }
  catalogCount();
}
function selectCatalog(value) {
  catalogValue = value; catalogSelection.clear(); $('catalog-search').value = '';
  $('catalog-info').textContent = `${value.title} · ${value.license}\n${value.files.length.toLocaleString()} resources · Showing up to 250 matches. Filter to narrow the list.\nChoose matching .muz mappings and the samples they reference. Project limit: 500 assets / 64 MiB.`;
  $('catalog-status').textContent = ''; drawCatalog();
}
async function openCatalog() {
  if (!catalogPacks) {
    const response = await fetch(new URL('catalogs.json', base));
    if (!response.ok) throw Error('Bundled catalogs are missing. Rebuild the complete dist.');
    catalogPacks = (await response.json()).map(value => normalizeCatalog(value, location.href));
    catalogPacks.forEach((pack, i) => $('catalog-pack').add(new Option(pack.title, String(i))));
  }
  $('catalog-dialog').showModal();
}
async function exportBundle(kind) {
  const rpc = new RPC('engine-worker.js'); exportWorker = rpc; abortOperation = () => rpc.close();
  const source = normalizeProject(snapshot());
  try {
    status('Preparing export');
    const score = await rpc.call('prepare-export', { project: source, rate: 48000 });
    const midi = await rpc.call('midi');
    if (kind === 'midi') { download(midi, filename('.mid'), 'audio/midi'); return; }
    const master = await rpc.call('wav', {}, 0, p => status(`Rendering master · ${Math.floor(p * 100)}%`));
    if (kind === 'wav') download(master, filename('.wav'), 'audio/wav');
    else if (kind === 'daw') {
      status('Packaging DAWProject');
      download(exportDawproject(score, source, master, midi), filename('.dawproject'), 'application/zip');
      message('DAWProject exported: rendered master + muted editable note tracks, MIDI, native project and fidelity report. Assign instruments before replacing the reference mix.');
    } else {
      const entries = [['master.wav', master], ['song.mid', midi], ['project.muzproject.json', JSON.stringify(source)]];
      let size = master.byteLength;
      for (const [i, track] of score.tracks.entries()) {
        const estimate = master.byteLength; if (size + estimate > 480 * 1024 * 1024) throw Error('Stems exceed the browser archive budget. Export individual tracks from a shorter project.');
        const bytes = await rpc.call('wav', { track: track.id }, 0, p => status(`Stem ${i + 1}/${score.tracks.length} · ${Math.floor(p * 100)}%`));
        entries.push([`stems/${String(i + 1).padStart(2, '0')}-${track.id.replace(/[^\w.-]/g, '_')}.wav`, bytes]); size += bytes.byteLength;
      }
      entries.push(['stems.json', JSON.stringify({ format: 'muzstatic/stems/1', rate: 48000, bitDepth: 24, tracks: score.tracks.map(t => t.id), note: 'Native post-insert track taps. Shared buses/master effects remain in master.wav; stems are not guaranteed to sum to the master.' }, null, 2)]);
      download(zipArchive(entries), filename('-stems.zip'), 'application/zip'); message('Master, track taps, MIDI and native project exported. See stems.json for routing details.');
    }
    status('Export complete');
  } finally { rpc.close(); exportWorker = undefined; }
}
function buildScores() {
  $('tracks').replaceChildren(); markers = [];
  compiled.tracks.forEach((track, index) => {
    const section = document.createElement('section'); section.className = 'track';
    const head = document.createElement('div'); head.className = 'track-head';
    const name = document.createElement('span'); name.className = 'track-id'; name.textContent = track.name || track.id; name.style.color = colors[index % colors.length];
    const count = document.createElement('span'); count.className = 'note-count'; count.textContent = `${track.notes.length} notes`;
    const solo = document.createElement('button'); solo.textContent = 'Solo'; solo.setAttribute('aria-pressed', String(solos.has(track.id)));
    const mute = document.createElement('button'); mute.textContent = 'Mute'; mute.setAttribute('aria-pressed', String(mutes.has(track.id)));
    solo.onclick = () => action(async () => { solos.has(track.id) ? solos.delete(track.id) : solos.add(track.id); solo.setAttribute('aria-pressed', String(solos.has(track.id))); await syncAudition(); });
    mute.onclick = () => action(async () => { mutes.has(track.id) ? mutes.delete(track.id) : mutes.add(track.id); mute.setAttribute('aria-pressed', String(mutes.has(track.id))); await syncAudition(); });
    const edit = document.createElement('button'); edit.textContent = 'Piano roll'; edit.onclick = () => { piano.select(track.id); view('piano'); };
    const controls = document.createElement('div'); controls.className = 'track-controls';
    const info = document.createElement('span'); info.textContent = [track.instrument, ...track.inserts].join(' → '); controls.append(info);
    if (track.editable) {
      const label = document.createElement('label'); label.textContent = 'Gain';
      const level = document.createElement('input'); level.type = 'range'; level.min = -120; level.max = 12; level.step = 1; level.value = track.gain; level.setAttribute('aria-label', `${track.id} gain`);
      const output = document.createElement('output'); output.textContent = `${track.gain} dB`;
      level.oninput = () => { output.textContent = `${level.value} dB`; };
      level.onchange = () => studioEdit(track.id, { gain: Number(level.value) }).catch(fail); label.append(level, output); controls.append(label);
      const preset = document.createElement('select'); preset.setAttribute('aria-label', `${track.id} native preset`); preset.add(new Option('Native preset…', ''));
      for (const value of ['glass-lead', 'pulse-bass', 'bell']) preset.add(new Option(value, value));
      for (const path of Object.keys(project.assets).filter(p => /\.(wav|flac)$/i.test(p))) preset.add(new Option(`Sample: ${path}`, 'sample:' + path));
      preset.add(new Option('Other native preset…', 'custom'));
      preset.onchange = () => {
        let value = preset.value; if (!value) return;
        if (value === 'custom') { value = prompt('Native synth preset name (see std/catalogs)', 'glass-lead'); if (!value) return; }
        studioEdit(track.id, value.startsWith('sample:') ? { sample: value.slice(7) } : { sample: '', preset: value }).catch(fail);
      }; controls.append(preset);
    }
    const canvas = document.createElement('canvas'); canvas.setAttribute('aria-label', `Score for ${track.id}`); canvas.setAttribute('role', 'img');
    canvas.onpointerdown = event => { if (event.button !== 0) return; event.preventDefault(); canvas.setPointerCapture(event.pointerId); canvas.dataset.scrub = '1'; scrubbing = true; };
    canvas.onpointermove = event => { if (canvas.dataset.scrub) { const r = canvas.getBoundingClientRect(); $('position').textContent = time(clampFrame((event.clientX - r.left) / r.width * compiled.frames, compiled.frames), compiled.rate); } };
    canvas.onpointerup = event => { if (!canvas.dataset.scrub) return; delete canvas.dataset.scrub; scrubbing = false; canvas.releasePointerCapture(event.pointerId); const r = canvas.getBoundingClientRect(); requestSeek((event.clientX - r.left) / r.width * compiled.frames); };
    canvas.onpointercancel = () => { delete canvas.dataset.scrub; scrubbing = false; positionUI(); };
    const marker = document.createElement('div'); marker.className = 'playhead'; marker.setAttribute('aria-hidden', 'true');
    head.append(name, count, mute, solo, edit); section.append(head, controls, canvas, marker); $('tracks').append(section); markers.push({ marker, canvas, width: 0 });
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
  });
  for (const item of markers) { item.width = item.canvas.clientWidth; item.marker.style.left = `${item.canvas.offsetLeft}px`; item.marker.style.top = `${item.canvas.offsetTop}px`; item.marker.style.height = `${item.canvas.clientHeight}px`; item.marker.style.bottom = 'auto'; }
  positionUI();
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
function fail(e) {
  message(e.message, true);
  if (e.diagnostic && (e.sourceRevision === undefined || e.sourceRevision === revision)) codeEditor.showDiagnostic(e.diagnostic);
  if (playing && compiled && engine && !engine.dead) { status('Operation rejected · accepted revision still playing'); return; }
  playing = false; player?.port.postMessage({ type: 'pause' }); $('play').textContent = '▶ Play'; status('Stopped · source preserved');
}
async function action(fn, rethrow = false) {
  if (busy) return; busy = true; $('cancel').hidden = false;
  let failed = false;
  try { return await fn(); } catch (e) { failed = true; fail(e); if (rethrow) throw e; } finally { busy = false; abortOperation = undefined; $('cancel').hidden = true; historyUI(); if (!failed) scheduleLive(); }
}
async function openLink(input) {
  const rpc = getData(); abortOperation = () => rpc.close(); message('Resolving project link…'); status('Loading');
  if (/^(?:https:\/\/gist\.github\.com\/[^/]+\/)?[a-f\d]{32,40}(?:\/|$)/i.test(input.trim())) {
    await install(await rpc.call('gist', input, 35000));
  } else { const result = await rpc.call('resolve', input, 35000); await install(result.project, result.fragment); message(`Loaded ${project.entry}${result.sources.length ? '\n' + result.sources.join('\n') : ' from embedded data'}.`); }
}
$('editor').addEventListener('input', () => { checkpoint(true); project.files[selected] = $('editor').value; lines(); edited(); });
$('editor').addEventListener('scroll', () => { $('line-numbers').scrollTop = $('editor').scrollTop; });
$('editor').addEventListener('keydown', e => { if (e.key === 'Tab' && !e.shiftKey && !$('editor').readOnly) { e.preventDefault(); const field = $('editor'); field.setRangeText('  ', field.selectionStart, field.selectionEnd, 'end'); field.dispatchEvent(new Event('input')); } });
$('project-title').oninput = () => { checkpoint(true); project.title = $('project-title').value; if (project.studio) project.files[project.studio.generated] = studioSource(project.studio, project.title); edited(); };
$('file').onchange = () => { selected = $('file').value; filesUI(); };
$('entry').onchange = () => { checkpoint(); project.entry = $('entry').value; if (project.studio && project.entry !== project.studio.generated) delete project.studio; filesUI(); edited(); };
$('add-file').onclick = () => { const input = prompt('Project-relative source path', 'module.muz'); if (!input) return; try { const path = projectPath(input); if (!/\.(muz|md)$/.test(path) || path in project.files || path in project.assets) throw Error('Choose a new .muz or .md path.'); checkpoint(); project.files[path] = ''; selected = path; filesUI(); edited(); } catch (e) { fail(e); } };
$('remove-file').onclick = () => { if (selected === project.entry || selected === project.studio?.baseEntry || Object.values(project.studio?.tracks || {}).some(t => t.sample === selected)) return message('Choose a different entry or detach Studio before removing this referenced file.'); if (!confirm(`Remove ${selected} from this project?`)) return; checkpoint(); delete project.files[selected]; delete project.assets[selected]; selected = project.entry; filesUI(); edited(); };
$('compile').onclick = () => action(compile); $('play').onclick = () => playing ? play().catch(fail) : action(play); $('stop').onclick = () => stop().catch(fail);
$('volume').oninput = () => { if (gain) gain.gain.setTargetAtTime(Number($('volume').value) / 100, audio.currentTime, .02); };
$('open-link').onclick = () => $('link-dialog').showModal();
$('open-workbench').onclick = () => action(async () => {
  const value = snapshot(); toWorkbench(value); // Fail before opening a target that cannot retain these assets.
  const fragment = await writeHandoff(value);
  const url = new URL('../workbench/', base); url.hash = fragment;
  await saveDraft(); location.assign(url.href);
});
$('link-form').onsubmit = e => { e.preventDefault(); const input = $('link-input').value; $('link-dialog').close(); action(() => openLink(input)); };
$('open-files').onclick = () => $('file-input').click(); $('open-folder').onclick = () => $('folder-input').click();
for (const id of ['file-input', 'folder-input']) $(id).onchange = () => action(async () => { const value = await importFiles($(id).files); $(id).value = ''; await install(value); });
$('share').onclick = () => $('share-dialog').showModal();
$('share-embedded').onclick = () => share('embedded'); $('share-source').onclick = () => share('source'); $('share-super').onclick = () => share('super');
$('save-project').onclick = () => download(JSON.stringify(normalizeProject(project), null, 2), filename('.muzproject.json'), 'application/json');
for (const [id, kind] of [['export-midi', 'midi'], ['export-wav', 'wav'], ['export-stems', 'stems'], ['export-daw', 'daw']]) $(id).onclick = () => action(() => exportBundle(kind));
$('seek').onpointerdown = () => { scrubbing = true; };
$('seek').oninput = () => { scrubbing = true; $('position').textContent = time(Number($('seek').value), compiled?.rate); };
$('seek').onchange = () => { const target = Number($('seek').value); scrubbing = false; requestSeek(target); };
$('seek').onpointercancel = () => { scrubbing = false; positionUI(); };
$('seek').onpointerup = () => { scrubbing = false; };
$('seek').onkeydown = event => {
  if (!compiled || !['ArrowLeft', 'ArrowRight', 'Home', 'End'].includes(event.key)) return;
  event.preventDefault(); scrubbing = false;
  requestSeek(event.key === 'Home' ? 0 : event.key === 'End' ? totalFrames() : shownFrame + (event.key === 'ArrowLeft' ? -1 : 1) * compiled.rate * (event.shiftKey ? 10 : 1));
};
$('loop-enabled').onchange = loopUI;
$('loop-in').onclick = () => { if (!compiled) return; loopStart = Math.min(shownFrame, compiled.frames - 1); loopUI(); };
$('loop-out').onclick = () => { if (!compiled) return; loopEnd = Math.min(compiled.frames, Math.max(shownFrame, loopStart + 1)); loopUI(); };
$('section').onchange = () => { if ($('section').value !== '') requestSeek(Number($('section').value)); };
$('live').onchange = scheduleLive;
for (const name of ['arrangement', 'piano', 'inspect']) $('view-' + name).onclick = () => view(name);
$('inspect-view').onchange = () => { inspectionOffset = 0; inspect().catch(fail); };
$('inspect-refresh').onclick = () => inspect().catch(fail);
$('inspect-prev').onclick = () => { inspectionOffset = Math.max(0, inspectionOffset - 50); inspect().catch(fail); };
$('inspect-next').onclick = () => { if (inspectionNext != null) { inspectionOffset = inspectionNext; inspect().catch(fail); } };
for (const id of ['undo', 'redo']) {
  // Arrays are replaced on project load, so resolve history at click time.
  $(id).onclick = () => {
    const source = id === 'undo' ? undo : redo, target = id === 'undo' ? redo : undo;
    if (!source.length) return; target.push(snapshot()); project = normalizeProject(source.pop()); lastCheckpoint = 0;
    if (!(selected in project.files) && !(selected in project.assets)) selected = project.entry;
    filesUI(); edited(); historyUI();
  };
}
function revisionUI() {
  $('revisions').replaceChildren(new Option('Accepted revisions', ''), ...[...revisions].reverse().map(r => new Option(`r${r.id} · ${r.time} · ${r.project.title}`, String(r.id))));
  $('restore-revision').disabled = true;
}
$('revisions').onchange = () => { $('restore-revision').disabled = !$('revisions').value; };
$('restore-revision').onclick = () => {
  const saved = revisions.find(r => r.id === Number($('revisions').value)); if (!saved) return;
  checkpoint(); project = normalizeProject(saved.project); selected = project.entry; filesUI(); edited(); message(`Restored source r${saved.id}. Compile applies it; the accepted audio remains available.`);
};
$('studio-source').onclick = () => { if (!project.studio) return message('Visual edits create a native .muz wrapper while preserving your original files.'); selected = project.studio.generated; filesUI(); };
$('edit-tempo').onclick = () => {
  if (!compiled) return message('Compile a project first.');
  if (compiled.tempos.length > 1) return message('This project owns a tempo map. Edit its native source to change that map.');
  const input = prompt('Tempo in BPM (20…400)', String(compiled.bpm)); if (input === null) return;
  studioEdit(null, { tempo: Number(input) }).catch(fail);
};
$('detach-studio').onclick = () => { checkpoint(); delete project.studio; filesUI(); edited(); };
$('format-source').onclick = () => action(async () => {
  if ($('editor').readOnly) throw Error('Select an editable source file first.');
  const text = project.files[selected], path = selected;
  const result = await getEngine().call('format', { source: text });
  if (project.files[path] !== text) throw Error('Source changed during formatting; try again.');
  checkpoint(); project.files[path] = result.source; filesUI(); edited(); message(result.changed ? 'Source formatted by muz.' : 'Source already formatted.');
});
$('catalog').onclick = () => action(openCatalog);
$('catalog-pack').onchange = () => { if ($('catalog-pack').value !== '') selectCatalog(catalogPacks[Number($('catalog-pack').value)]); };
$('catalog-form').onsubmit = event => {
  event.preventDefault(); action(async () => {
    catalogAbort = new AbortController(); abortOperation = () => catalogAbort.abort(); $('catalog-status').textContent = 'Reading catalog…';
    try { selectCatalog(await loadCatalog($('catalog-url').value, catalogAbort.signal)); } finally { catalogAbort = undefined; }
  });
};
$('catalog-search').oninput = drawCatalog;
$('catalog-select').onclick = () => { for (const row of catalogRows()) if (catalogSelection.size < 500) catalogSelection.add(row.path); drawCatalog(); };
$('catalog-clear').onclick = () => { catalogSelection.clear(); drawCatalog(); };
$('catalog-import').onclick = () => action(async () => {
  if (!catalogValue) throw Error('Open a catalog first.');
  const rev = revision, original = snapshot(); catalogAbort = new AbortController(); abortOperation = () => catalogAbort.abort(); $('catalog-cancel').hidden = false;
  try {
    const candidate = await importCatalog(original, catalogValue.files.filter(file => catalogSelection.has(file.path)), { signal: catalogAbort.signal, progress: p => { $('catalog-status').textContent = `Importing selected resources · ${Math.floor(p * 100)}%`; } });
    if (revision !== rev) throw Error('Project changed during download. Downloaded resources were not applied.');
    checkpoint(); project = candidate; filesUI(); edited(); $('catalog-status').textContent = 'Resources verified and added to the project. Saved projects include their exact bytes.';
  } finally { catalogAbort = undefined; $('catalog-cancel').hidden = true; }
});
$('catalog-cancel').onclick = () => catalogAbort?.abort();
$('catalog-dialog').addEventListener('close', () => catalogAbort?.abort());
$('download-module').onclick = () => { const module = library?.[Number($('library').value)]; if (module) download(module.source, module.name.split('/').pop(), 'text/plain'); };
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
  if (link?.startsWith('#handoff:')) {
    await action(async () => { await install(await readHandoff(link)); const url = new URL(location.href); url.hash = ''; history.replaceState(null, '', url); });
  } else if (link) await action(() => openLink(link));
  else { message(draft ? 'Local draft restored.' : 'Ready. Edit the bundled muz template, or open a project.'); status('Local workspace'); }
} catch (e) { fail(e); }
"""

let render() = file
