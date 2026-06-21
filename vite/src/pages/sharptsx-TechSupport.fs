module ConvertedFiles.Src.Pages.TechSupportTsx

let file = """import { useState, useRef } from 'react';
import { motion, AnimatePresence, useInView } from 'framer-motion';
import {
  Search,
  BookOpen,
  FileText,
  Video,
  Phone,
  Mail,
  MessageCircle,
  Check,
  ChevronRight,
  Send,
  Clock,
  User,
  AtSign,
  List,
  AlignLeft,
  Flag,
} from 'lucide-react';
import {
  Accordion,
  AccordionContent,
  AccordionItem,
  AccordionTrigger,
} from '@/components/ui/accordion';
import { Input } from '@/components/ui/input';
import { Textarea } from '@/components/ui/textarea';
import { cn } from '@/lib/utils';
import supportteam from '@/assets/support-team.jpg';

/* ------------------------------------------------------------------ */
/*  Data                                                               */
/* ------------------------------------------------------------------ */

const faqs = [
  {
    q: 'How do I access my insurance dashboard?',
    a: "Log in with your User ID on the Login page. Once authenticated, you'll see your personalized dashboard with your policy details, cash value charts, and coverage information.",
    category: 'Account & Login',
  },
  {
    q: 'What do I do if I forgot my User ID?',
    a: "Contact our support team at (352) 428-4009 or email clement.keynote-1e@icloud.com. We'll verify your identity and help you recover access.",
    category: 'Account & Login',
  },
  {
    q: 'How accurate is the dashboard information?',
    a: 'All dashboard values are example projections based on typical policy performance. Your actual policy values may vary. Contact your agent for exact figures.',
    category: 'Dashboard',
  },
  {
    q: 'Can I change my protection plan online?',
    a: 'Currently, plan changes require speaking with a licensed agent. Call (352) 428-4009 or use the contact form to request changes.',
    category: 'Payments',
  },
  {
    q: 'Is my personal information secure?',
    a: 'Absolutely. We use industry-standard encryption and security practices. Your data is never sold to third parties. See our Privacy Policy for details.',
    category: 'Account & Login',
  },
  {
    q: 'How do I update my beneficiary information?',
    a: 'Beneficiary changes must be processed through your agent. This ensures proper documentation and legal compliance.',
    category: 'Account & Login',
  },
  {
    q: 'What browsers are supported?',
    a: 'Turtle Protect supports the latest versions of Chrome, Firefox, Safari, and Edge. For the best experience, keep your browser updated.',
    category: 'Technical',
  },
  {
    q: 'How do I report a technical issue?',
    a: 'Use the support ticket form below, or call our tech support line at (352) 428-4009 ext. 2.',
    category: 'Technical',
  },
];

const categories = ['All', 'Account & Login', 'Dashboard', 'Payments', 'Technical'];

const resources = [
  {
    icon: BookOpen,
    title: 'User Guide',
    description:
      'Learn how to navigate your dashboard, understand your policy values, and make the most of Turtle Protect.',
    link: '#',
  },
  {
    icon: Video,
    title: 'Video Tutorials',
    description:
      'Step-by-step video walkthroughs of dashboard features, account management, and more.',
    link: '#',
  },
  {
    icon: FileText,
    title: 'Community Forum',
    description:
      'Connect with other users, ask questions, and share tips about identity protection and financial planning.',
    link: '#',
  },
];

/* ------------------------------------------------------------------ */
/*  Animations                                                         */
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

/* ------------------------------------------------------------------ */
/*  In-view wrapper                                                    */
/* ------------------------------------------------------------------ */

function FadeInSection({ children, className, delay = 0 }: { children: React.ReactNode; className?: string; delay?: number }) {
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
/*  Ticket Form                                                        */
/* ------------------------------------------------------------------ */

function TicketForm() {
  const [form, setForm] = useState({
    name: '',
    email: '',
    category: '',
    description: '',
    priority: 'Medium',
  });
  const [submitted, setSubmitted] = useState(false);
  const [ticketNum, setTicketNum] = useState('');

  const handleChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement | HTMLSelectElement>,
  ) => {
    setForm((prev) => ({ ...prev, [e.target.name]: e.target.value }));
  };

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    const num = `TP-2025-${String(Math.floor(1000 + Math.random() * 9000))}`;
    setTicketNum(num);
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
          Ticket Submitted Successfully
        </h3>
        <p className="text-[#4A4A4A] mb-4">
          Your support ticket <span className="font-mono font-semibold text-[#2D6A4F]">{ticketNum}</span> has been received.
        </p>
        <p className="text-[#8A8A8A] text-sm">
          Our tech team typically responds within 4 business hours.
        </p>
        <button
          onClick={() => {
            setSubmitted(false);
            setForm({ name: '', email: '', category: '', description: '', priority: 'Medium' });
          }}
          className="mt-6 font-body font-semibold text-[0.875rem] text-white bg-[#2D6A4F] px-6 py-2.5 rounded-lg transition-all duration-200 hover:bg-[#1B4332] hover:scale-[1.03]"
        >
          Submit Another Ticket
        </button>
      </motion.div>
    );
  }

  return (
    <form onSubmit={handleSubmit} className="bg-white rounded-2xl p-8 md:p-10 shadow-card">
      <div className="space-y-5">
        <div>
          <label className="flex items-center gap-1.5 text-sm font-medium text-[#1A1A1A] mb-1.5">
            <User className="w-4 h-4 text-[#8A8A8A]" /> Name
          </label>
          <Input
            name="name"
            placeholder="Full name"
            required
            value={form.name}
            onChange={handleChange}
          />
        </div>
        <div>
          <label className="flex items-center gap-1.5 text-sm font-medium text-[#1A1A1A] mb-1.5">
            <AtSign className="w-4 h-4 text-[#8A8A8A]" /> Email
          </label>
          <Input
            name="email"
            type="email"
            placeholder="your@email.com"
            required
            value={form.email}
            onChange={handleChange}
          />
        </div>
        <div className="grid grid-cols-1 sm:grid-cols-2 gap-4">
          <div>
            <label className="flex items-center gap-1.5 text-sm font-medium text-[#1A1A1A] mb-1.5">
              <List className="w-4 h-4 text-[#8A8A8A]" /> Issue Category
            </label>
            <select
              name="category"
              required
              value={form.category}
              onChange={handleChange}
              className="w-full h-9 rounded-md border border-[hsl(var(--input))] bg-transparent px-3 py-1 text-sm shadow-xs transition-[color,box-shadow] outline-none focus-visible:ring-[3px] focus-visible:ring-ring/50"
            >
              <option value="">Select category...</option>
              <option>Account Access</option>
              <option>Dashboard Problem</option>
              <option>Billing Question</option>
              <option>Technical Bug</option>
              <option>Other</option>
            </select>
          </div>
          <div>
            <label className="flex items-center gap-1.5 text-sm font-medium text-[#1A1A1A] mb-1.5">
              <Flag className="w-4 h-4 text-[#8A8A8A]" /> Priority
            </label>
            <select
              name="priority"
              value={form.priority}
              onChange={handleChange}
              className="w-full h-9 rounded-md border border-[hsl(var(--input))] bg-transparent px-3 py-1 text-sm shadow-xs transition-[color,box-shadow] outline-none focus-visible:ring-[3px] focus-visible:ring-ring/50"
            >
              <option>Low</option>
              <option>Medium</option>
              <option>High</option>
            </select>
          </div>
        </div>
        <div>
          <label className="flex items-center gap-1.5 text-sm font-medium text-[#1A1A1A] mb-1.5">
            <AlignLeft className="w-4 h-4 text-[#8A8A8A]" /> Description
          </label>
          <Textarea
            name="description"
            placeholder="Please describe your issue in detail. Include any error messages, steps to reproduce, and what you expected to happen."
            rows={6}
            required
            value={form.description}
            onChange={handleChange}
          />
        </div>
        <button
          type="submit"
          className="w-full font-body font-semibold text-[0.875rem] text-white bg-[#2D6A4F] px-6 py-3 rounded-lg transition-all duration-200 hover:bg-[#1B4332] hover:scale-[1.02] flex items-center justify-center gap-2"
        >
          <Send className="w-4 h-4" /> Submit Ticket
        </button>
      </div>
    </form>
  );
}

/* ------------------------------------------------------------------ */
/*  System Status                                                      */
/* ------------------------------------------------------------------ */

function SystemStatus() {
  const services = [
    { name: 'Website', status: 'Operational' },
    { name: 'Dashboard', status: 'Operational' },
    { name: 'Authentication', status: 'Operational' },
    { name: 'Email Services', status: 'Operational' },
  ];

  return (
    <motion.div
      initial={{ opacity: 0, y: -20 }}
      animate={{ opacity: 1, y: 0 }}
      transition={{ duration: 0.5, delay: 0.3 }}
      className="bg-white rounded-xl border-l-4 border-l-[#52B788] p-4 md:p-6 shadow-card max-w-[800px] mx-auto"
    >
      <div className="flex items-center justify-between flex-wrap gap-4">
        <div className="flex items-center gap-3">
          <span className="relative flex h-3 w-3">
            <span className="animate-ping absolute inline-flex h-full w-full rounded-full bg-[#52B788] opacity-75" />
            <span className="relative inline-flex rounded-full h-3 w-3 bg-[#52B788]" />
          </span>
          <span className="font-body font-semibold text-[0.9375rem] text-[#1A1A1A]">
            All systems operational
          </span>
        </div>
        <span className="text-[#8A8A8A] text-xs">
          Last checked: Just now
        </span>
      </div>
      <div className="mt-4 flex flex-wrap gap-x-6 gap-y-2">
        {services.map((s) => (
          <div key={s.name} className="flex items-center gap-2 text-sm text-[#4A4A4A]">
            <Check className="w-3.5 h-3.5 text-[#52B788]" />
            {s.name}: <span className="font-medium text-[#2D6A4F]">{s.status}</span>
          </div>
        ))}
      </div>
    </motion.div>
  );
}

/* ------------------------------------------------------------------ */
/*  Main Page                                                          */
/* ------------------------------------------------------------------ */

export default function TechSupport() {
  const [activeCategory, setActiveCategory] = useState('All');
  const [search, setSearch] = useState('');

  const filteredFaqs = faqs.filter((faq) => {
    const matchesCategory = activeCategory === 'All' || faq.category === activeCategory;
    const matchesSearch =
      search === '' ||
      faq.q.toLowerCase().includes(search.toLowerCase()) ||
      faq.a.toLowerCase().includes(search.toLowerCase());
    return matchesCategory && matchesSearch;
  });

  return (
    <div className="min-h-screen">
      {/* ========== HERO ========== */}
      <section
        className="relative min-h-[50vh] flex items-center justify-center overflow-hidden"
        style={{
          backgroundImage: `url(${supportteam})`,
          backgroundSize: 'cover',
          backgroundPosition: 'center',
        }}
      >
        <div className="absolute inset-0 bg-gradient-to-br from-[#457B9D] via-[#2A9D8F] to-[#2D6A4F] opacity-90" />
        <div className="relative z-10 max-w-[1280px] mx-auto px-4 sm:px-6 lg:px-8 py-24 text-center">
          <motion.span
            initial={{ opacity: 0, y: 20 }}
            animate={{ opacity: 1, y: 0 }}
            transition={{ duration: 0.5 }}
            className="inline-block text-xs font-body font-medium uppercase tracking-[0.05em] text-[#D4A574] mb-4"
          >
            Technical Support Center
          </motion.span>
          <motion.h1
            initial={{ opacity: 0, y: 30 }}
            animate={{ opacity: 1, y: 0 }}
            transition={{ duration: 0.6, delay: 0.1 }}
            className="font-display text-4xl md:text-5xl lg:text-6xl font-bold text-white mb-6"
            style={{ lineHeight: 1.1 }}
          >
            Technical Support Center
          </motion.h1>
          <motion.p
            initial={{ opacity: 0, y: 20 }}
            animate={{ opacity: 1, y: 0 }}
            transition={{ duration: 0.6, delay: 0.2 }}
            className="text-lg md:text-xl text-white/80 max-w-[600px] mx-auto mb-10"
            style={{ lineHeight: 1.7 }}
          >
            We&apos;re here to help with your account, dashboard, and protection plans
          </motion.p>
          <motion.div
            initial={{ opacity: 0, y: 20 }}
            animate={{ opacity: 1, y: 0 }}
            transition={{ duration: 0.6, delay: 0.3 }}
            className="relative max-w-[600px] mx-auto"
          >
            <Search className="absolute left-4 top-1/2 -translate-y-1/2 w-5 h-5 text-white/50 pointer-events-none" />
            <input
              type="text"
              placeholder="Search for help (e.g., 'login', 'dashboard', 'password')..."
              value={search}
              onChange={(e) => setSearch(e.target.value)}
              className="w-full rounded-xl border border-white/30 bg-white/15 text-white placeholder:text-white/50 px-12 py-3.5 outline-none transition-all duration-200 focus:bg-white/25 focus:border-white/50"
            />
          </motion.div>
          <motion.div
            initial={{ opacity: 0 }}
            animate={{ opacity: 1 }}
            transition={{ duration: 0.5, delay: 0.4 }}
            className="flex flex-wrap items-center justify-center gap-2 mt-6"
          >
            {['Account Issues', 'Dashboard Help', 'Password Reset', 'Contact Support'].map(
              (label) => (
                <button
                  key={label}
                  onClick={() => setSearch(label.toLowerCase().replace(' issues', '').replace(' help', ''))}
                  className="px-4 py-1.5 rounded-full border border-white/30 text-white/80 text-sm font-body transition-all duration-200 hover:bg-white/10 hover:border-white/50"
                >
                  {label}
                </button>
              ),
            )}
          </motion.div>
        </div>
      </section>

      {/* ========== SYSTEM STATUS ========== */}
      <section className="bg-[#FAF6F1] py-10 px-4 sm:px-6 lg:px-8">
        <SystemStatus />
      </section>

      {/* ========== FAQ ACCORDION ========== */}
      <section className="bg-white py-16 md:py-24 px-4 sm:px-6 lg:px-8">
        <div className="max-w-[900px] mx-auto">
          <FadeInSection className="text-center mb-10">
            <span className="text-xs font-body font-medium uppercase tracking-[0.05em] text-[#457B9D] mb-3 block">
              Knowledge Base
            </span>
            <h2 className="font-display text-3xl md:text-4xl font-semibold text-[#1A1A1A]" style={{ lineHeight: 1.2 }}>
              Frequently asked questions
            </h2>
          </FadeInSection>

          {/* Category tabs */}
          <FadeInSection delay={0.1} className="flex flex-wrap items-center justify-center gap-2 mb-10">
            {categories.map((cat) => (
              <button
                key={cat}
                onClick={() => setActiveCategory(cat)}
                className={cn(
                  'px-4 py-2 rounded-lg text-sm font-body font-medium transition-all duration-200',
                  activeCategory === cat
                    ? 'bg-[#457B9D] text-white'
                    : 'bg-transparent border border-[#F0EDE8] text-[#4A4A4A] hover:border-[#457B9D] hover:text-[#457B9D]',
                )}
              >
                {cat}
              </button>
            ))}
          </FadeInSection>

          {search && (
            <p className="text-sm text-[#8A8A8A] text-center mb-4">
              {filteredFaqs.length} result{filteredFaqs.length !== 1 ? 's' : ''} found
            </p>
          )}

          <motion.div
            variants={staggerContainer}
            initial="hidden"
            whileInView="visible"
            viewport={{ once: true, margin: '-80px' }}
          >
            <Accordion type="single" collapsible className="w-full">
              <AnimatePresence mode="wait">
                {filteredFaqs.map((faq, i) => (
                  <motion.div
                    key={faq.q}
                    variants={staggerItem}
                    initial={{ opacity: 0, y: 20 }}
                    animate={{ opacity: 1, y: 0 }}
                    exit={{ opacity: 0, y: -10 }}
                    transition={{ delay: i * 0.04 }}
                  >
                    <AccordionItem
                      value={`item-${i}`}
                      className="border-b border-[#F0EDE8] data-[state=open]:border-l-[3px] data-[state=open]:border-l-[#457B9D] pl-0 data-[state=open]:pl-4 transition-all duration-200"
                    >
                      <AccordionTrigger className="text-left text-[#1A1A1A] font-medium hover:no-underline py-5">
                        {faq.q}
                      </AccordionTrigger>
                      <AccordionContent className="text-[#4A4A4A] leading-relaxed pr-4">
                        {faq.a}
                      </AccordionContent>
                    </AccordionItem>
                  </motion.div>
                ))}
              </AnimatePresence>
            </Accordion>
            {filteredFaqs.length === 0 && (
              <p className="text-center text-[#8A8A8A] py-10">
                No questions match your search. Try different keywords or browse all categories.
              </p>
            )}
          </motion.div>
        </div>
      </section>

      {/* ========== SUPPORT TICKET FORM ========== */}
      <section className="bg-[#F0EDE8] py-16 md:py-24 px-4 sm:px-6 lg:px-8">
        <div className="max-w-[700px] mx-auto">
          <FadeInSection className="text-center mb-10">
            <span className="text-xs font-body font-medium uppercase tracking-[0.05em] text-[#2D6A4F] mb-3 block">
              Contact Support
            </span>
            <h2 className="font-display text-3xl md:text-4xl font-semibold text-[#1A1A1A]" style={{ lineHeight: 1.2 }}>
              Still need help? Send us a ticket
            </h2>
          </FadeInSection>
          <FadeInSection delay={0.15}>
            <TicketForm />
          </FadeInSection>
        </div>
      </section>

      {/* ========== RESOURCES ========== */}
      <section className="bg-[#FAF6F1] py-16 md:py-24 px-4 sm:px-6 lg:px-8">
        <div className="max-w-[1000px] mx-auto">
          <FadeInSection className="text-center mb-12">
            <span className="text-xs font-body font-medium uppercase tracking-[0.05em] text-[#2D6A4F] mb-3 block">
              Resources
            </span>
            <h2 className="font-display text-3xl md:text-4xl font-semibold text-[#1A1A1A]" style={{ lineHeight: 1.2 }}>
              Helpful guides and tools
            </h2>
          </FadeInSection>
          <motion.div
            variants={staggerContainer}
            initial="hidden"
            whileInView="visible"
            viewport={{ once: true, margin: '-80px' }}
            className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-6"
          >
            {resources.map((r) => (
              <motion.div
                key={r.title}
                variants={staggerItem}
                className="bg-white rounded-2xl p-8 shadow-card border border-[#F0EDE8] transition-all duration-300 hover:-translate-y-1 hover:shadow-card-hover group"
              >
                <div className="w-12 h-12 rounded-xl bg-[#457B9D]/10 flex items-center justify-center mb-5">
                  <r.icon className="w-6 h-6 text-[#457B9D]" />
                </div>
                <h3 className="font-body font-semibold text-xl text-[#1A1A1A] mb-3">{r.title}</h3>
                <p className="text-[#4A4A4A] text-sm leading-relaxed mb-5">{r.description}</p>
                <span className="inline-flex items-center gap-1 text-sm font-medium text-[#2D6A4F] group-hover:underline">
                  View Resource <ChevronRight className="w-4 h-4" />
                </span>
              </motion.div>
            ))}
          </motion.div>
        </div>
      </section>

      {/* ========== CONTACT INFO ========== */}
      <section className="bg-[#1B4332] py-16 md:py-20 px-4 sm:px-6 lg:px-8">
        <div className="max-w-[800px] mx-auto text-center">
          <FadeInSection>
            <h2 className="font-display text-3xl md:text-4xl font-semibold text-white mb-10" style={{ lineHeight: 1.2 }}>
              Still need help?
            </h2>
          </FadeInSection>
          <motion.div
            variants={staggerContainer}
            initial="hidden"
            whileInView="visible"
            viewport={{ once: true, margin: '-80px' }}
            className="grid grid-cols-1 sm:grid-cols-3 gap-8"
          >
            {[
              {
                icon: Phone,
                label: '(352) 428-4009',
                sub: 'Mon-Fri, 8am-6pm EST',
                color: 'text-[#D4A574]',
              },
              {
                icon: Mail,
                label: 'clement.keynote-1e@icloud.com',
                sub: 'Mail Turtle (delivers fast)',
                color: 'text-[#D4A574]',
              },
              {
                icon: MessageCircle,
                label: 'Live Chat',
                sub: 'Click the chat bubble',
                color: 'text-[#D4A574]',
              },
            ].map((c) => (
              <motion.div key={c.label} variants={staggerItem} className="flex flex-col items-center">
                <c.icon className={cn('w-6 h-6 mb-3', c.color)} />
                <span className="font-mono font-medium text-[#D4A574] text-sm">{c.label}</span>
                <span className="text-white/50 text-xs mt-1">{c.sub}</span>
              </motion.div>
            ))}
          </motion.div>
          <div className="mt-10 pt-8 border-t border-white/10 flex flex-wrap items-center justify-center gap-x-8 gap-y-2 text-xs text-white/40">
            <span className="flex items-center gap-1.5">
              <Phone className="w-3 h-3" /> Immediate (during hours)
            </span>
            <span className="flex items-center gap-1.5">
              <Mail className="w-3 h-3" /> Within 4 business hours
            </span>
            <span className="flex items-center gap-1.5">
              <Clock className="w-3 h-3" /> Chat: Within 15 minutes
            </span>
          </div>
        </div>
      </section>
    </div>
  );
}
"""

let render() = file
