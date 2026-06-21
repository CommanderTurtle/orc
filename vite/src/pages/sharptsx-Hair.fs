module ConvertedFiles.Src.Pages.HairTsx

let file = """import { Link } from 'react-router-dom';
import { Scissors, Sparkles, AlertTriangle, Heart, Clock, DollarSign, ShieldCheck, ChevronRight } from 'lucide-react';

/* ═══════════════════════════════════════════════════════════
   MY HAIR — "Oh No" Advanced Protection
   Originally a joke from the brain map site. Now it is real.
   ═══════════════════════════════════════════════════════════ */

export default function Hair() {
  return (
    <div>
      <section className="gradient-hero-green" style={{ padding: '140px 0 5rem' }}>
        <div className="max-w-[1280px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
          <div className="flex items-center gap-2 mb-4">
            <span className="font-body font-semibold text-[0.65rem] uppercase tracking-[0.15em] px-3 py-1 rounded-full" style={{ background: 'rgba(212,165,116,0.2)', color: '#D4A574' }}>Advanced Protection</span>
          </div>
          <h1 className="font-display font-bold text-white" style={{ fontSize: 'clamp(2.5rem, 6vw, 4rem)', lineHeight: 1.05, textShadow: '0 2px 20px rgba(0,0,0,0.3)' }}>
            Protect My Hair
          </h1>
          <p className="font-body text-[1.25rem] mt-3" style={{ color: 'rgba(255,255,255,0.8)', maxWidth: '560px', lineHeight: 1.5 }}>
            Because let&apos;s be honest — it is one of the first things people notice. And yes, we are completely serious.
          </p>
        </div>
      </section>

      <section className="section-warm-cream" style={{ padding: '4rem 0' }}>
        <div className="max-w-[800px] mx-auto text-center" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
          <div className="inline-flex items-center gap-3 bg-white border border-pearl rounded-full px-6 py-3" style={{ borderRadius: '999px', boxShadow: '0 1px 3px rgba(0,0,0,0.04)' }}>
            <Scissors size={18} className="text-turtle-green" />
            <span className="font-body text-[0.9375rem] text-[#4A4A4A]">Hair loss affects <strong className="text-[#1A1A1A]">80% of men</strong> and <strong className="text-[#1A1A1A]">50% of women</strong> by age 50</span>
          </div>
        </div>
      </section>

      <section className="bg-white" style={{ padding: '3rem 0 5rem' }}>
        <div className="max-w-[1280px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
          <div className="text-center mb-10">
            <p className="font-body font-medium text-[0.75rem] uppercase tracking-[0.05em] text-turtle-green mb-3">OPTIONS EXIST</p>
            <h2 className="font-display font-bold text-[#1A1A1A]" style={{ fontSize: 'clamp(1.5rem, 3vw, 2rem)' }}>Modern Hair Loss Solutions</h2>
          </div>
          <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-6">
            {[
              { icon: ShieldCheck, title: 'Preventive Care', desc: 'Prescription treatments like finasteride (Propecia) and minoxidil (Rogaine) can slow or stop hair loss when started early. Most effective for pattern baldness (androgenetic alopecia).', tag: 'Most Common' },
              { icon: Sparkles, title: 'PRP Therapy', desc: 'Platelet-Rich Plasma injections use your own blood to stimulate hair follicles. 3–4 sessions, results visible in 3–6 months. FDA-cleared, minimal downtime.', tag: 'Popular' },
              { icon: Scissors, title: 'Hair Transplant', desc: 'FUE (Follicular Unit Extraction) moves healthy follicles from donor areas. Permanent, natural results. 8,000–15,000 grafts possible. Recovery: 7–10 days.', tag: 'Permanent' },
              { icon: Heart, title: 'Nutritional Support', desc: 'Biotin, zinc, iron, vitamin D, and collagen supplements. Works best when deficiency is the cause. Get blood work done first.', tag: 'Natural' },
              { icon: Clock, title: 'Low-Level Laser Therapy', desc: 'FDA-cleared laser caps and combs (e.g., Capillus, HairMax). 15–30 min, 3x/week. Stimulates follicles at the cellular level. Results in 4–6 months.', tag: 'At-Home' },
              { icon: DollarSign, title: 'Specialized Insurance', desc: 'Some cosmetic procedure insurance and HSA/FSA accounts can cover PRP and prescription treatments. We can help you navigate coverage options.', tag: 'Coverage' },
            ].map((item) => (
              <div key={item.title} className="bg-warm-cream border border-pearl rounded-xl p-6" style={{ borderRadius: '16px' }}>
                <div className="flex items-center gap-3 mb-3">
                  <div className="w-10 h-10 rounded-lg bg-turtle-green/10 flex items-center justify-center"><item.icon size={20} className="text-turtle-green" /></div>
                  <span className="font-body text-[0.6875rem] text-turtle-green bg-turtle-green/10 px-2 py-0.5 rounded-full">{item.tag}</span>
                </div>
                <h3 className="font-body font-semibold text-[1rem] text-[#1A1A1A] mb-2">{item.title}</h3>
                <p className="font-body text-[0.8125rem] text-[#4A4A4A]" style={{ lineHeight: 1.6 }}>{item.desc}</p>
              </div>
            ))}
          </div>
        </div>
      </section>

      <section className="section-warm-cream" style={{ padding: '4rem 0' }}>
        <div className="max-w-[800px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
          <div className="bg-white border border-[#E07A5F]/20 rounded-xl p-6 flex items-start gap-4" style={{ borderRadius: '16px' }}>
            <AlertTriangle size={18} className="text-soft-coral shrink-0 mt-0.5" />
            <p className="font-body text-[0.8125rem] text-[#4A4A4A]" style={{ lineHeight: 1.6 }}>
              <strong className="text-[#1A1A1A]">Important:</strong> This page is for educational purposes. Turtle Protect does not provide medical advice. Consult a board-certified dermatologist or hair restoration specialist for diagnosis and treatment recommendations. We can connect you with trusted providers in our network.
            </p>
          </div>
        </div>
      </section>

      <section className="gradient-hero-green" style={{ padding: '4rem 0' }}>
        <div className="max-w-[800px] mx-auto text-center" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
          <Scissors size={28} className="text-shell-gold mx-auto mb-3" />
          <h2 className="font-display font-bold text-white" style={{ fontSize: 'clamp(1.5rem, 3vw, 2rem)' }}>Yes, we actually made this page.</h2>
          <p className="font-body text-[1rem] mt-3" style={{ color: 'rgba(255,255,255,0.7)' }}>Because protecting what matters includes every last strand. Even the ones you are worried about.</p>
          <Link to="/" className="inline-block font-body font-semibold text-[0.9375rem] text-shell-gold mt-4 hover:text-white transition-colors">Back to Home <ChevronRight size={14} className="inline" /></Link>
        </div>
      </section>
    </div>
  );
}
"""

let render() = file
