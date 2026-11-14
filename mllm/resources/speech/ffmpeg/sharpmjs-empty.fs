module MLLM.Resources.Speech.Ffmpeg.EmptyMjs

let file = """// File to be imported in node enviroments
export class FFmpeg {
    constructor() {
        throw new Error("ffmpeg.wasm does not support nodejs");
    }
}
"""

let render() = file
