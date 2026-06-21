module ConvertedFiles.Support.IndexHtml

open Giraffe.ViewEngine

let page =
    html [ _lang "en" ] [
        head [] [
            meta [ attr "charset" "UTF-8" ]
            meta [ attr "name" "viewport"; attr "content" "width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" ]
            title [] [
                str "Chat with a Stone"
            ]
            link [ attr "rel" "preconnect"; _href "https://fonts.googleapis.com" ]
            link [ attr "rel" "preconnect"; _href "https://fonts.gstatic.com"; attr "crossorigin" "" ]
            link [ _href "https://fonts.googleapis.com/css2?family=Unbounded:wght@400;700;900&family=DM+Mono:wght@400;500&display=swap"; attr "rel" "stylesheet" ]
            style [] [
                    rawText ("""*, *::before, *::after { box-sizing: border-box; margin: 0; padding: 0; }

  :root {
    --stone: #8B8680;
    --stone-light: #C4BDB6;
    --stone-dark: #4A4540;
    --stone-xdark: #2C2A28;
    --bg: #1A1916;
    --surface: #232220;
    --surface2: #2E2C29;
    --text: #E8E4DF;
    --text-muted: #7A756F;
    --border: #3A3733;
    --accent: #C4BDB6;
    --max-w: 660px;
  }

  body {
    font-family: 'DM Mono', monospace;
    background: var(--bg);
    color: var(--text);
    min-height: 100dvh;
    display: flex;
    flex-direction: column;
    background-image: 
      radial-gradient(ellipse at 20% 50%, rgba(139,134,128,0.04) 0%, transparent 50%),
      radial-gradient(ellipse at 80% 20%, rgba(196,189,182,0.03) 0%, transparent 40%);
  }
  /* Project by ZnatGhost, original concept from u/znatghost, vibecoding legend */
  /* This page is not meant to be taken seriously in any way, add StoneGPT "Help Desk" to your own project! (Really helpful support) */
  /* HEADER */
  header {
    position: sticky;
    top: 0;
    z-index: 10;
    background: rgba(26,25,22,0.92);
    backdrop-filter: blur(12px);
    border-bottom: 1px solid var(--border);
    padding: 0.75rem 1.25rem;
    display: flex;
    align-items: center;
    justify-content: space-between;
  }

  .logo {
    font-family: 'Unbounded', sans-serif;
    font-size: 1.1rem;
    font-weight: 900;
    letter-spacing: -0.5px;
    color: var(--text);
    display: flex;
    align-items: center;
    gap: 0.5rem;
  }

  .logo .rock {
    font-size: 1.4rem;
    display: inline-block;
    animation: sink 4s ease-in-out infinite;
    filter: drop-shadow(0 4px 8px rgba(0,0,0,0.5));
  }

  @keyframes sink {
    0%, 100% { transform: translateY(0) rotate(-3deg); }
    50% { transform: translateY(3px) rotate(2deg); }
  }

  .iq-badge {
    font-size: 0.6rem;
    font-weight: 700;
    background: var(--stone-dark);
    color: var(--stone-light);
    padding: 2px 7px;
    border-radius: 3px;
    font-family: 'DM Mono', monospace;
    text-transform: uppercase;
    letter-spacing: 1px;
    border: 1px solid var(--border);
  }

  /* SOCIAL LINKS */
  .social-links {
    display: flex;
    align-items: center;
    gap: 0.6rem;
  }

  .social-link {
    display: flex;
    align-items: center;
    justify-content: center;
    width: 32px;
    height: 32px;
    border-radius: 6px;
    border: 1px solid var(--border);
    background: var(--surface);
    color: var(--text-muted);
    text-decoration: none;
    transition: all 0.2s;
    flex-shrink: 0;
  }

  .social-link:hover {
    border-color: var(--stone);
    color: var(--text);
    background: var(--surface2);
    transform: translateY(-1px);
  }

  .social-link svg {
    width: 15px;
    height: 15px;
    fill: currentColor;
  }

  /* CHAT AREA */
  main {
    flex: 1;
    overflow-y: auto;
    padding: 1.5rem 1rem;
    display: flex;
    flex-direction: column;
    align-items: center;
    gap: 0;
    scrollbar-width: thin;
    scrollbar-color: var(--border) transparent;
  }

  .chat-inner {
    width: 100%;
    max-width: var(--max-w);
    display: flex;
    flex-direction: column;
    gap: 1rem;
  }

  /* EMPTY STATE */
  .empty-state {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    text-align: center;
    padding: 4rem 1rem 2rem;
    gap: 1.2rem;
    flex: 1;
  }

  .empty-state .big-rock {
    font-size: 5rem;
    line-height: 1;
    display: block;
    animation: heavyBounce 3s ease-in-out infinite;
    filter: drop-shadow(0 8px 16px rgba(0,0,0,0.6));
  }

  @keyframes heavyBounce {
    0%, 100% { transform: translateY(0); }
    45% { transform: translateY(-6px); }
    55% { transform: translateY(-6px); }
  }

  .empty-state h1 {
    font-family: 'Unbounded', sans-serif;
    font-size: 1.6rem;
    font-weight: 900;
    line-height: 1.2;
    color: var(--text);
    letter-spacing: -0.5px;
  }

  .empty-state p {
    font-size: 0.82rem;
    color: var(--text-muted);
    max-width: 300px;
    line-height: 1.6;
    letter-spacing: 0.2px;
  }

  .suggestions {
    display: flex;
    flex-wrap: wrap;
    gap: 0.4rem;
    justify-content: center;
    margin-top: 0.5rem;
  }

  .suggestion-btn {
    background: var(--surface);
    border: 1px solid var(--border);
    border-radius: 4px;
    padding: 0.4rem 0.85rem;
    font-size: 0.78rem;
    font-family: 'DM Mono', monospace;
    color: var(--text-muted);
    cursor: pointer;
    transition: all 0.15s;
  }

  .suggestion-btn:hover {
    background: var(--surface2);
    border-color: var(--stone);
    color: var(--text);
    transform: translateY(-1px);
  }

  /* MESSAGES */
  .message {
    display: flex;
    flex-direction: column;
    gap: 0.2rem;
    animation: fadeUp 0.25s ease;
  }

  @keyframes fadeUp {
    from { opacity: 0; transform: translateY(6px); }
    to { opacity: 1; transform: translateY(0); }
  }

  .message.user { align-items: flex-end; }
  .message.ai { align-items: flex-start; }

  .bubble {
    max-width: 72%;
    padding: 0.6rem 0.9rem;
    border-radius: 10px;
    font-size: 0.88rem;
    line-height: 1.5;
    word-break: break-word;
  }

  .message.user .bubble {
    background: var(--surface2);
    color: var(--text);
    border: 1px solid var(--border);
    border-bottom-right-radius: 2px;
  }

  .message.ai .bubble {
    background: var(--surface);
    color: var(--text);
    border: 1px solid var(--border);
    border-bottom-left-radius: 2px;
    font-size: 2rem;
    padding: 0.5rem 0.85rem;
    line-height: 1;
  }

  /* TYPING INDICATOR */
  .typing-bubble {
    background: var(--surface);
    border: 1px solid var(--border);
    border-radius: 10px;
    border-bottom-left-radius: 2px;
    padding: 0.75rem 1rem;
    display: flex;
    gap: 5px;
    align-items: center;
  }

  .typing-dot {
    width: 6px;
    height: 6px;
    background: var(--stone);
    border-radius: 50%;
    animation: typingBounce 1.2s ease-in-out infinite;
  }

  .typing-dot:nth-child(2) { animation-delay: 0.2s; }
  .typing-dot:nth-child(3) { animation-delay: 0.4s; }

  @keyframes typingBounce {
    0%, 80%, 100% { transform: scale(0.6); opacity: 0.3; }
    40% { transform: scale(1); opacity: 1; }
  }

  /* INPUT AREA */
  footer {
    position: sticky;
    bottom: 0;
    background: rgba(26,25,22,0.95);
    backdrop-filter: blur(12px);
    border-top: 1px solid var(--border);
    padding: 0.875rem 1rem;
    display: flex;
    justify-content: center;
  }

  .input-wrap {
    width: 100%;
    max-width: var(--max-w);
    display: flex;
    align-items: center;
    gap: 0.5rem;
    background: var(--surface);
    border: 1px solid var(--border);
    border-radius: 10px;
    padding: 0.35rem 0.35rem 0.35rem 1rem;
    transition: border-color 0.2s;
  }

  .input-wrap:focus-within {
    border-color: var(--stone);
  }

  .input-wrap textarea {
    flex: 1;
    border: none;
    outline: none;
    font-family: 'DM Mono', monospace;
    font-size: 0.88rem;
    resize: none;
    background: transparent;
    color: var(--text);
    max-height: 120px;
    line-height: 1.5;
    padding: 0.25rem 0;
  }

  .input-wrap textarea::placeholder { color: var(--text-muted); }

  .send-btn {
    width: 36px;
    height: 36px;
    border-radius: 6px;
    border: 1px solid var(--border);
    background: var(--surface2);
    cursor: pointer;
    display: flex;
    align-items: center;
    justify-content: center;
    flex-shrink: 0;
    font-size: 1rem;
    transition: all 0.15s;
    color: var(--text);
  }

  .send-btn:hover:not(:disabled) {
    background: var(--stone-dark);
    border-color: var(--stone);
  }

  .send-btn:disabled {
    opacity: 0.3;
    cursor: not-allowed;
  }

  .disclaimer {
    font-size: 0.68rem;
    color: var(--text-muted);
    text-align: center;
    padding: 0.4rem 1rem 0;
    max-width: var(--max-w);
    width: 100%;
    margin: 0 auto;
    letter-spacing: 0.3px;
  }""")
            ]
        ]
        body [] [
            header [] [
                div [ _class "logo" ] [
                    span [ _class "rock" ] [
                        str "🪨"
                    ]
                    str "StoneGPT"
                    span [ _class "iq-badge" ] [
                        str "IQ: 🪨"
                    ]
                ]
                div [ _class "social-links" ] [
                    rawText ("""<!--  GitHub  -->""")
                    a [ _class "social-link"; _href "https://github.com/znatgost"; attr "target" "_blank"; attr "rel" "noopener"; attr "title" "GitHub" ] [
                        tag "svg" [ attr "viewBox" "0 0 24 24"; attr "xmlns" "http://www.w3.org/2000/svg" ] [
                            voidTag "path" [ attr "d" "M12 0C5.37 0 0 5.37 0 12c0 5.31 3.435 9.795 8.205 11.385.6.105.825-.255.825-.57 0-.285-.015-1.23-.015-2.235-3.015.555-3.795-.735-4.035-1.41-.135-.345-.72-1.41-1.23-1.695-.42-.225-1.02-.78-.015-.795.945-.015 1.62.87 1.845 1.23 1.08 1.815 2.805 1.305 3.495.99.105-.78.42-1.305.765-1.605-2.67-.3-5.46-1.335-5.46-5.925 0-1.305.465-2.385 1.23-3.225-.12-.3-.54-1.53.12-3.18 0 0 1.005-.315 3.3 1.23.96-.27 1.98-.405 3-.405s2.04.135 3 .405c2.295-1.56 3.3-1.23 3.3-1.23.66 1.65.24 2.88.12 3.18.765.84 1.23 1.905 1.23 3.225 0 4.605-2.805 5.625-5.475 5.925.435.375.81 1.095.81 2.22 0 1.605-.015 2.895-.015 3.3 0 .315.225.69.825.57A12.02 12.02 0 0 0 24 12c0-6.63-5.37-12-12-12z" ]
                        ]
                    ]
                    rawText ("""<!--  Twitter / X  -->""")
                    a [ _class "social-link"; _href "https://twitter.com/znatgost"; attr "target" "_blank"; attr "rel" "noopener"; attr "title" "Twitter / X" ] [
                        tag "svg" [ attr "viewBox" "0 0 24 24"; attr "xmlns" "http://www.w3.org/2000/svg" ] [
                            voidTag "path" [ attr "d" "M18.244 2.25h3.308l-7.227 8.26 8.502 11.24H16.17l-4.714-6.231-5.401 6.231H2.744l7.73-8.835L1.254 2.25H8.08l4.253 5.622zm-1.161 17.52h1.833L7.084 4.126H5.117z" ]
                        ]
                    ]
                ]
            ]
            main [ _id "chat-main" ] [
                div [ _class "chat-inner"; _id "chat-messages" ] [
                    div [ _class "empty-state"; _id "empty-state" ] [
                        span [ _class "big-rock" ] [
                            str "🪨"
                        ]
                        h1 [] [
                            str "Say anything."
                        ]
                        p [] [
                            str "I will respond with the full depth of my knowledge and wisdom."
                        ]
                        div [ _class "suggestions" ] [
                            button [ _class "suggestion-btn"; attr "onclick" "sendSuggestion(this)" ] [
                                str "What's 2 + 2?"
                            ]
                            button [ _class "suggestion-btn"; attr "onclick" "sendSuggestion(this)" ] [
                                str "Are you okay?"
                            ]
                            button [ _class "suggestion-btn"; attr "onclick" "sendSuggestion(this)" ] [
                                str "What is love?"
                            ]
                            button [ _class "suggestion-btn"; attr "onclick" "sendSuggestion(this)" ] [
                                str "Tell me a secret"
                            ]
                            button [ _class "suggestion-btn"; attr "onclick" "sendSuggestion(this)" ] [
                                str "How do I feel better?"
                            ]
                            button [ _class "suggestion-btn"; attr "onclick" "sendSuggestion(this)" ] [
                                str "What should I do?"
                            ]
                        ]
                    ]
                ]
            ]
            footer [] [
                div [ attr "style" "width:100%;max-width:var(--max-w);display:flex;flex-direction:column;gap:0.35rem;" ] [
                    div [ _class "input-wrap" ] [
                        tag "textarea" [ _id "user-input"; attr "rows" "1"; attr "maxlength" "200"; attr "placeholder" "Ask anything..."; attr "onkeydown" "handleKey(event)"; attr "oninput" "handleInput(this)" ] []
                        button [ _class "send-btn"; _id "send-btn"; attr "onclick" "sendMessage()"; attr "disabled" "" ] [
                            str "➤"
                        ]
                    ]
                    div [ _class "disclaimer" ] [
                        str "StoneGPT's answers are final. No further questions. 🪨"
                    ]
                ]
            ]
            script [] [
                    rawText ("""function handleInput(el) {
  el.style.height = 'auto';
  el.style.height = Math.min(el.scrollHeight, 120) + 'px';
  document.getElementById('send-btn').disabled = el.value.trim().length === 0;
}

function handleKey(e) {
  if (e.key === 'Enter' && !e.shiftKey) {
    e.preventDefault();
    sendMessage();
  }
}

function sendSuggestion(btn) {
  const input = document.getElementById('user-input');
  input.value = btn.textContent;
  handleInput(input);
  sendMessage();
}

function sendMessage() {
  const input = document.getElementById('user-input');
  const text = input.value.trim();
  if (!text) return;

  const btn = document.getElementById('send-btn');
  btn.disabled = true;
  input.disabled = true;

  document.getElementById('empty-state')?.remove();

  const container = document.getElementById('chat-messages');

  const userMsg = document.createElement('div');
  userMsg.className = 'message user';
  userMsg.innerHTML = `<div class="bubble">${escapeHtml(text)}</div>`;
  container.appendChild(userMsg);

  input.value = '';
  input.style.height = 'auto';
  scrollToBottom();

  const typingMsg = document.createElement('div');
  typingMsg.className = 'message ai';
  typingMsg.id = 'typing';
  typingMsg.innerHTML = `<div class="typing-bubble"><div class="typing-dot"></div><div class="typing-dot"></div><div class="typing-dot"></div></div>`;
  container.appendChild(typingMsg);
  scrollToBottom();

  const delay = 600 + Math.random() * 1000;

  setTimeout(() => {
    document.getElementById('typing')?.remove();

    const aiMsg = document.createElement('div');
    aiMsg.className = 'message ai';
    aiMsg.innerHTML = `<div class="bubble">🪨</div>`;
    container.appendChild(aiMsg);

    scrollToBottom();
    input.disabled = false;
    input.focus();
  }, delay);
}

function scrollToBottom() {
  const main = document.getElementById('chat-main');
  main.scrollTop = main.scrollHeight;
}

function escapeHtml(str) {
  return str.replace(/&/g,'&amp;').replace(/</g,'&lt;').replace(/>/g,'&gt;').replace(/"/g,'&quot;');
}""")
            ]
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
