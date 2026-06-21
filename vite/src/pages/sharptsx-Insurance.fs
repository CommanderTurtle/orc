module ConvertedFiles.Src.Pages.InsuranceTsx

let file = """import { useState, useEffect, useRef } from 'react';
import { Link } from 'react-router-dom';
import { motion, AnimatePresence } from 'framer-motion';
import {
  Shield, Heart, TrendingUp, Users, ChevronDown, Check,
  Home, Minus, Clock, HeartHandshake, ArrowLeftRight,
  Phone, ArrowRight, Lock
} from 'lucide-react';
import { useAuth } from '@/context/AuthContext';
import homemortgage from '@/assets/home-mortgage.jpg';
import familyprotection from '@/assets/family-protection.jpg';

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

/* ─────────────────────── mortgage type data ─────────────────────── */
const mortgageTypes = [
  {
    id: 1,
    shortName: 'Full Payoff',
    fullName: 'Pay Off Mortgage in Full',
    icon: Home,
    title: 'Complete protection that pays off your entire mortgage balance, ensuring your family owns your home free and clear.',
    description: 'A mortgage protection life insurance policy pays off your remaining mortgage balance in full if you pass away during the term. Your family inherits the home \u2014 free and clear \u2014 with zero mortgage debt.',
    howItWorks: [
      'Purchase a term life policy with a death benefit equal to your current mortgage balance.',
      'Set the term length to match your remaining mortgage years.',
      'If you pass away during the term, the death benefit pays the mortgage lender directly.',
      'Your family receives the home with no remaining mortgage obligation.',
    ],
    benefits: [
      'Complete peace of mind \u2014 no mortgage debt for heirs',
      'Largest death benefit of all protection types',
      'Straightforward: mortgage balance = coverage amount',
      'Typically the most affordable per dollar of coverage',
    ],
    estimatedCost: '$28-45/month',
    costExample: 'for $300K coverage, 30-year term, healthy 35-year-old',
    bestFor: 'Homeowners who want complete peace of mind and want to eliminate all mortgage debt for their heirs.',
    badge: 'Full Protection',
    badgeColor: 'bg-[#2D6A4F]',
  },
  {
    id: 2,
    shortName: 'Partial Payoff',
    fullName: 'Partial Payoff (Lower Monthly)',
    icon: Minus,
    title: 'Strategic partial payoff that significantly reduces your monthly mortgage payment, making it manageable on a reduced income.',
    description: 'Instead of paying off the entire mortgage, a partial payoff strategy reduces the principal balance enough to significantly lower monthly payments. Your family keeps the home with affordable payments they can manage on a reduced income.',
    howItWorks: [
      'Calculate the reduced income your family would have if you passed away.',
      'Determine the mortgage balance needed to keep monthly payments affordable.',
      'Purchase a policy with a death benefit equal to the payoff target.',
      'The partial payoff reduces principal, which recalculates payments on the remaining term.',
    ],
    benefits: [
      'Lower premiums than full payoff coverage',
      'Surviving family keeps the home with manageable payments',
      'Works well when surviving spouse has some income',
      'Flexible: adjust the payoff target as finances change',
    ],
    estimatedCost: '$22-35/month',
    costExample: 'for $150K coverage, 20-year term, healthy 40-year-old',
    bestFor: 'Families where the surviving spouse has some income but needs reduced housing costs.',
    badge: 'Smart Reduction',
    badgeColor: 'bg-[#2A9D8F]',
  },
  {
    id: 3,
    shortName: 'Equity Shield',
    fullName: 'Equity Protection (Time-to-Sell)',
    icon: Clock,
    title: 'Pays enough of your mortgage to provide crucial time \u2014 typically 12-24 months \u2014 to sell your home at full market value without a distressed sale.',
    description: 'This strategy ensures your family has enough time to sell the home on their own terms \u2014 not under distress. The insurance covers mortgage payments for a defined period (typically 12-24 months), giving heirs breathing room to get fair market value.',
    howItWorks: [
      'Calculate your monthly mortgage payment (PITI).',
      'Multiply by the desired protection period (e.g., 18 months).',
      'Purchase a policy with that death benefit amount.',
      'If needed, the payout covers mortgage payments while the home is listed and sold.',
      'Any equity above the mortgage belongs to your heirs.',
    ],
    benefits: [
      'Lowest monthly premium of active protection types',
      'Preserves home equity for the family',
      'Ideal in stable or appreciating markets',
      'Heirs control the timeline \u2014 no forced sale',
    ],
    estimatedCost: '$18-30/month',
    costExample: 'for $50K coverage (~$2,700/mo for 18 months), healthy 45-year-old',
    bestFor: 'Homeowners in markets where property values are stable or appreciating, and where heirs may want to sell.',
    badge: 'Flexibility Shield',
    badgeColor: 'bg-[#D4A574]',
  },
  {
    id: 4,
    shortName: 'Transfer',
    fullName: 'Transfer of Assets to a Loved One',
    icon: HeartHandshake,
    title: 'Designed for transferring your home to a loved one. Pays off enough mortgage to allow time for the move-in process and the massive life change that follows.',
    description: 'This tailored approach pays off enough of the mortgage to allow time for a loved one to move in and navigate a massive life change. Whether it\u2019s an adult child taking over the family home or a sibling moving in to care for dependents, the coverage provides financial runway during the transition.',
    howItWorks: [
      'Identify the specific transfer scenario (who will take over the home).',
      'Calculate the mortgage reduction needed to make payments manageable.',
      'Factor in transition costs: moving, minor renovations, utility transfers.',
      'Purchase a policy covering the mortgage payoff + transition buffer.',
      'The loved one inherits a home they can afford, with time to settle in.',
    ],
    benefits: [
      'Covers 6-18 months of payments during transition',
      'Customized to each family\u2019s unique transfer situation',
      'Includes buffer for moving and setup costs',
      'Ensures dependents are cared for in a familiar home',
    ],
    estimatedCost: '$25-60/month',
    costExample: 'for $100K-$250K coverage, varies by scenario',
    bestFor: 'Families planning generational transfers, caregiving situations, or where a specific loved one is the intended heir.',
    badge: 'Family Bridge',
    badgeColor: 'bg-[#E07A5F]',
  },
  {
    id: 5,
    shortName: 'Reverse',
    fullName: 'Reverse Mortgage Plans',
    icon: ArrowLeftRight,
    title: 'For homeowners 62+, coordinates with reverse mortgage programs to eliminate monthly payments while accessing home equity for retirement income.',
    description: 'For seniors with reverse mortgages, this specialized protection ensures that non-borrowing spouses and heirs aren\u2019t forced to sell the home immediately upon the borrower\u2019s death. It covers the loan balance and gives heirs time to decide the best path forward.',
    howItWorks: [
      'Assess your current reverse mortgage balance and home equity.',
      'Purchase a permanent life insurance policy (whole life or guaranteed universal life).',
      'The death benefit can pay off the reverse mortgage, allowing heirs to keep the home.',
      'Alternatively, heirs can use the benefit to settle the loan and retain remaining equity.',
      'Non-borrowing spouses gain protection against immediate displacement.',
    ],
    benefits: [
      'Protects non-borrowing spouses from displacement',
      'Heirs retain flexibility: keep home or settle loan',
      'Permanent policy accumulates cash value over time',
      'Covers the unique risks of reverse mortgages',
    ],
    estimatedCost: '$180-250/month',
    costExample: 'for $200K guaranteed universal life policy, 70-year-old',
    bestFor: 'Seniors (62+) with reverse mortgages who want to protect their spouse or leave the home to heirs.',
    badge: 'Senior Shield',
    badgeColor: 'bg-[#1B4332]',
  },
];

/* ─────────────────────── accordion data ─────────────────────── */
const lifeInsuranceFacts = [
  { title: 'Income Replacement', content: 'Life insurance replaces your income so your family can maintain their standard of living. Experts recommend 10-12x your annual salary in coverage. For someone earning $75,000/year, that means $750,000-$900,000 in protection.' },
  { title: 'Debt Coverage', content: 'Beyond your mortgage, life insurance can cover credit cards, car loans, student loans, and other debts. The average household carries over $90,000 in debt. Without protection, co-signers and surviving family members may be responsible.' },
  { title: 'Final Expenses', content: 'The average funeral costs $8,000-$12,000 in 2025. Add medical bills, legal fees, and estate settlement costs, and families often face $20,000+ in immediate expenses. Life insurance ensures these don\u2019t burden grieving loved ones.' },
  { title: 'Legacy Building', content: 'Permanent life insurance builds cash value over time that grows tax-deferred. You can borrow against it, use it in retirement, or pass it on as a tax-advantaged inheritance. Whole life and universal life policies are powerful wealth-building tools.' },
  { title: 'Term Life Insurance', content: 'Term life provides affordable coverage for a specific period (10, 15, 20, or 30 years). Premiums are fixed and typically 5-10x cheaper than permanent insurance. Ideal for covering a mortgage, raising children, or other temporary financial obligations.' },
  { title: 'Whole Life Insurance', content: 'Whole life provides lifelong coverage with guaranteed premiums, guaranteed death benefit, and guaranteed cash value growth. It\u2019s the most predictable permanent life insurance option and serves as a foundational piece of long-term financial planning.' },
  { title: 'Universal Life Insurance', content: 'Universal life offers flexible premiums and adjustable death benefits. It combines permanent protection with a savings component that earns interest. Some policies tie cash value growth to market indexes (IUL) for potentially higher returns.' },
  { title: 'Variable Life Insurance', content: 'Variable life lets you invest the cash value portion in sub-accounts similar to mutual funds. This offers higher growth potential but also introduces investment risk. Best for those comfortable with market fluctuations and seeking aggressive cash value growth.' },
];

/* ─────────────────────── FAQ data ─────────────────────── */
const faqData = [
  { question: 'How much life insurance do I actually need?', answer: 'Most financial advisors recommend 10-12x your annual income in coverage. However, the right amount depends on your debts, dependents, future education costs, and your family\'s lifestyle needs. Our advisors help calculate your exact need.' },
  { question: 'What\'s the difference between term and whole life?', answer: 'Term life provides coverage for a specific period (10-30 years) at lower premiums. Whole life is permanent coverage that lasts your entire life and builds cash value. Term is best for temporary needs (mortgage, raising kids); whole life is best for permanent needs (estate planning, final expenses).' },
  { question: 'Can I get life insurance without a medical exam?', answer: 'Yes. In 2025, accelerated underwriting allows many healthy applicants to secure up to $3 million in coverage without a medical exam. Approval can be as fast as 24-48 hours. Coverage amounts and eligibility depend on age and health history.' },
  { question: 'Will my mortgage protection cover both spouses?', answer: 'It depends on the policy structure. Individual policies cover one person. Joint policies can cover both spouses, often paying out on the first death. We recommend speaking with an advisor to determine the best structure for your family.' },
  { question: 'What happens if I outlive my term policy?', answer: 'Your coverage ends, and no benefit is paid. However, many term policies offer conversion options to permanent coverage without a new medical exam. It\'s best to plan ahead \u2014 we help you review options before your term expires.' },
  { question: 'How does the cash value in whole life work?', answer: 'A portion of each premium payment goes into a cash value account that grows tax-deferred over time. You can borrow against it (policy loan), use it to pay premiums, or surrender the policy for the cash value. Typical growth rates range from 3-5% annually.' },
];

/* ─────────────────────── comparison data ─────────────────────── */
const comparisonFeatures = [
  { label: 'Mortgage eliminated?', t1: 'Yes', t2: 'Partially', t3: 'No (time given)', t4: 'Partially', t5: 'Yes (optional)' },
  { label: 'Family keeps home?', t1: 'Yes', t2: 'Yes', t3: 'Optional', t4: 'Yes', t5: 'Yes' },
  { label: 'Monthly cost relief?', t1: '100%', t2: 'Reduced', t3: 'Temporary', t4: 'Structured', t5: 'N/A' },
  { label: 'Time to decide?', t1: 'N/A', t2: 'Immediate', t3: '12-24 months', t4: 'Flexible', t5: 'Flexible' },
  { label: 'Typical policy type', t1: 'Term Life', t2: 'Term Life', t3: 'Term Life', t4: 'Term/Whole', t5: 'Whole/Universal' },
  { label: 'Avg. monthly cost*', t1: '$28-45', t2: '$22-35', t3: '$18-30', t4: '$25-60', t5: '$180-250' },
];

/* ─────────────────────── sub-components ─────────────────────── */

function AccordionItem({ title, children, isOpen, onToggle }: { title: string; children: string; isOpen: boolean; onToggle: () => void }) {
  return (
    <div className={`border rounded-xl bg-white transition-all duration-300 ${isOpen ? 'border-l-[3px] border-l-[#2D6A4F] border-[#F0EDE8]' : 'border-[#F0EDE8]'}`}>
      <button onClick={onToggle} className="w-full flex items-center justify-between p-5 text-left">
        <span className="font-body font-semibold text-[#1A1A1A] text-[1rem]">{title}</span>
        <motion.span animate={{ rotate: isOpen ? 180 : 0 }} transition={{ duration: 0.3 }}>
          <ChevronDown size={20} className="text-[#8A8A8A]" />
        </motion.span>
      </button>
      <AnimatePresence initial={false}>
        {isOpen && (
          <motion.div initial={{ height: 0, opacity: 0 }} animate={{ height: 'auto', opacity: 1 }} exit={{ height: 0, opacity: 0 }} transition={{ duration: 0.3, ease: [0.42, 0, 0.58, 1] as [number, number, number, number] }}>
            <div className="px-5 pb-5 text-[#4A4A4A] leading-relaxed">{children}</div>
          </motion.div>
        )}
      </AnimatePresence>
    </div>
  );
}

function FAQItem({ question, answer, isOpen, onToggle }: { question: string; answer: string; isOpen: boolean; onToggle: () => void }) {
  return (
    <div className="border-b border-[#F0EDE8]">
      <button onClick={onToggle} className="w-full flex items-center justify-between py-5 text-left">
        <span className="font-body font-semibold text-[#1A1A1A] text-[1rem] pr-4">{question}</span>
        <motion.span animate={{ rotate: isOpen ? 180 : 0 }} transition={{ duration: 0.3 }}>
          <ChevronDown size={20} className="text-[#8A8A8A] shrink-0" />
        </motion.span>
      </button>
      <AnimatePresence initial={false}>
        {isOpen && (
          <motion.div initial={{ height: 0, opacity: 0 }} animate={{ height: 'auto', opacity: 1 }} exit={{ height: 0, opacity: 0 }} transition={{ duration: 0.3, ease: [0.42, 0, 0.58, 1] as [number, number, number, number] }}>
            <div className="pb-5 text-[#4A4A4A] leading-relaxed">{answer}</div>
          </motion.div>
        )}
      </AnimatePresence>
    </div>
  );
}

/* Animated counter hook */
function useAnimatedCounter(target: number, duration: number = 2000, start: boolean = false) {
  const [value, setValue] = useState(0);
  const rafRef = useRef<number>(0);

  useEffect(() => {
    if (!start) { setValue(0); return; }
    const startTime = performance.now();
    const animate = (now: number) => {
      const elapsed = now - startTime;
      const progress = Math.min(elapsed / duration, 1);
      const eased = 1 - (1 - progress) * (1 - progress); // power2.out
      setValue(Math.floor(eased * target));
      if (progress < 1) rafRef.current = requestAnimationFrame(animate);
    };
    rafRef.current = requestAnimationFrame(animate);
    return () => cancelAnimationFrame(rafRef.current);
  }, [target, duration, start]);

  return value;
}

/* ─────────────────────── InsuranceDashboardPreview ─────────────────────── */
function InsuranceDashboardPreview() {
  const { isAuthenticated, userName } = useAuth();
  const [mounted, setMounted] = useState(false);
  const sectionRef = useRef<HTMLDivElement>(null);

  useEffect(() => {
    const observer = new IntersectionObserver(
      ([entry]) => { if (entry.isIntersecting) setMounted(true); },
      { threshold: 0.25 }
    );
    if (sectionRef.current) observer.observe(sectionRef.current);
    return () => observer.disconnect();
  }, []);

  const cashValue = useAnimatedCounter(47250, 2000, mounted && isAuthenticated);
  const deathBenefit = useAnimatedCounter(500000, 2000, mounted && isAuthenticated);
  const premiumYear = useAnimatedCounter(8, 2000, mounted && isAuthenticated);

  const ringSize = 200;
  const strokeWidth = 12;
  const radius = (ringSize - strokeWidth) / 2;
  const circumference = 2 * Math.PI * radius;
  const cashOffset = isAuthenticated ? circumference * (1 - 0.47) : circumference;
  const deathOffset = isAuthenticated ? 0 : circumference;
  const premiumOffset = isAuthenticated ? circumference * (1 - 8 / 30) : circumference;

  return (
    <section ref={sectionRef} className="gradient-hero-green" style={{ padding: '6rem 0' }}>
      <div className="max-w-[1200px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
        <motion.div variants={fadeUp} initial="hidden" whileInView="visible" viewport={{ once: true, amount: 0.25 }} className="text-center mb-12">
          <span className="font-body font-medium text-[0.75rem] uppercase tracking-[0.05em] text-[#D4A574]">YOUR INSURANCE DASHBOARD</span>
          <h2 className="font-display font-bold text-white mt-2" style={{ fontSize: 'clamp(2rem, 5vw, 4rem)' }}>See your protection at a glance</h2>
          <p className="font-body text-[1.125rem] text-[rgba(255,255,255,0.8)] mt-4 max-w-[700px] mx-auto">
            {isAuthenticated ? `Welcome back, ${userName}. Here\'s your personalized protection summary.` : 'Track your policy values, cash accumulation, and coverage details. Login to see your personalized dashboard.'}
          </p>
        </motion.div>

        <motion.div variants={fadeUp} initial="hidden" whileInView="visible" viewport={{ once: true }} custom={0.2}
          className="rounded-[24px] p-8 md:p-12" style={{ background: 'rgba(255,255,255,0.05)', backdropFilter: 'blur(16px)', border: '1px solid rgba(255,255,255,0.1)' }}>

          {!isAuthenticated && (
            <div className="flex flex-col items-center justify-center py-8 mb-8">
              <Lock size={48} className="text-[rgba(255,255,255,0.3)] mb-4" />
              <p className="text-white font-body text-[1.125rem] mb-4">Login to see your personalized dashboard</p>
              <Link to="/login" className="inline-flex items-center gap-2 font-body font-semibold text-[0.875rem] text-[#1B4332] bg-white px-6 py-3 rounded-lg transition-all duration-200 hover:bg-[#FAF6F1] hover:scale-[1.03]">
                Login <ArrowRight size={16} />
              </Link>
            </div>
          )}

          <div className="grid grid-cols-1 md:grid-cols-3 gap-8">
            {/* Cash Value Ring */}
            <div className="flex flex-col items-center text-center">
              <div className="relative" style={{ width: ringSize, height: ringSize }}>
                <svg width={ringSize} height={ringSize} className="-rotate-90">
                  <defs>
                    <linearGradient id="cashGradient" x1="0%" y1="0%" x2="100%" y2="0%">
                      <stop offset="0%" stopColor="#2D6A4F" />
                      <stop offset="100%" stopColor="#D4A574" />
                    </linearGradient>
                  </defs>
                  <circle cx={ringSize / 2} cy={ringSize / 2} r={radius} fill="none" stroke="#F0EDE8" strokeWidth={strokeWidth} opacity={0.2} />
                  <motion.circle cx={ringSize / 2} cy={ringSize / 2} r={radius} fill="none" stroke="url(#cashGradient)" strokeWidth={strokeWidth}
                    strokeLinecap="round" strokeDasharray={circumference}
                    animate={{ strokeDashoffset: cashOffset }}
                    transition={{ duration: 2, ease: [0.45, 0.05, 0.55, 0.95] }} />
                </svg>
                <div className="absolute inset-0 flex flex-col items-center justify-center">
                  <span className="font-mono font-bold text-[1.75rem] text-white">{isAuthenticated ? `$${cashValue.toLocaleString()}` : '\u2014'}</span>
                  <span className="font-body font-medium text-[0.875rem] text-[rgba(255,255,255,0.6)] mt-1">Cash Value</span>
                </div>
              </div>
              <div className="mt-4 space-y-1">
                <p className="text-[#52B788] font-body text-[0.875rem] flex items-center gap-1"><TrendingUp size={14} /> Annual Growth: {isAuthenticated ? '+$3,200' : '\u2014'}</p>
                <p className="text-[rgba(255,255,255,0.5)] font-body text-[0.875rem]">Projected at age 65: {isAuthenticated ? '$128,000' : '\u2014'}</p>
              </div>
            </div>

            {/* Death Benefit Ring */}
            <div className="flex flex-col items-center text-center">
              <div className="relative" style={{ width: ringSize, height: ringSize }}>
                <svg width={ringSize} height={ringSize} className="-rotate-90">
                  <defs>
                    <linearGradient id="deathGradient" x1="0%" y1="0%" x2="100%" y2="0%">
                      <stop offset="0%" stopColor="#2A9D8F" />
                      <stop offset="100%" stopColor="#52B788" />
                    </linearGradient>
                  </defs>
                  <circle cx={ringSize / 2} cy={ringSize / 2} r={radius} fill="none" stroke="#F0EDE8" strokeWidth={strokeWidth} opacity={0.2} />
                  <motion.circle cx={ringSize / 2} cy={ringSize / 2} r={radius} fill="none" stroke="url(#deathGradient)" strokeWidth={strokeWidth}
                    strokeLinecap="round" strokeDasharray={circumference}
                    animate={{ strokeDashoffset: deathOffset }}
                    transition={{ duration: 2, ease: [0.45, 0.05, 0.55, 0.95] }} />
                </svg>
                <div className="absolute inset-0 flex flex-col items-center justify-center">
                  <span className="font-mono font-bold text-[1.75rem] text-white">{isAuthenticated ? `$${deathBenefit.toLocaleString()}` : '\u2014'}</span>
                  <span className="font-body font-medium text-[0.875rem] text-[rgba(255,255,255,0.6)] mt-1">Death Benefit</span>
                </div>
              </div>
              <div className="mt-4 space-y-1">
                <p className="text-[rgba(255,255,255,0.7)] font-body text-[0.875rem]">Policy Type: {isAuthenticated ? 'Whole Life' : '\u2014'}</p>
                <p className="text-[rgba(255,255,255,0.5)] font-body text-[0.875rem]">Beneficiaries: {isAuthenticated ? '2 designated' : '\u2014'}</p>
              </div>
            </div>

            {/* Premium Progress */}
            <div className="flex flex-col items-center text-center">
              <div className="relative" style={{ width: ringSize, height: ringSize }}>
                <svg width={ringSize} height={ringSize} className="-rotate-90">
                  <defs>
                    <linearGradient id="premiumGradient" x1="0%" y1="0%" x2="100%" y2="0%">
                      <stop offset="0%" stopColor="#D4A574" />
                      <stop offset="100%" stopColor="#E9C46A" />
                    </linearGradient>
                  </defs>
                  <circle cx={ringSize / 2} cy={ringSize / 2} r={radius} fill="none" stroke="#F0EDE8" strokeWidth={strokeWidth} opacity={0.2} />
                  <motion.circle cx={ringSize / 2} cy={ringSize / 2} r={radius} fill="none" stroke="url(#premiumGradient)" strokeWidth={strokeWidth}
                    strokeLinecap="round" strokeDasharray={circumference}
                    animate={{ strokeDashoffset: premiumOffset }}
                    transition={{ duration: 2, ease: [0.45, 0.05, 0.55, 0.95] }} />
                </svg>
                <div className="absolute inset-0 flex flex-col items-center justify-center">
                  <span className="font-mono font-bold text-[1.75rem] text-white">{isAuthenticated ? `Year ${premiumYear}` : '\u2014'}</span>
                  <span className="font-body font-medium text-[0.875rem] text-[rgba(255,255,255,0.6)] mt-1">of 30</span>
                </div>
              </div>
              <div className="mt-4 space-y-1 w-full max-w-[240px]">
                <div className="flex justify-between text-[0.875rem]"><span className="text-[rgba(255,255,255,0.7)]">Monthly</span><span className="font-mono text-white">{isAuthenticated ? '$285' : '\u2014'}</span></div>
                <div className="flex justify-between text-[0.875rem]"><span className="text-[rgba(255,255,255,0.7)]">Annual</span><span className="font-mono text-white">{isAuthenticated ? '$3,420' : '\u2014'}</span></div>
                <div className="h-2 bg-[rgba(255,255,255,0.1)] rounded-full mt-2 overflow-hidden">
                  <motion.div className="h-full rounded-full" style={{ background: 'linear-gradient(90deg, #D4A574, #E9C46A)' }}
                    animate={{ width: isAuthenticated ? '26.7%' : '0%' }} transition={{ duration: 1.5, delay: 0.5 }} />
                </div>
              </div>
            </div>
          </div>
        </motion.div>
      </div>
    </section>
  );
}

/* ─────────────────────── main Insurance page ─────────────────────── */
export default function Insurance() {
  const [activeTab, setActiveTab] = useState(0);
  const [openFact, setOpenFact] = useState<number | null>(0);
  const [openFaq, setOpenFaq] = useState<number | null>(null);

  const activeType = mortgageTypes[activeTab];
  const TabIcon = activeType.icon;

  return (
    <div className="min-h-[100dvh]">
      {/* ════════════ Section 1: Hero ════════════ */}
      <section className="relative min-h-[60vh] flex items-center" style={{ background: 'linear-gradient(135deg, #1B4332 0%, #2D6A4F 50%, #2A9D8F 100%)' }}>
        <img src={homemortgage} alt="Home" className="absolute inset-0 w-full h-full object-cover opacity-20" />
        <div className="absolute inset-0" style={{ background: 'linear-gradient(to right, rgba(27,67,50,0.95) 0%, rgba(27,67,50,0.7) 60%, rgba(27,67,50,0.4) 100%)' }} />
        <div className="relative z-10 max-w-[1280px] mx-auto w-full" style={{ padding: '8rem clamp(1rem, 5vw, 3rem) 4rem' }}>
          <div className="max-w-[700px]">
            <motion.span variants={fadeUp} initial="hidden" animate="visible" className="inline-block font-body font-medium text-[0.75rem] uppercase tracking-[0.05em] text-[#D4A574] mb-4">INSURANCE PROTECTION</motion.span>
            <motion.h1 variants={fadeUp} initial="hidden" animate="visible" custom={0.1} className="font-display font-bold text-white" style={{ fontSize: 'clamp(2rem, 5vw, 4rem)', lineHeight: 1.1 }}>
              Comprehensive Insurance Protection
            </motion.h1>
            <motion.p variants={fadeUp} initial="hidden" animate="visible" custom={0.2} className="font-body text-[1.125rem] text-[rgba(255,255,255,0.8)] mt-6 leading-relaxed max-w-[600px]">
              From life insurance to mortgage protection, Turtle Protect helps you find the right coverage from 50+ top-rated carriers — all tailored to your unique situation.
            </motion.p>
            <motion.div variants={fadeUp} initial="hidden" animate="visible" custom={0.3} className="flex flex-wrap gap-8 mt-8">
              <div>
                <p className="font-mono font-bold text-[2rem] text-[#D4A574]">41%</p>
                <p className="font-body text-[0.875rem] text-[rgba(255,255,255,0.6)]">of adults need more life insurance</p>
              </div>
              <div>
                <p className="font-mono font-bold text-[2rem] text-[#D4A574]">$22<span className="text-[1.25rem]">/mo</span></p>
                <p className="font-body text-[0.875rem] text-[rgba(255,255,255,0.6)]">starting cost for term life</p>
              </div>
            </motion.div>
            <motion.div variants={fadeUp} initial="hidden" animate="visible" custom={0.4} className="mt-8">
              <Link to="/contact" className="inline-flex items-center gap-2 font-body font-semibold text-[0.875rem] text-[#1B4332] bg-white px-6 py-3 rounded-lg transition-all duration-200 hover:bg-[#FAF6F1] hover:scale-[1.03]">
                Get Your Free Quote <ArrowRight size={16} />
              </Link>
            </motion.div>
          </div>
        </div>
      </section>

      {/* ════════════ Section 2: Why Life Insurance Matters ════════════ */}
      <section className="bg-[#FAF6F1]" style={{ padding: '6rem 0' }}>
        <div className="max-w-[1280px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
          <motion.div variants={fadeUp} initial="hidden" whileInView="visible" viewport={{ once: true, amount: 0.2 }} className="text-center mb-12">
            <span className="font-body font-medium text-[0.75rem] uppercase tracking-[0.05em] text-[#2D6A4F]">LIFE INSURANCE IN 2025</span>
            <h2 className="font-display font-bold text-[#1A1A1A] mt-2" style={{ fontSize: 'clamp(1.5rem, 3vw, 2.5rem)' }}>Why life insurance matters more than ever</h2>
          </motion.div>

          <div className="grid grid-cols-1 lg:grid-cols-2 gap-12">
            {/* Left: accordion facts */}
            <motion.div variants={staggerContainer} initial="hidden" whileInView="visible" viewport={{ once: true, amount: 0.2 }} className="space-y-4">
              {lifeInsuranceFacts.map((fact, i) => (
                <motion.div key={i} variants={staggerItem}>
                  <AccordionItem title={fact.title} isOpen={openFact === i} onToggle={() => setOpenFact(openFact === i ? null : i)}>
                    {fact.content}
                  </AccordionItem>
                </motion.div>
              ))}
            </motion.div>

            {/* Right: image + stats */}
            <motion.div variants={fadeUp} initial="hidden" whileInView="visible" viewport={{ once: true }} custom={0.3} className="space-y-6">
              <img src={familyprotection} alt="Family protection" className="w-full rounded-2xl shadow-lg object-cover" />
              <div className="grid grid-cols-2 gap-4">
                {[
                  { icon: Shield, stat: '60%', label: 'of Americans have life insurance' },
                  { icon: Heart, stat: '$500K+', label: 'average household coverage need' },
                  { icon: TrendingUp, stat: '$3M', label: 'max no-exam coverage in 2025' },
                  { icon: Users, stat: '50+', label: 'A-rated carriers we work with' },
                ].map((item, i) => (
                  <div key={i} className="bg-white rounded-xl p-4 border border-[#F0EDE8] flex items-start gap-3">
                    <item.icon size={20} className="text-[#2D6A4F] mt-1 shrink-0" />
                    <div>
                      <p className="font-mono font-bold text-[1.25rem] text-[#1A1A1A]">{item.stat}</p>
                      <p className="font-body text-[0.75rem] text-[#8A8A8A]">{item.label}</p>
                    </div>
                  </div>
                ))}
              </div>
            </motion.div>
          </div>
        </div>
      </section>

      {/* ════════════ Section 3: 5 Mortgage Protection Types ════════════ */}
      <section className="bg-white" style={{ padding: '6rem 0' }}>
        <div className="max-w-[1280px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
          <motion.div variants={fadeUp} initial="hidden" whileInView="visible" viewport={{ once: true, amount: 0.2 }} className="mb-10">
            <span className="font-body font-medium text-[0.75rem] uppercase tracking-[0.05em] text-[#D4A574]">MORTGAGE PROTECTION</span>
            <h2 className="font-display font-bold text-[#1A1A1A] mt-2" style={{ fontSize: 'clamp(2rem, 5vw, 4rem)' }}>5 ways to keep your home protected</h2>
            <p className="font-body text-[1.125rem] text-[#4A4A4A] mt-4 max-w-[700px]">Your mortgage is likely your largest financial obligation. These five strategies ensure your family never has to worry about losing their home.</p>
          </motion.div>

          {/* Tab selector */}
          <motion.div variants={staggerContainer} initial="hidden" whileInView="visible" viewport={{ once: true }} className="flex gap-3 mb-10 overflow-x-auto pb-2">
            {mortgageTypes.map((type, i) => {
              const Icon = type.icon;
              return (
                <motion.button key={type.id} variants={staggerItem} onClick={() => setActiveTab(i)}
                  className={`flex items-center gap-2 px-5 py-3 rounded-xl font-body font-medium text-[0.875rem] whitespace-nowrap transition-all duration-200 border shrink-0 ${
                    activeTab === i ? 'bg-[#2D6A4F] text-white border-[#2D6A4F]' : 'bg-transparent text-[#4A4A4A] border-[#F0EDE8] hover:bg-[rgba(45,106,79,0.05)] hover:border-[rgba(45,106,79,0.3)]'
                  }`}>
                  <Icon size={18} className={activeTab === i ? 'text-[#D4A574]' : 'text-[#8A8A8A]'} />
                  {type.shortName}
                </motion.button>
              );
            })}
          </motion.div>

          {/* Detail panel */}
          <AnimatePresence mode="wait">
            <motion.div key={activeTab} initial={{ opacity: 0, y: 10 }} animate={{ opacity: 1, y: 0 }} exit={{ opacity: 0, y: -10 }} transition={{ duration: 0.3 }}
              className="grid grid-cols-1 lg:grid-cols-12 gap-10">

              {/* Left: text */}
              <div className="lg:col-span-7 space-y-6">
                <div>
                  <h3 className="font-display font-bold text-[#1A1A1A] text-[1.75rem]">{activeType.fullName}</h3>
                  <p className="font-body text-[1.125rem] text-[#4A4A4A] leading-relaxed mt-3">{activeType.description}</p>
                </div>

                <div>
                  <h4 className="font-body font-semibold text-[#1A1A1A] mb-3">How It Works</h4>
                  <ol className="space-y-3">
                    {activeType.howItWorks.map((step, i) => (
                      <li key={i} className="flex items-start gap-3">
                        <span className="flex items-center justify-center w-6 h-6 rounded-full bg-[#2D6A4F] text-white font-mono font-bold text-[0.75rem] shrink-0 mt-0.5">{i + 1}</span>
                        <span className="text-[#4A4A4A] leading-relaxed">{step}</span>
                      </li>
                    ))}
                  </ol>
                </div>

                <div>
                  <h4 className="font-body font-semibold text-[#1A1A1A] mb-3">Key Benefits</h4>
                  <ul className="grid grid-cols-1 sm:grid-cols-2 gap-3">
                    {activeType.benefits.map((benefit, i) => (
                      <li key={i} className="flex items-start gap-2">
                        <Check size={18} className="text-[#52B788] shrink-0 mt-0.5" />
                        <span className="text-[#4A4A4A] text-[0.875rem]">{benefit}</span>
                      </li>
                    ))}
                  </ul>
                </div>

                <div className="flex flex-wrap gap-4 pt-2">
                  <div className="bg-[#FAF6F1] rounded-xl px-5 py-3">
                    <p className="font-body text-[0.75rem] text-[#8A8A8A] uppercase tracking-wider">Estimated Cost</p>
                    <p className="font-mono font-bold text-[1.25rem] text-[#2D6A4F]">{activeType.estimatedCost}</p>
                    <p className="font-body text-[0.75rem] text-[#8A8A8A]">{activeType.costExample}</p>
                  </div>
                  <div className="bg-[#FAF6F1] rounded-xl px-5 py-3 flex-1 min-w-[200px]">
                    <p className="font-body text-[0.75rem] text-[#8A8A8A] uppercase tracking-wider">Best For</p>
                    <p className="font-body text-[0.875rem] text-[#4A4A4A] mt-1 leading-relaxed">{activeType.bestFor}</p>
                  </div>
                </div>
              </div>

              {/* Right: visual card */}
              <div className="lg:col-span-5 flex items-start">
                <div className="w-full rounded-2xl p-8 gradient-warm-glow border border-[#F0EDE8] text-center">
                  <div className={`inline-flex items-center justify-center w-20 h-20 rounded-full ${activeType.badgeColor} text-white mb-4`}>
                    <TabIcon size={40} />
                  </div>
                  <span className={`inline-block px-4 py-1 rounded-full text-white font-body font-semibold text-[0.75rem] ${activeType.badgeColor}`}>{activeType.badge}</span>
                  <div className="mt-6 space-y-4 text-left">
                    <div className="bg-white rounded-xl p-4">
                      <p className="font-body text-[0.75rem] text-[#8A8A8A] uppercase tracking-wider mb-1">Coverage Strategy</p>
                      <p className="font-body text-[0.875rem] text-[#4A4A4A]">{activeType.title}</p>
                    </div>
                    <div className="bg-white rounded-xl p-4">
                      <p className="font-body text-[0.75rem] text-[#8A8A8A] uppercase tracking-wider mb-1">Typical Time Frame</p>
                      <p className="font-body text-[0.875rem] text-[#4A4A4A]">
                        {activeTab === 0 && 'Matches mortgage term (15-30 years)'}
                        {activeTab === 1 && 'Matches remaining mortgage years'}
                        {activeTab === 2 && '12-24 months of payment coverage'}
                        {activeTab === 3 && '6-18 months transition period'}
                        {activeTab === 4 && 'Lifetime protection (permanent policy)'}
                      </p>
                    </div>
                    <div className="bg-white rounded-xl p-4">
                      <p className="font-body text-[0.75rem] text-[#8A8A8A] uppercase tracking-wider mb-1">Policy Type</p>
                      <p className="font-body text-[0.875rem] text-[#4A4A4A]">
                        {activeTab === 0 && 'Term Life Insurance'}
                        {activeTab === 1 && 'Term Life Insurance'}
                        {activeTab === 2 && 'Term Life Insurance'}
                        {activeTab === 3 && 'Term or Whole Life'}
                        {activeTab === 4 && 'Whole or Universal Life'}
                      </p>
                    </div>
                  </div>
                </div>
              </div>
            </motion.div>
          </AnimatePresence>
        </div>
      </section>

      {/* ════════════ Section 4: Comparison Table ════════════ */}
      <section className="bg-[#F0EDE8]" style={{ padding: '6rem 0' }}>
        <div className="max-w-[1280px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
          <motion.div variants={fadeUp} initial="hidden" whileInView="visible" viewport={{ once: true, amount: 0.25 }} className="text-center mb-10">
            <span className="font-body font-medium text-[0.75rem] uppercase tracking-[0.05em] text-[#2D6A4F]">QUICK COMPARISON</span>
            <h2 className="font-display font-bold text-[#1A1A1A] mt-2" style={{ fontSize: 'clamp(1.5rem, 3vw, 2.5rem)' }}>Find your protection strategy</h2>
          </motion.div>

          <motion.div variants={fadeUp} initial="hidden" whileInView="visible" viewport={{ once: true }} custom={0.2} className="overflow-x-auto">
            <table className="w-full min-w-[700px] rounded-xl overflow-hidden border border-[#F0EDE8]">
              <thead>
                <tr className="bg-[#2D6A4F]">
                  <th className="text-left font-body font-semibold text-[0.875rem] text-white px-5 py-4">Feature</th>
                  <th className="text-center font-body font-semibold text-[0.875rem] text-white px-4 py-4">Full Payoff</th>
                  <th className="text-center font-body font-semibold text-[0.875rem] text-white px-4 py-4">Partial Payoff</th>
                  <th className="text-center font-body font-semibold text-[0.875rem] text-white px-4 py-4">Equity Shield</th>
                  <th className="text-center font-body font-semibold text-[0.875rem] text-white px-4 py-4">Transfer</th>
                  <th className="text-center font-body font-semibold text-[0.875rem] text-white px-4 py-4">Reverse Mtg</th>
                </tr>
              </thead>
              <tbody>
                {comparisonFeatures.map((row, i) => (
                  <tr key={i} className={`${i % 2 === 0 ? 'bg-white' : 'bg-[#FAF6F1]'} hover:bg-[rgba(45,106,79,0.05)] transition-colors`}>
                    <td className="font-body font-medium text-[0.875rem] text-[#1A1A1A] px-5 py-4">{row.label}</td>
                    {[row.t1, row.t2, row.t3, row.t4, row.t5].map((cell, j) => (
                      <td key={j} className="text-center px-4 py-4">
                        {cell === 'Yes' ? (
                          <span className="inline-flex items-center justify-center"><Check size={18} className="text-[#52B788]" /></span>
                        ) : (
                          <span className={`font-body text-[0.875rem] ${cell.includes('$') ? 'font-mono text-[#1A1A1A]' : 'text-[#4A4A4A]'}`}>{cell}</span>
                        )}
                      </td>
                    ))}
                  </tr>
                ))}
              </tbody>
            </table>
          </motion.div>
          <p className="text-center font-body text-[0.75rem] text-[#8A8A8A] mt-4">*Estimates for healthy individuals, ages 35-70. Actual rates vary.</p>
          <div className="text-center mt-8">
            <Link to="/contact" className="inline-flex items-center gap-2 font-body font-semibold text-[0.875rem] text-[#1A1A1A] bg-[#D4A574] px-6 py-3 rounded-lg transition-all duration-200 hover:bg-[#E9C46A] hover:scale-[1.03]">
              Not sure which is right? Speak with an advisor
            </Link>
          </div>
        </div>
      </section>

      {/* ════════════ Section 5: Insurance Dashboard Preview ════════════ */}
      <InsuranceDashboardPreview />

      {/* ════════════ Section 6: Carrier Partners ════════════ */}
      <section className="bg-[#FAF6F1]" style={{ padding: '6rem 0' }}>
        <div className="max-w-[1280px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
          <motion.div variants={fadeUp} initial="hidden" whileInView="visible" viewport={{ once: true, amount: 0.2 }} className="text-center mb-10">
            <span className="font-body font-medium text-[0.75rem] uppercase tracking-[0.05em] text-[#2D6A4F]">TRUSTED PARTNERS</span>
            <h2 className="font-display font-bold text-[#1A1A1A] mt-2" style={{ fontSize: 'clamp(1.5rem, 3vw, 2.5rem)' }}>Backed by A-rated carriers we trust</h2>
            <p className="font-body text-[1rem] text-[#4A4A4A] mt-4 max-w-[600px] mx-auto">As a licensed independent agent, Turtle Protect is appointed with these industry-leading carriers to find you the best coverage at the best price.</p>
          </motion.div>
          <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-4" style={{ gap: '1.25rem' }}>
            {[
              { name: 'Mutual of Omaha', rating: 'A+ (AM Best)', since: '1909', specialty: 'Term, Whole & IUL Life', desc: 'Living Promise whole life, Income Advantage IUL, and no-exam Term Life Express options.' },
              { name: 'Transamerica', rating: 'A (AM Best)', since: '1904', specialty: 'IUL, Term & Final Expense', desc: 'FFIUL II Express with instant-decision underwriting. Top 5 IUL provider in the U.S.' },
              { name: 'Corebridge (AIG)', rating: 'A (AM Best)', since: '1919', specialty: 'Term, IUL & Annuities', desc: 'Formerly AIG Life. Leading provider of retirement solutions and universal life insurance.' },
              { name: 'Ethos Life', rating: 'A (AM Best)', since: '2016', specialty: 'Digital Term & Whole', desc: '100% online application. Term life up to $2M. No medical exam options available.' },
              { name: 'American Amicable', rating: 'A (AM Best)', since: '1910', specialty: 'Final Expense & Term', desc: 'Financial Lifeline whole life, Security Protector term, and simplified issue products.' },
              { name: 'Ameritas', rating: 'A+ (AM Best)', since: '1887', specialty: 'Life, Disability & Dental', desc: 'Comprehensive life insurance with strong disability income and dental rider options.' },
              { name: 'National Life Group', rating: 'A (AM Best)', since: '1848', specialty: 'IUL, Whole & Annuities', desc: 'Over 175 years of financial protection. Strong indexed universal life and annuity portfolio.' },
              { name: 'TruStage', rating: 'A (AM Best)', since: '1935', specialty: 'Whole & Term Life', desc: 'Trusted by 42M+ members. Simplified issue whole life with online application and quick decisions.' },
            ].map((carrier, idx) => (
              <motion.div
                key={carrier.name}
                variants={staggerItem}
                initial="hidden"
                whileInView="visible"
                viewport={{ once: true }}
                className="bg-white border border-[#F0EDE8] rounded-xl p-6 shadow-card hover:shadow-card-hover transition-all duration-300 hover:-translate-y-1"
                style={{ borderRadius: '16px', animationDelay: `${idx * 0.08}s` }}
              >
                <div className="flex items-center justify-between mb-3">
                  <h3 className="font-body font-semibold text-[0.9375rem] text-[#1A1A1A]">{carrier.name}</h3>
                  <span className="font-body text-[0.6875rem] text-[#2D6A4F] bg-[rgba(45,106,79,0.1)] px-2 py-0.5 rounded-full">{carrier.rating}</span>
                </div>
                <p className="font-body text-[0.8125rem] text-[#D4A574] mb-2">{carrier.specialty} &middot; Est. {carrier.since}</p>
                <p className="font-body text-[0.8125rem] text-[#8A8A8A]" style={{ lineHeight: 1.5 }}>{carrier.desc}</p>
              </motion.div>
            ))}
          </div>
        </div>
      </section>

      {/* ════════════ Section 7: FAQ ════════════ */}
      <section className="bg-white" style={{ padding: '6rem 0' }}>
        <div className="max-w-[800px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
          <motion.div variants={fadeUp} initial="hidden" whileInView="visible" viewport={{ once: true, amount: 0.2 }} className="text-center mb-10">
            <span className="font-body font-medium text-[0.75rem] uppercase tracking-[0.05em] text-[#2D6A4F]">FREQUENTLY ASKED QUESTIONS</span>
            <h2 className="font-display font-bold text-[#1A1A1A] mt-2" style={{ fontSize: 'clamp(1.5rem, 3vw, 2.5rem)' }}>Common questions about insurance protection</h2>
          </motion.div>
          <motion.div variants={staggerContainer} initial="hidden" whileInView="visible" viewport={{ once: true }}>
            {faqData.map((faq, i) => (
              <motion.div key={i} variants={staggerItem}>
                <FAQItem question={faq.question} answer={faq.answer} isOpen={openFaq === i} onToggle={() => setOpenFaq(openFaq === i ? null : i)} />
              </motion.div>
            ))}
          </motion.div>
        </div>
      </section>

      {/* ════════════ Section 8: CTA ════════════ */}
      <section className="gradient-hero-green" style={{ padding: '6rem 0' }}>
        <div className="max-w-[800px] mx-auto text-center" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
          <motion.h2 variants={fadeUp} initial="hidden" whileInView="visible" viewport={{ once: true, amount: 0.3 }} className="font-display font-bold text-white" style={{ fontSize: 'clamp(2rem, 5vw, 4rem)' }}>Ready to protect what matters most?</motion.h2>
          <motion.p variants={fadeUp} initial="hidden" whileInView="visible" viewport={{ once: true }} custom={0.2} className="font-body text-[1.125rem] text-[rgba(255,255,255,0.8)] mt-4">Our advisors are standing by to help you find the perfect protection plan. Free consultation, no obligation.</motion.p>
          <motion.div variants={fadeUp} initial="hidden" whileInView="visible" viewport={{ once: true }} custom={0.4} className="flex flex-wrap justify-center gap-4 mt-8">
            <Link to="/contact" className="inline-flex items-center gap-2 font-body font-semibold text-[0.875rem] text-[#1B4332] bg-white px-6 py-3 rounded-lg transition-all duration-200 hover:bg-[#FAF6F1] hover:scale-[1.03]">
              Get Your Free Quote
            </Link>
            <a href="tel:+13524284009" className="inline-flex items-center gap-2 font-body font-semibold text-[0.875rem] text-white border border-white px-6 py-3 rounded-lg transition-all duration-200 hover:bg-[rgba(255,255,255,0.1)]">
              <Phone size={16} /> Call (352) 428-4009
            </a>
          </motion.div>
          <motion.div variants={fadeUp} initial="hidden" whileInView="visible" viewport={{ once: true }} custom={0.6} className="flex flex-wrap justify-center gap-6 mt-8">
            {['A+ Rated', '50+ Carriers', 'No Obligation'].map((badge) => (
              <span key={badge} className="inline-flex items-center gap-2 font-body text-[0.875rem] text-[rgba(255,255,255,0.6)]">
                <Check size={16} className="text-[#D4A574]" /> {badge}
              </span>
            ))}
          </motion.div>
        </div>
      </section>
    </div>
  );
}
"""

let render() = file
