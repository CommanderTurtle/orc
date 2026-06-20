module Imported.Src.Pages.IULTsx

let file = """import { useState } from 'react';
import { Link } from 'react-router-dom';
import {
  TrendingUp, Shield, DollarSign, BarChart3, Lock,
} from 'lucide-react';

/* ═══════════════════════════════════════════════════════════
   INDEXED UNIVERSAL LIFE (IUL) — Educational Page
   ═══════════════════════════════════════════════════════════ */

export default function IUL() {
  const [activeTab, setActiveTab] = useState(0);
  const tabs = ['What is IUL?', 'How It Works', 'Tax Advantages', 'Compare Options'];

  return (
    <div>
      {/* Hero */}
      <section className="gradient-hero-green" style={{ padding: '140px 0 5rem' }}>
        <div className="max-w-[1280px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
          <p className="font-body font-medium text-[0.75rem] uppercase tracking-[0.15em] text-shell-gold mb-4">INSURANCE EDUCATION</p>
          <h1 className="font-display font-bold text-white" style={{ fontSize: 'clamp(2rem, 5vw, 3.5rem)', lineHeight: 1.1, letterSpacing: '-0.02em', textShadow: '0 2px 20px rgba(0,0,0,0.3)' }}>
            Indexed Universal Life
          </h1>
          <p className="font-body text-[1.125rem] mt-4" style={{ color: 'rgba(255,255,255,0.8)', maxWidth: '640px', lineHeight: 1.6 }}>
            Growth potential of the market. Protection of a floor. Tax advantages of life insurance. IUL combines the best of all worlds for long-term wealth building.
          </p>
        </div>
      </section>

      {/* Tabbed Content */}
      <section className="section-warm-cream" style={{ padding: '4rem 0 5rem' }}>
        <div className="max-w-[1000px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
          {/* Tabs */}
          <div className="flex flex-wrap gap-2 mb-8">
            {tabs.map((tab, i) => (
              <button key={tab} onClick={() => setActiveTab(i)} className="font-body font-semibold text-[0.875rem] px-5 py-2.5 rounded-full transition-all duration-200" style={{ borderRadius: '999px', background: activeTab === i ? '#2D6A4F' : '#F0EDE8', color: activeTab === i ? '#fff' : '#4A4A4A' }}>
                {tab}
              </button>
            ))}
          </div>

          {/* Tab content */}
          {activeTab === 0 && (
            <div>
              <h2 className="font-display font-bold text-[#1A1A1A] text-[1.75rem] mb-4">What is Indexed Universal Life Insurance?</h2>
              <p className="font-body text-[1rem] text-[#4A4A4A] mb-4" style={{ lineHeight: 1.7 }}>
                Indexed Universal Life (IUL) is a type of permanent life insurance that offers a death benefit while also building cash value. Unlike traditional universal life, the cash value growth is tied to a stock market index — typically the S&P 500 — but with a critical safety feature: <strong>you cannot lose money due to market downturns</strong>.
              </p>
              <div className="grid grid-cols-1 sm:grid-cols-3 gap-4 my-8">
                {[
                  { icon: TrendingUp, title: 'Market-Linked Growth', desc: 'Cash value grows based on a market index like the S&P 500, with caps and participation rates set by the carrier.' },
                  { icon: Shield, title: 'Downside Protection', desc: 'A 0% floor means your cash value never decreases due to market losses. Your principal is always protected.' },
                  { icon: DollarSign, title: 'Tax-Free Access', desc: 'Policy loans and withdrawals can be structured to provide tax-free income in retirement.' },
                ].map((item) => (
                  <div key={item.title} className="bg-white border border-pearl rounded-xl p-6" style={{ borderRadius: '16px', boxShadow: '0 1px 3px rgba(0,0,0,0.04), 0 4px 12px rgba(0,0,0,0.02)' }}>
                    <div className="w-10 h-10 rounded-lg bg-turtle-green/10 flex items-center justify-center mb-3"><item.icon size={20} className="text-turtle-green" /></div>
                    <h3 className="font-body font-semibold text-[0.9375rem] text-[#1A1A1A] mb-2">{item.title}</h3>
                    <p className="font-body text-[0.8125rem] text-[#4A4A4A]" style={{ lineHeight: 1.5 }}>{item.desc}</p>
                  </div>
                ))}
              </div>
              <p className="font-body text-[1rem] text-[#4A4A4A]" style={{ lineHeight: 1.7 }}>
                IUL policies have become one of the fastest-growing life insurance products in the United States. According to LIMRA, IUL sales grew 14% in 2024, with over $2.8 billion in premium. They are particularly popular among individuals aged 35-55 who want both protection and a tax-advantaged savings vehicle.
              </p>
            </div>
          )}

          {activeTab === 1 && (
            <div>
              <h2 className="font-display font-bold text-[#1A1A1A] text-[1.75rem] mb-4">How Does IUL Work?</h2>
              <div className="flex flex-col gap-6">
                {[
                  { step: '1', title: 'Premium Payment', desc: 'You pay flexible premiums into your policy. A portion covers the cost of insurance, and the remainder goes into the cash value account.' },
                  { step: '2', title: 'Index Selection', desc: 'Your carrier tracks a market index (typically the S&P 500). You choose an indexing strategy — 1-year point-to-point is most common.' },
                  { step: '3', title: 'Capped Upside', desc: 'If the index goes up 12% and your cap is 10%, your cash value is credited 10%. If it goes up 40%, you still get 10% (the cap).' },
                  { step: '4', title: 'Protected Downside', desc: 'If the index drops 20%, your cash value is credited 0%. You lose nothing. The floor protects your accumulated wealth.' },
                  { step: '5', title: 'Tax-Advantaged Growth', desc: 'Cash value grows tax-deferred. Policy loans can provide tax-free income. Death benefit passes to beneficiaries income-tax-free.' },
                ].map((item) => (
                  <div key={item.step} className="flex gap-4">
                    <div className="w-10 h-10 rounded-full bg-turtle-green flex items-center justify-center shrink-0 font-mono font-bold text-white">{item.step}</div>
                    <div>
                      <h3 className="font-body font-semibold text-[1rem] text-[#1A1A1A]">{item.title}</h3>
                      <p className="font-body text-[0.9375rem] text-[#4A4A4A] mt-1" style={{ lineHeight: 1.6 }}>{item.desc}</p>
                    </div>
                  </div>
                ))}
              </div>
            </div>
          )}

          {activeTab === 2 && (
            <div>
              <h2 className="font-display font-bold text-[#1A1A1A] text-[1.75rem] mb-4">IUL Tax Advantages</h2>
              <div className="grid grid-cols-1 sm:grid-cols-2 gap-4">
                {[
                  { icon: Lock, title: 'Tax-Deferred Growth', desc: 'Cash value accumulates without annual taxes on gains. Compounding works more efficiently than taxable accounts.' },
                  { icon: DollarSign, title: 'Tax-Free Policy Loans', desc: 'Borrow against your cash value without triggering income tax. Loans are not considered taxable distributions.' },
                  { icon: Shield, title: 'Tax-Free Death Benefit', desc: 'Your beneficiaries receive the death benefit completely free of federal income tax.' },
                  { icon: BarChart3, title: 'No Contribution Limits', desc: 'Unlike 401(k)s and IRAs, there are no annual caps on how much premium you can contribute.' },
                ].map((item) => (
                  <div key={item.title} className="bg-white border border-pearl rounded-xl p-6 flex gap-4" style={{ borderRadius: '16px' }}>
                    <div className="w-10 h-10 rounded-lg bg-turtle-green/10 flex items-center justify-center shrink-0"><item.icon size={20} className="text-turtle-green" /></div>
                    <div>
                      <h3 className="font-body font-semibold text-[0.9375rem] text-[#1A1A1A]">{item.title}</h3>
                      <p className="font-body text-[0.8125rem] text-[#4A4A4A] mt-1" style={{ lineHeight: 1.5 }}>{item.desc}</p>
                    </div>
                  </div>
                ))}
              </div>
            </div>
          )}

          {activeTab === 3 && (
            <div>
              <h2 className="font-display font-bold text-[#1A1A1A] text-[1.75rem] mb-4">Compare IUL to Other Options</h2>
              <div className="overflow-x-auto">
                <table className="w-full text-left">
                  <thead>
                    <tr className="border-b-2 border-[#2D6A4F]">
                      <th className="font-body font-semibold text-[0.875rem] text-[#1A1A1A] pb-3 pr-4">Feature</th>
                      <th className="font-body font-semibold text-[0.875rem] text-[#2D6A4F] pb-3 px-4">IUL</th>
                      <th className="font-body font-semibold text-[0.875rem] text-[#8A8A8A] pb-3 px-4">Whole Life</th>
                      <th className="font-body font-semibold text-[0.875rem] text-[#8A8A8A] pb-3 px-4">Term Life</th>
                      <th className="font-body font-semibold text-[0.875rem] text-[#8A8A8A] pb-3 pl-4">401(k)</th>
                    </tr>
                  </thead>
                  <tbody>
                    {[
                      ['Death Benefit', 'Yes', 'Yes', 'Yes', 'No'],
                      ['Cash Value Growth', 'Index-linked', 'Guaranteed', 'No', 'Market-based'],
                      ['Downside Protection', '0% floor', 'Guaranteed', 'N/A', 'No'],
                      ['Tax-Deferred Growth', 'Yes', 'Yes', 'N/A', 'Yes'],
                      ['Tax-Free Loans', 'Yes', 'Yes', 'N/A', 'No'],
                      ['Premium Flexibility', 'High', 'Fixed', 'Fixed', 'N/A'],
                      ['Contribution Limits', 'None', 'None', 'N/A', '$23,000/year'],
                    ].map((row, i) => (
                      <tr key={i} className="border-b border-[#F0EDE8]">
                        <td className="font-body text-[0.8125rem] text-[#1A1A1A] py-3 pr-4 font-medium">{row[0]}</td>
                        <td className="font-body text-[0.8125rem] text-[#2D6A4F] py-3 px-4 font-semibold bg-[rgba(45,106,79,0.04)]">{row[1]}</td>
                        <td className="font-body text-[0.8125rem] text-[#4A4A4A] py-3 px-4">{row[2]}</td>
                        <td className="font-body text-[0.8125rem] text-[#4A4A4A] py-3 px-4">{row[3]}</td>
                        <td className="font-body text-[0.8125rem] text-[#4A4A4A] py-3 pl-4">{row[4]}</td>
                      </tr>
                    ))}
                  </tbody>
                </table>
              </div>
            </div>
          )}
        </div>
      </section>

      {/* Carriers offering IUL */}
      <section className="bg-white" style={{ padding: '5rem 0' }}>
        <div className="max-w-[1280px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
          <div className="text-center mb-10">
            <p className="font-body font-medium text-[0.75rem] uppercase tracking-[0.05em] text-turtle-green mb-3">CARRIERS WE WORK WITH</p>
            <h2 className="font-display font-bold text-[#1A1A1A]" style={{ fontSize: 'clamp(1.5rem, 3vw, 2rem)' }}>Leading IUL Providers</h2>
          </div>
          <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-5">
            {[
              { name: 'Transamerica', highlight: 'FFIUL II Express — instant decision, no exam', detail: 'Top 5 IUL provider. Express underwriting with decisions in minutes.' },
              { name: 'National Life Group', highlight: 'NLG Index 10 — strong historical performance', detail: '175+ years of financial protection. Competitive caps and uncapped strategies.' },
              { name: 'Corebridge (AIG)', highlight: 'Max Accumulator+ IUL', detail: 'Multiple index options including S&P 500 and blended strategies.' },
              { name: 'Mutual of Omaha', highlight: 'Income Advantage IUL', detail: 'Living benefit riders included. Strong chronic illness protection.' },
              { name: 'Ameritas', highlight: 'Growth IUL — low costs', detail: 'A+ rated. Focus on cost-efficient cash value accumulation.' },
            ].map((c) => (
              <div key={c.name} className="bg-warm-cream border border-pearl rounded-xl p-6" style={{ borderRadius: '16px' }}>
                <h3 className="font-body font-semibold text-[1rem] text-[#1A1A1A] mb-1">{c.name}</h3>
                <p className="font-body text-[0.8125rem] text-turtle-green mb-2">{c.highlight}</p>
                <p className="font-body text-[0.75rem] text-[#8A8A8A]" style={{ lineHeight: 1.5 }}>{c.detail}</p>
              </div>
            ))}
          </div>
        </div>
      </section>

      {/* CTA */}
      <section className="gradient-hero-green" style={{ padding: '5rem 0' }}>
        <div className="max-w-[800px] mx-auto text-center" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
          <h2 className="font-display font-bold text-white" style={{ fontSize: 'clamp(2rem, 4vw, 3rem)', lineHeight: 1.1 }}>Ready to explore IUL?</h2>
          <p className="font-body text-[1rem] mt-4" style={{ color: 'rgba(255,255,255,0.8)' }}>Our licensed agents can help you compare IUL options and find the right fit for your goals.</p>
          <div className="flex flex-wrap items-center justify-center gap-4 mt-8">
            <Link to="/contact" className="font-body font-semibold text-[0.9375rem] text-white px-8 py-3.5 rounded-lg transition-all hover:scale-105" style={{ background: 'linear-gradient(135deg, #2D6A4F, #3D8A6F)', boxShadow: '0 4px 16px rgba(45,106,79,0.4)' }}>Speak with an Agent</Link>
            <Link to="/insurance" className="font-body font-semibold text-[0.9375rem] text-white px-8 py-3.5 rounded-lg transition-all hover:bg-[rgba(255,255,255,0.15)]" style={{ border: '1px solid rgba(255,255,255,0.3)', background: 'rgba(255,255,255,0.08)' }}>Back to Insurance</Link>
          </div>
        </div>
      </section>
    </div>
  );
}
"""

let render() = file
