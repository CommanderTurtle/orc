module ConvertedFiles.CountkuContentJs

let file = """import {
  DIALOGUE_BANK,
  DIALOGUE_CATEGORIES
} from "./countku-dialogue.js?v=0.6.1";

export const QUESTS = Object.freeze([
  {
    id: "first-footfall",
    title: "First Footfall",
    description: "Complete one valid Countku.",
    reward: 5,
    rule: "first-success"
  },
  {
    id: "root-route",
    title: "Root Route",
    description: "Land a Countku containing a root operation.",
    reward: 4,
    rule: "root-operation"
  },
  {
    id: "natural-way",
    title: "Natural Way",
    description: "Use e or a natural logarithm successfully.",
    reward: 5,
    rule: "natural-log"
  },
  {
    id: "unbroken-form",
    title: "Unbroken Form",
    description: "Reach a streak of three.",
    reward: 8,
    rule: "streak-three"
  },
  {
    id: "many-names",
    title: "Many Names",
    description: "Use a systematic ordinal synonym.",
    reward: 6,
    rule: "ordinal-synonym"
  },
  {
    id: "quiet-seventeen",
    title: "Quiet Seventeen",
    description: "Complete a Countku without a filler phrase.",
    reward: 7,
    rule: "without-filler"
  }
]);

export const DAILY_QUESTS = Object.freeze([
  {
    id: "daily-two-landings",
    title: "Two Quiet Landings",
    description: "Complete two valid Countku today.",
    reward: 6,
    goal: 2,
    rule: "any-success"
  },
  {
    id: "daily-root",
    title: "A Root in the Road",
    description: "Complete a Countku using a root.",
    reward: 7,
    goal: 1,
    rule: "root-operation"
  },
  {
    id: "daily-precision",
    title: "Unpadded Verse",
    description: "Complete two Countku without filler phrases.",
    reward: 8,
    goal: 2,
    rule: "without-filler"
  },
  {
    id: "daily-crossroads",
    title: "Two Ways at Once",
    description: "Use two operation families in one Countku.",
    reward: 8,
    goal: 1,
    rule: "two-families"
  },
  {
    id: "daily-many-names",
    title: "An Older Name",
    description: "Use one systematic ordinal synonym.",
    reward: 7,
    goal: 1,
    rule: "ordinal-synonym"
  }
]);

export const WEEKLY_QUESTS = Object.freeze([
  {
    id: "weekly-seven-landings",
    title: "Seven Stones",
    description: "Complete seven distinct Countku before the trail turns.",
    reward: 18,
    goal: 7,
    rule: "any-success"
  },
  {
    id: "weekly-three-roads",
    title: "Three Roads, One Verse",
    description: "Use three operation families in one valid Countku.",
    reward: 20,
    goal: 1,
    rule: "three-families"
  },
  {
    id: "weekly-plain-speech",
    title: "Plain Speech",
    description: "Complete four Countku without a filler phrase.",
    reward: 20,
    goal: 4,
    rule: "without-filler"
  },
  {
    id: "weekly-unbroken-five",
    title: "Unbroken Five",
    description: "Reach a live streak of five exact landings.",
    reward: 22,
    goal: 1,
    rule: "streak-five"
  },
  {
    id: "weekly-older-names",
    title: "The Older Names",
    description: "Use two systematic ordinal synonyms successfully.",
    reward: 20,
    goal: 2,
    rule: "ordinal-synonym"
  }
]);

export const ACHIEVEMENTS = Object.freeze([
  {
    id: "one-small-step",
    title: "One Small Step",
    description: "Complete your first valid Countku.",
    reward: 3,
    rule: "first-success"
  },
  {
    id: "form-and-function",
    title: "Form and Function",
    description: "Complete ten valid Countku.",
    reward: 10,
    rule: "ten-successes"
  },
  {
    id: "squarely-rooted",
    title: "Squarely Rooted",
    description: "Use square, cube, and quartic roots.",
    reward: 12,
    rule: "root-triad"
  },
  {
    id: "the-long-way-around",
    title: "The Long Way Around",
    description: "Reach ten without naming a cardinal above three.",
    reward: 15,
    rule: "long-way"
  },
  {
    id: "bashos-ledger",
    title: "Bashō's Ledger",
    description: "Complete five Countku without filler.",
    reward: 12,
    rule: "five-without-filler"
  },
  {
    id: "wasan-apprentice",
    title: "Wasan Apprentice",
    description: "Use five different operation families.",
    reward: 12,
    rule: "five-families"
  }
]);

export const COSMETICS = Object.freeze([
  {
    id: "ninja-classic",
    kind: "avatar",
    title: "Classic Ninja",
    description: "The original Sakura Count Ninja.",
    price: 0,
    className: "avatar-classic"
  },
  {
    id: "trail-sakura",
    kind: "trail",
    title: "Sakura Trail",
    description: "Soft petals and the original moonlit palette.",
    price: 0,
    className: "trail-sakura"
  },
  {
    id: "trail-bamboo-dawn",
    kind: "trail",
    title: "Bamboo Dawn Trail",
    description: "A clear green morning palette for the first expedition.",
    price: 18,
    className: "trail-bamboo-dawn"
  },
  {
    id: "trail-moon-ink",
    kind: "trail",
    title: "Moon Ink Trail",
    description: "A quiet indigo trail with restrained motion.",
    price: 25,
    className: "trail-moon-ink"
  },
  {
    id: "trail-maple-ember",
    kind: "trail",
    title: "Maple Ember Trail",
    description: "Warm copper leaves for autumn runs.",
    price: 40,
    className: "trail-maple-ember"
  },
  {
    id: "trail-lantern-moss",
    kind: "trail",
    title: "Lantern Moss Trail",
    description: "Deep cedar green, lit by a patient amber path.",
    price: 55,
    minimum: 25,
    className: "trail-lantern-moss"
  },
  {
    id: "trail-sumi-gold",
    kind: "trail",
    title: "Sumi Gold Trail",
    description: "Ink-dark restraint with a single line of warm gold.",
    price: 80,
    minimum: 50,
    className: "trail-sumi-gold"
  },
  {
    id: "avatar-scholar-band",
    kind: "avatar",
    title: "Scholar's Headband",
    description: "A silver band earned by patient composition.",
    price: 60,
    className: "avatar-scholar-band"
  },
  {
    id: "avatar-moon-halo",
    kind: "avatar",
    title: "Moon Halo",
    description: "A cool lunar glow reserved for the long trail.",
    price: 100,
    minimum: 100,
    className: "avatar-moon-halo"
  },
  {
    id: "effect-none",
    kind: "effect",
    title: "Unadorned",
    description: "The original ninja, with no additional field effect.",
    price: 0,
    className: "effect-none"
  },
  {
    id: "effect-petal-glow",
    kind: "effect",
    title: "Petal Glow",
    description: "A warm edge-light that follows the original silhouette.",
    price: 4800,
    minimum: 100,
    className: "effect-petal-glow"
  },
  {
    id: "effect-smoke",
    kind: "effect",
    title: "Smoke Step",
    description: "Slow smoke curls appear behind each patient landing.",
    price: 5200,
    minimum: 120,
    className: "effect-smoke"
  },
  {
    id: "effect-sword",
    kind: "effect",
    title: "Quiet Blade",
    description: "A slim ceremonial sword settles into the ninja's hand.",
    price: 5600,
    minimum: 140,
    className: "effect-sword"
  },
  {
    id: "effect-fire",
    kind: "effect",
    title: "Ember Body",
    description: "A disciplined fire aura climbs without hiding the figure.",
    price: 6000,
    minimum: 160,
    className: "effect-fire"
  },
  {
    id: "effect-ascendant",
    kind: "effect",
    title: "Volt Ascendant",
    description: "Sharp charge lines and a rising gold-white power field.",
    price: 6400,
    minimum: 180,
    className: "effect-ascendant"
  },
  {
    id: "effect-disco",
    kind: "effect",
    title: "Disco Ninja",
    description: "A constant spectral palette cycle, with absolutely no shame.",
    price: 6800,
    minimum: 200,
    className: "effect-disco"
  },
  {
    id: "effect-glitch",
    kind: "effect",
    title: "Signal Fracture",
    description: "A restrained cyber split flickers across the same old friend.",
    price: 7200,
    minimum: 220,
    className: "effect-glitch"
  },
  {
    id: "effect-matrix",
    kind: "effect",
    title: "Verdant Rain",
    description: "Falling green glyph-lines dissolve before touching the ground.",
    price: 7600,
    minimum: 240,
    className: "effect-matrix"
  },
  {
    id: "effect-cowboy",
    kind: "effect",
    title: "Cowboy Ninja",
    description: "A perfectly ordinary ninja accompanied by one tiny horse.",
    price: 8000,
    minimum: 260,
    className: "effect-cowboy"
  },
  {
    id: "effect-supernova",
    kind: "effect",
    title: "Supernova Ninja",
    description: "The final absurdity: a compact star detonates around the silhouette.",
    price: 8400,
    minimum: 300,
    className: "effect-supernova"
  }
]);

export const ENCOUNTERS = DIALOGUE_BANK;
export { DIALOGUE_CATEGORIES };

export const OPERATION_FAMILIES = Object.freeze({
  addition: /\b(plus|add(?:ed|ing)?|addition|sum)\b/i,
  subtraction: /\b(minus|subtract(?:ed|ing|ion)?|difference)\b/i,
  multiplication: /\b(times|multiplied|multiplication|double|twice|tripled?)\b/i,
  division: /\b(divided|division|over|halved?|half of)\b/i,
  power: /\b(power|squared|cubed|quadratic|cubic|quartic|quintic)\b/i,
  root: /\broot\b/i,
  logarithm: /\b(log|logarithm|natural log)\b/i,
  trigonometry:
    /\b(sine|cosine|tangent|secant|cosecant|cotangent|arcsine|arccosine|arctangent)\b/i
});

export const ORDINAL_SYNONYMS =
  /\b(quadratic|cubic|quartic|quadrantal|tetragonal|tetradic|tessaric|quintic|quinary|pentagonal|pentadic|sextic|senary|hexagonal|hexadic|sextantal|septic|septenary|heptagonal|heptadic|octic|octonary|octagonal|octadic|nonic|nonary|enneadic|decic|denary|decadic|undecic|undenary|hendecadic|hendecagonal|undecagonal|duodecic|duodenary|dodecagonal|dodecadic|duodecagonal)\b/i;

export const FILLER_PHRASES =
  /\b(type shit|the influence of|under the influence of|a total of|an effect of|the number)\b/i;
"""

let render() = file
