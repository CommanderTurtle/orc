module ConvertedFiles.Src.Pages.HomeTsx

let file = """import { useRef, useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import gsap from 'gsap';
import { ScrollTrigger } from 'gsap/ScrollTrigger';
import { motion, AnimatePresence } from 'framer-motion';
import {
  Shield, Home as HomeIcon, TrendingUp, Lock, Wifi, Heart, Landmark,
  Gem, CheckCircle, Users, Clock, ChevronRight, ChevronLeft,
  Phone
} from 'lucide-react';
import HeroScene from '@/components/HeroScene';
import PartnerMarquee from '@/components/PartnerMarquee';
import familyprotection from '@/assets/family-protection.jpg';

gsap.registerPlugin(ScrollTrigger);

/* ═══════════════════════ HERO SECTION ═══════════════════════ */

function HeroSection() {
  return (
    <section id="hero" style={{ position: 'relative' }}>
      <HeroScene />
    </section>
  );
}

/* ═══════════════════════ PROTECTION GRID ═══════════════════════ */

const protectionCards = [
  { icon: Shield, title: 'My Life', subtitle: 'Comprehensive life insurance for your loved ones', path: '/insurance', accent: '#2D6A4F' },
  { icon: HomeIcon, title: 'My Home', subtitle: 'Mortgage protection — 5 ways to keep your home safe', path: '/insurance', accent: '#2A9D8F' },
  { icon: TrendingUp, title: 'My Money', subtitle: 'Annuities and asset protection for long-term security', path: '/assets', accent: '#D4A574' },
  { icon: Lock, title: 'My Privacy', subtitle: 'Identity protection and digital security services', path: '/tech-support', accent: '#457B9D' },
  { icon: Wifi, title: 'My Internet', subtitle: 'Online security and family internet safety plans', path: '/tech-support', accent: '#2A9D8F' },
  { icon: Heart, title: 'My Health', subtitle: 'Health coverage options and wellness programs', path: '/health', accent: '#E07A5F' },
  { icon: Landmark, title: 'My Equity', subtitle: 'Home equity protection and preservation strategies', path: '/insurance', accent: '#D4A574' },
  { icon: Gem, title: 'My Assets', subtitle: 'Full asset protection and wealth preservation', path: '/assets', accent: '#2D6A4F' },
];

function ProtectionGrid() {
  return (
    <section className="section-warm-cream" style={{ padding: '6rem 0' }}>
      <div className="max-w-[1280px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
        <div className="text-center" style={{ marginBottom: '3rem', animation: 'fadeInUp 0.7s ease-out both' }}>
          <p className="font-body font-medium text-[0.75rem] uppercase tracking-[0.05em] text-turtle-green mb-3">
            Your Protection Options
          </p>
          <h2 className="font-display font-bold text-ink" style={{ fontSize: 'clamp(2rem, 5vw, 4rem)', lineHeight: 1.1, letterSpacing: '-0.02em' }}>
            What would you like to protect?
          </h2>
          <div className="mx-auto mt-4 bg-shell-gold" style={{ width: '80px', height: '3px' }} />
          <p className="font-body text-[1.125rem] text-slate-text mx-auto mt-4" style={{ maxWidth: '640px' }}>
            Choose what matters most to you. Each protection plan is tailored to your unique situation.
          </p>
        </div>
        <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-4" style={{ gap: '1.5rem' }}>
          {protectionCards.map((card, idx) => {
            const Icon = card.icon;
            return (
              <Link
                key={card.title}
                to={card.path}
                className="group bg-white border border-pearl rounded-xl p-8 transition-all duration-300 hover:-translate-y-1.5 hover:shadow-card-hover flex flex-col items-center text-center"
                style={{ borderRadius: '16px', animation: `fadeInUp 0.6s ease-out ${0.1 + idx * 0.08}s both` }}
              >
                <div
                  className="flex items-center justify-center transition-transform duration-300 group-hover:scale-110"
                  style={{ width: '48px', height: '48px', color: card.accent }}
                >
                  <Icon size={32} strokeWidth={1.5} />
                </div>
                <h3 className="font-body font-semibold text-[1.25rem] text-ink mt-4">{card.title}</h3>
                <p className="font-body text-[0.875rem] text-slate-text mt-2">{card.subtitle}</p>
                <div className="mt-4 text-stone-muted transition-transform duration-300 group-hover:translate-x-1">
                  <ChevronRight size={20} />
                </div>
              </Link>
            );
          })}
        </div>
      </div>
    </section>
  );
}

/* ═══════════════════════ WHY TURTLE PROTECT ═══════════════════════ */

const stats = [
  { value: 12000, suffix: '+', label: 'Florida families trust us' },
  { value: 50, suffix: '+', label: 'Plans from top-rated carriers' },
  { value: 15, suffix: '+', label: 'Decades of experience' },
];

const features = [
  { icon: CheckCircle, title: 'Independent & Unbiased', description: 'We work with 50+ top-rated carriers to find you the best plan — not the plan that pays us the most.' },
  { icon: Users, title: 'Personalized Guidance', description: 'Every family is unique. Our advisors take the time to understand your situation and tailor recommendations.' },
  { icon: Clock, title: 'Always Here for You', description: 'Life changes fast. We\'re available when you need us — for questions, claims support, or plan adjustments.' },
];

function AnimatedCounter({ target, suffix }: { target: number; suffix: string }) {
  const [count, setCount] = useState(0);
  const ref = useRef<HTMLSpanElement>(null);
  const hasAnimated = useRef(false);

  useEffect(() => {
    const el = ref.current;
    if (!el) return;

    const observer = new IntersectionObserver(
      ([entry]) => {
        if (entry.isIntersecting && !hasAnimated.current) {
          hasAnimated.current = true;
          const duration = 1500;
          const startTime = performance.now();

          const animate = (currentTime: number) => {
            const elapsed = currentTime - startTime;
            const progress = Math.min(1, elapsed / duration);
            const ease = 1 - Math.pow(1 - progress, 3);
            setCount(Math.floor(target * ease));
            if (progress < 1) requestAnimationFrame(animate);
          };
          requestAnimationFrame(animate);
        }
      },
      { threshold: 0.3 }
    );

    observer.observe(el);
    return () => observer.disconnect();
  }, [target]);

  return (
    <span ref={ref} className="font-stat" style={{ color: '#D4A574' }}>
      {count.toLocaleString()}{suffix}
    </span>
  );
}

function WhySection() {
  const sectionRef = useRef<HTMLElement>(null);

  useEffect(() => {
    const el = sectionRef.current;
    if (!el) return;

    const elements = el.querySelectorAll('.animate-in');
    const tl = gsap.timeline({
      scrollTrigger: {
        trigger: el,
        start: 'top 75%',
        toggleActions: 'play none none none',
      },
    });

    tl.from(elements, {
      opacity: 0,
      y: 30,
      stagger: 0.1,
      duration: 0.7,
      ease: 'power2.out',
    });

    return () => { tl.kill(); };
  }, []);

  return (
    <section ref={sectionRef} className="bg-deep-forest" style={{ padding: '6rem 0' }}>
      <div className="max-w-[1280px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
        <div className="grid grid-cols-1 lg:grid-cols-2 items-center" style={{ gap: '3rem' }}>
          <div>
            <p className="animate-in font-body font-medium text-[0.75rem] uppercase tracking-[0.05em] text-shell-gold mb-3">
              Why Turtle Protect
            </p>
            <h2
              className="animate-in font-display font-bold text-white"
              style={{ fontSize: 'clamp(2rem, 5vw, 4rem)', lineHeight: 1.1, letterSpacing: '-0.02em' }}
            >
              We&apos;ve been protecting Florida families since day one.
            </h2>
            <p className="animate-in font-body text-[1.125rem] mt-4" style={{ color: 'rgba(255,255,255,0.8)', lineHeight: 1.7 }}>
              As an independent protection platform, we&apos;re not tied to any single provider. That means we shop across the market to find you the best coverage at the best price — tailored to your exact needs.
            </p>
            <div className="animate-in mt-6">
              <Link
                to="/insurance"
                className="inline-block font-body font-semibold text-[0.875rem] text-turtle-green bg-white px-6 py-3 rounded-lg transition-all duration-200 hover:bg-warm-cream hover:scale-[1.03]"
              >
                Learn About Us
              </Link>
            </div>
          </div>
          <div className="flex flex-col" style={{ gap: '1.75rem' }}>
            {stats.map((stat, i) => (
              <div key={i} className="animate-in flex items-baseline gap-3">
                <span className="font-mono font-bold whitespace-nowrap" style={{ color: '#D4A574', fontSize: 'clamp(1.5rem, 3vw, 2.25rem)', lineHeight: 1.1, minWidth: '100px' }}>
                  <AnimatedCounter target={stat.value} suffix={stat.suffix} />
                </span>
                <span className="font-body text-[0.8125rem]" style={{ color: 'rgba(255,255,255,0.6)', lineHeight: 1.4 }}>
                  {stat.label}
                </span>
              </div>
            ))}
          </div>
        </div>

        {/* Feature cards */}
        <div className="grid grid-cols-1 sm:grid-cols-3" style={{ gap: '1.5rem', marginTop: '3rem' }}>
          {features.map((feat, i) => {
            const Icon = feat.icon;
            return (
              <div
                key={i}
                className="animate-in p-8 rounded-xl"
                style={{
                  background: 'rgba(255,255,255,0.05)',
                  border: '1px solid rgba(255,255,255,0.1)',
                  borderRadius: '16px',
                }}
              >
                <div className="text-shell-gold mb-4">
                  <Icon size={40} strokeWidth={1.5} />
                </div>
                <h4 className="font-body font-semibold text-[1.125rem] text-white">{feat.title}</h4>
                <p className="font-body text-[0.9375rem] mt-2" style={{ color: 'rgba(255,255,255,0.7)', lineHeight: 1.6 }}>
                  {feat.description}
                </p>
              </div>
            );
          })}
        </div>
      </div>
    </section>
  );
}

/* ═══════════════════════ HOW IT WORKS ═══════════════════════ */

const steps = [
  { number: '01', title: 'Tell Us What You Need', description: 'Select what you\'d like to protect from our options, or speak with an advisor for personalized guidance.' },
  { number: '02', title: 'We Shop the Market', description: 'Our team compares plans from 50+ carriers to find the best coverage at the best price for your situation.' },
  { number: '03', title: 'Get Your Custom Plan', description: 'Review your tailored protection plan with a dedicated advisor who explains every detail.' },
  { number: '04', title: 'Rest Easy', description: 'Your protection is in place. We\'re here for ongoing support, claims help, and plan adjustments.' },
];

function HowItWorks() {
  const sectionRef = useRef<HTMLElement>(null);

  useEffect(() => {
    const el = sectionRef.current;
    if (!el) return;

    const stepEls = el.querySelectorAll('.step-item');
    const tl = gsap.timeline({
      scrollTrigger: {
        trigger: el,
        start: 'top 70%',
        toggleActions: 'play none none none',
      },
    });

    tl.from(stepEls, {
      opacity: 0,
      y: 30,
      scale: 0.95,
      stagger: 0.15,
      duration: 0.6,
      ease: 'power2.out',
    });

    return () => { tl.kill(); };
  }, []);

  return (
    <section ref={sectionRef} className="section-warm-cream" style={{ padding: '6rem 0' }}>
      <div className="max-w-[1280px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
        <div className="text-center" style={{ marginBottom: '3rem' }}>
          <p className="font-body font-medium text-[0.75rem] uppercase tracking-[0.05em] text-turtle-green mb-3">
            The Process
          </p>
          <h2
            className="font-display font-bold text-ink"
            style={{ fontSize: 'clamp(2rem, 5vw, 4rem)', lineHeight: 1.1, letterSpacing: '-0.02em' }}
          >
            Getting protected is simple
          </h2>
          <p className="font-body text-[1.125rem] text-slate-text mt-3">
            Four easy steps to peace of mind.
          </p>
        </div>

        <div className="relative grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-4" style={{ gap: '2rem' }}>
          {/* Connecting line (desktop) */}
          <div
            className="hidden lg:block absolute top-7 left-[12.5%] right-[12.5%] h-0.5 border-t-2 border-dashed border-sage-mist"
            style={{ zIndex: 0 }}
          />

          {steps.map((step) => (
            <div key={step.number} className="step-item relative flex flex-col items-center text-center" style={{ zIndex: 1 }}>
              <div
                className="flex items-center justify-center rounded-full font-body font-bold text-[1.25rem] text-white bg-turtle-green"
                style={{ width: '56px', height: '56px' }}
              >
                {step.number}
              </div>
              <h3 className="font-body font-semibold text-[1.25rem] text-ink mt-6">{step.title}</h3>
              <p className="font-body text-[1rem] text-slate-text mt-2" style={{ lineHeight: 1.6 }}>
                {step.description}
              </p>
            </div>
          ))}
        </div>
      </div>
    </section>
  );
}

/* ═══════════════════════ FEATURED PROTECTION ═══════════════════════ */

const bulletPoints = [
  'Term life, whole life, and universal life options',
  'Coverage amounts from $50,000 to $10 million',
  'No-medical-exam policies available up to $3 million',
  'Rates locked for the full term duration',
];

function FeaturedSection() {
  const sectionRef = useRef<HTMLElement>(null);

  useEffect(() => {
    const el = sectionRef.current;
    if (!el) return;

    const imageEl = el.querySelector('.feat-image');
    const textEls = el.querySelectorAll('.feat-text');

    const tl = gsap.timeline({
      scrollTrigger: {
        trigger: el,
        start: 'top 75%',
        toggleActions: 'play none none none',
      },
    });

    if (imageEl) {
      tl.from(imageEl, { opacity: 0, x: -60, duration: 0.7, ease: 'power2.out' });
    }
    tl.from(textEls, {
      opacity: 0,
      y: 30,
      stagger: 0.1,
      duration: 0.6,
      ease: 'power2.out',
    }, '-=0.4');

    return () => { tl.kill(); };
  }, []);

  return (
    <section ref={sectionRef} className="gradient-warm-glow" style={{ padding: '6rem 0' }}>
      <div className="max-w-[1280px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
        <div className="grid grid-cols-1 lg:grid-cols-2 items-center" style={{ gap: '3rem' }}>
          <div className="feat-image overflow-hidden rounded-2xl" style={{ boxShadow: '0 8px 32px rgba(0,0,0,0.1)' }}>
            <img
              src={familyprotection}
              alt="Family Protection"
              className="w-full h-auto object-cover transition-transform duration-500 hover:scale-[1.03]"
            />
          </div>
          <div>
            <span
              className="feat-text inline-block font-body font-medium text-[0.75rem] uppercase tracking-[0.05em] text-turtle-green px-3 py-1 rounded-full mb-4"
              style={{ background: 'rgba(45,106,79,0.1)' }}
            >
              Featured
            </span>
            <h2
              className="feat-text font-display font-semibold text-ink"
              style={{ fontSize: 'clamp(1.5rem, 3vw, 2.5rem)', lineHeight: 1.2, letterSpacing: '-0.01em' }}
            >
              Life Insurance: The Foundation of Every Protection Plan
            </h2>
            <p className="feat-text font-body text-[1.125rem] text-slate-text mt-4" style={{ lineHeight: 1.7 }}>
              In 2026, the average cost of a 20-year term life insurance policy for a healthy 35-year-old starts at around just $22/month. Yet 41% of American adults say they need more life insurance. Don&apos;t leave your family&apos;s financial future to chance.
            </p>
            <ul className="mt-4" style={{ display: 'flex', flexDirection: 'column', gap: '0.75rem' }}>
              {bulletPoints.map((point, i) => (
                <li key={i} className="feat-text flex items-start gap-3">
                  <CheckCircle size={20} className="text-turtle-green mt-0.5 shrink-0" />
                  <span className="font-body text-slate-text">{point}</span>
                </li>
              ))}
            </ul>
            <div className="feat-text mt-6">
              <Link
                to="/insurance"
                className="inline-block font-body font-semibold text-[0.875rem] text-white bg-turtle-green px-6 py-3 rounded-lg transition-all duration-200 hover:bg-deep-forest hover:scale-[1.03]"
              >
                Explore Life Insurance
              </Link>
            </div>
          </div>
        </div>
      </div>
    </section>
  );
}

/* ═══════════════════════ TESTIMONIALS ═══════════════════════ */

const testimonials = [
  {
    quote: 'Turtle Protect made getting life insurance so easy. Our advisor walked us through every option and found a plan that fits our budget perfectly. I finally feel like my family is safe.',
    name: 'Maria S.',
    location: 'Miami, FL',
    type: 'Life Insurance',
  },
  {
    quote: 'When we refinanced our home, we didn\'t even think about mortgage protection. Turtle Protect showed us 5 different ways to keep our home safe. Worth every penny.',
    name: 'James & Linda T.',
    location: 'Tampa, FL',
    type: 'Mortgage Protection',
  },
  {
    quote: 'The annuity plan they set up for our retirement gives us peace of mind we never had before. Our advisor checks in regularly to make sure everything is on track.',
    name: 'Robert K.',
    location: 'Orlando, FL',
    type: 'Annuities',
  },
];

function Testimonials() {
  const [current, setCurrent] = useState(0);
  const sectionRef = useRef<HTMLElement>(null);

  useEffect(() => {
    const el = sectionRef.current;
    if (!el) return;

    const tl = gsap.timeline({
      scrollTrigger: {
        trigger: el,
        start: 'top 80%',
        toggleActions: 'play none none none',
      },
    });

    tl.from(el.querySelector('.testimonial-inner'), {
      opacity: 0,
      scale: 0.95,
      duration: 0.6,
      ease: 'power2.out',
    });

    return () => { tl.kill(); };
  }, []);

  const next = () => setCurrent((c) => (c + 1) % testimonials.length);
  const prev = () => setCurrent((c) => (c - 1 + testimonials.length) % testimonials.length);

  const t = testimonials[current];

  return (
    <section ref={sectionRef} className="bg-white" style={{ padding: '6rem 0' }}>
      <div className="max-w-[1000px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
        <div className="text-center" style={{ marginBottom: '3rem' }}>
          <p className="font-body font-medium text-[0.75rem] uppercase tracking-[0.05em] text-turtle-green mb-3">
            Florida Families Trust Us
          </p>
          <h2
            className="font-display font-semibold text-ink"
            style={{ fontSize: 'clamp(1.5rem, 3vw, 2.5rem)', lineHeight: 1.2 }}
          >
            Real stories from real families
          </h2>
        </div>

        <div className="testimonial-inner relative mx-auto" style={{ maxWidth: '800px' }}>
          {/* Decorative quote mark */}
          <div
            className="font-display font-bold text-shell-gold select-none pointer-events-none absolute"
            style={{ fontSize: '6rem', opacity: 0.3, top: '-1rem', left: '-0.5rem', lineHeight: 1 }}
          >
            &ldquo;
          </div>

          <AnimatePresence mode="wait">
            <motion.div
              key={current}
              initial={{ opacity: 0, x: 50 }}
              animate={{ opacity: 1, x: 0 }}
              exit={{ opacity: 0, x: -50 }}
              transition={{ duration: 0.4, ease: [0.25, 0.46, 0.45, 0.94] as [number, number, number, number] }}
              className="relative"
              style={{ zIndex: 1, padding: '0 1rem' }}
            >
              <p
                className="font-display italic text-ink"
                style={{ fontSize: '1.25rem', lineHeight: 1.6 }}
              >
                {t.quote}
              </p>
              <div className="mt-6 flex items-center gap-4">
                <div>
                  <p className="font-body font-semibold text-[1rem] text-ink">{t.name}</p>
                  <p className="font-body text-[0.875rem] text-stone-muted">{t.location}</p>
                </div>
                <div className="ml-auto">
                  <span
                    className="font-body font-medium text-[0.75rem] uppercase tracking-[0.05em] text-turtle-green pl-2"
                    style={{ borderLeft: '3px solid #2D6A4F' }}
                  >
                    {t.type}
                  </span>
                </div>
              </div>
            </motion.div>
          </AnimatePresence>

          {/* Navigation */}
          <div className="flex items-center justify-center" style={{ gap: '1rem', marginTop: '2rem' }}>
            <button
              onClick={prev}
              className="w-10 h-10 rounded-full border border-pearl flex items-center justify-center text-stone-muted hover:text-ink hover:border-stone-muted transition-colors"
            >
              <ChevronLeft size={20} />
            </button>
            <div className="flex items-center" style={{ gap: '0.5rem' }}>
              {testimonials.map((_, i) => (
                <button
                  key={i}
                  onClick={() => setCurrent(i)}
                  className="transition-all duration-300 rounded-full"
                  style={{
                    width: i === current ? '24px' : '8px',
                    height: '8px',
                    backgroundColor: i === current ? '#2D6A4F' : '#F0EDE8',
                  }}
                />
              ))}
            </div>
            <button
              onClick={next}
              className="w-10 h-10 rounded-full border border-pearl flex items-center justify-center text-stone-muted hover:text-ink hover:border-stone-muted transition-colors"
            >
              <ChevronRight size={20} />
            </button>
          </div>
        </div>
      </div>
    </section>
  );
}

/* ═══════════════════════ CTA BANNER ═══════════════════════ */

function CTABanner() {
  const sectionRef = useRef<HTMLElement>(null);

  useEffect(() => {
    const el = sectionRef.current;
    if (!el) return;

    const items = el.querySelectorAll('.cta-animate');
    const tl = gsap.timeline({
      scrollTrigger: {
        trigger: el,
        start: 'top 70%',
        toggleActions: 'play none none none',
      },
    });

    tl.from(items, {
      opacity: 0,
      y: 30,
      stagger: 0.15,
      duration: 0.6,
      ease: 'power2.out',
    });

    return () => { tl.kill(); };
  }, []);

  return (
    <section ref={sectionRef} className="gradient-hero-green" style={{ padding: '6rem 0', position: 'relative', overflow: 'hidden' }}>
      {/* Decorative background pattern */}
      <div className="absolute inset-0 pointer-events-none" style={{ opacity: 0.05 }}>
        <svg width="100%" height="100%" xmlns="http://www.w3.org/2000/svg">
          <defs>
            <pattern id="shellPattern" x="0" y="0" width="60" height="60" patternUnits="userSpaceOnUse">
              <circle cx="30" cy="30" r="15" fill="none" stroke="#fff" strokeWidth="1" />
              <circle cx="30" cy="30" r="8" fill="none" stroke="#fff" strokeWidth="0.5" />
            </pattern>
          </defs>
          <rect width="100%" height="100%" fill="url(#shellPattern)" />
        </svg>
      </div>

      <div className="relative z-10 max-w-[800px] mx-auto text-center" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
        <h2
          className="cta-animate font-display font-bold text-white"
          style={{ fontSize: 'clamp(2rem, 5vw, 4rem)', lineHeight: 1.1, letterSpacing: '-0.02em' }}
        >
          Ready to get protected?
        </h2>
        <p className="cta-animate font-body text-[1.125rem] mt-4" style={{ color: 'rgba(255,255,255,0.85)', lineHeight: 1.7 }}>
          Take the first step toward protecting what matters most. Speak with a Turtle Protect advisor today — no obligation, no pressure.
        </p>
        <div className="cta-animate flex flex-wrap items-center justify-center" style={{ gap: '1rem', marginTop: '2rem' }}>
          <Link
            to="/contact"
            className="font-body font-semibold text-turtle-green bg-white px-8 py-4 rounded-lg transition-all duration-200 hover:bg-warm-cream hover:scale-[1.03]"
            style={{ fontSize: '1rem' }}
          >
            Schedule a Free Consultation
          </Link>
          <a
            href="tel:+13524284009"
            className="font-body font-semibold text-white px-8 py-4 rounded-lg transition-all duration-200 hover:bg-[rgba(255,255,255,0.25)] flex items-center gap-2"
            style={{ border: '1px solid rgba(255,255,255,0.5)', fontSize: '1rem' }}
          >
            <Phone size={18} />
            Call (352) 428-4009
          </a>
        </div>
        <p className="cta-animate font-body text-[0.875rem] mt-6" style={{ color: 'rgba(255,255,255,0.6)' }}>
          Free consultation &middot; No obligation &middot; Florida families only
        </p>
      </div>
    </section>
  );
}

/* ═══════════════════════ TRUST SECTION (MARQUEE) ═══════════════════════ */

function TrustSection() {
  return (
    <section style={{ padding: '5rem 0', background: '#FAF6F1' }}>
      <div className="max-w-[1280px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
        <div className="text-center" style={{ marginBottom: '2.5rem', animation: 'fadeInUp 0.7s ease-out both' }}>
          <p className="font-body font-medium text-[0.75rem] uppercase tracking-[0.05em] text-turtle-green mb-2">TRUSTED BY INDUSTRY LEADERS</p>
          <h2 className="font-display font-semibold text-deep-forest" style={{ fontSize: 'clamp(1.25rem, 3vw, 2rem)' }}>Partnerships & Carrier Commitment</h2>
          <p className="font-body text-[0.9375rem] text-[#8A8A8A] mt-3 max-w-[600px] mx-auto">As a licensed independent agent, Turtle Protect is appointed with these A-rated carriers to find you the best coverage.</p>
        </div>
      </div>
      {/* Marquee — full-bleed */}
      <PartnerMarquee />
      <div className="max-w-[1280px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
        <p className="text-center font-body text-[0.6875rem] text-[#8A8A8A] mt-4">Hover to pause &middot; All carriers A-rated or higher by AM Best</p>
      </div>
    </section>
  );
}

/* ═══════════════════════ HOME PAGE ═══════════════════════ */

export default function Home() {
  return (
    <div>
      <HeroSection />
      <ProtectionGrid />
      <WhySection />
      <HowItWorks />
      <FeaturedSection />
      <Testimonials />
      <TrustSection />
      <CTABanner />
    </div>
  );
}
"""

let render() = file
