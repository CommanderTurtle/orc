module ConvertedFiles.CountkuStateJs

let file = """const STORAGE_KEY = "countku.player.v1";
const RECOVERY_KEY = "countku.player.recovery";
const CURRENT_VERSION = 1;

const clone = (value) => JSON.parse(JSON.stringify(value));

function createStorageAdapter(primary) {
  const memory = new Map();
  let warned = false;

  const warnOnce = (error) => {
    if (warned) return;
    warned = true;
    console.warn(
      "Countku is using an in-memory save because browser storage is unavailable.",
      error
    );
  };

  return {
    getItem(key) {
      try {
        const value = primary?.getItem(key) ?? null;
        if (value !== null) memory.set(key, value);
        return value ?? memory.get(key) ?? null;
      } catch (error) {
        warnOnce(error);
        return memory.get(key) ?? null;
      }
    },
    setItem(key, value) {
      const serialized = String(value);
      memory.set(key, serialized);
      try {
        primary?.setItem(key, serialized);
      } catch (error) {
        warnOnce(error);
      }
    },
    removeItem(key) {
      memory.delete(key);
      try {
        primary?.removeItem(key);
      } catch (error) {
        warnOnce(error);
      }
    }
  };
}

function browserStorage() {
  try {
    return window.localStorage;
  } catch (error) {
    console.warn("Countku could not access browser storage.", error);
    return null;
  }
}

export const defaultPlayerState = () => ({
  version: CURRENT_VERSION,
  coins: 0,
  lifetimeCorrect: 0,
  bestStreak: 0,
  noFillerStreak: 0,
  operationFamilies: [],
  rootDegrees: [],
  discoveredTerms: [],
  rewardedCompositions: [],
  unlocked: ["ninja-classic", "trail-sakura", "effect-none"],
  equipped: {
    avatar: "ninja-classic",
    trail: "trail-sakura",
    effect: "effect-none"
  },
  achievements: {},
  quests: {},
  daily: null,
  latestDailyDate: null,
  weekly: null,
  latestWeeklyKey: null,
  encountersSeen: {},
  preferences: {
    sound: true,
    effectsVolume: 0.72,
    music: true,
    musicVolume: 0.24,
    musicMovement: "auto",
    reducedEffects: false
  },
  onboardingComplete: false,
  updatedAt: null
});

const isRecord = (value) =>
  value !== null && typeof value === "object" && !Array.isArray(value);

function normalizeState(candidate) {
  if (!isRecord(candidate) || candidate.version !== CURRENT_VERSION) {
    throw new TypeError("Unsupported Countku save version");
  }

  const baseline = defaultPlayerState();
  const normalized = {
    ...baseline,
    ...candidate,
    equipped: {
      ...baseline.equipped,
      ...(isRecord(candidate.equipped) ? candidate.equipped : {})
    },
    preferences: {
      ...baseline.preferences,
      ...(isRecord(candidate.preferences) ? candidate.preferences : {})
    },
    achievements: isRecord(candidate.achievements)
      ? candidate.achievements
      : {},
    quests: isRecord(candidate.quests) ? candidate.quests : {},
    encountersSeen: isRecord(candidate.encountersSeen)
      ? candidate.encountersSeen
      : {}
  };

  normalized.coins = Math.max(0, Number(normalized.coins) || 0);
  normalized.lifetimeCorrect =
    Math.max(0, Number(normalized.lifetimeCorrect) || 0);
  normalized.bestStreak = Math.max(0, Number(normalized.bestStreak) || 0);
  normalized.noFillerStreak =
    Math.max(0, Number(normalized.noFillerStreak) || 0);
  normalized.operationFamilies = Array.from(
    new Set(Array.isArray(normalized.operationFamilies)
      ? normalized.operationFamilies.filter((item) => typeof item === "string")
      : [])
  );
  normalized.rootDegrees = Array.from(
    new Set(Array.isArray(normalized.rootDegrees)
      ? normalized.rootDegrees.filter((item) => typeof item === "string")
      : [])
  );
  normalized.discoveredTerms = Array.from(
    new Set(Array.isArray(normalized.discoveredTerms)
      ? normalized.discoveredTerms.filter((item) => typeof item === "string")
      : [])
  );
  normalized.rewardedCompositions = Array.from(
    new Set(Array.isArray(normalized.rewardedCompositions)
      ? normalized.rewardedCompositions.filter((item) => typeof item === "string")
      : [])
  ).slice(-500);
  normalized.unlocked = Array.from(
    new Set([
      ...baseline.unlocked,
      ...(Array.isArray(normalized.unlocked)
        ? normalized.unlocked.filter((item) => typeof item === "string")
        : [])
    ])
  );
  normalized.daily = isRecord(candidate.daily) ? candidate.daily : null;
  normalized.latestDailyDate =
    typeof candidate.latestDailyDate === "string"
      ? candidate.latestDailyDate
      : null;
  normalized.weekly = isRecord(candidate.weekly) ? candidate.weekly : null;
  normalized.latestWeeklyKey =
    typeof candidate.latestWeeklyKey === "string"
      ? candidate.latestWeeklyKey
      : null;
  normalized.preferences.effectsVolume = Math.min(
    1,
    Math.max(0, Number(normalized.preferences.effectsVolume) || 0)
  );
  normalized.preferences.musicVolume = Math.min(
    1,
    Math.max(0, Number(normalized.preferences.musicVolume) || 0)
  );
  normalized.preferences.musicMovement =
    typeof normalized.preferences.musicMovement === "string"
      ? normalized.preferences.musicMovement
      : "auto";

  return normalized;
}

export class CountkuPlayerStore {
  constructor(storage = browserStorage()) {
    this.storage = createStorageAdapter(storage);
    this.state = this.load();
  }

  load() {
    const raw = this.storage.getItem(STORAGE_KEY);
    if (!raw) return defaultPlayerState();

    try {
      return normalizeState(JSON.parse(raw));
    } catch (error) {
      if (!this.storage.getItem(RECOVERY_KEY)) {
        this.storage.setItem(RECOVERY_KEY, raw);
      }
      console.warn("Countku preserved an unreadable save for recovery.", error);
      return defaultPlayerState();
    }
  }

  snapshot() {
    return clone(this.state);
  }

  replace(next) {
    this.state = normalizeState(next);
    this.save();
    return this.snapshot();
  }

  update(mutator) {
    const draft = this.snapshot();
    mutator(draft);
    draft.updatedAt = new Date().toISOString();
    return this.replace(draft);
  }

  save() {
    this.storage.setItem(STORAGE_KEY, JSON.stringify(this.state));
  }

  export() {
    return JSON.stringify(this.state, null, 2);
  }

  import(serialized) {
    const parsed = JSON.parse(serialized);
    return this.replace(parsed);
  }

  reset() {
    this.state = defaultPlayerState();
    this.save();
    return this.snapshot();
  }
}

export { CURRENT_VERSION, RECOVERY_KEY, STORAGE_KEY };
"""

let render() = file
