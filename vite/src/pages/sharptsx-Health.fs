module ConvertedFiles.Src.Pages.HealthTsx

let file = """import { useState } from 'react';
import {
  Heart, Building2, Baby, Activity, Phone, Mail,
  MessageCircle, ChevronRight, CheckCircle, Send,
  Shield, Star, Stethoscope, FileText, Lock,
  AlertTriangle, Users, Cookie, RefreshCw, Clock,
} from 'lucide-react';
import { sendPrefilledEmail } from '@/utils/emailUtils';
import healthwellness from '@/assets/health-wellness.jpg';

/* ═══════════════════════════════════════════════════════════
   HEALTH PAGE — Turtle Protect (Clean rewrite, no GSAP)
   ═══════════════════════════════════════════════════════════ */

const coverageCards = [
  {
    icon: Heart, title: 'Individual & Family Plans',
    description: 'ACA marketplace plans, short-term medical, and private health insurance options tailored to your family size, income, and health needs. Open enrollment and special enrollment period guidance included.',
    cta: 'Find a Plan',
    benefits: ['ACA marketplace & private plans', 'Open enrollment guidance', 'Family-size tailored options'],
  },
  {
    icon: Building2, title: 'Medicare Solutions',
    description: 'Medicare Advantage, Medigap (Supplement), and Part D prescription drug plans. Our advisors help you navigate the complexities of Medicare during your Initial Enrollment Period and Annual Election Period.',
    cta: 'Explore Medicare',
    benefits: ['Medicare Advantage & Medigap', 'Part D prescription plans', 'Enrollment period guidance'],
  },
  {
    icon: Baby, title: 'Dental & Vision',
    description: 'Standalone and bundled dental and vision plans. Coverage for routine care, major procedures, orthodontics, eye exams, glasses, and contact lenses.',
    cta: 'View Options',
    benefits: ['Routine & major procedure coverage', 'Orthodontics included', 'Vision & contacts covered'],
  },
  {
    icon: Activity, title: 'Wellness Programs',
    description: 'Preventive care incentives, telehealth access, mental health resources, fitness program discounts, and chronic condition management programs through our sponsored provider network.',
    cta: 'Learn More',
    benefits: ['Telehealth access', 'Mental health resources', 'Fitness discounts'],
  },
];

const inquiryOptions = [
  'Select inquiry type...',
  'Health Insurance Quote',
  'Medicare Supplement',
  'Dental & Vision',
  'Critical Illness Coverage',
  'General Question',
];

const preferredContactOptions = [
  'How should we reach you?',
  'Email',
  'Phone',
  'Either',
];

const providers = [
  { name: 'BlueCross Health Partners', desc: 'Comprehensive health plans for individuals and families. Network includes 10,000+ providers nationwide.', category: 'Health Insurance' },
  { name: 'MedicarePlus Solutions', desc: 'Specializing in Medicare Advantage and Supplement plans for seniors.', category: 'Medicare' },
  { name: 'Vitality Dental Network', desc: 'Full-spectrum dental and vision coverage with preventive care focus.', category: 'Dental & Vision' },
  { name: 'Guardian Critical Care', desc: 'Critical illness and accident protection with fast lump-sum payouts.', category: 'Critical Illness' },
  { name: 'Sunrise Wellness Group', desc: 'Integrated wellness programs combining health insurance with preventive care.', category: 'Wellness' },
  { name: 'Heritage Health Alliance', desc: 'Provider network specializing in family care and pediatric services.', category: 'Family Care' },
];

/* ────────────────── HERO ────────────────── */

function HeroSection() {
  return (
    <section
      style={{
        background: 'linear-gradient(135deg, #2A9D8F 0%, #2D6A4F 50%, #1B4332 100%)',
        minHeight: '70vh',
        paddingTop: '140px',
        paddingBottom: '4rem',
      }}
    >
      <div
        className="max-w-[1280px] mx-auto grid grid-cols-1 lg:grid-cols-5 items-center"
        style={{ padding: '0 clamp(1rem, 5vw, 3rem)', gap: '3rem' }}
      >
        <div className="lg:col-span-3" style={{ animation: 'fadeInUp 0.8s ease-out 0.1s both' }}>
          <p className="font-body font-medium text-[0.75rem] uppercase tracking-[0.15em] mb-4" style={{ color: '#D4A574' }}>
            HEALTH PROTECTION
          </p>
          <h1 className="font-display font-bold text-white" style={{ fontSize: 'clamp(2rem, 5vw, 4rem)', lineHeight: 1.1, letterSpacing: '-0.02em', textShadow: '0 2px 20px rgba(0,0,0,0.3)' }}>
            Your health. Our priority.
          </h1>
          <p className="font-body text-[1.125rem] leading-relaxed mt-5" style={{ color: 'rgba(255,255,255,0.85)', maxWidth: '560px' }}>
            From health insurance guidance to wellness program referrals, Turtle Protect connects you with the right health coverage solutions and sponsored providers who put your wellbeing first.
          </p>
          <div className="flex flex-wrap items-center" style={{ gap: '1rem', marginTop: '1.5rem' }}>
            <a href="tel:+13524284009" className="font-body font-semibold text-[0.875rem] text-white px-5 py-2.5 rounded-lg transition-all duration-200 hover:bg-[rgba(255,255,255,0.25)] flex items-center gap-2" style={{ border: '1px solid rgba(255,255,255,0.4)' }}>
              <Phone size={16} /> (352) 428-4009
            </a>
            <a href="#contact" className="font-body font-semibold text-[0.875rem] text-white px-5 py-2.5 rounded-lg transition-all duration-200 hover:bg-[rgba(255,255,255,0.25)] flex items-center gap-2" style={{ border: '1px solid rgba(255,255,255,0.4)' }}>
              <MessageCircle size={16} /> Chat Now
            </a>
          </div>
          <div style={{ marginTop: '1.5rem' }}>
            <a href="#coverage" className="inline-block font-body font-semibold text-[1rem] text-turtle-green bg-white px-8 py-3 rounded-lg transition-all duration-200 hover:bg-warm-cream hover:scale-[1.03]">
              Explore Health Options
            </a>
          </div>
        </div>

        <div className="lg:col-span-2 hidden lg:block" style={{ animation: 'fadeInRight 1s ease-out 0.3s both' }}>
          <div className="relative" style={{ transform: 'rotate(-2deg)' }}>
            <img src={healthwellness} alt="Health and wellness" className="rounded-2xl w-full h-auto object-cover" style={{ boxShadow: '0 8px 32px rgba(0,0,0,0.2)', maxHeight: '400px' }} />
            <div className="absolute bottom-4 right-4 font-body font-medium text-[0.75rem] text-white px-4 py-2 rounded-full flex items-center gap-2" style={{ background: 'rgba(255,255,255,0.15)', backdropFilter: 'blur(8px)', WebkitBackdropFilter: 'blur(8px)' }}>
              <Shield size={14} /> Sponsored Provider Network
            </div>
          </div>
        </div>
      </div>
    </section>
  );
}

/* ────────────────── COVERAGE OPTIONS ────────────────── */

function CoverageOptions() {
  return (
    <section id="coverage" className="section-warm-cream" style={{ padding: '6rem 0' }}>
      <div className="max-w-[1280px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
        <div className="text-center" style={{ marginBottom: '3rem', animation: 'fadeInUp 0.6s ease-out both' }}>
          <p className="font-body font-medium text-[0.75rem] uppercase tracking-[0.05em] text-ocean-teal mb-3">COVERAGE OPTIONS</p>
          <h2 className="font-display font-bold text-ink" style={{ fontSize: 'clamp(1.5rem, 3vw, 2.5rem)', lineHeight: 1.2, letterSpacing: '-0.01em' }}>
            Health protection for every stage of life
          </h2>
        </div>
        <div className="grid grid-cols-1 sm:grid-cols-2" style={{ gap: '1.5rem' }}>
          {coverageCards.map((card, idx) => {
            const Icon = card.icon;
            return (
              <div key={card.title} className="group bg-white border border-pearl rounded-xl p-8 transition-all duration-300 hover:-translate-y-1 hover:shadow-card-hover" style={{ borderRadius: '16px', boxShadow: '0 1px 3px rgba(0,0,0,0.04), 0 4px 12px rgba(0,0,0,0.02)', animation: `fadeInUp 0.6s ease-out ${0.1 + idx * 0.1}s both` }}>
                <div className="flex items-start gap-4">
                  <div className="flex items-center justify-center shrink-0 rounded-xl" style={{ width: '48px', height: '48px', color: '#2A9D8F', background: 'rgba(42,157,143,0.1)' }}>
                    <Icon size={28} strokeWidth={1.5} />
                  </div>
                  <div className="flex-1">
                    <h3 className="font-body font-semibold text-[1.25rem] text-ink">{card.title}</h3>
                    <p className="font-body text-[0.9375rem] text-slate-text mt-2" style={{ lineHeight: 1.6 }}>{card.description}</p>
                    <ul className="mt-3 flex flex-col" style={{ gap: '0.4rem' }}>
                      {card.benefits.map((b, i) => (
                        <li key={i} className="flex items-center gap-2"><CheckCircle size={14} className="text-ocean-teal shrink-0" /><span className="font-body text-[0.8125rem] text-slate-text">{b}</span></li>
                      ))}
                    </ul>
                    <button className="mt-4 font-body font-semibold text-[0.875rem] text-ocean-teal hover:text-turtle-green transition-colors flex items-center gap-1 group-hover:gap-2">
                      {card.cta} <ChevronRight size={16} className="transition-transform group-hover:translate-x-0.5" />
                    </button>
                  </div>
                </div>
              </div>
            );
          })}
        </div>
      </div>
    </section>
  );
}

/* ────────────────── CONTACT FORM ────────────────── */

function ContactForm() {
  const [name, setName] = useState('');
  const [email, setEmail] = useState('');
  const [phone, setPhone] = useState('');
  const [inquiryType, setInquiryType] = useState(inquiryOptions[0]);
  const [preferredContact, setPreferredContact] = useState(preferredContactOptions[0]);
  const [message, setMessage] = useState('');
  const [submitted, setSubmitted] = useState(false);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    if (!name || !email || inquiryType === inquiryOptions[0] || !message) return;
    const composedMessage = `Health Coverage Inquiry\n\nName: ${name}\nEmail: ${email}\nPhone: ${phone || 'Not provided'}\nInquiry Type: ${inquiryType}\nPreferred Contact: ${preferredContact}\n\nMessage:\n${message}`;
    await sendPrefilledEmail({ to: 'clement.keynote-1e@icloud.com', subject: `Health Inquiry from ${name}`, body: composedMessage });
    setSubmitted(true);
  };

  const resetForm = () => {
    setName(''); setEmail(''); setPhone(''); setInquiryType(inquiryOptions[0]); setPreferredContact(preferredContactOptions[0]); setMessage(''); setSubmitted(false);
  };

  return (
    <section id="contact" className="bg-white" style={{ padding: '6rem 0' }}>
      <div className="max-w-[800px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
        <div className="text-center" style={{ marginBottom: '2.5rem' }}>
          <p className="font-body font-medium text-[0.75rem] uppercase tracking-[0.05em] text-turtle-green mb-3">GET IN TOUCH</p>
          <h2 className="font-display font-bold text-ink" style={{ fontSize: 'clamp(1.5rem, 3vw, 2.5rem)', lineHeight: 1.2 }}>Request a Health Coverage Consultation</h2>
          <p className="font-body text-[1rem] text-slate-text mt-3" style={{ lineHeight: 1.6 }}>Fill out the form below and a Turtle Protect health advisor will contact you within 24 hours.</p>
        </div>

        {submitted ? (
          <div className="bg-warm-cream border border-pearl rounded-xl p-8 text-center" style={{ borderRadius: '16px' }}>
            <div className="w-16 h-16 rounded-full bg-turtle-green/10 flex items-center justify-center mx-auto mb-4">
              <CheckCircle size={32} className="text-turtle-green" />
            </div>
            <h3 className="font-body font-semibold text-[1.25rem] text-ink mb-2">Inquiry Submitted</h3>
            <p className="font-body text-[0.9375rem] text-slate-text mb-6">Your email client should open with a pre-filled message. If not, check your clipboard — we've copied the message for you.</p>
            <button onClick={resetForm} className="font-body font-semibold text-[0.875rem] text-ocean-teal hover:text-turtle-green transition-colors">Submit another inquiry</button>
          </div>
        ) : (
          <form onSubmit={handleSubmit} className="bg-warm-cream border border-pearl rounded-xl p-8" style={{ borderRadius: '16px', boxShadow: '0 1px 3px rgba(0,0,0,0.04), 0 4px 12px rgba(0,0,0,0.02)' }}>
            <div className="grid grid-cols-1 sm:grid-cols-2" style={{ gap: '1.25rem', marginBottom: '1.25rem' }}>
              <div>
                <label className="block font-body font-medium text-[0.8125rem] text-ink mb-1.5">Full Name <span className="text-soft-coral">*</span></label>
                <input type="text" value={name} onChange={e => setName(e.target.value)} required className="w-full font-body text-[0.9375rem] bg-white border border-pearl rounded-lg px-4 py-3 text-ink outline-none transition-colors focus:border-ocean-teal" style={{ borderRadius: '10px' }} placeholder="John Martinez" />
              </div>
              <div>
                <label className="block font-body font-medium text-[0.8125rem] text-ink mb-1.5">Email <span className="text-soft-coral">*</span></label>
                <input type="email" value={email} onChange={e => setEmail(e.target.value)} required className="w-full font-body text-[0.9375rem] bg-white border border-pearl rounded-lg px-4 py-3 text-ink outline-none transition-colors focus:border-ocean-teal" style={{ borderRadius: '10px' }} placeholder="john@email.com" />
              </div>
              <div>
                <label className="block font-body font-medium text-[0.8125rem] text-ink mb-1.5">Phone</label>
                <input type="tel" value={phone} onChange={e => setPhone(e.target.value)} className="w-full font-body text-[0.9375rem] bg-white border border-pearl rounded-lg px-4 py-3 text-ink outline-none transition-colors focus:border-ocean-teal" style={{ borderRadius: '10px' }} placeholder="(555) 123-4567" />
              </div>
              <div>
                <label className="block font-body font-medium text-[0.8125rem] text-ink mb-1.5">Inquiry Type <span className="text-soft-coral">*</span></label>
                <select value={inquiryType} onChange={e => setInquiryType(e.target.value)} required className="w-full font-body text-[0.9375rem] bg-white border border-pearl rounded-lg px-4 py-3 text-ink outline-none transition-colors focus:border-ocean-teal" style={{ borderRadius: '10px' }}>
                  {inquiryOptions.map(o => <option key={o} value={o}>{o}</option>)}
                </select>
              </div>
            </div>
            <div style={{ marginBottom: '1.25rem' }}>
              <label className="block font-body font-medium text-[0.8125rem] text-ink mb-1.5">Preferred Contact Method</label>
              <select value={preferredContact} onChange={e => setPreferredContact(e.target.value)} className="w-full font-body text-[0.9375rem] bg-white border border-pearl rounded-lg px-4 py-3 text-ink outline-none transition-colors focus:border-ocean-teal" style={{ borderRadius: '10px' }}>
                {preferredContactOptions.map(o => <option key={o} value={o}>{o}</option>)}
              </select>
            </div>
            <div style={{ marginBottom: '1.5rem' }}>
              <label className="block font-body font-medium text-[0.8125rem] text-ink mb-1.5">Message <span className="text-soft-coral">*</span></label>
              <textarea value={message} onChange={e => setMessage(e.target.value)} required rows={5} className="w-full font-body text-[0.9375rem] bg-white border border-pearl rounded-lg px-4 py-3 text-ink outline-none transition-colors resize-y focus:border-ocean-teal" style={{ borderRadius: '10px' }} placeholder="Tell us about your health coverage needs..." />
            </div>
            <button type="submit" className="w-full font-body font-semibold text-[1rem] text-white bg-turtle-green px-6 py-3.5 rounded-lg transition-all duration-200 hover:bg-[#3D8A6F] hover:scale-[1.01] flex items-center justify-center gap-2" style={{ borderRadius: '10px' }}>
              <Send size={18} /> Send Inquiry
            </button>
            <p className="font-body text-[0.75rem] text-stone-muted text-center mt-4">By submitting, you agree to our Terms of Service and Privacy Policy below.</p>
          </form>
        )}
      </div>
    </section>
  );
}

/* ────────────────── BUBBLE CHAT ────────────────── */

function BubbleChatSection() {
  return (
    <section className="section-warm-cream" style={{ padding: '4rem 0' }}>
      <div className="max-w-[600px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
        <div className="bg-white border border-pearl rounded-xl p-6 flex items-start gap-4" style={{ borderRadius: '16px', boxShadow: '0 1px 3px rgba(0,0,0,0.04), 0 4px 12px rgba(0,0,0,0.02)' }}>
          <div className="w-12 h-12 rounded-full flex items-center justify-center shrink-0" style={{ background: 'rgba(42,157,143,0.1)' }}>
            <MessageCircle size={22} className="text-ocean-teal" />
          </div>
          <div>
            <h3 className="font-body font-semibold text-[1.125rem] text-ink mb-1">Prefer to chat?</h3>
            <p className="font-body text-[0.9375rem] text-slate-text" style={{ lineHeight: 1.5 }}>Click the bubble in the bottom right to start a conversation with a Turtle Protect health advisor. We typically reply within minutes.</p>
          </div>
        </div>
      </div>
    </section>
  );
}

/* ────────────────── DIRECT CONTACT ────────────────── */

function DirectContact() {
  return (
    <section className="bg-white" style={{ padding: '6rem 0' }}>
      <div className="max-w-[1280px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
        <div className="text-center" style={{ marginBottom: '3rem' }}>
          <p className="font-body font-medium text-[0.75rem] uppercase tracking-[0.05em] text-turtle-green mb-3">REACH US DIRECTLY</p>
          <h2 className="font-display font-bold text-ink" style={{ fontSize: 'clamp(1.5rem, 3vw, 2.5rem)', lineHeight: 1.2 }}>We're here when you need us</h2>
        </div>

        <div className="max-w-[600px] mx-auto">
          {/* Phone card */}
          <div className="bg-gradient-hero-green rounded-xl p-8 text-center mb-6" style={{ borderRadius: '16px' }}>
            <p className="font-body font-medium text-[0.75rem] uppercase tracking-[0.1em] mb-3" style={{ color: 'rgba(255,255,255,0.7)' }}>Call us for immediate assistance</p>
            <a href="tel:+13524284009" className="font-display font-bold text-white block transition-transform hover:scale-105" style={{ fontSize: 'clamp(2rem, 5vw, 3.5rem)', lineHeight: 1.1, textShadow: '0 2px 10px rgba(0,0,0,0.3)' }}>
              (352) 428-4009
            </a>
            <p className="font-body text-[0.875rem] mt-2" style={{ color: 'rgba(255,255,255,0.7)' }}>(352) 428-4009</p>
            <div className="flex items-center justify-center gap-4 mt-4">
              <span className="font-body text-[0.75rem] px-3 py-1 rounded-full flex items-center gap-1" style={{ color: 'rgba(255,255,255,0.9)', background: 'rgba(255,255,255,0.15)' }}><Clock size={12} /> Mon-Fri 9am-6pm EST</span>
              <span className="font-body text-[0.75rem] px-3 py-1 rounded-full flex items-center gap-1" style={{ color: '#52B788', background: 'rgba(82,183,136,0.2)' }}><span className="w-1.5 h-1.5 rounded-full bg-[#52B788] inline-block mr-1" /> Available now</span>
            </div>
          </div>

          {/* Other methods */}
          <div className="grid grid-cols-1 sm:grid-cols-3" style={{ gap: '1rem' }}>
            <div className="bg-warm-cream border border-pearl rounded-xl p-5 text-center transition-all hover:shadow-card-hover" style={{ borderRadius: '12px' }}>
              <div className="w-10 h-10 rounded-full bg-turtle-green/10 flex items-center justify-center mx-auto mb-2"><Mail size={18} className="text-turtle-green" /></div>
              <p className="font-body font-semibold text-[0.875rem] text-ink">Email</p>
              <a href="mailto:clement.keynote-1e@icloud.com" className="font-body text-[0.75rem] text-ocean-teal hover:text-turtle-green transition-colors">clement.keynote-1e@icloud.com</a>
            </div>
            <div className="bg-warm-cream border border-pearl rounded-xl p-5 text-center transition-all hover:shadow-card-hover" style={{ borderRadius: '12px' }}>
              <div className="w-10 h-10 rounded-full bg-turtle-green/10 flex items-center justify-center mx-auto mb-2"><MessageCircle size={18} className="text-turtle-green" /></div>
              <p className="font-body font-semibold text-[0.875rem] text-ink">Live Chat</p>
              <p className="font-body text-[0.75rem] text-stone-muted">Click the bubble</p>
            </div>
            <div className="bg-warm-cream border border-pearl rounded-xl p-5 text-center transition-all hover:shadow-card-hover" style={{ borderRadius: '12px' }}>
              <div className="w-10 h-10 rounded-full bg-turtle-green/10 flex items-center justify-center mx-auto mb-2"><Users size={18} className="text-turtle-green" /></div>
              <p className="font-body font-semibold text-[0.875rem] text-ink">Seminars</p>
              <a href="/#/seminars" className="font-body text-[0.75rem] text-ocean-teal hover:text-turtle-green transition-colors">View upcoming dates</a>
            </div>
          </div>
        </div>
      </div>
    </section>
  );
}

/* ────────────────── PROVIDER DIRECTORY ────────────────── */

function ProviderDirectory() {
  const [filter, setFilter] = useState('All');
  const categories = ['All', 'Health Insurance', 'Medicare', 'Dental & Vision', 'Critical Illness', 'Wellness', 'Family Care'];
  const filtered = filter === 'All' ? providers : providers.filter(p => p.category === filter);

  return (
    <section className="section-warm-cream" style={{ padding: '6rem 0' }}>
      <div className="max-w-[1280px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
        <div className="text-center" style={{ marginBottom: '3rem' }}>
          <p className="font-body font-medium text-[0.75rem] uppercase tracking-[0.05em] text-turtle-green mb-3">OUR TRUSTED NETWORK</p>
          <h2 className="font-display font-bold text-ink" style={{ fontSize: 'clamp(1.5rem, 3vw, 2.5rem)', lineHeight: 1.2 }}>Sponsored Provider Directory</h2>
          <p className="font-body text-[1rem] text-slate-text mt-3 max-w-[640px] mx-auto" style={{ lineHeight: 1.6 }}>
            Turtle Protect partners with leading health coverage providers. We receive referral compensation from sponsored providers, which does not affect your pricing or our recommendations.
          </p>
        </div>

        {/* Filter tabs */}
        <div className="flex flex-wrap items-center justify-center" style={{ gap: '0.5rem', marginBottom: '2rem' }}>
          {categories.map(cat => (
            <button key={cat} onClick={() => setFilter(cat)} className="font-body font-medium text-[0.8125rem] px-4 py-2 rounded-full transition-all duration-200" style={{ borderRadius: '999px', background: filter === cat ? '#2D6A4F' : '#F0EDE8', color: filter === cat ? '#fff' : '#4A4A4A' }}>
              {cat}
            </button>
          ))}
        </div>

        {/* Provider grid */}
        <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3" style={{ gap: '1.25rem' }}>
          {filtered.map(p => (
            <div key={p.name} className="bg-white border border-pearl rounded-xl p-6 transition-all duration-200 hover:shadow-card-hover hover:-translate-y-0.5" style={{ borderRadius: '16px' }}>
              <div className="flex items-start gap-3">
                <div className="w-10 h-10 rounded-lg bg-turtle-green/10 flex items-center justify-center shrink-0"><Stethoscope size={18} className="text-turtle-green" /></div>
                <div>
                  <h3 className="font-body font-semibold text-[0.9375rem] text-ink">{p.name}</h3>
                  <span className="font-body text-[0.6875rem] text-turtle-green bg-turtle-green/10 px-2 py-0.5 rounded-full">{p.category}</span>
                </div>
              </div>
              <p className="font-body text-[0.8125rem] text-slate-text mt-3" style={{ lineHeight: 1.5 }}>{p.desc}</p>
              <button className="mt-3 font-body font-semibold text-[0.75rem] text-ocean-teal hover:text-turtle-green transition-colors flex items-center gap-1">
                Learn More <ChevronRight size={12} />
              </button>
            </div>
          ))}
        </div>

        {/* Disclosure */}
        <div className="mt-8 bg-white border border-pearl rounded-xl p-5 flex items-start gap-3" style={{ borderRadius: '12px' }}>
          <AlertTriangle size={18} className="text-soft-coral shrink-0 mt-0.5" />
          <p className="font-body text-[0.8125rem] text-slate-text" style={{ lineHeight: 1.5 }}>
            <strong className="text-ink">Sponsored Provider Disclosure:</strong> Turtle Protect receives compensation from sponsored providers listed above. This does not affect our recommendations or the price you pay. We only partner with providers who meet our quality standards. You are free to choose any provider, sponsored or not.
          </p>
        </div>
      </div>
    </section>
  );
}

/* ────────────────── TERMS OF SERVICE ────────────────── */

function TermsOfService() {
  const [open, setOpen] = useState<number | null>(null);
  const terms = [
    { title: 'Service Description', icon: FileText, content: 'Turtle Protect provides health insurance referral and brokerage services. We connect individuals and families with licensed health insurance providers and sponsored partners. We are not a licensed health insurer ourselves.' },
    { title: 'Sponsored Provider Disclosure', icon: Star, content: 'We partner with select health insurance providers and receive referral compensation when you enroll through our service. This compensation does not influence our recommendations or the price you pay. All provider information is presented transparently.' },
    { title: 'No Medical Advice', icon: Stethoscope, content: 'Information provided on this website and by our advisors is for educational and informational purposes only. It does not constitute medical advice, diagnosis, or treatment. Always consult qualified healthcare professionals for medical decisions.' },
    { title: 'Data Privacy', icon: Lock, content: 'We collect personal information necessary to provide referral services, including contact details and health coverage preferences. We follow HIPAA-aligned privacy principles. Your health information is shared only with providers you choose to contact.' },
    { title: 'Limitation of Liability', icon: AlertTriangle, content: 'Turtle Protect connects you with licensed insurance providers. Coverage decisions, policy terms, and claims handling are the responsibility of the respective insurers. We are not liable for provider actions or coverage disputes.' },
    { title: 'Referrer Guidelines', icon: Users, content: '"Supported Referrer" means providers who compensate Turtle Protect for customer referrals. All sponsored relationships are clearly disclosed. You may choose any provider regardless of their sponsored status.' },
  ];

  return (
    <section className="bg-white" style={{ padding: '6rem 0' }}>
      <div className="max-w-[800px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
        <div className="text-center" style={{ marginBottom: '2.5rem' }}>
          <p className="font-body font-medium text-[0.75rem] uppercase tracking-[0.05em] text-turtle-green mb-3">LEGAL</p>
          <h2 className="font-display font-bold text-ink" style={{ fontSize: 'clamp(1.5rem, 3vw, 2rem)', lineHeight: 1.2 }}>Terms of Service — Health Module</h2>
        </div>
        <div style={{ display: 'flex', flexDirection: 'column', gap: '0.75rem' }}>
          {terms.map((t, i) => {
            const Icon = t.icon;
            const isOpen = open === i;
            return (
              <div key={i} className="border border-pearl rounded-xl overflow-hidden" style={{ borderRadius: '12px' }}>
                <button onClick={() => setOpen(isOpen ? null : i)} className="w-full flex items-center gap-3 p-4 text-left transition-colors hover:bg-warm-cream">
                  <Icon size={18} className="text-turtle-green shrink-0" />
                  <span className="font-body font-semibold text-[0.9375rem] text-ink flex-1">{t.title}</span>
                  <ChevronRight size={16} className="text-stone-muted transition-transform" style={{ transform: isOpen ? 'rotate(90deg)' : 'rotate(0deg)' }} />
                </button>
                {isOpen && (
                  <div className="px-4 pb-4" style={{ paddingLeft: '3rem' }}>
                    <p className="font-body text-[0.875rem] text-slate-text" style={{ lineHeight: 1.6 }}>{t.content}</p>
                  </div>
                )}
              </div>
            );
          })}
        </div>
      </div>
    </section>
  );
}

/* ────────────────── PRIVACY POLICY ────────────────── */

function PrivacyPolicy() {
  const [open, setOpen] = useState<number | null>(null);
  const items = [
    { title: 'Information We Collect', icon: FileText, content: 'We collect contact information (name, email, phone), health coverage interests, demographic data, and communication preferences. We do not collect sensitive health information beyond your general coverage needs.' },
    { title: 'How We Use Your Information', icon: Users, content: 'Your information is used to connect you with appropriate health insurance providers, send relevant communications, improve our services, and comply with legal obligations.' },
    { title: 'Information Sharing', icon: Lock, content: 'We share your inquiry information with health insurance providers you express interest in. We do not sell your personal information to third parties for marketing purposes.' },
    { title: 'Sponsored Provider Data Sharing', icon: Star, content: 'When you request information about a sponsored provider, we share your contact details and inquiry specifics with that provider so they can respond to your request. This sharing is necessary to fulfill your service request.' },
    { title: 'Your Rights', icon: RefreshCw, content: 'You have the right to access, correct, or delete your personal information. Contact us at clement.keynote-1e@icloud.com to exercise these rights. We respond to all requests within 30 days.' },
    { title: 'HIPAA Notice', icon: Shield, content: 'Turtle Protect is not a "covered entity" under HIPAA. However, we follow similar privacy principles to protect your health-related information and maintain appropriate data security measures.' },
    { title: 'Cookies & Tracking', icon: Cookie, content: 'We use standard website analytics cookies to understand how visitors use our site. You can disable cookies in your browser settings. We do not use tracking cookies for advertising purposes.' },
    { title: 'Contact Our Privacy Officer', icon: Mail, content: 'For privacy-related questions or to exercise your rights, contact our Privacy Officer at clement.keynote-1e@icloud.com or call (352) 428-4009.' },
  ];

  return (
    <section className="section-warm-cream" style={{ padding: '6rem 0' }}>
      <div className="max-w-[800px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
        <div className="text-center" style={{ marginBottom: '2.5rem' }}>
          <p className="font-body font-medium text-[0.75rem] uppercase tracking-[0.05em] text-turtle-green mb-3">LEGAL</p>
          <h2 className="font-display font-bold text-ink" style={{ fontSize: 'clamp(1.5rem, 3vw, 2rem)', lineHeight: 1.2 }}>Privacy Policy — Health Module</h2>
        </div>
        <div style={{ display: 'flex', flexDirection: 'column', gap: '0.75rem' }}>
          {items.map((item, i) => {
            const Icon = item.icon;
            const isOpen = open === i;
            return (
              <div key={i} className="bg-white border border-pearl rounded-xl overflow-hidden" style={{ borderRadius: '12px' }}>
                <button onClick={() => setOpen(isOpen ? null : i)} className="w-full flex items-center gap-3 p-4 text-left transition-colors hover:bg-warm-cream">
                  <Icon size={18} className="text-ocean-teal shrink-0" />
                  <span className="font-body font-semibold text-[0.9375rem] text-ink flex-1">{item.title}</span>
                  <ChevronRight size={16} className="text-stone-muted transition-transform" style={{ transform: isOpen ? 'rotate(90deg)' : 'rotate(0deg)' }} />
                </button>
                {isOpen && (
                  <div className="px-4 pb-4" style={{ paddingLeft: '3rem' }}>
                    <p className="font-body text-[0.875rem] text-slate-text" style={{ lineHeight: 1.6 }}>{item.content}</p>
                  </div>
                )}
              </div>
            );
          })}
        </div>
      </div>
    </section>
  );
}

/* ────────────────── CTA BANNER ────────────────── */

function CTABanner() {
  return (
    <section className="gradient-hero-green" style={{ padding: '5rem 0', position: 'relative', overflow: 'hidden' }}>
      <div className="absolute inset-0 pointer-events-none" style={{ opacity: 0.05 }}>
        <svg width="100%" height="100%" xmlns="http://www.w3.org/2000/svg">
          <defs>
            <pattern id="healthPattern2" x="0" y="0" width="60" height="60" patternUnits="userSpaceOnUse">
              <circle cx="30" cy="30" r="15" fill="none" stroke="#fff" strokeWidth="1" />
              <circle cx="30" cy="30" r="8" fill="none" stroke="#fff" strokeWidth="0.5" />
            </pattern>
          </defs>
          <rect width="100%" height="100%" fill="url(#healthPattern2)" />
        </svg>
      </div>
      <div className="relative z-10 max-w-[800px] mx-auto text-center" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
        <h2 className="font-display font-bold text-white" style={{ fontSize: 'clamp(2rem, 5vw, 4rem)', lineHeight: 1.1, letterSpacing: '-0.02em' }}>
          Your health can&apos;t wait.
        </h2>
        <p className="font-body text-[1.125rem] mt-4" style={{ color: 'rgba(255,255,255,0.85)', lineHeight: 1.7 }}>
          Get connected with the right health coverage today. Our advisors and sponsored provider network are ready to help.
        </p>
        <div className="flex flex-wrap items-center justify-center" style={{ gap: '1rem', marginTop: '2rem' }}>
          <a href="#contact" className="font-body font-semibold text-turtle-green bg-white px-8 py-4 rounded-lg transition-all duration-200 hover:bg-warm-cream hover:scale-[1.03]" style={{ fontSize: '1rem' }}>
            Contact a Health Advisor
          </a>
          <a href="tel:+13524284009" className="font-body font-semibold text-white px-8 py-4 rounded-lg transition-all duration-200 hover:bg-[rgba(255,255,255,0.25)] flex items-center gap-2" style={{ border: '1px solid rgba(255,255,255,0.5)', fontSize: '1rem' }}>
            <Phone size={18} /> Call (352) 428-4009
          </a>
        </div>
        <p className="font-body text-[0.75rem] mt-6" style={{ color: 'rgba(255,255,255,0.5)' }}>
          *Turtle Protect is not a licensed health insurer. We provide referral and information services only.
        </p>
      </div>
    </section>
  );
}

/* ═══════════════════════ EXPORT ═══════════════════════ */

export default function Health() {
  return (
    <div>
      <HeroSection />
      <CoverageOptions />
      <ContactForm />
      <BubbleChatSection />
      <DirectContact />
      <ProviderDirectory />
      <TermsOfService />
      <PrivacyPolicy />
      <CTABanner />
    </div>
  );
}
"""

let render() = file
