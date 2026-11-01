module Muz.Source.Src.TimelineJs

let file = """// UI coordinates use the engine's performed tempo map, never a guessed BPM.
export function clampFrame(frame, duration) {
  return Math.round(Math.max(0, Math.min(Number.isFinite(frame) ? frame : 0, duration)));
}
export function beatToFrame(beat, score) {
  const points = score.tempos || [{ beat: 0, frame: 0, bpm: score.bpm }];
  const point = points.findLast(p => p.beat <= beat) || points[0];
  return point.frame + (beat - point.beat) * score.rate * 60 / point.bpm;
}
export function frameToBeat(frame, score) {
  const points = score.tempos || [{ beat: 0, frame: 0, bpm: score.bpm }];
  const point = points.findLast(p => p.frame <= frame) || points[0];
  return point.beat + (frame - point.frame) * point.bpm / (score.rate * 60);
}
export function snapBeat(beat, grid) { return Math.max(0, grid > 0 ? Math.round(beat / grid) * grid : beat); }
export function pitchName(pitch) { return ['C', 'C♯', 'D', 'D♯', 'E', 'F', 'F♯', 'G', 'G♯', 'A', 'A♯', 'B'][pitch % 12] + (Math.floor(pitch / 12) - 1); }
export function audibleTracks(tracks, solos, mutes) { return tracks.filter(t => !mutes.has(t.id) && (!solos.size || solos.has(t.id))).map(t => t.id); }
"""

let render() = file
