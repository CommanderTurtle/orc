module ConvertedFiles.Src.Pages.LoginTsx

let file = """import { useState, useRef } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { motion, AnimatePresence } from 'framer-motion';
import { Lock, CheckCircle, AlertCircle, PieChart, TrendingUp, Settings, Phone, Mail } from 'lucide-react';
import { useAuth } from '@/context/AuthContext';

/* ------------------------------------------------------------------ */
/*  Animation variants                                                 */
/* ------------------------------------------------------------------ */

const staggerContainer = {
  hidden: {},
  visible: { transition: { staggerChildren: 0.1 } },
};

const staggerItem = {
  hidden: { opacity: 0, y: 30 },
  visible: { opacity: 1, y: 0, transition: { duration: 0.5, ease: [0, 0, 0.2, 1] as [number, number, number, number] } },
};

/* ------------------------------------------------------------------ */
/*  Demo users (decoded from base64 for display hints)                */
/* ------------------------------------------------------------------ */
const DEMO_USERS = [
  { id: 'USER001', name: 'John Martinez' },
  { id: 'USER002', name: 'Sarah Johnson' },
  { id: 'USER003', name: 'Michael Chen' },
  { id: 'USER004', name: 'Emilia Rodriguez' },
  { id: 'USER005', name: 'David Thompson' },
  { id: 'ADMIN001', name: 'Admin User' },
];

const PREVIEW_CARDS = [
  {
    icon: PieChart,
    title: 'Policy Overview',
    description:
      'See your cash value, death benefit, and premium details at a glance with beautiful animated charts.',
  },
  {
    icon: TrendingUp,
    title: 'Growth Tracking',
    description:
      'Track how your policy values grow over time with visual projections and milestone markers.',
  },
  {
    icon: Settings,
    title: 'Personal Settings',
    description:
      'View your profile, update preferences, and manage your protection plans in one place.',
  },
];

/* ------------------------------------------------------------------ */
/*  Login page                                                         */
/* ------------------------------------------------------------------ */
export default function Login() {
  const { isAuthenticated, userName, login, logout } = useAuth();
  const navigate = useNavigate();

  const [userId, setUserId] = useState('');
  const [error, setError] = useState(false);
  const [success, setSuccess] = useState(false);
  const [shake, setShake] = useState(false);
  const inputRef = useRef<HTMLInputElement>(null);

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    setError(false);
    setShake(false);

    const trimmed = userId.trim();
    if (!trimmed) {
      setError(true);
      setShake(true);
      setTimeout(() => setShake(false), 400);
      return;
    }

    const result = login(trimmed);
    if (result) {
      setSuccess(true);
      setTimeout(() => {
        navigate('/dashboard');
      }, 1500);
    } else {
      setError(true);
      setShake(true);
      setTimeout(() => setShake(false), 400);
    }
  };

  /* ---- Already authenticated ---- */
  if (isAuthenticated) {
    return (
      <div className="min-h-[100dvh] flex flex-col">
        {/* Section 1 — Auth state card */}
        <section className="gradient-hero-green min-h-[100dvh] flex items-center justify-center relative overflow-hidden">
          {/* Decorative background shapes */}
          <div className="absolute inset-0 overflow-hidden pointer-events-none">
            {Array.from({ length: 12 }).map((_, i) => (
              <motion.div
                key={i}
                className="absolute rounded-full border border-white/[0.03]"
                style={{
                  width: 40 + Math.random() * 80,
                  height: 40 + Math.random() * 80,
                  left: `${(i * 8.5) % 100}%`,
                  top: `${(i * 13.7 + 10) % 100}%`,
                }}
                animate={{
                  x: [0, 20, -20, 0],
                  y: [0, -10, 10, 0],
                }}
                transition={{
                  duration: 20,
                  repeat: Infinity,
                  ease: [0, 0, 1, 1] as [number, number, number, number],
                  delay: i * 1.5,
                }}
              />
            ))}
          </div>

          <motion.div
            className="relative z-10 bg-[rgba(255,255,255,0.95)] backdrop-blur-[20px] rounded-[24px] shadow-[0_20px_60px_rgba(0,0,0,0.2)] max-w-[480px] w-full mx-4"
            style={{ padding: '3rem' }}
            initial={{ opacity: 0, scale: 0.9 }}
            animate={{ opacity: 1, scale: 1 }}
            transition={{ duration: 0.6, ease: [0, 0, 0.2, 1] as [number, number, number, number] }}
          >
            <div className="text-center">
              <div
                className="mx-auto rounded-full bg-[#52B788] flex items-center justify-center mb-4"
                style={{ width: '64px', height: '64px' }}
              >
                <CheckCircle size={32} className="text-white" />
              </div>
              <h1 className="font-display font-bold text-[2.5rem] text-ink">You are logged in</h1>
              <p className="mt-2 text-lg text-slate-text">
                Welcome back, <span className="font-semibold text-ink">{userName}</span>!
              </p>
              <div className="mt-6 flex flex-col gap-3">
                <Link
                  to="/dashboard"
                  className="inline-flex items-center justify-center gap-2 bg-[#2D6A4F] text-white font-body font-semibold text-sm py-3 rounded-lg hover:bg-[#1B4332] hover:scale-[1.03] transition-all duration-200"
                >
                  Go to Dashboard
                </Link>
                <button
                  onClick={logout}
                  className="inline-flex items-center justify-center gap-2 bg-[#E76F51] text-white font-body font-semibold text-sm py-3 rounded-lg hover:bg-[#D65A3C] hover:scale-[1.03] transition-all duration-200"
                >
                  Logout
                </button>
              </div>
            </div>
          </motion.div>
        </section>
      </div>
    );
  }

  /* ---- Login form ---- */
  return (
    <div className="min-h-[100dvh] flex flex-col">
      {/* ============================================================ */}
      {/* SECTION 1 — LOGIN CARD                                      */}
      {/* ============================================================ */}
      <section className="gradient-hero-green min-h-[100dvh] flex items-center justify-center relative overflow-hidden">
        {/* Decorative background shapes */}
        <div className="absolute inset-0 overflow-hidden pointer-events-none">
          {Array.from({ length: 12 }).map((_, i) => (
            <motion.div
              key={i}
              className="absolute rounded-full border border-white/[0.03]"
              style={{
                width: 40 + Math.random() * 80,
                height: 40 + Math.random() * 80,
                left: `${(i * 8.5) % 100}%`,
                top: `${(i * 13.7 + 10) % 100}%`,
              }}
              animate={{
                x: [0, 20, -20, 0],
                y: [0, -10, 10, 0],
              }}
              transition={{
                duration: 20,
                repeat: Infinity,
                ease: [0, 0, 1, 1] as [number, number, number, number],
                delay: i * 1.5,
              }}
            />
          ))}
        </div>

        <motion.div
          className="relative z-10 bg-[rgba(255,255,255,0.95)] backdrop-blur-[20px] rounded-[24px] shadow-[0_20px_60px_rgba(0,0,0,0.2)] max-w-[480px] w-full mx-4"
          style={{ padding: 'clamp(2rem, 5vw, 3rem)' }}
          initial={{ opacity: 0, scale: 0.9 }}
          animate={{ opacity: 1, scale: 1 }}
          transition={{ duration: 0.6, ease: [0, 0, 0.2, 1] as [number, number, number, number], delay: 0.2 }}
        >
          {/* Logo */}
          <div className="flex items-center justify-center gap-3">
            <svg width="48" height="48" viewBox="0 0 28 28" fill="none" xmlns="http://www.w3.org/2000/svg">
              <ellipse cx="14" cy="18" rx="10" ry="7" fill="#2D6A4F" />
              <circle cx="14" cy="11" r="6" fill="#2D6A4F" />
              <circle cx="11.5" cy="10" r="1" fill="#FAF6F1" />
              <circle cx="16.5" cy="10" r="1" fill="#FAF6F1" />
              <path d="M12 12.5C12.5 13 15.5 13 16 12.5" stroke="#FAF6F1" strokeWidth="0.8" strokeLinecap="round" />
              <ellipse cx="6" cy="20" rx="2.5" ry="3" fill="#2D6A4F" />
              <ellipse cx="22" cy="20" rx="2.5" ry="3" fill="#2D6A4F" />
              <ellipse cx="6" cy="14" rx="2" ry="2.5" fill="#2D6A4F" />
              <ellipse cx="22" cy="14" rx="2" ry="2.5" fill="#2D6A4F" />
              <path d="M14 4C12 4 11 6 11 7" stroke="#2D6A4F" strokeWidth="1.5" strokeLinecap="round" />
              <path d="M4 22C2 23 2 24 3 25" stroke="#2D6A4F" strokeWidth="1.2" strokeLinecap="round" />
            </svg>
            <span className="font-display font-bold text-[#2D6A4F] text-2xl">Turtle Protect</span>
          </div>

          <h1 className="mt-6 text-center font-body font-bold text-[2.5rem] text-ink leading-tight">
            Welcome back
          </h1>
          <p className="mt-2 text-center text-base text-slate-text">
            Enter your User ID to access your dashboard.
          </p>

          <AnimatePresence mode="wait">
            {success ? (
              <motion.div
                key="success"
                className="mt-8 text-center"
                initial={{ opacity: 0, scale: 0.9 }}
                animate={{ opacity: 1, scale: 1 }}
                exit={{ opacity: 0 }}
                transition={{ duration: 0.4 }}
              >
                <div
                  className="mx-auto rounded-full bg-[#52B788] flex items-center justify-center mb-4"
                  style={{ width: '80px', height: '80px' }}
                >
                  <CheckCircle size={40} className="text-white" />
                </div>
                <h2 className="font-body font-semibold text-2xl text-ink">
                  Welcome, {DEMO_USERS.find((u) => u.id === userId.trim().toUpperCase())?.name || 'User'}!
                </h2>
                <p className="mt-2 text-base text-slate-text">
                  Redirecting to your dashboard...
                </p>
              </motion.div>
            ) : (
              <motion.form
                key="form"
                onSubmit={handleSubmit}
                className="mt-6 space-y-4"
                initial={{ opacity: 0 }}
                animate={{ opacity: 1 }}
                exit={{ opacity: 0 }}
              >
                <div>
                  <label className="block font-body font-medium text-sm text-ink mb-2">
                    User ID
                  </label>
                  <motion.input
                    ref={inputRef}
                    type="text"
                    placeholder="Enter your User ID"
                    value={userId}
                    onChange={(e) => {
                      setUserId(e.target.value);
                      if (error) setError(false);
                    }}
                    className={`w-full bg-[#FAF6F1] border rounded-[12px] px-[18px] py-[14px] font-body text-base text-ink placeholder:text-stone-muted transition-all duration-200 outline-none focus:border-[#2D6A4F] focus:ring-[3px] focus:ring-[rgba(45,106,79,0.15)] ${
                      error
                        ? 'border-[#E76F51] ring-[3px] ring-[rgba(231,111,81,0.15)]'
                        : 'border-[#F0EDE8]'
                    }`}
                    animate={
                      shake
                        ? { x: [0, -10, 10, -10, 10, 0] }
                        : { x: 0 }
                    }
                    transition={{ duration: 0.4 }}
                  />
                  <p className="mt-2 text-sm text-stone-muted">
                    Your User ID was provided when you enrolled. It looks like: USER001
                  </p>

                  <AnimatePresence>
                    {error && (
                      <motion.div
                        className="mt-2 flex items-start gap-2 text-sm text-[#E76F51]"
                        initial={{ opacity: 0, y: -5 }}
                        animate={{ opacity: 1, y: 0 }}
                        exit={{ opacity: 0 }}
                      >
                        <AlertCircle size={16} className="flex-shrink-0 mt-0.5" />
                        <span>
                          We don&apos;t recognize that User ID. Please check and try again, or contact
                          support at (352) 428-4009.
                        </span>
                      </motion.div>
                    )}
                  </AnimatePresence>
                </div>

                <button
                  type="submit"
                  className="w-full flex items-center justify-center gap-2 bg-[#2D6A4F] text-white font-body font-semibold text-sm py-3 rounded-lg hover:bg-[#1B4332] transition-all duration-200"
                >
                  <Lock size={16} />
                  Access My Dashboard
                </button>

                {/* Divider */}
                <div className="relative flex items-center gap-4 my-4">
                  <div className="flex-1 h-px bg-[#F0EDE8]" />
                  <span className="text-sm text-stone-muted font-body">or</span>
                  <div className="flex-1 h-px bg-[#F0EDE8]" />
                </div>

                <p className="text-center text-sm text-slate-text">
                  Don&apos;t have a User ID?{' '}
                  <Link to="/contact" className="text-[#2D6A4F] hover:underline font-medium">
                    Contact us
                  </Link>{' '}
                  to get started.
                </p>

                <Link
                  to="/"
                  className="block text-center text-sm text-stone-muted hover:text-slate-text transition-colors mt-2"
                >
                  &larr; Back to Turtle Protect
                </Link>
              </motion.form>
            )}
          </AnimatePresence>

          {/* Demo credentials hint */}
          {!success && (
            <div className="mt-6 rounded-xl bg-[rgba(45,106,79,0.05)] border border-[rgba(45,106,79,0.1)] p-4">
              <p className="text-xs font-body font-medium uppercase tracking-[0.05em] text-[#2D6A4F] mb-2">
                Demo Credentials
              </p>
              <div className="flex flex-wrap gap-2">
                {DEMO_USERS.map((u) => (
                  <button
                    key={u.id}
                    onClick={() => {
                      setUserId(u.id);
                      setError(false);
                    }}
                    className="text-xs font-mono bg-white border border-[#F0EDE8] rounded-md px-2 py-1 text-slate-text hover:border-[#2D6A4F] hover:text-[#2D6A4F] transition-colors"
                  >
                    {u.id}
                  </button>
                ))}
              </div>
            </div>
          )}
        </motion.div>
      </section>

      {/* ============================================================ */}
      {/* SECTION 2 — DASHBOARD PREVIEW                               */}
      {/* ============================================================ */}
      <section className="bg-[#FAF6F1] py-20 lg:py-28">
        <div className="max-w-[1000px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
          <SectionHeader
            overline="YOUR DASHBOARD"
            heading="What you'll see when you log in"
          />

          <motion.div
            className="mt-10 grid grid-cols-1 sm:grid-cols-3 gap-6"
            initial="hidden"
            whileInView="visible"
            viewport={{ once: true, amount: 0.2 }}
            variants={staggerContainer}
          >
            {PREVIEW_CARDS.map((card) => (
              <motion.div
                key={card.title}
                className="bg-white border border-pearl rounded-xl shadow-card p-6 text-center opacity-80 hover:opacity-100 transition-opacity duration-300"
                variants={staggerItem}
              >
                <div
                  className="mx-auto rounded-full bg-[rgba(212,165,116,0.12)] flex items-center justify-center mb-4"
                  style={{ width: '64px', height: '64px' }}
                >
                  <card.icon size={28} className="text-[#D4A574]" />
                </div>
                <h4 className="font-body font-semibold text-lg text-ink mb-2">{card.title}</h4>
                <p className="text-sm text-slate-text leading-relaxed">{card.description}</p>
              </motion.div>
            ))}
          </motion.div>
        </div>
      </section>

      {/* ============================================================ */}
      {/* SECTION 3 — NEED HELP?                                      */}
      {/* ============================================================ */}
      <section className="bg-white py-20 lg:py-28">
        <div className="max-w-[800px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
          <motion.h2
            className="font-body font-semibold text-[2rem] text-ink text-center mb-10"
            initial={{ opacity: 0, y: 30 }}
            whileInView={{ opacity: 1, y: 0 }}
            viewport={{ once: true, amount: 0.3 }}
            transition={{ duration: 0.6, ease: [0, 0, 0.2, 1] as [number, number, number, number] }}
          >
            Having trouble logging in?
          </motion.h2>

          <motion.div
            className="grid grid-cols-1 sm:grid-cols-3 gap-4"
            initial="hidden"
            whileInView="visible"
            viewport={{ once: true, amount: 0.2 }}
            variants={staggerContainer}
          >
            <motion.div
              className="bg-[#FAF6F1] rounded-xl p-4 text-center"
              variants={staggerItem}
            >
              <Phone size={20} className="mx-auto text-[#2D6A4F] mb-2" />
              <a
                href="tel:+13524284009"
                className="block font-mono font-medium text-sm text-[#2D6A4F] hover:text-[#1B4332] transition-colors"
              >
                (352) 428-4009
              </a>
              <p className="mt-1 text-xs text-stone-muted">Mon-Fri, 8am-6pm</p>
            </motion.div>

            <motion.div
              className="bg-[#FAF6F1] rounded-xl p-4 text-center"
              variants={staggerItem}
            >
              <Mail size={20} className="mx-auto text-[#2D6A4F] mb-2" />
              <a
                href="mailto:clement.keynote-1e@icloud.com"
                className="block font-mono font-medium text-sm text-[#2D6A4F] hover:text-[#1B4332] transition-colors"
              >
                clement.keynote-1e@icloud.com
              </a>
              <p className="mt-1 text-xs text-stone-muted">Response within 24hrs</p>
            </motion.div>

            <motion.div
              className="bg-[#FAF6F1] rounded-xl p-4 text-center"
              variants={staggerItem}
            >
              <Settings size={20} className="mx-auto text-[#2D6A4F] mb-2" />
              <Link
                to="/tech-support"
                className="block font-body font-medium text-sm text-[#2D6A4F] hover:text-[#1B4332] transition-colors"
              >
                Contact support to recover your User ID
              </Link>
            </motion.div>
          </motion.div>
        </div>
      </section>

      {/* ============================================================ */}
      {/* SECTION 4 — CTA                                             */}
      {/* ============================================================ */}
      <section className="gradient-hero-green py-20 lg:py-28">
        <motion.div
          className="max-w-[600px] mx-auto text-center"
          style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}
          initial="hidden"
          whileInView="visible"
          viewport={{ once: true, amount: 0.3 }}
          variants={staggerContainer}
        >
          <motion.h2
            className="font-display font-semibold text-white"
            style={{ fontSize: 'clamp(1.5rem, 3vw, 2.5rem)' }}
            variants={staggerItem}
          >
            Not enrolled yet?
          </motion.h2>
          <motion.p
            className="mt-3 text-lg text-[rgba(255,255,255,0.8)] leading-relaxed"
            variants={staggerItem}
          >
            Get started with Turtle Protect and receive your personalized User ID.
          </motion.p>
          <motion.div className="mt-8" variants={staggerItem}>
            <Link
              to="/contact"
              className="inline-block bg-white text-[#2D6A4F] font-body font-semibold text-base px-8 py-4 rounded-lg hover:bg-[#FAF6F1] hover:scale-[1.03] transition-all duration-200"
            >
              Get Started
            </Link>
          </motion.div>
        </motion.div>
      </section>
    </div>
  );
}

/* ------------------------------------------------------------------ */
/*  Shared Section Header                                              */
/* ------------------------------------------------------------------ */
function SectionHeader({ overline, heading }: { overline: string; heading: string }) {
  return (
    <motion.div
      className="text-center"
      variants={staggerContainer}
      initial="hidden"
      whileInView="visible"
      viewport={{ once: true, amount: 0.3 }}
    >
      <motion.span
        className="inline-block font-body font-medium text-xs uppercase tracking-[0.05em] text-[#2D6A4F] mb-3"
        variants={staggerItem}
      >
        {overline}
      </motion.span>
      <motion.h2
        className="font-display font-semibold text-deep-forest"
        style={{ fontSize: 'clamp(1.5rem, 3vw, 2.5rem)' }}
        variants={staggerItem}
      >
        {heading}
      </motion.h2>
    </motion.div>
  );
}
"""

let render() = file
