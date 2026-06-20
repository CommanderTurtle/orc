module Imported.Src.Pages.ContactTsx

let file = """import { useState, useRef, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { motion, AnimatePresence } from 'framer-motion';
import {
  Phone,
  Mail,
  MapPin,
  Send,
  CheckCircle,
  MessageCircle,
  Calendar,
  Clock,
  UserCheck,
  Shield,
  Heart,
  ChevronDown,
} from 'lucide-react';
import { sendPrefilledEmail } from '@/utils/emailUtils';
import floridaoffice from '@/assets/florida-office.jpg';

/* ------------------------------------------------------------------ */
/*  Types                                                              */
/* ------------------------------------------------------------------ */
interface FormData {
  fullName: string;
  email: string;
  phone: string;
  inquiryType: string;
  preferredContact: string;
  message: string;
}

/* ------------------------------------------------------------------ */
/*  Constants                                                          */
/* ------------------------------------------------------------------ */
const INQUIRY_TYPES = [
  { value: '', label: 'What would you like to protect?' },
  { value: 'My Life (Life Insurance)', label: 'My Life (Life Insurance)' },
  { value: 'My Home (Mortgage Protection)', label: 'My Home (Mortgage Protection)' },
  { value: 'My Money (Annuities)', label: 'My Money (Annuities)' },
  { value: 'My Health (Health Coverage)', label: 'My Health (Health Coverage)' },
  { value: 'My Privacy (Identity Protection)', label: 'My Privacy (Identity Protection)' },
  { value: 'My Assets (Asset Protection)', label: 'My Assets (Asset Protection)' },
  { value: 'General Inquiry', label: 'General Inquiry' },
  { value: 'Other', label: 'Other' },
];

const PREFERRED_CONTACTS = [
  { value: '', label: 'How should we reach you?' },
  { value: 'Email', label: 'Email' },
  { value: 'Phone', label: 'Phone' },
  { value: 'Either', label: 'Either' },
];

const CONTACT_METHODS = [
  {
    icon: Phone,
    title: 'Call Us',
    detail: '(352) 428-4009',
    detailAlt: '(352) 428-4009',
    href: 'tel:+13524284009',
    availability: 'Mon-Fri, 8am-6pm EST',
  },
  {
    icon: Mail,
    title: 'Email Us',
    detail: 'clement.keynote-1e@icloud.com',
    href: 'mailto:clement.keynote-1e@icloud.com',
    availability: 'Response within 24hrs',
  },
  {
    icon: MessageCircle,
    title: 'Live Chat',
    detail: 'Chat with our team',
    href: '#',
    availability: 'Mon-Fri, 9am-5pm EST',
  },
  {
    icon: Calendar,
    title: 'Attend a Seminar',
    detail: 'Free educational workshops',
    href: '/seminars',
    availability: 'See schedule online',
  },
];

const PROMISES = [
  {
    icon: Clock,
    title: 'Within 24 Hours',
    description:
      'Every inquiry receives a response within one business day. No exceptions.',
  },
  {
    icon: UserCheck,
    title: 'Personalized Attention',
    description:
      'A dedicated advisor handles your inquiry from start to finish — no bouncing between departments.',
  },
  {
    icon: Shield,
    title: 'No Pressure, Ever',
    description:
      'We provide information and guidance. You\u2019ll never face pushy sales tactics.',
  },
  {
    icon: Heart,
    title: 'Free Consultations',
    description:
      'Initial consultations are always complimentary. Explore your options at no cost.',
  },
];

const FAQ_ITEMS = [
  {
    question: 'How quickly will I hear back?',
    answer:
      'We respond to all inquiries within 1 business day. Phone calls are answered immediately during business hours. Chat responses typically arrive within 15 minutes.',
  },
  {
    question: 'Is there a cost for the initial consultation?',
    answer:
      'No. Initial consultations are completely free and carry no obligation. We believe everyone deserves to understand their protection options.',
  },
  {
    question: 'What information should I prepare?',
    answer:
      'For the most productive conversation, have a general sense of your budget, any existing coverage, and what you\u2019d like to protect. Don\u2019t worry if you\u2019re unsure \u2014 our advisors guide you through everything.',
  },
];

/* ------------------------------------------------------------------ */
/*  Animation helpers                                                  */
/* ------------------------------------------------------------------ */
const fadeUp = {
  hidden: { opacity: 0, y: 40 },
  visible: (i: number) => ({
    opacity: 1,
    y: 0,
    transition: { duration: 0.6, delay: i * 0.15, ease: [0, 0, 0.2, 1] as [number, number, number, number] },
  }),
};

const staggerContainer = {
  hidden: {},
  visible: { transition: { staggerChildren: 0.1 } },
};

const staggerItem = {
  hidden: { opacity: 0, y: 30 },
  visible: { opacity: 1, y: 0, transition: { duration: 0.5, ease: [0, 0, 0.2, 1] as [number, number, number, number] } },
};

/* ------------------------------------------------------------------ */
/*  Main Component                                                     */
/* ------------------------------------------------------------------ */
export default function Contact() {
  const [form, setForm] = useState<FormData>({
    fullName: '',
    email: '',
    phone: '',
    inquiryType: '',
    preferredContact: '',
    message: '',
  });
  const [submitted, setSubmitted] = useState(false);
  const [errors, setErrors] = useState<Partial<Record<keyof FormData, boolean>>>({});
  const formRef = useRef<HTMLDivElement>(null);

  const update = (field: keyof FormData, value: string) => {
    setForm((prev) => ({ ...prev, [field]: value }));
    if (errors[field]) {
      setErrors((prev) => ({ ...prev, [field]: false }));
    }
  };

  const validate = () => {
    const newErrors: Partial<Record<keyof FormData, boolean>> = {};
    if (!form.fullName.trim()) newErrors.fullName = true;
    if (!form.email.trim()) newErrors.email = true;
    if (!form.inquiryType) newErrors.inquiryType = true;
    if (!form.preferredContact) newErrors.preferredContact = true;
    if (!form.message.trim()) newErrors.message = true;
    setErrors(newErrors);
    return Object.keys(newErrors).length === 0;
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    if (!validate()) return;

    const body = `New Inquiry from Turtle Protect Website

Name: ${form.fullName}
Email: ${form.email}
Phone: ${form.phone || 'Not provided'}
Inquiry Type: ${form.inquiryType}
Preferred Contact: ${form.preferredContact}

Message:
${form.message}

---
Submitted via turtleprotect.org/contact`;

    await sendPrefilledEmail({
      to: 'clement.keynote-1e@icloud.com',
      subject: `New Inquiry: ${form.inquiryType} from ${form.fullName}`,
      body,
    });

    setSubmitted(true);
  };

  const resetForm = () => {
    setForm({
      fullName: '',
      email: '',
      phone: '',
      inquiryType: '',
      preferredContact: '',
      message: '',
    });
    setSubmitted(false);
    setErrors({});
  };

  const scrollToForm = () => {
    formRef.current?.scrollIntoView({ behavior: 'smooth', block: 'start' });
  };

  /* Intersection Observer for reveal animations */
  const useReveal = () => {
    const ref = useRef<HTMLDivElement>(null);
    const [visible, setVisible] = useState(false);

    useEffect(() => {
      const el = ref.current;
      if (!el) return;
      const observer = new IntersectionObserver(
        ([entry]) => {
          if (entry.isIntersecting) setVisible(true);
        },
        { threshold: 0.2 },
      );
      observer.observe(el);
      return () => observer.disconnect();
    }, []);

    return { ref, visible };
  };

  const heroReveal = useReveal();
  const formReveal = useReveal();
  const methodsReveal = useReveal();
  const officeReveal = useReveal();
  const promiseReveal = useReveal();
  const faqReveal = useReveal();
  const ctaReveal = useReveal();

  /* Shared input styles */
  const inputBase =
    'w-full bg-[#FAF6F1] border border-[#F0EDE8] rounded-[10px] px-[18px] py-[14px] font-body text-base text-ink placeholder:text-stone-muted transition-all duration-200 outline-none focus:border-[#2D6A4F] focus:ring-[3px] focus:ring-[rgba(45,106,79,0.15)]';

  return (
    <div className="min-h-[100dvh]">
      {/* ============================================================ */}
      {/* SECTION 1 — HERO                                            */}
      {/* ============================================================ */}
      <section className="gradient-hero-green min-h-[55vh] flex items-center relative overflow-hidden">
        <div className="max-w-[1280px] mx-auto w-full" style={{ padding: 'clamp(1rem, 5vw, 3rem)' }}>
          <div className="flex flex-col lg:flex-row items-center gap-12 pt-20">
            {/* Left column */}
            <motion.div
              className="lg:w-[55%] text-center lg:text-left"
              ref={heroReveal.ref}
              initial="hidden"
              animate={heroReveal.visible ? 'visible' : 'hidden'}
            >
              <motion.span
                className="inline-block font-body font-medium text-xs uppercase tracking-[0.05em] text-[#D4A574] mb-4"
                variants={fadeUp}
                custom={0}
              >
                GET IN TOUCH
              </motion.span>
              <motion.h1
                className="font-display font-bold text-white leading-tight"
                style={{ fontSize: 'clamp(2rem, 5vw, 4rem)' }}
                variants={fadeUp}
                custom={1}
              >
                We&apos;d love to hear from you
              </motion.h1>
              <motion.p
                className="mt-4 text-lg leading-relaxed text-[rgba(255,255,255,0.8)] max-w-xl"
                variants={fadeUp}
                custom={2}
              >
                Whether you have a question about insurance, need help with your account, or just
                want to learn more about how we can protect what matters — our team is here for you.
              </motion.p>
              <motion.div
                className="mt-6 flex flex-wrap items-center justify-center lg:justify-start gap-6"
                variants={fadeUp}
                custom={3}
              >
                <a
                  href="tel:+13524284009"
                  className="flex items-center gap-2 font-mono font-medium text-[#D4A574] hover:text-[#E9C46A] transition-colors"
                >
                  <Phone size={18} />
                  (352) 428-4009
                </a>
                <a
                  href="mailto:clement.keynote-1e@icloud.com"
                  className="flex items-center gap-2 font-mono font-medium text-[#D4A574] hover:text-[#E9C46A] transition-colors"
                >
                  <Mail size={18} />
                  clement.keynote-1e@icloud.com
                </a>
              </motion.div>
              <motion.p
                className="mt-3 text-sm text-[rgba(255,255,255,0.5)]"
                variants={fadeUp}
                custom={4}
              >
                Available Monday–Friday, 8:00 AM – 6:00 PM EST
              </motion.p>
            </motion.div>

            {/* Right column */}
            <motion.div
              className="lg:w-[45%] relative"
              initial={{ opacity: 0, x: 60 }}
              animate={heroReveal.visible ? { opacity: 1, x: 0 } : {}}
              transition={{ duration: 0.8, ease: [0, 0, 0.2, 1] as [number, number, number, number], delay: 0.2 }}
            >
              <div className="rounded-2xl overflow-hidden shadow-[0_8px_32px_rgba(0,0,0,0.2)] border border-[rgba(255,255,255,0.1)]">
                <img
                  src={floridaoffice}
                  alt="Turtle Protect Florida Office"
                  className="w-full h-auto object-cover"
                />
              </div>
              <div
                className="absolute bottom-4 left-4 flex items-center gap-2 rounded-full font-body text-sm text-white"
                style={{
                  background: 'rgba(255,255,255,0.15)',
                  backdropFilter: 'blur(8px)',
                  padding: '0.5rem 1rem',
                }}
              >
                <MapPin size={14} />
                Florida-Based &middot; Serving Families Statewide
              </div>
            </motion.div>
          </div>
        </div>
      </section>

      {/* ============================================================ */}
      {/* SECTION 2 — CONTACT FORM                                    */}
      {/* ============================================================ */}
      <section className="bg-[#FAF6F1] py-20 lg:py-28" ref={formRef}>
        <div className="max-w-[800px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
          <motion.div
            ref={formReveal.ref}
            initial="hidden"
            animate={formReveal.visible ? 'visible' : 'hidden'}
            className="text-center mb-10"
            variants={staggerContainer}
          >
            <motion.span
              className="inline-block font-body font-medium text-xs uppercase tracking-[0.05em] text-[#2D6A4F] mb-3"
              variants={staggerItem}
            >
              SEND AN INQUIRY
            </motion.span>
            <motion.h2
              className="font-display font-semibold text-deep-forest"
              style={{ fontSize: 'clamp(1.5rem, 3vw, 2.5rem)' }}
              variants={staggerItem}
            >
              What can we help you protect?
            </motion.h2>
            <motion.p className="mt-3 text-base text-slate-text" variants={staggerItem}>
              Fill out the form below and a Turtle Protect advisor will respond within one business
              day.
            </motion.p>
          </motion.div>

          <motion.div
            className="bg-white rounded-[20px] shadow-[0_4px_24px_rgba(0,0,0,0.06)]"
            style={{ padding: 'clamp(1.5rem, 4vw, 3rem)' }}
            initial={{ opacity: 0, y: 60 }}
            animate={formReveal.visible ? { opacity: 1, y: 0 } : {}}
            transition={{ duration: 0.9, ease: [0, 0, 0.2, 1] as [number, number, number, number], delay: 0.1 }}
          >
            <AnimatePresence mode="wait">
              {submitted ? (
                <motion.div
                  key="success"
                  className="text-center py-8"
                  initial={{ opacity: 0, scale: 0.9 }}
                  animate={{ opacity: 1, scale: 1 }}
                  exit={{ opacity: 0, scale: 0.9 }}
                  transition={{ duration: 0.3 }}
                >
                  <div
                    className="mx-auto rounded-full bg-[#52B788] flex items-center justify-center mb-6"
                    style={{ width: '80px', height: '80px' }}
                  >
                    <CheckCircle size={40} className="text-white" />
                  </div>
                  <h3
                    className="font-display font-semibold text-ink"
                    style={{ fontSize: 'clamp(1.5rem, 3vw, 2.5rem)' }}
                  >
                    Thank you, {form.fullName}!
                  </h3>
                  <p className="mt-3 text-lg text-slate-text">
                    Your inquiry has been prepared and sent. Here&apos;s what happens next:
                  </p>
                  <ol className="mt-6 text-left max-w-lg mx-auto space-y-3 text-slate-text">
                    <li className="flex items-start gap-3">
                      <span className="flex-shrink-0 w-6 h-6 rounded-full bg-[#2D6A4F] text-white flex items-center justify-center text-xs font-semibold">
                        1
                      </span>
                      Your email client should have opened with your inquiry pre-filled.
                    </li>
                    <li className="flex items-start gap-3">
                      <span className="flex-shrink-0 w-6 h-6 rounded-full bg-[#2D6A4F] text-white flex items-center justify-center text-xs font-semibold">
                        2
                      </span>
                      The inquiry details have been copied to your clipboard as a backup.
                    </li>
                    <li className="flex items-start gap-3">
                      <span className="flex-shrink-0 w-6 h-6 rounded-full bg-[#2D6A4F] text-white flex items-center justify-center text-xs font-semibold">
                        3
                      </span>
                      A Turtle Protect advisor will respond within 1 business day.
                    </li>
                    <li className="flex items-start gap-3">
                      <span className="flex-shrink-0 w-6 h-6 rounded-full bg-[#2D6A4F] text-white flex items-center justify-center text-xs font-semibold">
                        4
                      </span>
                      If you don&apos;t hear back, call us at (352) 428-4009.
                    </li>
                  </ol>
                  <button
                    onClick={resetForm}
                    className="mt-8 font-body font-semibold text-sm text-[#2D6A4F] border border-[#2D6A4F] px-6 py-3 rounded-lg hover:bg-[rgba(45,106,79,0.08)] transition-all duration-200"
                  >
                    Send Another Inquiry
                  </button>
                </motion.div>
              ) : (
                <motion.form
                  key="form"
                  onSubmit={handleSubmit}
                  className="space-y-5"
                  initial={{ opacity: 0 }}
                  animate={{ opacity: 1 }}
                  exit={{ opacity: 0 }}
                >
                  {/* Row 1: Full Name + Email */}
                  <div className="grid grid-cols-1 sm:grid-cols-2 gap-5">
                    <div>
                      <label className="block font-body font-medium text-sm text-ink mb-2">
                        Full Name <span className="text-[#E76F51]">*</span>
                      </label>
                      <input
                        type="text"
                        placeholder="Your full name"
                        className={`${inputBase} ${errors.fullName ? 'border-[#E76F51] ring-[3px] ring-[rgba(231,111,81,0.15)]' : ''}`}
                        value={form.fullName}
                        onChange={(e) => update('fullName', e.target.value)}
                      />
                    </div>
                    <div>
                      <label className="block font-body font-medium text-sm text-ink mb-2">
                        Email Address <span className="text-[#E76F51]">*</span>
                      </label>
                      <input
                        type="email"
                        placeholder="your@email.com"
                        className={`${inputBase} ${errors.email ? 'border-[#E76F51] ring-[3px] ring-[rgba(231,111,81,0.15)]' : ''}`}
                        value={form.email}
                        onChange={(e) => update('email', e.target.value)}
                      />
                    </div>
                  </div>

                  {/* Row 2: Phone + Preferred Contact */}
                  <div className="grid grid-cols-1 sm:grid-cols-2 gap-5">
                    <div>
                      <label className="block font-body font-medium text-sm text-ink mb-2">
                        Phone Number
                      </label>
                      <input
                        type="tel"
                        placeholder="(555) 123-4567"
                        className={inputBase}
                        value={form.phone}
                        onChange={(e) => update('phone', e.target.value)}
                      />
                    </div>
                    <div>
                      <label className="block font-body font-medium text-sm text-ink mb-2">
                        Preferred Contact <span className="text-[#E76F51]">*</span>
                      </label>
                      <div className="relative">
                        <select
                          className={`${inputBase} appearance-none pr-10 ${errors.preferredContact ? 'border-[#E76F51] ring-[3px] ring-[rgba(231,111,81,0.15)]' : ''}`}
                          value={form.preferredContact}
                          onChange={(e) => update('preferredContact', e.target.value)}
                        >
                          {PREFERRED_CONTACTS.map((opt) => (
                            <option key={opt.value} value={opt.value}>
                              {opt.label}
                            </option>
                          ))}
                        </select>
                        <ChevronDown
                          size={18}
                          className="absolute right-3 top-1/2 -translate-y-1/2 text-stone-muted pointer-events-none"
                        />
                      </div>
                    </div>
                  </div>

                  {/* Row 3: Inquiry Type */}
                  <div>
                    <label className="block font-body font-medium text-sm text-ink mb-2">
                      Inquiry Type <span className="text-[#E76F51]">*</span>
                    </label>
                    <div className="relative">
                      <select
                        className={`${inputBase} appearance-none pr-10 ${errors.inquiryType ? 'border-[#E76F51] ring-[3px] ring-[rgba(231,111,81,0.15)]' : ''}`}
                        value={form.inquiryType}
                        onChange={(e) => update('inquiryType', e.target.value)}
                      >
                        {INQUIRY_TYPES.map((opt) => (
                          <option key={opt.value} value={opt.value}>
                            {opt.label}
                          </option>
                        ))}
                      </select>
                      <ChevronDown
                        size={18}
                        className="absolute right-3 top-1/2 -translate-y-1/2 text-stone-muted pointer-events-none"
                      />
                    </div>
                  </div>

                  {/* Row 4: Message */}
                  <div>
                    <label className="block font-body font-medium text-sm text-ink mb-2">
                      Message <span className="text-[#E76F51]">*</span>
                    </label>
                    <textarea
                      rows={8}
                      placeholder="Tell us about your situation, what you're looking to protect, and any questions you have. The more detail you provide, the better we can tailor our response."
                      className={`${inputBase} min-h-[180px] resize-y ${errors.message ? 'border-[#E76F51] ring-[3px] ring-[rgba(231,111,81,0.15)]' : ''}`}
                      value={form.message}
                      onChange={(e) => update('message', e.target.value)}
                    />
                  </div>

                  {/* Submit */}
                  <button
                    type="submit"
                    className="w-full flex items-center justify-center gap-2 bg-[#2D6A4F] text-white font-body font-semibold text-base py-4 rounded-lg transition-all duration-200 hover:bg-[#1B4332] hover:scale-[1.01] hover:shadow-[0_4px_16px_rgba(45,106,79,0.3)]"
                  >
                    Send My Inquiry
                    <Send size={18} />
                  </button>
                </motion.form>
              )}
            </AnimatePresence>
          </motion.div>
        </div>
      </section>

      {/* ============================================================ */}
      {/* SECTION 3 — OTHER WAYS TO CONNECT                           */}
      {/* ============================================================ */}
      <section className="bg-white py-20 lg:py-28">
        <div className="max-w-[1200px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
          <motion.div
            ref={methodsReveal.ref}
            initial="hidden"
            animate={methodsReveal.visible ? 'visible' : 'hidden'}
            className="text-center mb-10"
            variants={staggerContainer}
          >
            <motion.span
              className="inline-block font-body font-medium text-xs uppercase tracking-[0.05em] text-[#2D6A4F] mb-3"
              variants={staggerItem}
            >
              OTHER WAYS TO REACH US
            </motion.span>
            <motion.h2
              className="font-display font-semibold text-deep-forest"
              style={{ fontSize: 'clamp(1.5rem, 3vw, 2.5rem)' }}
              variants={staggerItem}
            >
              Choose the channel that works for you
            </motion.h2>
          </motion.div>

          <motion.div
            className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-4 gap-6"
            initial="hidden"
            animate={methodsReveal.visible ? 'visible' : 'hidden'}
            variants={staggerContainer}
          >
            {CONTACT_METHODS.map((method) => (
              <motion.div
                key={method.title}
                className="bg-white border border-pearl rounded-xl shadow-card p-6 text-center hover:-translate-y-1 hover:shadow-card-hover transition-all duration-300"
                variants={staggerItem}
              >
                <div
                  className="mx-auto rounded-full bg-[rgba(45,106,79,0.08)] flex items-center justify-center mb-4"
                  style={{ width: '80px', height: '80px' }}
                >
                  <method.icon size={32} className="text-[#2D6A4F]" />
                </div>
                <h4 className="font-body font-semibold text-xl text-ink mb-1">{method.title}</h4>
                {method.href.startsWith('http') || method.href.startsWith('tel:') || method.href.startsWith('mailto:') ? (
                  <a
                    href={method.href}
                    className="block font-body font-semibold text-base text-[#2D6A4F] hover:text-[#1B4332] transition-colors"
                  >
                    {method.detail}
                  </a>
                ) : method.href === '#' ? (
                  <span className="block font-body font-semibold text-base text-[#2D6A4F]">
                    {method.detail}
                  </span>
                ) : (
                  <Link
                    to={method.href}
                    className="block font-body font-semibold text-base text-[#2D6A4F] hover:text-[#1B4332] transition-colors"
                  >
                    {method.detail}
                  </Link>
                )}
                <p className="mt-2 text-sm text-stone-muted">{method.availability}</p>
              </motion.div>
            ))}
          </motion.div>
        </div>
      </section>

      {/* ============================================================ */}
      {/* SECTION 4 — OFFICE INFORMATION                              */}
      {/* ============================================================ */}
      <section className="bg-[#F0EDE8] py-20 lg:py-28">
        <div className="max-w-[1000px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
          <motion.div
            ref={officeReveal.ref}
            initial="hidden"
            animate={officeReveal.visible ? 'visible' : 'hidden'}
            className="text-center mb-10"
            variants={staggerContainer}
          >
            <motion.span
              className="inline-block font-body font-medium text-xs uppercase tracking-[0.05em] text-[#2D6A4F] mb-3"
              variants={staggerItem}
            >
              VISIT US
            </motion.span>
            <motion.h2
              className="font-display font-semibold text-deep-forest"
              style={{ fontSize: 'clamp(1.5rem, 3vw, 2.5rem)' }}
              variants={staggerItem}
            >
              Our Florida office
            </motion.h2>
          </motion.div>

          <div className="flex flex-col lg:flex-row gap-8">
            {/* Left — Office details */}
            <motion.div
              className="lg:w-1/2"
              initial={{ opacity: 0, x: -60 }}
              animate={officeReveal.visible ? { opacity: 1, x: 0 } : {}}
              transition={{ duration: 0.7, ease: [0, 0, 0.2, 1] as [number, number, number, number], delay: 0.1 }}
            >
              <h3 className="font-body font-semibold text-2xl text-ink">Turtle Protect, Inc.</h3>
              <div className="mt-3 space-y-1 text-base text-slate-text">
                <p>Tampa, FL 33602</p>
                <p>United States</p>
              </div>
              <div className="mt-4 space-y-2">
                <a
                  href="tel:+13524284009"
                  className="flex items-center gap-2 font-mono font-medium text-[#2D6A4F] hover:text-[#1B4332] transition-colors"
                >
                  <Phone size={16} />
                  (352) 428-4009
                </a>
                <a
                  href="mailto:clement.keynote-1e@icloud.com"
                  className="flex items-center gap-2 font-mono font-medium text-[#2D6A4F] hover:text-[#1B4332] transition-colors"
                >
                  <Mail size={16} />
                  clement.keynote-1e@icloud.com
                </a>
              </div>
              <div className="mt-4 space-y-1 text-sm text-slate-text">
                <p>Monday &ndash; Friday: 8:00 AM &ndash; 6:00 PM EST</p>
                <p>Saturday: 9:00 AM &ndash; 1:00 PM EST</p>
                <p>Sunday: Closed</p>
              </div>
              <p className="mt-4 text-sm text-stone-muted">
                *Walk-ins welcome during business hours, but appointments are recommended for
                consultations.
              </p>
            </motion.div>

            {/* Right — Map placeholder */}
            <motion.div
              className="lg:w-1/2"
              initial={{ opacity: 0, x: 60 }}
              animate={officeReveal.visible ? { opacity: 1, x: 0 } : {}}
              transition={{ duration: 0.7, ease: [0, 0, 0.2, 1] as [number, number, number, number], delay: 0.2 }}
            >
              <div
                className="rounded-2xl border border-pearl flex flex-col items-center justify-center text-center"
                style={{
                  background: 'rgba(212,165,116,0.1)',
                  aspectRatio: '4/3',
                  padding: '2rem',
                }}
              >
                <MapPin size={48} className="text-[#D4A574] mb-3" />
                <p className="font-body font-medium text-base text-slate-text">Interactive Map</p>
                <p className="text-sm text-stone-muted mt-1">
                  123 Shell Boulevard, Tampa, FL 33602
                </p>
                <a
                  href="https://maps.google.com/?q=123+Shell+Boulevard,+Tampa,+FL+33602"
                  target="_blank"
                  rel="noopener noreferrer"
                  className="mt-3 font-body font-medium text-sm text-[#2D6A4F] hover:underline"
                >
                  View on Google Maps &rarr;
                </a>
              </div>
            </motion.div>
          </div>
        </div>
      </section>

      {/* ============================================================ */}
      {/* SECTION 5 — RESPONSE PROMISE                                */}
      {/* ============================================================ */}
      <section className="bg-[#2D6A4F] py-20 lg:py-28">
        <div className="max-w-[1000px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
          <motion.h2
            className="font-display font-semibold text-white text-center"
            style={{ fontSize: 'clamp(1.5rem, 3vw, 2.5rem)' }}
            ref={promiseReveal.ref}
            initial={{ opacity: 0, y: 30 }}
            animate={promiseReveal.visible ? { opacity: 1, y: 0 } : {}}
            transition={{ duration: 0.6, ease: [0, 0, 0.2, 1] as [number, number, number, number] }}
          >
            Our commitment to you
          </motion.h2>

          <motion.div
            className="mt-8 grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-4 gap-6"
            initial="hidden"
            animate={promiseReveal.visible ? 'visible' : 'hidden'}
            variants={staggerContainer}
          >
            {PROMISES.map((p) => (
              <motion.div
                key={p.title}
                className="rounded-2xl p-6"
                style={{
                  background: 'rgba(255,255,255,0.08)',
                  border: '1px solid rgba(255,255,255,0.15)',
                }}
                variants={staggerItem}
              >
                <p.icon size={40} className="text-[#D4A574] mb-3" />
                <h4 className="font-body font-semibold text-xl text-white mb-2">{p.title}</h4>
                <p className="text-base text-[rgba(255,255,255,0.7)] leading-relaxed">
                  {p.description}
                </p>
              </motion.div>
            ))}
          </motion.div>
        </div>
      </section>

      {/* ============================================================ */}
      {/* SECTION 6 — FAQ                                             */}
      {/* ============================================================ */}
      <section className="bg-[#FAF6F1] py-20 lg:py-28">
        <div className="max-w-[800px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
          <motion.div
            ref={faqReveal.ref}
            initial="hidden"
            animate={faqReveal.visible ? 'visible' : 'hidden'}
            className="text-center mb-10"
            variants={staggerContainer}
          >
            <motion.span
              className="inline-block font-body font-medium text-xs uppercase tracking-[0.05em] text-[#2D6A4F] mb-3"
              variants={staggerItem}
            >
              COMMON QUESTIONS
            </motion.span>
            <motion.h2
              className="font-display font-semibold text-deep-forest"
              style={{ fontSize: 'clamp(1.5rem, 3vw, 2.5rem)' }}
              variants={staggerItem}
            >
              Quick answers
            </motion.h2>
          </motion.div>

          <motion.div
            className="space-y-4"
            initial="hidden"
            animate={faqReveal.visible ? 'visible' : 'hidden'}
            variants={staggerContainer}
          >
            {FAQ_ITEMS.map((faq) => (
              <FAQItem key={faq.question} question={faq.question} answer={faq.answer} />
            ))}
          </motion.div>
        </div>
      </section>

      {/* ============================================================ */}
      {/* SECTION 7 — CTA BANNER                                      */}
      {/* ============================================================ */}
      <section className="gradient-hero-green py-20 lg:py-28">
        <motion.div
          className="max-w-[700px] mx-auto text-center"
          style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}
          ref={ctaReveal.ref}
          initial="hidden"
          animate={ctaReveal.visible ? 'visible' : 'hidden'}
          variants={staggerContainer}
        >
          <motion.h2
            className="font-display font-bold text-white"
            style={{ fontSize: 'clamp(2rem, 5vw, 4rem)' }}
            variants={staggerItem}
          >
            Ready to get protected?
          </motion.h2>
          <motion.p
            className="mt-4 text-lg text-[rgba(255,255,255,0.8)] leading-relaxed"
            variants={staggerItem}
          >
            Take the first step. Reach out today and discover how Turtle Protect can safeguard what
            matters most.
          </motion.p>
          <motion.div className="mt-8" variants={staggerItem}>
            <button
              onClick={scrollToForm}
              className="inline-block bg-white text-[#2D6A4F] font-body font-semibold text-base px-8 py-4 rounded-lg hover:bg-[#FAF6F1] hover:scale-[1.03] transition-all duration-200"
            >
              Start Your Inquiry
            </button>
          </motion.div>
          <motion.p
            className="mt-4 text-sm text-[rgba(255,255,255,0.6)]"
            variants={staggerItem}
          >
            Or call{' '}
            <a href="tel:+13524284009" className="text-[#D4A574] hover:text-[#E9C46A] transition-colors">
              (352) 428-4009
            </a>
          </motion.p>
        </motion.div>
      </section>
    </div>
  );
}

/* ------------------------------------------------------------------ */
/*  FAQ Item (accordion)                                               */
/* ------------------------------------------------------------------ */
function FAQItem({ question, answer }: { question: string; answer: string }) {
  const [open, setOpen] = useState(false);

  return (
    <motion.div
      className="bg-white rounded-xl border border-pearl shadow-card overflow-hidden"
      variants={staggerItem}
    >
      <button
        onClick={() => setOpen(!open)}
        className="w-full flex items-center justify-between p-5 text-left"
      >
        <span className="font-body font-semibold text-base text-ink pr-4">{question}</span>
        <ChevronDown
          size={20}
          className={`flex-shrink-0 text-stone-muted transition-transform duration-200 ${open ? 'rotate-180' : ''}`}
        />
      </button>
      <AnimatePresence initial={false}>
        {open && (
          <motion.div
            initial={{ height: 0, opacity: 0 }}
            animate={{ height: 'auto', opacity: 1 }}
            exit={{ height: 0, opacity: 0 }}
            transition={{ duration: 0.25, ease: [0.42, 0, 0.58, 1] as [number, number, number, number] }}
          >
            <div className="px-5 pb-5 text-base text-slate-text leading-relaxed">{answer}</div>
          </motion.div>
        )}
      </AnimatePresence>
    </motion.div>
  );
}
"""

let render() = file
