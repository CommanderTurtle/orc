module ConvertedFiles.Src.Pages.PrivacyTsx

let file = """import { useState, useEffect, useRef } from 'react';
import { Link } from 'react-router-dom';
import { motion } from 'framer-motion';
import { FileText, ArrowRight, ArrowUp } from 'lucide-react';

/* ------------------------------------------------------------------ */
/*  Section data                                                       */
/* ------------------------------------------------------------------ */
const SECTIONS = [
  {
    id: 'introduction',
    number: '1',
    title: 'Introduction',
    content: `Turtle Protect, Inc. ("Turtle Protect," "we," "us," or "our") is committed to protecting your privacy. This Privacy Policy describes how we collect, use, disclose, and safeguard your personal information when you visit our website, use our services, attend our seminars, or otherwise interact with us. By using our Services, you consent to the practices described in this Privacy Policy. If you do not agree with this policy, please do not use our Services.`,
  },
  {
    id: 'information-collect',
    number: '2',
    title: 'Information We Collect',
    content: `We collect several types of information from and about users of our Services:

(a) **Personal Information**: Name, email address, phone number, mailing address, and other contact details you provide through forms, registrations, or communications.

(b) **Inquiry Information**: Details about your insurance needs, coverage preferences, health coverage interests, financial situation, and protection goals that you share with us.

(c) **Authentication Information**: User IDs and session tokens used for account access and dashboard features.

(d) **Usage Information**: Information about how you use our website, including pages visited, time spent, links clicked, features used, and referring URLs.

(e) **Device Information**: IP address, browser type, operating system, device type, and screen resolution.

(f) **Communication Records**: Records of your interactions with our team, including emails, chat transcripts, phone call notes, and seminar attendance.`,
  },
  {
    id: 'how-collect',
    number: '3',
    title: 'How We Collect Information',
    content: `We collect information through: (a) **Direct submission** — when you fill out forms, register for seminars, contact us, or use the authentication system; (b) **Automated technologies** — cookies, web beacons, and analytics tools that collect usage and device information as you navigate our site; (c) **Third parties** — our carrier partners, Sponsored Providers, and analytics services may provide us with information about your interactions.`,
  },
  {
    id: 'how-use',
    number: '4',
    title: 'How We Use Information',
    content: `We use the information we collect to: (a) Respond to your inquiries and provide requested services; (b) Connect you with appropriate insurance agents, financial advisors, or health providers; (c) Authenticate users and provide access to personalized dashboard features; (d) Send seminar invitations, educational content, and service updates (with your consent); (e) Improve our website, services, and user experience; (f) Analyze usage trends and optimize our platform; (g) Comply with legal obligations and protect our rights; (h) Prevent fraud, abuse, and unauthorized access.`,
  },
  {
    id: 'sponsored-sharing',
    number: '5',
    title: 'Sponsored Provider Data Sharing',
    content: `Turtle Protect works with Sponsored Providers — carefully vetted third-party health, wellness, identity protection, and financial service companies. When you express interest in a Sponsored Provider's services (by clicking "Learn More," submitting an inquiry form, or selecting a provider in our health module), we may share the following information with that provider: your name, email address, phone number, and the specific service you're interested in.

We only share data with Sponsored Providers after you take an affirmative action indicating interest. We do not sell your personal information to Sponsored Providers or any other third parties. Each Sponsored Provider is contractually obligated to use your information only for the purpose of responding to your inquiry and providing the requested services. We encourage you to review each Sponsored Provider's individual privacy policy before engaging their services.

**Our current Sponsored Providers include:**

• Ethos
• National Life Group
• American Amicable
• Transamerica
• Mutual of Omaha
• Corebridge

Sponsored Providers are clearly identified throughout our platform with disclosure labels. The compensation we receive from Sponsored Providers does not influence which providers we feature or the objectivity of the information we provide about them.`,
  },
  {
    id: 'your-choices',
    number: '6',
    title: 'Your Choices',
    content: `You have several choices regarding your personal information:

(a) **Opt-out of marketing communications** — You can unsubscribe from our promotional emails by clicking the "unsubscribe" link at the bottom of any marketing email. You may still receive transactional and service-related communications.

(b) **Cookie preferences** — You can manage cookie settings through your browser. Note that disabling certain cookies may affect the functionality of our Services, particularly the authentication system.

(c) **Access and update your information** — You can request access to or correction of your personal information by contacting us at clement.keynote-1e@icloud.com.

(d) **Close your account** — You may request account closure at any time by contacting our support team.`,
  },
  {
    id: 'data-security',
    number: '7',
    title: 'Data Security',
    content: `We implement commercially reasonable security measures to protect your personal information, including: (a) SSL/TLS encryption for all data transmitted between your browser and our servers; (b) Secure storage practices for authentication data; (c) Regular security assessments and monitoring; (d) Limited access to personal information by authorized personnel only. While we strive to protect your information, no method of transmission over the internet or electronic storage is 100% secure. We cannot guarantee absolute security.`,
  },
  {
    id: 'data-retention',
    number: '8',
    title: 'Data Retention',
    content: `We retain your personal information for as long as necessary to fulfill the purposes outlined in this Privacy Policy, unless a longer retention period is required or permitted by law. Inquiry data is retained for up to 7 years to comply with insurance industry regulations. Authentication data is retained as long as your account remains active. You may request deletion of your data at any time (see Your Rights below).`,
  },
  {
    id: 'childrens-privacy',
    number: '9',
    title: "Children's Privacy",
    content: `Our Services are not intended for individuals under the age of 13. We do not knowingly collect personal information from children under 13. If you are a parent or guardian and believe your child has provided us with personal information, please contact us immediately at clement.keynote-1e@icloud.com, and we will take steps to delete such information.`,
  },
  {
    id: 'third-party-links',
    number: '10',
    title: 'Third-Party Links',
    content: `Our website may contain links to third-party websites, services, and applications that are not operated by us. This Privacy Policy does not apply to those third-party services. We encourage you to review the privacy policies of any third-party services you interact with. We are not responsible for the privacy practices of third parties.`,
  },
  {
    id: 'hipaa-notice',
    number: '11',
    title: 'HIPAA Notice',
    content: `Turtle Protect is not a HIPAA covered entity. We do not provide healthcare services, process health insurance claims, or engage in transactions that would make us subject to the Health Insurance Portability and Accountability Act. Any health-related information you share with us is treated as general personal information and is protected as described in this Privacy Policy. If you engage with a HIPAA-covered Sponsored Provider, that provider's own privacy practices and HIPAA notices will apply to their handling of your information.`,
  },
  {
    id: 'ccpa-rights',
    number: '12',
    title: 'CCPA Rights',
    content: `If you are a California resident, you have additional rights under the California Consumer Privacy Act (CCPA), including:

(a) **Right to Know** — You have the right to request what personal information we collect, use, disclose, and sell about you.

(b) **Right to Delete** — You have the right to request deletion of your personal information, subject to certain exceptions.

(c) **Right to Opt-Out** — You have the right to opt out of the sale of your personal information. Turtle Protect does not sell personal information as defined by the CCPA.

(d) **Right to Non-Discrimination** — We will not discriminate against you for exercising any of your CCPA rights.

To exercise these rights, contact us at clement.keynote-1e@icloud.com or (352) 428-4009. We will verify your identity before processing your request and will respond within 45 days.`,
  },
  {
    id: 'cookies-tracking',
    number: '13',
    title: 'Cookies & Tracking',
    content: `We use cookies and similar tracking technologies to: (a) Maintain your session and authentication state; (b) Remember your preferences; (c) Analyze website traffic and usage patterns; (d) Deliver relevant content and measure engagement.

**Types of cookies we use:**

• **Essential cookies** — Required for the website to function properly, including authentication.
• **Preference cookies** — Remember your settings and choices.
• **Analytics cookies** — Help us understand how visitors interact with our website.
• **Marketing cookies** — Used to deliver relevant advertisements and track their performance.

You can manage cookie preferences through your browser settings. Most browsers allow you to refuse or delete cookies. Note that disabling certain cookies may affect the functionality of our Services, particularly the authentication system.`,
  },
  {
    id: 'changes',
    number: '14',
    title: 'Changes to This Policy',
    content: `We may update this Privacy Policy from time to time to reflect changes in our practices, legal requirements, or service offerings. We will notify you of material changes by posting the updated policy on this page with a revised effective date and, where required by law, through additional notification methods. Your continued use of the Services after any changes constitutes acceptance of the updated Privacy Policy.`,
  },
  {
    id: 'contact',
    number: '15',
    title: 'Contact Us',
    content: `If you have any questions, concerns, or requests regarding this Privacy Policy or our data practices, please contact us:

Turtle Protect, Inc.
clement.keynote-1e@icloud.com
Tampa, FL

Email: clement.keynote-1e@icloud.com
Phone: (352) 428-4009`,
  },
];

const RELATED_DOCS = [
  { title: 'Terms of Service', path: '/terms' },
  { title: 'Health Module ToS', path: '/health' },
  { title: 'Health Module Privacy', path: '/health' },
];

/* ------------------------------------------------------------------ */
/*  Animation helpers                                                  */
/* ------------------------------------------------------------------ */
const staggerContainer = {
  hidden: {},
  visible: { transition: { staggerChildren: 0.1 } },
};

const staggerItem = {
  hidden: { opacity: 0, y: 30 },
  visible: { opacity: 1, y: 0, transition: { duration: 0.5, ease: [0, 0, 0.2, 1] as [number, number, number, number] } },
};

/* ------------------------------------------------------------------ */
/*  Main component                                                     */
/* ------------------------------------------------------------------ */
export default function Privacy() {
  const [activeSection, setActiveSection] = useState('');
  const [mobileTocOpen, setMobileTocOpen] = useState(false);
  const [showBackToTop, setShowBackToTop] = useState(false);
  const sectionRefs = useRef<Record<string, HTMLDivElement | null>>({});

  /* Scroll-spy via IntersectionObserver */
  useEffect(() => {
    const observer = new IntersectionObserver(
      (entries) => {
        entries.forEach((entry) => {
          if (entry.isIntersecting) {
            setActiveSection(entry.target.id);
          }
        });
      },
      { rootMargin: '-20% 0px -60% 0px', threshold: 0 },
    );

    SECTIONS.forEach((s) => {
      const el = document.getElementById(s.id);
      if (el) observer.observe(el);
    });

    return () => observer.disconnect();
  }, []);

  /* Back-to-top visibility */
  useEffect(() => {
    const onScroll = () => setShowBackToTop(window.scrollY > 800);
    window.addEventListener('scroll', onScroll, { passive: true });
    return () => window.removeEventListener('scroll', onScroll);
  }, []);

  const scrollToSection = (id: string) => {
    setMobileTocOpen(false);
    const el = document.getElementById(id);
    if (el) {
      const navOffset = 90;
      const top = el.getBoundingClientRect().top + window.scrollY - navOffset;
      window.scrollTo({ top, behavior: 'smooth' });
    }
  };

  const scrollToTop = () => {
    window.scrollTo({ top: 0, behavior: 'smooth' });
  };

  /* Split content by newlines for multi-paragraph rendering */
  const renderContent = (content: string) => {
    const lines = content.split('\n');
    const elements: React.ReactNode[] = [];
    let currentList: string[] = [];
    let inList = false;

    const flushList = () => {
      if (currentList.length > 0) {
        elements.push(
          <ul key={`list-${elements.length}`} className="list-none space-y-2 my-3">
            {currentList.map((item, i) => {
              const clean = item.replace(/^[•\-\*]\s*/, '').trim();
              if (!clean) return null;
              return (
                <li key={i} className="flex items-start gap-2 text-base text-slate-text leading-[1.8]">
                  <span className="text-[#2D6A4F] mt-1.5 flex-shrink-0">
                    <span className="block w-1.5 h-1.5 rounded-full bg-[#2D6A4F]" />
                  </span>
                  {clean}
                </li>
              );
            })}
          </ul>,
        );
        currentList = [];
        inList = false;
      }
    };

    lines.forEach((line, idx) => {
      const trimmed = line.trim();

      if (trimmed.startsWith('•') || trimmed.startsWith('-') || trimmed.startsWith('*')) {
        currentList.push(trimmed);
        inList = true;
        return;
      }

      if (inList && trimmed === '') {
        flushList();
        return;
      }

      if (inList && !trimmed.startsWith('•') && !trimmed.startsWith('-')) {
        flushList();
      }

      if (trimmed === '') {
        return;
      }

      // Bold text like (a) **text**
      if (trimmed.match(/^\([a-z]\)\s*\*\*/)) {
        const clean = trimmed.replace(/^\([a-z]\)\s*\*\*/, '').replace(/\*\*$/, '');
        elements.push(
          <p key={idx} className="text-base text-slate-text leading-[1.8] mt-3">
            <span className="font-medium text-ink">{clean}</span>
          </p>,
        );
        return;
      }

      // Regular bold text **text**
      if (trimmed.includes('**')) {
        const parts = trimmed.split(/\*\*/);
        const formatted = parts.map((part, i) =>
          i % 2 === 1 ? (
            <span key={i} className="font-medium text-ink">{part}</span>
          ) : (
            <span key={i}>{part}</span>
          ),
        );
        elements.push(
          <p key={idx} className="text-base text-slate-text leading-[1.8] mt-3">
            {formatted}
          </p>,
        );
        return;
      }

      elements.push(
        <p key={idx} className="text-base text-slate-text leading-[1.8] mt-3">
          {trimmed}
        </p>,
      );
    });

    flushList();
    return <>{elements}</>;
  };

  return (
    <div className="min-h-[100dvh]">
      {/* ============================================================ */}
      {/* HERO HEADER                                                   */}
      {/* ============================================================ */}
      <section className="gradient-hero-green min-h-[40vh] flex items-center justify-center relative">
        <div
          className="max-w-[1280px] mx-auto w-full text-center"
          style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}
        >
          <motion.div initial="hidden" animate="visible" variants={staggerContainer}>
            <motion.span
              className="inline-block font-body font-medium text-xs uppercase tracking-[0.05em] text-[#D4A574] mb-4"
              variants={staggerItem}
            >
              LEGAL
            </motion.span>
            <motion.h1
              className="font-display font-bold text-white leading-tight"
              style={{ fontSize: 'clamp(2rem, 5vw, 4rem)' }}
              variants={staggerItem}
            >
              Privacy Policy
            </motion.h1>
            <motion.p
              className="mt-4 text-lg text-[rgba(255,255,255,0.8)] max-w-[640px] mx-auto leading-relaxed"
              variants={staggerItem}
            >
              Your privacy is important to us. This policy explains how we collect, use, and protect
              your personal information when you use the Turtle Protect platform.
            </motion.p>
            <motion.p
              className="mt-4 text-sm text-[rgba(255,255,255,0.5)]"
              variants={staggerItem}
            >
              Effective Date: January 1, 2025
            </motion.p>
            <motion.p className="text-sm text-[rgba(255,255,255,0.5)]" variants={staggerItem}>
              Last Updated: January 1, 2025
            </motion.p>
          </motion.div>
        </div>
      </section>

      {/* ============================================================ */}
      {/* DOCUMENT CONTENT                                              */}
      {/* ============================================================ */}
      <section className="bg-white py-12 lg:py-20">
        <div
          className="max-w-[1100px] mx-auto flex flex-col lg:flex-row gap-8"
          style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}
        >
          {/* -------------------------------------------------------- */}
          {/* SIDEBAR TOC                                               */}
          {/* -------------------------------------------------------- */}
          <aside className="lg:w-[250px] flex-shrink-0">
            <button
              onClick={() => setMobileTocOpen(!mobileTocOpen)}
              className="lg:hidden w-full flex items-center justify-between bg-[#FAF6F1] border border-pearl rounded-lg px-4 py-3 font-body font-medium text-sm text-ink"
            >
              <span>Table of Contents</span>
              <ArrowRight
                size={16}
                className={`text-stone-muted transition-transform duration-200 ${mobileTocOpen ? 'rotate-90' : ''}`}
              />
            </button>

            <div
              className={`${mobileTocOpen ? 'block' : 'hidden'} lg:block lg:sticky lg:top-[100px] bg-white lg:bg-transparent border lg:border-0 border-pearl rounded-lg lg:rounded-none mt-2 lg:mt-0 overflow-hidden`}
            >
              <nav className="p-4 lg:p-0 space-y-1 max-h-[60vh] overflow-y-auto">
                {SECTIONS.map((s) => (
                  <button
                    key={s.id}
                    onClick={() => scrollToSection(s.id)}
                    className={[
                      'w-full text-left font-body text-sm px-3 py-2 rounded-md transition-all duration-200 leading-snug',
                      activeSection === s.id
                        ? 'text-[#2D6A4F] bg-[rgba(45,106,79,0.06)] border-l-2 border-[#2D6A4F]'
                        : 'text-slate-text hover:text-ink hover:bg-[rgba(45,106,79,0.03)] border-l-2 border-transparent',
                    ].join(' ')}
                  >
                    <span className="font-mono text-xs text-stone-muted mr-2">{s.number}.</span>
                    {s.title}
                  </button>
                ))}
              </nav>
            </div>
          </aside>

          {/* -------------------------------------------------------- */}
          {/* MAIN CONTENT                                            */}
          {/* -------------------------------------------------------- */}
          <div className="flex-1 min-w-0">
            {SECTIONS.map((section, index) => (
              <div
                key={section.id}
                id={section.id}
                ref={(el) => { sectionRefs.current[section.id] = el; }}
                className={index > 0 ? 'mt-12 pt-4' : ''}
              >
                <div className="flex items-baseline gap-3 mb-3">
                  <span className="font-display font-bold text-2xl text-[#D4A574]">
                    {section.number}
                  </span>
                  <h2 className="font-body font-semibold text-xl text-ink">{section.title}</h2>
                </div>

                {/* CCPA highlight callout */}
                {section.id === 'ccpa-rights' && (
                  <div
                    className="mb-4 rounded-r-lg p-4"
                    style={{
                      background: 'rgba(45,106,79,0.05)',
                      borderLeft: '3px solid #2D6A4F',
                    }}
                  >
                    <p className="text-sm text-slate-text leading-relaxed">
                      <span className="font-medium text-ink">California Residents:</span> If you
                      are a California resident, you have additional rights under the California
                      Consumer Privacy Act (CCPA), including the right to know what personal
                      information we collect, the right to delete your information, and the right to
                      opt out of the sale of personal information. Turtle Protect does not sell
                      personal information as defined by the CCPA.
                    </p>
                  </div>
                )}

                <div>{renderContent(section.content)}</div>

                {index < SECTIONS.length - 1 && <hr className="mt-12 border-[#F0EDE8]" />}
              </div>
            ))}

            {/* Back to top */}
            <div className="mt-12 flex justify-center">
              <button
                onClick={scrollToTop}
                className="flex items-center gap-2 font-body font-medium text-sm text-[#2D6A4F] hover:text-[#1B4332] transition-colors"
              >
                <ArrowUp size={16} />
                Back to top
              </button>
            </div>
          </div>
        </div>
      </section>

      {/* ============================================================ */}
      {/* RELATED DOCUMENTS                                             */}
      {/* ============================================================ */}
      <section className="bg-[#FAF6F1] py-16 lg:py-20">
        <div className="max-w-[800px] mx-auto" style={{ padding: '0 clamp(1rem, 5vw, 3rem)' }}>
          <motion.h3
            className="font-body font-semibold text-xl text-ink text-center mb-8"
            initial={{ opacity: 0, y: 30 }}
            whileInView={{ opacity: 1, y: 0 }}
            viewport={{ once: true, amount: 0.3 }}
            transition={{ duration: 0.6, ease: [0, 0, 0.2, 1] as [number, number, number, number] }}
          >
            Related documents
          </motion.h3>

          <motion.div
            className="flex flex-wrap justify-center gap-4"
            initial="hidden"
            whileInView="visible"
            viewport={{ once: true, amount: 0.3 }}
            variants={staggerContainer}
          >
            {RELATED_DOCS.map((doc) => (
              <motion.div key={doc.title} variants={staggerItem}>
                <Link
                  to={doc.path}
                  className="flex items-center gap-3 bg-white rounded-xl px-5 py-4 shadow-card hover:shadow-card-hover hover:-translate-y-1 transition-all duration-300 group"
                >
                  <FileText size={24} className="text-[#2D6A4F]" />
                  <span className="font-body font-medium text-sm text-ink group-hover:text-[#2D6A4F] transition-colors">
                    {doc.title}
                  </span>
                  <ArrowRight
                    size={16}
                    className="text-stone-muted group-hover:text-[#2D6A4F] group-hover:translate-x-1 transition-all duration-200"
                  />
                </Link>
              </motion.div>
            ))}
          </motion.div>
        </div>
      </section>

      {/* ============================================================ */}
      {/* FLOATING BACK TO TOP                                          */}
      {/* ============================================================ */}
      {showBackToTop && (
        <button
          onClick={scrollToTop}
          className="fixed bottom-8 right-8 z-30 bg-[#2D6A4F] text-white rounded-full p-3 shadow-lg hover:bg-[#1B4332] transition-colors"
          aria-label="Back to top"
        >
          <ArrowUp size={20} />
        </button>
      )}
    </div>
  );
}
"""

let render() = file
