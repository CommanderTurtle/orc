module Muz.Source.Engine.Src.LibRs

let file = """//! Consumer-owned portable host. The muz engine and language remain unmodified.
use anyhow::{Result, bail, ensure};
use base64::{Engine as _, engine::general_purpose::STANDARD};
use muz::{
    audio::{AudioConfig, AudioEngine},
    host::HostContext,
    lang::SourceLoader,
};
use serde::Deserialize;
use serde_json::{Value, json};
use std::{
    cell::RefCell,
    collections::BTreeMap,
    path::{Component, Path, PathBuf},
    rc::Rc,
    sync::Arc,
};

const MAX_REQUEST: usize = 96 * 1024 * 1024;
#[derive(Deserialize)]
struct Project {
    entry: String,
    files: BTreeMap<String, String>,
    #[serde(default)]
    assets: BTreeMap<String, String>,
}
struct Sources(BTreeMap<PathBuf, String>);
fn mounted(path: &Path) -> Result<PathBuf> {
    let mut parts = Vec::new();
    for part in path.components() {
        match part {
            Component::RootDir | Component::CurDir => {}
            Component::ParentDir => {
                ensure!(parts.len() > 1, "path escapes project: {}", path.display());
                parts.pop();
            }
            Component::Normal(p) => parts.push(p.to_owned()),
            _ => bail!("invalid project path: {}", path.display()),
        }
    }
    ensure!(
        parts.first().is_some_and(|p| p == "project"),
        "path outside project mount"
    );
    let mut result = PathBuf::from("/");
    for part in parts {
        result.push(part);
    }
    Ok(result)
}
impl SourceLoader for Sources {
    fn resolve(&self, p: &Path) -> Result<PathBuf> {
        let p = mounted(p)?;
        ensure!(
            self.0.contains_key(&p),
            "missing module {} (import the project folder or bundle)",
            p.display()
        );
        Ok(p)
    }
    fn read(&self, p: &Path) -> Result<String> {
        Ok(self.0.get(&self.resolve(p)?).unwrap().clone())
    }
    fn contrib_root(&self) -> Result<PathBuf> {
        Ok(PathBuf::from("/project/contrib"))
    }
    fn contrib_modules(&self) -> Vec<String> {
        self.0
            .keys()
            .filter_map(|p| p.strip_prefix("/project/").ok())
            .map(|p| p.to_string_lossy().trim_end_matches(".muz").to_owned())
            .filter(|s| s.starts_with("contrib/"))
            .collect()
    }
}
// MemoryAssets owns immutable bytes; this wrapper applies the same normalization as sources.
struct Assets(muz::assets::MemoryAssets);
impl muz::assets::AssetResolver for Assets {
    fn resolve(&self, p: &Path) -> Result<PathBuf> {
        self.0.resolve(&mounted(p)?)
    }
    fn resolve_case_insensitive(&self, p: &Path) -> Result<PathBuf> {
        self.0.resolve_case_insensitive(&mounted(p)?)
    }
    fn version(&self, p: &Path) -> Result<(u64, u128)> {
        self.0.version(&mounted(p)?)
    }
    fn open(&self, p: &Path) -> Result<Box<dyn muz::assets::AssetReader>> {
        self.0.open(&mounted(p)?)
    }
}
#[derive(Default)]
struct Host {
    response: Vec<u8>,
    blob: Vec<u8>,
    pcm: Vec<f32>,
    context: Option<HostContext>,
    compiled: Option<muz::compile::Compiled>,
    engine: Option<AudioEngine>,
    rate: u32,
}
thread_local! { static HOST: RefCell<Host> = RefCell::new(Host::default()); }

fn project_context(v: &Value) -> Result<(PathBuf, Rc<Sources>, HostContext)> {
    let project: Project = serde_json::from_value(v["project"].clone())?;
    ensure!(
        !project.files.is_empty() && project.files.len() <= 500,
        "project must have 1..500 source files"
    );
    ensure!(
        project.files.values().map(String::len).sum::<usize>() <= 4 * 1024 * 1024,
        "source exceeds 4 MiB"
    );
    let files = project
        .files
        .into_iter()
        .map(|(p, s)| Ok((mounted(&Path::new("/project").join(p))?, s)))
        .collect::<Result<BTreeMap<_, _>>>()?;
    let mut assets = muz::assets::MemoryAssets::default();
    let mut size = 0;
    ensure!(project.assets.len() <= 500, "project exceeds 500 assets");
    for (p, b64) in project.assets {
        let bytes = STANDARD.decode(b64)?;
        size += bytes.len();
        ensure!(size <= 64 * 1024 * 1024, "assets exceed 64 MiB");
        assets.insert(
            mounted(&Path::new("/project").join(p))?,
            Arc::from(bytes),
            1,
        );
    }
    let context = HostContext {
        assets: Arc::new(Assets(assets)),
        provenance: v["provenance"].as_bool().unwrap_or(false),
        ..HostContext::default()
    };
    Ok((
        mounted(&Path::new("/project").join(project.entry))?,
        Rc::new(Sources(files)),
        context,
    ))
}

impl Host {
    fn command(&mut self, v: Value) -> Result<Value> {
        match v["command"].as_str().unwrap_or("") {
            "compile" | "check" => {
                // Failed candidates cannot leave stale inspection/playback state behind.
                self.compiled = None;
                self.engine = None;
                self.context = None;
                let (entry, sources, context) = project_context(&v)?;
                let compiled = muz::compile::compile_with_context(&entry, sources, &context)?;
                let rate = v["rate"].as_u64().unwrap_or(48000) as u32;
                ensure!((8000..=192000).contains(&rate), "invalid sample rate");
                let engine = context.run(|| {
                    AudioEngine::new(
                        &compiled.session,
                        AudioConfig {
                            sample_rate: rate as f32,
                            max_frames: 1024,
                            offline: v["offline"].as_bool().unwrap_or(false),
                        },
                    )
                })?;
                let status = engine.status();
                let timeline = muz::audio::transport::TempoTimeline::compile(
                    rate as f64,
                    &compiled.session.transport,
                    &compiled.session.tracks,
                )
                .map_err(anyhow::Error::msg)?;
                // Inspect performed notes after kit expansion, on the engine's tempo timeline.
                let compact = v["command"] == "check" || v["compact"].as_bool().unwrap_or(false);
                let tracks: Vec<_> = compiled.session.tracks.iter().map(|track| {
                    let note = |at: u64, dur: u64, pitch: u8, velocity: f64| {
                        let start = timeline.tick_to_project_frame(at as f64);
                        json!({"at": start, "dur": timeline.tick_to_project_frame((at + dur) as f64) - start, "pitch": pitch, "velocity": velocity})
                    };
                    if compact { return json!({"id":track.id.as_str(), "name":track.name}); }
                    let notes: Vec<_> = match &track.source {
                        muz::model::TrackSource::Pattern(p) => p.notes.iter().map(|n| note(n.start_ticks, n.duration_ticks, n.key, n.velocity as f64)).collect(),
                        muz::model::TrackSource::Midi(p) => p.imported.notes.iter().filter(|n| p.all_channels || n.channel == p.channel).map(|n| note(n.start_tick, n.duration_ticks, n.key, n.attack_velocity as f64 / 127.0)).collect()
                    };
                    json!({"id": track.id.as_str(), "name": track.name, "notes": notes})
                }).collect();
                let beats = compiled
                    .score
                    .iter()
                    .map(|s| muz::music::real(s.pattern.span))
                    .fold(0.0, f64::max);
                let score_tracks: Vec<_> = compiled.score.iter().map(|t| json!({"id":t.id,"policy":t.policy,"span":t.pattern.span,"notes":t.pattern.notes.len()})).collect();
                let performed_tracks: Vec<_> = compiled.session.tracks.iter().map(|t| match &t.source {
                    muz::model::TrackSource::Pattern(p) => { let end = p.notes.iter().map(|n|n.start_ticks+n.duration_ticks).max().unwrap_or(0); json!({"id":t.id,"ppq":muz::model::TICKS_PER_BEAT,"end":[end,muz::model::TICKS_PER_BEAT],"endBeat":end as f64 / muz::model::TICKS_PER_BEAT as f64}) },
                    muz::model::TrackSource::Midi(m) => json!({"id":t.id,"ppq":m.imported.summary.ppq,"end":[m.imported.summary.end_tick,m.imported.summary.ppq],"endBeat":m.imported.summary.end_tick as f64 / m.imported.summary.ppq as f64})
                }).collect();
                let response = json!({"title": compiled.session.extras.title, "bpm": status.transport.bpm, "meter": compiled.session.transport.meter(), "beats": beats, "endTick": status.end_tick, "frames": status.end_project_frame.ceil() as u64, "rate":rate, "tail": compiled.session.extras.tail, "tracks": tracks, "scoreTracks":score_tracks,"performedTracks":performed_tracks,"sections":compiled.session.extras.sections,"transport":compiled.session.transport,"scorePpq":muz::compile::PPQ,"diagnostics": compiled.diagnostics, "locations": compiled.locations});
                self.rate = rate;
                self.context = Some(context);
                self.compiled = Some(compiled);
                self.engine = Some(engine);
                Ok(response)
            }
            "evaluate" => {
                let (entry, sources, context) = project_context(&v)?;
                let (value, deps) = context.run(|| muz::lang::load_with_loader(&entry, sources))?;
                let value = value.json();
                ensure!(
                    serde_json::to_vec(&value)?.len() <= 1024 * 1024,
                    "evaluation exceeds 1 MiB; return a smaller value"
                );
                Ok(json!({"result":value,"dependencies":deps}))
            }
            "format" => {
                let source = v["source"]
                    .as_str()
                    .ok_or_else(|| anyhow::anyhow!("source required"))?;
                ensure!(source.len() <= 4 * 1024 * 1024, "source exceeds 4 MiB");
                let formatted = muz::lang::format::format(source)?;
                Ok(json!({"changed":formatted!=source,"source":formatted}))
            }
            "inspect" => {
                let c = self
                    .compiled
                    .as_ref()
                    .ok_or_else(|| anyhow::anyhow!("compile first"))?;
                let request: muz::inspect::PageRequest =
                    serde_json::from_value(v.get("page").cloned().unwrap_or(json!({})))?;
                Ok(serde_json::to_value(muz::inspect::page_compiled(
                    c,
                    1,
                    v["view"].as_str().unwrap_or("summary"),
                    &request,
                )?)?)
            }
            "explain" => {
                let c = self
                    .compiled
                    .as_ref()
                    .ok_or_else(|| anyhow::anyhow!("compile first"))?;
                Ok(serde_json::to_value(
                    c.explain_notes(
                        v["track"]
                            .as_str()
                            .ok_or_else(|| anyhow::anyhow!("track required"))?,
                        v["offset"].as_u64().unwrap_or(0) as usize,
                        v["limit"].as_u64().unwrap_or(100) as usize,
                    )?,
                )?)
            }
            "notes" => self.notes(&v),
            "start" => {
                self.engine
                    .as_mut()
                    .ok_or_else(|| anyhow::anyhow!("compile first"))?
                    .set_running(true);
                Ok(json!({}))
            }
            "release" => {
                self.engine
                    .as_mut()
                    .ok_or_else(|| anyhow::anyhow!("compile first"))?
                    .set_running(false);
                Ok(json!({}))
            }
            "reset" => {
                let session = &self
                    .compiled
                    .as_ref()
                    .ok_or_else(|| anyhow::anyhow!("compile first"))?
                    .session;
                self.engine = Some(self.context.as_ref().unwrap().run(|| {
                    AudioEngine::new(
                        session,
                        AudioConfig {
                            sample_rate: self.rate as f32,
                            max_frames: 1024,
                            offline: v["offline"].as_bool().unwrap_or(false),
                        },
                    )
                })?);
                self.engine.as_mut().unwrap().set_running(true);
                Ok(json!({}))
            }
            "render" => {
                let frames = v["frames"].as_u64().unwrap_or(1024) as usize;
                ensure!(frames <= 1024, "render block exceeds 1024 frames");
                self.pcm.resize(frames * 2, 0.0);
                let e = self
                    .engine
                    .as_mut()
                    .ok_or_else(|| anyhow::anyhow!("compile first"))?;
                e.render_interleaved(&mut self.pcm, 2)?;
                let s = e.status();
                Ok(
                    json!({"frame": s.transport.project_frame, "tick": s.current_tick, "peak": s.last_peak, "ended": s.ended}),
                )
            }
            "solo" => {
                let names: Vec<String> = serde_json::from_value(v["tracks"].clone())?;
                self.engine
                    .as_mut()
                    .ok_or_else(|| anyhow::anyhow!("compile first"))?
                    .set_solo(&names)?;
                Ok(json!({}))
            }
            "midi" => {
                self.blob = muz::smf::encode(&muz::smf::export(
                    &self
                        .compiled
                        .as_ref()
                        .ok_or_else(|| anyhow::anyhow!("compile first"))?
                        .session,
                )?)?;
                Ok(json!({"length": self.blob.len()}))
            }
            _ => bail!("unknown host command"),
        }
    }

    // A common quarter-note-beat interface, without confusing score PPQ, imported
    // MIDI PPQ, and the legacy loop PPQ. Indices are revision-local, not note IDs.
    fn notes(&self, v: &Value) -> Result<Value> {
        let c = self
            .compiled
            .as_ref()
            .ok_or_else(|| anyhow::anyhow!("compile first"))?;
        let basis = v["basis"].as_str().unwrap_or("score");
        ensure!(
            matches!(basis, "score" | "performance"),
            "basis must be score or performance"
        );
        let offset = v["offset"].as_u64().unwrap_or(0) as usize;
        let limit = v["limit"].as_u64().unwrap_or(1000) as usize;
        ensure!(
            limit > 0 && limit <= 1000,
            "note page limit must be 1..1000"
        );
        let mut total = 0usize;
        let mut rows = Vec::new();
        let mut bytes = 0usize;
        let track = v["track"].as_str();
        let mut push = |t: &str,
                        index: usize,
                        at: Value,
                        dur: Value,
                        pitch: f64,
                        velocity: f64,
                        key: Value,
                        tags: Value,
                        voice: Value,
                        channel: Value,
                        clock: Value|
         -> Result<()> {
            if track.is_some_and(|selected| selected != t) {
                return Ok(());
            }
            let position = total;
            total += 1;
            if position < offset || rows.len() >= limit || bytes >= 900_000 {
                return Ok(());
            }
            let row = json!({"track":t,"index":index,"at":at,"dur":dur,"pitch":pitch,"velocity":velocity,"key":key,"tags":tags,"voice":voice,"channel":channel,"clock":clock});
            bytes += serde_json::to_vec(&row)?.len();
            ensure!(bytes <= 1024 * 1024, "note page exceeds 1 MiB");
            rows.push(row);
            Ok(())
        };
        if basis == "score" {
            ensure!(
                track.is_none_or(|id| c.score.iter().any(|t| t.id == id)),
                "unknown score track"
            );
            for t in &c.score {
                for (i, n) in t.pattern.notes.iter().enumerate() {
                    push(
                        &t.id,
                        i,
                        json!(n.at),
                        json!(n.dur),
                        n.pitch,
                        n.velocity,
                        json!(n.key),
                        json!(n.tags),
                        json!(n.voice),
                        Value::Null,
                        json!(n.clock),
                    )?;
                }
            }
        } else {
            ensure!(
                track.is_none_or(|id| c.session.tracks.iter().any(|t| t.id.as_str() == id)),
                "unknown performance track"
            );
            for t in &c.session.tracks {
                match &t.source {
                    muz::model::TrackSource::Pattern(p) => {
                        for (i, n) in p.notes.iter().enumerate() {
                            push(
                                t.id.as_str(),
                                i,
                                json!([n.start_ticks, muz::model::TICKS_PER_BEAT]),
                                json!([n.duration_ticks, muz::model::TICKS_PER_BEAT]),
                                n.key as f64,
                                n.velocity as f64,
                                json!(n.id),
                                json!([]),
                                Value::Null,
                                Value::Null,
                                Value::Null,
                            )?;
                        }
                    }
                    muz::model::TrackSource::Midi(m) => {
                        for (i, n) in m
                            .imported
                            .notes
                            .iter()
                            .enumerate()
                            .filter(|(_, n)| m.all_channels || n.channel == m.channel)
                        {
                            push(
                                t.id.as_str(),
                                i,
                                json!([n.start_tick, m.imported.summary.ppq]),
                                json!([n.duration_ticks, m.imported.summary.ppq]),
                                n.key as f64,
                                n.attack_velocity as f64 / 127.0,
                                json!(n.id),
                                json!(n.tags),
                                Value::Null,
                                json!(n.channel),
                                Value::Null,
                            )?;
                        }
                    }
                }
            }
        }
        let end = offset + rows.len();
        Ok(
            json!({"basis":basis,"unit":"quarter-note beats","rows":rows,"total":total,"next":if end<total {Some(end)} else {None}}),
        )
    }
}

// The worker is the sole caller. Each returned view is borrowed only until the next call.
#[unsafe(no_mangle)]
pub extern "C" fn muz_alloc(length: usize) -> *mut u8 {
    if length > MAX_REQUEST {
        return std::ptr::null_mut();
    }
    Box::into_raw(vec![0u8; length].into_boxed_slice()) as *mut u8
}
#[unsafe(no_mangle)]
pub unsafe extern "C" fn muz_free(ptr: *mut u8, length: usize) {
    if !ptr.is_null() {
        unsafe {
            drop(Box::from_raw(std::ptr::slice_from_raw_parts_mut(
                ptr, length,
            )));
        }
    }
}
#[unsafe(no_mangle)]
pub unsafe extern "C" fn muz_call(ptr: *const u8, length: usize) -> usize {
    HOST.with(|host| {
        let mut host = host.borrow_mut();
        let result = if ptr.is_null() || length > MAX_REQUEST { Err(anyhow::anyhow!("request exceeds host limit")) } else { unsafe { serde_json::from_slice(std::slice::from_raw_parts(ptr,length)) }.map_err(Into::into).and_then(|v| host.command(v)) };
        let response = match result { Ok(value) => json!({"ok":true,"value":value}), Err(e) => json!({"ok":false,"error":format!("{e:#}"), "diagnostic":e.chain().find_map(|cause|cause.downcast_ref::<muz::diagnostic::Diagnostic>()).map(|d| d.to_json())}) };
        host.response = serde_json::to_vec(&response).unwrap(); host.response.len()
    })
}
#[unsafe(no_mangle)]
pub extern "C" fn muz_response() -> *const u8 {
    HOST.with(|h| h.borrow().response.as_ptr())
}
#[unsafe(no_mangle)]
pub extern "C" fn muz_pcm() -> *const f32 {
    HOST.with(|h| h.borrow().pcm.as_ptr())
}
#[unsafe(no_mangle)]
pub extern "C" fn muz_blob() -> *const u8 {
    HOST.with(|h| h.borrow().blob.as_ptr())
}

#[cfg(test)]
mod tests {
    use super::*;
    #[test]
    fn mount_normalizes_without_escape() {
        assert_eq!(
            mounted(Path::new("/project/lib/../song.muz")).unwrap(),
            Path::new("/project/song.muz")
        );
        assert!(mounted(Path::new("/project/../secrets")).is_err());
    }
}
"""

let render() = file
