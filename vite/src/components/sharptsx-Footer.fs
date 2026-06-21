module ConvertedFiles.Src.Components.FooterTsx

let file = """import { Link } from 'react-router-dom';
import turtlelogo from '@/assets/turtle-master.svg';

const serviceLinks = [
  { label: 'Life Insurance', path: '/insurance' },
  { label: 'Mortgage Protection', path: '/insurance' },
  { label: 'Annuities', path: '/assets' },
  { label: 'Health Coverage', path: '/health' },
  { label: 'Identity Protection', path: '/tech-support' },
];

const companyLinks = [
  { label: 'About', path: '/insurance' },
  { label: 'Careers', path: '/contact' },
  { label: 'Blog', path: '/seminars' },
  { label: 'Contact', path: '/contact' },
  { label: 'Terms of Service', path: '/terms' },
  { label: 'Privacy Policy', path: '/privacy' },
];

const moreLinks = [
  { label: 'IUL Explained', path: '/iul' },
  { label: 'Identity Protection', path: '/privacy-identity' },
  { label: 'Protect My Ideas', path: '/ideas' },
  { label: 'Protect My Hair', path: '/hair' },
];

export default function Footer() {
  return (
    <footer className="bg-deep-forest" style={{ paddingTop: '6rem', paddingBottom: '3rem' }}>
      <div className="max-w-[1280px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
        <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-5" style={{ gap: '2.5rem' }}>
          {/* Column 1 — Brand */}
          <div className="flex flex-col" style={{ gap: '1rem' }}>
            <div className="flex items-center gap-2">
              <img src={turtlelogo} width={28} height={28} alt="Turtle logo" />
              <span className="font-display font-bold text-white" style={{ fontSize: '1.25rem' }}>
                Turtle Protect
              </span>
            </div>
            <p className="font-display italic text-sage-mist" style={{ fontSize: '1rem' }}>
              Protecting what matters most.
            </p>
          </div>

          {/* Column 2 — Services */}
          <div className="flex flex-col" style={{ gap: '1rem' }}>
            <h4 className="font-body font-semibold text-[0.875rem] uppercase text-white" style={{ letterSpacing: '0.05em' }}>
              Services
            </h4>
            {serviceLinks.map((link) => (
              <Link
                key={link.label}
                to={link.path}
                className="font-body text-sage-mist text-[0.875rem] transition-colors duration-200 hover:text-shell-gold"
              >
                {link.label}
              </Link>
            ))}
          </div>

          {/* Column 3 — Company */}
          <div className="flex flex-col" style={{ gap: '1rem' }}>
            <h4 className="font-body font-semibold text-[0.875rem] uppercase text-white" style={{ letterSpacing: '0.05em' }}>
              Company
            </h4>
            {companyLinks.map((link) => (
              <Link
                key={link.label}
                to={link.path}
                className="font-body text-sage-mist text-[0.875rem] transition-colors duration-200 hover:text-shell-gold"
              >
                {link.label}
              </Link>
            ))}
          </div>

          {/* Column 4 — More (tucked-away pages) */}
          <div className="flex flex-col" style={{ gap: '1rem' }}>
            <h4 className="font-body font-semibold text-[0.875rem] uppercase text-white" style={{ letterSpacing: '0.05em' }}>
              Explore
            </h4>
            {moreLinks.map((link) => (
              <Link
                key={link.label}
                to={link.path}
                className="font-body text-sage-mist text-[0.8125rem] transition-colors duration-200 hover:text-shell-gold"
              >
                {link.label}
              </Link>
            ))}
          </div>

          {/* Column 5 — Connect */}
          <div className="flex flex-col" style={{ gap: '1rem' }}>
            <h4 className="font-body font-semibold text-[0.875rem] uppercase text-white" style={{ letterSpacing: '0.05em' }}>
              Connect
            </h4>
            <div className="flex flex-col" style={{ gap: '0.5rem' }}>
              <p className="font-body text-sage-mist text-[0.875rem]">
                Phone: <span className="text-white">(352) 428-4009</span>
              </p>
              <p className="font-body text-sage-mist text-[0.875rem]">
                Email: <span className="text-white">clement.keynote-1e@icloud.com</span>
              </p>
            </div>
            {/* Social placeholders */}
            <div className="flex items-center" style={{ gap: '0.75rem', marginTop: '0.5rem' }}>
              <div className="w-9 h-9 rounded-full bg-[rgba(163,177,138,0.2)] flex items-center justify-center">
                <svg width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="#A3B18A" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round">
                  <path d="M18 2h-3a5 5 0 0 0-5 5v3H7v4h3v8h4v-8h3l1-4h-4V7a1 1 0 0 1 1-1h3z" />
                </svg>
              </div>
              <div className="w-9 h-9 rounded-full bg-[rgba(163,177,138,0.2)] flex items-center justify-center">
                <svg width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="#A3B18A" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round">
                  <rect x="2" y="2" width="20" height="20" rx="5" ry="5" />
                  <path d="M16 11.37A4 4 0 1 1 12.63 8 4 4 0 0 1 16 11.37z" />
                  <line x1="17.5" y1="6.5" x2="17.51" y2="6.5" />
                </svg>
              </div>
              <div className="w-9 h-9 rounded-full bg-[rgba(163,177,138,0.2)] flex items-center justify-center">
                <svg width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="#A3B18A" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round">
                  <path d="M16 8a6 6 0 0 1 6 6v7h-4v-7a2 2 0 0 0-2-2 2 2 0 0 0-2 2v7h-4v-7a6 6 0 0 1 6-6z" />
                  <rect x="2" y="9" width="4" height="12" />
                  <circle cx="4" cy="4" r="2" />
                </svg>
              </div>
            </div>
          </div>
        </div>

        {/* Bottom bar */}
        <div
          className="flex flex-col sm:flex-row items-center justify-between mt-12 pt-6"
          style={{ borderTop: '1px solid rgba(163,177,138,0.2)' }}
        >
          <p className="font-body text-stone-muted" style={{ fontSize: '0.875rem' }}>
            ™ 2026 Turtle Protect, Inc. All rights reserved.
          </p>
          <p className="font-body text-stone-muted" style={{ fontSize: '0.875rem' }}>
            Florida-based independent protection.
          </p>
        </div>
      </div>
    </footer>
  );
}
"""

let render() = file
