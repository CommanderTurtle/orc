module ConvertedFiles.Docs.Assets.Stylesheets.ExtraCss

let file = """/* ============================================================
   sHEL Documentation - Custom Styles
   Merged: vLLM external link icons + nav styling + sHEL branding
   ============================================================ */

/* ---- Logo switching for light/dark mode ---- */
.logo-dark {
  display: none !important;
}

[data-md-color-scheme="slate"] .logo-light {
  display: none !important;
}

[data-md-color-scheme="slate"] .logo-dark {
  display: block !important;
}

/* ---- Custom primary color - sHEL green ---- */
:root {
  --md-primary-fg-color: #4a7c59;
  --md-primary-fg-color--light: #6b9e7c;
  --md-primary-fg-color--dark: #2d5a3a;
  --md-accent-fg-color: #7cb342;
  --md-accent-bg-color: #7cb342;
}

[data-md-color-scheme="slate"] {
  --md-primary-fg-color: #5a8c69;
  --md-primary-fg-color--light: #7cae8c;
  --md-primary-fg-color--dark: #3d6a4a;
}

/* ---- External link icons (from vLLM docs) ---- */
a:not(:has(svg)):not(.md-icon):not(.autorefs-external) {
  align-items: center;

  &[href^="//"]::after,
  &[href^="http://"]::after,
  &[href^="https://"]::after {
    content: "";
    width: 12px;
    height: 12px;
    margin-left: 4px;
    background-image: url("data:image/svg+xml,%3Csvg xmlns='http://www.w3.org/2000/svg' width='16' height='16' stroke='gray' viewBox='0 0 16 16'%3E%3Cpath fill-rule='evenodd' d='M8.636 3.5a.5.5 0 0 0-.5-.5H1.5A1.5 1.5 0 0 0 0 4.5v10A1.5 1.5 0 0 0 1.5 16h10a1.5 1.5 0 0 0 1.5-1.5V7.864a.5.5 0 0 0-1 0V14.5a.5.5 0 0 1-.5.5h-10a.5.5 0 0 1-.5-.5v-10a.5.5 0 0 1 .5-.5h6.636a.5.5 0 0 0 .5-.5z'/%3E%3Cpath fill-rule='evenodd' d='M16 .5a.5.5 0 0 0-.5-.5h-5a.5.5 0 0 0 0 1h3.793L6.146 9.146a.5.5 0 1 0 .708.708L15 1.707V5.5a.5.5 0 0 0 1 0v-5z'/%3E%3C/svg%3E");
    background-position: center;
    background-repeat: no-repeat;
    background-size: contain;
    display: inline-block;
  }
}

/* Hide external icon for internal links */
a[href*="commanderturtle.github.io"]::after,
a[href*="shel.sh"]::after,
a[href*="localhost"]::after,
a[href*="127.0.0.1"]::after {
  display: none !important;
}

/* ---- vLLM nav section styling ---- */
body[data-md-color-scheme="default"] .md-nav__item--section > label.md-nav__link .md-ellipsis {
  color: rgba(0, 0, 0, 0.7) !important;
  font-weight: 700;
}

body[data-md-color-scheme="slate"] .md-nav__item--section > label.md-nav__link .md-ellipsis {
  color: rgba(255, 255, 255, 0.7) !important;
  font-weight: 700;
}

/* ---- Content tabs styling ---- */
.md-typeset .tabbed-set {
  border: 0.075rem solid var(--md-default-fg-color--lightest);
  border-radius: 0.2rem;
}

.md-typeset .tabbed-content {
  padding: 0 0.6em;
}

/* ---- Announcement banner ---- */
.md-banner {
  background-color: var(--md-warning-bg-color);
  color: var(--md-warning-fg-color);
}

/* ---- Heart animation (from Zensical docs) ---- */
@keyframes heart {
  0%, 40%, 80%, 100% { transform: scale(1); }
  20%, 60% { transform: scale(1.15); }
}

.mdx-heart {
  animation: heart 1000ms infinite;
}

/* ---- Columns (from Zensical docs) ---- */
.mdx-columns ol,
.mdx-columns ul {
  columns: 2;
}

@media screen and (max-width: 29.9844em) {
  .md-typeset .mdx-columns ol,
  .md-typeset .mdx-columns ul {
    columns: initial;
  }
}

.mdx-columns li {
  break-inside: avoid;
}"""

let render() = file
