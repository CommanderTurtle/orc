module ConvertedFiles.Assets.Js.MainJs

let file = """// ============================================================
// sHEL Site JavaScript
// Copy buttons, sticky header, scroll reveals, TOC, tabs, calendar
// ============================================================

(function() {
  'use strict';

  // --- Sticky Header Shadow ---
  const header = document.getElementById('site-header');
  if (header) {
    window.addEventListener('scroll', function() {
      header.classList.toggle('scrolled', window.scrollY > 10);
    }, { passive: true });
  }

  // --- Smooth Scroll Reveal Animations (vllm.ai style) ---
  const revealElements = document.querySelectorAll('.reveal');
  if (revealElements.length > 0) {
    const revealObserver = new IntersectionObserver(function(entries) {
      entries.forEach(function(entry) {
        if (entry.isIntersecting) {
          entry.target.classList.add('revealed');
          revealObserver.unobserve(entry.target);
        }
      });
    }, {
      threshold: 0.05,
      rootMargin: '0px 0px -30px 0px'
    });
    revealElements.forEach(function(el) {
      revealObserver.observe(el);
    });
  }

  // --- Copy-to-Clipboard for Code Blocks (strips $ prompt) ---
  function stripPrompt(text) {
    // Remove leading $ or > prompts, optionally followed by a space
    return text.replace(/^\s*[$>]\s?/gm, '').trim();
  }

  function createCopyButton() {
    var btn = document.createElement('button');
    btn.className = 'copy-btn';
    btn.setAttribute('aria-label', 'Copy code');
    btn.innerHTML = '<svg viewBox="0 0 16 16" fill="none" stroke="currentColor" stroke-width="1.5"><rect x="3" y="3" width="7" height="7" rx="1"/><path d="M6 6h5a1 1 0 011 1v5a1 1 0 01-1 1H7a1 1 0 01-1-1V6" opacity="0.6"/></svg>';
    return btn;
  }

  function initCopyButtons() {
    document.querySelectorAll('pre').forEach(function(pre) {
      if (pre.parentElement && pre.parentElement.classList.contains('code-block-wrapper')) return;
      if (pre.closest('.code-wrapper')) return;

      var wrapper = document.createElement('div');
      wrapper.className = 'code-block-wrapper';
      pre.parentNode.insertBefore(wrapper, pre);
      wrapper.appendChild(pre);

      var btn = createCopyButton();
      wrapper.appendChild(btn);

      btn.addEventListener('click', function() {
        var code = pre.querySelector('code');
        var raw = code ? code.textContent : pre.textContent;
        var clean = stripPrompt(raw);
        navigator.clipboard.writeText(clean).then(function() {
          btn.classList.add('copied');
          btn.innerHTML = '<svg viewBox="0 0 16 16" fill="none" stroke="currentColor" stroke-width="1.5"><path d="M3 8l3.5 3.5L13 5"/></svg>';
          setTimeout(function() {
            btn.classList.remove('copied');
            btn.innerHTML = '<svg viewBox="0 0 16 16" fill="none" stroke="currentColor" stroke-width="1.5"><rect x="3" y="3" width="7" height="7" rx="1"/><path d="M6 6h5a1 1 0 011 1v5a1 1 0 01-1 1H7a1 1 0 01-1-1V6" opacity="0.6"/></svg>';
          }, 2000);
        }).catch(function() {
          var textarea = document.createElement('textarea');
          textarea.value = clean;
          textarea.style.position = 'fixed';
          textarea.style.opacity = '0';
          document.body.appendChild(textarea);
          textarea.select();
          try { document.execCommand('copy'); } catch(e) {}
          document.body.removeChild(textarea);
        });
      });
    });
  }
  initCopyButtons();

  // --- Table of Contents ---
  var tocList = document.getElementById('toc-list');
  var postContent = document.querySelector('.post-content');

  if (tocList && postContent) {
    var headings = postContent.querySelectorAll('h2, h3');
    if (headings.length > 0) {
      headings.forEach(function(heading, index) {
        if (!heading.id) heading.id = 'section-' + index;
        var li = document.createElement('li');
        var a = document.createElement('a');
        a.href = '#' + heading.id;
        a.textContent = heading.textContent;
        a.className = heading.tagName.toLowerCase() === 'h3' ? 'toc-h3' : 'toc-h2';
        a.dataset.target = heading.id;
        a.addEventListener('click', function(e) {
          e.preventDefault();
          heading.scrollIntoView({ behavior: 'smooth', block: 'start' });
          history.pushState(null, null, '#' + heading.id);
        });
        li.appendChild(a);
        tocList.appendChild(li);
      });

      var tocLinks = tocList.querySelectorAll('a');
      var tocObserver = new IntersectionObserver(function(entries) {
        entries.forEach(function(entry) {
          if (entry.isIntersecting) {
            tocLinks.forEach(function(l) { l.classList.remove('active'); });
            var active = tocList.querySelector('a[data-target="' + entry.target.id + '"]');
            if (active) active.classList.add('active');
          }
        });
      }, { threshold: 0, rootMargin: '-80px 0px -60% 0px' });
      headings.forEach(function(h) { tocObserver.observe(h); });
    } else {
      var tocNav = document.getElementById('toc-nav');
      if (tocNav) tocNav.style.display = 'none';
    }
  }

  // --- Install Block (tabs + copy) ---
  var installTabs = document.querySelectorAll('.tab-btn');
  var installCodeBlock = document.querySelector('.install-block .code-block');
  var installCodeWrapper = document.querySelector('.install-block .code-wrapper');

  if (installTabs.length > 0 && installCodeBlock) {
    var installCommands = {
      'macos': { html: '<span class="code-prompt">$</span>brew install shel', plain: 'brew install shel' },
      'linux': { html: '<span class="code-prompt">$</span>curl -fsSL https://shel.sh/install.sh | sh', plain: 'curl -fsSL https://shel.sh/install.sh | sh' },
      'cargo': { html: '<span class="code-prompt">$</span>cargo install shel-cli', plain: 'cargo install shel-cli' },
      'windows': { html: '<span class="code-prompt">></span>winget install shel', plain: 'winget install shel' },
      'docker': { html: '<span class="code-prompt">$</span>docker pull shel/shel-cli', plain: 'docker pull shel/shel-cli' }
    };

    if (installCodeWrapper) {
      var btn = createCopyButton();
      btn.style.opacity = '1';
      btn.setAttribute('aria-label', 'Copy install command');
      installCodeWrapper.appendChild(btn);

      btn.addEventListener('click', function() {
        var activeTab = document.querySelector('.tab-btn.active');
        var tabName = activeTab ? activeTab.dataset.tab : 'macos';
        var cmd = installCommands[tabName];
        var text = cmd ? cmd.plain : 'brew install shel';
        navigator.clipboard.writeText(text).then(function() {
          btn.classList.add('copied');
          btn.innerHTML = '<svg viewBox="0 0 16 16" fill="none" stroke="currentColor" stroke-width="1.5"><path d="M3 8l3.5 3.5L13 5"/></svg>';
          setTimeout(function() {
            btn.classList.remove('copied');
            btn.innerHTML = '<svg viewBox="0 0 16 16" fill="none" stroke="currentColor" stroke-width="1.5"><rect x="3" y="3" width="7" height="7" rx="1"/><path d="M6 6h5a1 1 0 011 1v5a1 1 0 01-1 1H7a1 1 0 01-1-1V6" opacity="0.6"/></svg>';
          }, 2000);
        });
      });
    }

    installTabs.forEach(function(tab) {
      tab.addEventListener('click', function() {
        installTabs.forEach(function(t) { t.classList.remove('active'); });
        tab.classList.add('active');
        var cmd = installCommands[tab.dataset.tab];
        if (cmd) installCodeBlock.innerHTML = cmd.html;
      });
    });
  }

  // --- Functional Calendar ---
  var calendarDays = document.querySelectorAll('.calendar-day[data-events]');
  var eventPopup = null;

  var activePopupDay = null;

  function showEventPopup(dayEl, events) {
    // If clicking the same day that already has a popup open, close it
    if (eventPopup && activePopupDay === dayEl) {
      eventPopup.remove();
      eventPopup = null;
      activePopupDay = null;
      return;
    }
    // Close any existing popup from a different day
    if (eventPopup) { eventPopup.remove(); eventPopup = null; }
    if (!events || events.length === 0) return;

    var popup = document.createElement('div');
    popup.className = 'event-popup';
    var content = '<div class="event-popup-header">' + dayEl.querySelector('.day-number').textContent + ' Events</div>';
    events.forEach(function(ev) {
      content += '<a href="' + ev.url + '" class="event-popup-item">' +
        '<span class="event-popup-dot" style="background:' + ev.color + '"></span>' +
        '<span class="event-popup-text">' + ev.title + '</span>' +
        '</a>';
    });
    popup.innerHTML = content;
    document.body.appendChild(popup);
    eventPopup = popup;
    activePopupDay = dayEl;

    var rect = dayEl.getBoundingClientRect();
    popup.style.left = (rect.left + rect.width / 2 - popup.offsetWidth / 2) + 'px';
    popup.style.top = (rect.bottom + 8) + 'px';
  }

  // Calendar day click handlers — show popup for ALL event days (single or multiple)
  document.querySelectorAll('.calendar-day[data-events]').forEach(function(day) {
    day.addEventListener('click', function(e) {
      e.stopPropagation();
      var events = [];
      try { events = JSON.parse(day.dataset.events); } catch(err) {}
      if (events.length > 0) {
        showEventPopup(day, events);
      }
    });
    day.style.cursor = 'pointer';
  });

  // Close popup when clicking anywhere outside
  document.addEventListener('click', function(e) {
    if (eventPopup && !eventPopup.contains(e.target) && !e.target.closest('.calendar-day')) {
      eventPopup.remove();
      eventPopup = null;
      activePopupDay = null;
    }
  });

  // Close popup on scroll
  window.addEventListener('scroll', function() {
    if (eventPopup) { eventPopup.remove(); eventPopup = null; activePopupDay = null; }
  }, { passive: true });

  // --- Mobile Menu ---
  var navTrigger = document.getElementById('nav-trigger');
  if (navTrigger) {
    document.querySelectorAll('.nav-items a').forEach(function(link) {
      link.addEventListener('click', function() { navTrigger.checked = false; });
    });
  }

  // --- Smooth scroll for anchors ---
  document.querySelectorAll('a[href^="#"]').forEach(function(anchor) {
    anchor.addEventListener('click', function(e) {
      var targetId = this.getAttribute('href');
      if (targetId === '#') return;
      var target = document.querySelector(targetId);
      if (target) { e.preventDefault(); target.scrollIntoView({ behavior: 'smooth', block: 'start' }); }
    });
  });

})();
"""

let render() = file
