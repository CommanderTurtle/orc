module MLLM.Resources.Speech.Ffmpeg.WorkerDTs

let file = """/// <reference no-default-lib="true"/>
/// <reference lib="esnext" />
/// <reference lib="webworker" />
import type { FFmpegCoreModuleFactory } from "@ffmpeg/types";
declare global {
    interface WorkerGlobalScope {
        createFFmpegCore: FFmpegCoreModuleFactory;
    }
}
"""

let render() = file
