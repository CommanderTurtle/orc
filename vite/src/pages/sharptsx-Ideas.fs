module Imported.Src.Pages.IdeasTsx

let file = """import { Link } from 'react-router-dom';
import { Lightbulb, Shield, PenTool, BookOpen, Scale } from 'lucide-react';

/* ═══════════════════════════════════════════════════════════
   MY IDEAS — Intellectual Property Protection
   "Protect My Ideas" — tucked away like Privacy
   ═══════════════════════════════════════════════════════════ */

const ipTypes = [
  {
    icon: PenTool, title: 'Copyright',
    what: 'Protects original works of authorship — books, music, software, artwork, photographs, website content.',
    duration: 'Life of author + 70 years',
    cost: '$45–$125 (DIY) / $500–$2,000 (attorney)',
    when: 'As soon as work is created in tangible form. Registration optional but recommended.',
  },
  {
    icon: Shield, title: 'Trademark',
    what: 'Protects brand identifiers — business names, logos, slogans, product names, sounds, colors associated with your brand.',
    duration: '10 years, renewable indefinitely',
    cost: '$250–$350 per class (USPTO) / $1,000–$2,500 (attorney)',
    when: 'Before launch or as soon as brand identity is finalized. Search existing marks first.',
  },
  {
    icon: Lightbulb, title: 'Patent',
    what: 'Protects inventions, processes, machines, manufactured items, or compositions of matter. Must be novel, non-obvious, and useful.',
    duration: '20 years from filing date (utility) / 15 years (design)',
    cost: '$300–$1,600 (USPTO) / $5,000–$15,000+ (attorney)',
    when: 'Before public disclosure. File provisional patent first for 12-month protection window.',
  },
  {
    icon: BookOpen, title: 'Trade Secret',
    what: 'Protects confidential business information — formulas, recipes, customer lists, algorithms, business methods.',
    duration: 'Indefinite (as long as secret)',
    cost: 'Minimal (NDAs, security measures)',
    when: 'Implement protection measures from day one. Use NDAs with employees and partners.',
  },
];

const processSteps = [
  { num: '1', title: 'Document Everything', desc: 'Keep dated records, sketches, prototypes, emails, and notes. Use timestamps and version control.' },
  { num: '2', title: 'Conduct a Search', desc: 'Search USPTO database, Google, and industry sources to ensure your idea is original and not already protected.' },
  { num: '3', title: 'Choose Protection Type', desc: 'Copyright for creative works, trademark for brands, patent for inventions, trade secret for confidential methods.' },
  { num: '4', title: 'File Your Application', desc: 'File with USPTO or Copyright Office. Consider hiring an IP attorney for complex filings.' },
  { num: '5', title: 'Monitor & Enforce', desc: 'Watch for infringement. Set up Google Alerts. Be prepared to send cease & desist letters if needed.' },
];

export default function Ideas() {
  return (
    <div>
      <section className="gradient-hero-green" style={{ padding: '140px 0 5rem' }}>
        <div className="max-w-[1280px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
          <p className="font-body font-medium text-[0.75rem] uppercase tracking-[0.15em] text-shell-gold mb-4">INTELLECTUAL PROPERTY</p>
          <h1 className="font-display font-bold text-white" style={{ fontSize: 'clamp(2rem, 5vw, 3.5rem)', lineHeight: 1.1, textShadow: '0 2px 20px rgba(0,0,0,0.3)' }}>
            Protect Your Ideas
          </h1>
          <p className="font-body text-[1.125rem] mt-4" style={{ color: 'rgba(255,255,255,0.8)', maxWidth: '640px', lineHeight: 1.6 }}>
            Your ideas are your most valuable asset. Whether it is a novel, an app, a brand, or an invention, Turtle Protect helps you understand how to safeguard your intellectual property.
          </p>
        </div>
      </section>

      <section className="section-warm-cream" style={{ padding: '5rem 0' }}>
        <div className="max-w-[1280px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
          <div className="text-center mb-10">
            <p className="font-body font-medium text-[0.75rem] uppercase tracking-[0.05em] text-turtle-green mb-3">4 PILLARS OF IP PROTECTION</p>
            <h2 className="font-display font-bold text-[#1A1A1A]" style={{ fontSize: 'clamp(1.5rem, 3vw, 2rem)' }}>Choose the Right Protection for Your Idea</h2>
          </div>
          <div className="grid grid-cols-1 lg:grid-cols-2 gap-6">
            {ipTypes.map((ip) => (
              <div key={ip.title} className="bg-white border border-pearl rounded-xl p-6" style={{ borderRadius: '16px', boxShadow: '0 1px 3px rgba(0,0,0,0.04), 0 4px 12px rgba(0,0,0,0.02)' }}>
                <div className="flex items-start gap-4">
                  <div className="w-12 h-12 rounded-xl bg-turtle-green/10 flex items-center justify-center shrink-0"><ip.icon size={24} className="text-turtle-green" /></div>
                  <div>
                    <h3 className="font-body font-semibold text-[1.125rem] text-[#1A1A1A]">{ip.title}</h3>
                    <p className="font-body text-[0.875rem] text-[#4A4A4A] mt-2" style={{ lineHeight: 1.6 }}>{ip.what}</p>
                    <div className="mt-4 space-y-1.5">
                      <p className="font-body text-[0.75rem] text-[#8A8A8A]"><strong className="text-[#4A4A4A]">Duration:</strong> {ip.duration}</p>
                      <p className="font-body text-[0.75rem] text-[#8A8A8A]"><strong className="text-[#4A4A4A]">Cost:</strong> {ip.cost}</p>
                      <p className="font-body text-[0.75rem] text-[#8A8A8A]"><strong className="text-[#4A4A4A]">When:</strong> {ip.when}</p>
                    </div>
                  </div>
                </div>
              </div>
            ))}
          </div>
        </div>
      </section>

      <section className="bg-white" style={{ padding: '5rem 0' }}>
        <div className="max-w-[800px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
          <div className="text-center mb-10">
            <p className="font-body font-medium text-[0.75rem] uppercase tracking-[0.05em] text-turtle-green mb-3">THE PROCESS</p>
            <h2 className="font-display font-bold text-[#1A1A1A]" style={{ fontSize: 'clamp(1.5rem, 3vw, 2rem)' }}>5 Steps to Protect Your IP</h2>
          </div>
          <div className="flex flex-col gap-5">
            {processSteps.map((s) => (
              <div key={s.num} className="flex gap-4">
                <div className="w-10 h-10 rounded-full bg-turtle-green flex items-center justify-center shrink-0 font-mono font-bold text-white text-[0.875rem]">{s.num}</div>
                <div>
                  <h3 className="font-body font-semibold text-[1rem] text-[#1A1A1A]">{s.title}</h3>
                  <p className="font-body text-[0.875rem] text-[#4A4A4A] mt-1" style={{ lineHeight: 1.6 }}>{s.desc}</p>
                </div>
              </div>
            ))}
          </div>
        </div>
      </section>

      <section className="section-warm-cream" style={{ padding: '4rem 0' }}>
        <div className="max-w-[800px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
          <div className="bg-white border border-pearl rounded-xl p-6 flex items-start gap-4" style={{ borderRadius: '16px' }}>
            <Scale size={20} className="text-turtle-green shrink-0 mt-0.5" />
            <div>
              <p className="font-body text-[0.875rem] text-[#4A4A4A]" style={{ lineHeight: 1.6 }}>
                <strong className="text-[#1A1A1A]">Disclaimer:</strong> Turtle Protect is not a law firm. We provide educational information about intellectual property protection. For legal advice specific to your situation, please consult with a qualified intellectual property attorney. We can refer you to trusted IP attorneys in our network.
              </p>
            </div>
          </div>
        </div>
      </section>

      <section className="gradient-hero-green" style={{ padding: '4rem 0' }}>
        <div className="max-w-[800px] mx-auto text-center" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
          <h2 className="font-display font-bold text-white" style={{ fontSize: 'clamp(1.5rem, 3vw, 2rem)' }}>Got a brilliant idea? Protect it today.</h2>
          <div className="flex flex-wrap items-center justify-center gap-4 mt-6">
            <Link to="/contact" className="font-body font-semibold text-[0.9375rem] text-white px-8 py-3 rounded-lg transition-all hover:scale-105" style={{ background: 'linear-gradient(135deg, #2D6A4F, #3D8A6F)', boxShadow: '0 4px 16px rgba(45,106,79,0.4)' }}>Talk to an Advisor</Link>
            <Link to="/seminars" className="font-body font-semibold text-[0.9375rem] text-white px-6 py-3 rounded-lg transition-all hover:bg-[rgba(255,255,255,0.15)]" style={{ border: '1px solid rgba(255,255,255,0.3)', background: 'rgba(255,255,255,0.08)' }}>View Seminars</Link>
          </div>
        </div>
      </section>
    </div>
  );
}
"""

let render() = file
