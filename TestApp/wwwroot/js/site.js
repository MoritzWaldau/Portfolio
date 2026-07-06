// Animations-Engine der Portfolio-Seite:
// Scroll-Reveal, Partikel-Konstellation, Typewriter, Buchstaben-Stagger, Zähler,
// Scrollspy + Progress-Bar, Parallax, scroll-gekoppelte Timeline, Tilt + Glare,
// Cursor-Glow, Material-Ripple.
// Blazor WASM rendert den DOM erst nach App-Start, daher registriert ein
// MutationObserver neu hinzukommende Elemente nach.
(function () {
    'use strict';

    const reducedMotion = window.matchMedia('(prefers-reduced-motion: reduce)').matches;
    const finePointer = window.matchMedia('(pointer: fine)').matches;

    // ---------- Scroll-Reveal ----------
    const revealObserver = reducedMotion ? null : new IntersectionObserver(entries => {
        for (const entry of entries) {
            if (entry.isIntersecting) {
                entry.target.classList.add('is-visible');
                revealObserver.unobserve(entry.target);
            }
        }
    }, { threshold: 0.15, rootMargin: '0px 0px -40px 0px' });

    function registerReveals(root) {
        if (!root.querySelectorAll) return;
        for (const el of root.querySelectorAll('.reveal:not(.is-visible)')) {
            if (reducedMotion) {
                el.classList.add('is-visible');
            } else {
                revealObserver.observe(el);
            }
        }
    }

    // ---------- Partikel-Konstellation im Hero (Canvas) ----------
    const particles = { canvas: null, ctx: null, dots: [], mouse: { x: -9999, y: -9999 } };

    function initParticles(canvas) {
        if (reducedMotion || canvas.dataset.bound) return;
        canvas.dataset.bound = 'true';
        particles.canvas = canvas;
        particles.ctx = canvas.getContext('2d');

        const sizeCanvas = () => {
            const dpr = Math.min(window.devicePixelRatio || 1, 2);
            const rect = canvas.parentElement.getBoundingClientRect();
            canvas.width = rect.width * dpr;
            canvas.height = rect.height * dpr;
            canvas.style.width = rect.width + 'px';
            canvas.style.height = rect.height + 'px';
            particles.ctx.setTransform(dpr, 0, 0, dpr, 0, 0);
            spawnDots(rect.width, rect.height);
        };

        const spawnDots = (w, h) => {
            const count = w < 768 ? 38 : 70;
            particles.dots = Array.from({ length: count }, () => ({
                x: Math.random() * w,
                y: Math.random() * h,
                vx: (Math.random() - 0.5) * 0.35,
                vy: (Math.random() - 0.5) * 0.35,
                r: 1 + Math.random() * 1.8,
            }));
        };

        sizeCanvas();
        window.addEventListener('resize', sizeCanvas);

        const hero = canvas.closest('.hero');
        hero.addEventListener('pointermove', e => {
            const rect = canvas.getBoundingClientRect();
            particles.mouse.x = e.clientX - rect.left;
            particles.mouse.y = e.clientY - rect.top;
        });
        hero.addEventListener('pointerleave', () => {
            particles.mouse.x = particles.mouse.y = -9999;
        });
    }

    function drawParticles() {
        const { canvas, ctx, dots, mouse } = particles;
        if (!canvas || !canvas.isConnected) return;
        const w = canvas.clientWidth, h = canvas.clientHeight;
        ctx.clearRect(0, 0, w, h);

        const LINK = 120, MOUSE_LINK = 170;
        for (const d of dots) {
            // sanfte Abstoßung vom Mauszeiger
            const dxm = d.x - mouse.x, dym = d.y - mouse.y;
            const distM = Math.hypot(dxm, dym);
            if (distM < 90 && distM > 0.01) {
                d.vx += (dxm / distM) * 0.04;
                d.vy += (dym / distM) * 0.04;
            }
            d.vx = Math.max(-0.6, Math.min(0.6, d.vx));
            d.vy = Math.max(-0.6, Math.min(0.6, d.vy));
            d.x += d.vx;
            d.y += d.vy;
            if (d.x < 0 || d.x > w) d.vx *= -1;
            if (d.y < 0 || d.y > h) d.vy *= -1;

            ctx.beginPath();
            ctx.arc(d.x, d.y, d.r, 0, Math.PI * 2);
            ctx.fillStyle = 'rgba(170, 205, 255, 0.65)';
            ctx.fill();
        }

        for (let i = 0; i < dots.length; i++) {
            const a = dots[i];
            for (let j = i + 1; j < dots.length; j++) {
                const b = dots[j];
                const dist = Math.hypot(a.x - b.x, a.y - b.y);
                if (dist < LINK) {
                    ctx.beginPath();
                    ctx.moveTo(a.x, a.y);
                    ctx.lineTo(b.x, b.y);
                    ctx.strokeStyle = `rgba(138, 185, 255, ${(0.35 * (1 - dist / LINK)).toFixed(3)})`;
                    ctx.lineWidth = 1;
                    ctx.stroke();
                }
            }
            const distM = Math.hypot(a.x - mouse.x, a.y - mouse.y);
            if (distM < MOUSE_LINK) {
                ctx.beginPath();
                ctx.moveTo(a.x, a.y);
                ctx.lineTo(mouse.x, mouse.y);
                ctx.strokeStyle = `rgba(125, 220, 255, ${(0.45 * (1 - distM / MOUSE_LINK)).toFixed(3)})`;
                ctx.lineWidth = 1;
                ctx.stroke();
            }
        }
    }

    // ---------- Typewriter in der Hero-Tagline ----------
    function initTypewriter(el) {
        if (el.dataset.bound) return;
        el.dataset.bound = 'true';
        const words = JSON.parse(el.dataset.typewriter);
        if (reducedMotion) {
            el.textContent = words[0];
            return;
        }
        let wordIdx = 0, charIdx = 0, deleting = false;
        const tick = () => {
            const word = words[wordIdx];
            charIdx += deleting ? -1 : 1;
            el.textContent = word.slice(0, charIdx);
            let delay = deleting ? 45 : 85;
            if (!deleting && charIdx === word.length) {
                delay = 1800;
                deleting = true;
            } else if (deleting && charIdx === 0) {
                deleting = false;
                wordIdx = (wordIdx + 1) % words.length;
                delay = 350;
            }
            setTimeout(tick, delay);
        };
        setTimeout(tick, 600);
    }

    // ---------- Buchstaben-Stagger für den Hero-Namen ----------
    function splitLetters(el) {
        if (el.dataset.split) return;
        el.dataset.split = 'true';
        if (reducedMotion) return;
        const text = el.textContent;
        el.textContent = '';
        el.setAttribute('aria-label', text);
        [...text].forEach((ch, i) => {
            const span = document.createElement('span');
            span.className = 'letter';
            span.setAttribute('aria-hidden', 'true');
            span.textContent = ch === ' ' ? ' ' : ch;
            span.style.animationDelay = (0.35 + i * 0.045) + 's';
            el.appendChild(span);
        });
    }

    // ---------- Zähler-Animation (Stats) ----------
    const countFormat = new Intl.NumberFormat('de-DE');

    function animateCounter(el) {
        if (el.dataset.done) return;
        el.dataset.done = 'true';
        const target = parseInt(el.dataset.countTo, 10);
        const suffix = el.dataset.suffix ?? '';
        if (reducedMotion) {
            el.textContent = countFormat.format(target) + suffix;
            return;
        }
        const duration = 1800;
        const start = performance.now();
        const step = now => {
            const t = Math.min(1, (now - start) / duration);
            const eased = 1 - Math.pow(2, -10 * t);          // easeOutExpo
            el.textContent = countFormat.format(Math.round(target * eased)) + suffix;
            if (t < 1) requestAnimationFrame(step);
            else el.textContent = countFormat.format(target) + suffix;
        };
        requestAnimationFrame(step);
    }

    const counterObserver = new IntersectionObserver(entries => {
        for (const entry of entries) {
            if (entry.isIntersecting) {
                animateCounter(entry.target);
                counterObserver.unobserve(entry.target);
            }
        }
    }, { threshold: 0.4 });

    // ---------- Tilt + Glare für Karten ----------
    function attachTilt(card) {
        if (card.dataset.tiltBound) return;
        card.dataset.tiltBound = 'true';
        card.addEventListener('pointermove', e => {
            const rect = card.getBoundingClientRect();
            const px = (e.clientX - rect.left) / rect.width;
            const py = (e.clientY - rect.top) / rect.height;
            card.style.transform =
                `perspective(800px) rotateX(${(-(py - 0.5) * 7).toFixed(2)}deg) rotateY(${((px - 0.5) * 7).toFixed(2)}deg) translateY(-6px)`;
            card.style.setProperty('--glare-x', (px * 100).toFixed(1) + '%');
            card.style.setProperty('--glare-y', (py * 100).toFixed(1) + '%');
        });
        card.addEventListener('pointerleave', () => {
            card.style.transform = '';
        });
    }

    // ---------- Spotlight-Karten (Radial-Glow folgt dem Zeiger) ----------
    function attachSpotlight(card) {
        if (card.dataset.spotBound || !finePointer) return;
        card.dataset.spotBound = 'true';
        card.addEventListener('pointermove', e => {
            const rect = card.getBoundingClientRect();
            card.style.setProperty('--spot-x', ((e.clientX - rect.left) / rect.width * 100).toFixed(1) + '%');
            card.style.setProperty('--spot-y', ((e.clientY - rect.top) / rect.height * 100).toFixed(1) + '%');
        });
    }

    // ---------- Mobiles Hamburger-Menü ----------
    // Läuft bewusst ohne Blazor (delegierte Listener): so reagiert die Navigation
    // sofort, auch während WASM noch lädt.
    function setNavMenu(open) {
        const collapse = document.querySelector('.site-navbar .navbar-collapse');
        const toggler = document.querySelector('.site-navbar .navbar-toggler');
        if (!collapse || !toggler) return;
        collapse.classList.toggle('show', open);
        toggler.setAttribute('aria-expanded', String(open));
    }

    document.addEventListener('click', e => {
        if (e.target.closest('.site-navbar .navbar-toggler')) {
            const collapse = document.querySelector('.site-navbar .navbar-collapse');
            setNavMenu(!(collapse && collapse.classList.contains('show')));
        } else if (e.target.closest('.site-navbar .nav-link')) {
            setNavMenu(false);
        }
    });

    // ---------- Copy-to-Clipboard (z.B. E-Mail-Button im Kontaktbereich) ----------
    document.addEventListener('click', e => {
        const btn = e.target.closest('[data-copy]');
        if (!btn || !navigator.clipboard) return;
        e.preventDefault();
        navigator.clipboard.writeText(btn.dataset.copy).then(() => {
            btn.classList.add('copied');
            clearTimeout(btn._copyTimeout);
            btn._copyTimeout = setTimeout(() => btn.classList.remove('copied'), 1600);
        });
    });

    // ---------- Command-Palette (Cmd/Ctrl+K) ----------
    function initCommandPalette(dotNetRef) {
        if (window.__cmdkBound) return;
        window.__cmdkBound = true;
        document.addEventListener('keydown', e => {
            const key = e.key.toLowerCase();
            if ((e.ctrlKey || e.metaKey) && key === 'k') {
                e.preventDefault();
                dotNetRef.invokeMethodAsync('Toggle');
            } else if (key === 'escape') {
                dotNetRef.invokeMethodAsync('CloseIfOpen');
            }
        });
    }
    window.initCommandPalette = initCommandPalette;

    // ---------- Back-to-top ----------
    function initBackToTop() {
        const btn = document.querySelector('[data-back-to-top]');
        if (!btn || btn.dataset.bound) return;
        btn.dataset.bound = 'true';
        btn.addEventListener('click', () => {
            window.scrollTo({ top: 0, behavior: reducedMotion ? 'auto' : 'smooth' });
        });
    }

    // ---------- Material-Ripple auf Buttons ----------
    document.addEventListener('click', e => {
        if (reducedMotion) return;
        const btn = e.target.closest('.btn');
        if (!btn) return;
        const rect = btn.getBoundingClientRect();
        const size = Math.max(rect.width, rect.height) * 2;
        const ripple = document.createElement('span');
        ripple.className = 'ripple';
        ripple.style.width = ripple.style.height = size + 'px';
        ripple.style.left = (e.clientX - rect.left - size / 2) + 'px';
        ripple.style.top = (e.clientY - rect.top - size / 2) + 'px';
        btn.appendChild(ripple);
        ripple.addEventListener('animationend', () => ripple.remove());
    });

    // ---------- Cursor-Glow ----------
    const glow = { el: null, x: -500, y: -500, tx: -500, ty: -500 };

    function initCursorGlow() {
        if (reducedMotion || !finePointer || glow.el) return;
        glow.el = document.createElement('div');
        glow.el.id = 'cursor-glow';
        glow.el.setAttribute('aria-hidden', 'true');
        document.body.appendChild(glow.el);
        window.addEventListener('pointermove', e => {
            glow.tx = e.clientX;
            glow.ty = e.clientY;
        });
    }

    function drawCursorGlow() {
        if (!glow.el) return;
        glow.x += (glow.tx - glow.x) * 0.12;                 // Lerp-Nachlauf
        glow.y += (glow.ty - glow.y) * 0.12;
        glow.el.style.transform = `translate(${glow.x.toFixed(1)}px, ${glow.y.toFixed(1)}px)`;
    }

    // ---------- Scroll-Effekte: Navbar, Progress, Parallax, Timeline, Scrollspy ----------
    let progressBar = null;

    function initProgressBar() {
        if (progressBar) return;
        progressBar = document.createElement('div');
        progressBar.id = 'scroll-progress';
        progressBar.setAttribute('aria-hidden', 'true');
        document.body.appendChild(progressBar);
    }

    const SECTION_IDS = ['start', 'ueber-mich', 'skills', 'projekte', 'werdegang', 'kontakt'];

    function updateScrollFx() {
        const y = window.scrollY;

        const nav = document.querySelector('.site-navbar');
        if (nav) nav.classList.toggle('scrolled', y > 24);

        const backToTop = document.querySelector('[data-back-to-top]');
        if (backToTop) backToTop.classList.toggle('visible', y > 600);

        if (progressBar) {
            const max = document.documentElement.scrollHeight - window.innerHeight;
            progressBar.style.transform = `scaleX(${max > 0 ? (y / max).toFixed(4) : 0})`;
        }

        if (!reducedMotion) {
            // Parallax: Ambient-Orbs driften gegen den Scroll, Hero-Inhalt schiebt sich raus
            const ambient = document.querySelector('.ambient');
            if (ambient) ambient.style.transform = `translateY(${(-y * 0.06).toFixed(1)}px)`;
            const heroInner = document.querySelector('.hero .container');
            if (heroInner) {
                const heroH = heroInner.closest('.hero').offsetHeight || 1;
                const p = Math.min(1, y / heroH);
                heroInner.style.transform = `translateY(${(y * 0.3).toFixed(1)}px)`;
                heroInner.style.opacity = (1 - p * 0.9).toFixed(3);
            }

            // Timeline: Linie wächst mit der Scroll-Position, Marker zünden nacheinander
            const tl = document.querySelector('.timeline');
            if (tl) {
                const rect = tl.getBoundingClientRect();
                const vh = window.innerHeight;
                const progress = Math.max(0, Math.min(1, (vh * 0.8 - rect.top) / rect.height));
                tl.style.setProperty('--tl-progress', progress.toFixed(4));
                const lineEnd = rect.top + progress * rect.height;
                for (const entry of tl.querySelectorAll('.timeline-entry')) {
                    const markerY = entry.getBoundingClientRect().top + 14;
                    entry.classList.toggle('lit', markerY <= lineEnd);
                }
            }
        }

        // Scrollspy: aktiven Abschnitt im Menü markieren
        let current = SECTION_IDS[0];
        for (const id of SECTION_IDS) {
            const sec = document.getElementById(id);
            if (sec && sec.getBoundingClientRect().top <= 120) current = id;
        }
        for (const link of document.querySelectorAll('.site-navbar .nav-link')) {
            const href = link.getAttribute('href') ?? '';
            link.classList.toggle('active', href.endsWith('#' + current));
        }
    }

    let scrollQueued = false;
    window.addEventListener('scroll', () => {
        if (scrollQueued) return;
        scrollQueued = true;
        requestAnimationFrame(() => {
            scrollQueued = false;
            updateScrollFx();
        });
    }, { passive: true });

    // ---------- zentraler rAF-Loop (Canvas + Cursor-Glow) ----------
    function loop() {
        drawParticles();
        drawCursorGlow();
        requestAnimationFrame(loop);
    }
    if (!reducedMotion) requestAnimationFrame(loop);

    // ---------- Registrierung neuer Blazor-Inhalte ----------
    function scan(root) {
        if (!root.querySelectorAll) return;
        registerReveals(root);
        root.querySelectorAll('.tilt').forEach(attachTilt);
        root.querySelectorAll('.spot-card').forEach(attachSpotlight);
        root.querySelectorAll('[data-typewriter]').forEach(initTypewriter);
        root.querySelectorAll('.split-letters').forEach(splitLetters);
        root.querySelectorAll('[data-count-to]').forEach(el => {
            if (reducedMotion) animateCounter(el);
            else counterObserver.observe(el);
        });
        root.querySelectorAll('canvas.hero-canvas').forEach(initParticles);
        initBackToTop();
        updateScrollFx();
    }

    new MutationObserver(mutations => {
        for (const m of mutations) {
            for (const node of m.addedNodes) {
                if (node.nodeType === Node.ELEMENT_NODE) scan(node.parentElement ?? node);
            }
        }
    }).observe(document.body, { childList: true, subtree: true });

    initProgressBar();
    initCursorGlow();
    scan(document);

    // Test-/Debug-Zugriff (z.B. für Verifikation in der Preview)
    window.__siteFx = { scan, updateScrollFx, drawParticles, particles, animateCounter, attachSpotlight };
})();
