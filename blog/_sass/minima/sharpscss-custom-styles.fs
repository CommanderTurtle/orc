module ConvertedFiles.Sass.Minima.CustomStylesScss

let file = """// ============================================================
// sHEL Custom Styles — vllm.ai-inspired
// Vibrant deep dark theme with sHEL green accents
// ============================================================

// --- CSS Custom Properties ---
:root {
  --shel-green: #4a7c59;
  --shel-green-light: #6b9e7c;
  --shel-green-dark: #2d5a3a;
  --shel-green-glow: rgba(74, 124, 89, 0.15);
  --shel-brown: #5d4e37;

  --bg-primary: #faf8f5;
  --bg-secondary: #f0ece4;
  --bg-tertiary: #e8e2d8;
  --bg-code: #1a1a24;
  --bg-code-inline: #f0ede8;
  --bg-card: #ffffff;
  --bg-hero: #0a0a0f;
  --bg-footer: #0a0a0f;
  --bg-nav: rgba(250, 248, 245, 0.92);
  --bg-admonition: #f5f0e8;

  --text-primary: #1a1714;
  --text-secondary: #5a554d;
  --text-muted: #8a8478;
  --text-on-dark: #e8e0d4;
  --text-on-dark-muted: #9a9488;

  --border-primary: #e0d8cc;
  --border-secondary: #d0c8bc;
  --border-glow: rgba(74, 124, 89, 0.3);

  --link-color: #2d6a3e;
  --link-hover: #1a4a28;

  --radius-sm: 8px;
  --radius-md: 12px;
  --radius-lg: 16px;
  --radius-xl: 20px;

  --shadow-sm: 0 1px 2px rgba(0,0,0,0.04);
  --shadow-md: 0 4px 16px rgba(0,0,0,0.06);
  --shadow-lg: 0 12px 40px rgba(0,0,0,0.08);
  --shadow-glow: 0 0 20px rgba(74, 124, 89, 0.15);
}

@media (prefers-color-scheme: dark) {
  :root {
    --bg-primary: #0a0a0f;
    --bg-secondary: #111118;
    --bg-tertiary: #181824;
    --bg-code: #13131a;
    --bg-code-inline: #1e1e2a;
    --bg-card: #13131a;
    --bg-hero: #0a0a0f;
    --bg-footer: #08080c;
    --bg-nav: rgba(10, 10, 15, 0.92);
    --bg-admonition: #13131a;

    --text-primary: #e8e0d4;
    --text-secondary: #c8c0b4;
    --text-muted: #8a8478;
    --text-on-dark: #e8e0d4;
    --text-on-dark-muted: #9a9488;

    --border-primary: #1e1e28;
    --border-secondary: #2a2a38;
    --border-glow: rgba(74, 124, 89, 0.25);

    --link-color: #5ab76e;
    --link-hover: #7dd48f;

    --shadow-sm: 0 1px 2px rgba(0,0,0,0.2);
    --shadow-md: 0 4px 16px rgba(0,0,0,0.3);
    --shadow-lg: 0 12px 40px rgba(0,0,0,0.4);
  }
}

// --- Reset & Base ---
*, *::before, *::after {
  box-sizing: border-box;
}

html {
  scroll-behavior: smooth;
  scroll-padding-top: 72px;
}

body {
  font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Inter, Roboto, Helvetica, Arial, sans-serif;
  line-height: 1.6;
  color: var(--text-primary);
  background: var(--bg-primary);
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  transition: background-color 0.3s ease, color 0.3s ease;
}

// --- Scrollbar ---
::-webkit-scrollbar {
  width: 8px;
  height: 8px;
}
::-webkit-scrollbar-track {
  background: transparent;
}
::-webkit-scrollbar-thumb {
  background: var(--border-secondary);
  border-radius: 4px;
}
::-webkit-scrollbar-thumb:hover {
  background: var(--text-muted);
}

// --- Selection ---
::selection {
  background: rgba(74, 124, 89, 0.25);
  color: inherit;
}

// ============================================
// HEADER & NAVIGATION
// ============================================

.site-header {
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  z-index: 1000;
  min-height: 56px;
  background: var(--bg-nav);
  backdrop-filter: blur(20px) saturate(1.2);
  -webkit-backdrop-filter: blur(20px) saturate(1.2);
  border-bottom: 1px solid var(--border-primary);
  transition: box-shadow 0.3s ease, border-color 0.3s ease;

  .wrapper {
    max-width: 1200px;
    margin: 0 auto;
    padding: 0 24px;
    display: flex;
    align-items: center;
    justify-content: space-between;
    height: 56px;
  }

  &.scrolled {
    box-shadow: 0 4px 24px rgba(0,0,0,0.08);
    border-color: transparent;
  }
}

.site-title {
  text-decoration: none;
  transition: opacity 0.2s ease;
  display: flex;
  align-items: center;

  img, picture {
    display: block;
    height: 28px;
    width: auto;
  }

  &:hover {
    opacity: 0.85;
    text-decoration: none;
  }
}

.site-nav {
  display: flex;
  align-items: center;

  .nav-trigger {
    display: none;
  }

  .menu-icon {
    display: none;
  }

  .nav-items {
    display: flex;
    align-items: center;
    gap: 2px;
    list-style: none;
    margin: 0;
    padding: 0;

    a {
      display: inline-flex;
      align-items: center;
      padding: 6px 14px;
      border-radius: var(--radius-sm);
      font-size: 0.875rem;
      font-weight: 500;
      color: var(--text-secondary);
      text-decoration: none;
      transition: all 0.2s ease;

      &:hover {
        background: var(--shel-green-glow);
        color: var(--shel-green);
        text-decoration: none;
      }

      &.nav-docs {
        background: var(--shel-green);
        color: #fff;
        margin-left: 8px;
        font-weight: 600;

        &:hover {
          background: var(--shel-green-dark);
          color: #fff;
        }
      }
    }
  }
}

// Mobile nav
@media screen and (max-width: 600px) {
  .site-nav {
    position: absolute;
    top: 56px;
    right: 0;
    left: 0;
    background: var(--bg-nav);
    backdrop-filter: blur(20px);
    -webkit-backdrop-filter: blur(20px);
    border-bottom: 1px solid var(--border-primary);
    padding: 12px 24px 20px;
    transform: translateY(-8px);
    opacity: 0;
    pointer-events: none;
    transition: all 0.25s ease;

    .nav-trigger:checked ~ & {
      transform: translateY(0);
      opacity: 1;
      pointer-events: all;
    }

    .nav-items {
      flex-direction: column;
      align-items: stretch;
      gap: 2px;

      a {
        padding: 10px 14px;
        width: 100%;
        justify-content: space-between;

        &.nav-docs {
          margin-left: 0;
          margin-top: 8px;
          justify-content: center;
        }
      }
    }
  }

  label[for="nav-trigger"] {
    display: block;
    cursor: pointer;
    padding: 8px;
    user-select: none;
  }

  .menu-icon {
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    width: 20px;
    height: 14px;
    position: relative;

    .menu-line {
      display: block;
      height: 2px;
      background: var(--text-secondary);
      border-radius: 1px;
      transition: all 0.25s ease;
      transform-origin: center;
    }
  }

  .nav-trigger:checked ~ label .menu-icon {
    .menu-line:nth-child(1) {
      transform: translateY(6px) rotate(45deg);
    }
    .menu-line:nth-child(2) {
      opacity: 0;
    }
    .menu-line:nth-child(3) {
      transform: translateY(-6px) rotate(-45deg);
    }
  }
}

// ============================================
// MAIN CONTENT
// ============================================

.page-content {
  padding-top: 56px;
}

.wrapper {
  max-width: 1200px;
  margin: 0 auto;
  padding: 0 24px;
}

// ============================================
// HERO SECTION
// ============================================

.hero-section {
  background: var(--bg-hero);
  color: var(--text-on-dark);
  padding: 100px 0 80px;
  position: relative;
  overflow: hidden;

  // Subtle dot grid pattern
  .hero-bg-pattern {
    position: absolute;
    inset: 0;
    opacity: 0.025;
    background-image: radial-gradient(circle, currentColor 1px, transparent 1px);
    background-size: 32px 32px;
  }

  .hero-content {
    position: relative;
    z-index: 1;
    max-width: 720px;
    margin: 0 auto;
    text-align: center;
  }

  .hero-badge {
    display: inline-flex;
    align-items: center;
    gap: 8px;
    background: rgba(74, 124, 89, 0.12);
    border: 1px solid rgba(74, 124, 89, 0.25);
    color: var(--shel-green-light);
    padding: 6px 18px;
    border-radius: 100px;
    font-size: 0.8125rem;
    font-weight: 500;
    margin-bottom: 28px;
    backdrop-filter: blur(4px);
  }

  .hero-title {
    font-size: clamp(2.5rem, 6vw, 3.75rem);
    font-weight: 800;
    line-height: 1.08;
    margin-bottom: 20px;
    letter-spacing: -0.03em;
    color: #fff;

    .gradient-text {
      background: linear-gradient(135deg, #6b9e7c 0%, #4a7c59 40%, #8fbc8f 100%);
      -webkit-background-clip: text;
      -webkit-text-fill-color: transparent;
      background-clip: text;
    }
  }

  .hero-subtitle {
    font-size: 1.2rem;
    color: var(--text-on-dark-muted);
    max-width: 560px;
    margin: 0 auto 36px;
    line-height: 1.65;
  }

  .hero-cta-group {
    display: flex;
    gap: 12px;
    justify-content: center;
    flex-wrap: wrap;
  }
}

// ============================================
// BUTTONS
// ============================================

.btn {
  display: inline-flex;
  align-items: center;
  gap: 8px;
  padding: 12px 28px;
  border-radius: var(--radius-sm);
  font-size: 0.9375rem;
  font-weight: 600;
  text-decoration: none;
  transition: all 0.2s ease;
  cursor: pointer;
  border: none;

  &:hover {
    text-decoration: none;
    transform: translateY(-1px);
  }

  &:active {
    transform: translateY(0);
  }

  &-primary {
    background: var(--shel-green);
    color: #fff;
    box-shadow: 0 4px 14px rgba(74, 124, 89, 0.3);

    &:hover {
      background: var(--shel-green-dark);
      color: #fff;
      box-shadow: 0 6px 20px rgba(74, 124, 89, 0.4);
    }
  }

  &-secondary {
    background: rgba(255,255,255,0.08);
    color: var(--text-on-dark);
    border: 1px solid rgba(255,255,255,0.12);

    &:hover {
      background: rgba(255,255,255,0.12);
      color: var(--text-on-dark);
    }
  }

  &-ghost {
    background: transparent;
    color: var(--text-secondary);
    border: 1px solid var(--border-primary);

    &:hover {
      background: var(--shel-green-glow);
      color: var(--shel-green);
      border-color: var(--border-glow);
    }
  }
}

// ============================================
// SECTIONS
// ============================================

.section {
  padding: 80px 0;

  &-alt {
    background: var(--bg-secondary);
  }

  .section-header {
    text-align: center;
    max-width: 600px;
    margin: 0 auto 56px;

    h2 {
      font-size: 2rem;
      font-weight: 700;
      letter-spacing: -0.02em;
      margin-bottom: 12px;
      color: var(--text-primary);
    }

    p {
      font-size: 1.05rem;
      color: var(--text-muted);
      line-height: 1.6;
    }
  }
}

// ============================================
// FEATURE CARDS
// ============================================

.feature-grid {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(260px, 1fr));
  gap: 20px;
}

.feature-card {
  background: var(--bg-card);
  border: 1px solid var(--border-primary);
  border-radius: var(--radius-md);
  padding: 32px;
  transition: all 0.4s cubic-bezier(0.22, 1, 0.36, 1);
  position: relative;
  overflow: hidden;

  &::before {
    content: '';
    position: absolute;
    inset: 0;
    background: linear-gradient(135deg, rgba(74, 124, 89, 0.03), transparent 60%);
    opacity: 0;
    transition: opacity 0.4s ease;
  }

  &:hover {
    transform: translateY(-6px);
    box-shadow: var(--shadow-lg), 0 0 0 1px var(--border-glow);
    border-color: rgba(74, 124, 89, 0.2);

    &::before { opacity: 1; }

    .feature-icon {
      transform: scale(1.08);
      box-shadow: 0 6px 18px rgba(74, 124, 89, 0.35);
    }
  }

  .feature-icon {
    width: 44px;
    height: 44px;
    background: linear-gradient(135deg, var(--shel-green), var(--shel-green-light));
    border-radius: 10px;
    display: flex;
    align-items: center;
    justify-content: center;
    font-size: 1.25rem;
    margin-bottom: 18px;
    box-shadow: 0 4px 12px rgba(74, 124, 89, 0.25);
    transition: transform 0.4s cubic-bezier(0.22, 1, 0.36, 1), box-shadow 0.4s ease;
    position: relative;
    z-index: 1;
  }

  h3 {
    font-size: 1.0625rem;
    font-weight: 600;
    margin-bottom: 8px;
    color: var(--text-primary);
  }

  p {
    font-size: 0.875rem;
    color: var(--text-muted);
    line-height: 1.6;
    margin-bottom: 0;
  }
}

// ============================================
// INSTALL BLOCK
// ============================================

.install-section {
  background: var(--bg-secondary);
}

.install-block {
  background: var(--bg-code);
  border-radius: var(--radius-md);
  padding: 32px;
  max-width: 720px;
  margin: 0 auto;
  border: 1px solid var(--border-primary);

  .install-tabs {
    display: flex;
    gap: 4px;
    margin-bottom: 16px;
    flex-wrap: wrap;

    .tab-btn {
      padding: 8px 18px;
      background: transparent;
      border: 1px solid var(--border-secondary);
      color: var(--text-muted);
      border-radius: var(--radius-sm);
      font-size: 0.8125rem;
      font-weight: 500;
      cursor: pointer;
      transition: all 0.2s;

      &:hover {
        border-color: var(--border-glow);
        color: var(--shel-green-light);
      }

      &.active {
        background: rgba(74, 124, 89, 0.15);
        border-color: var(--shel-green);
        color: var(--shel-green-light);
      }
    }
  }

  .code-wrapper {
    position: relative;

    .code-block {
      background: #0d0d12;
      border: 1px solid var(--border-primary);
      border-radius: var(--radius-sm);
      padding: 18px 24px;
      font-family: "SFMono-Regular", Consolas, "Liberation Mono", Menlo, "Courier New", monospace;
      font-size: 0.875rem;
      color: #c8c0b4;
      overflow-x: auto;
      line-height: 1.6;

      .code-prompt {
        color: var(--shel-green-light);
        margin-right: 8px;
        user-select: none;
      }
    }

    .copy-btn {
      position: absolute;
      top: 8px;
      right: 8px;
      width: 32px;
      height: 32px;
      display: flex;
      align-items: center;
      justify-content: center;
      background: rgba(255,255,255,0.06);
      border: 1px solid rgba(255,255,255,0.08);
      border-radius: 6px;
      color: var(--text-muted);
      cursor: pointer;
      opacity: 0;
      transition: all 0.2s ease;

      &:hover {
        background: rgba(255,255,255,0.1);
        color: var(--text-on-dark);
      }

      &.copied {
        color: var(--shel-green-light);
        border-color: var(--shel-green);
      }
    }

    &:hover .copy-btn {
      opacity: 1;
    }
  }
}

// ============================================
// STATS BAR
// ============================================

.stats-bar {
  display: flex;
  justify-content: center;
  gap: 56px;
  flex-wrap: wrap;
  padding: 56px 0;

  .stat-item {
    text-align: center;

    .stat-number {
      font-size: 2.25rem;
      font-weight: 800;
      color: var(--shel-green);
      line-height: 1;
      margin-bottom: 6px;
      letter-spacing: -0.02em;
    }

    .stat-label {
      font-size: 0.8125rem;
      color: var(--text-muted);
      text-transform: uppercase;
      letter-spacing: 0.06em;
    }
  }
}

// ============================================
// COMMUNITY CARDS
// ============================================

.community-grid {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(200px, 1fr));
  gap: 16px;
}

.community-card {
  display: flex;
  flex-direction: column;
  align-items: center;
  text-align: center;
  padding: 32px 20px;
  background: var(--bg-card);
  border: 1px solid var(--border-primary);
  border-radius: var(--radius-md);
  text-decoration: none;
  color: inherit;
  transition: all 0.35s cubic-bezier(0.22, 1, 0.36, 1);
  position: relative;
  overflow: hidden;

  &::before {
    content: '';
    position: absolute;
    inset: 0;
    background: linear-gradient(135deg, rgba(74, 124, 89, 0.04), transparent 60%);
    opacity: 0;
    transition: opacity 0.35s ease;
  }

  &:hover {
    transform: translateY(-6px);
    box-shadow: var(--shadow-lg), 0 0 0 1px var(--border-glow);
    border-color: rgba(74, 124, 89, 0.2);
    text-decoration: none;
    color: inherit;

    &::before { opacity: 1; }

    .community-icon {
      transform: scale(1.1);
    }
  }

  .community-icon {
    font-size: 2rem;
    margin-bottom: 14px;
    width: 48px;
    height: 48px;
    display: flex;
    align-items: center;
    justify-content: center;
    background: var(--bg-secondary);
    border-radius: 12px;
    transition: transform 0.35s cubic-bezier(0.22, 1, 0.36, 1);
    position: relative;
    z-index: 1;
  }

  h4 {
    font-size: 0.9375rem;
    font-weight: 600;
    margin-bottom: 4px;
    color: var(--text-primary);
  }

  p {
    font-size: 0.8125rem;
    color: var(--text-muted);
    margin: 0;
  }
}

// ============================================
// RESOURCE CARDS
// ============================================

.resource-grid {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(260px, 1fr));
  gap: 16px;
}

.resource-card {
  display: flex;
  align-items: flex-start;
  gap: 16px;
  padding: 24px;
  background: var(--bg-card);
  border: 1px solid var(--border-primary);
  border-radius: var(--radius-md);
  text-decoration: none;
  color: inherit;
  transition: all 0.35s cubic-bezier(0.22, 1, 0.36, 1);

  &:hover {
    border-color: rgba(74, 124, 89, 0.25);
    box-shadow: var(--shadow-md), 0 0 0 1px var(--border-glow);
    transform: translateY(-3px);
    text-decoration: none;
    color: inherit;

    .resource-icon {
      background: var(--shel-green-glow);
      transform: scale(1.08);
    }
  }

  .resource-icon {
    width: 40px;
    height: 40px;
    background: var(--bg-secondary);
    border-radius: 10px;
    display: flex;
    align-items: center;
    justify-content: center;
    font-size: 1.125rem;
    flex-shrink: 0;
    transition: background 0.35s ease, transform 0.35s cubic-bezier(0.22, 1, 0.36, 1);
  }

  .resource-content {
    h4 {
      font-size: 0.9375rem;
      font-weight: 600;
      margin-bottom: 4px;
      color: var(--text-primary);
    }

    p {
      font-size: 0.8125rem;
      color: var(--text-muted);
      margin: 0;
      line-height: 1.5;
    }
  }
}

// ============================================
// FOOTER
// ============================================

.site-footer {
  background: var(--bg-footer);
  color: var(--text-on-dark-muted);
  padding: 64px 0 32px;
  border-top: 1px solid var(--border-primary);

  .footer-grid {
    display: grid;
    grid-template-columns: 2fr 1fr 1fr 1fr;
    gap: 48px;
    margin-bottom: 48px;

    @media (max-width: 768px) {
      grid-template-columns: 1fr 1fr;
      gap: 32px;
    }

    @media (max-width: 480px) {
      grid-template-columns: 1fr;
    }
  }

  .footer-brand {
    .footer-logo {
      font-size: 1.5rem;
      font-weight: 800;
      color: var(--shel-green-light);
      margin-bottom: 12px;
      letter-spacing: -0.02em;
    }

    p {
      font-size: 0.8125rem;
      line-height: 1.65;
      color: var(--text-on-dark-muted);
      max-width: 280px;
    }
  }

  .footer-links {
    h4 {
      font-size: 0.75rem;
      font-weight: 600;
      text-transform: uppercase;
      letter-spacing: 0.1em;
      color: var(--text-on-dark);
      margin-bottom: 16px;
    }

    ul {
      list-style: none;
      margin: 0;
      padding: 0;
    }

    li {
      margin-bottom: 10px;
    }

    a {
      color: var(--text-on-dark-muted);
      text-decoration: none;
      font-size: 0.8125rem;
      transition: color 0.2s;

      &:hover {
        color: var(--shel-green-light);
        text-decoration: none;
      }
    }
  }

  .footer-bottom {
    border-top: 1px solid var(--border-primary);
    padding-top: 24px;
    display: flex;
    justify-content: space-between;
    align-items: center;
    flex-wrap: wrap;
    gap: 16px;

    p {
      font-size: 0.75rem;
      color: var(--text-on-dark-muted);
      margin: 0;
      opacity: 0.7;
    }

    .social-links {
      display: flex;
      gap: 16px;
      align-items: center;

      a {
        color: var(--text-on-dark-muted);
        transition: color 0.2s;
        display: flex;
        align-items: center;

        &:hover {
          color: var(--shel-green-light);
        }

        svg {
          width: 18px;
          height: 18px;
          fill: currentColor;
        }
      }
    }
  }
}

// ============================================
// BLOG LISTING
// ============================================

.blog-list {
  display: flex;
  flex-direction: column;
  gap: 16px;
  max-width: 800px;
  margin: 0 auto;
}

.blog-card {
  display: flex;
  gap: 24px;
  padding: 28px 32px;
  background: var(--bg-card);
  border: 1px solid var(--border-primary);
  border-radius: var(--radius-md);
  transition: all 0.3s cubic-bezier(0.4, 0, 0.2, 1);

  &:hover {
    box-shadow: var(--shadow-md);
    border-color: var(--border-glow);
    transform: translateY(-2px);
  }

  .blog-meta {
    flex-shrink: 0;
    text-align: center;
    min-width: 52px;

    .blog-date-day {
      font-size: 1.75rem;
      font-weight: 700;
      color: var(--shel-green);
      line-height: 1;
    }

    .blog-date-month {
      font-size: 0.6875rem;
      text-transform: uppercase;
      letter-spacing: 0.06em;
      color: var(--text-muted);
      margin-top: 2px;
    }
  }

  .blog-content {
    min-width: 0;

    h3 {
      font-size: 1.125rem;
      font-weight: 600;
      margin-bottom: 8px;

      a {
        color: var(--text-primary);
        text-decoration: none;

        &:hover {
          color: var(--shel-green);
        }
      }
    }

    p {
      color: var(--text-muted);
      font-size: 0.875rem;
      margin-bottom: 12px;
      line-height: 1.55;
    }

    .blog-tags {
      display: flex;
      gap: 6px;
      flex-wrap: wrap;

      .tag {
        padding: 3px 10px;
        background: var(--bg-secondary);
        color: var(--shel-green);
        border-radius: 100px;
        font-size: 0.6875rem;
        font-weight: 500;
        text-decoration: none;
        transition: all 0.2s;

        &:hover {
          background: var(--shel-green-glow);
        }
      }
    }
  }
}

// ============================================
// POST LAYOUT
// ============================================

.post-layout {
  display: grid;
  grid-template-columns: 1fr 260px;
  gap: 56px;
  max-width: 1100px;
  margin: 0 auto;
  padding: 40px 24px 80px;

  @media (max-width: 900px) {
    grid-template-columns: 1fr;
    padding: 24px 16px 60px;
  }
}

.post-main {
  min-width: 0;
}

.post-sidebar {
  @media (max-width: 900px) {
    display: none;
  }
}

.post-header {
  margin-bottom: 40px;
  padding-bottom: 24px;
  border-bottom: 1px solid var(--border-primary);

  .post-title {
    font-size: 2.25rem;
    font-weight: 700;
    letter-spacing: -0.025em;
    line-height: 1.2;
    margin-bottom: 16px;
    color: var(--text-primary);
  }

  .post-meta-bar {
    display: flex;
    align-items: center;
    gap: 12px;
    flex-wrap: wrap;
    color: var(--text-muted);
    font-size: 0.875rem;

    .author-avatar {
      width: 28px;
      height: 28px;
      border-radius: 50%;
      background: linear-gradient(135deg, var(--shel-green), var(--shel-green-light));
      display: flex;
      align-items: center;
      justify-content: center;
      color: #fff;
      font-size: 0.6875rem;
      font-weight: 700;
      flex-shrink: 0;
    }

    a {
      color: var(--text-secondary);
      text-decoration: none;

      &:hover {
        color: var(--shel-green);
      }
    }
  }
}

// ============================================
// SCROLLABLE TOC
// ============================================

.toc-nav {
  position: sticky;
  top: 80px;
  max-height: calc(100vh - 120px);
  overflow-y: auto;
  padding-right: 4px;

  &::-webkit-scrollbar {
    width: 3px;
  }

  h4 {
    font-size: 0.6875rem;
    font-weight: 600;
    text-transform: uppercase;
    letter-spacing: 0.12em;
    color: var(--text-muted);
    margin-bottom: 12px;
    padding-bottom: 12px;
    border-bottom: 1px solid var(--border-primary);
  }

  ul {
    list-style: none;
    margin: 0;
    padding: 0;
  }

  li {
    margin-bottom: 2px;
  }

  a {
    display: block;
    padding: 5px 10px;
    border-radius: 6px;
    font-size: 0.78rem;
    color: var(--text-muted);
    text-decoration: none;
    border-left: 2px solid transparent;
    transition: all 0.2s;
    line-height: 1.4;

    &:hover {
      background: var(--shel-green-glow);
      color: var(--text-secondary);
    }

    &.active {
      background: var(--shel-green-glow);
      color: var(--shel-green);
      border-left-color: var(--shel-green);
      font-weight: 500;
    }

    &.toc-h3 {
      padding-left: 18px;
      font-size: 0.72rem;
    }
  }
}

// ============================================
// CODE BLOCKS WITH COPY BUTTONS
// ============================================

.highlight,
pre {
  position: relative;
  background: var(--bg-code);
  border-radius: var(--radius-md);
  border: 1px solid var(--border-primary);
  overflow: hidden;
  margin-bottom: 20px;

  pre {
    background: none;
    border: none;
    border-radius: 0;
    margin: 0;
    padding: 20px 24px;
    overflow-x: auto;
    font-family: "SFMono-Regular", Consolas, "Liberation Mono", Menlo, "Courier New", monospace;
    font-size: 0.8125rem;
    line-height: 1.7;
    color: #c8c0b4;
  }

  code {
    background: none;
    padding: 0;
    color: inherit;
    font-size: inherit;
    border-radius: 0;
  }
}

// Copy button on code blocks
.code-block-wrapper {
  position: relative;

  .copy-btn {
    position: absolute;
    top: 10px;
    right: 10px;
    width: 30px;
    height: 30px;
    display: flex;
    align-items: center;
    justify-content: center;
    background: rgba(255,255,255,0.05);
    border: 1px solid rgba(255,255,255,0.08);
    border-radius: 6px;
    color: var(--text-muted);
    cursor: pointer;
    opacity: 0;
    transition: all 0.2s ease;
    z-index: 2;

    svg {
      width: 14px;
      height: 14px;
    }

    &:hover {
      background: rgba(255,255,255,0.1);
      color: var(--text-on-dark);
    }

    &.copied {
      color: var(--shel-green-light);
      border-color: var(--shel-green);
      opacity: 1;
    }
  }

  &:hover .copy-btn {
    opacity: 1;
  }
}

// Inline code
code {
  background: var(--bg-code-inline);
  padding: 2px 7px;
  border-radius: 5px;
  font-size: 0.84em;
  font-family: "SFMono-Regular", Consolas, "Liberation Mono", Menlo, monospace;
  color: var(--shel-green-light);
  border: 1px solid var(--border-primary);
}

// ============================================
// ADMONITION / CALLOUT BLOCKS
// ============================================

.admonition {
  border-radius: var(--radius-md);
  border: 1px solid var(--border-primary);
  margin: 24px 0;
  overflow: hidden;

  .admonition-title {
    padding: 12px 20px;
    font-size: 0.8125rem;
    font-weight: 600;
    display: flex;
    align-items: center;
    gap: 8px;
  }

  .admonition-content {
    padding: 16px 20px;
    font-size: 0.875rem;
    line-height: 1.6;

    p:last-child {
      margin-bottom: 0;
    }
  }

  // Note variant
  &.admonition-note {
    background: var(--bg-admonition);
    border-left: 3px solid #3b82f6;

    .admonition-title {
      color: #3b82f6;

      &::before {
        content: "ℹ";
        font-size: 1rem;
      }
    }
  }

  // Warning variant
  &.admonition-warning {
    background: rgba(234, 179, 8, 0.06);
    border-left: 3px solid #eab308;

    .admonition-title {
      color: #eab308;

      &::before {
        content: "⚠";
        font-size: 1rem;
      }
    }
  }

  // Tip variant
  &.admonition-tip {
    background: var(--shel-green-glow);
    border-left: 3px solid var(--shel-green);

    .admonition-title {
      color: var(--shel-green-light);

      &::before {
        content: "✦";
        font-size: 1rem;
      }
    }
  }

  // Important variant
  &.admonition-important {
    background: rgba(239, 68, 68, 0.05);
    border-left: 3px solid #ef4444;

    .admonition-title {
      color: #ef4444;

      &::before {
        content: "❗";
        font-size: 1rem;
      }
    }
  }
}

// ============================================
// EVENTS CALENDAR
// ============================================

.calendar-grid {
  display: grid;
  grid-template-columns: repeat(7, 1fr);
  gap: 6px;
  margin-bottom: 16px;

  .calendar-day-header {
    text-align: center;
    font-size: 0.625rem;
    font-weight: 600;
    text-transform: uppercase;
    letter-spacing: 0.08em;
    color: var(--text-muted);
    padding: 6px 0;
  }

  .calendar-day {
    aspect-ratio: 1;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    border-radius: var(--radius-sm);
    border: 1px solid var(--border-primary);
    background: var(--bg-card);
    font-size: 0.8125rem;
    font-weight: 600;
    color: var(--text-primary);
    position: relative;
    cursor: pointer;
    transition: all 0.2s;

    &:hover {
      border-color: var(--border-glow);
      background: var(--bg-secondary);
    }

    &.empty {
      background: transparent;
      border-color: transparent;
      cursor: default;
    }

    &.today {
      border-color: var(--shel-green);
      background: var(--shel-green-glow);

      .day-number {
        color: var(--shel-green-light);
      }
    }

    .day-number {
      font-size: 0.8125rem;
      font-weight: 600;
      color: var(--text-primary);
    }

    .event-dots {
      display: flex;
      gap: 2px;
      margin-top: 2px;
      flex-wrap: wrap;
      justify-content: center;
      max-width: 100%;
      padding: 0 4px;

      .event-dot {
        width: 5px;
        height: 5px;
        border-radius: 50%;
        flex-shrink: 0;
      }
    }

    .event-count {
      font-size: 0.5625rem;
      color: var(--text-muted);
      margin-top: 1px;
      font-weight: 500;
    }
  }
}

.calendar-legend {
  display: flex;
  gap: 16px;
  justify-content: center;
  flex-wrap: wrap;
  margin-top: 12px;

  .legend-item {
    display: flex;
    align-items: center;
    gap: 5px;
    font-size: 0.6875rem;
    color: var(--text-muted);

    .legend-dot {
      width: 7px;
      height: 7px;
      border-radius: 50%;
    }
  }
}

// --- Event Popup ---
.event-popup {
  position: fixed;
  z-index: 2000;
  background: var(--bg-card);
  border: 1px solid var(--border-primary);
  border-radius: var(--radius-md);
  padding: 12px;
  min-width: 200px;
  box-shadow: var(--shadow-lg);
  animation: popupIn 0.2s ease;

  .event-popup-header {
    font-size: 0.75rem;
    font-weight: 600;
    color: var(--text-muted);
    text-transform: uppercase;
    letter-spacing: 0.06em;
    margin-bottom: 8px;
    padding-bottom: 8px;
    border-bottom: 1px solid var(--border-primary);
  }

  .event-popup-item {
    display: flex;
    align-items: center;
    gap: 8px;
    padding: 6px 8px;
    border-radius: 6px;
    text-decoration: none;
    color: var(--text-primary);
    font-size: 0.8125rem;
    transition: background 0.15s;

    &:hover {
      background: var(--bg-secondary);
      text-decoration: none;
      color: var(--shel-green);
    }

    .event-popup-dot {
      width: 7px;
      height: 7px;
      border-radius: 50%;
      flex-shrink: 0;
    }

    .event-popup-text {
      line-height: 1.3;
    }
  }
}

@keyframes popupIn {
  from { opacity: 0; transform: translateY(-4px); }
  to { opacity: 1; transform: translateY(0); }
}

// Event type colors
$event-types: (
  "meetup": #3b82f6,
  "office-hours": #22c55e,
  "release": #eab308,
  "news": #a855f7,
  "conference": #f97316,
  "sig-meeting": #06b6d4,
  "workshop": #ec4899,
  "virtual": #6366f1
);

@each $name, $color in $event-types {
  .event-dot-#{$name} {
    background: $color;
  }
}

// ============================================
// EVENT CARDS
// ============================================

.events-list {
  display: flex;
  flex-direction: column;
  gap: 12px;
  max-width: 800px;
  margin: 0 auto;
}

.event-card {
  display: flex;
  gap: 20px;
  padding: 24px;
  background: var(--bg-card);
  border: 1px solid var(--border-primary);
  border-radius: var(--radius-md);
  transition: all 0.35s cubic-bezier(0.22, 1, 0.36, 1);
  text-decoration: none;
  color: inherit;
  cursor: pointer;

  &:hover {
    border-color: rgba(74, 124, 89, 0.2);
    box-shadow: var(--shadow-md), 0 0 0 1px var(--border-glow);
    transform: translateX(4px);
    text-decoration: none;
    color: inherit;
  }

  .event-date {
    flex-shrink: 0;
    text-align: center;
    min-width: 52px;

    .event-day {
      font-size: 1.5rem;
      font-weight: 700;
      color: var(--shel-green);
      line-height: 1;
    }

    .event-month {
      font-size: 0.6875rem;
      text-transform: uppercase;
      color: var(--text-muted);
    }
  }

  .event-details {
    min-width: 0;

    h3 {
      font-size: 1.05rem;
      font-weight: 600;
      margin-bottom: 6px;
      margin-top: 0;
      color: var(--text-primary);
    }

    .event-meta {
      font-size: 0.8125rem;
      color: var(--text-muted);
      margin-bottom: 8px;
      display: flex;
      align-items: center;
      gap: 8px;
      flex-wrap: wrap;

      .event-type-badge {
        display: inline-flex;
        align-items: center;
        padding: 2px 8px;
        border-radius: 100px;
        font-size: 0.625rem;
        font-weight: 600;
        text-transform: uppercase;
        letter-spacing: 0.04em;
      }
    }

    p {
      font-size: 0.8125rem;
      color: var(--text-muted);
      margin: 0;
      line-height: 1.55;
    }
  }
}

@each $name, $color in $event-types {
  .badge-#{$name} {
    background: rgba($color, 0.1);
    color: $color;
  }
}

// ============================================
// CONTACT PAGE
// ============================================

.contact-grid {
  display: grid;
  grid-template-columns: 1fr 1fr;
  gap: 56px;
  max-width: 900px;
  margin: 0 auto;

  @media (max-width: 768px) {
    grid-template-columns: 1fr;
    gap: 40px;
  }
}

.contact-form {
  h3 {
    margin-top: 0;
    margin-bottom: 24px;
    font-size: 1.125rem;
    font-weight: 600;
  }

  .form-group {
    margin-bottom: 18px;

    label {
      display: block;
      font-size: 0.8125rem;
      font-weight: 500;
      margin-bottom: 6px;
      color: var(--text-secondary);
    }

    input,
    textarea {
      width: 100%;
      padding: 10px 14px;
      border: 1px solid var(--border-secondary);
      border-radius: var(--radius-sm);
      background: var(--bg-card);
      color: var(--text-primary);
      font-size: 0.875rem;
      transition: border-color 0.2s, box-shadow 0.2s;
      font-family: inherit;

      &:focus {
        outline: none;
        border-color: var(--shel-green);
        box-shadow: 0 0 0 3px var(--shel-green-glow);
      }

      &::placeholder {
        color: var(--text-muted);
        opacity: 0.6;
      }
    }

    textarea {
      min-height: 120px;
      resize: vertical;
    }
  }

  button[type="submit"] {
    width: 100%;
    justify-content: center;
  }
}

.contact-info {
  h3 {
    margin-top: 0;
    margin-bottom: 24px;
    font-size: 1.125rem;
    font-weight: 600;
  }

  .info-item {
    display: flex;
    align-items: flex-start;
    gap: 14px;
    margin-bottom: 20px;

    .info-icon {
      width: 36px;
      height: 36px;
      background: var(--bg-secondary);
      border-radius: 9px;
      display: flex;
      align-items: center;
      justify-content: center;
      font-size: 1rem;
      flex-shrink: 0;
    }

    h4 {
      font-size: 0.875rem;
      font-weight: 600;
      margin-bottom: 3px;
      margin-top: 0;
      color: var(--text-primary);
    }

    p, a {
      font-size: 0.8125rem;
      color: var(--text-muted);
      margin: 0;
      line-height: 1.5;
    }

    a {
      text-decoration: none;

      &:hover {
        color: var(--shel-green);
      }
    }
  }
}

// ============================================
// CONTRIBUTION CARDS (Community page)
// ============================================

.contrib-grid {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(240px, 1fr));
  gap: 16px;
  margin-top: 24px;
}

.contrib-card {
  padding: 24px;
  background: var(--bg-card);
  border: 1px solid var(--border-primary);
  border-radius: var(--radius-md);
  transition: all 0.25s ease;

  &:hover {
    border-color: var(--border-glow);
    box-shadow: var(--shadow-md);
    transform: translateY(-2px);
  }

  .contrib-icon {
    font-size: 1.75rem;
    margin-bottom: 12px;
  }

  h4 {
    font-size: 1rem;
    font-weight: 600;
    margin-bottom: 8px;
    margin-top: 0;
    color: var(--text-primary);
  }

  p {
    font-size: 0.8125rem;
    color: var(--text-muted);
    line-height: 1.55;
    margin: 0;

    a {
      color: var(--link-color);
      text-decoration: none;

      &:hover {
        text-decoration: underline;
      }
    }
  }
}

// ============================================
// PAGE CONTENT (general)
// ============================================

.post-content {
  h1, h2, h3, h4, h5, h6 {
    margin-top: 40px;
    margin-bottom: 16px;
    color: var(--text-primary);
    scroll-margin-top: 72px;
  }

  h1 {
    font-size: 2rem;
    font-weight: 700;
    letter-spacing: -0.02em;
    border-bottom: 1px solid var(--border-primary);
    padding-bottom: 12px;
  }

  h2 {
    font-size: 1.5rem;
    font-weight: 600;
    letter-spacing: -0.01em;
    border-bottom: 1px solid var(--border-primary);
    padding-bottom: 8px;
  }

  h3 {
    font-size: 1.25rem;
    font-weight: 600;
  }

  h4 {
    font-size: 1.1rem;
    font-weight: 600;
  }

  p {
    margin-bottom: 16px;
    line-height: 1.7;
  }

  ul, ol {
    margin-bottom: 16px;
    padding-left: 24px;

    li {
      margin-bottom: 6px;
      line-height: 1.6;
    }
  }

  a {
    color: var(--link-color);
    text-decoration: none;

    &:hover {
      text-decoration: underline;
      color: var(--link-hover);
    }
  }

  blockquote {
    border-left: 3px solid var(--shel-green);
    padding: 12px 20px;
    margin: 20px 0;
    background: var(--bg-secondary);
    border-radius: 0 var(--radius-sm) var(--radius-sm) 0;
    color: var(--text-secondary);
    font-style: italic;

    p:last-child {
      margin-bottom: 0;
    }
  }

  img {
    max-width: 100%;
    border-radius: var(--radius-md);
    border: 1px solid var(--border-primary);
  }

  table {
    width: 100%;
    border-collapse: collapse;
    margin: 20px 0;
    font-size: 0.875rem;

    th, td {
      padding: 10px 14px;
      text-align: left;
      border-bottom: 1px solid var(--border-primary);
    }

    th {
      font-weight: 600;
      color: var(--text-primary);
      background: var(--bg-secondary);
    }

    tr:hover {
      background: var(--bg-secondary);
    }
  }

  hr {
    border: none;
    border-top: 1px solid var(--border-primary);
    margin: 32px 0;
  }

  strong {
    color: var(--text-primary);
    font-weight: 600;
  }
}

// ============================================
// SCROLL REVEAL
// ============================================

.reveal {
  opacity: 0;
  transform: translateY(40px) scale(0.98);
  filter: blur(2px);
  transition:
    opacity 0.7s cubic-bezier(0.22, 1, 0.36, 1),
    transform 0.7s cubic-bezier(0.22, 1, 0.36, 1),
    filter 0.7s cubic-bezier(0.22, 1, 0.36, 1);

  &.revealed {
    opacity: 1;
    transform: translateY(0) scale(1);
    filter: blur(0);
  }
}

.reveal-delay-1 { transition-delay: 0.10s; }
.reveal-delay-2 { transition-delay: 0.20s; }
.reveal-delay-3 { transition-delay: 0.30s; }
.reveal-delay-4 { transition-delay: 0.40s; }
.reveal-delay-5 { transition-delay: 0.50s; }

// ============================================
// UTILITY
// ============================================

.text-center { text-align: center; }
.container-narrow { max-width: 720px; margin: 0 auto; }
"""

let render() = file
