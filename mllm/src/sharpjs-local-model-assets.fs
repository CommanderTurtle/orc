module MLLM.Src.LocalModelAssetsJs

let file = """import { MODEL_FILES, MODEL_CACHE } from "./local-model-catalog.js";

export async function modelBytes(file, progress) {
  const entry = MODEL_FILES[file];
  if (!entry) throw Error(`Unpinned model file: ${file}`);
  let cache;
  try { cache = await caches.open(MODEL_CACHE); } catch { /* Private browsing can disable persistent storage. */ }
  let response = await cache?.match(entry.url);
  const cached = Boolean(response);
  if (!response) {
    const signal = AbortSignal.timeout(15 * 60_000);
    const local = new URL(`../models/${file === "needle3.cact" ? "needle3" : "bonsai1.7b"}/${file}`, import.meta.url);
    try { response = await fetch(local, { credentials: "omit", signal }); } catch { /* A missing optional mirror can fall back to the pinned host. */ }
    if (!response?.ok || response.headers.get("content-type")?.includes("text/html")) {
      await response?.body?.cancel();
      response = await fetch(entry.url, { mode: "cors", credentials: "omit", referrerPolicy: "no-referrer", signal });
    }
  }
  if (!response.ok || !response.body) throw Error(`Model download failed (${response.status}): ${file}`);
  const data = new Uint8Array(entry.size);
  const reader = response.body.getReader();
  let offset = 0, last = 0;
  try {
    for (;;) {
      const { done, value } = await reader.read();
      if (done) break;
      if (offset + value.length > data.length) throw Error(`Unexpected model size: ${file}`);
      data.set(value, offset); offset += value.length;
      if (performance.now() - last > 100 || offset === data.length) {
        last = performance.now(); progress?.(`${cached ? "Reading cache" : "Downloading"} · ${file}`, offset / data.length);
      }
    }
    if (offset !== entry.size) throw Error(`Incomplete model file: ${file}`);
    progress?.(`Verifying · ${file}`);
    const digest = new Uint8Array(await crypto.subtle.digest("SHA-256", data));
    const hash = [...digest].map((b) => b.toString(16).padStart(2, "0")).join("");
    if (hash !== entry.sha256) throw Error(`Model integrity mismatch: ${file}. Load again to download a clean copy.`);
    if (!cached && cache) {
      try { await cache.put(entry.url, new Response(data)); }
      catch { progress?.("Browser cache full; this model is available for this session."); }
    }
    return data;
  } catch (error) {
    await cache?.delete(entry.url).catch(() => {});
    throw error;
  } finally {
    await reader.cancel().catch(() => {}); reader.releaseLock();
  }
}

export function modelFetch(progress) {
  return async (url) => {
    const file = Object.entries(MODEL_FILES).find(([, entry]) => entry.url === String(url))?.[0];
    // Optional tokenizer/config probes may miss; never fall back to unpinned weights or another precision.
    if (!file) return new Response("Unpinned model file", { status: 404 });
    return new Response(await modelBytes(file, progress), { headers: { "Content-Type": file.endsWith("json") ? "application/json" : "application/octet-stream" } });
  };
}
"""

let render() = file
