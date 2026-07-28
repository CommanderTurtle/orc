module ConvertedFiles.CountkuMusicJs

let file = """import {
  SCORE_MOVEMENTS,
  movementById,
  movementForCount
} from "./countku-score.js?v=0.6.1";

const midiToFrequency = (midi) => 440 * (2 ** ((midi - 69) / 12));

const clamp = (value, minimum = 0, maximum = 1) =>
  Math.min(maximum, Math.max(minimum, Number(value) || 0));

export class CountkuAmbientScore {
  constructor({
    enabled = true,
    volume = 0.24,
    progress = 0,
    movement = "auto"
  } = {}) {
    this.enabled = Boolean(enabled);
    this.volume = clamp(volume);
    this.progress = Math.max(0, Math.floor(Number(progress) || 0));
    this.manualMovement = movement === "auto" ? null : movementById(movement);
    this.profile = this.manualMovement ?? movementForCount(this.progress);
    this.context = null;
    this.master = null;
    this.compressor = null;
    this.delay = null;
    this.delayFeedback = null;
    this.delayWet = null;
    this.atmosphere = null;
    this.atmosphereFilter = null;
    this.atmosphereGain = null;
    this.percussionBuffer = null;
    this.transport = null;
    this.nextStepAt = 0;
    this.step = 0;
    this.playing = false;
  }

  get movement() {
    return this.profile;
  }

  get availableMovements() {
    return SCORE_MOVEMENTS.filter(
      (movement) => this.progress >= movement.minimum
    );
  }

  setEnabled(enabled) {
    this.enabled = Boolean(enabled);
    if (!this.enabled) this.pause();
  }

  setVolume(volume) {
    this.volume = clamp(volume);
    if (this.context && this.master) {
      this.master.gain.cancelScheduledValues(this.context.currentTime);
      this.master.gain.setTargetAtTime(
        this.playing ? this.volume : 0,
        this.context.currentTime,
        0.08
      );
    }
  }

  setProgress(correct) {
    this.progress = Math.max(0, Math.floor(Number(correct) || 0));
    const next =
      this.manualMovement &&
      this.progress >= this.manualMovement.minimum
        ? this.manualMovement
        : movementForCount(this.progress);
    this.selectProfile(next);
  }

  setMovement(id = "auto") {
    const requested = id === "auto" ? null : movementById(id);
    if (requested && this.progress < requested.minimum) return false;
    const previous =
      this.manualMovement?.id ?? "auto";
    this.manualMovement = requested;
    this.selectProfile(requested ?? movementForCount(this.progress), {
      restartPhrase: previous !== id
    });
    return true;
  }

  selectProfile(profile, { restartPhrase = false } = {}) {
    if (!profile) return;
    const changed = this.profile?.id !== profile.id;
    this.profile = profile;
    if (changed || restartPhrase) {
      this.step = 0;
      if (this.context) {
        this.nextStepAt = this.context.currentTime + 0.12;
      }
    }
    this.applyProfile();
  }

  applyProfile() {
    if (!this.context || !this.profile) return;
    const now = this.context.currentTime;
    const profile = this.profile;

    if (this.delay && this.delayFeedback && this.delayWet) {
      this.delay.delayTime.setTargetAtTime(profile.delayTime, now, 0.18);
      this.delayFeedback.gain.setTargetAtTime(
        profile.delayFeedback,
        now,
        0.18
      );
      this.delayWet.gain.setTargetAtTime(profile.delayWet, now, 0.18);
    }
    if (this.atmosphereFilter && this.atmosphereGain) {
      this.atmosphereFilter.frequency.setTargetAtTime(
        profile.atmosphereFrequency,
        now,
        0.4
      );
      this.atmosphereFilter.Q.setTargetAtTime(
        profile.atmosphereQ,
        now,
        0.4
      );
      this.atmosphereGain.gain.setTargetAtTime(
        profile.atmosphereGain,
        now,
        0.4
      );
    }
  }

  getContext() {
    const AudioContext = window.AudioContext || window.webkitAudioContext;
    if (!AudioContext) return null;
    if (!this.context) {
      this.context = new AudioContext();
      this.master = this.context.createGain();
      this.compressor = this.context.createDynamicsCompressor();
      this.delay = this.context.createDelay(1);
      this.delayFeedback = this.context.createGain();
      this.delayWet = this.context.createGain();

      this.master.gain.value = 0.0001;
      this.compressor.threshold.value = -22;
      this.compressor.knee.value = 18;
      this.compressor.ratio.value = 3;
      this.compressor.attack.value = 0.018;
      this.compressor.release.value = 0.42;

      this.master.connect(this.compressor);
      this.master.connect(this.delay);
      this.delay.connect(this.delayFeedback);
      this.delayFeedback.connect(this.delay);
      this.delay.connect(this.delayWet);
      this.delayWet.connect(this.compressor);
      this.compressor.connect(this.context.destination);
      this.createAtmosphere();
      this.createPercussionBuffer();
      this.applyProfile();
    }
    return this.context;
  }

  createAtmosphere() {
    if (!this.context || !this.master || this.atmosphere) return;
    const length = this.context.sampleRate * 4;
    const buffer = this.context.createBuffer(
      1,
      length,
      this.context.sampleRate
    );
    const data = buffer.getChannelData(0);
    let drift = 0;
    for (let index = 0; index < length; index += 1) {
      drift = (drift + Math.random() * 0.05 - 0.025) * 0.994;
      data[index] = drift;
    }

    const source = this.context.createBufferSource();
    const filter = this.context.createBiquadFilter();
    const gain = this.context.createGain();
    source.buffer = buffer;
    source.loop = true;
    filter.type = "bandpass";
    gain.gain.value = 0.0001;
    source.connect(filter);
    filter.connect(gain);
    gain.connect(this.master);
    source.start();
    this.atmosphere = source;
    this.atmosphereFilter = filter;
    this.atmosphereGain = gain;
  }

  createPercussionBuffer() {
    if (!this.context || this.percussionBuffer) return;
    const length = Math.floor(this.context.sampleRate * 0.18);
    const buffer = this.context.createBuffer(
      1,
      length,
      this.context.sampleRate
    );
    const data = buffer.getChannelData(0);
    for (let index = 0; index < length; index += 1) {
      const envelope = 1 - index / length;
      data[index] = (Math.random() * 2 - 1) * envelope;
    }
    this.percussionBuffer = buffer;
  }

  async start() {
    if (!this.enabled || this.playing) return false;
    const context = this.getContext();
    if (!context) return false;
    if (context.state === "suspended") {
      await context.resume().catch(() => {});
    }
    this.playing = true;
    this.nextStepAt = context.currentTime + 0.08;
    this.master.gain.cancelScheduledValues(context.currentTime);
    this.master.gain.setTargetAtTime(
      this.volume,
      context.currentTime,
      0.18
    );
    this.transport = window.setInterval(() => this.scheduleAhead(), 72);
    this.scheduleAhead();
    return true;
  }

  pause() {
    this.playing = false;
    if (this.transport) window.clearInterval(this.transport);
    this.transport = null;
    if (this.context && this.master) {
      this.master.gain.cancelScheduledValues(this.context.currentTime);
      this.master.gain.setTargetAtTime(0, this.context.currentTime, 0.08);
    }
  }

  async toggle() {
    if (this.playing) {
      this.pause();
      return false;
    }
    await this.start();
    return this.playing;
  }

  scheduleAhead() {
    if (!this.playing || !this.context) return;
    if (this.nextStepAt < this.context.currentTime - 1) {
      this.nextStepAt = this.context.currentTime + 0.08;
    }
    const horizon = this.context.currentTime + 0.72;
    while (this.nextStepAt < horizon) {
      const profile = this.profile;
      this.scheduleStep(profile, this.nextStepAt, this.step);
      this.nextStepAt += (60 / profile.bpm) / profile.subdivision;
      this.step = (this.step + 1) % profile.notes.length;
    }
  }

  scheduleStep(profile, startsAt, step) {
    const midi = profile.notes[step % profile.notes.length];
    if (midi !== null) {
      this.voice({
        midi,
        startsAt,
        duration: step % 4 === 0
          ? profile.release * 1.18
          : profile.release,
        volume: step % 4 === 0
          ? profile.melodyGain * 1.14
          : profile.melodyGain,
        wave: profile.wave,
        attack: profile.attack,
        lowpass: profile.lowpass
      });
    }

    const counter =
      profile.counter[step % profile.counter.length];
    if (counter !== null) {
      this.voice({
        midi: counter,
        startsAt: startsAt + 0.012,
        duration: profile.release * 1.45,
        volume: profile.counterGain,
        wave: profile.counterWave,
        attack: profile.attack * 1.3,
        lowpass: profile.lowpass * 1.25
      });
    }

    if (step % 8 === 0) {
      const root = profile.roots[
        Math.floor(step / 8) % profile.roots.length
      ];
      this.voice({
        midi: root,
        startsAt,
        duration: Math.max(2.2, profile.release * 2.35),
        volume: profile.bassGain,
        wave: profile.bassWave,
        attack: Math.max(0.06, profile.attack * 1.7),
        lowpass: Math.min(620, profile.lowpass * 0.42)
      });
    }

    if (
      profile.pulseEvery > 0 &&
      step % profile.pulseEvery === 0
    ) {
      this.pulse({
        startsAt,
        frequency: profile.pulseFrequency,
        volume: profile.pulseGain
      });
    }
  }

  voice({
    midi,
    startsAt,
    duration,
    volume,
    wave,
    attack = 0.04,
    lowpass = 1800
  }) {
    if (!this.context || !this.master) return;
    const oscillator = this.context.createOscillator();
    const filter = this.context.createBiquadFilter();
    const gain = this.context.createGain();
    const end = startsAt + duration;

    oscillator.type = wave;
    oscillator.frequency.setValueAtTime(midiToFrequency(midi), startsAt);
    oscillator.detune.setValueAtTime((this.step % 3) - 1.5, startsAt);
    filter.type = "lowpass";
    filter.frequency.setValueAtTime(lowpass, startsAt);
    filter.Q.setValueAtTime(0.72, startsAt);
    gain.gain.setValueAtTime(0.0001, startsAt);
    gain.gain.exponentialRampToValueAtTime(
      Math.max(0.0001, volume),
      startsAt + Math.max(0.012, attack)
    );
    gain.gain.exponentialRampToValueAtTime(
      Math.max(0.0001, volume * 0.38),
      startsAt + Math.min(0.52, duration * 0.34)
    );
    gain.gain.exponentialRampToValueAtTime(0.0001, end);

    oscillator.connect(filter);
    filter.connect(gain);
    gain.connect(this.master);
    oscillator.start(startsAt);
    oscillator.stop(end + 0.04);
  }

  pulse({ startsAt, frequency, volume }) {
    if (!this.context || !this.master || !this.percussionBuffer) return;
    const source = this.context.createBufferSource();
    const filter = this.context.createBiquadFilter();
    const gain = this.context.createGain();
    source.buffer = this.percussionBuffer;
    filter.type = "bandpass";
    filter.frequency.value = frequency;
    filter.Q.value = 1.7;
    gain.gain.setValueAtTime(Math.max(0.0001, volume), startsAt);
    gain.gain.exponentialRampToValueAtTime(0.0001, startsAt + 0.16);
    source.connect(filter);
    filter.connect(gain);
    gain.connect(this.master);
    source.start(startsAt);
    source.stop(startsAt + 0.18);
  }

  accent() {
    if (!this.playing || !this.context) return;
    const now = this.context.currentTime + 0.04;
    const profile = this.profile;
    [0, 4, 7].forEach((offset, index) => {
      this.voice({
        midi: profile.roots[0] + 12 + offset,
        startsAt: now + index * 0.1,
        duration: Math.max(1.4, profile.release),
        volume: profile.melodyGain * (1.35 - index * 0.12),
        wave: profile.wave,
        attack: profile.attack,
        lowpass: profile.lowpass
      });
    });
  }
}
"""

let render() = file
