module TTS.AppJs

let file = """import {
  SpeechEngine,
  speechSegments,
  wavBlob,
  clearDownloads,
} from "./speech/speech.js";
import {
  languages,
  translationPrompt,
  translationTools,
  validatedRequest,
} from "./speech/translation.js";
const $ = (id) => document.getElementById(id);
let engine,
  mic,
  controller,
  epoch = 0,
  recordDone,
  audioURL,
  requestJSON = "",
  busy = false;
const settings = (() => {
  try {
    return JSON.parse(localStorage.getItem("speakingwasm-settings") || "{}");
  } catch {
    return {};
  }
})();
const persist = () => {
  try {
    localStorage.setItem("speakingwasm-settings", JSON.stringify(settings));
  } catch {}
};
const tell = (text, progress, error = false) => {
  $("status").textContent = text;
  $("status").parentElement.classList.toggle("error", error);
  $("progress").hidden = typeof progress !== "number";
  if (typeof progress === "number") {
    $("progress").max = 1;
    $("progress").value = progress;
  }
};
function working(value) {
  busy = value;
  $("cancel").hidden = !value;
  for (const el of document.querySelectorAll(
    "aside select,aside input,#speak-run,#translate-run,#audio-file,#clear-cache",
  ))
    el.disabled = value;
  if (!value) sttOptions();
}
function cancel() {
  epoch++;
  controller?.abort();
  mic?.cancel();
  mic = null;
  recordDone?.();
  recordDone = null;
  engine?.close();
  engine = null;
  working(false);
  $("microphone").classList.remove("recording");
  $("microphone").setAttribute("aria-label", "Start microphone");
  $("mic-label").textContent = "Tap to record";
  $("pending").textContent = "";
}
async function run(task) {
  cancel();
  const id = epoch;
  controller = new AbortController();
  engine = new SpeechEngine({
    onStatus: (text, p) => {
      if (epoch === id) tell(text, p);
    },
  });
  working(true);
  tell("Preparing…");
  try {
    await task(engine, controller.signal);
    if (epoch === id) tell("Ready · model released");
  } catch (error) {
    if (epoch === id && error.name !== "AbortError")
      tell(error.message, undefined, true);
  } finally {
    if (epoch === id) {
      engine?.close();
      engine = null;
      mic?.cancel();
      mic = null;
      working(false);
      $("microphone").classList.remove("recording");
      $("microphone").setAttribute("aria-label", "Start microphone");
      $("mic-label").textContent = "Tap to record";
    }
  }
}
function mode(name) {
  cancel();
  $("audio").pause();
  for (const el of document.querySelectorAll("[data-mode]"))
    el.setAttribute("aria-pressed", String(el.dataset.mode === name));
  for (const id of ["speak", "listen", "translate"]) $(id).hidden = id !== name;
  tell("Ready · nothing loaded");
}
document
  .querySelectorAll("[data-mode]")
  .forEach((el) => (el.onclick = () => mode(el.dataset.mode)));
$("cancel").onclick = () => {
  cancel();
  tell("Cancelled · model released");
};
$("clear-cache").onclick = async () => {
  try {
    await clearDownloads();
    tell("Downloaded model cache cleared");
  } catch (error) {
    tell(error.message, undefined, true);
  }
};
function save(blob, name) {
  const url = URL.createObjectURL(blob),
    a = document.createElement("a");
  a.href = url;
  a.download = name;
  a.click();
  setTimeout(() => URL.revokeObjectURL(url), 30000);
}
async function copy(text) {
  try {
    await navigator.clipboard.writeText(text);
    tell("Copied");
  } catch {
    tell(
      "Clipboard unavailable. Select the text and copy it manually.",
      undefined,
      true,
    );
  }
}
const voiceNames = {
  a: "English · US",
  b: "English · UK",
  e: "Spanish",
  f: "French",
  h: "Hindi",
  i: "Italian",
  p: "Portuguese",
  j: "Japanese · phonemes",
  z: "Chinese · phonemes",
};
let allVoices = [];
const paradeeVoices = [
  "af_heart",
  "bf_isabella",
  "am_puck",
  "bm_fable",
  "hf_alpha",
  "hm_omega",
  "ff_siwis",
  "em_alex",
];
function voices() {
  const model = $("tts-model").value,
    previous = settings[`${model}-voice`] || "af_heart";
  $("voice").replaceChildren();
  for (const id of model === "paradee" ? paradeeVoices : allVoices) {
    const option = new Option(
      `${id.slice(3).replaceAll("_", " ")} · ${voiceNames[id[0]] || id}`,
      id,
    );
    $("voice").add(option);
  }
  $("voice").value = previous;
  if (!$("voice").value) $("voice").selectedIndex = 0;
  $("tts-size").textContent =
    model === "paradee"
      ? "INT8 · 8.5 MB · embedded voices"
      : "FP32 · 326 MB + selected voice · 522 KB";
  settings.tts = model;
  persist();
  voiceHint();
}
function voiceHint() {
  const native = ["j", "z"].includes($("voice").value[0]);
  $("phoneme-hint").textContent = native
    ? "Japanese and Chinese voices accept Misaki model phonemes. Select “Model phonemes” above."
    : "Voice language determines pronunciation.";
}
$("tts-model").value = settings.tts || "paradee";
$("tts-model").onchange = voices;
$("voice").onchange = () => {
  settings[`${$("tts-model").value}-voice`] = $("voice").value;
  persist();
  voiceHint();
};
$("speed").value = settings.speed || 1;
$("speed").oninput = () => {
  $("speed-value").value = Number($("speed").value).toFixed(2) + "×";
  settings.speed = Number($("speed").value);
  persist();
};
$("speed").oninput();
voices();
fetch("./speech/assets.lock.json")
  .then((r) => {
    if (!r.ok)
      throw Error(
        "Speech catalog missing. Build and deploy the complete dist.",
      );
    return r.json();
  })
  .then((lock) => {
    allVoices = Object.keys(lock.kokoro)
      .filter((s) => s.startsWith("voices/"))
      .map((s) => s.slice(7, -4));
    voices();
  })
  .catch((error) => tell(error.message, undefined, true));
$("script").oninput = () => {
  $("chars").textContent =
    `${$("script").value.length.toLocaleString()} characters`;
};
for (const [input, target] of [
  ["tts-file", "script"],
  ["translation-file", "document"],
])
  $(input).onchange = async () => {
    try {
      const file = $(input).files[0];
      if (file) {
        $(target).value = await file.text();
        $(target).dispatchEvent(new Event("input"));
      }
    } catch (e) {
      tell(e.message, undefined, true);
    } finally {
      $(input).value = "";
    }
  };
function closeAudio() {
  $("audio").pause();
  $("audio").removeAttribute("src");
  $("audio").load();
  if (audioURL) URL.revokeObjectURL(audioURL);
  audioURL = null;
  $("save-audio").removeAttribute("href");
  $("player").hidden = true;
}
$("close-audio").onclick = closeAudio;
$("rewind").onclick = () => {
  $("audio").currentTime = Math.max(0, $("audio").currentTime - 10);
};
$("forward").onclick = () => {
  $("audio").currentTime = Math.min(
    $("audio").duration || 0,
    $("audio").currentTime + 10,
  );
};
$("speak-run").onclick = () => {
  const text = $("script").value;
  if (!text.trim()) {
    tell("Enter text to speak.", undefined, true);
    return;
  }
  const options = {
      voice: $("voice").value,
      speed: Number($("speed").value),
      phonemes: $("input-mode").value === "phonemes",
    },
    model = $("tts-model").value;
  if (!options.phonemes && ["j", "z"].includes(options.voice[0])) {
    tell(
      "Select Model phonemes for this voice, or choose a text-supported language.",
      undefined,
      true,
    );
    return;
  }
  closeAudio();
  void run(async (e, signal) => {
    await e.load(model, options);
    const chunks = [],
      parts = speechSegments(text);
    for (let i = 0; i < parts.length; i++) {
      signal.throwIfAborted();
      tell(`Speaking · phrase ${i + 1} of ${parts.length}`, i / parts.length);
      try {
        const result = await e.call("speak", { text: parts[i] });
        chunks.push(result.pcm);
      } catch (error) {
        if (error.message.includes("510 phonemes") && parts[i].length > 2) {
          const midpoint = Math.floor(parts[i].length / 2),
            space = parts[i].lastIndexOf(" ", midpoint),
            cut = space > 0 ? space : midpoint;
          parts.splice(i, 1, parts[i].slice(0, cut), parts[i].slice(cut));
          i--;
          continue;
        }
        throw error;
      }
    }
    signal.throwIfAborted();
    audioURL = URL.createObjectURL(wavBlob(chunks));
    $("audio").src = audioURL;
    $("save-audio").href = audioURL;
    $("player").hidden = false;
  });
};
$("stt-model").value = settings.stt || "whistle";
function sttOptions() {
  const whistle = $("stt-model").value === "whistle";
  $("stt-size").textContent = whistle
    ? "17 MB · WASM · live updates"
    : "INT8 · 685 MB · English · phrase updates";
  $("stt-language").disabled = !whistle;
  $("keywords").disabled = !whistle;
  settings.stt = $("stt-model").value;
  persist();
}
$("stt-model").onchange = sttOptions;
sttOptions();
function result(data) {
  if (data.text) {
    const current = $("transcript").value;
    $("transcript").value =
      current + (current && !/\s$/.test(current) ? " " : "") + data.text;
  }
  $("pending").textContent = data.pending || "";
}
$("microphone").onclick = () => {
  if (mic) {
    $("mic-label").textContent = "Finishing…";
    void mic
      .stop()
      .then(() => recordDone?.())
      .catch((error) => {
        tell(error.message, undefined, true);
        recordDone?.();
      });
    return;
  }
  if (busy) return;
  if (!navigator.mediaDevices?.getUserMedia) {
    tell("Microphone requires HTTPS or localhost.", undefined, true);
    return;
  }
  const context = new AudioContext();
  void context.resume();
  void run(async (e, signal) => {
    try {
      const model = $("stt-model").value;
      await e.load(model, {
        language: $("stt-language").value,
        keywords: $("keywords").value,
      });
      signal.throwIfAborted();
      const { Microphone, paintWave } = await import("./speech/microphone.js");
      signal.throwIfAborted();
      let recordError;
      const ended = new Promise((resolve) => {
        recordDone = resolve;
      });
      mic = new Microphone({
        context,
        onWave: (data) => paintWave($("wave"), data),
        onResult: result,
        onEnd: () => recordDone?.(),
        onError: (error) => {
          recordError = error;
          tell(error.message, undefined, true);
        },
      });
      await mic.start(e, { stream: model === "whistle" });
      signal.throwIfAborted();
      $("microphone").classList.add("recording");
      $("microphone").setAttribute("aria-label", "Stop microphone");
      $("mic-label").textContent = "Listening · tap to stop";
      await ended;
      $("pending").textContent = "";
      if (recordError) throw recordError;
    } finally {
      if (context.state !== "closed") void context.close();
    }
  });
};
async function upload(file) {
  if (!file) return;
  await run(async (e, signal) => {
    const model = $("stt-model").value;
    await e.load(model, {
      language: $("stt-language").value,
      keywords: $("keywords").value,
    });
    const { audioFile } = await import("./speech/media.js");
    let processed = 0;
    for await (const pcm of audioFile(file, {
      signal,
      seconds: model === "whistle" ? 20 : 24,
    })) {
      signal.throwIfAborted();
      const seconds = pcm.length / 16000;
      result(await e.call("transcribe", { pcm }, [pcm.buffer]));
      processed += seconds;
      tell(
        `Transcribed ${Math.floor(processed / 60)}:${String(Math.floor(processed % 60)).padStart(2, "0")} · ${file.name}`,
      );
    }
  });
  sttOptions();
}
$("audio-file").onchange = () => {
  const file = $("audio-file").files[0];
  $("audio-file").value = "";
  void upload(file);
};
$("drop").ondragover = (e) => {
  e.preventDefault();
  $("drop").classList.add("over");
};
$("drop").ondragleave = () => $("drop").classList.remove("over");
$("drop").ondrop = (e) => {
  e.preventDefault();
  $("drop").classList.remove("over");
  if (!busy) void upload(e.dataTransfer.files[0]);
};
$("clear-transcript").onclick = () => {
  $("transcript").value = "";
  $("pending").textContent = "";
};
$("copy-transcript").onclick = () => copy($("transcript").value);
$("save-transcript").onclick = () =>
  save(
    new Blob([$("transcript").value], { type: "text/plain;charset=utf-8" }),
    "transcript.txt",
  );
$("use-translation").onclick = () => {
  const text = $("transcript").value;
  mode("translate");
  $("document").value = text;
  $("document").focus();
};
for (const id of ["from", "to"]) {
  for (const [value, label] of languages) $(id).add(new Option(label, value));
  $(id).value = settings[id] || (id === "from" ? "detect" : "en");
  $(id).onchange = () => {
    settings[id] = $(id).value;
    persist();
    resetPrompt();
  };
}
function resetPrompt() {
  $("prompt").value = translationPrompt($("from").value, $("to").value);
}
$("reset-prompt").onclick = resetPrompt;
resetPrompt();
$("translate-run").onclick = () => {
  const text = $("document").value,
    from = $("from").value,
    to = $("to").value,
    system = $("prompt").value;
  if (!text.trim()) {
    tell("Enter or open a document.", undefined, true);
    return;
  }
  void run(async (e, signal) => {
    await e.load("needle");
    const data = await e.call("request", {
      text,
      system,
      tools: translationTools,
    });
    signal.throwIfAborted();
    const output = validatedRequest(data, text, from, to);
    requestJSON = JSON.stringify(output, null, 2);
    $("request-json").textContent = requestJSON;
    $("request-output").hidden = false;
  });
};
$("document").onkeydown = (e) => {
  if (e.key === "Enter" && (e.ctrlKey || e.metaKey)) {
    e.preventDefault();
    if (!busy) $("translate-run").click();
  }
};
$("copy-request").onclick = () => copy(requestJSON);
$("save-request").onclick = () =>
  save(
    new Blob([requestJSON], { type: "application/json" }),
    "translate-request.json",
  );
window.addEventListener("pagehide", () => {
  cancel();
  closeAudio();
});
"""

let render() = file
