module Muz.Source.Src.StudioViewJs

let file = """import { frameToBeat, pitchName, snapBeat } from './timeline.js';
const $ = id => document.getElementById(id), row = 12, gutter = 42;
export class StudioView {
  constructor({ apply, addTrack, seek, report }) {
    this.apply = apply; this.report = report; this.seek = seek; this.notes = []; this.selected = -1;
    this.canvas = $('piano-roll'); this.scroll = $('piano-scroll'); this.zoom = 44;
    $('piano-track').onchange = () => this.loadTrack(true);
    $('zoom').oninput = () => { this.zoom = Number($('zoom').value); this.draw(); };
    this.scroll.onscroll = () => this.draw();
    this.observer = new ResizeObserver(() => this.draw()); this.observer.observe(this.scroll);
    this.canvas.onpointerdown = event => this.pointerDown(event);
    this.canvas.onpointermove = event => this.pointerMove(event);
    this.canvas.onpointerup = event => this.pointerUp(event);
    this.canvas.onpointercancel = () => { if (this.drag) { this.notes = this.drag.before; this.drag = undefined; this.draw(); } };
    this.canvas.ondblclick = event => {
      if (!this.editable) return;
      const point = this.point(event);
      this.notes.push({ beat: snapBeat(point.beat, this.grid), length: this.grid || 1, pitch: point.pitch, velocity: .72 });
      this.selected = this.notes.length - 1; this.changed();
    };
    this.canvas.oncontextmenu = event => { event.preventDefault(); if (this.editable) { this.selected = this.hit(this.point(event)); this.remove(); } };
    this.canvas.onkeydown = event => {
      if (event.key === 'Delete' || event.key === 'Backspace') { event.preventDefault(); this.remove(); }
      if (event.key === 'Escape') { this.selected = -1; this.draw(); this.fields(); }
      if (this.editable && this.notes[this.selected] && ['ArrowLeft', 'ArrowRight', 'ArrowUp', 'ArrowDown'].includes(event.key)) {
        event.preventDefault(); const note = this.notes[this.selected];
        if (event.key === 'ArrowLeft') note.beat = Math.max(0, note.beat - (this.grid || .25));
        if (event.key === 'ArrowRight') note.beat += this.grid || .25;
        if (event.key === 'ArrowUp') note.pitch = Math.min(127, note.pitch + 1);
        if (event.key === 'ArrowDown') note.pitch = Math.max(0, note.pitch - 1);
        this.changed();
      }
    };
    $('note-form').onsubmit = event => {
      event.preventDefault(); if (!this.editable || !this.notes[this.selected]) return;
      this.notes[this.selected] = { beat: Number($('note-beat').value), length: Number($('note-length').value), pitch: Number($('note-pitch').value), velocity: Number($('note-velocity').value) }; this.changed();
    };
    $('delete-note').onclick = () => this.remove();
    $('revert-notes').onclick = () => this.loadTrack(true);
    $('quantize-notes').onclick = () => { if (!this.editable || !this.grid) return; this.notes = this.notes.map(n => ({ ...n, beat: snapBeat(n.beat, this.grid), length: Math.max(this.grid, snapBeat(n.length, this.grid)) })); this.changed(); };
    $('delete-track').onclick = () => { if (this.editable && confirm(`Remove ${this.track.id} in the Studio wrapper? Original source stays intact.`)) this.apply(this.track.id, { removed: true }).catch(e => this.report(e.message)); };
    $('apply-notes').onclick = async () => {
      if (!this.editable || !this.track) return;
      try { await this.apply(this.track.id, { notes: this.notes }); this.loadTrack(true); } catch (e) { this.report(e.message); }
    };
    $('add-track').onclick = addTrack;
  }
  get grid() { return Number($('grid').value); }
  update(score) {
    const previous = $('piano-track').value; this.score = score;
    $('piano-track').replaceChildren(...score.tracks.map(track => new Option(track.name || track.id, track.id)));
    if (score.tracks.some(t => t.id === previous)) $('piano-track').value = previous;
    this.loadTrack(!this.dirty);
  }
  select(id) { $('piano-track').value = id; this.loadTrack(true); }
  loadTrack(force) {
    const track = this.score?.tracks.find(t => t.id === $('piano-track').value);
    if (!track) { this.notes = []; this.track = undefined; this.editable = false; this.selected = -1; this.dirty = false; this.fields(); this.draw(); return; }
    if (force || this.track?.id !== track.id) {
      this.notes = track.notes.map(n => ({ beat: n.beat, length: n.length, pitch: n.pitch, velocity: n.velocity }));
      this.selected = -1; this.dirty = false;
      const pitch = this.notes.length ? this.notes[0].pitch : 60;
      this.centerPitch = pitch;
    }
    this.track = track; this.editable = track.editable;
    $('apply-notes').disabled = !this.editable; $('delete-note').disabled = !this.editable;
    $('quantize-notes').disabled = !this.editable; $('delete-track').disabled = !this.editable;
    $('piano-info').textContent = `${this.notes.length} notes${this.editable ? this.dirty ? ' · unapplied edits' : '' : ' · source-edited MIDI / kit'}`;
    this.fields(); this.draw();
  }
  changed() { this.dirty = true; $('piano-info').textContent = `${this.notes.length} notes · unapplied edits`; this.fields(); this.draw(); }
  fields() {
    const n = this.notes[this.selected];
    for (const key of ['beat', 'length', 'pitch', 'velocity']) { const input = $('note-' + key); input.value = n ? Math.round(n[key] * 10000) / 10000 : ''; input.disabled = !n || !this.editable; }
  }
  point(event) {
    const rect = this.canvas.getBoundingClientRect();
    return { beat: Math.max(0, (event.clientX - rect.left - gutter + this.scroll.scrollLeft) / this.zoom), pitch: Math.max(0, Math.min(127, 127 - Math.floor((event.clientY - rect.top) / row))) };
  }
  hit(point) { return this.notes.findLastIndex(n => n.pitch === point.pitch && point.beat >= n.beat && point.beat <= n.beat + n.length); }
  pointerDown(event) {
    if (!this.score || event.button !== 0) return;
    this.canvas.focus(); const point = this.point(event); this.selected = this.hit(point); this.fields(); this.draw();
    if (this.selected < 0) { if (event.altKey) this.seek(point.beat); return; }
    if (!this.editable) return;
    const note = this.notes[this.selected];
    this.drag = { start: point, note: { ...note }, before: this.notes.map(n => ({ ...n })), resize: (note.beat + note.length - point.beat) * this.zoom <= 8 };
    this.canvas.setPointerCapture(event.pointerId);
  }
  pointerMove(event) {
    if (!this.drag) return; const p = this.point(event), d = this.drag, note = this.notes[this.selected];
    if (d.resize) note.length = Math.max(this.grid || .01, snapBeat(d.note.length + p.beat - d.start.beat, this.grid));
    else { note.beat = snapBeat(d.note.beat + p.beat - d.start.beat, this.grid); note.pitch = Math.max(0, Math.min(127, d.note.pitch + p.pitch - d.start.pitch)); }
    this.draw(); this.fields();
  }
  pointerUp(event) { if (!this.drag) return; this.drag = undefined; this.canvas.releasePointerCapture(event.pointerId); this.changed(); }
  remove() { if (!this.editable || this.selected < 0) return; this.notes.splice(this.selected, 1); this.selected = -1; this.changed(); }
  position(frame) { this.frame = frame; if (!$('piano-panel').hidden) this.draw(); }
  draw() {
    if ($('piano-panel').hidden) return;
    if (this.centerPitch !== undefined) { const pitch = this.centerPitch; this.centerPitch = undefined; this.scroll.scrollTop = Math.max(0, (127 - pitch) * row - this.scroll.clientHeight / 2); }
    const width = Math.max(100, this.scroll.clientWidth), height = 128 * row, dpr = window.devicePixelRatio || 1;
    const end = Math.max(this.score?.beats || 4, ...this.notes.map(n => n.beat + n.length), 4) + 4;
    $('piano-space').style.width = `${Math.min(10000000, Math.max(width, end * this.zoom + gutter))}px`;
    this.canvas.style.width = `${width}px`; this.canvas.width = width * dpr; this.canvas.height = height * dpr;
    const ctx = this.canvas.getContext('2d'); ctx.scale(dpr, dpr); const offset = this.scroll.scrollLeft;
    ctx.font = '10px monospace';
    for (let pitch = 0; pitch < 128; pitch++) {
      const y = (127 - pitch) * row; ctx.fillStyle = [1, 3, 6, 8, 10].includes(pitch % 12) ? '#10171e' : '#18212a'; ctx.fillRect(0, y, width, row);
      ctx.strokeStyle = '#27333e'; ctx.beginPath(); ctx.moveTo(0, y); ctx.lineTo(width, y); ctx.stroke();
    }
    const start = Math.max(0, Math.floor(offset / this.zoom)), stop = Math.ceil((offset + width) / this.zoom), beatsPerBar = this.score ? this.score.meter[0] * 4 / this.score.meter[1] : 4;
    for (let beat = start; beat <= stop; beat++) {
      const x = gutter + beat * this.zoom - offset; ctx.strokeStyle = beat % beatsPerBar === 0 ? '#4a5c69' : '#293641'; ctx.beginPath(); ctx.moveTo(x, 0); ctx.lineTo(x, height); ctx.stroke();
    }
    this.notes.forEach((note, index) => {
      const x = gutter + note.beat * this.zoom - offset, w = Math.max(3, note.length * this.zoom - 1), y = (127 - note.pitch) * row + 1;
      if (x + w < gutter || x > width) return;
      ctx.fillStyle = index === this.selected ? '#ecce96' : `rgba(137,214,180,${.35 + note.velocity * .65})`; ctx.fillRect(x, y, w, row - 2);
      ctx.fillStyle = '#244a3b'; ctx.fillRect(x + w - 3, y, 2, row - 2);
    });
    if (this.score && this.frame !== undefined) { const x = gutter + frameToBeat(this.frame, this.score) * this.zoom - offset; ctx.strokeStyle = '#fff'; ctx.beginPath(); ctx.moveTo(x, 0); ctx.lineTo(x, height); ctx.stroke(); }
    ctx.fillStyle = '#1c2932'; ctx.fillRect(0, 0, gutter, height); ctx.fillStyle = '#a8b9c4';
    for (let p = 0; p < 128; p++) if (p % 12 === 0 || p === this.notes[this.selected]?.pitch) ctx.fillText(pitchName(p), 5, (127 - p) * row + 10);
  }
}
"""

let render() = file
