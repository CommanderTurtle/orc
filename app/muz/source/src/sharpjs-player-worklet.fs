module Muz.Source.Src.PlayerWorkletJs

let file = """class MuzPlayer extends AudioWorkletProcessor {
  constructor() {
    super(); this.queue = []; this.offset = 0; this.playing = false; this.frame = 0;
    this.report = 0; this.waiting = false; this.done = false; this.epoch = 0; this.loop = null; this.fade = 0;
    this.port.onmessage = ({ data }) => {
      if (data.type === 'clear') {
        this.queue = []; this.offset = 0; this.frame = data.frame || 0; this.epoch = data.epoch;
        this.waiting = false; this.done = false; this.playing = false; this.fade = 240;
      }
      if (data.epoch !== undefined && data.epoch !== this.epoch) return;
      if (data.type === 'chunk') { if (data.pcm.length) this.queue.push(data.pcm); this.waiting = false; this.done = data.done; }
      if (data.type === 'play') this.playing = true;
      if (data.type === 'pause') this.playing = false;
      if (data.type === 'retry') this.waiting = false;
      if (data.type === 'loop') this.loop = data.range;
    };
  }
  process(_inputs, outputs) {
    const [left, right] = outputs[0]; if (!left) return true;
    left.fill(0); right?.fill(0);
    if (this.playing) for (let i = 0; i < left.length; i++) {
      if (this.loop && this.frame >= this.loop[1]) {
        this.playing = false; this.port.postMessage({ type: 'loop', epoch: this.epoch, frame: this.loop[0] }); break;
      }
      while (this.queue.length && this.offset >= this.queue[0].length) { this.queue.shift(); this.offset = 0; }
      if (!this.queue.length) break;
      const scale = this.fade > 0 ? 1 - this.fade-- / 240 : 1;
      left[i] = this.queue[0][this.offset++] * scale;
      if (right) right[i] = this.queue[0][this.offset++] * scale; else this.offset++;
      this.frame++;
    }
    const buffered = this.queue.reduce((n, b) => n + b.length / 2, 0) - this.offset / 2;
    if (this.playing && buffered < sampleRate * .4 && !this.waiting && !this.done) { this.waiting = true; this.port.postMessage({ type: 'need', epoch: this.epoch }); }
    if (this.playing && this.done && buffered <= 0) { this.playing = false; this.port.postMessage({ type: 'ended', epoch: this.epoch }); }
    if (++this.report >= 20 && this.playing) { this.report = 0; this.port.postMessage({ type: 'position', epoch: this.epoch, frame: this.frame }); }
    return true;
  }
}
registerProcessor('muzstatic-player', MuzPlayer);
"""

let render() = file
