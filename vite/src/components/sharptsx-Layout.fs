module ConvertedFiles.Src.Components.LayoutTsx

let file = """import { useLocation } from 'react-router-dom';
import { motion, AnimatePresence } from 'framer-motion';
import type { ReactNode } from 'react';
import Navbar from './Navbar';
import Footer from './Footer';
import BubbleChat from './BubbleChat';

interface LayoutProps {
  children: ReactNode;
}

const pageVariants = {
  initial: { opacity: 0, scale: 0.98, y: 20 },
  animate: { opacity: 1, scale: 1, y: 0 },
  exit: { opacity: 0, scale: 0.98, y: -10 },
};

const pageTransition = {
  duration: 0.4,
  ease: [0.25, 0.46, 0.45, 0.94] as [number, number, number, number],
};

export default function Layout({ children }: LayoutProps) {
  const location = useLocation();

  return (
    <div className="min-h-[100dvh] flex flex-col">
      <Navbar />
      <div className="flex-1">
        <AnimatePresence mode="wait">
          <motion.div
            key={location.pathname}
            variants={pageVariants}
            initial="initial"
            animate="animate"
            exit="exit"
            transition={pageTransition}
          >
            {children}
          </motion.div>
        </AnimatePresence>
      </div>
      <Footer />
      <BubbleChat />
    </div>
  );
}
"""

let render() = file
