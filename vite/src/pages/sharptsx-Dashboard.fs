module Imported.Src.Pages.DashboardTsx

let file = """import { useState, useEffect, useRef } from 'react';
import { Link } from 'react-router-dom';
import { motion } from 'framer-motion';
import {
  TrendingUp, Phone, Users, Download, LogOut, Printer,
  CreditCard, FileText, ShieldCheck, Clock, AlertCircle,
  CheckCircle2, Lightbulb, ChevronRight, Lock, Info,
} from 'lucide-react';
import { generatePolicyPDF } from '@/utils/pdfExport';
import { useAuth } from '@/context/AuthContext';

/* ─────────────────────── animation helpers ─────────────────────── */
const fadeUp = {
  hidden: { opacity: 0, y: 40 },
  visible: (d: number = 0) => ({ opacity: 1, y: 0, transition: { duration: 0.6, delay: d, ease: [0.25, 0.46, 0.45, 0.94] as [number, number, number, number] } }),
};

const staggerContainer = {
  hidden: {},
  visible: { transition: { staggerChildren: 0.08 } },
};

const staggerItem = {
  hidden: { opacity: 0, y: 30 },
  visible: { opacity: 1, y: 0, transition: { duration: 0.5, ease: [0.25, 0.46, 0.45, 0.94] as [number, number, number, number] } },
};

const scaleIn = {
  hidden: { opacity: 0, scale: 0.9 },
  visible: { opacity: 1, scale: 1, transition: { duration: 0.5, ease: [0.25, 0.46, 0.45, 0.94] as [number, number, number, number] } },
};

/* ─────────────────────── animated counter hook ─────────────────────── */
function useAnimatedCounter(target: number, duration: number = 2000, start: boolean = false, formatter?: (v: number) => string) {
  const [display, setDisplay] = useState('0');
  const hasRun = useRef(false);
  const rafRef = useRef<number>(0);

  useEffect(() => {
    if (!start || hasRun.current) return;
    hasRun.current = true;
    const startTime = performance.now();
    const animate = (now: number) => {
      const elapsed = now - startTime;
      const progress = Math.min(elapsed / duration, 1);
      const eased = 1 - Math.pow(1 - progress, 3); // smooth power3.out climb
      const current = Math.floor(eased * target);
      setDisplay(formatter ? formatter(current) : current.toLocaleString());
      if (progress < 1) {
        rafRef.current = requestAnimationFrame(animate);
      } else {
        setDisplay(formatter ? formatter(target) : target.toLocaleString());
      }
    };
    rafRef.current = requestAnimationFrame(animate);
    return () => cancelAnimationFrame(rafRef.current);
  }, [start]);

  return display;
}

/* ─────────────────────── Tooltip Component ─────────────────────── */
function Tooltip({ children, content }: { children: React.ReactNode; content: React.ReactNode }) {
  const [show, setShow] = useState(false);
  return (
    <div className="relative" onMouseEnter={() => setShow(true)} onMouseLeave={() => setShow(false)}>
      {children}
      {show && (
        <div className="absolute z-50 bottom-full left-1/2 -translate-x-1/2 mb-3 w-64 bg-[#1A1A1A] text-white rounded-xl p-4 shadow-xl pointer-events-none" style={{ borderRadius: '12px' }}>
          <div className="absolute left-1/2 -translate-x-1/2 -bottom-1.5 w-3 h-3 bg-[#1A1A1A] rotate-45" />
          {content}
        </div>
      )}
    </div>
  );
}

/* ─────────────────────── SVG Circle Chart Component ─────────────────────── */
interface CircleChartProps {
  size: number;
  strokeWidth: number;
  fillPercent: number;
  gradientId: string;
  gradientColors: [string, string];
  label: string;
  value: string;
  sublabel: string;
  delay?: number;
  start: boolean;
  badge?: string;
  badgeColor?: string;
  tooltipData?: { title: string; rows: { label: string; value: string }[] };
}

function CircleChart({ size, strokeWidth, fillPercent, gradientId, gradientColors, label, value, sublabel, delay = 0, start, badge, badgeColor, tooltipData }: CircleChartProps) {
  const radius = (size - strokeWidth) / 2;
  const circumference = 2 * Math.PI * radius;
  const offset = start ? circumference * (1 - fillPercent) : circumference;

  const chartContent = (
    <div className="flex flex-col items-center">
      <div className="relative" style={{ width: size, height: size }}>
        <svg width={size} height={size} className="-rotate-90">
          <defs>
            <linearGradient id={gradientId} x1="0%" y1="0%" x2="100%" y2="0%">
              <stop offset="0%" stopColor={gradientColors[0]} />
              <stop offset="100%" stopColor={gradientColors[1]} />
            </linearGradient>
          </defs>
          {/* Background track */}
          <circle cx={size / 2} cy={size / 2} r={radius} fill="none" stroke="#F0EDE8" strokeWidth={strokeWidth} />
          {/* Fill ring */}
          <motion.circle
            cx={size / 2} cy={size / 2} r={radius}
            fill="none" stroke={`url(#${gradientId})`} strokeWidth={strokeWidth}
            strokeLinecap="round" strokeDasharray={circumference}
            initial={{ strokeDashoffset: circumference }}
            animate={{ strokeDashoffset: offset }}
            transition={{ duration: 2, delay: delay, ease: [0.45, 0.05, 0.55, 0.95] as [number, number, number, number] }}
          />
        </svg>
        {/* Center text — always visible, no fade-in */}
        <div className="absolute inset-0 flex flex-col items-center justify-center">
          <span className="font-mono font-bold text-[#1A1A1A] transition-opacity duration-500" style={{ fontSize: size >= 280 ? '2rem' : '1.75rem', opacity: start ? 1 : 0.4 }}>
            {value}
          </span>
          <span className="font-body font-medium text-[0.875rem] mt-1 transition-opacity duration-500" style={{ color: '#8A8A8A', opacity: start ? 1 : 0.4 }}>
            {label}
          </span>
        </div>
        {/* Badge */}
        {badge && start && (
          <motion.span className="absolute -top-2 -right-2 px-2.5 py-1 rounded-full text-white font-body font-semibold text-[0.75rem]" style={{ backgroundColor: badgeColor || '#2D6A4F' }} initial={{ scale: 0 }} animate={{ scale: start ? [0, 1.1, 1] : 0 }} transition={{ duration: 0.3, delay: 2.2 }}>
            {badge}
          </motion.span>
        )}
      </div>
      {/* Info icon — outside the circle, below it */}
      {tooltipData && (
        <div className="flex items-center gap-1.5 mt-3 px-3 py-1.5 rounded-full bg-[#F5F3EF] cursor-help group-hover:bg-[#EDEAE4] transition-colors">
          <Info size={12} className="text-[#8A8A8A]" />
          <span className="font-body text-[0.6875rem] text-[#8A8A8A]">Hover for details</span>
        </div>
      )}
      <p className="mt-4 font-body text-[0.875rem] text-[#8A8A8A] transition-opacity duration-500" style={{ opacity: start ? 1 : 0.4 }}>
        {sublabel}
      </p>
    </div>
  );

  if (!tooltipData) return chartContent;

  return (
    <Tooltip content={
      <div>
        <p className="font-body font-semibold text-[0.875rem] mb-2" style={{ color: '#D4A574' }}>{tooltipData.title}</p>
        {tooltipData.rows.map((r, i) => (
          <div key={i} className="flex justify-between gap-4 py-1">
            <span className="font-body text-[0.75rem] text-[rgba(255,255,255,0.6)]">{r.label}</span>
            <span className="font-mono font-semibold text-[0.75rem] text-white">{r.value}</span>
          </div>
        ))}
      </div>
    }>
      {chartContent}
    </Tooltip>
  );
}

/* ─────────────────────── Bar Graph Component ─────────────────────── */
const barData = [
  { year: 'Yr 1', value: 3200, label: '$3,200' },
  { year: 'Yr 2', value: 6800, label: '$6,800' },
  { year: 'Yr 3', value: 11200, label: '$11,200' },
  { year: 'Yr 4', value: 17200, label: '$17,200' },
  { year: 'Yr 5', value: 24100, label: '$24,100' },
  { year: 'Yr 6', value: 32100, label: '$32,100' },
  { year: 'Yr 7', value: 41200, label: '$41,200' },
  { year: 'Yr 8', value: 47250, label: '$47,250' },
];
const maxBarValue = 50000;

function BarGraph({ start }: { start: boolean }) {
  const [hoveredIdx, setHoveredIdx] = useState<number | null>(null);

  return (
    <div className="w-full">
      <div className="flex items-end justify-between" style={{ height: '200px', gap: '8px' }}>
        {barData.map((d, i) => {
          const heightPercent = (d.value / maxBarValue) * 100;
          const isHovered = hoveredIdx === i;
          return (
            <div key={i} className="flex-1 flex flex-col items-center justify-end relative" style={{ height: '100%' }}>
              {/* Hover tooltip */}
              {isHovered && (
                <div className="absolute bottom-full mb-2 z-10 bg-[#1A1A1A] text-white rounded-lg px-3 py-2 text-center" style={{ borderRadius: '8px', minWidth: '80px' }}>
                  <p className="font-mono font-bold text-[0.875rem]">{d.label}</p>
                  <p className="font-body text-[0.6875rem] text-[rgba(255,255,255,0.6)]">{d.year}</p>
                  <div className="absolute left-1/2 -translate-x-1/2 -bottom-1 w-2 h-2 bg-[#1A1A1A] rotate-45" />
                </div>
              )}
              {/* Bar */}
              <motion.div
                className="w-full rounded-t-lg cursor-pointer transition-all duration-200"
                style={{
                  borderRadius: '6px 6px 0 0',
                  background: isHovered
                    ? 'linear-gradient(180deg, #D4A574 0%, #2D6A4F 100%)'
                    : 'linear-gradient(180deg, #2D6A4F 0%, #2A9D8F 100%)',
                  opacity: hoveredIdx !== null && !isHovered ? 0.5 : 1,
                }}
                initial={{ height: 0 }}
                animate={{ height: start ? `${heightPercent}%` : 0 }}
                transition={{ duration: 0.8, delay: 0.1 * i, ease: [0.45, 0.05, 0.55, 0.95] as [number, number, number, number] }}
                onMouseEnter={() => setHoveredIdx(i)}
                onMouseLeave={() => setHoveredIdx(null)}
              />
              {/* Year label */}
              <span className="font-body text-[0.6875rem] text-[#8A8A8A] mt-2">{d.year}</span>
            </div>
          );
        })}
      </div>
      {/* Axis line */}
      <div className="h-px bg-[#E0DCD7] mt-1" />
      <div className="flex justify-between mt-2">
        <span className="font-body text-[0.6875rem] text-[#8A8A8A]">Cash Value Growth Over Time</span>
        <span className="font-body text-[0.6875rem] text-[#8A8A8A]">Projected at age 65: $128,000</span>
      </div>
    </div>
  );
}

/* ─────────────────────── Main Dashboard Page ─────────────────────── */
export default function Dashboard() {
  const { isAuthenticated, userId, userName, logout } = useAuth();
  const [mounted, setMounted] = useState(false);
  const [_sectionVisible, setSectionVisible] = useState(false);
  const sectionRef = useRef<HTMLDivElement>(null);

  useEffect(() => {
    setMounted(true);
  }, []);

  useEffect(() => {
    const observer = new IntersectionObserver(
      ([entry]) => { if (entry.isIntersecting) setSectionVisible(true); },
      { threshold: 0.2 }
    );
    if (sectionRef.current) observer.observe(sectionRef.current);
    return () => observer.disconnect();
  }, []);

  // Trigger animations after mount for authenticated users
  const trigger = mounted && isAuthenticated;

  // Animated counters
  const cashValueStr = useAnimatedCounter(73450, 2000, trigger, (v) => `$${v.toLocaleString()}`);
  const deathBenefitStr = useAnimatedCounter(500000, 2000, trigger, (v) => `$${v.toLocaleString()}`);
  const premiumPaid = useAnimatedCounter(2310, 2000, trigger, (v) => `$${v.toLocaleString()}`);

  const currentDate = new Date().toLocaleDateString('en-US', { month: 'long', day: 'numeric', year: 'numeric' });

  /* ── Unauthenticated fallback ── */
  if (!isAuthenticated) {
    return (
      <div className="min-h-[100dvh] bg-warm-cream">
        <section className="gradient-hero-green" style={{ paddingTop: '8rem', paddingBottom: '4rem' }}>
          <div className="max-w-[1280px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
            <motion.div variants={fadeUp} initial="hidden" animate="visible" className="text-center">
              <Lock size={48} className="mx-auto text-[rgba(255,255,255,0.4)] mb-4" />
              <h1 className="font-display font-bold text-white" style={{ fontSize: 'clamp(1.5rem, 3vw, 2.5rem)' }}>Dashboard Access Required</h1>
              <p className="font-body text-[1.125rem] text-[rgba(255,255,255,0.8)] mt-4">Please log in to view your personalized dashboard.</p>
              <Link to="/login" className="inline-flex items-center gap-2 mt-6 font-body font-semibold text-[0.875rem] text-[#1B4332] bg-white px-6 py-3 rounded-lg transition-all duration-200 hover:bg-[#FAF6F1] hover:scale-[1.03]">
                Log In
              </Link>
            </motion.div>
          </div>
        </section>
      </div>
    );
  }

  return (
    <div className="min-h-[100dvh] bg-warm-cream">
      {/* ════════════ Section 1: Dashboard Header ════════════ */}
      <section className="gradient-hero-green" style={{ paddingTop: '8rem', paddingBottom: '3rem' }}>
        <div className="max-w-[1280px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
          <div className="flex flex-col lg:flex-row lg:items-end lg:justify-between gap-6">
            <motion.div variants={fadeUp} initial="hidden" animate="visible">
              <h1 className="font-display font-semibold text-white" style={{ fontSize: 'clamp(1.5rem, 3vw, 2.5rem)' }}>
                Welcome back, {userName}
              </h1>
              <p className="font-body text-[1.125rem] text-[rgba(255,255,255,0.7)] mt-2">
                Here&apos;s your protection summary as of {currentDate}
              </p>
              <div className="inline-flex items-center gap-2 mt-4 px-4 py-2 rounded-full font-body text-[0.875rem] text-white" style={{ background: 'rgba(255,255,255,0.15)', backdropFilter: 'blur(8px)' }}>
                <ShieldCheck size={16} />
                Policy #TP-2025-A001 &middot; Whole Life &middot; Active
              </div>
            </motion.div>

            <motion.div variants={staggerContainer} initial="hidden" animate="visible" className="flex flex-wrap gap-3">
              {[
                { label: 'Print / PDF', icon: Printer, action: () => generatePolicyPDF({ userName, userId: userId ?? 'DEMO', cashValue: 47250, deathBenefit: 500000, annualPremium: 3420, premiumPaid: 2310, policyYear: 8, totalYears: 30, growthRate: 4.2 }) },
                { label: 'Contact Advisor', icon: Phone, action: undefined },
                { label: 'Logout', icon: LogOut, action: logout },
              ].map((item) => (
                <motion.button
                  key={item.label}
                  variants={staggerItem}
                  onClick={item.action}
                  className={`inline-flex items-center gap-2 font-body font-semibold text-[0.875rem] px-5 py-2.5 rounded-lg transition-all duration-200 ${
                    item.label === 'Logout'
                      ? 'text-[#E76F51] border border-[#E76F51] hover:bg-[rgba(231,111,81,0.08)]'
                      : 'text-white border border-white hover:bg-[rgba(255,255,255,0.1)]'
                  }`}
                >
                  <item.icon size={16} /> {item.label}
                </motion.button>
              ))}
            </motion.div>
          </div>
        </div>
      </section>

      {/* ════════════ Section 2: Circle Charts ════════════ */}
      <section ref={sectionRef} className="bg-[#FAF6F1]" style={{ padding: '4rem 0' }}>
        <div className="max-w-[1200px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
          <motion.div variants={fadeUp} initial="hidden" whileInView="visible" viewport={{ once: true }} className="text-center mb-10">
            <span className="font-body font-medium text-[0.75rem] uppercase tracking-[0.05em] text-[#2D6A4F]">YOUR POLICY AT A GLANCE</span>
            <h2 className="font-display font-semibold text-[#1A1A1A] mt-2" style={{ fontSize: 'clamp(1.5rem, 3vw, 2.5rem)' }}>Protection overview</h2>
          </motion.div>

          <div className="grid grid-cols-1 md:grid-cols-3 gap-8">
            {/* Cash Value Ring */}
            <motion.div variants={scaleIn} initial="hidden" whileInView="visible" viewport={{ once: true }} className="bg-white rounded-[20px] p-8 shadow-[0_2px_12px_rgba(0,0,0,0.04)] flex flex-col items-center">
              <CircleChart
                size={220}
                strokeWidth={14}
                fillPercent={0.47}
                gradientId="cashDashGrad"
                gradientColors={['#2D6A4F', '#D4A574']}
                label="Cash Value"
                value={cashValueStr}
                sublabel="Growing at 4.2% annually"
                delay={0.1}
                start={trigger}
                badge="+47%"
                badgeColor="#2D6A4F"
                tooltipData={{
                  title: 'Cash Value Details',
                  rows: [
                    { label: 'Current Value', value: cashValueStr },
                    { label: 'Growth Rate', value: '4.2% annually' },
                    { label: 'This Month', value: '+$196.25' },
                    { label: 'Projected (Age 65)', value: '$128,000' },
                    { label: 'Tax Status', value: 'Tax-deferred' },
                  ],
                }}
              />
              <div className="mt-6 w-full space-y-2 pt-4 border-t border-[#F0EDE8]">
                <div className="flex items-center gap-2 text-[#52B788] font-body text-[0.875rem]">
                  <TrendingUp size={14} /> Annual Growth: +$3,200
                </div>
                <p className="font-body text-[0.875rem] text-[#8A8A8A]">Projected at age 65: $128,000</p>
                <p className="font-body text-[0.875rem] text-[#8A8A8A]">Growth rate: 4.2% annually</p>
              </div>
            </motion.div>

            {/* Death Benefit Ring */}
            <motion.div variants={scaleIn} initial="hidden" whileInView="visible" viewport={{ once: true }} custom={0.15} className="bg-white rounded-[20px] p-8 shadow-[0_2px_12px_rgba(0,0,0,0.04)] flex flex-col items-center">
              <CircleChart
                size={220}
                strokeWidth={14}
                fillPercent={1.0}
                gradientId="deathDashGrad"
                gradientColors={['#2A9D8F', '#52B788']}
                label="Death Benefit"
                value={deathBenefitStr}
                sublabel="Full coverage active"
                delay={0.2}
                start={trigger}
                badge="100%"
                badgeColor="#2A9D8F"
                tooltipData={{
                  title: 'Death Benefit Details',
                  rows: [
                    { label: 'Total Coverage', value: deathBenefitStr },
                    { label: 'Policy Type', value: 'Whole Life' },
                    { label: 'Beneficiaries', value: '2 designated' },
                    { label: 'Primary', value: 'Mary Santos (60%)' },
                    { label: 'Contingent', value: 'David Santos (40%)' },
                  ],
                }}
              />
              <div className="mt-6 w-full space-y-2 pt-4 border-t border-[#F0EDE8]">
                <p className="font-body text-[0.875rem] text-[#4A4A4A]">Policy Type: Whole Life</p>
                <p className="font-body text-[0.875rem] text-[#8A8A8A]">Beneficiaries: 2 designated</p>
                <p className="font-body text-[0.875rem] text-[#8A8A8A]">Mary Santos (spouse) &middot; David Santos (son)</p>
              </div>
            </motion.div>

            {/* Premium Ring */}
            <motion.div variants={scaleIn} initial="hidden" whileInView="visible" viewport={{ once: true }} custom={0.3} className="bg-white rounded-[20px] p-8 shadow-[0_2px_12px_rgba(0,0,0,0.04)] flex flex-col items-center">
              <CircleChart
                size={220}
                strokeWidth={14}
                fillPercent={8 / 30}
                gradientId="premiumDashGrad"
                gradientColors={['#D4A574', '#E9C46A']}
                label="of 30"
                value={`Year ${trigger ? '8' : '0'}`}
                sublabel="Policy year progress"
                delay={0.3}
                start={trigger}
                badge="26.7%"
                badgeColor="#D4A574"
                tooltipData={{
                  title: 'Premium Details',
                  rows: [
                    { label: 'Monthly Premium', value: '$285.00' },
                    { label: 'Annual Total', value: '$3,420' },
                    { label: 'Paid This Year', value: premiumPaid },
                    { label: 'Next Due', value: 'Mar 1, 2025' },
                    { label: 'Payment Method', value: 'Auto-debit ...4242' },
                  ],
                }}
              />
              <div className="mt-6 w-full space-y-2 pt-4 border-t border-[#F0EDE8]">
                <div className="flex justify-between items-center">
                  <span className="font-body text-[0.875rem] text-[#4A4A4A]">Monthly Premium</span>
                  <span className="font-mono font-semibold text-[1.125rem] text-[#1A1A1A]">$285</span>
                </div>
                <div className="flex justify-between items-center">
                  <span className="font-body text-[0.875rem] text-[#4A4A4A]">Annual Total</span>
                  <span className="font-body text-[0.875rem] text-[#4A4A4A]">$3,420</span>
                </div>
                <div className="flex justify-between items-center">
                  <span className="font-body text-[0.875rem] text-[#8A8A8A]">Next payment: Mar 1, 2025</span>
                </div>
                <div className="flex justify-between items-center">
                  <span className="font-body text-[0.875rem] text-[#8A8A8A]">Payment: Auto-debit &middot;&middot;&middot;4242</span>
                </div>
                {/* Progress bar for annual contribution */}
                <div className="pt-2">
                  <div className="flex justify-between text-[0.75rem] mb-1">
                    <span className="text-[#8A8A8A]">Annual contribution</span>
                    <span className="font-mono text-[#2D6A4F]">{premiumPaid} / $3,720</span>
                  </div>
                  <div className="h-2 bg-[#F0EDE8] rounded-full overflow-hidden">
                    <motion.div
                      className="h-full bg-[#2A9D8F] rounded-full"
                      initial={{ width: 0 }}
                      animate={{ width: trigger ? '62%' : 0 }}
                      transition={{ duration: 1.5, delay: 0.8, ease: [0.45, 0.05, 0.55, 0.95] as [number, number, number, number] }}
                    />
                  </div>
                </div>
              </div>
            </motion.div>
          </div>

          {/* ════════════ Bar Graph: Cash Value Growth ════════════ */}
          <motion.div variants={fadeUp} initial="hidden" whileInView="visible" viewport={{ once: true }} className="bg-white rounded-[20px] p-8 shadow-[0_2px_12px_rgba(0,0,0,0.04)] mt-8">
            <div className="flex flex-col sm:flex-row sm:items-center sm:justify-between mb-6">
              <div>
                <h3 className="font-display font-semibold text-[#1A1A1A] text-[1.25rem]">Cash Value Growth</h3>
                <p className="font-body text-[0.875rem] text-[#8A8A8A] mt-1">8-year history with projected trajectory. Hover bars for details.</p>
              </div>
              <div className="flex items-center gap-4 mt-3 sm:mt-0">
                <span className="flex items-center gap-1.5 font-body text-[0.75rem] text-[#8A8A8A]"><span className="w-3 h-3 rounded-sm" style={{ background: 'linear-gradient(180deg, #2D6A4F, #2A9D8F)' }} /> Actual</span>
                <span className="flex items-center gap-1.5 font-body text-[0.75rem] text-[#8A8A8A]"><span className="w-3 h-3 rounded-sm" style={{ background: 'linear-gradient(180deg, #D4A574, #2D6A4F)' }} /> Hover</span>
              </div>
            </div>
            <BarGraph start={trigger} />
          </motion.div>
        </div>
      </section>

      {/* ════════════ Section 3: Policy Details Table ════════════ */}
      <section className="bg-white" style={{ padding: '4rem 0' }}>
        <div className="max-w-[1000px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
          <motion.div variants={fadeUp} initial="hidden" whileInView="visible" viewport={{ once: true }} className="mb-8">
            <span className="font-body font-medium text-[0.75rem] uppercase tracking-[0.05em] text-[#2D6A4F]">POLICY DETAILS</span>
            <h2 className="font-display font-semibold text-[#1A1A1A] mt-2 text-[2rem]">Your coverage breakdown</h2>
          </motion.div>

          <motion.div variants={fadeUp} initial="hidden" whileInView="visible" viewport={{ once: true }} custom={0.1} className="overflow-x-auto rounded-xl border border-[#F0EDE8]">
            <table className="w-full min-w-[600px]">
              <tbody>
                {[
                  { field: 'Policy Number', value: 'TP-2025-A001', status: 'Active', statusColor: 'bg-[#52B788]' },
                  { field: 'Policy Type', value: 'Whole Life Insurance', status: null },
                  { field: 'Issue Date', value: 'January 15, 2017', status: null },
                  { field: 'Premium Mode', value: 'Monthly Auto-Debit', status: 'Current', statusColor: 'bg-[#52B788]' },
                  { field: 'Base Premium', value: '$285.00/mo', status: null },
                  { field: 'Cash Value', value: '$47,250.00', status: 'Growing', statusColor: 'bg-[#2D6A4F]' },
                  { field: 'Death Benefit', value: '$500,000.00', status: 'Guaranteed', statusColor: 'bg-[#2A9D8F]' },
                  { field: 'Loan Balance', value: '$0.00', status: 'None', statusColor: 'bg-[#8A8A8A]' },
                  { field: 'Surrender Value', value: '$44,531.25', status: null },
                  { field: 'Next Premium Due', value: 'March 1, 2025', status: 'Paid', statusColor: 'bg-[#52B788]' },
                  { field: 'Beneficiary 1', value: 'Mary Santos (spouse) — 60%', status: 'Current', statusColor: 'bg-[#52B788]' },
                  { field: 'Beneficiary 2', value: 'David Santos (son) — 40%', status: 'Current', statusColor: 'bg-[#52B788]' },
                ].map((row, i) => (
                  <tr key={i} className={`${i % 2 === 0 ? 'bg-white' : 'bg-[#FAF6F1]'}`}>
                    <td className="font-body font-medium text-[0.875rem] text-[#4A4A4A] px-5 py-3 w-[40%]">{row.field}</td>
                    <td className="font-mono font-medium text-[1rem] text-[#1A1A1A] px-5 py-3 text-right">{row.value}</td>
                    <td className="px-5 py-3 text-right">
                      {row.status && (
                        <span className={`inline-block px-3 py-1 rounded-full font-body font-semibold text-[0.75rem] text-white ${row.statusColor}`}>
                          {row.status}
                        </span>
                      )}
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          </motion.div>
        </div>
      </section>

      {/* ════════════ Section 4: Quick Stats Row ════════════ */}
      <section className="bg-[#F0EDE8]" style={{ padding: '3rem 0' }}>
        <div className="max-w-[1000px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
          <motion.div variants={staggerContainer} initial="hidden" whileInView="visible" viewport={{ once: true }} className="grid grid-cols-2 lg:grid-cols-4 gap-4">
            {[
              { label: 'Total Coverage', value: '$500,000', icon: ShieldCheck, color: '#2D6A4F' },
              { label: 'Cash Value', value: '$47,250', icon: TrendingUp, color: '#2A9D8F' },
              { label: 'Policies Active', value: '1', icon: CheckCircle2, color: '#52B788' },
              { label: 'Next Payment', value: 'Mar 1', icon: Clock, color: '#D4A574' },
            ].map((stat) => (
              <motion.div key={stat.label} variants={staggerItem} className="bg-white rounded-xl p-5 border border-[#F0EDE8] flex items-center gap-4">
                <div className="w-12 h-12 rounded-xl flex items-center justify-center shrink-0" style={{ backgroundColor: `${stat.color}15` }}>
                  <stat.icon size={22} style={{ color: stat.color }} />
                </div>
                <div>
                  <p className="font-mono font-bold text-[1.25rem] text-[#1A1A1A]">{stat.value}</p>
                  <p className="font-body text-[0.75rem] text-[#8A8A8A]">{stat.label}</p>
                </div>
              </motion.div>
            ))}
          </motion.div>
        </div>
      </section>

      {/* ════════════ Section 5: Recent Activity ════════════ */}
      <section className="bg-[#FAF6F1]" style={{ padding: '4rem 0' }}>
        <div className="max-w-[1000px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
          <motion.div variants={fadeUp} initial="hidden" whileInView="visible" viewport={{ once: true }} className="mb-8">
            <span className="font-body font-medium text-[0.75rem] uppercase tracking-[0.05em] text-[#2D6A4F]">ACTIVITY</span>
            <h2 className="font-display font-semibold text-[#1A1A1A] mt-2 text-[2rem]">Recent events</h2>
          </motion.div>

          <motion.div variants={staggerContainer} initial="hidden" whileInView="visible" viewport={{ once: true }} className="space-y-4">
            {[
              { icon: CheckCircle2, color: '#52B788', title: 'Premium payment received', desc: 'Monthly auto-debit of $285.00 processed successfully.', date: 'Feb 1, 2025' },
              { icon: TrendingUp, color: '#2D6A4F', title: 'Cash value increased', desc: 'Policy cash value grew by $196.25 this month. Current: $47,250.00.', date: 'Feb 1, 2025' },
              { icon: FileText, color: '#2A9D8F', title: 'Annual statement available', desc: 'Your 2024 annual policy statement is ready for download.', date: 'Jan 15, 2025' },
              { icon: ShieldCheck, color: '#D4A574', title: 'Policy anniversary', desc: '8 years with Turtle Protect. Your policy is in excellent standing.', date: 'Jan 15, 2025' },
              { icon: AlertCircle, color: '#E9C46A', title: 'Beneficiary review reminder', desc: 'It\'s been 2 years since your last beneficiary review. Consider updating.', date: 'Jan 10, 2025' },
            ].map((item, i) => (
              <motion.div key={i} variants={staggerItem} className="bg-white rounded-xl p-5 border border-[#F0EDE8] flex items-start gap-4 hover:shadow-card-hover transition-all duration-300">
                <div className="w-10 h-10 rounded-lg flex items-center justify-center shrink-0" style={{ backgroundColor: `${item.color}15` }}>
                  <item.icon size={20} style={{ color: item.color }} />
                </div>
                <div className="flex-1 min-w-0">
                  <div className="flex items-start justify-between gap-4">
                    <h4 className="font-body font-semibold text-[#1A1A1A] text-[0.875rem]">{item.title}</h4>
                    <span className="font-body text-[0.75rem] text-[#8A8A8A] shrink-0">{item.date}</span>
                  </div>
                  <p className="font-body text-[0.875rem] text-[#4A4A4A] mt-1">{item.desc}</p>
                </div>
              </motion.div>
            ))}
          </motion.div>
        </div>
      </section>

      {/* ════════════ Section 6: Quick Actions ════════════ */}
      <section className="bg-white" style={{ padding: '4rem 0' }}>
        <div className="max-w-[1000px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
          <motion.div variants={fadeUp} initial="hidden" whileInView="visible" viewport={{ once: true }} className="mb-8">
            <span className="font-body font-medium text-[0.75rem] uppercase tracking-[0.05em] text-[#2D6A4F]">QUICK ACTIONS</span>
            <h2 className="font-display font-semibold text-[#1A1A1A] mt-2 text-[2rem]">Manage your protection</h2>
          </motion.div>

          <motion.div variants={staggerContainer} initial="hidden" whileInView="visible" viewport={{ once: true }} className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-4 gap-4">
            {[
              { action: 'Contact Advisor', icon: Phone, desc: 'Speak with your dedicated advisor about your policy.' },
              { action: 'Update Beneficiaries', icon: Users, desc: 'Review or change your designated beneficiaries.' },
              { action: 'Download Documents', icon: Download, desc: 'Access your policy documents, statements, and tax forms.' },
              { action: 'Make a Payment', icon: CreditCard, desc: 'Set up or manage premium payments through your carrier.' },
            ].map((card) => (
              <motion.button key={card.action} variants={staggerItem}
                className="bg-white rounded-xl p-6 border border-[#F0EDE8] text-left hover:border-[#2D6A4F] transition-all duration-300 hover:shadow-card-hover group">
                <div className="w-10 h-10 rounded-lg bg-[#2D6A4F] bg-opacity-10 flex items-center justify-center mb-4 group-hover:bg-[#2D6A4F] transition-colors duration-300">
                  <card.icon size={20} className="text-[#2D6A4F] group-hover:text-white transition-colors duration-300" />
                </div>
                <h4 className="font-body font-semibold text-[#1A1A1A] text-[0.875rem]">{card.action}</h4>
                <p className="font-body text-[0.75rem] text-[#8A8A8A] mt-2 leading-relaxed">{card.desc}</p>
              </motion.button>
            ))}
          </motion.div>
        </div>
      </section>

      {/* ════════════ Section 7: Educational Tip ════════════ */}
      <section className="bg-[#2D6A4F]" style={{ padding: '4rem 0' }}>
        <motion.div variants={fadeUp} initial="hidden" whileInView="visible" viewport={{ once: true }} className="max-w-[800px] mx-auto text-center" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
          <Lightbulb size={32} className="mx-auto text-[#D4A574] mb-4" />
          <p className="font-body text-[1.125rem] text-white leading-relaxed">
            Did you know? Your whole life policy&apos;s cash value grows tax-deferred. You can borrow against it at rates typically lower than personal loans, and the loan doesn&apos;t require credit checks or repayment schedules.
          </p>
          <Link to="/assets" className="inline-flex items-center gap-2 mt-6 font-body font-semibold text-[0.875rem] text-[#D4A574] hover:underline">
            Learn about policy loans <ChevronRight size={16} />
          </Link>
        </motion.div>
      </section>

      {/* ════════════ Section 8: Need Help? ════════════ */}
      <section className="bg-white" style={{ padding: '4rem 0' }}>
        <motion.div variants={fadeUp} initial="hidden" whileInView="visible" viewport={{ once: true }} className="max-w-[600px] mx-auto text-center" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
          <h2 className="font-display font-semibold text-[#1A1A1A] text-[2rem]">Questions about your policy?</h2>
          <p className="font-body text-[#4A4A4A] mt-4">Your dedicated advisor is here to help. Reach out anytime.</p>
          <Link to="/contact" className="inline-flex items-center gap-2 mt-6 font-body font-semibold text-[0.875rem] text-white bg-[#2D6A4F] px-6 py-3 rounded-lg transition-all duration-200 hover:bg-[#1B4332] hover:scale-[1.03]">
            Contact My Advisor
          </Link>
          <div className="mt-4">
            <Link to="/tech-support" className="font-body text-[0.875rem] text-[#8A8A8A] hover:text-[#2D6A4F] transition-colors">
              Visit Tech Support
            </Link>
          </div>
        </motion.div>
      </section>
    </div>
  );
}
"""

let render() = file
