module Imported.Src.Components.BubbleChatTsx

let file = """import { useState } from 'react';
import { motion, AnimatePresence } from 'framer-motion';
import { MessageCircle, X, Send } from 'lucide-react';

const quickReplies = [
  'Life Insurance quote',
  'Mortgage Protection',
  'Annuities info',
  'Health coverage',
  'Talk to an agent',
];

export default function BubbleChat() {
  const [isOpen, setIsOpen] = useState(false);
  const [messages, setMessages] = useState<{ text: string; from: 'user' | 'bot' }[]>([
    { text: 'Hi there! How can we help protect you today? 👋', from: 'bot' },
  ]);
  const [inputValue, setInputValue] = useState('');

  const handleQuickReply = (reply: string) => {
    setMessages((prev) => [...prev, { text: reply, from: 'user' }]);
    setTimeout(() => {
      setMessages((prev) => [
        ...prev,
        { text: `🐢 Thanks for your interest in ${reply.toLowerCase()}! 🐢 Fill out a contact form! Or, call our main line.`, from: 'bot' },
      ]);
    }, 600);
  };

  const handleSend = () => {
    if (!inputValue.trim()) return;
    setMessages((prev) => [...prev, { text: inputValue, from: 'user' }]);
    setInputValue('');
    setTimeout(() => {
      setMessages((prev) => [
        ...prev,
        { text: '🐢 (352) 428-4009 - Available 24/7. Else, send a contact form. The form uses your preferred mail app.', from: 'bot' },
      ]);
    }, 600);
  };

  return (
    <div className="fixed z-30" style={{ bottom: '24px', right: '24px' }}>
      <AnimatePresence>
        {isOpen && (
          <motion.div
            initial={{ opacity: 0, scale: 0.8, y: 20 }}
            animate={{ opacity: 1, scale: 1, y: 0 }}
            exit={{ opacity: 0, scale: 0.8, y: 20 }}
            transition={{ type: 'spring', duration: 0.4 }}
            className="bg-[rgba(250,246,241,0.98)] backdrop-blur-[16px] rounded-2xl shadow-[0_8px_32px_rgba(0,0,0,0.15)] flex flex-col overflow-hidden"
            style={{ width: '380px', height: '500px', marginBottom: '16px' }}
          >
            {/* Header */}
            <div className="bg-turtle-green flex items-center justify-between px-5 py-4 shrink-0">
              <span className="font-body font-semibold text-white">Chat with Turtle Protect</span>
              <button onClick={() => setIsOpen(false)} className="text-white/80 hover:text-white transition-colors">
                <X size={20} />
              </button>
            </div>

            {/* Messages */}
            <div className="flex-1 overflow-y-auto px-4 py-4 flex flex-col" style={{ gap: '0.75rem' }}>
              {messages.map((msg, i) => (
                <div
                  key={i}
                  className={[
                    'max-w-[80%] px-4 py-2.5 rounded-2xl text-sm font-body',
                    msg.from === 'bot'
                      ? 'bg-white text-ink self-start rounded-bl-none'
                      : 'bg-turtle-green text-white self-end rounded-br-none',
                  ].join(' ')}
                >
                  {msg.text}
                </div>
              ))}

              {/* Quick replies */}
              {messages[messages.length - 1].from === 'bot' && (
                <div className="flex flex-wrap gap-2 mt-2">
                  {quickReplies.map((reply) => (
                    <button
                      key={reply}
                      onClick={() => handleQuickReply(reply)}
                      className="text-xs font-body bg-dawn-blush text-deep-forest px-3 py-1.5 rounded-full hover:bg-shell-gold/30 transition-colors"
                    >
                      {reply}
                    </button>
                  ))}
                </div>
              )}
            </div>

            {/* Input */}
            <div className="shrink-0 flex items-center gap-2 px-4 py-3 border-t border-pearl">
              <input
                type="text"
                value={inputValue}
                onChange={(e) => setInputValue(e.target.value)}
                onKeyDown={(e) => e.key === 'Enter' && handleSend()}
                placeholder="Type a message..."
                className="flex-1 bg-white border border-pearl rounded-lg px-3 py-2 text-sm font-body text-ink placeholder:text-stone-muted focus:outline-none focus:border-turtle-green"
              />
              <button
                onClick={handleSend}
                className="bg-turtle-green text-white p-2 rounded-lg hover:bg-deep-forest transition-colors"
              >
                <Send size={16} />
              </button>
            </div>
          </motion.div>
        )}
      </AnimatePresence>

      {/* Trigger button */}
      <motion.button
        onClick={() => setIsOpen(!isOpen)}
        className="bg-turtle-green text-white rounded-full flex items-center justify-center shadow-lg hover:bg-deep-forest transition-colors"
        style={{ width: '56px', height: '56px' }}
        animate={{ scale: [1, 1.05, 1] }}
        transition={{ duration: 2, repeat: Infinity, ease: [0.42, 0, 0.58, 1] as [number, number, number, number] }}
      >
        {isOpen ? <X size={24} /> : <MessageCircle size={24} />}
      </motion.button>
    </div>
  );
}
"""

let render() = file
