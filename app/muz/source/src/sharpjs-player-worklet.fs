module Muz.Source.Src.PlayerWorkletJs

let file = """class MuzPlayer extends AudioWorkletProcessor {
  constructor() {
    super(); this.queue = []; this.offset = 0; this.playing = false; this.frame = 0; this.report = 0; this.waiting = false; this.done = false;
    this.port.onmessage = ({ data }) => {
      if (data.type === 'chunk') { this.queue.push(data.pcm); this.waiting = false; this.done = data.done; }
      if (data.type === 'play') this.playing = true;
      if (data.type === 'pause') this.playing = false;
      if (data.type === 'retry') this.waiting = false;
      if (data.type === 'clear') { this.queue = []; this.offset = 0; this.frame = 0; this.waiting = false; this.done = false; this.playing = false; }
    };
  }
  process(_inputs, outputs) {
    const [left, right] = outputs[0];
    if (!left) return true;
    if (this.playing) for (let i = 0; i < left.length; i++) {
      while (this.queue.length && this.offset >= this.queue[0].length) { this.queue.shift(); this.offset = 0; }
      if (!this.queue.length) break;
      left[i] = this.queue[0][this.offset++]; right[i] = this.queue[0][this.offset++]; this.frame++;
    }
    const buffered = this.queue.reduce((n, b) => n + b.length / 2, 0) - this.offset / 2;
    if (this.playing && buffered < sampleRate * 0.4 && !this.waiting && !this.done) { this.waiting = true; this.port.postMessage({ type: 'need' }); }
    if (this.playing && this.done && buffered <= 0) { this.playing = false; this.port.postMessage({ type: 'ended' }); }
    if (++this.report >= 20 && this.playing) { this.report = 0; this.port.postMessage({ type: 'position', frame: this.frame }); }
    return true;
  }
}
registerProcessor('muzstatic-player', MuzPlayer);
"""

let render() = file
