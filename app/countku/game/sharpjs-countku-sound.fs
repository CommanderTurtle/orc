module ConvertedFiles.CountkuSoundJs

let file = """const STAGE_PALETTES = Object.freeze({
  novice: {
    wave: "sine",
    success: [
      [523.25, 0, 0.22, 0.08],
      [659.25, 0.08, 0.25, 0.07],
      [783.99, 0.17, 0.34, 0.06]
    ],
    failure: [196, 146.83]
  },
  apprentice: {
    wave: "triangle",
    success: [
      [587.33, 0, 0.2, 0.072],
      [739.99, 0.07, 0.24, 0.064],
      [880, 0.15, 0.31, 0.056]
    ],
    failure: [220, 164.81]
  },
  verse: {
    wave: "sine",
    success: [
      [659.25, 0, 0.2, 0.07],
      [830.61, 0.075, 0.27, 0.064],
      [987.77, 0.18, 0.38, 0.052]
    ],
    failure: [207.65, 155.56]
  },
  adept: {
    wave: "triangle",
    success: [
      [392, 0, 0.25, 0.074],
      [523.25, 0.06, 0.29, 0.064],
      [659.25, 0.16, 0.4, 0.054]
    ],
    failure: [185, 138.59]
  },
  moon: {
    wave: "sine",
    success: [
      [440, 0, 0.3, 0.064],
      [659.25, 0.1, 0.38, 0.056],
      [880, 0.24, 0.5, 0.045]
    ],
    failure: [174.61, 130.81]
  },
  sage: {
    wave: "triangle",
    success: [
      [587.33, 0, 0.26, 0.065],
      [880, 0.09, 0.36, 0.054],
      [1174.66, 0.22, 0.52, 0.042]
    ],
    failure: [246.94, 185]
  }
});

export class CountkuSoundPalette {
  constructor(enabled = true, volume = 0.72) {
    this.enabled = enabled;
    this.volume = volume;
    this.context = null;
    this.stage = "novice";
  }

  setEnabled(enabled) {
    this.enabled = Boolean(enabled);
  }

  setStage(stage) {
    if (STAGE_PALETTES[stage]) this.stage = stage;
  }

  setVolume(volume) {
    this.volume = Math.min(1, Math.max(0, Number(volume) || 0));
  }

  getContext() {
    if (!this.enabled) return null;
    const AudioContext = window.AudioContext || window.webkitAudioContext;
    if (!AudioContext) return null;
    this.context ??= new AudioContext();
    if (this.context.state === "suspended") {
      this.context.resume().catch(() => {});
    }
    return this.context;
  }

  tone({ frequency, startsAt, duration, volume, type = "sine" }) {
    const context = this.getContext();
    if (!context || this.volume <= 0) return;

    const oscillator = context.createOscillator();
    const gain = context.createGain();
    const start = context.currentTime + startsAt;
    const end = start + duration;

    oscillator.type = type;
    oscillator.frequency.setValueAtTime(frequency, start);
    gain.gain.setValueAtTime(0.0001, start);
    gain.gain.exponentialRampToValueAtTime(
      Math.max(0.0001, volume * this.volume),
      start + 0.018
    );
    gain.gain.exponentialRampToValueAtTime(0.0001, end);
    oscillator.connect(gain);
    gain.connect(context.destination);
    oscillator.start(start);
    oscillator.stop(end + 0.02);
  }

  success() {
    const palette = STAGE_PALETTES[this.stage];
    palette.success.forEach(([frequency, startsAt, duration, volume]) =>
      this.tone({
        frequency,
        startsAt,
        duration,
        volume,
        type: palette.wave
      })
    );
  }

  failure() {
    const palette = STAGE_PALETTES[this.stage];
    this.tone({
      frequency: palette.failure[0],
      startsAt: 0,
      duration: 0.28,
      volume: 0.06,
      type: "triangle"
    });
    this.tone({
      frequency: palette.failure[1],
      startsAt: 0.1,
      duration: 0.34,
      volume: 0.045,
      type: "triangle"
    });
  }
}
"""

let render() = file
