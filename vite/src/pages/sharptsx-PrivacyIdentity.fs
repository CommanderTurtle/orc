module Imported.Src.Pages.PrivacyIdentityTsx

let file = """import { Link } from 'react-router-dom';
import {
  Shield, Lock, Eye, Fingerprint, CreditCard, Wifi,
  AlertTriangle, CheckCircle, UserCheck, Phone,
} from 'lucide-react';

/* ═══════════════════════════════════════════════════════════
   PRIVACY & IDENTITY PROTECTION
   Tucked-away page — accessible via links, not in navbar
   ═══════════════════════════════════════════════════════════ */

const protectionSteps = [
  { icon: Lock, title: 'Credit Monitoring', desc: 'Continuous monitoring of your credit reports across all three bureaus (Experian, Equifax, TransUnion). Alerts for new accounts, hard inquiries, and score changes.' },
  { icon: Eye, title: 'Dark Web Surveillance', desc: 'Scans dark web markets and forums for your personal information — SSN, email, passwords, bank accounts. Immediate alerts if your data is found.' },
  { icon: Fingerprint, title: 'Identity Restoration', desc: 'If your identity is stolen, a dedicated recovery specialist handles everything — filing police reports, contacting creditors, disputing fraudulent charges.' },
  { icon: CreditCard, title: 'Financial Fraud Protection', desc: 'Monitors bank accounts and credit cards for suspicious transactions. Covers up to $1 million in stolen funds reimbursement with most plans.' },
  { icon: Wifi, title: 'Digital Privacy Tools', desc: 'VPN for secure browsing, password manager, antivirus software, and social media privacy scan to limit exposed personal information.' },
  { icon: Shield, title: 'Family Coverage', desc: 'Protect your entire household — spouse, children, and elderly parents. Kids are 35x more likely to have their identity stolen than adults.' },
];

const warningSigns = [
  'Unfamiliar accounts on your credit report',
  'Bills or collection notices for services you never used',
  'IRS notice about a tax return you did not file',
  'Medical bills for treatments you never received',
  'Calls from debt collectors about unknown debts',
  'Bank statements showing withdrawals you did not make',
];

export default function PrivacyIdentity() {
  return (
    <div>
      {/* Hero */}
      <section style={{ background: 'linear-gradient(135deg, #1B4332 0%, #2D6A4F 50%, #1A3A4B 100%)', padding: '140px 0 5rem' }}>
        <div className="max-w-[1280px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
          <p className="font-body font-medium text-[0.75rem] uppercase tracking-[0.15em] mb-4" style={{ color: '#D4A574' }}>PROTECTION SERVICES</p>
          <h1 className="font-display font-bold text-white" style={{ fontSize: 'clamp(2rem, 5vw, 3.5rem)', lineHeight: 1.1, letterSpacing: '-0.02em', textShadow: '0 2px 20px rgba(0,0,0,0.3)' }}>
            Protect Your Privacy. Protect Your Identity.
          </h1>
          <p className="font-body text-[1.125rem] mt-4" style={{ color: 'rgba(255,255,255,0.8)', maxWidth: '640px', lineHeight: 1.6 }}>
            Identity theft affects 1 in 20 Americans every year. Florida ranks among the top 5 states for identity theft complaints. Turtle Protect partners with leading identity protection services to keep you and your family safe.
          </p>
        </div>
      </section>

      {/* Stats */}
      <section className="section-warm-cream" style={{ padding: '4rem 0' }}>
        <div className="max-w-[1280px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
          <div className="grid grid-cols-2 lg:grid-cols-4 gap-6">
            {[
              { value: '47%', label: 'Increase in ID theft since 2020' },
              { value: '$5.8B', label: 'Lost to fraud in 2023 (FTC)' },
              { value: '1 in 20', label: 'Americans affected annually' },
              { value: '600+ hrs', label: 'Average recovery time' },
            ].map((stat) => (
              <div key={stat.label} className="text-center">
                <p className="font-mono font-bold text-[2rem] text-turtle-green">{stat.value}</p>
                <p className="font-body text-[0.8125rem] text-[#8A8A8A] mt-1">{stat.label}</p>
              </div>
            ))}
          </div>
        </div>
      </section>

      {/* Protection Steps */}
      <section className="bg-white" style={{ padding: '5rem 0' }}>
        <div className="max-w-[1280px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
          <div className="text-center mb-12">
            <p className="font-body font-medium text-[0.75rem] uppercase tracking-[0.05em] text-turtle-green mb-3">COMPREHENSIVE COVERAGE</p>
            <h2 className="font-display font-bold text-[#1A1A1A]" style={{ fontSize: 'clamp(1.5rem, 3vw, 2rem)' }}>Six Layers of Identity Protection</h2>
          </div>
          <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-6">
            {protectionSteps.map((item) => (
              <div key={item.title} className="bg-warm-cream border border-pearl rounded-xl p-6 transition-all hover:shadow-card-hover hover:-translate-y-0.5" style={{ borderRadius: '16px' }}>
                <div className="w-12 h-12 rounded-xl bg-turtle-green/10 flex items-center justify-center mb-4"><item.icon size={24} className="text-turtle-green" /></div>
                <h3 className="font-body font-semibold text-[1rem] text-[#1A1A1A] mb-2">{item.title}</h3>
                <p className="font-body text-[0.875rem] text-[#4A4A4A]" style={{ lineHeight: 1.6 }}>{item.desc}</p>
              </div>
            ))}
          </div>
        </div>
      </section>

      {/* Warning Signs */}
      <section className="section-warm-cream" style={{ padding: '5rem 0' }}>
        <div className="max-w-[800px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
          <div className="bg-white border border-[#E07A5F]/30 rounded-xl p-8" style={{ borderRadius: '16px' }}>
            <div className="flex items-center gap-3 mb-6">
              <div className="w-10 h-10 rounded-full bg-[#E07A5F]/10 flex items-center justify-center"><AlertTriangle size={20} className="text-soft-coral" /></div>
              <h2 className="font-display font-bold text-[#1A1A1A] text-[1.25rem]">Warning Signs of Identity Theft</h2>
            </div>
            <div className="grid grid-cols-1 sm:grid-cols-2 gap-3">
              {warningSigns.map((sign) => (
                <div key={sign} className="flex items-start gap-2">
                  <CheckCircle size={14} className="text-soft-coral shrink-0 mt-0.5" />
                  <span className="font-body text-[0.8125rem] text-[#4A4A4A]" style={{ lineHeight: 1.5 }}>{sign}</span>
                </div>
              ))}
            </div>
            <p className="font-body text-[0.8125rem] text-[#8A8A8A] mt-6 pt-4 border-t border-pearl">
              If you notice any of these signs, act immediately. Contact your bank, credit bureaus, and file a report at <a href="https://identitytheft.gov" target="_blank" rel="noopener noreferrer" className="text-turtle-green hover:underline">IdentityTheft.gov</a>.
            </p>
          </div>
        </div>
      </section>

      {/* Seminar CTA */}
      <section className="bg-white" style={{ padding: '4rem 0' }}>
        <div className="max-w-[800px] mx-auto text-center" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
          <UserCheck size={32} className="text-turtle-green mx-auto mb-4" />
          <h2 className="font-display font-bold text-[#1A1A1A]" style={{ fontSize: 'clamp(1.5rem, 3vw, 2rem)' }}>Attend Our Identity Protection Seminar</h2>
          <p className="font-body text-[1rem] text-[#4A4A4A] mt-3" style={{ lineHeight: 1.6 }}>Learn practical strategies to safeguard your personal information in the digital age. Free 2-hour workshop covering credit monitoring, fraud prevention, password security, and responding to identity theft.</p>
          <div className="flex flex-wrap items-center justify-center gap-4 mt-6">
            <Link to="/seminars" className="font-body font-semibold text-[0.9375rem] text-white px-8 py-3.5 rounded-lg transition-all hover:scale-105" style={{ background: 'linear-gradient(135deg, #2D6A4F, #3D8A6F)', boxShadow: '0 4px 16px rgba(45,106,79,0.4)' }}>View Seminar Schedule</Link>
            <a href="tel:+13524284009" className="font-body font-semibold text-[0.9375rem] text-turtle-green px-6 py-3.5 rounded-lg border border-turtle-green transition-all hover:bg-[rgba(45,106,79,0.05)] flex items-center gap-2"><Phone size={16} />(352) 428-4009</a>
          </div>
        </div>
      </section>

      {/* CTA */}
      <section className="gradient-hero-green" style={{ padding: '4rem 0' }}>
        <div className="max-w-[800px] mx-auto text-center" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
          <h2 className="font-display font-bold text-white" style={{ fontSize: 'clamp(1.5rem, 3vw, 2rem)' }}>Your privacy is not optional.</h2>
          <p className="font-body text-[1rem] mt-3" style={{ color: 'rgba(255,255,255,0.8)' }}>Contact us to learn about identity protection plans that fit your family&apos;s needs.</p>
          <div className="flex flex-wrap items-center justify-center gap-4 mt-6">
            <Link to="/contact" className="font-body font-semibold text-[0.9375rem] text-turtle-green bg-white px-8 py-3 rounded-lg transition-all hover:bg-warm-cream">Get Protected</Link>
          </div>
        </div>
      </section>
    </div>
  );
}
"""

let render() = file
