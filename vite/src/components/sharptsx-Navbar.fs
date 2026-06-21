module ConvertedFiles.Src.Components.NavbarTsx

let file = """import { useState, useEffect, useRef } from 'react';
import { Link, useLocation } from 'react-router-dom';
import { Menu, X } from 'lucide-react';
import { useAuth } from '@/context/AuthContext';
import turtlelogo from '@/assets/turtle-master.svg';

const navLinks = [
  { label: 'Home', path: '/' },
  { label: 'Insurance', path: '/insurance' },
  { label: 'Assets', path: '/assets' },
  { label: 'Health', path: '/health' },
  { label: 'Tech Support', path: '/tech-support' },
  { label: 'Seminars', path: '/seminars' },
  { label: 'Contact', path: '/contact' },
];

export default function Navbar() {
  const [opacity, setOpacity] = useState(0);
  const [mobileOpen, setMobileOpen] = useState(false);
  const location = useLocation();
  const { isAuthenticated, userName, logout } = useAuth();
  const navRef = useRef<HTMLElement>(null);

  const isHome = location.pathname === '/';

  useEffect(() => {
    setMobileOpen(false);
  }, [location.pathname]);

  useEffect(() => {
    const onScroll = () => {
      if (!isHome) {
        setOpacity(1);
        return;
      }
      // On homepage: fully transparent at top, fade in after ~85vh (past the hero)
      const threshold = window.innerHeight * 0.82;
      const fadeEnd = threshold + 200; // 200px fade zone
      const y = window.scrollY;
      if (y < threshold) {
        setOpacity(0);
      } else if (y < fadeEnd) {
        setOpacity((y - threshold) / (fadeEnd - threshold));
      } else {
        setOpacity(1);
      }
    };

    onScroll(); // Initial check
    window.addEventListener('scroll', onScroll, { passive: true });
    return () => window.removeEventListener('scroll', onScroll);
  }, [isHome]);

  const isActive = (path: string) => location.pathname === path;

  // Build nav background style based on opacity
  const bgStyle = isHome
    ? {
        background: `rgba(250,246,241,${opacity * 0.96})`,
        backdropFilter: opacity > 0.1 ? `blur(${12 + opacity * 4}px)` : 'none',
        WebkitBackdropFilter: opacity > 0.1 ? `blur(${12 + opacity * 4}px)` : 'none',
        borderBottom: opacity > 0.5
          ? '1px solid rgba(163,177,138,0.35)'
          : '1px solid transparent',
        boxShadow: opacity > 0.8 ? '0 1px 8px rgba(0,0,0,0.04)' : 'none',
      }
    : {
        background: 'rgba(250,246,241,0.96)',
        backdropFilter: 'blur(16px)',
        WebkitBackdropFilter: 'blur(16px)',
        borderBottom: '1px solid rgba(163,177,138,0.35)',
        boxShadow: '0 1px 8px rgba(0,0,0,0.04)',
      };

  return (
    <>
      <nav
        ref={navRef}
        className="fixed top-0 left-0 right-0 z-50 transition-all duration-300"
        style={{ height: '72px', ...bgStyle }}
      >
        <div className="max-w-[1280px] mx-auto h-full flex items-center justify-between" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
          {/* Logo */}
          <Link to="/" className="flex items-center gap-2 shrink-0">
            <img src={turtlelogo} width={28} height={28} alt="Turtle logo" />
            <span className="font-display font-semibold text-[1.125rem]" style={{ color: isHome && opacity < 0.5 ? '#FAF6F1' : '#1B4332', transition: 'color 0.3s ease' }}>
              Turtle Protect
            </span>
          </Link>

          {/* Desktop nav links */}
          <div className="hidden lg:flex items-center" style={{ gap: '0.25rem' }}>
            {navLinks.map((link) => (
              <Link
                key={link.path}
                to={link.path}
                className={[
                  'font-body font-medium text-[0.8125rem] px-3 py-2 rounded-lg transition-colors duration-200',
                  isActive(link.path)
                    ? isHome && opacity < 0.5 ? 'text-[#A3B18A]' : 'text-turtle-green'
                    : isHome && opacity < 0.5 ? 'text-[rgba(250,246,241,0.85)] hover:text-white' : 'text-[#4A4A4A] hover:text-turtle-green',
                ].join(' ')}
              >
                {link.label}
              </Link>
            ))}
          </div>

          {/* Right side */}
          <div className="hidden lg:flex items-center" style={{ gap: '0.5rem' }}>
            {isAuthenticated ? (
              <div className="flex items-center" style={{ gap: '0.5rem' }}>
                <Link
                  to="/dashboard"
                  className="font-body font-semibold text-[0.75rem] px-3 py-2 rounded-lg transition-all text-turtle-green border border-turtle-green hover:bg-[rgba(45,106,79,0.08)]"
                >
                  Dashboard
                </Link>
                <span className="text-[0.6875rem] font-body text-[#8A8A8A] max-w-[80px] truncate" title={userName}>{userName}</span>
                <button
                  onClick={logout}
                  className="font-body font-semibold text-[0.75rem] text-white bg-deep-forest px-3 py-2 rounded-lg transition-all hover:bg-[#2D5A40]"
                >
                  Logout
                </button>
              </div>
            ) : (
              <>
                <Link
                  to="/login"
                  className={[
                    'font-body font-semibold text-[0.8125rem] px-4 py-2 rounded-lg transition-colors',
                    isHome && opacity < 0.5 ? 'text-[rgba(250,246,241,0.85)] hover:text-white' : 'text-[#4A4A4A] hover:text-turtle-green',
                  ].join(' ')}
                >
                  Login
                </Link>
                <Link
                  to="/contact"
                  className={[
                    'font-body font-semibold text-[0.8125rem] px-4 py-2 rounded-lg transition-all hover:scale-[1.03]',
                    isHome && opacity < 0.5 ? 'text-white bg-[rgba(27,67,50,0.6)] border border-[rgba(255,255,255,0.2)] hover:bg-[rgba(27,67,50,0.85)]' : 'text-white bg-deep-forest hover:bg-[#2D5A40]',
                  ].join(' ')}
                >
                  Get Protected
                </Link>
              </>
            )}
          </div>

          {/* Mobile hamburger */}
          <button
            className="lg:hidden p-2 rounded-lg"
            onClick={() => setMobileOpen(!mobileOpen)}
            style={{ color: isHome && opacity < 0.5 ? '#FAF6F1' : '#1B4332', transition: 'color 0.3s ease' }}
          >
            {mobileOpen ? <X size={24} /> : <Menu size={24} />}
          </button>
        </div>
      </nav>

      {/* Mobile menu */}
      {mobileOpen && (
        <div
          className="fixed inset-0 z-40 lg:hidden"
          style={{ top: '72px', background: 'rgba(250,246,241,0.98)', backdropFilter: 'blur(12px)' }}
        >
          <div className="flex flex-col" style={{ padding: '1.5rem', gap: '0.25rem' }}>
            {navLinks.map((link) => (
              <Link
                key={link.path}
                to={link.path}
                className={[
                  'font-body font-semibold text-[1rem] py-3 px-4 rounded-lg transition-colors',
                  isActive(link.path) ? 'text-turtle-green bg-[rgba(45,106,79,0.05)]' : 'text-[#4A4A4A]',
                ].join(' ')}
                onClick={() => setMobileOpen(false)}
              >
                {link.label}
              </Link>
            ))}
            {isAuthenticated && (
              <>
                <Link to="/dashboard" className="font-body font-semibold text-[1rem] py-3 px-4 rounded-lg text-turtle-green">Dashboard</Link>
                <span className="font-body text-[0.875rem] text-[#8A8A8A] px-4">Hi, {userName}</span>
                <button onClick={() => { logout(); setMobileOpen(false); }} className="font-body font-semibold text-[1rem] py-3 px-4 rounded-lg text-left text-[#E07A5F]">Logout</button>
              </>
            )}
            {!isAuthenticated && (
              <>
                <Link to="/login" className="font-body font-semibold text-[1rem] py-3 px-4 rounded-lg text-[#4A4A4A]">Login</Link>
                <Link to="/contact" className="font-body font-semibold text-[1rem] py-3 px-4 rounded-lg text-center text-white bg-deep-forest">Get Protected</Link>
              </>
            )}
          </div>
        </div>
      )}
    </>
  );
}
"""

let render() = file
