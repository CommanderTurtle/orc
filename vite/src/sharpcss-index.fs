module ConvertedFiles.Src.IndexCss

let file = """@import url('https://fonts.googleapis.com/css2?family=Playfair+Display:wght@400;500;600;700;800;900&family=Inter:wght@300;400;500;600;700&family=Source+Code+Pro:wght@400;500;600&display=swap');

@tailwind base;
@tailwind components;
@tailwind utilities;

@layer base {
  :root {
    --background: 0 0% 100%;
    --foreground: 240 10% 3.9%;
    --card: 0 0% 100%;
    --card-foreground: 240 10% 3.9%;
    --popover: 0 0% 100%;
    --popover-foreground: 240 10% 3.9%;
    --primary: 240 5.9% 10%;
    --primary-foreground: 0 0% 98%;
    --secondary: 240 4.8% 95.9%;
    --secondary-foreground: 240 5.9% 10%;
    --muted: 240 4.8% 95.9%;
    --muted-foreground: 240 3.8% 46.1%;
    --accent: 240 4.8% 95.9%;
    --accent-foreground: 240 5.9% 10%;
    --destructive: 0 84.2% 60.2%;
    --destructive-foreground: 0 0% 98%;
    --border: 240 5.9% 90%;
    --input: 240 5.9% 90%;
    --ring: 240 5.9% 10%;
    --radius: 0.625rem;
    --sidebar-background: 0 0% 98%;
    --sidebar-foreground: 240 5.3% 26.1%;
    --sidebar-primary: 240 5.9% 10%;
    --sidebar-primary-foreground: 0 0% 98%;
    --sidebar-accent: 240 4.8% 95.9%;
    --sidebar-accent-foreground: 240 5.9% 10%;
    --sidebar-border: 220 13% 91%;
    --sidebar-ring: 217.2 91.2% 59.8%;

    /* Turtle Protect Design System */
    --turtle-green: #2D6A4F;
    --deep-forest: #1B4332;
    --shell-gold: #D4A574;
    --warm-cream: #FAF6F1;
    --sage-mist: #A3B18A;
    --ocean-teal: #2A9D8F;
    --soft-coral: #E07A5F;
    --dawn-blush: #F2E9E4;
    --ink: #1A1A1A;
    --slate-text: #4A4A4A;
    --stone-muted: #8A8A8A;
    --pearl: #F0EDE8;

    /* Semantic */
    --success: #52B788;
    --alert: #E9C46A;
    --error: #E76F51;
    --info: #457B9D;
  }

  html {
    scroll-behavior: smooth;
  }

  body {
    @apply bg-warm-cream text-ink font-body antialiased;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
  }

  * {
    @apply border-border;
  }
}

@layer utilities {
  .section-warm-cream {
    background-color: var(--warm-cream);
  }

  .section-deep-forest {
    background-color: var(--deep-forest);
  }

  .section-white {
    background-color: #FFFFFF;
  }

  .gradient-hero-green {
    background: linear-gradient(135deg, #1B4332 0%, #2D6A4F 50%, #2A9D8F 100%);
  }

  .gradient-warm-glow {
    background: linear-gradient(180deg, #FAF6F1 0%, #F2E9E4 100%);
  }

  .gradient-shell-shine {
    background: linear-gradient(45deg, #D4A574 0%, #E9C46A 50%, #D4A574 100%);
  }

  .gradient-forest-depth {
    background: linear-gradient(to bottom, rgba(27,67,50,0.95), rgba(27,67,50,0.8));
  }

  .text-shadow-hero {
    text-shadow: 0 2px 40px rgba(0,0,0,0.3);
  }

  .font-stat {
    font-family: 'Source Code Pro', monospace;
    font-weight: 700;
    font-size: clamp(2rem, 4vw, 3.5rem);
    line-height: 1.0;
    letter-spacing: -0.02em;
  }

  /* Partner Marquee animations */
  @keyframes marquee-left {
    0%   { transform: translateX(0); }
    100% { transform: translateX(-50%); }
  }
  @keyframes marquee-right {
    0%   { transform: translateX(-50%); }
    100% { transform: translateX(0); }
  }
  .animate-marquee-left {
    animation: marquee-left 45s linear infinite;
    width: max-content;
  }
  .animate-marquee-right {
    animation: marquee-right 40s linear infinite;
    width: max-content;
  }
  .animate-marquee-left:hover,
  .animate-marquee-right:hover {
    animation-play-state: paused;
  }

  /* Health page entrance animations */
  @keyframes fadeInUp {
    from { opacity: 0; transform: translateY(30px); }
    to   { opacity: 1; transform: translateY(0); }
  }
  @keyframes fadeInRight {
    from { opacity: 0; transform: translateX(40px); }
    to   { opacity: 1; transform: translateX(0); }
  }
}

/* ═══════════════════════════════════════════════════════════
   PRINT STYLES — Dashboard & Global
   ═══════════════════════════════════════════════════════════ */

@media print {
  /* Hide navigation, footer, chat, and interactive elements */
  nav,
  footer,
  .fixed,
  button,
  a[href^="tel:"],
  .no-print {
    display: none !important;
  }

  /* Ensure dashboard content is visible and full-width */
  body {
    background: white !important;
    -webkit-print-color-adjust: exact !important;
    print-color-adjust: exact !important;
  }

  /* Remove gradients for cleaner print, use solid colors */
  .gradient-hero-green {
    background: #1B4332 !important;
  }

  /* Ensure sections don't break awkwardly */
  section {
    break-inside: avoid;
    page-break-inside: avoid;
  }

  /* Make charts and tables print-friendly */
  svg,
  table {
    max-width: 100% !important;
  }

  /* Show all motion-hidden content */
  [style*="opacity: 0"] {
    opacity: 1 !important;
  }

  /* Add page title header */
  .print-header {
    display: block !important;
    text-align: center;
    padding: 1rem 0;
    border-bottom: 2px solid #2D6A4F;
    margin-bottom: 1rem;
  }

  /* Links should show their URL */
  a[href]::after {
    content: none !important;
  }
}
"""

let render() = file
