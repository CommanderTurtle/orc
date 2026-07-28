module ConvertedFiles.CountkuSwJs

let file = """const CACHE_NAME = "countku-shell-0.6.1";
const SHELL = [
  "./",
  "./manifest.webmanifest",
  "./game/countku-app.css?v=0.6.1",
  "./game/countku-app.js?v=0.6.1",
  "./game/countku-content.js?v=0.6.1",
  "./game/countku-dialogue.js?v=0.6.1",
  "./game/countku-state.js?v=0.6.1",
  "./game/countku-sound.js?v=0.6.1",
  "./game/countku-music.js?v=0.6.1",
  "./game/countku-score.js?v=0.6.1",
  "./game/countku-wisdom.js?v=0.6.1",
  "./game/countku-worlds.js?v=0.6.1",
  "./game/assets/countku-mark.svg",
  "./game/assets/skeptical-scholar.svg",
  "./game/assets/cc0-ninja-adventure/coin.gif",
  "./game/assets/cc0-ninja-adventure/flower.gif",
  "./game/assets/cc0-ninja-adventure/scroll.png",
  "./game/assets/cc0-ninja-adventure/treasure-chest.png"
];

self.addEventListener("install", (event) => {
  event.waitUntil(
    caches.open(CACHE_NAME).then((cache) => cache.addAll(SHELL))
  );
});

self.addEventListener("activate", (event) => {
  event.waitUntil(
    caches
      .keys()
      .then((names) =>
        Promise.all(
          names
            .filter((name) => name.startsWith("countku-shell-"))
            .filter((name) => name !== CACHE_NAME)
            .map((name) => caches.delete(name))
        )
      )
      .then(() => self.clients.claim())
  );
});

self.addEventListener("fetch", (event) => {
  const { request } = event;
  if (request.method !== "GET") return;

  const url = new URL(request.url);
  if (url.origin !== self.location.origin) return;

  if (request.mode === "navigate") {
    event.respondWith(
      fetch(request)
        .then((response) => {
          if (response.ok) {
            const copy = response.clone();
            caches.open(CACHE_NAME).then((cache) => cache.put("./", copy));
          }
          return response;
        })
        .catch(() => caches.match("./"))
    );
    return;
  }

  event.respondWith(
    caches.match(request).then((cached) => {
      const refreshed = fetch(request)
        .then((response) => {
          if (response.ok) {
            const copy = response.clone();
            caches.open(CACHE_NAME).then((cache) => cache.put(request, copy));
          }
          return response;
        })
        .catch(() => cached);
      return cached ?? refreshed;
    })
  );
});
"""

let render() = file
