module ConvertedFiles.CountkuAppJs

let file = """import {
  ACHIEVEMENTS,
  COSMETICS,
  DAILY_QUESTS,
  DIALOGUE_CATEGORIES,
  ENCOUNTERS,
  FILLER_PHRASES,
  OPERATION_FAMILIES,
  ORDINAL_SYNONYMS,
  QUESTS,
  WEEKLY_QUESTS
} from "./countku-content.js?v=0.6.1";
import { CountkuAmbientScore } from "./countku-music.js?v=0.6.1";
import { CountkuSoundPalette } from "./countku-sound.js?v=0.6.1";
import { CountkuPlayerStore } from "./countku-state.js?v=0.6.1";
import {
  ADVISOR_BANK,
  advisorAtLevel,
  fieldMessageAtLevel
} from "./countku-wisdom.js?v=0.6.1";
import {
  AUTHORED_WORLDS,
  applyWorldPalette,
  nextWorldForCount,
  worldForCount
} from "./countku-worlds.js?v=0.6.1";

const APP_VERSION = "0.6.1";
const playerStore = new CountkuPlayerStore();
let player = playerStore.snapshot();
const sounds = new CountkuSoundPalette(
  player.preferences.sound,
  player.preferences.effectsVolume
);
const music = new CountkuAmbientScore({
  enabled: player.preferences.music,
  volume: player.preferences.musicVolume,
  progress: player.lifetimeCorrect,
  movement: player.preferences.musicMovement
});

const originalTitle = document.querySelector(".game-title")?.textContent ?? "";
const body = document.body;
const input = document.getElementById("gameInput");
const helpContentElement = document.getElementById("helpContent");
const helpModal = document.getElementById("helpModal");
const haikuDisplay = document.getElementById("haikuDisplay");
const debugConsole = document.getElementById("debugConsole");

let activePanel = null;
let activeEncounter = null;
let activeLearnCategory = "all";
let pendingPurchase = null;
let pendingReset = false;
let toastTimer = null;
let previewTimer = null;
let previewItem = null;
let revealTimer = null;
let queuedEncounter = null;
let encounterTypeTimer = null;
let encounterTypeToken = 0;
let deferredInstallPrompt = null;

const app = document.createElement("div");
app.className = "ck-app";
app.hidden = true;
app.innerHTML = `
  <header class="ck-hud" aria-label="Countku trail status">
    <div class="ck-hud__identity">
      <span class="ck-hud__mark" aria-hidden="true">句</span>
      <span class="ck-hud__copy">
        <strong id="ckWorld">Sakura Trail</strong>
        <span id="ckRank">Trail Novice</span>
      </span>
    </div>
    <div class="ck-hud__wallet">
      <span class="ck-coin-sprite" aria-hidden="true"></span>
      <strong id="ckCoins">0</strong>
      <span class="ck-hud__streak" id="ckStreak">· streak 0</span>
      <button
        class="ck-icon-button ck-music-button"
        type="button"
        data-music-control
        aria-label="Start Countku ambient score"
        aria-pressed="false"
      >♫</button>
      <button
        class="ck-icon-button"
        type="button"
        data-open-panel="settings"
        aria-label="Open Countku settings"
      >⚙</button>
    </div>
  </header>

  <nav class="ck-nav" aria-label="Countku game sections">
    <button type="button" data-open-panel="trail" aria-pressed="false">
      道<span>Trail</span>
    </button>
    <button type="button" data-open-panel="quests" aria-pressed="false">
      任<span>Quests</span>
    </button>
    <button type="button" data-open-panel="collection" aria-pressed="false">
      蔵<span>Collection</span>
    </button>
    <button type="button" data-open-panel="learn" aria-pressed="false">
      学<span>Learn</span>
    </button>
  </nav>

  <section
    class="ck-panel"
    id="ckPanel"
    aria-label="Countku game panel"
    hidden
  >
    <header class="ck-panel__header">
      <h2 id="ckPanelTitle">Trail</h2>
      <button
        type="button"
        class="ck-icon-button"
        data-close-panel
        aria-label="Close panel"
      >×</button>
    </header>
    <div class="ck-panel__body" id="ckPanelBody"></div>
  </section>

  <div class="ck-toast" id="ckToast" role="status" aria-live="polite" hidden></div>

  <section
    class="ck-stage-reveal"
    id="ckStageReveal"
    role="dialog"
    aria-modal="true"
    aria-labelledby="ckStageRevealTitle"
    hidden
  >
    <div class="ck-stage-reveal__card">
      <i class="ck-flower ck-flower--one" aria-hidden="true"></i>
      <i class="ck-flower ck-flower--two" aria-hidden="true"></i>
      <span class="ck-stage-reveal__eyebrow">The trail changes</span>
      <strong class="ck-stage-reveal__sigil" id="ckStageRevealSigil">道</strong>
      <h2 id="ckStageRevealTitle">New trail rank</h2>
      <p id="ckStageRevealCopy"></p>
      <div class="ck-stage-reveal__reward">
        <span class="ck-chest-sprite is-open" aria-hidden="true"></span>
        <span>New world palette and score movement unlocked</span>
      </div>
      <button class="ck-action" type="button" data-close-stage>
        Continue
      </button>
    </div>
  </section>

  <article
    class="ck-encounter"
    id="ckEncounter"
    aria-label="Scholar encounter"
    hidden
  >
    <div class="ck-encounter__portrait">
      <span class="ck-encounter__sigil" id="ckEncounterSigil" aria-hidden="true">問</span>
      <img
        src="game/assets/skeptical-scholar.svg"
        alt="The skeptical scholar"
      >
    </div>
    <div class="ck-encounter__copy" id="ckEncounterCopy"></div>
  </article>

  <input id="ckImportFile" type="file" accept="application/json,.json" hidden>
`;
document.body.appendChild(app);

const panel = document.getElementById("ckPanel");
const panelTitle = document.getElementById("ckPanelTitle");
const panelBody = document.getElementById("ckPanelBody");
const toastElement = document.getElementById("ckToast");
const encounterElement = document.getElementById("ckEncounter");
const encounterCopy = document.getElementById("ckEncounterCopy");
const encounterSigil = document.getElementById("ckEncounterSigil");
const importFile = document.getElementById("ckImportFile");
const rankElement = document.getElementById("ckRank");
const worldElement = document.getElementById("ckWorld");
const coinsElement = document.getElementById("ckCoins");
const streakElement = document.getElementById("ckStreak");
const musicButton = app.querySelector("[data-music-control]");
const stageReveal = document.getElementById("ckStageReveal");
const stageRevealSigil = document.getElementById("ckStageRevealSigil");
const stageRevealTitle = document.getElementById("ckStageRevealTitle");
const stageRevealCopy = document.getElementById("ckStageRevealCopy");

const htmlEscape = (value) =>
  String(value)
    .replaceAll("&", "&amp;")
    .replaceAll("<", "&lt;")
    .replaceAll(">", "&gt;")
    .replaceAll('"', "&quot;")
    .replaceAll("'", "&#039;");

const categoryLabel = (value) =>
  value
    .replaceAll("-", " ")
    .replace(/\b\w/g, (letter) => letter.toUpperCase());

const objectiveBanner = document.createElement("button");
objectiveBanner.type = "button";
objectiveBanner.className = "ck-objective";
objectiveBanner.hidden = true;
objectiveBanner.setAttribute("aria-label", "Open today’s Countku mission");
document.querySelector(".game-title")?.after(objectiveBanner);

const readCurrentNumber = () =>
  Number(document.getElementById("currentNumber")?.textContent ?? "0");

const readStreak = () =>
  Number(document.getElementById("streakValue")?.textContent ?? "0");

const localDateKey = (date = new Date()) => {
  const year = date.getFullYear();
  const month = String(date.getMonth() + 1).padStart(2, "0");
  const day = String(date.getDate()).padStart(2, "0");
  return `${year}-${month}-${day}`;
};

const localWeekKey = (date = new Date()) => {
  const monday = new Date(date.getFullYear(), date.getMonth(), date.getDate());
  const daysSinceMonday = (monday.getDay() + 6) % 7;
  monday.setDate(monday.getDate() - daysSinceMonday);
  return localDateKey(monday);
};

const stableIndex = (value, length) => {
  let hash = 2166136261;
  for (const character of value) {
    hash ^= character.charCodeAt(0);
    hash = Math.imul(hash, 16777619);
  }
  return Math.abs(hash) % length;
};

const compositionKey = (inputText, target) =>
  `${target}:${inputText.trim().toLowerCase().replace(/\s+/g, " ")}`;

const PROGRESSION_STAGES = Object.freeze([
  {
    id: "novice",
    className: "stage-novice",
    minimum: 0,
    label: "Trail Novice",
    sigil: "芽",
    description: "Begin with exact landings and hear the first quiet motif."
  },
  {
    id: "apprentice",
    className: "stage-apprentice",
    minimum: 3,
    label: "Trail Apprentice",
    sigil: "竹",
    description: "A bamboo dawn opens after three distinct compositions."
  },
  {
    id: "verse",
    className: "stage-verse",
    minimum: 10,
    label: "Verse Walker",
    sigil: "詩",
    description: "The trail grows warmer and the melody begins to answer."
  },
  {
    id: "adept",
    className: "stage-adept",
    minimum: 25,
    label: "Sakura Adept",
    sigil: "桜",
    description: "Autumn light and deeper customization enter the world."
  },
  {
    id: "moon",
    className: "stage-moon",
    minimum: 50,
    label: "Moon Scholar",
    sigil: "月",
    description: "The score slows beneath an indigo, long-horizon sky."
  },
  {
    id: "sage",
    className: "stage-sage",
    minimum: 100,
    label: "Wasan Sage",
    sigil: "算",
    description: "The full palette settles into patient wasan green and gold."
  }
]);

const PROGRESSION_STAGE_CLASSES = PROGRESSION_STAGES.map(
  (stage) => stage.className
);

function stageFor(correct) {
  for (let index = PROGRESSION_STAGES.length - 1; index >= 0; index -= 1) {
    if (correct >= PROGRESSION_STAGES[index].minimum) {
      return PROGRESSION_STAGES[index];
    }
  }
  return PROGRESSION_STAGES[0];
}

function ensureDailyQuest() {
  const today = localDateKey();
  const latest = player.latestDailyDate;
  const shouldAdvance = !latest || today > latest;
  const missing = !player.daily;

  if (!missing && !shouldAdvance) return player.daily;

  const effectiveDate =
    latest && today < latest
      ? latest
      : today;
  const quest = DAILY_QUESTS[
    stableIndex(effectiveDate, DAILY_QUESTS.length)
  ];

  playerStore.update((draft) => {
    draft.daily = {
      date: effectiveDate,
      questId: quest.id,
      progress: 0,
      complete: false,
      claimed: false
    };
    draft.latestDailyDate = effectiveDate;
  });
  player = playerStore.snapshot();
  return player.daily;
}

function dailyQuestModel() {
  const daily = ensureDailyQuest();
  const quest = DAILY_QUESTS.find((item) => item.id === daily.questId);
  return { daily, quest };
}

function ensureWeeklyQuest() {
  const thisWeek = localWeekKey();
  const latest = player.latestWeeklyKey;
  const shouldAdvance = !latest || thisWeek > latest;
  const missing = !player.weekly;

  if (!missing && !shouldAdvance) return player.weekly;

  const effectiveWeek =
    latest && thisWeek < latest
      ? latest
      : thisWeek;
  const quest = WEEKLY_QUESTS[
    stableIndex(effectiveWeek, WEEKLY_QUESTS.length)
  ];

  playerStore.update((draft) => {
    draft.weekly = {
      week: effectiveWeek,
      questId: quest.id,
      progress: 0,
      complete: false,
      claimed: false
    };
    draft.latestWeeklyKey = effectiveWeek;
  });
  player = playerStore.snapshot();
  return player.weekly;
}

function weeklyQuestModel() {
  const weekly = ensureWeeklyQuest();
  const quest = WEEKLY_QUESTS.find((item) => item.id === weekly.questId);
  return { weekly, quest };
}

function rankFor(correct) {
  return stageFor(correct).label;
}

function applyProgressionStage() {
  const stage = stageFor(player.lifetimeCorrect);
  const world = worldForCount(player.lifetimeCorrect);
  body.classList.remove(...PROGRESSION_STAGE_CLASSES);
  body.classList.add(stage.className);
  body.dataset.countkuStage = stage.id;
  body.dataset.countkuWorld = world.id;
  applyWorldPalette(body, world);
  sounds.setStage(stage.id);
  music.setProgress(player.lifetimeCorrect);
  if (!music.setMovement(player.preferences.musicMovement)) {
    music.setMovement("auto");
  }
  worldElement.textContent = world.label;
  const title = document.querySelector(".game-title");
  if (title && body.dataset.countkuMode === "countku") {
    title.textContent = `COUNTKU // ${world.label.toUpperCase()}`;
  }
}

function applyEquippedCosmetics() {
  const classes = COSMETICS.map((item) => item.className);
  body.classList.remove(...classes);
  const active = {
    avatar: COSMETICS.find(
      (item) => item.id === player.equipped.avatar
    ),
    trail: COSMETICS.find(
      (item) => item.id === player.equipped.trail
    ),
    effect: COSMETICS.find(
      (item) => item.id === player.equipped.effect
    )
  };
  if (previewItem) active[previewItem.kind] = previewItem;
  Object.values(active).forEach((item) => {
    if (item) body.classList.add(item.className);
  });
}

function updateHud() {
  player = playerStore.snapshot();
  coinsElement.textContent = String(player.coins);
  rankElement.textContent = rankFor(player.lifetimeCorrect);
  streakElement.textContent = `· streak ${readStreak()}`;
  sounds.setEnabled(player.preferences.sound);
  sounds.setVolume(player.preferences.effectsVolume);
  music.setEnabled(player.preferences.music);
  music.setVolume(player.preferences.musicVolume);
  musicButton.setAttribute(
    "aria-pressed",
    String(player.preferences.music && music.playing)
  );
  musicButton.setAttribute(
    "aria-label",
    music.playing
      ? "Pause Countku ambient score"
      : "Start Countku ambient score"
  );
  musicButton.classList.toggle("is-playing", music.playing);
  body.classList.toggle(
    "effects-reduced",
    player.preferences.reducedEffects
  );
  applyProgressionStage();
  applyEquippedCosmetics();
  updateObjective();
}

function updateObjective() {
  const { daily, quest } = dailyQuestModel();
  objectiveBanner.innerHTML = `
    <span>Today</span>
    <strong>${htmlEscape(quest.title)}</strong>
    <em>${Math.min(daily.progress, quest.goal)}/${quest.goal}</em>
  `;
}

function showToast(message) {
  if (toastTimer) window.clearTimeout(toastTimer);
  toastElement.textContent = message;
  toastElement.hidden = false;
  toastTimer = window.setTimeout(() => {
    toastElement.hidden = true;
  }, 3200);
}

function closeStageReveal() {
  if (revealTimer) window.clearTimeout(revealTimer);
  revealTimer = null;
  stageReveal.hidden = true;
  if (queuedEncounter && encounterElement.hidden) {
    const queued = queuedEncounter;
    queuedEncounter = null;
    window.setTimeout(
      () => showEncounter(queued.encounter, queued.options),
      260
    );
  }
}

function showStageReveal(world) {
  if (!world || stageReveal.hidden === false) return;
  stageRevealSigil.textContent = world.sigil;
  stageRevealTitle.textContent = world.label;
  stageRevealCopy.textContent = world.description;
  stageReveal.dataset.world = world.id;
  stageReveal.hidden = false;
  music.accent();
  revealTimer = window.setTimeout(closeStageReveal, 5400);
}

function questState(id) {
  return player.quests[id] ?? {
    complete: false,
    claimed: false
  };
}

function achievementState(id) {
  return player.achievements[id] ?? {
    unlocked: false
  };
}

function renderTrailPanel() {
  const unlocked = ACHIEVEMENTS.filter(
    (item) => achievementState(item.id).unlocked
  ).length;
  const completeQuests = QUESTS.filter(
    (item) => questState(item.id).complete
  ).length;
  const operationCount = player.operationFamilies.length;
  const currentStage = stageFor(player.lifetimeCorrect);
  const currentWorld = worldForCount(player.lifetimeCorrect);
  const nextWorld = nextWorldForCount(player.lifetimeCorrect);
  const worldSpan = Math.max(1, nextWorld.minimum - currentWorld.minimum);
  const worldProgress = Math.min(
    100,
    ((player.lifetimeCorrect - currentWorld.minimum) / worldSpan) * 100
  );
  const worldMap = currentWorld.minimum >= 105
    ? [...AUTHORED_WORLDS, currentWorld]
    : AUTHORED_WORLDS;
  const mastery =
    player.operationFamilies.length > 0
      ? player.operationFamilies
          .map((name) => `<span class="ck-chip">${htmlEscape(name)}</span>`)
          .join("")
      : `<span class="ck-muted">No operation families recorded yet.</span>`;

  return `
    <p class="ck-section-intro">
      Progress is local to this browser. Compose, learn, and spend only what
      the trail awards.
    </p>
    <section class="ck-journey" aria-label="Countku worlds">
      <header class="ck-journey__header">
        <span>
          <em>${htmlEscape(currentStage.label)}</em>
          <strong>${htmlEscape(currentWorld.label)}</strong>
        </span>
        <span class="ck-journey__next">
          ${player.lifetimeCorrect}/${nextWorld.minimum} to
          ${htmlEscape(nextWorld.label)}
        </span>
      </header>
      <div
        class="ck-progress ck-progress--journey"
        role="progressbar"
        aria-label="Progress to the next Countku world"
        aria-valuemin="0"
        aria-valuemax="100"
        aria-valuenow="${Math.round(worldProgress)}"
      >
        <span style="width:${worldProgress}%"></span>
      </div>
      <ol class="ck-stage-map">
        ${worldMap.map((world, index) => {
          const reached = player.lifetimeCorrect >= world.minimum;
          const current = world.id === currentWorld.id;
          return `
            <li data-reached="${reached}" data-current="${current}">
              <span
                class="ck-chest-sprite ${reached ? "is-open" : ""}"
                aria-hidden="true"
              ></span>
              <span>
                <strong>${htmlEscape(world.sigil)} ${htmlEscape(world.label)}</strong>
                <em>${index === 0 ? "Beginning" : `${world.minimum} landings`}</em>
              </span>
            </li>
          `;
        }).join("")}
      </ol>
    </section>
    <div class="ck-card-grid">
      <article class="ck-card">
        <span class="ck-card__eyebrow">Lifetime</span>
        <h3>${player.lifetimeCorrect} valid Countku</h3>
        <p>Best streak ${player.bestStreak} · ${operationCount} operation families.</p>
      </article>
      <article class="ck-card">
        <span class="ck-card__eyebrow">Journey</span>
        <h3>${completeQuests}/${QUESTS.length} quests complete</h3>
        <p>${unlocked}/${ACHIEVEMENTS.length} achievements discovered.</p>
      </article>
      <article class="ck-card">
        <span class="ck-card__eyebrow">Operation mastery</span>
        <h3>${operationCount}/8 families discovered</h3>
        <div class="ck-chip-row">${mastery}</div>
      </article>
      ${ACHIEVEMENTS.map((achievement) => {
        const state = achievementState(achievement.id);
        return `
          <article
            class="ck-card"
            data-complete="${state.unlocked}"
            data-locked="${!state.unlocked}"
          >
            <span class="ck-card__eyebrow">
              ${state.unlocked ? "Achievement" : "Undiscovered"}
            </span>
            <h3>${htmlEscape(achievement.title)}</h3>
            <p>${htmlEscape(achievement.description)}</p>
            <div class="ck-card__footer">
              <span class="ck-reward">◉ ${achievement.reward}</span>
              <span>${state.unlocked ? "Unlocked" : "In progress"}</span>
            </div>
          </article>
        `;
      }).join("")}
    </div>
    <div class="ck-panel-actions">
      <button class="ck-action ck-action--secondary" type="button" data-share>
        Share a text summary
      </button>
    </div>
  `;
}

function renderQuestsPanel() {
  const { daily, quest: dailyQuest } = dailyQuestModel();
  const { weekly, quest: weeklyQuest } = weeklyQuestModel();
  const dailyButton = daily.claimed
    ? `<button class="ck-action" type="button" disabled>Claimed</button>`
    : daily.complete
      ? `<button class="ck-action" type="button" data-claim-daily>Claim</button>`
      : `<button class="ck-action ck-action--secondary" type="button" disabled>In progress</button>`;
  const weeklyButton = weekly.claimed
    ? `<button class="ck-action" type="button" disabled>Claimed</button>`
    : weekly.complete
      ? `<button class="ck-action" type="button" data-claim-weekly>Claim</button>`
      : `<button class="ck-action ck-action--secondary" type="button" disabled>In progress</button>`;

  return `
    <p class="ck-section-intro">
      Daily and weekly paths rotate from your local calendar. Trail quests
      remain until claimed; no account or server is involved.
    </p>
    <div class="ck-card-grid">
      <article class="ck-card ck-card--daily" data-complete="${daily.complete}">
        <span class="ck-card__eyebrow">Daily mission · ${daily.date}</span>
        <h3>${htmlEscape(dailyQuest.title)}</h3>
        <p>${htmlEscape(dailyQuest.description)}</p>
        <div
          class="ck-progress"
          role="progressbar"
          aria-label="${htmlEscape(dailyQuest.title)} progress"
          aria-valuemin="0"
          aria-valuemax="${dailyQuest.goal}"
          aria-valuenow="${Math.min(daily.progress, dailyQuest.goal)}"
        >
          <span style="width:${Math.min(100, (daily.progress / dailyQuest.goal) * 100)}%"></span>
        </div>
        <div class="ck-card__footer">
          <span class="ck-reward">
            ${Math.min(daily.progress, dailyQuest.goal)}/${dailyQuest.goal} · ◉ ${dailyQuest.reward}
          </span>
          ${dailyButton}
        </div>
      </article>
      <article class="ck-card ck-card--weekly" data-complete="${weekly.complete}">
        <span class="ck-scroll-sprite" aria-hidden="true"></span>
        <span class="ck-card__eyebrow">Seven-day path · week of ${weekly.week}</span>
        <h3>${htmlEscape(weeklyQuest.title)}</h3>
        <p>${htmlEscape(weeklyQuest.description)}</p>
        <div
          class="ck-progress"
          role="progressbar"
          aria-label="${htmlEscape(weeklyQuest.title)} progress"
          aria-valuemin="0"
          aria-valuemax="${weeklyQuest.goal}"
          aria-valuenow="${Math.min(weekly.progress, weeklyQuest.goal)}"
        >
          <span style="width:${Math.min(100, (weekly.progress / weeklyQuest.goal) * 100)}%"></span>
        </div>
        <div class="ck-card__footer">
          <span class="ck-reward">
            ${Math.min(weekly.progress, weeklyQuest.goal)}/${weeklyQuest.goal} · ◉ ${weeklyQuest.reward}
          </span>
          ${weeklyButton}
        </div>
      </article>
      ${QUESTS.map((quest) => {
        const state = questState(quest.id);
        const button = state.claimed
          ? `<button class="ck-action" type="button" disabled>Claimed</button>`
          : state.complete
            ? `<button class="ck-action" type="button" data-claim-quest="${quest.id}">Claim</button>`
            : `<button class="ck-action ck-action--secondary" type="button" disabled>In progress</button>`;
        return `
          <article class="ck-card" data-complete="${state.complete}">
            <span class="ck-card__eyebrow">Trail quest</span>
            <h3>${htmlEscape(quest.title)}</h3>
            <p>${htmlEscape(quest.description)}</p>
            <div class="ck-card__footer">
              <span class="ck-reward">◉ ${quest.reward}</span>
              ${button}
            </div>
          </article>
        `;
      }).join("")}
    </div>
  `;
}

function cosmeticButton(item) {
  const unlocked = player.unlocked.includes(item.id);
  const equipped = player.equipped[item.kind] === item.id;
  const minimum = Number(item.minimum || 0);
  if (equipped) {
    return `<button class="ck-action" type="button" disabled>Equipped</button>`;
  }
  if (unlocked) {
    return `
      <button class="ck-action" type="button" data-equip="${item.id}">
        Equip
      </button>
    `;
  }
  if (player.lifetimeCorrect < minimum) {
    return `
      <button class="ck-action ck-action--secondary" type="button" disabled>
        Rank path · ${minimum}
      </button>
    `;
  }
  const confirming = pendingPurchase === item.id;
  return `
    <button class="ck-action" type="button" data-buy="${item.id}">
      ${confirming ? `Confirm ◉ ${item.price}` : `Unlock ◉ ${item.price}`}
    </button>
  `;
}

function renderCollectionPanel() {
  return `
    <p class="ck-section-intro">
      Preview freely. Unlocks use earned coins and remain on this device.
    </p>
    <div class="ck-card-grid">
      ${COSMETICS.map((item) => {
        const unlocked = player.unlocked.includes(item.id);
        const rankLocked =
          !unlocked && player.lifetimeCorrect < Number(item.minimum || 0);
        return `
          <article class="ck-card" data-locked="${rankLocked}">
            <span class="ck-card__eyebrow">
              ${htmlEscape(item.kind)}
              ${rankLocked ? ` · path ${item.minimum}` : ""}
            </span>
            <h3>${htmlEscape(item.title)}</h3>
            <p>${htmlEscape(item.description)}</p>
            <div class="ck-store-actions">
              <button
                class="ck-action ck-action--secondary"
                type="button"
                data-preview="${item.id}"
              >Preview</button>
              ${cosmeticButton(item)}
            </div>
          </article>
        `;
      }).join("")}
    </div>
  `;
}

function renderLearnPanel() {
  const unlockedAdvisors = ADVISOR_BANK.filter(
    (encounter) => player.lifetimeCorrect >= encounter.unlockAt
  );
  const recentAdvisors = unlockedAdvisors.slice(-8).reverse();
  const nextAdvisor = ADVISOR_BANK.find(
    (encounter) => player.lifetimeCorrect < encounter.unlockAt
  );
  const categoryEntries =
    activeLearnCategory === "all"
      ? ENCOUNTERS
      : ENCOUNTERS.filter(
          (encounter) => encounter.category === activeLearnCategory
        );
  const availableEntries = categoryEntries.filter(
    (encounter) => player.lifetimeCorrect >= encounter.unlockAt
  );
  const lockedEntries = categoryEntries.filter(
    (encounter) => player.lifetimeCorrect < encounter.unlockAt
  );
  const nextEntries =
    activeLearnCategory === "all"
      ? DIALOGUE_CATEGORIES.map((category) =>
          lockedEntries.find((encounter) => encounter.category === category)
        ).filter(Boolean)
      : lockedEntries.slice(0, 2);
  const visibleEntries = [...availableEntries, ...nextEntries];
  const unlockedCount = ENCOUNTERS.filter(
    (encounter) => player.lifetimeCorrect >= encounter.unlockAt
  ).length;

  return `
    <p class="ck-section-intro">
      ${unlockedCount}/${ENCOUNTERS.length} trail notes and
      ${unlockedAdvisors.length}/${ADVISOR_BANK.length} advisor haiku unlocked.
      Sources remain attached to every research trail.
    </p>
    <section class="ck-advisor-library" aria-label="Advisor haiku">
      <header class="ck-subsection-header">
        <span>
          <em>Five · seven · five</em>
          <strong>Advisor field book</strong>
        </span>
        <span>
          ${nextAdvisor
            ? `Next meeting at ${nextAdvisor.unlockAt}`
            : "The full field book is open"}
        </span>
      </header>
      <div class="ck-card-grid">
        ${recentAdvisors.length
          ? recentAdvisors.map((encounter) => `
              <article class="ck-card">
                <span class="ck-card__eyebrow">
                  ${htmlEscape(encounter.sigil)} · ${htmlEscape(encounter.persona)}
                </span>
                <h3>${htmlEscape(encounter.title)}</h3>
                <p class="ck-haiku-lines">${encounter.lines
                  .map((line) => htmlEscape(line))
                  .join("<br>")}</p>
                <div class="ck-card__footer">
                  <span>Landing ${encounter.unlockAt}</span>
                  <button class="ck-action" type="button" data-read="${encounter.id}">
                    Read
                  </button>
                </div>
              </article>
            `).join("")
          : `<p class="ck-muted">The first advisor arrives at five exact landings.</p>`}
      </div>
    </section>
    <div class="ck-filter-row" role="group" aria-label="Filter trail notes">
      ${["all", ...DIALOGUE_CATEGORIES].map((category) => `
        <button
          class="ck-filter"
          type="button"
          data-learn-category="${category}"
          aria-pressed="${activeLearnCategory === category}"
        >${category === "all" ? "All" : htmlEscape(categoryLabel(category))}</button>
      `).join("")}
    </div>
    <div class="ck-card-grid">
      ${visibleEntries.map((encounter) => {
        const available = player.lifetimeCorrect >= encounter.unlockAt;
        const seen = Boolean(player.encountersSeen[encounter.id]);
        return `
          <article class="ck-card" data-locked="${!available}">
            <span class="ck-card__eyebrow">
              ${available
                ? `${htmlEscape(encounter.sigil)} · ${htmlEscape(encounter.persona)}`
                : `Unlocks at ${encounter.unlockAt}`}
            </span>
            <h3>${available ? htmlEscape(encounter.title) : "Untraveled page"}</h3>
            <p>
              ${available
                ? htmlEscape(encounter.body)
                : `Continue the trail to reveal this ${htmlEscape(
                    categoryLabel(encounter.category)
                  ).toLowerCase()} note.`}
            </p>
            ${available
              ? `<div class="ck-card__footer">
                  <span>${seen ? "Read" : "New"} · ${
                    encounter.sourceKind === "institutional"
                      ? "Sourced"
                      : "Original"
                  }</span>
                  <button class="ck-action" type="button" data-read="${encounter.id}">
                    Read
                  </button>
                </div>`
              : ""}
          </article>
        `;
      }).join("")}
    </div>
  `;
}

function renderSettingsPanel() {
  return `
    <p class="ck-section-intro">
      Countku stores progress locally and sends no play data anywhere.
    </p>
    <div class="ck-settings">
      <div class="ck-setting">
        <span>
          <strong>Result chimes</strong>
          <small>Original, rank-sensitive synthesis</small>
        </span>
        <button
          class="ck-toggle"
          type="button"
          role="switch"
          aria-label="Toggle Countku sounds"
          aria-checked="${player.preferences.sound}"
          data-toggle="sound"
        ></button>
      </div>
      <label class="ck-setting ck-setting--range">
        <span>
          <strong>Chime volume</strong>
          <small>Only success and reset feedback</small>
        </span>
        <span class="ck-range-control">
          <input
            type="range"
            min="0"
            max="100"
            step="1"
            value="${Math.round(player.preferences.effectsVolume * 100)}"
            data-volume="effects"
            aria-label="Countku result chime volume"
          >
          <output data-volume-output="effects">${Math.round(player.preferences.effectsVolume * 100)}%</output>
        </span>
      </label>
      <section class="ck-setting ck-setting--score">
        <span>
          <strong>Trail score movement</strong>
          <small>
            New movements open every twenty landings. Auto follows the road;
            after 200, the full score remains selectable.
          </small>
        </span>
        <div class="ck-score-library" role="group" aria-label="Choose a score movement">
          <button
            class="ck-score-choice"
            type="button"
            data-movement="auto"
            aria-pressed="${player.preferences.musicMovement === "auto"}"
          >
            <strong>Auto journey</strong>
            <small>Now: ${htmlEscape(music.movement.title)}</small>
          </button>
          ${music.availableMovements.map((movement) => `
            <button
              class="ck-score-choice"
              type="button"
              data-movement="${htmlEscape(movement.id)}"
              aria-pressed="${
                player.preferences.musicMovement === movement.id
              }"
            >
              <strong>${htmlEscape(movement.title)}</strong>
              <small>${movement.minimum === 0
                ? "Opening movement"
                : `Landmark ${movement.minimum}`}</small>
            </button>
          `).join("")}
        </div>
      </section>
      <div class="ck-setting">
        <span>
          <strong>Ambient trail score</strong>
          <small>Original generative music; begins after your gesture</small>
        </span>
        <button
          class="ck-toggle"
          type="button"
          role="switch"
          aria-label="Toggle Countku ambient music"
          aria-checked="${player.preferences.music}"
          data-toggle="music"
        ></button>
      </div>
      <label class="ck-setting ck-setting--range">
        <span>
          <strong>Music volume</strong>
          <small>Sparse motifs change with trail rank</small>
        </span>
        <span class="ck-range-control">
          <input
            type="range"
            min="0"
            max="100"
            step="1"
            value="${Math.round(player.preferences.musicVolume * 100)}"
            data-volume="music"
            aria-label="Countku ambient music volume"
          >
          <output data-volume-output="music">${Math.round(player.preferences.musicVolume * 100)}%</output>
        </span>
      </label>
      <div class="ck-setting">
        <span>
          <strong>Reduced motion</strong>
          <small>Reduce petals and nonessential transitions</small>
        </span>
        <button
          class="ck-toggle"
          type="button"
          role="switch"
          aria-label="Toggle reduced effects"
          aria-checked="${player.preferences.reducedEffects}"
          data-toggle="effects"
        ></button>
      </div>
    </div>
    <div class="ck-data-actions">
      <button class="ck-action ck-action--secondary" type="button" data-onboarding>
        Replay introduction
      </button>
      ${deferredInstallPrompt
        ? `<button class="ck-action ck-action--secondary" type="button" data-install>
            Install Countku
          </button>`
        : ""}
      <button class="ck-action ck-action--secondary" type="button" data-export>
        Export save
      </button>
      <button class="ck-action ck-action--secondary" type="button" data-import>
        Import save
      </button>
      <button class="ck-action ck-action--secondary" type="button" data-reset>
        ${pendingReset ? "Confirm local reset" : "Reset local progress"}
      </button>
    </div>
  `;
}

const PANEL_TITLES = Object.freeze({
  trail: "Sakura Trail",
  quests: "Quests",
  collection: "Collection",
  learn: "Learn",
  settings: "Settings"
});

const PANEL_RENDERERS = Object.freeze({
  trail: renderTrailPanel,
  quests: renderQuestsPanel,
  collection: renderCollectionPanel,
  learn: renderLearnPanel,
  settings: renderSettingsPanel
});

function renderPanel() {
  if (!activePanel) return;
  player = playerStore.snapshot();
  panelTitle.textContent = activePanel === "trail"
    ? worldForCount(player.lifetimeCorrect).label
    : PANEL_TITLES[activePanel];
  panelBody.innerHTML = PANEL_RENDERERS[activePanel]();
}

function openPanel(name) {
  if (!PANEL_RENDERERS[name]) return;
  activePanel = name;
  pendingPurchase = null;
  pendingReset = false;
  panel.hidden = false;
  renderPanel();
  panelBody.scrollTop = 0;
  app.querySelectorAll("[data-open-panel]").forEach((button) => {
    button.setAttribute(
      "aria-pressed",
      String(button.dataset.openPanel === name)
    );
  });
}

function closePanel() {
  activePanel = null;
  pendingPurchase = null;
  pendingReset = false;
  panel.hidden = true;
  app.querySelectorAll("[data-open-panel]").forEach((button) => {
    button.setAttribute("aria-pressed", "false");
  });
  if (previewItem) {
    window.clearTimeout(previewTimer);
    showToast(`${previewItem.title} remains visible for three seconds.`);
    previewTimer = window.setTimeout(() => {
      previewItem = null;
      previewTimer = null;
      applyEquippedCosmetics();
    }, 3000);
  } else {
    applyEquippedCosmetics();
  }
}

function closeEncounter(markSeen = true) {
  encounterTypeToken += 1;
  if (encounterTypeTimer) window.clearTimeout(encounterTypeTimer);
  encounterTypeTimer = null;
  if (markSeen && activeEncounter?.id) {
    playerStore.update((draft) => {
      draft.encountersSeen[activeEncounter.id] = true;
    });
    player = playerStore.snapshot();
  }
  activeEncounter = null;
  encounterElement.hidden = true;
}

function finishEncounterTyping() {
  const typed = encounterCopy.querySelector(".ck-encounter__typed");
  if (!typed || typed.dataset.complete === "true") return false;
  encounterTypeToken += 1;
  if (encounterTypeTimer) window.clearTimeout(encounterTypeTimer);
  encounterTypeTimer = null;
  typed.textContent = typed.dataset.fullText ?? "";
  typed.dataset.complete = "true";
  return true;
}

function typeEncounterText(text) {
  const typed = encounterCopy.querySelector(".ck-encounter__typed");
  if (!typed) return;
  encounterTypeToken += 1;
  const token = encounterTypeToken;
  const reduced =
    player.preferences.reducedEffects ||
    window.matchMedia("(prefers-reduced-motion: reduce)").matches;
  typed.dataset.fullText = text;
  typed.dataset.complete = String(reduced);
  if (reduced) {
    typed.textContent = text;
    return;
  }

  typed.textContent = "";
  let index = 0;
  const write = () => {
    if (token !== encounterTypeToken || encounterElement.hidden) return;
    const stride = text.length > 150 ? 2 : 1;
    index = Math.min(text.length, index + stride);
    typed.textContent = text.slice(0, index);
    if (index >= text.length) {
      typed.dataset.complete = "true";
      encounterTypeTimer = null;
      return;
    }
    const character = text[index - 1];
    const delay = /[.!?]/.test(character)
      ? 120
      : /[,;:]/.test(character)
        ? 70
        : 23;
    encounterTypeTimer = window.setTimeout(write, delay);
  };
  write();
}

function showEncounter(
  encounter,
  { onboarding = false, kind = "advisor" } = {}
) {
  activeEncounter = onboarding ? null : encounter;
  const persona = onboarding
    ? "The skeptical scholar"
    : encounter.persona;
  const sigil = onboarding ? "問" : encounter.sigil ?? "言";
  const bodyText = onboarding
    ? "Compose mathematical English, let the trail divide it into 5-7-5, and make the result equal the next target. The keyboard stays yours."
    : encounter.body;
  const sourceMarkup =
    !onboarding && encounter.sourceUrl
      ? `<a
          class="ck-source"
          href="${htmlEscape(encounter.sourceUrl)}"
          target="_blank"
          rel="noopener noreferrer"
        >${htmlEscape(encounter.sourceLabel)} ↗</a>`
      : !onboarding
        ? `<span class="ck-source ck-source--original">
            ${htmlEscape(encounter.sourceLabel)}
          </span>`
        : "";

  encounterElement.dataset.persona = persona
    .toLowerCase()
    .replace(/[^a-z0-9]+/g, "-")
    .replace(/^-|-$/g, "");
  encounterElement.dataset.kind = onboarding ? "onboarding" : kind;
  encounterElement.setAttribute("aria-label", `${persona} message`);
  encounterSigil.textContent = sigil;
  encounterCopy.innerHTML = `
    <button
      type="button"
      class="ck-icon-button"
      data-close-encounter
      aria-label="Close scholar message"
    >×</button>
    <span class="ck-encounter__era">
      ${htmlEscape(onboarding ? persona : `${persona} · ${encounter.era}`)}
    </span>
    <h2>${htmlEscape(
      onboarding ? "Seventeen syllables. One exact landing." : encounter.title
    )}</h2>
    <p class="ck-encounter__text">
      <span class="ck-encounter__typed" aria-hidden="true"></span>
      <span class="ck-sr-only">${htmlEscape(bodyText)}</span>
    </p>
    ${onboarding
      ? `<div class="ck-onboarding-actions">
          <button class="ck-action" type="button" data-begin-trail>
            Begin the trail
          </button>
          <button class="ck-action ck-action--secondary" type="button" data-close-encounter>
            Later
          </button>
        </div>`
      : sourceMarkup}
    <span class="ck-dialogue-advance" aria-hidden="true">▼</span>
  `;
  encounterElement.hidden = false;
  typeEncounterText(bodyText);
}

function nextAdvisor() {
  const encounter = advisorAtLevel(player.lifetimeCorrect);
  if (!encounter || player.encountersSeen[encounter.id]) return null;
  return encounter;
}

function claimQuest(id) {
  const quest = QUESTS.find((item) => item.id === id);
  const state = questState(id);
  if (!quest || !state.complete || state.claimed) {
    showToast("That quest is not ready to claim.");
    return;
  }

  playerStore.update((draft) => {
    draft.quests[id] = {
      ...draft.quests[id],
      complete: true,
      claimed: true
    };
    draft.coins += quest.reward;
  });
  updateHud();
  renderPanel();
  showToast(`${quest.title} claimed · +${quest.reward} coins`);
}

function claimDailyQuest() {
  const { daily, quest } = dailyQuestModel();
  if (!quest || !daily.complete || daily.claimed) {
    showToast("Today’s mission is not ready to claim.");
    return;
  }

  playerStore.update((draft) => {
    draft.daily.claimed = true;
    draft.coins += quest.reward;
  });
  updateHud();
  renderPanel();
  showToast(`${quest.title} claimed · +${quest.reward} coins`);
}

function claimWeeklyQuest() {
  const { weekly, quest } = weeklyQuestModel();
  if (!quest || !weekly.complete || weekly.claimed) {
    showToast("This week’s path is not ready to claim.");
    return;
  }

  playerStore.update((draft) => {
    draft.weekly.claimed = true;
    draft.coins += quest.reward;
  });
  updateHud();
  renderPanel();
  showToast(`${quest.title} claimed · +${quest.reward} coins`);
}

async function shareProgress() {
  const world = worldForCount(player.lifetimeCorrect);
  const summary = [
    `COUNTKU // ${world.label.toUpperCase()}`,
    `${player.lifetimeCorrect} exact Countku`,
    `best streak ${player.bestStreak}`,
    `${player.operationFamilies.length}/8 operation families`,
    `${player.coins} trail coins`
  ].join(" · ");

  try {
    if (navigator.share) {
      await navigator.share({
        title: `Countku — ${world.label}`,
        text: summary
      });
      showToast("Trail summary shared.");
      return;
    }
    await navigator.clipboard.writeText(summary);
    showToast("Trail summary copied.");
  } catch (error) {
    if (error?.name !== "AbortError") {
      console.warn("Countku could not share the summary.", error);
      showToast("Sharing is unavailable in this browser.");
    }
  }
}

async function installCountku() {
  if (!deferredInstallPrompt) {
    showToast("Use your browser’s install or Add to Home Screen action.");
    return;
  }
  deferredInstallPrompt.prompt();
  await deferredInstallPrompt.userChoice;
  deferredInstallPrompt = null;
  if (activePanel === "settings") renderPanel();
}

function previewCosmetic(id) {
  const item = COSMETICS.find((candidate) => candidate.id === id);
  if (!item) return;
  window.clearTimeout(previewTimer);
  previewTimer = null;
  previewItem = item;
  applyEquippedCosmetics();
  showToast(`Previewing ${item.title} · close Collection for a clear view`);
}

function buyCosmetic(id) {
  const item = COSMETICS.find((candidate) => candidate.id === id);
  if (!item || player.unlocked.includes(id)) return;
  if (player.lifetimeCorrect < Number(item.minimum || 0)) {
    showToast(`That cosmetic opens at ${item.minimum} exact landings.`);
    return;
  }
  if (player.coins < item.price) {
    pendingPurchase = null;
    showToast(`You need ${item.price - player.coins} more coins.`);
    renderPanel();
    return;
  }
  if (pendingPurchase !== id) {
    pendingPurchase = id;
    renderPanel();
    return;
  }

  playerStore.update((draft) => {
    if (!draft.unlocked.includes(id)) draft.unlocked.push(id);
    draft.coins -= item.price;
    draft.equipped[item.kind] = id;
  });
  previewItem = null;
  window.clearTimeout(previewTimer);
  previewTimer = null;
  pendingPurchase = null;
  updateHud();
  renderPanel();
  showToast(`${item.title} unlocked and equipped.`);
}

function equipCosmetic(id) {
  const item = COSMETICS.find((candidate) => candidate.id === id);
  if (!item || !player.unlocked.includes(id)) return;
  playerStore.update((draft) => {
    draft.equipped[item.kind] = id;
  });
  previewItem = null;
  window.clearTimeout(previewTimer);
  previewTimer = null;
  updateHud();
  renderPanel();
  showToast(`${item.title} equipped.`);
}

function exportSave() {
  const blob = new Blob([playerStore.export()], {
    type: "application/json"
  });
  const url = URL.createObjectURL(blob);
  const anchor = document.createElement("a");
  anchor.href = url;
  anchor.download = `countku-save-${new Date().toISOString().slice(0, 10)}.json`;
  anchor.click();
  window.setTimeout(() => URL.revokeObjectURL(url), 0);
  showToast("Local save exported.");
}

function togglePreference(name) {
  playerStore.update((draft) => {
    if (name === "sound") {
      draft.preferences.sound = !draft.preferences.sound;
    } else if (name === "music") {
      draft.preferences.music = !draft.preferences.music;
    } else if (name === "effects") {
      draft.preferences.reducedEffects = !draft.preferences.reducedEffects;
    }
  });
  updateHud();
  if (
    name === "music" &&
    player.preferences.music &&
    body.dataset.countkuMode === "countku"
  ) {
    music.start().then(updateHud);
  }
  renderPanel();
}

function setVolume(name, rawValue, { persist = false } = {}) {
  const value = Math.min(1, Math.max(0, Number(rawValue) / 100));
  if (name === "music") music.setVolume(value);
  if (name === "effects") sounds.setVolume(value);
  if (!persist) return;

  playerStore.update((draft) => {
    if (name === "music") draft.preferences.musicVolume = value;
    if (name === "effects") draft.preferences.effectsVolume = value;
  });
  player = playerStore.snapshot();
}

function setMusicMovement(id) {
  if (!music.setMovement(id)) {
    showToast("That movement has not opened on this trail yet.");
    return;
  }
  playerStore.update((draft) => {
    draft.preferences.musicMovement = id;
  });
  player = playerStore.snapshot();
  if (
    player.preferences.music &&
    body.dataset.countkuMode === "countku"
  ) {
    music.start().then(updateHud);
  }
  renderPanel();
  showToast(
    id === "auto"
      ? `Score follows the trail · ${music.movement.title}`
      : `Now playing · ${music.movement.title}`
  );
}

function resetProgress() {
  if (!pendingReset) {
    pendingReset = true;
    renderPanel();
    return;
  }
  playerStore.reset();
  player = playerStore.snapshot();
  pendingReset = false;
  updateHud();
  renderPanel();
  showToast("Local Countku progress reset.");
}

function operationFamilies(inputText) {
  return Object.entries(OPERATION_FAMILIES)
    .filter(([, expression]) => expression.test(inputText))
    .map(([name]) => name);
}

function rootDegrees(inputText) {
  const degrees = [];
  if (/\b(square|quadratic|second)\s+root\b/i.test(inputText)) {
    degrees.push("square");
  }
  if (/\b(cube|cubic|third)\s+root\b/i.test(inputText)) {
    degrees.push("cube");
  }
  if (
    /\b(fourth|quartic|quadrantal|tetragonal|tetradic|tessaric)\s+root\b/i
      .test(inputText)
  ) {
    degrees.push("quartic");
  }
  return degrees;
}

function questSatisfied(rule, draft, event) {
  switch (rule) {
    case "first-success":
      return draft.lifetimeCorrect >= 1;
    case "root-operation":
      return event.families.includes("root");
    case "natural-log":
      return /\b(e|natural log)\b/i.test(event.input);
    case "streak-three":
      return event.streak >= 3;
    case "ordinal-synonym":
      return ORDINAL_SYNONYMS.test(event.input);
    case "without-filler":
      return !FILLER_PHRASES.test(event.input);
    default:
      return false;
  }
}

function dailyQuestSatisfied(rule, event) {
  switch (rule) {
    case "any-success":
      return true;
    case "root-operation":
      return event.families.includes("root");
    case "without-filler":
      return event.noFiller;
    case "two-families":
      return event.families.length >= 2;
    case "ordinal-synonym":
      return ORDINAL_SYNONYMS.test(event.input);
    default:
      return false;
  }
}

function weeklyQuestSatisfied(rule, event) {
  switch (rule) {
    case "any-success":
      return true;
    case "three-families":
      return event.families.length >= 3;
    case "without-filler":
      return event.noFiller;
    case "streak-five":
      return event.streak >= 5;
    case "ordinal-synonym":
      return ORDINAL_SYNONYMS.test(event.input);
    default:
      return false;
  }
}

function achievementSatisfied(rule, draft, event) {
  switch (rule) {
    case "first-success":
      return draft.lifetimeCorrect >= 1;
    case "ten-successes":
      return draft.lifetimeCorrect >= 10;
    case "root-triad":
      return ["square", "cube", "quartic"].every((degree) =>
        draft.rootDegrees.includes(degree)
      );
    case "long-way":
      return event.target >= 10 &&
        !/\b(four|five|six|seven|eight|nine|ten|eleven|twelve|thirteen|fourteen|fifteen|sixteen|seventeen|eighteen|nineteen|twenty|thirty|forty|fifty|sixty|seventy|eighty|ninety|hundred|thousand|million)\b/i
          .test(event.input);
    case "five-without-filler":
      return draft.noFillerStreak >= 5;
    case "five-families":
      return draft.operationFamilies.length >= 5;
    default:
      return false;
  }
}

function recordSuccess(inputText, target, streak) {
  player = playerStore.snapshot();
  const previousWorld = worldForCount(player.lifetimeCorrect);
  const proof = compositionKey(inputText, target);
  if (player.rewardedCompositions.includes(proof)) {
    updateHud();
    showToast("Already recorded · the trail advances without new rewards.");
    return;
  }

  const families = operationFamilies(inputText);
  const degrees = rootDegrees(inputText);
  const noFiller = !FILLER_PHRASES.test(inputText);
  const completedQuests = [];
  const unlockedAchievements = [];
  const { quest: dailyQuest } = dailyQuestModel();
  const { quest: weeklyQuest } = weeklyQuestModel();
  let completedDaily = false;
  let completedWeekly = false;
  let achievementReward = 0;
  const streakReward =
    streak > 0 && streak % 10 === 0 ? 5 :
      streak === 5 ? 3 :
        streak === 3 ? 2 : 0;

  playerStore.update((draft) => {
    draft.lifetimeCorrect += 1;
    draft.bestStreak = Math.max(draft.bestStreak, streak);
    draft.noFillerStreak = noFiller ? draft.noFillerStreak + 1 : 0;
    draft.coins += 1 + streakReward;
    draft.rewardedCompositions.push(proof);
    draft.rewardedCompositions = draft.rewardedCompositions.slice(-500);
    draft.operationFamilies = Array.from(
      new Set([...draft.operationFamilies, ...families])
    );
    draft.rootDegrees = Array.from(
      new Set([...draft.rootDegrees, ...degrees])
    );
    draft.discoveredTerms = Array.from(
      new Set([
        ...draft.discoveredTerms,
        ...families,
        ...degrees,
        ...(ORDINAL_SYNONYMS.test(inputText) ? ["ordinal synonym"] : [])
      ])
    );

    const event = {
      input: inputText,
      target,
      streak,
      families,
      degrees,
      noFiller
    };

    if (
      dailyQuest &&
      draft.daily &&
      !draft.daily.complete &&
      dailyQuestSatisfied(dailyQuest.rule, event)
    ) {
      draft.daily.progress = Math.min(
        dailyQuest.goal,
        Number(draft.daily.progress || 0) + 1
      );
      if (draft.daily.progress >= dailyQuest.goal) {
        draft.daily.complete = true;
        completedDaily = true;
      }
    }

    if (
      weeklyQuest &&
      draft.weekly &&
      !draft.weekly.complete &&
      weeklyQuestSatisfied(weeklyQuest.rule, event)
    ) {
      draft.weekly.progress = Math.min(
        weeklyQuest.goal,
        Number(draft.weekly.progress || 0) + 1
      );
      if (draft.weekly.progress >= weeklyQuest.goal) {
        draft.weekly.complete = true;
        completedWeekly = true;
      }
    }

    for (const quest of QUESTS) {
      const existing = draft.quests[quest.id] ?? {
        complete: false,
        claimed: false
      };
      if (!existing.complete && questSatisfied(quest.rule, draft, event)) {
        existing.complete = true;
        completedQuests.push(quest.title);
      }
      draft.quests[quest.id] = existing;
    }

    for (const achievement of ACHIEVEMENTS) {
      const existing = draft.achievements[achievement.id] ?? {
        unlocked: false
      };
      if (
        !existing.unlocked &&
        achievementSatisfied(achievement.rule, draft, event)
      ) {
        existing.unlocked = true;
        existing.unlockedAt = new Date().toISOString();
        draft.coins += achievement.reward;
        unlockedAchievements.push(achievement.title);
        achievementReward += achievement.reward;
      }
      draft.achievements[achievement.id] = existing;
    }
  });

  updateHud();
  const currentWorld = worldForCount(player.lifetimeCorrect);
  if (activePanel) renderPanel();

  const reward = 1 + streakReward;
  if (unlockedAchievements.length) {
    const extra =
      unlockedAchievements.length > 1
        ? ` + ${unlockedAchievements.length - 1} more`
        : "";
    showToast(
      `${unlockedAchievements[0]}${extra} · +${reward + achievementReward} coins`
    );
  } else if (completedQuests.length) {
    showToast(`${completedQuests[0]} complete · claim it in Quests`);
  } else if (completedDaily) {
    showToast(`${dailyQuest.title} complete · claim today’s mission`);
  } else if (completedWeekly) {
    showToast(`${weeklyQuest.title} complete · claim the seven-day path`);
  } else {
    showToast(`Clean landing · +${reward} coin${reward === 1 ? "" : "s"}`);
  }

  const advisor = nextAdvisor();
  const fieldMessage = advisor
    ? null
    : fieldMessageAtLevel(player.lifetimeCorrect);
  const encounter = advisor ?? fieldMessage;
  const encounterOptions = {
    kind: advisor ? "advisor" : "field"
  };

  if (currentWorld.id !== previousWorld.id) {
    if (encounter) {
      queuedEncounter = {
        encounter,
        options: encounterOptions
      };
    }
    window.setTimeout(() => showStageReveal(currentWorld), 420);
  } else if (encounter && encounterElement.hidden) {
    window.setTimeout(
      () => showEncounter(encounter, encounterOptions),
      650
    );
  }
}

function enhanceHelp() {
  if (!helpContentElement || helpContentElement.querySelector(".ck-help-close")) {
    return;
  }
  const closeButton = document.createElement("button");
  closeButton.type = "button";
  closeButton.className = "ck-help-close";
  closeButton.textContent = "CLOSE GUIDE";
  closeButton.addEventListener("click", () => hideBaseHelp());
  helpContentElement.appendChild(closeButton);
  helpModal.setAttribute("role", "dialog");
  helpModal.setAttribute("aria-modal", "true");
  helpModal.setAttribute("aria-label", "Countku syntax guide");
}

function addMathLens() {
  if (!haikuDisplay || document.getElementById("ckMathLens")) return;
  const button = document.createElement("button");
  button.id = "ckMathLens";
  button.type = "button";
  button.className = "ck-lens-button";
  button.textContent = "Math lens";
  button.setAttribute("aria-expanded", "false");
  button.addEventListener("click", () => {
    const open = debugConsole.classList.toggle("ck-open");
    button.setAttribute("aria-expanded", String(open));
    button.textContent = open ? "Close math lens" : "Math lens";
  });
  haikuDisplay.appendChild(button);
}

function applyMode(mode) {
  const countku = mode === "countku";
  body.dataset.countkuMode = mode;
  body.classList.toggle("mode-countku", countku);
  app.hidden = !countku;
  objectiveBanner.hidden = !countku;
  const title = document.querySelector(".game-title");
  if (title) {
    title.textContent = countku
      ? `COUNTKU // ${worldForCount(player.lifetimeCorrect).label.toUpperCase()}`
      : originalTitle;
  }

  if (!countku) {
    music.pause();
    previewItem = null;
    window.clearTimeout(previewTimer);
    previewTimer = null;
    queuedEncounter = null;
    closePanel();
    closeEncounter(false);
    closeStageReveal();
    return;
  }

  updateHud();
  if (player.preferences.music) {
    music.start().then(updateHud);
  }
  addMathLens();
  if (!player.onboardingComplete && encounterElement.hidden) {
    window.setTimeout(
      () => showEncounter({}, { onboarding: true }),
      380
    );
  }
}

objectiveBanner.addEventListener("click", () => openPanel("quests"));

app.addEventListener("click", (event) => {
  const button = event.target.closest("button");
  if (!button) return;

  if (button.dataset.openPanel) {
    if (activePanel === button.dataset.openPanel && !panel.hidden) {
      closePanel();
    } else {
      openPanel(button.dataset.openPanel);
    }
  } else if (button.hasAttribute("data-close-panel")) {
    closePanel();
  } else if (button.dataset.learnCategory) {
    activeLearnCategory = button.dataset.learnCategory;
    renderPanel();
    panelBody.scrollTop = 0;
  } else if (button.dataset.claimQuest) {
    claimQuest(button.dataset.claimQuest);
  } else if (button.hasAttribute("data-claim-daily")) {
    claimDailyQuest();
  } else if (button.hasAttribute("data-claim-weekly")) {
    claimWeeklyQuest();
  } else if (button.hasAttribute("data-music-control")) {
    if (!player.preferences.music) {
      playerStore.update((draft) => {
        draft.preferences.music = true;
      });
      player = playerStore.snapshot();
      music.setEnabled(true);
    }
    music.toggle().then(updateHud);
  } else if (button.dataset.preview) {
    previewCosmetic(button.dataset.preview);
  } else if (button.dataset.buy) {
    buyCosmetic(button.dataset.buy);
  } else if (button.dataset.equip) {
    equipCosmetic(button.dataset.equip);
  } else if (button.dataset.read) {
    const encounter = [...ADVISOR_BANK, ...ENCOUNTERS].find(
      (item) => item.id === button.dataset.read
    );
    if (encounter) showEncounter(encounter);
  } else if (button.hasAttribute("data-close-encounter")) {
    closeEncounter();
  } else if (button.hasAttribute("data-close-stage")) {
    closeStageReveal();
  } else if (button.hasAttribute("data-begin-trail")) {
    playerStore.update((draft) => {
      draft.onboardingComplete = true;
    });
    player = playerStore.snapshot();
    closeEncounter(false);
    input?.focus();
  } else if (button.dataset.movement) {
    setMusicMovement(button.dataset.movement);
  } else if (button.dataset.toggle) {
    togglePreference(button.dataset.toggle);
  } else if (button.hasAttribute("data-share")) {
    shareProgress();
  } else if (button.hasAttribute("data-onboarding")) {
    closePanel();
    showEncounter({}, { onboarding: true });
  } else if (button.hasAttribute("data-install")) {
    installCountku();
  } else if (button.hasAttribute("data-export")) {
    exportSave();
  } else if (button.hasAttribute("data-import")) {
    importFile.click();
  } else if (button.hasAttribute("data-reset")) {
    resetProgress();
  }
});

encounterElement.addEventListener("click", (event) => {
  if (event.target.closest("button, a")) return;
  finishEncounterTyping();
});

app.addEventListener("input", (event) => {
  const slider = event.target.closest("[data-volume]");
  if (!slider) return;
  setVolume(slider.dataset.volume, slider.value);
  const output = app.querySelector(
    `[data-volume-output="${slider.dataset.volume}"]`
  );
  if (output) output.textContent = `${slider.value}%`;
});

app.addEventListener("change", (event) => {
  const slider = event.target.closest("[data-volume]");
  if (!slider) return;
  setVolume(slider.dataset.volume, slider.value, { persist: true });
});

importFile.addEventListener("change", async () => {
  const file = importFile.files?.[0];
  if (!file) return;
  try {
    playerStore.import(await file.text());
    player = playerStore.snapshot();
    updateHud();
    if (
      player.preferences.music &&
      body.dataset.countkuMode === "countku"
    ) {
      music.start().then(updateHud);
    }
    if (activePanel) renderPanel();
    showToast("Countku save imported.");
  } catch (error) {
    console.error(error);
    showToast("That file is not a compatible Countku save.");
  } finally {
    importFile.value = "";
  }
});

document.addEventListener("keydown", (event) => {
  if (event.key !== "Escape") return;
  if (!stageReveal.hidden) {
    closeStageReveal();
  } else if (!encounterElement.hidden) {
    closeEncounter();
  } else if (!panel.hidden) {
    closePanel();
  } else if (helpModal?.classList.contains("active")) {
    hideBaseHelp();
  }
});

document.addEventListener("visibilitychange", () => {
  if (document.hidden) {
    music.pause();
    updateHud();
    return;
  }
  if (
    body.dataset.countkuMode === "countku" &&
    player.preferences.music
  ) {
    music.start().then(updateHud);
  }
});

const baseSetMode = window.CountkuHost?.setMode ?? window.setMode;
window.setMode = function setModeWithApp(mode) {
  const result = baseSetMode.call(this, mode);
  applyMode(mode);
  return result;
};

const baseHandleSubmit = window.CountkuHost?.handleSubmit ?? window.handleSubmit;
window.handleSubmit = function handleSubmitWithProgress(event) {
  const before = readCurrentNumber();
  const submitted = input?.value.trim() ?? "";
  const isCountku = body.dataset.countkuMode === "countku";
  const result = baseHandleSubmit.call(this, event);

  if (isCountku) {
    queueMicrotask(() => {
      const after = readCurrentNumber();
      if (after === before + 1) {
        recordSuccess(submitted, after, readStreak());
      } else {
        updateHud();
      }
    });
  }
  return result;
};

const baseResetGame = window.CountkuHost?.resetGame ?? window.resetGame;
function invokeBaseReset() {
  if (typeof baseResetGame === "function") {
    baseResetGame.call(window);
  }
}

window.resetGame = function resetGameWithApp() {
  invokeBaseReset();
  updateHud();
};

document.querySelector(".play-again-btn")?.addEventListener("click", () => {
  queueMicrotask(() => {
    const dashboard = document.getElementById("dashboard");
    if (!dashboard?.classList.contains("active")) return;
    invokeBaseReset();
    updateHud();
  });
});

const baseShowHelp = window.CountkuHost?.showHelp ?? window.showHelp;
const hideBaseHelp = window.CountkuHost?.hideHelp ?? window.hideHelp;
window.showHelp = function showHelpWithClose() {
  const result = baseShowHelp.call(this);
  enhanceHelp();
  return result;
};

window.playSound = function playCountkuSound(type) {
  if (type === "ding") sounds.success();
  if (type === "failure") sounds.failure();
};

window.addEventListener("beforeinstallprompt", (event) => {
  event.preventDefault();
  deferredInstallPrompt = event;
  if (activePanel === "settings") renderPanel();
});

window.addEventListener("appinstalled", () => {
  deferredInstallPrompt = null;
  showToast("Countku installed for this device.");
});

if ("serviceWorker" in navigator) {
  window.addEventListener("load", () => {
    navigator.serviceWorker
      .register(`./countku-sw.js?v=${APP_VERSION}`)
      .then((registration) => {
        registration.addEventListener("updatefound", () => {
          const worker = registration.installing;
          worker?.addEventListener("statechange", () => {
            if (
              worker.state === "installed" &&
              navigator.serviceWorker.controller
            ) {
              showToast("A new Countku build is ready after this run.");
            }
          });
        });
      })
      .catch((error) => {
        console.warn("Countku offline support could not start.", error);
      });
  });
}

document.getElementById("bubbleContent")?.setAttribute("aria-live", "polite");
document.getElementById("haikuStatus")?.setAttribute("aria-live", "polite");
input?.setAttribute("aria-describedby", "inputHint haikuStatus");

applyMode("normal");
updateHud();
"""

let render() = file
