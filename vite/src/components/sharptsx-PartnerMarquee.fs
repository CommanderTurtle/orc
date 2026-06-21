module ConvertedFiles.Src.Components.PartnerMarqueeTsx

let file = """import { ShieldCheck, TrendingUp, Heart, Users, GraduationCap, HandHeart } from 'lucide-react';

/* ═══════════════════════════════════════════════════════════
   PARTNER MARQUEE v2 — Insurance Carriers (Row 1) 
   + Community (Row 2)
   ═══════════════════════════════════════════════════════════ */

interface CarrierCard {
  name: string;
  detail: string;
  rating: string;
  since: string;
  products: string;
  color: string;
}

const carriers: CarrierCard[] = [
  { name: 'Mutual of Omaha', detail: 'A+ Rated · Living Promise & IUL', rating: 'A+', since: '1909', products: 'Term, Whole, IUL', color: '#2D6A4F' },
  { name: 'Transamerica', detail: 'A Rated · Top 5 IUL Provider', rating: 'A', since: '1904', products: 'IUL, Term, Final Expense', color: '#1B4332' },
  { name: 'Corebridge (AIG)', detail: 'A Rated · Retirement Solutions', rating: 'A', since: '1919', products: 'Term, IUL, Annuities', color: '#2A9D8F' },
  { name: 'Ethos Life', detail: 'A Rated · 100% Digital', rating: 'A', since: '2016', products: 'Digital Term, Whole', color: '#52796F' },
  { name: 'American Amicable', detail: 'A Rated · Simplified Issue', rating: 'A', since: '1910', products: 'Final Expense, Term', color: '#A3B18A' },
  { name: 'Ameritas', detail: 'A+ Rated · Life & Disability', rating: 'A+', since: '1887', products: 'Life, Disability, Dental', color: '#588157' },
  { name: 'National Life Group', detail: 'A Rated · 175+ Years', rating: 'A', since: '1848', products: 'IUL, Whole, Annuities', color: '#344E41' },
  { name: 'TruStage', detail: 'A Rated · 42M+ Members', rating: 'A', since: '1935', products: 'Whole, Term, Simplified', color: '#3A5A40' },
];

interface CommunityCard {
  name: string;
  desc: string;
  icon: 'heart' | 'users' | 'graduation' | 'shield' | 'trending' | 'handheart';
}

const community: CommunityCard[] = [
  { name: 'Florida Families', desc: 'Protecting homes across the Sunshine State', icon: 'heart' },
  { name: 'Independent Agents', desc: 'Shopping 50+ A-rated carriers for you', icon: 'shield' },
  { name: 'Senior Community', desc: 'Medicare & final expense expertise', icon: 'users' },
  { name: 'Young Families', desc: 'Term life starting at $22/month', icon: 'graduation' },
  { name: 'Business Owners', desc: 'Key person & buy-sell agreements', icon: 'trending' },
  { name: 'Local Seminars', desc: 'Free identity & financial workshops', icon: 'handheart' },
];

const iconMap = {
  heart: Heart,
  users: Users,
  graduation: GraduationCap,
  shield: ShieldCheck,
  trending: TrendingUp,
  handheart: HandHeart,
};

/* ─── Sub-components ─── */

function CarrierCardComponent({ c }: { c: CarrierCard }) {
  return (
    <div
      className="flex-shrink-0 w-[280px] rounded-xl border p-5 mx-2 transition-all duration-300 group select-none cursor-default"
      style={{
        background: 'white',
        borderColor: 'rgba(45,106,79,0.12)',
        boxShadow: '0 1px 3px rgba(0,0,0,0.04)',
      }}
      onMouseEnter={(e) => {
        e.currentTarget.style.borderColor = c.color + '40';
        e.currentTarget.style.boxShadow = '0 4px 16px rgba(0,0,0,0.08)';
        e.currentTarget.style.transform = 'translateY(-2px)';
      }}
      onMouseLeave={(e) => {
        e.currentTarget.style.borderColor = 'rgba(45,106,79,0.12)';
        e.currentTarget.style.boxShadow = '0 1px 3px rgba(0,0,0,0.04)';
        e.currentTarget.style.transform = 'translateY(0)';
      }}
    >
      <div className="flex items-center gap-3 mb-3">
        <div
          className="w-10 h-10 rounded-lg flex items-center justify-center text-white font-bold text-[11px] tracking-tight flex-shrink-0"
          style={{ backgroundColor: c.color }}
        >
          {c.rating}
        </div>
        <div className="min-w-0">
          <div className="text-[14px] font-semibold text-[#1A1A1A] truncate">{c.name}</div>
          <div className="text-[11px] text-[#8A8A8A] truncate">{c.detail}</div>
        </div>
      </div>
      <div className="flex items-center gap-2">
        <span className="text-[10px] text-[#8A8A8A] bg-[#F5F3EF] px-1.5 py-0.5 rounded-full">Est. {c.since}</span>
        <span className="text-[10px] text-turtle-green bg-[rgba(45,106,79,0.08)] px-1.5 py-0.5 rounded-full">{c.products}</span>
      </div>
    </div>
  );
}

function CommunityCardComponent({ c }: { c: CommunityCard }) {
  const Icon = iconMap[c.icon];
  return (
    <div
      className="flex-shrink-0 w-[260px] rounded-xl border p-5 mx-2 transition-all duration-300 group select-none cursor-default"
      style={{
        background: 'rgba(45,106,79,0.03)',
        borderColor: 'rgba(45,106,79,0.12)',
      }}
      onMouseEnter={(e) => {
        e.currentTarget.style.background = 'rgba(45,106,79,0.06)';
        e.currentTarget.style.borderColor = 'rgba(45,106,79,0.25)';
        e.currentTarget.style.transform = 'translateY(-2px)';
      }}
      onMouseLeave={(e) => {
        e.currentTarget.style.background = 'rgba(45,106,79,0.03)';
        e.currentTarget.style.borderColor = 'rgba(45,106,79,0.12)';
        e.currentTarget.style.transform = 'translateY(0)';
      }}
    >
      <div className="flex items-center gap-3">
        <div className="w-10 h-10 rounded-lg bg-[rgba(45,106,79,0.1)] flex items-center justify-center flex-shrink-0 group-hover:bg-[rgba(45,106,79,0.15)] transition-colors">
          <Icon size={18} style={{ color: '#2D6A4F' }} />
        </div>
        <div className="min-w-0">
          <div className="text-[14px] font-semibold text-[#1A1A1A] truncate">{c.name}</div>
          <div className="text-[11px] text-[rgba(26,26,26,0.55)] leading-[1.4] truncate">{c.desc}</div>
        </div>
      </div>
    </div>
  );
}

/* ─── Main ─── */

export default function PartnerMarquee() {
  const carriersDup = [...carriers, ...carriers];
  const communityDup = [...community, ...community];

  return (
    <div className="w-full overflow-hidden py-2">
      {/* Row 1 — Carriers (scrolls left) */}
      <div className="relative mb-3">
        <div className="flex animate-marquee-left hover:[animation-play-state:paused]">
          {carriersDup.map((c, i) => <CarrierCardComponent key={`c-${i}`} c={c} />)}
        </div>
      </div>

      {/* Row 2 — Community (scrolls right) */}
      <div className="relative">
        <div className="flex animate-marquee-right hover:[animation-play-state:paused]">
          {communityDup.map((c, i) => <CommunityCardComponent key={`co-${i}`} c={c} />)}
        </div>
      </div>

      <style>{`
        @keyframes marquee-left {
          0%   { transform: translateX(0); }
          100% { transform: translateX(-50%); }
        }
        @keyframes marquee-right {
          0%   { transform: translateX(-50%); }
          100% { transform: translateX(0); }
        }
        .animate-marquee-left {
          animation: marquee-left 50s linear infinite;
          width: max-content;
        }
        .animate-marquee-right {
          animation: marquee-right 42s linear infinite;
          width: max-content;
        }
        .animate-marquee-left:hover,
        .animate-marquee-right:hover {
          animation-play-state: paused;
        }
      `}</style>
    </div>
  );
}
"""

let render() = file
