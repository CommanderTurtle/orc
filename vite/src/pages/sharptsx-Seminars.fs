module ConvertedFiles.Src.Pages.SeminarsTsx

let file = """import { useState, useRef } from 'react';
import { motion, useInView } from 'framer-motion';
import {
  Phone,
  Shield,
  TrendingUp,
  Check,
  Clock,
  MapPin,
  Users,
  Star,
  ChevronRight,
  UserPlus,
  BookOpen,
  Calendar,
  Monitor,
  ArrowRight,
} from 'lucide-react';
import { Input } from '@/components/ui/input';
import { Textarea } from '@/components/ui/textarea';
import { cn } from '@/lib/utils';
import seminarroom from '@/assets/seminar-room.jpg';


/* ------------------------------------------------------------------ */
/*  Data                                                               */
/* ------------------------------------------------------------------ */

const identityTakeaways = [
  'How to read and monitor your credit reports',
  'Recognizing phishing, vishing, and smishing attacks',
  'Setting up fraud alerts and credit freezes',
  'Best practices for password security and 2FA',
  'What to do if your identity is stolen (step-by-step response)',
];

const financialTakeaways = [
  'Building an emergency fund that actually protects you',
  'Understanding life insurance and when you need it',
  'Mortgage protection strategies for homeowners',
  'Annuities explained: guaranteed income for retirement',
  'Estate planning basics: wills, trusts, and beneficiary designations',
];

interface SeminarEvent {
  date: string;
  month: string;
  track: 'Identity Protection' | 'Financial Guidance';
  title: string;
  location: string;
  time: string;
}

const upcomingSeminars: SeminarEvent[] = [
  {
    date: '15',
    month: 'Jan',
    track: 'Identity Protection',
    title: 'Protecting Your Digital Identity',
    location: 'Tampa, FL',
    time: '6:00 PM EST',
  },
  {
    date: '22',
    month: 'Jan',
    track: 'Financial Guidance',
    title: 'Foundations of Financial Protection',
    location: 'Orlando, FL',
    time: '10:00 AM EST',
  },
  {
    date: '5',
    month: 'Feb',
    track: 'Identity Protection',
    title: 'Protecting Your Digital Identity',
    location: 'Virtual',
    time: '7:00 PM EST',
  },
  {
    date: '12',
    month: 'Feb',
    track: 'Financial Guidance',
    title: 'Foundations of Financial Protection',
    location: 'Miami, FL',
    time: '10:00 AM EST',
  },
];

const seminarOptions = [
  'Jan 15, 2025 — Identity Protection — Tampa, FL — 6:00 PM EST',
  'Jan 22, 2025 — Financial Guidance — Orlando, FL — 10:00 AM EST',
  'Feb 5, 2025 — Identity Protection — Virtual — 7:00 PM EST',
  'Feb 12, 2025 — Financial Guidance — Miami, FL — 10:00 AM EST',
];

/* ------------------------------------------------------------------ */
/*  Animation helpers                                                  */
/* ------------------------------------------------------------------ */

const fadeUp = {
  hidden: { opacity: 0, y: 40 },
  visible: (delay = 0) => ({
    opacity: 1,
    y: 0,
    transition: { duration: 0.6, delay, ease: [0.25, 0.46, 0.45, 0.94] as [number, number, number, number] },
  }),
};

const staggerContainer = {
  hidden: {},
  visible: { transition: { staggerChildren: 0.08 } },
};

const staggerItem = {
  hidden: { opacity: 0, y: 30 },
  visible: {
    opacity: 1,
    y: 0,
    transition: { duration: 0.5, ease: [0.25, 0.46, 0.45, 0.94] as [number, number, number, number] },
  },
};

const slideInLeft = {
  hidden: { opacity: 0, x: -60 },
  visible: {
    opacity: 1,
    x: 0,
    transition: { duration: 0.7, ease: [0.25, 0.46, 0.45, 0.94] as [number, number, number, number] },
  },
};

const slideInRight = {
  hidden: { opacity: 0, x: 60 },
  visible: {
    opacity: 1,
    x: 0,
    transition: { duration: 0.7, ease: [0.25, 0.46, 0.45, 0.94] as [number, number, number, number] },
  },
};

function FadeInSection({
  children,
  className,
  delay = 0,
}: {
  children: React.ReactNode;
  className?: string;
  delay?: number;
}) {
  const ref = useRef<HTMLDivElement>(null);
  const isInView = useInView(ref, { once: true, margin: '-80px' });
  return (
    <motion.div
      ref={ref}
      className={className}
      variants={fadeUp}
      initial="hidden"
      animate={isInView ? 'visible' : 'hidden'}
      custom={delay}
    >
      {children}
    </motion.div>
  );
}

/* ------------------------------------------------------------------ */
/*  Registration Form                                                  */
/* ------------------------------------------------------------------ */

function RegistrationForm() {
  const [form, setForm] = useState({
    firstName: '',
    lastName: '',
    email: '',
    phone: '',
    seminar: '',
    attendanceType: 'In-Person',
    guests: '0',
    dietary: '',
  });
  const [submitted, setSubmitted] = useState(false);

  const handleChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement | HTMLSelectElement>,
  ) => {
    setForm((prev) => ({ ...prev, [e.target.name]: e.target.value }));
  };

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    setSubmitted(true);
  };

  if (submitted) {
    return (
      <motion.div
        initial={{ opacity: 0, scale: 0.95 }}
        animate={{ opacity: 1, scale: 1 }}
        transition={{ duration: 0.5 }}
        className="bg-white rounded-2xl p-8 md:p-10 text-center shadow-card"
      >
        <div className="w-16 h-16 rounded-full bg-[#52B788] flex items-center justify-center mx-auto mb-6">
          <Check className="w-8 h-8 text-white" />
        </div>
        <h3 className="font-display text-2xl font-semibold text-[#1A1A1A] mb-2">
          Registration Complete!
        </h3>
        <p className="text-[#4A4A4A] mb-1">
          Thank you, <span className="font-medium">{form.firstName} {form.lastName}</span>.
        </p>
        <p className="text-[#4A4A4A] mb-4">
          You are registered for <span className="font-medium text-[#2D6A4F]">{form.seminar}</span>.
        </p>
        <div className="bg-[#FAF6F1] rounded-xl p-4 max-w-sm mx-auto text-left space-y-2 mb-6">
          <p className="text-sm text-[#4A4A4A]">
            <span className="font-medium">Attendance:</span> {form.attendanceType}
          </p>
          <p className="text-sm text-[#4A4A4A]">
            <span className="font-medium">Guests:</span> {form.guests}
          </p>
          {form.dietary && (
            <p className="text-sm text-[#4A4A4A]">
              <span className="font-medium">Notes:</span> {form.dietary}
            </p>
          )}
        </div>
        <p className="text-[#8A8A8A] text-sm">
          A calendar invite has been sent to <span className="font-medium">{form.email}</span>.
        </p>
        <button
          onClick={() => {
            setSubmitted(false);
            setForm({
              firstName: '',
              lastName: '',
              email: '',
              phone: '',
              seminar: '',
              attendanceType: 'In-Person',
              guests: '0',
              dietary: '',
            });
          }}
          className="mt-6 font-body font-semibold text-[0.875rem] text-white bg-[#2D6A4F] px-6 py-2.5 rounded-lg transition-all duration-200 hover:bg-[#1B4332] hover:scale-[1.03]"
        >
          Register for Another Seminar
        </button>
      </motion.div>
    );
  }

  return (
    <form onSubmit={handleSubmit} className="bg-white rounded-2xl p-8 md:p-10 shadow-card">
      <div className="space-y-5">
        <div className="grid grid-cols-1 sm:grid-cols-2 gap-4">
          <div>
            <label className="block text-sm font-medium text-[#1A1A1A] mb-1.5">First Name</label>
            <Input
              name="firstName"
              placeholder="First name"
              required
              value={form.firstName}
              onChange={handleChange}
            />
          </div>
          <div>
            <label className="block text-sm font-medium text-[#1A1A1A] mb-1.5">Last Name</label>
            <Input
              name="lastName"
              placeholder="Last name"
              required
              value={form.lastName}
              onChange={handleChange}
            />
          </div>
        </div>
        <div>
          <label className="block text-sm font-medium text-[#1A1A1A] mb-1.5">Email</label>
          <Input
            name="email"
            type="email"
            placeholder="your@email.com"
            required
            value={form.email}
            onChange={handleChange}
          />
        </div>
        <div>
          <label className="block text-sm font-medium text-[#1A1A1A] mb-1.5">Phone</label>
          <Input
            name="phone"
            type="tel"
            placeholder="(555) 123-4567"
            value={form.phone}
            onChange={handleChange}
          />
        </div>
        <div>
          <label className="block text-sm font-medium text-[#1A1A1A] mb-1.5">Seminar Selection</label>
          <select
            name="seminar"
            required
            value={form.seminar}
            onChange={handleChange}
            className="w-full h-9 rounded-md border border-[hsl(var(--input))] bg-transparent px-3 py-1 text-sm shadow-xs transition-[color,box-shadow] outline-none focus-visible:ring-[3px] focus-visible:ring-ring/50"
          >
            <option value="">Choose a session...</option>
            {seminarOptions.map((opt) => (
              <option key={opt} value={opt}>
                {opt}
              </option>
            ))}
          </select>
        </div>
        <div className="grid grid-cols-1 sm:grid-cols-2 gap-4">
          <div>
            <label className="block text-sm font-medium text-[#1A1A1A] mb-1.5">Attendance Type</label>
            <select
              name="attendanceType"
              value={form.attendanceType}
              onChange={handleChange}
              className="w-full h-9 rounded-md border border-[hsl(var(--input))] bg-transparent px-3 py-1 text-sm shadow-xs transition-[color,box-shadow] outline-none focus-visible:ring-[3px] focus-visible:ring-ring/50"
            >
              <option>In-Person</option>
              <option>Virtual</option>
            </select>
          </div>
          <div>
            <label className="block text-sm font-medium text-[#1A1A1A] mb-1.5">Number of Guests</label>
            <select
              name="guests"
              value={form.guests}
              onChange={handleChange}
              className="w-full h-9 rounded-md border border-[hsl(var(--input))] bg-transparent px-3 py-1 text-sm shadow-xs transition-[color,box-shadow] outline-none focus-visible:ring-[3px] focus-visible:ring-ring/50"
            >
              <option value="0">0</option>
              <option value="1">1</option>
              <option value="2">2</option>
              <option value="3">3</option>
            </select>
          </div>
        </div>
        <div>
          <label className="block text-sm font-medium text-[#1A1A1A] mb-1.5">
            Dietary Restrictions / Accessibility Needs <span className="text-[#8A8A8A] font-normal">(optional)</span>
          </label>
          <Textarea
            name="dietary"
            placeholder="Please let us know of any dietary restrictions or accessibility accommodations."
            rows={3}
            value={form.dietary}
            onChange={handleChange}
          />
        </div>
        <button
          type="submit"
          className="w-full font-body font-semibold text-[0.875rem] text-white bg-[#2D6A4F] px-6 py-3 rounded-lg transition-all duration-200 hover:bg-[#1B4332] hover:scale-[1.02] flex items-center justify-center gap-2"
        >
          <Check className="w-4 h-4" /> Complete Registration
        </button>
      </div>
    </form>
  );
}

/* ------------------------------------------------------------------ */
/*  Main Page                                                          */
/* ------------------------------------------------------------------ */

export default function Seminars() {
  const [_openFormFor, setOpenFormFor] = useState<string | null>(null);

  const scrollToRegistration = () => {
    const el = document.getElementById('registration-form');
    if (el) el.scrollIntoView({ behavior: 'smooth' });
  };

  return (
    <div className="min-h-screen">
      {/* ========== HERO ========== */}
      <section
        className="relative min-h-[65vh] flex items-center overflow-hidden"
        style={{
          background: 'linear-gradient(135deg, #2D6A4F 0%, #D4A574 50%, #2A9D8F 100%)',
        }}
      >
        <div className="relative z-10 max-w-[1280px] mx-auto px-4 sm:px-6 lg:px-8 py-24 w-full">
          <div className="grid grid-cols-1 lg:grid-cols-2 gap-12 items-center">
            {/* Left */}
            <div>
              <motion.span
                initial={{ opacity: 0, y: 20 }}
                animate={{ opacity: 1, y: 0 }}
                transition={{ duration: 0.5 }}
                className="inline-block text-xs font-body font-medium uppercase tracking-[0.05em] text-white/80 mb-4"
              >
                Learning Seminars
              </motion.span>
              <motion.h1
                initial={{ opacity: 0, y: 30 }}
                animate={{ opacity: 1, y: 0 }}
                transition={{ duration: 0.6, delay: 0.1 }}
                className="font-display text-4xl md:text-5xl lg:text-6xl font-bold text-white mb-6"
                style={{ lineHeight: 1.1 }}
              >
                Learning Seminars
              </motion.h1>
              <motion.p
                initial={{ opacity: 0, y: 20 }}
                animate={{ opacity: 1, y: 0 }}
                transition={{ duration: 0.6, delay: 0.2 }}
                className="text-lg text-white/85 mb-8 max-w-lg"
                style={{ lineHeight: 1.7 }}
              >
                Free educational workshops on identity protection and financial guidance
              </motion.p>
              <motion.div
                initial={{ opacity: 0, y: 20 }}
                animate={{ opacity: 1, y: 0 }}
                transition={{ duration: 0.6, delay: 0.3 }}
                className="flex flex-wrap gap-6 mb-8"
              >
                <div>
                  <div className="font-mono text-2xl font-bold text-white">2 Tracks</div>
                  <div className="text-white/70 text-sm">Identity Protection & Financial Guidance</div>
                </div>
                <div>
                  <div className="font-mono text-2xl font-bold text-white">Free</div>
                  <div className="text-white/70 text-sm">All seminars complimentary</div>
                </div>
              </motion.div>
              <motion.button
                initial={{ opacity: 0, y: 20 }}
                animate={{ opacity: 1, y: 0 }}
                transition={{ duration: 0.6, delay: 0.4 }}
                onClick={() => {
                  const el = document.getElementById('upcoming-schedule');
                  if (el) el.scrollIntoView({ behavior: 'smooth' });
                }}
                className="font-body font-semibold text-[0.875rem] text-[#2D6A4F] bg-white px-6 py-3 rounded-lg transition-all duration-200 hover:bg-[#FAF6F1] hover:scale-[1.03] inline-flex items-center gap-2"
              >
                View Upcoming Seminars <ArrowRight className="w-4 h-4" />
              </motion.button>
            </div>
            {/* Right */}
            <motion.div
              initial={{ opacity: 0, x: 60 }}
              animate={{ opacity: 1, x: 0 }}
              transition={{ duration: 0.8, delay: 0.3 }}
              className="relative hidden lg:block"
            >
              <img
                src={seminarroom}
                alt="Seminar room"
                className="rounded-2xl shadow-[0_12px_40px_rgba(0,0,0,0.2)] w-full object-cover"
                style={{ maxHeight: '400px' }}
              />
              <motion.div
                initial={{ opacity: 0, scale: 0 }}
                animate={{ opacity: 1, scale: 1 }}
                transition={{ duration: 0.5, delay: 0.6, type: 'spring', bounce: 0.4 }}
                className="absolute -top-4 -right-4 bg-white/90 backdrop-blur rounded-xl p-3 shadow-lg"
              >
                <div className="flex items-center gap-2">
                  <Calendar className="w-4 h-4 text-[#2D6A4F]" />
                  <span className="text-sm font-medium text-[#1A1A1A]">Next Seminar: Feb 12</span>
                </div>
              </motion.div>
              <motion.div
                initial={{ opacity: 0, scale: 0 }}
                animate={{ opacity: 1, scale: 1 }}
                transition={{ duration: 0.5, delay: 0.7, type: 'spring', bounce: 0.4 }}
                className="absolute -bottom-4 -left-4 bg-white/90 backdrop-blur rounded-xl p-3 shadow-lg"
              >
                <div className="flex items-center gap-1 text-[#D4A574]">
                  {[1, 2, 3, 4, 5].map((s) => (
                    <Star key={s} className="w-3.5 h-3.5 fill-current" />
                  ))}
                  <span className="text-sm font-medium text-[#1A1A1A] ml-1">Incredibly informative!</span>
                </div>
              </motion.div>
            </motion.div>
          </div>
        </div>
      </section>

      {/* ========== TWO LEARNING TRACKS ========== */}
      <section className="bg-[#FAF6F1] py-16 md:py-24 px-4 sm:px-6 lg:px-8">
        <div className="max-w-[1280px] mx-auto">
          <FadeInSection className="text-center mb-14">
            <span className="text-xs font-body font-medium uppercase tracking-[0.05em] text-[#2D6A4F] mb-3 block">
              Choose Your Track
            </span>
            <h2 className="font-display text-3xl md:text-4xl font-semibold text-[#1A1A1A]" style={{ lineHeight: 1.2 }}>
              Two paths to financial confidence
            </h2>
          </FadeInSection>

          <div className="grid grid-cols-1 lg:grid-cols-2 gap-8">
            {/* Track 1 — Identity Protection */}
            <motion.div
              variants={slideInLeft}
              initial="hidden"
              whileInView="visible"
              viewport={{ once: true, margin: '-80px' }}
              className="bg-white rounded-2xl border-t-4 border-t-[#457B9D] p-8 shadow-card border border-[#F0EDE8]"
            >
              <div className="flex items-center gap-3 mb-4">
                <div className="w-14 h-14 rounded-xl bg-[#457B9D]/10 flex items-center justify-center">
                  <Shield className="w-7 h-7 text-[#457B9D]" />
                </div>
                <span className="px-3 py-1 rounded-full bg-[rgba(69,123,157,0.1)] text-[#457B9D] text-xs font-medium uppercase tracking-wider">
                  Security Focus
                </span>
              </div>
              <h3 className="font-display text-2xl font-semibold text-[#1A1A1A] mb-3">
                Protecting Your Digital Identity
              </h3>
              <p className="text-[#4A4A4A] mb-6 leading-relaxed">
                Learn how to safeguard your personal information in the digital age. Topics include:
                credit monitoring, fraud prevention, password security, recognizing phishing
                attempts, and responding to identity theft.
              </p>
              <div className="flex flex-wrap gap-4 mb-6 text-sm text-[#4A4A4A]">
                <span className="flex items-center gap-1.5">
                  <Clock className="w-4 h-4 text-[#457B9D]" /> 2-hour workshop
                </span>
                <span className="flex items-center gap-1.5">
                  <Monitor className="w-4 h-4 text-[#457B9D]" /> In-person or virtual
                </span>
                <span className="flex items-center gap-1.5">
                  <Users className="w-4 h-4 text-[#457B9D]" /> Anyone concerned about identity theft
                </span>
              </div>
              <div className="mb-6">
                <h4 className="font-semibold text-sm text-[#1A1A1A] mb-2">Key Takeaways</h4>
                <ul className="space-y-2">
                  {identityTakeaways.map((item) => (
                    <li key={item} className="flex items-start gap-2 text-sm text-[#4A4A4A]">
                      <Check className="w-4 h-4 text-[#52B788] mt-0.5 shrink-0" />
                      {item}
                    </li>
                  ))}
                </ul>
              </div>
              <button
                onClick={scrollToRegistration}
                className="font-body font-semibold text-[0.875rem] text-[#457B9D] border border-[#457B9D] px-5 py-2.5 rounded-lg transition-all duration-200 hover:bg-[rgba(69,123,157,0.08)] inline-flex items-center gap-2"
              >
                Sign Up for Identity Protection <ChevronRight className="w-4 h-4" />
              </button>
            </motion.div>

            {/* Track 2 — Financial Guidance */}
            <motion.div
              variants={slideInRight}
              initial="hidden"
              whileInView="visible"
              viewport={{ once: true, margin: '-80px' }}
              className="bg-white rounded-2xl border-t-4 border-t-[#D4A574] p-8 shadow-card border border-[#F0EDE8]"
            >
              <div className="flex items-center gap-3 mb-4">
                <div className="w-14 h-14 rounded-xl bg-[#D4A574]/10 flex items-center justify-center">
                  <TrendingUp className="w-7 h-7 text-[#D4A574]" />
                </div>
                <span className="px-3 py-1 rounded-full bg-[rgba(212,165,116,0.1)] text-[#D4A574] text-xs font-medium uppercase tracking-wider">
                  Wealth Focus
                </span>
              </div>
              <h3 className="font-display text-2xl font-semibold text-[#1A1A1A] mb-3">
                Foundations of Financial Protection
              </h3>
              <p className="text-[#4A4A4A] mb-6 leading-relaxed">
                Build a solid foundation for your financial future. Topics include: understanding
                life insurance, mortgage protection strategies, annuity basics, retirement planning,
                and building an emergency fund.
              </p>
              <div className="flex flex-wrap gap-4 mb-6 text-sm text-[#4A4A4A]">
                <span className="flex items-center gap-1.5">
                  <Clock className="w-4 h-4 text-[#D4A574]" /> 3-hour workshop
                </span>
                <span className="flex items-center gap-1.5">
                  <Monitor className="w-4 h-4 text-[#D4A574]" /> In-person or virtual
                </span>
                <span className="flex items-center gap-1.5">
                  <Users className="w-4 h-4 text-[#D4A574]" /> Families, homeowners, retirees
                </span>
              </div>
              <div className="mb-6">
                <h4 className="font-semibold text-sm text-[#1A1A1A] mb-2">Key Takeaways</h4>
                <ul className="space-y-2">
                  {financialTakeaways.map((item) => (
                    <li key={item} className="flex items-start gap-2 text-sm text-[#4A4A4A]">
                      <Check className="w-4 h-4 text-[#52B788] mt-0.5 shrink-0" />
                      {item}
                    </li>
                  ))}
                </ul>
              </div>
              <button
                onClick={scrollToRegistration}
                className="font-body font-semibold text-[0.875rem] text-[#D4A574] border border-[#D4A574] px-5 py-2.5 rounded-lg transition-all duration-200 hover:bg-[rgba(212,165,116,0.08)] inline-flex items-center gap-2"
              >
                Sign Up for Financial Guidance <ChevronRight className="w-4 h-4" />
              </button>
            </motion.div>
          </div>
        </div>
      </section>

      {/* ========== UPCOMING SCHEDULE ========== */}
      <section id="upcoming-schedule" className="bg-white py-16 md:py-24 px-4 sm:px-6 lg:px-8">
        <div className="max-w-[1000px] mx-auto">
          <FadeInSection className="text-center mb-12">
            <span className="text-xs font-body font-medium uppercase tracking-[0.05em] text-[#D4A574] mb-3 block">
              Upcoming Sessions
            </span>
            <h2 className="font-display text-3xl md:text-4xl font-semibold text-[#1A1A1A] mb-4" style={{ lineHeight: 1.2 }}>
              Reserve your spot
            </h2>
            <p className="text-[#4A4A4A] max-w-xl mx-auto">
              All seminars are free and include Q&A. Select a session below to register.
            </p>
          </FadeInSection>

          <motion.div
            variants={staggerContainer}
            initial="hidden"
            whileInView="visible"
            viewport={{ once: true, margin: '-80px' }}
            className="space-y-4"
          >
            {upcomingSeminars.map((event, i) => (
              <motion.div
                key={`${event.month}-${event.date}-${event.track}`}
                variants={staggerItem}
                className="relative flex flex-col sm:flex-row items-start sm:items-center gap-4 bg-[#FAF6F1] rounded-xl p-5 border border-[#F0EDE8] transition-all duration-300 hover:bg-white hover:shadow-[0_4px_16px_rgba(0,0,0,0.06)] hover:translate-x-1"
              >
                {/* Date block */}
                <div className="shrink-0 w-16 h-16 rounded-lg bg-[#2D6A4F] flex flex-col items-center justify-center text-white">
                  <span className="text-xs uppercase font-medium">{event.month}</span>
                  <span className="text-xl font-bold font-mono">{event.date}</span>
                </div>
                {/* Info */}
                <div className="flex-1 min-w-0">
                  <div className="flex flex-wrap items-center gap-2 mb-1">
                    <h4 className="font-body font-semibold text-lg text-[#1A1A1A]">{event.title}</h4>
                    <span
                      className={cn(
                        'px-2 py-0.5 rounded-full text-xs font-medium',
                        event.track === 'Identity Protection'
                          ? 'bg-[rgba(69,123,157,0.1)] text-[#457B9D]'
                          : 'bg-[rgba(212,165,116,0.1)] text-[#D4A574]',
                      )}
                    >
                      {event.track}
                    </span>
                  </div>
                  <div className="flex flex-wrap gap-3 text-sm text-[#8A8A8A]">
                    <span className="flex items-center gap-1">
                      <Clock className="w-3.5 h-3.5" /> {event.time}
                    </span>
                    <span className="flex items-center gap-1">
                      <MapPin className="w-3.5 h-3.5" /> {event.location}
                    </span>
                  </div>
                </div>
                {/* Register */}
                <button
                  onClick={() => {
                    setOpenFormFor(`${event.month} ${event.date}, 2025 — ${event.track}`);
                    scrollToRegistration();
                  }}
                  className="shrink-0 font-body font-semibold text-[0.875rem] text-white bg-[#2D6A4F] px-5 py-2 rounded-lg transition-all duration-200 hover:bg-[#1B4332] hover:scale-[1.03]"
                >
                  Register Now
                </button>
                {/* Timeline connector */}
                {i < upcomingSeminars.length - 1 && (
                  <div className="hidden sm:block absolute left-[2.875rem] -bottom-5 w-0.5 h-5 border-l-2 border-dashed border-[#F0EDE8]" />
                )}
              </motion.div>
            ))}
          </motion.div>
        </div>
      </section>

      {/* ========== REGISTRATION FORM ========== */}
      <section id="registration-form" className="bg-[#F0EDE8] py-16 md:py-24 px-4 sm:px-6 lg:px-8">
        <div className="max-w-[700px] mx-auto">
          <FadeInSection className="text-center mb-10">
            <span className="text-xs font-body font-medium uppercase tracking-[0.05em] text-[#2D6A4F] mb-3 block">
              Register Now
            </span>
            <h2 className="font-display text-3xl md:text-4xl font-semibold text-[#1A1A1A]" style={{ lineHeight: 1.2 }}>
              Sign up for a seminar
            </h2>
          </FadeInSection>
          <FadeInSection delay={0.15}>
            <RegistrationForm />
          </FadeInSection>
        </div>
      </section>

      {/* ========== WHAT TO EXPECT ========== */}
      <section className="bg-[#FAF6F1] py-16 md:py-24 px-4 sm:px-6 lg:px-8">
        <div className="max-w-[1000px] mx-auto">
          <FadeInSection className="text-center mb-14">
            <span className="text-xs font-body font-medium uppercase tracking-[0.05em] text-[#2D6A4F] mb-3 block">
              What to Expect
            </span>
            <h2 className="font-display text-3xl md:text-4xl font-semibold text-[#1A1A1A]" style={{ lineHeight: 1.2 }}>
              Your learning journey
            </h2>
          </FadeInSection>

          <motion.div
            variants={staggerContainer}
            initial="hidden"
            whileInView="visible"
            viewport={{ once: true, margin: '-80px' }}
            className="grid grid-cols-1 md:grid-cols-3 gap-8"
          >
            {[
              {
                step: '01',
                icon: UserPlus,
                title: 'Register',
                desc: 'Choose your track and session. Fill out the quick registration form above to reserve your spot.',
              },
              {
                step: '02',
                icon: BookOpen,
                title: 'Attend',
                desc: 'Join us in-person or via Zoom. Engage with certified instructors and ask questions during Q&A.',
              },
              {
                step: '03',
                icon: Shield,
                title: 'Protect',
                desc: 'Apply what you learned immediately. Take home actionable strategies to safeguard your identity and finances.',
              },
            ].map((s) => (
              <motion.div
                key={s.step}
                variants={staggerItem}
                className="text-center"
              >
                <div className="w-16 h-16 rounded-2xl bg-[#2D6A4F]/10 flex items-center justify-center mx-auto mb-5">
                  <s.icon className="w-8 h-8 text-[#2D6A4F]" />
                </div>
                <span className="text-xs font-mono font-medium text-[#D4A574] mb-2 block">
                  STEP {s.step}
                </span>
                <h3 className="font-body font-semibold text-xl text-[#1A1A1A] mb-2">{s.title}</h3>
                <p className="text-[#4A4A4A] text-sm leading-relaxed">{s.desc}</p>
              </motion.div>
            ))}
          </motion.div>
        </div>
      </section>

      {/* ========== TESTIMONIAL ========== */}
      <section className="bg-white py-16 md:py-24 px-4 sm:px-6 lg:px-8">
        <div className="max-w-[800px] mx-auto">
          <FadeInSection className="text-center">
            <div className="inline-flex items-center gap-1 text-[#D4A574] mb-6">
              {[1, 2, 3, 4, 5].map((s) => (
                <Star key={s} className="w-5 h-5 fill-current" />
              ))}
            </div>
            <blockquote className="font-display italic text-2xl md:text-3xl text-[#1A1A1A] mb-6 leading-relaxed">
              &ldquo;The identity protection seminar opened my eyes to risks I never knew existed. Highly recommend!&rdquo;
            </blockquote>
            <cite className="not-italic">
              <span className="font-body font-semibold text-[#1A1A1A]">Maria S.</span>
              <span className="text-[#8A8A8A] text-sm ml-2">Tampa, FL</span>
            </cite>
          </FadeInSection>
        </div>
      </section>

      {/* ========== CTA ========== */}
      <section
        className="py-16 md:py-24 px-4 sm:px-6 lg:px-8"
        style={{ background: 'linear-gradient(135deg, #1B4332 0%, #2D6A4F 50%, #2A9D8F 100%)' }}
      >
        <div className="max-w-[700px] mx-auto text-center">
          <FadeInSection>
            <h2 className="font-display text-3xl md:text-4xl font-bold text-white mb-4" style={{ lineHeight: 1.2 }}>
              Invest in Your Knowledge
            </h2>
            <p className="text-lg text-white/80 mb-8">
              All seminars are free and led by certified professionals. Reserve your spot today — space is limited.
            </p>
            <div className="flex flex-wrap items-center justify-center gap-4">
              <button
                onClick={() => {
                  const el = document.getElementById('upcoming-schedule');
                  if (el) el.scrollIntoView({ behavior: 'smooth' });
                }}
                className="font-body font-semibold text-[0.875rem] text-[#2D6A4F] bg-white px-6 py-3 rounded-lg transition-all duration-200 hover:bg-[#FAF6F1] hover:scale-[1.03]"
              >
                Browse Upcoming Seminars
              </button>
              <a
                href="tel:+13524284009"
                className="font-body font-semibold text-[0.875rem] text-white border border-white/40 px-6 py-3 rounded-lg transition-all duration-200 hover:bg-white/10 inline-flex items-center gap-2"
              >
                <Phone className="w-4 h-4" /> Questions? Call (352) 428-4009
              </a>
            </div>
          </FadeInSection>
        </div>
      </section>
    </div>
  );
}
"""

let render() = file
