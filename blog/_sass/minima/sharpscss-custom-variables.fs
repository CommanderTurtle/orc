module Imported.Sass.Minima.CustomVariablesScss

let file = """// ============================================================
// sHEL Color Scheme: Vibrant Deep Dark + sHEL Green Accent
// Modeled after vllm.ai's modern dark theme
// ============================================================

// --- Light Mode ---
$lm-brand-color:           #5d4e37 !default;
$lm-brand-color-light:     lighten($lm-brand-color, 45%) !default;
$lm-brand-color-dimmed:    darken($lm-brand-color, 10%) !default;
$lm-brand-color-dark:      darken($lm-brand-color, 25%) !default;

$lm-site-title-color:      $lm-brand-color-dark !default;

$lm-heading-color:         #1a1714 !default;
$lm-text-color:            #2d2924 !default;
$lm-background-color:      #faf8f5 !default;
$lm-code-background-color: #f0ede8 !default;

$lm-link-base-color:       #2d6a3e !default;
$lm-link-visited-color:    darken($lm-link-base-color, 12%) !default;
$lm-link-hover-color:      $lm-text-color !default;

$lm-border-color-01:       $lm-brand-color-light !default;
$lm-border-color-02:       lighten($lm-brand-color, 35%) !default;
$lm-border-color-03:       $lm-brand-color-dark !default;

// --- Dark Mode (Vibrant Deep) ---
$dm-brand-color:           #8a7d6b !default;
$dm-brand-color-light:     lighten($dm-brand-color, 10%) !default;
$dm-brand-color-dimmed:    darken($dm-brand-color, 15%) !default;
$dm-brand-color-dark:      darken($dm-brand-color, 45%) !default;

$dm-site-title-color:      $dm-brand-color-light !default;

$dm-heading-color:         #e8e0d4 !default;
$dm-text-color:            #c8c0b4 !default;
$dm-background-color:      #0a0a0f !default;
$dm-code-background-color: #13131a !default;

$dm-link-base-color:       #5ab76e !default;
$dm-link-visited-color:    #7dd48f !default;
$dm-link-hover-color:      $dm-text-color !default;

$dm-border-color-01:       #1e1e28 !default;
$dm-border-color-02:       #2a2a38 !default;
$dm-border-color-03:       $dm-brand-color !default;

// --- sHEL Brand Colors ---
$shel-green:        #4a7c59;
$shel-green-light:  #6b9e7c;
$shel-green-dark:   #2d5a3a;
$shel-brown:        #5d4e37;
$shel-brown-dark:   #3d3224;
$shel-cream:        #faf8f5;
"""

let render() = file
