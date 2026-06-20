module Imported.Src.Pages.TermsTsx

let file = """import { useState, useEffect, useRef } from 'react';
import { Link } from 'react-router-dom';
import { motion } from 'framer-motion';
import { FileText, ArrowRight, ArrowUp } from 'lucide-react';

/* ------------------------------------------------------------------ */
/*  Section data                                                       */
/* ------------------------------------------------------------------ */
const SECTIONS = [
  {
    id: 'header',
    number: '1',
    title: 'Terms of use — Effective date',
    content: `This policy is effective June 11, 2026.`,
  },
  {
    id: 'welcome',
    number: '2',
    title: 'Welcome / Applicability',
    content: `Welcome to Turtle Protect. These Terms of Use apply to the Services (defined below) offered by FFL America and Turtle Protect, Florida (collectively, “Turtle Protect”). The Service comprises the Site and the Apps (defined below). Any participation in this site will constitute acceptance of this agreement. If you do not agree to abide by the agreement, pleased do not use this site. Please read this agreement carefully.`,
  },
  {
    id: 'service_definition',
    number: '3',
    title: 'Service description',
    content: `Turtle Protect allows users to access information and configure certain aspects of its Service through its website located at www.TurtleProtect.org (the “Site”), and also provides software applications for mobile phones (the “Apps”). For the avoidance of doubt, the Service excludes Turtle Protect’s insurance products, coverages, and services (which require your application, and Turtle Protect’s acceptance, and which are governed by separate terms), and is limited solely to your use of Turtle Protect’s Apps and web based information and configuration services.`,
  },
  {
    id: 'changes',
    number: '4',
    title: 'Changes to Terms',
    content: `Turtle Protect reserves the right to update or modify the Terms at any time without prior notice, and such changes will be effective immediately upon being posted through the Service and these Terms will identify the date of last update.`,
  },
  {
    id: 'privacy',
    number: '5',
    title: 'Privacy',
    content: `Whenever you submit information to Turtle Protect you consent to the collection, processing, use and disclosure of that information in accordance with these Terms of Use and the Privacy Policy.`,
  },
  {
    id: 'account_info',
    number: '6',
    title: 'Account Information & Responsibilities of Registered Users',
    content: `In order to access some features of the Service, you will have to create an account. You represent and warrant that the information you provide to Turtle Protect upon registration (including information provided through your linked Facebook account, as applicable, or other third party Linked Accounts, as defined below), and at all other times, will be true, accurate, current, and complete. You also represent and warrant that this information is accurate and kept up-to-date at all times.\n\nDo not share your account information with, or allow access to your account by, any third party. If you have any reason to believe that your account information has been compromised or that your account has been accessed by a third party, you agree to immediately notify Turtle Protect by e-mail to clement.keynote-1e@icloud.com. You are solely responsible for your own losses or losses incurred by Turtle Protect and others (including other users) due to any unauthorized use of your account that occur as a result of your intentional or inadvertent disclosure of any of your login information or as a result of your delay in notifying Turtle Protect that your account was compromised after your discovery of the compromise.\n\nWhen you purchase insurance coverage from the Turtle Protect. The site is capable of collecting and communicating back to Turtle Protect a variety of information about your personal information.`,
  },
  {
    id: 'copyright',
    number: '7',
    title: 'Trademark / IP',
    content: `All original content, features, and functionality of this Site is owned by Turtle Protect and protected by U.S. and international trademark, trade secret, and other intellectual property or proprietary rights laws.\n\nYou agree and understand that Site Content may include Third Party Content, as set forth in further detail in Section 6, below. All trademarks, service marks, and trade names are proprietary to Turtle Protect or its affiliates and/or third parties. You agree not to sell, license, distribute, copy, modify, publicly perform or display, transmit, publish, edit, adapt, create derivative works from, or otherwise make unauthorized use of the Site Content, and nothing herein shall be interpreted to grant you any right or license under any intellectual property rights of Turtle Protect or any third party.`,
  },
  {
    id: 'linked_accounts',
    number: '8',
    title: 'Linked Accounts and Social Networking Sites',
    content: `Turtle Protect may, now or in the future, allow you to link your account(s) on the Service to your accounts on third party services, such as social networking sites (“Linked Accounts”). If you link your account on the Service to a Linked Account, you authorize Turtle Protect to store and use your access credentials to access your Linked Account on your behalf as your agent to integrate your experience with the Service with content, information, and features available through such Linked Account. This may include importing the contacts, preferences, interests or “likes” of the Linked Account, and/or pushing updates regarding your use of the Service out to your Linked Accounts. Linking, accessing or using a third party service through the Service in this manner may be subject to additional terms established by the applicable third party, and it is your sole responsibility to comply with such third party terms.`,
  },
  {
    id: 'third_party_content',
    number: '9',
    title: 'Third Party Content',
    content: `Turtle Protect may display information, materials or content from third parties (“Third Party Materials”) through the Services. The display on or through the website and Services of such Third Party Materials does not in any way imply, suggest, or constitute any sponsorship, endorsement, or approval of Turtle Protect by any such third party or any affiliation between any such third party and Turtle Protect.`,
  },
  {
    id: 'user_content',
    number: '10',
    title: 'User Content',
    content: `The Service may now or in the future allow users to submit, post, and share content such as text, photos, audiovisual content, and other media content (“User Content”). You retain all your rights in User Content, but if you choose to provide any User Content to Turtle Protect, we require a license to such User Content in order to make it available through the Service. Turtle Protect cannot guarantee any anonymity or confidentiality with respect to any User Content, and strongly recommends that you think carefully and use good judgment about what you submit to or make available through the Service.\n\nYou understand that you, and not Turtle Protect, are entirely responsible for User Content that you make available through the Service. You are solely responsible for your own User Content and the consequences of posting or publishing it. Further, you represent and warrant that you own, or have the necessary licenses, rights, consents, and permissions to use and authorize Turtle Protect to use all patent, trademark, copyright, or other proprietary rights in and to any and all User Content to enable the use of User Content in the manner contemplated by these Terms, and to grant the rights and license set forth herein.\n\nYou retain all of your ownership rights in original aspects your User Content. By providing User Content to Turtle Protect you grant Turtle Protect and its affiliates, sublicensees, partners, designees, and assignees of the Service (collectively, the “Turtle Protect Licensees”) a non-exclusive, fully paid-up, royalty-free, perpetual, irrevocable, sublicensable, transferable, worldwide license.\n\nTurtle Protect does not control User Content and does not have any obligation to monitor such User Content for any purpose, but may at its sole discretion, monitor or review some or all User Content. Turtle Protect and its designees may, at any time and without prior notice, remove any User Content that in the sole judgment of Turtle Protect violates these Terms or is otherwise objectionable, or for any other reason, with or without notice and with no liability of any kind. You agree that you must evaluate, and bear all risks associated with the use of any User Content or other Content, including any reliance on the accuracy, completeness, usefulness or legality of such User Content. You should exercise your independent discretion and judgment before downloading any other User Content.`,
  },
  {
    id: 'customer_contact',
    number: '11',
    title: 'Customer Contact',
    content: `Our Service may involve contacting you by phone call, SMS/MMS messaging, or email. If you use a feature of our Service that involves such contact, you are responsible for any and all service fees associated with any voice minutes, SMS/MMS delivery, and mobile network access, including all applicable data fees, and for complying with all terms of use imposed by your carrier. You are also responsible for having a mobile device that is compatible with software and/or applications made available by Turtle Protect. Unless otherwise stated, Turtle Protect does not represent or warrant that the software made available will be compatible with your mobile device. You represent and warrant that any telephone numbers, email addresses, or other contact information that you provide to Turtle Protect currently belongs to you and not to a family member or any other third party, and you commit to notifying Turtle Protect should such contact information cease to be accurate.`,
  },
  {
    id: 'prohibited_uses',
    number: '12',
    title: 'Prohibited Uses',
    content: `You agree not to use the Service or any aspect or feature thereof for any unlawful purpose or in any way that might harm, damage, or disparage any other party. You agree that you will not, do or attempt to:\n\nReproduce, duplicate, copy, sell, trade, resell, distribute or exploit, any part of the Service, use of the Service, access to the Service, or content obtained through the Service (including without limitation Site Content, Third Party Content, and User Content), for any purpose other than for your personal, noncommercial purposes;\n\nAccess or use the Service for any commercial or business purpose, including without limitation for comparative or competitive research purposes or to transmit unauthorized advertising;\n\nRemove, circumvent, disable, damage or otherwise interfere with any security-related features of the Service, or features that enforce limitations on the use of the Service or any content therein;\n\nThreaten, harass, abuse, slander, defame or otherwise violate the legal rights (such as rights of privacy and publicity) of others; or\n\nUse the Service in any manner whatsoever that could lead to a violation of any federal, state or local laws, rules or regulations.`,
  },
  {
    id: 'termination',
    number: '13',
    title: 'Termination',
    content: `Turtle Protect, in its sole discretion and for any reason or no reason, may terminate your account on the Service, disable your access to the Service (or any part thereof), discontinue the Service, or terminate any license or permission granted to you, at any time, with or without notice, including without limitation in connection with any termination of any insurance policy you may have with the Turtle Protect. You agree that Turtle Protect shall not be liable to you for any such termination.\n\nIf you are dissatisfied with the Service, then please let us know by e-mailing us at clement.keynote-1e@icloud.com. Your only remedy with respect to any dissatisfaction with (i) the Service, (ii) any of these Terms, (iii) any policy or practice of Turtle Protect in operating the Service, or (iv) any content or information transmitted or made available through the Service, is to terminate your use of the Service. You may terminate only by discontinuing your insurance policy (and thus your account on the Service) by calling Turtle Protect at 515.303.2410.`,
  },
  {
    id: 'indemnity',
    number: '14',
    title: 'Indemnity',
    content: `You agree to indemnify and hold harmless Turtle Protect and its parent, subsidiaries, affiliates or any related companies, licensors and suppliers, and their respective directors, officers, employees, agents, representatives, customers, and contractors, from all damages, injuries, liabilities, costs, fees and expenses (including, but not limited to, legal and accounting fees) arising from or in any way related to (i) your use or misuse of the Service (including your use or misuse of Third Party Materials); (ii) your User Content; (iii) your breach or other violation of these Terms including any representations, warranties and covenants herein; (iv) your violation of the rights of any other person or entity, including, but not limited to claims that any User Content infringes or violates any third party intellectual property rights. Turtle Protect reserves the right, at your expense, to assume the exclusive defense and control of any matter for which you are required to indemnify us and you agree to cooperate with our defense of these claims. You may not settle any matter without the prior written consent from Turtle Protect.`,
  },
  {
    id: 'disclaimers',
    number: '15',
    title: 'Disclaimers',
    content: `THE SERVICE (INCLUDING, WITHOUT LIMITATION, THE SITE, SITE CONTENT, OR ANY OTHER PRODUCT, SERVICE OR INFORMATION PROVIDED BY COMPANY), USER CONTENT, THIRD-PARTY CONTENT, AND ANY OTHER SOFTWARE, SERVICES OR APPLICATIONS MADE AVAILABLE IN CONJUNCTION WITH OR THROUGH THE SERVICE, ARE PROVIDED ON AN “AS IS”, “AS AVAILABLE”, “WITH ALL FAULTS” BASIS WITHOUT REPRESENTATIONS OR WARRANTIES OF ANY KIND, EITHER EXPRESS, IMPLIED, OR STATUTORY, INCLUDING, BUT NOT LIMITED TO, IN TERMS OF CORRECTNESS, ACCURACY, RELIABILITY, OR OTHERWISE.\n\nTO THE FULLEST EXTENT PERMISSIBLE BY APPLICABLE LAW, COMPANY HEREBY DISCLAIMS ALL WARRANTIES OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING, ANY WARRANTY OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE, NON-INFRINGEMENT, OR ARISING FROM A COURSE OF DEALING, WITH RESPECT TO THE PRODUCTS OR SERVICES PROVIDED BY COMPANY.`,
  },
  {
    id: 'limitation_of_liability',
    number: '16',
    title: 'Limitation of Liability',
    content: `IN NO EVENT WILL COMPANY, ITS OFFICERS OR DIRECTORS BE LIABLE TO ANY PARTY FOR ANY DIRECT, INDIRECT, SPECIAL OR OTHER CONSEQUENTIAL DAMAGES ARISING OUT OF OR IN CONNECTION WITH (I) YOUR USE OF THE SERVICE, SITE CONTENT, THIRD PARTY MATERIALS OR THE SITE; (II) THE USE OR ACCESS OF OR INABILITY TO USE OR ACCESS THE SERVICE OR ANY CONTENT; OR (III) PLANS MADE OR INFORMATION ACQUIRED THROUGH THE SERVICES, INCLUDING, WITHOUT LIMITATION, (I) ANY FEES OR COSTS ASSOCIATED WITH CANCELLED, INTERRUPTED OR DELAYED PLANS; (II) ANY FEES OR COSTS RESULTING FROM MISINFORMATION OR FAILURES IN COMMUNICATION; (III) AND ANY ACCIDENTS OR UNEXPECTED EVENTS OTHERWISE, WHETHER BASED IN TORT, CONTRACT OR OTHER LEGAL THEORY, EVEN IF COMPANY IS EXPRESSLY ADVISED OF THE POSSIBILITY OF SUCH DAMAGES. EXCEPT AS SPECIFICALLY REQUIRED BY LAW, IN NO EVENT WILL COMPANY, ITS OFFICERS OR DIRECTORS BE LIABLE IN THE AGGREGATE FOR ANY DAMAGES INCURRED GREATER THAN FIVE HUNDRED DOLLARS ($500). THESE LIMITATIONS OF LIABILITY SHALL SURVIVE THE TERMINATION OF THIS AGREEMENT.\n\nAPPLICABLE LAW MAY NOT ALLOW FOR THE LIMITATION OR EXCLUSION OF LIABILITY OR INCIDENTAL OR CONSEQUENTIAL DAMAGES, SO THE ABOVE LIMITATION OR EXCLUSION MAY NOT APPLY TO YOU. IN SUCH CASES, YOU AGREE THAT BECAUSE SUCH WARRANTY DISCLAIMERS AND LIMITATIONS OF LIABILITY REFLECT A REASONABLE AND FAIR ALLOCATION OF RISK BETWEEN YOU AND COMPANY, AND ARE FUNDAMENTAL ELEMENTS OF THE BASIS OF THE BARGAIN BETWEEN YOU AND COMPANY, COMPANY’S LIABILITY WILL BE LIMITED TO THE MAXIMUM EXTENT PERMITTED BY LAW. THESE LIMITATIONS AND EXCLUSIONS APPLY IN NEW JERSEY. YOU UNDERSTAND AND AGREE THAT COMPANY WOULD NOT BE ABLE TO OFFER THE SERVICE TO YOU ON AN ECONOMICALLY FEASIBLE BASIS WITHOUT THESE LIMITATIONS.`,
  }
];

const RELATED_DOCS = [
  { title: 'Privacy Policy', path: '/privacy' },
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
export default function Terms() {
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
          <motion.div
            initial="hidden"
            animate="visible"
            variants={staggerContainer}
          >
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
              Terms of Service
            </motion.h1>
            <motion.p
              className="mt-4 text-lg text-[rgba(255,255,255,0.8)] max-w-[640px] mx-auto leading-relaxed"
              variants={staggerItem}
            >
              Please read these terms carefully before using the Turtle Protect platform. By
              accessing our site, you agree to be bound by these terms.
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
          {/* SIDEBAR TOC (desktop) / Mobile accordion                */}
          {/* -------------------------------------------------------- */}
          <aside className="lg:w-[250px] flex-shrink-0">
            {/* Mobile accordion toggle */}
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
                  <h2 className="font-body font-semibold text-xl text-ink">
                    {section.title}
                  </h2>
                </div>
                <p className="text-base text-slate-text leading-[1.8]">{section.content}</p>
                {index < SECTIONS.length - 1 && (
                  <hr className="mt-12 border-[#F0EDE8]" />
                )}
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
      {/* BACK TO TOP (floating)                                        */}
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
