module Muz.Source.Src.DawprojectJs

let file = """import { zipArchive } from './zip.js';
const esc = text => String(text).replaceAll('&', '&amp;').replaceAll('<', '&lt;').replaceAll('>', '&gt;').replaceAll('"', '&quot;').replace(/[\x00-\x08\x0b\x0c\x0e-\x1f]/g, '');
const n = value => { if (!Number.isFinite(value)) throw Error('Invalid DAWProject timeline value.'); return String(Math.round(value * 1e9) / 1e9); };
export function dawprojectDocuments(score, project) {
  const duration = (score.frames + Math.round((score.tail || 0) * score.rate)) / score.rate;
  const warning = 'Native instruments, effects, routing and automation are preserved in the rendered master, not represented as DAW plug-ins. Editable note tracks are muted; assign instruments and unmute them when replacing the reference mix.';
  let xml = `<?xml version="1.0" encoding="UTF-8"?><Project version="1.0"><Application name="muzstatic" version="1.0"/><Transport><Tempo id="tempo" unit="bpm" value="${n(score.tempos?.[0]?.bpm || score.bpm)}"/><TimeSignature id="meter" numerator="${score.meter[0]}" denominator="${score.meter[1]}"/></Transport><Structure>`;
  xml += '<Track id="reference" name="Rendered master" contentType="audio"><Channel id="reference-channel" role="regular" destination="master-channel" audioChannels="2"/></Track>';
  score.tracks.forEach((track, i) => { xml += `<Track id="t${i}" name="${esc(track.name || track.id)}" contentType="notes"><Channel id="c${i}" role="regular" destination="master-channel" audioChannels="2"><Mute id="mute-${i}" value="true"/></Channel></Track>`; });
  xml += '<Track id="master" name="Master" contentType="audio"><Channel id="master-channel" role="master" audioChannels="2"/></Track></Structure><Arrangement id="arrangement"><Lanes id="arrangement-lanes" timeUnit="beats">';
  xml += `<Lanes id="reference-lane" track="reference" timeUnit="seconds"><Clips id="reference-clips"><Clip time="0" duration="${n(duration)}" playStart="0" contentTimeUnit="seconds"><Audio id="reference-audio" timeUnit="seconds" duration="${n(duration)}" sampleRate="${score.rate}" channels="2"><File path="audio/master.wav"/></Audio></Clip></Clips></Lanes>`;
  score.tracks.forEach((track, i) => {
    const end = Math.max(score.beats, ...track.notes.map(note => note.beat + note.length), 1);
    xml += `<Lanes id="lane-${i}" track="t${i}"><Clips id="clips-${i}"><Clip time="0" duration="${n(end)}" playStart="0"><Notes id="notes-${i}" timeUnit="beats">`;
    for (const note of track.notes) xml += `<Note time="${n(note.beat)}" duration="${n(note.length)}" channel="0" key="${note.pitch}" vel="${n(note.velocity)}"/>`;
    xml += '</Notes></Clip></Clips></Lanes>';
  });
  xml += '</Lanes>';
  if (score.sections?.length) xml += `<Markers id="sections" timeUnit="beats">${score.sections.map(s => `<Marker time="${n(s.start)}" name="${esc(s.name)}"/>`).join('')}</Markers>`;
  if (score.tempos?.length > 1) xml += `<TempoAutomation id="tempo-map" timeUnit="beats" unit="bpm"><Target parameter="tempo"/>${score.tempos.map(t => `<RealPoint time="${n(t.beat)}" value="${n(t.bpm)}" interpolation="hold"/>`).join('')}</TempoAutomation>`;
  xml += '</Arrangement></Project>';
  const report = { format: 'muzstatic/dawproject/1', title: project.title, duration, sampleRate: score.rate, tracks: score.tracks.length, requiredPlugins: [], audio: 'audio/master.wav', notes: 'Performed MIDI-key notes, quarter-note beats; per-note expression/controllers remain in song.mid and native source.', warning, automation: score.automation || [], engineRevision: score.revision };
  return [
    ['project.xml', xml], ['metadata.xml', `<?xml version="1.0" encoding="UTF-8"?><MetaData><Title>${esc(project.title)}</Title><Comment>${esc(warning)}</Comment></MetaData>`],
    ['muzstatic/report.json', JSON.stringify(report, null, 2)], ['muzstatic/project.muzproject.json', JSON.stringify(project)],
  ];
}
export function exportDawproject(score, project, master, midi) {
  return zipArchive([...dawprojectDocuments(score, project), ['audio/master.wav', master], ['muzstatic/song.mid', midi]]);
}
"""

let render() = file
