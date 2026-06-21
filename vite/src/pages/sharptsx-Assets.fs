module ConvertedFiles.Src.Pages.AssetsTsx

let file = """import { useState, useEffect, useRef, useMemo } from 'react';
import { Link } from 'react-router-dom';
import { motion, useInView, useMotionValue, useTransform, animate } from 'framer-motion';
import {
  Shield,
  TrendingUp,
  BarChart3,
  Calendar,
  Check,
  ChevronDown,
  Clock,
  Users,
  Phone,
  ArrowRight,
  CircleDollarSign,
} from 'lucide-react';

/* ───────── Animation helpers ───────── */

const fadeUpVariants = {
  hidden: { opacity: 0, y: 40 },
  visible: { opacity: 1, y: 0 },
};

const slideInLeftVariants = {
  hidden: { opacity: 0, x: -60 },
  visible: { opacity: 1, x: 0 },
};

const slideInRightVariants = {
  hidden: { opacity: 0, x: 60 },
  visible: { opacity: 1, x: 0 },
};

const scaleInVariants = {
  hidden: { opacity: 0, scale: 0.9 },
  visible: { opacity: 1, scale: 1 },
};

const staggerContainer = {
  hidden: {},
  visible: { transition: { staggerChildren: 0.08 } },
};

const defaultTransition = {
  duration: 0.6,
  ease: [0.25, 0.46, 0.45, 0.94] as [number, number, number, number],
};

/* ───────── Animated counter hook ───────── */

function useAnimatedCounter(target: number, duration: number = 1.5, enabled: boolean = true) {
  const motionVal = useMotionValue(0);
  const rounded = useTransform(motionVal, (v) => Math.round(v));
  const [display, setDisplay] = useState(0);

  useEffect(() => {
    if (!enabled) return;
    const controls = animate(motionVal, target, {
      duration,
      ease: [0.25, 0.46, 0.45, 0.94] as [number, number, number, number],
    });
    const unsub = rounded.on('change', (v) => setDisplay(v));
    return () => {
      controls.stop();
      unsub();
    };
  }, [target, duration, enabled, motionVal, rounded]);

  return display;
}

/* ───────── Section 1: Hero ───────── */

function HeroSection() {
  const [hovered, setHovered] = useState(false);

  const ring1 = { size: 280, duration: 60, color: '#2D6A4F', width: 3 };
  const ring2 = { size: 220, duration: 45, color: '#D4A574', width: 3 };
  const ring3 = { size: 160, duration: 75, color: '#2A9D8F', width: 3 };

  const stats = [
    { value: 250, suffix: 'B+', label: 'Annual annuity sales in 2024' },
    { value: 6, suffix: '.2%', label: 'Average fixed annuity rate (2024)' },
    { value: 85, suffix: '%', label: 'Of retirees worry about outliving savings' },
  ];

  const sectionRef = useRef<HTMLDivElement>(null);
  const isInView = useInView(sectionRef, { once: true });

  const stat1 = useAnimatedCounter(250, 1.5, isInView);
  const stat2 = useAnimatedCounter(6, 1.5, isInView);
  const stat3 = useAnimatedCounter(85, 1.5, isInView);
  const statDisplays = [`${stat1}B+`, `${stat2}.2%`, `${stat3}%`];

  return (
    <section
      ref={sectionRef}
      className="relative overflow-hidden"
      style={{
        minHeight: '70vh',
        background: 'linear-gradient(160deg, #2D6A4F 0%, #1B4332 60%, #0D2818 100%)',
        paddingTop: '120px',
        paddingBottom: '80px',
      }}
    >
      <div className="max-w-[1280px] mx-auto relative z-10" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
        <div className="flex flex-col lg:flex-row items-center gap-12">
          {/* Left column - text */}
          <motion.div
            className="flex-1 lg:max-w-[55%]"
            initial="hidden"
            animate="visible"
            variants={staggerContainer}
          >
            <motion.span
              variants={fadeUpVariants}
              transition={{ ...defaultTransition, delay: 0 }}
              className="inline-block font-body font-medium text-[0.75rem] uppercase tracking-[0.05em] mb-4"
              style={{ color: '#D4A574' }}
            >
              ASSET PROTECTION
            </motion.span>

            <motion.h1
              variants={fadeUpVariants}
              transition={{ ...defaultTransition, delay: 0.1 }}
              className="font-display font-bold text-white mb-6"
              style={{
                fontSize: 'clamp(2rem, 5vw, 4rem)',
                lineHeight: 1.1,
                letterSpacing: '-0.02em',
              }}
            >
              Build a fortress around your wealth.
            </motion.h1>

            <motion.p
              variants={fadeUpVariants}
              transition={{ ...defaultTransition, delay: 0.2 }}
              className="font-body text-[1.125rem] leading-[1.7] mb-8"
              style={{ color: 'rgba(255,255,255,0.8)' }}
            >
              Annuities are the ultimate financial shell — protecting your assets from market crashes,
              outliving your savings, and the unexpected. Discover how Turtle Protect helps you build
              unshakable retirement income.
            </motion.p>

            {/* Stats row */}
            <motion.div
              variants={fadeUpVariants}
              transition={{ ...defaultTransition, delay: 0.4 }}
              className="flex flex-wrap gap-8 mb-10"
            >
              {stats.map((s, i) => (
                <div key={i} className="flex flex-col">
                  <span
                    className="font-mono font-bold text-[clamp(1.5rem,3vw,2.5rem)] leading-none"
                    style={{ color: '#D4A574', letterSpacing: '-0.02em' }}
                  >
                    {statDisplays[i]}
                  </span>
                  <span className="font-body text-[0.75rem] mt-1" style={{ color: 'rgba(255,255,255,0.6)' }}>
                    {s.label}
                  </span>
                </div>
              ))}
            </motion.div>

            <motion.div variants={fadeUpVariants} transition={{ ...defaultTransition, delay: 0.6 }}>
              <Link
                to="#calculator"
                className="inline-block font-body font-semibold text-[0.875rem] bg-white text-[#2D6A4F] px-8 py-3.5 rounded-lg transition-all duration-200 hover:scale-[1.03]"
                style={{ letterSpacing: '0.01em' }}
              >
                Explore Annuity Options
              </Link>
            </motion.div>
          </motion.div>

          {/* Right column - animated rings */}
          <motion.div
            className="flex-1 flex flex-col items-center justify-center"
            initial={{ opacity: 0, scale: 0.5 }}
            animate={{ opacity: 1, scale: 1 }}
            transition={{ duration: 0.8, delay: 0.3, ease: [0.16, 1, 0.3, 1] as [number, number, number, number] }}
            onMouseEnter={() => setHovered(true)}
            onMouseLeave={() => setHovered(false)}
          >
            <div className="relative" style={{ width: '320px', height: '320px' }}>
              {/* Outer ring */}
              <motion.div
                className="absolute rounded-full border-2 border-dashed"
                style={{
                  width: ring1.size,
                  height: ring1.size,
                  borderColor: ring1.color,
                  top: '50%',
                  left: '50%',
                  marginLeft: -ring1.size / 2,
                  marginTop: -ring1.size / 2,
                  opacity: 0.6,
                }}
                animate={{ rotate: 360 }}
                transition={{
                  duration: hovered ? ring1.duration / 3 : ring1.duration,
                  repeat: Infinity,
                  ease: [0, 0, 1, 1] as [number, number, number, number],
                }}
              />
              {/* Middle ring - counter rotation */}
              <motion.div
                className="absolute rounded-full border-2 border-dashed"
                style={{
                  width: ring2.size,
                  height: ring2.size,
                  borderColor: ring2.color,
                  top: '50%',
                  left: '50%',
                  marginLeft: -ring2.size / 2,
                  marginTop: -ring2.size / 2,
                  opacity: 0.7,
                }}
                animate={{ rotate: -360 }}
                transition={{
                  duration: hovered ? ring2.duration / 3 : ring2.duration,
                  repeat: Infinity,
                  ease: [0, 0, 1, 1] as [number, number, number, number],
                }}
              />
              {/* Inner ring */}
              <motion.div
                className="absolute rounded-full border-2 border-dashed"
                style={{
                  width: ring3.size,
                  height: ring3.size,
                  borderColor: ring3.color,
                  top: '50%',
                  left: '50%',
                  marginLeft: -ring3.size / 2,
                  marginTop: -ring3.size / 2,
                  opacity: 0.8,
                }}
                animate={{ rotate: 360 }}
                transition={{
                  duration: hovered ? ring3.duration / 3 : ring3.duration,
                  repeat: Infinity,
                  ease: [0, 0, 1, 1] as [number, number, number, number],
                }}
              />
              {/* Center icon */}
              <motion.div
                className="absolute flex items-center justify-center rounded-full"
                style={{
                  width: 80,
                  height: 80,
                  background: 'linear-gradient(45deg, #D4A574, #E9C46A)',
                  top: '50%',
                  left: '50%',
                  marginLeft: -40,
                  marginTop: -40,
                  boxShadow: hovered ? '0 0 40px rgba(212,165,116,0.5)' : '0 0 20px rgba(212,165,116,0.2)',
                  transition: 'box-shadow 0.3s ease',
                }}
                animate={{ scale: [1, 1.05, 1] }}
                transition={{ duration: 3, repeat: Infinity, ease: [0.42, 0, 0.58, 1] as [number, number, number, number] }}
              >
                <CircleDollarSign size={36} className="text-white" />
              </motion.div>
              {/* Labels */}
              <span
                className="absolute font-body text-[0.65rem] uppercase tracking-wider"
                style={{ color: '#2D6A4F', top: '8%', right: '5%' }}
              >
                Market Protection
              </span>
              <span
                className="absolute font-body text-[0.65rem] uppercase tracking-wider"
                style={{ color: '#D4A574', top: '28%', left: '0%' }}
              >
                Guaranteed Income
              </span>
              <span
                className="absolute font-body text-[0.65rem] uppercase tracking-wider"
                style={{ color: '#2A9D8F', bottom: '18%', right: '10%' }}
              >
                Legacy Preservation
              </span>
            </div>
            <p
              className="mt-6 font-display italic text-center"
              style={{ color: 'rgba(255,255,255,0.5)', fontSize: '0.9rem' }}
            >
              Layer by layer, your wealth is protected.
            </p>
          </motion.div>
        </div>
      </div>
    </section>
  );
}

/* ───────── Section 2: Why Annuities Matter ───────── */

function WhyAnnuitiesSection() {
  const ref = useRef<HTMLDivElement>(null);
  const isInView = useInView(ref, { once: true, margin: '-20% 0px' });

  const pillars = [
    {
      icon: Shield,
      stat: 'Never lose principal',
      title: 'Market Protection',
      description:
        'Fixed and indexed annuities protect your principal from market downturns. Even when the S&P 500 drops 20%, your annuity balance stays intact. In 2022, when the market fell 19.4%, fixed annuity holders saw zero losses.',
    },
    {
      icon: Clock,
      stat: 'Income for life',
      title: 'Guaranteed Income',
      description:
        'A $500,000 annuity can generate $2,500-$3,500 per month for life — regardless of how long you live. In 2026, with Americans living longer than ever, this guarantee is invaluable. Social Security was never meant to be your only income source.',
    },
    {
      icon: Users,
      stat: 'Leave more behind',
      title: 'Legacy Planning',
      description:
        'Certain annuities include death benefits that guarantee your beneficiaries receive at least your principal back, even if you pass away early. Some advanced strategies use annuities to create tax-efficient wealth transfers to heirs.',
    },
  ];

  return (
    <section className="bg-warm-cream" style={{ padding: '6rem 0' }}>
      <div className="max-w-[1280px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
        <motion.div
          ref={ref}
          initial="hidden"
          animate={isInView ? 'visible' : 'hidden'}
          variants={staggerContainer}
          className="text-center mb-12"
        >
          <motion.span
            variants={fadeUpVariants}
            transition={defaultTransition}
            className="inline-block font-body font-medium text-[0.75rem] uppercase tracking-[0.05em] mb-4 text-turtle-green"
          >
            THE ANNUITY ADVANTAGE
          </motion.span>
          <motion.h2
            variants={fadeUpVariants}
            transition={{ ...defaultTransition, delay: 0.1 }}
            className="font-display font-semibold text-ink"
            style={{ fontSize: 'clamp(1.5rem, 3vw, 2.5rem)', lineHeight: 1.2, letterSpacing: '-0.01em' }}
          >
            Three reasons annuities belong in your portfolio
          </motion.h2>
        </motion.div>

        <div className="grid grid-cols-1 md:grid-cols-3" style={{ gap: '2rem' }}>
          {pillars.map((p, i) => (
            <motion.div
              key={i}
              initial="hidden"
              whileInView="visible"
              viewport={{ once: true, margin: '-20% 0px' }}
              variants={fadeUpVariants}
              transition={{ ...defaultTransition, delay: i * 0.12 }}
              className="bg-white rounded-xl p-8 relative overflow-hidden transition-all duration-300 hover:-translate-y-1 hover:shadow-card-hover"
              style={{
                border: '1px solid #F0EDE8',
                boxShadow: '0 1px 3px rgba(0,0,0,0.04), 0 4px 12px rgba(0,0,0,0.02)',
              }}
            >
              {/* Top accent bar */}
              <div
                className="absolute top-0 left-0 right-0 h-1"
                style={{ background: 'linear-gradient(45deg, #D4A574 0%, #E9C46A 50%, #D4A574 100%)' }}
              />
              <motion.div
                className="w-14 h-14 rounded-xl flex items-center justify-center mb-4"
                style={{ background: 'rgba(45,106,79,0.08)' }}
                variants={scaleInVariants}
                transition={{ duration: 0.4, ease: [0.34, 1.56, 0.64, 1] as [number, number, number, number], delay: 0.2 + i * 0.12 }}
              >
                <p.icon size={28} className="text-turtle-green" />
              </motion.div>
              <div className="font-mono font-bold text-[1.5rem] text-turtle-green mb-2">{p.stat}</div>
              <h3 className="font-body font-semibold text-[1.25rem] text-ink mb-3">{p.title}</h3>
              <p className="font-body text-[1rem] leading-[1.7] text-slate-text">{p.description}</p>
            </motion.div>
          ))}
        </div>
      </div>
    </section>
  );
}

/* ───────── Section 3: Annuity Types ───────── */

function AnnuityTypesSection() {
  const types = [
    {
      title: 'Fixed Annuities',
      subtitle: 'Guaranteed growth. Zero market risk.',
      badge: 'MOST SECURE',
      badgeBg: '#2D6A4F',
      badgeText: '#FFFFFF',
      icon: Shield,
      visualGradient: 'linear-gradient(135deg, #2D6A4F, #1B4332)',
      description:
        'Your money grows at a guaranteed interest rate set by the insurance company — typically 4-7% for multi-year guaranteed annuities (MYGAs). You know exactly what you\'ll earn, with no surprises.',
      features: [
        'Principal fully protected from market losses',
        'Guaranteed interest rate for the entire term',
        'Tax-deferred growth until withdrawal',
        'Terms from 2-10 years available',
        'Penalty-free withdrawals up to 10% annually',
      ],
      ratesNote: 'Current MYGA rates: 3-year at 5.25%, 5-year at 5.85%, 7-year at 5.95% (as of Q1 2026)',
      bestFor: 'Conservative investors, those within 5 years of retirement, anyone who cannot tolerate market losses',
      cta: 'Learn More About Fixed Annuities',
    },
    {
      title: 'Fixed Indexed Annuities (FIA)',
      subtitle: 'Market-linked growth. Downside protection.',
      badge: 'BEST OF BOTH WORLDS',
      badgeBg: '#D4A574',
      badgeText: '#1B4332',
      icon: BarChart3,
      visualGradient: 'linear-gradient(135deg, #D4A574, #E9C46A)',
      description:
        'Your returns are linked to a market index (like the S&P 500) — when the market goes up, you participate in gains (subject to caps). When the market goes down, you lose nothing. The insurance company absorbs the losses.',
      features: [
        'Zero risk of principal loss due to market declines',
        'Participate in market upside with caps (typically 4-8%)',
        'Multiple index options: S&P 500, Nasdaq, international',
        'Optional income riders for guaranteed lifetime withdrawals',
        'Tax-deferred growth',
      ],
      ratesNote: 'Average participation rates have increased to 35-55% with cap rates of 5-7.5% in 2026',
      bestFor: 'Investors who want some market upside but cannot afford losses, pre-retirees seeking growth with protection',
      cta: 'Explore Fixed Indexed Annuities',
    },
    {
      title: 'Variable Annuities',
      subtitle: 'Direct market investment. Professional management.',
      badge: 'HIGHEST GROWTH POTENTIAL',
      badgeBg: '#2A9D8F',
      badgeText: '#FFFFFF',
      icon: TrendingUp,
      visualGradient: 'linear-gradient(135deg, #2A9D8F, #2D6A4F)',
      description:
        'Invest directly in sub-accounts (similar to mutual funds) within the annuity wrapper. You bear the investment risk, but you gain access to professional money management, tax-deferred growth, and optional guaranteed income riders.',
      features: [
        'Invest in professionally managed sub-accounts',
        'Tax-deferred growth on investment gains',
        'Optional Guaranteed Lifetime Withdrawal Benefits (GLWB)',
        'Death benefit guarantees available',
        'Dollar-cost averaging and portfolio rebalancing options',
      ],
      ratesNote: '',
      bestFor: 'Younger investors with longer time horizons, those who want professional management, investors seeking tax-deferred growth',
      cta: 'Discover Variable Annuities',
    },
    {
      title: 'Immediate & Income Annuities',
      subtitle: 'Turn savings into guaranteed paychecks for life.',
      badge: 'INSTANT INCOME',
      badgeBg: '#E07A5F',
      badgeText: '#FFFFFF',
      icon: Calendar,
      visualGradient: 'linear-gradient(135deg, #E07A5F, #E9C46A)',
      description:
        'You make a single premium payment, and the insurance company guarantees a stream of income payments that start immediately or within one year. These are pure income contracts — simple, predictable, and reliable.',
      features: [
        'Income starts within 12 months of purchase',
        'Payments guaranteed for life, period certain, or both',
        'Higher payout rates than most other income strategies',
        'No investment decisions to manage',
        'Can cover one life or two lives (joint)',
      ],
      ratesNote: 'A 65-year-old male investing $300,000 could receive approximately $1,850-$2,100 per month for life (2026 estimates)',
      bestFor: 'Retirees who need immediate income, those who want to eliminate longevity risk, conservative investors seeking maximum income',
      cta: 'Calculate Your Income',
    },
  ];

  return (
    <section className="bg-white" style={{ padding: '6rem 0' }}>
      <div className="max-w-[1280px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
        <motion.div
          initial="hidden"
          whileInView="visible"
          viewport={{ once: true, margin: '-20% 0px' }}
          variants={staggerContainer}
          className="mb-10"
        >
          <motion.span
            variants={fadeUpVariants}
            transition={defaultTransition}
            className="inline-block font-body font-medium text-[0.75rem] uppercase tracking-[0.05em] mb-4"
            style={{ color: '#D4A574' }}
          >
            TYPES OF ANNUITIES
          </motion.span>
          <motion.h2
            variants={fadeUpVariants}
            transition={{ ...defaultTransition, delay: 0.1 }}
            className="font-display font-bold text-ink mb-4"
            style={{ fontSize: 'clamp(2rem, 5vw, 4rem)', lineHeight: 1.1, letterSpacing: '-0.02em' }}
          >
            Choose your protective shell
          </motion.h2>
          <motion.p
            variants={fadeUpVariants}
            transition={{ ...defaultTransition, delay: 0.2 }}
            className="font-body text-[1.125rem] text-slate-text max-w-2xl"
          >
            Each type offers a different balance of growth potential, guarantees, and flexibility. Our advisors help you find the right fit.
          </motion.p>
        </motion.div>

        <div className="flex flex-col" style={{ gap: '1.5rem' }}>
          {types.map((t, i) => (
            <motion.div
              key={i}
              initial="hidden"
              whileInView="visible"
              viewport={{ once: true, margin: '-15% 0px' }}
              variants={slideInRightVariants}
              transition={{ ...defaultTransition, delay: i * 0.15 }}
              className="flex flex-col md:flex-row rounded-2xl overflow-hidden transition-all duration-300 hover:shadow-card-hover group"
              style={{
                border: '1px solid #F0EDE8',
                boxShadow: '0 1px 3px rgba(0,0,0,0.04), 0 4px 12px rgba(0,0,0,0.02)',
              }}
            >
              {/* Left visual */}
              <motion.div
                className="md:w-[30%] flex items-center justify-center relative"
                style={{ background: t.visualGradient, minHeight: '160px' }}
                variants={scaleInVariants}
                transition={{ duration: 0.5, ease: [0.16, 1, 0.3, 1] as [number, number, number, number], delay: i * 0.15 }}
              >
                <t.icon size={80} className="text-white" style={{ opacity: 0.3 }} />
              </motion.div>

              {/* Right content */}
              <div className="md:w-[70%] p-8 relative">
                {/* Top accent */}
                <div className="absolute top-0 left-0 right-0 h-1" style={{ background: t.visualGradient }} />
                <div className="flex flex-wrap items-center gap-3 mb-3">
                  <span
                    className="inline-block px-3 py-1 rounded-full text-[0.7rem] font-body font-semibold uppercase tracking-wider"
                    style={{ background: t.badgeBg, color: t.badgeText }}
                  >
                    {t.badge}
                  </span>
                </div>
                <h3 className="font-body font-semibold text-[1.5rem] text-ink mb-1">{t.title}</h3>
                <p className="font-body font-medium text-[1rem] mb-3" style={{ color: t.badgeBg }}>
                  {t.subtitle}
                </p>
                <p className="font-body text-[1rem] leading-[1.7] text-slate-text mb-4">{t.description}</p>

                <div className="grid grid-cols-1 sm:grid-cols-2 gap-2 mb-4">
                  {t.features.map((f, fi) => (
                    <div key={fi} className="flex items-start gap-2">
                      <Check size={16} className="text-turtle-green mt-1 flex-shrink-0" />
                      <span className="font-body text-[0.875rem] text-slate-text">{f}</span>
                    </div>
                  ))}
                </div>

                {t.ratesNote && (
                  <p className="font-body text-[0.8rem] text-stone-muted italic mb-4 p-3 rounded-lg bg-warm-cream">
                    {t.ratesNote}
                  </p>
                )}

                <div className="flex flex-wrap items-center justify-between gap-4">
                  <p className="font-body text-[0.8rem] text-slate-text">
                    <span className="font-semibold">Best for:</span> {t.bestFor}
                  </p>
                  <Link
                    to="/contact"
                    className="inline-flex items-center gap-2 font-body font-semibold text-[0.8rem] text-turtle-green border border-turtle-green px-4 py-2 rounded-lg transition-all duration-200 hover:bg-[rgba(45,106,79,0.08)] whitespace-nowrap"
                  >
                    {t.cta} <ArrowRight size={14} />
                  </Link>
                </div>
              </div>
            </motion.div>
          ))}
        </div>
      </div>
    </section>
  );
}

/* ───────── Section 4: Shell Concept ───────── */

function ShellConceptSection() {
  const [activeLayer, setActiveLayer] = useState<number | null>(null);

  const layers = [
    { name: 'Income Layer', color: '#E07A5F', desc: 'Immediate income annuities — your guaranteed paycheck' },
    { name: 'Growth Layer', color: '#2A9D8F', desc: 'Variable & indexed annuities — market participation with protection' },
    { name: 'Stability Layer', color: '#D4A574', desc: 'Fixed indexed annuities — moderate growth, zero downside' },
    { name: 'Foundation Layer', color: '#2D6A4F', desc: 'Fixed annuities & MYGAs — guaranteed principal, guaranteed rates' },
  ];

  const ref = useRef<HTMLDivElement>(null);

  return (
    <section className="gradient-warm-glow" style={{ padding: '6rem 0' }}>
      <div className="max-w-[1280px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
        <motion.div
          initial="hidden"
          whileInView="visible"
          viewport={{ once: true, margin: '-25% 0px' }}
          variants={staggerContainer}
          className="text-center mb-12"
        >
          <motion.span
            variants={fadeUpVariants}
            transition={defaultTransition}
            className="inline-block font-body font-medium text-[0.75rem] uppercase tracking-[0.05em] mb-4 text-turtle-green"
          >
            THE SHELL PHILOSOPHY
          </motion.span>
          <motion.h2
            variants={fadeUpVariants}
            transition={{ ...defaultTransition, delay: 0.1 }}
            className="font-display font-semibold text-ink mb-4"
            style={{ fontSize: 'clamp(1.5rem, 3vw, 2.5rem)', lineHeight: 1.2, letterSpacing: '-0.01em' }}
          >
            Layer your protection
          </motion.h2>
          <motion.p
            variants={fadeUpVariants}
            transition={{ ...defaultTransition, delay: 0.2 }}
            className="font-body text-[1.125rem] text-slate-text max-w-[640px] mx-auto leading-[1.7]"
          >
            Just like a turtle builds its shell layer by layer, your financial protection grows stronger with each annuity strategy you add.
          </motion.p>
        </motion.div>

        {/* Pyramid layers */}
        <div ref={ref} className="max-w-[700px] mx-auto flex flex-col-reverse" style={{ gap: '0.5rem' }}>
          {layers.map((layer, i) => {
            const widthPct = 60 + i * 10; // bottom widest
            const isActive = activeLayer === i;
            const isDimmed = activeLayer !== null && activeLayer !== i;

            return (
              <motion.div
                key={i}
                initial="hidden"
                whileInView="visible"
                viewport={{ once: true, margin: '-25% 0px' }}
                variants={i % 2 === 0 ? slideInLeftVariants : slideInRightVariants}
                transition={{ ...defaultTransition, delay: i * 0.2 }}
                className="mx-auto relative cursor-pointer transition-all duration-300 rounded-xl flex items-center justify-center"
                style={{
                  width: `${widthPct}%`,
                  height: '80px',
                  background: layer.color,
                  opacity: isDimmed ? 0.5 : 1,
                  transform: isActive ? 'scale(1.02)' : 'scale(1)',
                  boxShadow: isActive ? `0 8px 24px ${layer.color}40` : '0 2px 8px rgba(0,0,0,0.06)',
                }}
                onMouseEnter={() => setActiveLayer(i)}
                onMouseLeave={() => setActiveLayer(null)}
              >
                <span className="font-body font-semibold text-white text-[1rem]">{layer.name}</span>
                {/* Tooltip */}
                {isActive && (
                  <motion.div
                    initial={{ opacity: 0, y: 5 }}
                    animate={{ opacity: 1, y: 0 }}
                    className="absolute -bottom-12 left-1/2 -translate-x-1/2 bg-ink text-white text-[0.8rem] font-body px-4 py-2 rounded-lg whitespace-nowrap z-10"
                  >
                    {layer.desc}
                  </motion.div>
                )}
              </motion.div>
            );
          })}
        </div>
      </div>
    </section>
  );
}

/* ───────── Section 5: Growth Calculator ───────── */

function formatCurrency(n: number): string {
  if (n >= 1_000_000) return `$${(n / 1_000_000).toFixed(2)}M`;
  if (n >= 1_000) return `$${(n / 1_000).toFixed(0)}K`;
  return `$${n.toFixed(0)}`;
}

function formatFullCurrency(n: number): string {
  return new Intl.NumberFormat('en-US', { style: 'currency', currency: 'USD', maximumFractionDigits: 0 }).format(n);
}

function GrowthCalculatorSection() {
  const [initial, setInitial] = useState(100000);
  const [contribution, setContribution] = useState(5000);
  const [years, setYears] = useState(15);
  const [rate, setRate] = useState(5.5);

  const data = useMemo(() => {
    const points: { year: number; value: number; conservative: number; aggressive: number }[] = [];
    let val = initial;
    let cons = initial;
    let agg = initial;
    const r = rate / 100;
    const consR = 0.04;
    const aggR = 0.08;
    for (let y = 0; y <= years; y++) {
      if (y > 0) {
        val = val * (1 + r) + contribution;
        cons = cons * (1 + consR) + contribution;
        agg = agg * (1 + aggR) + contribution;
      }
      points.push({ year: y, value: Math.round(val), conservative: Math.round(cons), aggressive: Math.round(agg) });
    }
    return points;
  }, [initial, contribution, years, rate]);

  const finalValue = data[data.length - 1]?.value ?? 0;
  const savingsValue = initial + contribution * years; // Simple sum without interest
  const diff = finalValue - savingsValue;

  // SVG chart dimensions
  const chartW = 500;
  const chartH = 250;
  const pad = { top: 20, right: 20, bottom: 40, left: 60 };
  const innerW = chartW - pad.left - pad.right;
  const innerH = chartH - pad.top - pad.bottom;

  const maxVal = data[data.length - 1]?.aggressive ?? 1;

  const xScale = (year: number) => pad.left + (year / years) * innerW;
  const yScale = (val: number) => pad.top + innerH - (val / maxVal) * innerH;

  // Build area path
  const areaPath = useMemo(() => {
    let d = `M ${xScale(0)} ${yScale(data[0].value)}`;
    for (let i = 1; i < data.length; i++) {
      d += ` L ${xScale(data[i].year)} ${yScale(data[i].value)}`;
    }
    d += ` L ${xScale(data[data.length - 1].year)} ${pad.top + innerH} L ${xScale(0)} ${pad.top + innerH} Z`;
    return d;
  }, [data]);

  // Conservative area
  const consPath = useMemo(() => {
    let d = `M ${xScale(0)} ${yScale(data[0].conservative)}`;
    for (let i = 1; i < data.length; i++) {
      d += ` L ${xScale(data[i].year)} ${yScale(data[i].conservative)}`;
    }
    d += ` L ${xScale(data[data.length - 1].year)} ${pad.top + innerH} L ${xScale(0)} ${pad.top + innerH} Z`;
    return d;
  }, [data]);

  // Aggressive line
  const aggLine = useMemo(() => {
    let d = `M ${xScale(0)} ${yScale(data[0].aggressive)}`;
    for (let i = 1; i < data.length; i++) {
      d += ` L ${xScale(data[i].year)} ${yScale(data[i].aggressive)}`;
    }
    return d;
  }, [data]);

  // Main line
  const mainLine = useMemo(() => {
    let d = `M ${xScale(0)} ${yScale(data[0].value)}`;
    for (let i = 1; i < data.length; i++) {
      d += ` L ${xScale(data[i].year)} ${yScale(data[i].value)}`;
    }
    return d;
  }, [data]);

  return (
    <section id="calculator" className="bg-deep-forest" style={{ padding: '6rem 0' }}>
      <div className="max-w-[1000px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
        <motion.div
          initial="hidden"
          whileInView="visible"
          viewport={{ once: true, margin: '-25% 0px' }}
          variants={staggerContainer}
          className="text-center mb-10"
        >
          <motion.span
            variants={fadeUpVariants}
            transition={defaultTransition}
            className="inline-block font-body font-medium text-[0.75rem] uppercase tracking-[0.05em] mb-4"
            style={{ color: '#D4A574' }}
          >
            GROWTH CALCULATOR
          </motion.span>
          <motion.h2
            variants={fadeUpVariants}
            transition={{ ...defaultTransition, delay: 0.1 }}
            className="font-display font-bold text-white"
            style={{ fontSize: 'clamp(2rem, 5vw, 4rem)', lineHeight: 1.1, letterSpacing: '-0.02em' }}
          >
            See how your shell grows
          </motion.h2>
        </motion.div>

        <div className="flex flex-col lg:flex-row gap-8">
          {/* Inputs */}
          <motion.div
            className="lg:w-[45%] rounded-2xl p-8"
            style={{ background: 'rgba(255,255,255,0.05)', border: '1px solid rgba(255,255,255,0.1)' }}
            initial="hidden"
            whileInView="visible"
            viewport={{ once: true, margin: '-25% 0px' }}
            variants={slideInLeftVariants}
            transition={{ ...defaultTransition }}
          >
            {/* Initial investment */}
            <div className="mb-6">
              <label className="block font-body font-medium text-[0.875rem] text-white mb-2">
                Initial Investment
              </label>
              <div className="flex items-center gap-3 mb-2">
                <span className="font-mono text-[1.25rem] text-shell-gold">{formatFullCurrency(initial)}</span>
              </div>
              <input
                type="range"
                min={10000}
                max={1000000}
                step={10000}
                value={initial}
                onChange={(e) => setInitial(Number(e.target.value))}
                className="w-full accent-shell-gold cursor-pointer"
              />
              <div className="flex justify-between font-body text-[0.65rem] text-stone-muted mt-1">
                <span>$10K</span>
                <span>$1M</span>
              </div>
            </div>

            {/* Annual contribution */}
            <div className="mb-6">
              <label className="block font-body font-medium text-[0.875rem] text-white mb-2">
                Annual Contribution
              </label>
              <div className="flex items-center gap-3 mb-2">
                <span className="font-mono text-[1.25rem] text-shell-gold">{formatFullCurrency(contribution)}</span>
              </div>
              <input
                type="range"
                min={0}
                max={50000}
                step={1000}
                value={contribution}
                onChange={(e) => setContribution(Number(e.target.value))}
                className="w-full accent-shell-gold cursor-pointer"
              />
              <div className="flex justify-between font-body text-[0.65rem] text-stone-muted mt-1">
                <span>$0</span>
                <span>$50K</span>
              </div>
            </div>

            {/* Years */}
            <div className="mb-6">
              <label className="block font-body font-medium text-[0.875rem] text-white mb-2">
                Time Horizon (years)
              </label>
              <div className="flex items-center gap-3 mb-2">
                <span className="font-mono text-[1.25rem] text-shell-gold">{years} years</span>
              </div>
              <input
                type="range"
                min={5}
                max={30}
                step={1}
                value={years}
                onChange={(e) => setYears(Number(e.target.value))}
                className="w-full accent-shell-gold cursor-pointer"
              />
              <div className="flex justify-between font-body text-[0.65rem] text-stone-muted mt-1">
                <span>5</span>
                <span>30</span>
              </div>
            </div>

            {/* Rate */}
            <div className="mb-6">
              <label className="block font-body font-medium text-[0.875rem] text-white mb-2">
                Interest / Growth Rate
              </label>
              <div className="flex items-center gap-3 mb-2">
                <span className="font-mono text-[1.25rem] text-shell-gold">{rate}%</span>
              </div>
              <input
                type="range"
                min={2}
                max={10}
                step={0.25}
                value={rate}
                onChange={(e) => setRate(Number(e.target.value))}
                className="w-full accent-shell-gold cursor-pointer"
              />
              <div className="flex justify-between font-body text-[0.65rem] text-stone-muted mt-1">
                <span>2%</span>
                <span>10%</span>
              </div>
            </div>
          </motion.div>

          {/* Chart */}
          <motion.div
            className="lg:w-[55%] flex flex-col"
            initial="hidden"
            whileInView="visible"
            viewport={{ once: true, margin: '-25% 0px' }}
            variants={slideInRightVariants}
            transition={{ ...defaultTransition, delay: 0.2 }}
          >
            <div className="rounded-2xl p-6 flex-1" style={{ background: 'rgba(255,255,255,0.03)', border: '1px solid rgba(255,255,255,0.08)' }}>
              {/* Legend */}
              <div className="flex flex-wrap gap-4 mb-4">
                <div className="flex items-center gap-2">
                  <div className="w-3 h-3 rounded-full" style={{ background: '#D4A574' }} />
                  <span className="font-body text-[0.75rem]" style={{ color: 'rgba(255,255,255,0.6)' }}>
                    Your rate ({rate}%)
                  </span>
                </div>
                <div className="flex items-center gap-2">
                  <div className="w-3 h-3 rounded-full" style={{ background: '#A3B18A' }} />
                  <span className="font-body text-[0.75rem]" style={{ color: 'rgba(255,255,255,0.6)' }}>
                    Conservative (4%)
                  </span>
                </div>
                <div className="flex items-center gap-2">
                  <div className="w-3 h-3 rounded-full" style={{ background: '#2A9D8F' }} />
                  <span className="font-body text-[0.75rem]" style={{ color: 'rgba(255,255,255,0.6)' }}>
                    Aggressive (8%)
                  </span>
                </div>
              </div>

              <svg viewBox={`0 0 ${chartW} ${chartH}`} className="w-full" style={{ maxHeight: '300px' }}>
                {/* Grid lines */}
                {[0, 0.25, 0.5, 0.75, 1].map((p) => (
                  <g key={p}>
                    <line
                      x1={pad.left}
                      y1={pad.top + innerH * (1 - p)}
                      x2={pad.left + innerW}
                      y2={pad.top + innerH * (1 - p)}
                      stroke="rgba(255,255,255,0.1)"
                      strokeWidth={1}
                    />
                    <text
                      x={pad.left - 10}
                      y={pad.top + innerH * (1 - p) + 4}
                      textAnchor="end"
                      fill="rgba(255,255,255,0.5)"
                      fontSize={10}
                      fontFamily="Inter, system-ui, sans-serif"
                    >
                      {formatCurrency(maxVal * p)}
                    </text>
                  </g>
                ))}

                {/* X axis labels */}
                {Array.from({ length: Math.min(years + 1, 7) }, (_, i) =>
                  Math.round((years / 6) * i)
                ).map((y) => (
                  <text
                    key={y}
                    x={xScale(y)}
                    y={chartH - 10}
                    textAnchor="middle"
                    fill="rgba(255,255,255,0.5)"
                    fontSize={10}
                    fontFamily="Inter, system-ui, sans-serif"
                  >
                    Yr {y}
                  </text>
                ))}

                {/* Conservative area */}
                <path d={consPath} fill="rgba(163,177,138,0.15)" />
                {/* Main area */}
                <path d={areaPath} fill="url(#areaGrad)" />

                {/* Aggressive line */}
                <path d={aggLine} fill="none" stroke="#2A9D8F" strokeWidth={2} strokeDasharray="4 4" />
                {/* Main line */}
                <path d={mainLine} fill="none" stroke="#D4A574" strokeWidth={2} />

                <defs>
                  <linearGradient id="areaGrad" x1="0" y1="0" x2="0" y2="1">
                    <stop offset="0%" stopColor="#2D6A4F" stopOpacity={0.6} />
                    <stop offset="100%" stopColor="#2D6A4F" stopOpacity={0} />
                  </linearGradient>
                </defs>
              </svg>

              {/* Final value */}
              <div className="text-center mt-4 p-4 rounded-xl" style={{ background: 'rgba(212,165,116,0.1)' }}>
                <p className="font-body text-[0.75rem] uppercase tracking-wider mb-1" style={{ color: 'rgba(255,255,255,0.5)' }}>
                  Projected Value at Year {years}
                </p>
                <p className="font-mono font-bold text-[2rem]" style={{ color: '#D4A574' }}>
                  {formatFullCurrency(finalValue)}
                </p>
                <p className="font-body text-[0.8rem] mt-1" style={{ color: '#52B788' }}>
                  +{formatFullCurrency(diff)} more than a savings account
                </p>
              </div>
            </div>
          </motion.div>
        </div>
      </div>
    </section>
  );
}

/* ───────── Section 6: Testimonials ───────── */

function TestimonialsSection() {
  const testimonials = [
    {
      name: 'Patricia M.',
      age: 68,
      location: 'Naples, FL',
      type: 'Fixed Indexed',
      quote: 'After losing 30% in 2008, I swore never again. My FIA gave me 6.2% growth in 2024 with zero stress.',
      result: 'Gained $31,000 in 2024 with zero downside risk',
    },
    {
      name: 'George & Helen R.',
      age: 72,
      location: 'Sarasota, FL',
      type: 'Immediate Income',
      quote: 'We turned $400K into $2,400/month guaranteed. We\'ll never outlive our income.',
      result: '$2,400/mo guaranteed for both lives',
    },
    {
      name: 'David K.',
      age: 59,
      location: 'Jacksonville, FL',
      type: 'MYGA Fixed',
      quote: 'I parked $200K in a 5-year MYGA at 5.85%. I\'ll know exactly what I have when I retire at 64.',
      result: '$267,000 guaranteed at maturity',
    },
  ];

  return (
    <section className="bg-warm-cream" style={{ padding: '6rem 0' }}>
      <div className="max-w-[1280px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
        <motion.div
          initial="hidden"
          whileInView="visible"
          viewport={{ once: true, margin: '-20% 0px' }}
          variants={staggerContainer}
          className="text-center mb-12"
        >
          <motion.span
            variants={fadeUpVariants}
            transition={defaultTransition}
            className="inline-block font-body font-medium text-[0.75rem] uppercase tracking-[0.05em] mb-4 text-turtle-green"
          >
            REAL RESULTS
          </motion.span>
          <motion.h2
            variants={fadeUpVariants}
            transition={{ ...defaultTransition, delay: 0.1 }}
            className="font-display font-semibold text-ink"
            style={{ fontSize: 'clamp(1.5rem, 3vw, 2.5rem)', lineHeight: 1.2, letterSpacing: '-0.01em' }}
          >
            How annuities changed these retirees' lives
          </motion.h2>
        </motion.div>

        <div className="grid grid-cols-1 md:grid-cols-3" style={{ gap: '1.5rem' }}>
          {testimonials.map((t, i) => (
            <motion.div
              key={i}
              initial="hidden"
              whileInView="visible"
              viewport={{ once: true, margin: '-20% 0px' }}
              variants={fadeUpVariants}
              transition={{ ...defaultTransition, delay: i * 0.1 }}
              className="bg-white rounded-2xl p-8 relative overflow-hidden transition-all duration-300 hover:-translate-y-1 hover:shadow-card-hover"
              style={{
                border: '1px solid #F0EDE8',
                boxShadow: '0 1px 3px rgba(0,0,0,0.04), 0 4px 12px rgba(0,0,0,0.02)',
              }}
            >
              <div
                className="absolute top-0 left-0 right-0 h-1"
                style={{ background: 'linear-gradient(45deg, #D4A574 0%, #E9C46A 50%, #D4A574 100%)' }}
              />
              <div className="flex items-center gap-3 mb-4">
                <div className="w-10 h-10 rounded-full bg-turtle-green flex items-center justify-center">
                  <span className="font-body font-semibold text-white text-[0.875rem]">
                    {t.name.charAt(0)}
                  </span>
                </div>
                <div>
                  <p className="font-body font-semibold text-[0.9rem] text-ink">{t.name}</p>
                  <p className="font-body text-[0.75rem] text-stone-muted">
                    Age {t.age} · {t.location}
                  </p>
                </div>
              </div>
              <span className="inline-block px-2 py-0.5 rounded text-[0.7rem] font-body font-medium bg-dawn-blush text-turtle-green mb-4">
                {t.type}
              </span>
              <p className="font-display italic text-[1rem] leading-[1.6] text-slate-text mb-4">
                &ldquo;{t.quote}&rdquo;
              </p>
              <div className="pt-4" style={{ borderTop: '1px solid #F0EDE8' }}>
                <p className="font-mono font-bold text-[0.9rem] text-turtle-green">{t.result}</p>
              </div>
            </motion.div>
          ))}
        </div>
      </div>
    </section>
  );
}

/* ───────── Section 7: FAQ ───────── */

function FAQSection() {
  const [openIndex, setOpenIndex] = useState<number | null>(null);

  const faqs = [
    {
      q: 'Are annuities safe?',
      a: 'Fixed and indexed annuities are backed by insurance companies regulated at the state level. Each state has a guaranty association that provides protection (typically $250,000-$500,000) if an insurer fails. We only work with A-rated carriers.',
    },
    {
      q: 'What are the tax advantages?',
      a: 'Annuities grow tax-deferred — you don\'t pay taxes on gains until you withdraw. This compound growth advantage can significantly increase your returns over time compared to taxable accounts.',
    },
    {
      q: 'Can I access my money early?',
      a: 'Most annuities allow penalty-free withdrawals of up to 10% annually after the first year. Withdrawals beyond that during the surrender period (typically 5-10 years) may incur charges that decrease over time.',
    },
    {
      q: "What's the difference between an annuity and a 401(k)?",
      a: 'A 401(k) is a retirement account with contribution limits. An annuity is an insurance contract with no contribution limits. Many people max out their 401(k) and IRA, then use annuities for additional tax-deferred growth.',
    },
    {
      q: 'How do I know which type is right for me?',
      a: 'It depends on your age, risk tolerance, income needs, and timeline. Our advisors assess your complete financial picture and recommend a strategy — often combining multiple types for optimal protection.',
    },
    {
      q: 'What fees do annuities have?',
      a: 'Fixed annuities typically have no explicit fees — the insurer makes money on the spread. Variable annuities have management fees (0.5-2% annually). Indexed annuities may have caps or participation rates instead of direct fees. We always explain all costs upfront.',
    },
  ];

  return (
    <section className="bg-white" style={{ padding: '6rem 0' }}>
      <div className="max-w-[800px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
        <motion.div
          initial="hidden"
          whileInView="visible"
          viewport={{ once: true, margin: '-20% 0px' }}
          variants={staggerContainer}
          className="text-center mb-12"
        >
          <motion.span
            variants={fadeUpVariants}
            transition={defaultTransition}
            className="inline-block font-body font-medium text-[0.75rem] uppercase tracking-[0.05em] mb-4 text-turtle-green"
          >
            FREQUENTLY ASKED QUESTIONS
          </motion.span>
          <motion.h2
            variants={fadeUpVariants}
            transition={{ ...defaultTransition, delay: 0.1 }}
            className="font-display font-semibold text-ink"
            style={{ fontSize: 'clamp(1.5rem, 3vw, 2.5rem)', lineHeight: 1.2, letterSpacing: '-0.01em' }}
          >
            Questions about annuities?
          </motion.h2>
        </motion.div>

        <div className="flex flex-col" style={{ gap: '0.75rem' }}>
          {faqs.map((faq, i) => {
            const isOpen = openIndex === i;
            return (
              <motion.div
                key={i}
                initial="hidden"
                whileInView="visible"
                viewport={{ once: true, margin: '-20% 0px' }}
                variants={fadeUpVariants}
                transition={{ ...defaultTransition, delay: i * 0.08 }}
                className="rounded-xl overflow-hidden"
                style={{
                  border: '1px solid #F0EDE8',
                  background: isOpen ? '#FAF6F1' : '#FFFFFF',
                }}
              >
                <button
                  className="w-full flex items-center justify-between p-5 text-left transition-colors duration-200"
                  onClick={() => setOpenIndex(isOpen ? null : i)}
                >
                  <span className="font-body font-semibold text-[1rem] text-ink pr-4">{faq.q}</span>
                  <motion.div animate={{ rotate: isOpen ? 180 : 0 }} transition={{ duration: 0.2 }}>
                    <ChevronDown size={20} className="text-stone-muted flex-shrink-0" />
                  </motion.div>
                </button>
                <motion.div
                  initial={false}
                  animate={{ height: isOpen ? 'auto' : 0, opacity: isOpen ? 1 : 0 }}
                  transition={{ duration: 0.3, ease: [0.25, 0.46, 0.45, 0.94] as [number, number, number, number] }}
                  className="overflow-hidden"
                >
                  <p className="font-body text-[0.95rem] leading-[1.7] text-slate-text px-5 pb-5">{faq.a}</p>
                </motion.div>
              </motion.div>
            );
          })}
        </div>
      </div>
    </section>
  );
}

/* ───────── Section 8: CTA ───────── */

function CTASection() {
  return (
    <section
      style={{
        background: 'linear-gradient(135deg, #1B4332 0%, #2D6A4F 50%, #2A9D8F 100%)',
        padding: '6rem 0',
      }}
    >
      <div className="max-w-[800px] mx-auto text-center" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
        <motion.div
          initial="hidden"
          whileInView="visible"
          viewport={{ once: true, margin: '-30% 0px' }}
          variants={staggerContainer}
        >
          <motion.h2
            variants={fadeUpVariants}
            transition={defaultTransition}
            className="font-display font-bold text-white mb-4"
            style={{ fontSize: 'clamp(2rem, 5vw, 4rem)', lineHeight: 1.1, letterSpacing: '-0.02em' }}
          >
            Ready to protect your assets?
          </motion.h2>
          <motion.p
            variants={fadeUpVariants}
            transition={{ ...defaultTransition, delay: 0.1 }}
            className="font-body text-[1.125rem] leading-[1.7] mb-8"
            style={{ color: 'rgba(255,255,255,0.8)' }}
          >
            Speak with a Turtle Protect annuity specialist. We&apos;ll analyze your situation and design a custom protection strategy.
          </motion.p>
          <motion.div
            variants={fadeUpVariants}
            transition={{ ...defaultTransition, delay: 0.2 }}
            className="flex flex-col sm:flex-row items-center justify-center gap-4 mb-6"
          >
            <Link
              to="/contact"
              className="inline-flex items-center gap-2 font-body font-semibold text-[0.875rem] bg-white text-[#2D6A4F] px-8 py-3.5 rounded-lg transition-all duration-200 hover:scale-[1.03]"
            >
              Schedule a Free Consultation <ArrowRight size={16} />
            </Link>
            <Link
              to="/seminars"
              className="inline-flex items-center gap-2 font-body font-semibold text-[0.875rem] text-white border border-white px-8 py-3.5 rounded-lg transition-all duration-200 hover:bg-[rgba(255,255,255,0.1)]"
            >
              Attend a Seminar
            </Link>
          </motion.div>
          <motion.div
            variants={fadeUpVariants}
            transition={{ ...defaultTransition, delay: 0.3 }}
            className="flex items-center justify-center gap-2 mb-8"
          >
            <Phone size={16} style={{ color: 'rgba(255,255,255,0.5)' }} />
            <span className="font-body text-[0.875rem]" style={{ color: 'rgba(255,255,255,0.6)' }}>
              Or call <span className="font-semibold" style={{ color: 'rgba(255,255,255,0.8)' }}>(352) 428-4009</span>
            </span>
          </motion.div>
          <motion.p
            variants={fadeUpVariants}
            transition={{ ...defaultTransition, delay: 0.4 }}
            className="font-body text-[0.75rem]"
            style={{ color: 'rgba(255,255,255,0.4)' }}
          >
            *Annuities are insurance products. Consult with a licensed professional. Guarantees are backed by the claims-paying ability of the issuing insurance company.
          </motion.p>
        </motion.div>
      </div>
    </section>
  );
}

/* ───────── Page Component ───────── */

export default function Assets() {
  return (
    <main>
      <HeroSection />
      <WhyAnnuitiesSection />
      <AnnuityTypesSection />
      <ShellConceptSection />
      <GrowthCalculatorSection />
      <TestimonialsSection />
      <FAQSection />
      <CTASection />
    </main>
  );
}
"""

let render() = file
