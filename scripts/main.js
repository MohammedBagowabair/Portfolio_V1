//// Initialize AOS (Animate On Scroll)
//document.addEventListener('DOMContentLoaded', function () {
//    AOS.init({
//        duration: 800,
//        easing: 'ease-in-out',
//        once: true,
//        offset: 100
//    });
//});

//// Portfolio App Alpine.js Component
//function portfolioApp() {
//    return {
//        // State
//        darkMode: localStorage.getItem('darkMode') !== null
//            ? localStorage.getItem('darkMode') === 'true'
//            : true,
//        mobileMenuOpen: false,
//        scrolled: false,
//        activeSection: 'home',
//        isSubmitting: false,

//        // Form data
//        form: {
//            name: '',
//            email: '',
//            subject: '',
//            message: ''
//        },

//        // Initialize
//        init() {
//            // Apply saved theme
//            this.applyTheme();

//            // Watch for theme changes
//            this.$watch('darkMode', (value) => {
//                localStorage.setItem('darkMode', value);
//                this.applyTheme();
//            });

//            // Set up scroll listener
//            this.setupScrollListener();

//            // Set up smooth scrolling for navigation links
//            this.setupSmoothScrolling();

//            // Close mobile menu when clicking outside
//            document.addEventListener('click', (e) => {
//                if (!e.target.closest('.navbar') && this.mobileMenuOpen) {
//                    this.mobileMenuOpen = false;
//                }
//            });
//        },

//        // Apply theme
//        applyTheme() {
//            if (this.darkMode) {
//                document.documentElement.classList.add('dark');
//            } else {
//                document.documentElement.classList.remove('dark');
//            }
//        },

//        // Set up scroll listener
//        setupScrollListener() {
//            let ticking = false;

//            window.addEventListener('scroll', () => {
//                if (!ticking) {
//                    requestAnimationFrame(() => {
//                        this.handleScroll();
//                        ticking = false;
//                    });
//                    ticking = true;
//                }
//            });
//        },

//        // Handle scroll events
//        handleScroll() {
//            const scrollTop = window.pageYOffset || document.documentElement.scrollTop;

//            // Update scrolled state
//            this.scrolled = scrollTop > 50;

//            // Update active section
//            this.updateActiveSection();
//        },

//        // Update active section based on scroll position
//        updateActiveSection() {
//            const sections = ['home', 'about', 'skills', 'projects', 'services', 'education', 'contact'];
//            const scrollPosition = window.scrollY + 200;

//            for (let section of sections) {
//                const element = document.getElementById(section);
//                if (element) {
//                    const offsetTop = element.offsetTop;
//                    const offsetHeight = element.offsetHeight;

//                    if (scrollPosition >= offsetTop && scrollPosition < offsetTop + offsetHeight) {
//                        this.activeSection = section;
//                        break;
//                    }
//                }
//            }
//        },

//        // Set up smooth scrolling for navigation links
//        setupSmoothScrolling() {
//            document.querySelectorAll('a[href^="#"]').forEach(anchor => {
//                anchor.addEventListener('click', (e) => {
//                    e.preventDefault();
//                    const target = document.querySelector(anchor.getAttribute('href'));

//                    if (target) {
//                        const navHeight = document.querySelector('.navbar').offsetHeight;
//                        const targetPosition = target.offsetTop - navHeight;

//                        window.scrollTo({
//                            top: targetPosition,
//                            behavior: 'smooth'
//                        });

//                        // Close mobile menu if open
//                        this.mobileMenuOpen = false;
//                    }
//                });
//            });
//        },

//        // Scroll to top
//        scrollToTop() {
//            window.scrollTo({
//                top: 0,
//                behavior: 'smooth'
//            });
//        },

//        // Handle form submission
//        async submitForm() {
//            // Validate form
//            if (!this.validateForm()) {
//                return;
//            }

//            this.isSubmitting = true;

//            try {
//                // Simulate form submission (replace with actual endpoint)
//                await this.simulateFormSubmission();

//                // Show success message
//                this.showNotification('Message sent successfully!', 'success');

//                // Reset form
//                this.resetForm();

//            } catch (error) {
//                console.error('Form submission error:', error);
//                this.showNotification('Failed to send message. Please try again.', 'error');
//            } finally {
//                this.isSubmitting = false;
//            }
//        },

//        // Validate form
//        validateForm() {
//            const { name, email, subject, message } = this.form;

//            if (!name.trim()) {
//                this.showNotification('Please enter your name.', 'error');
//                return false;
//            }

//            if (!email.trim() || !this.isValidEmail(email)) {
//                this.showNotification('Please enter a valid email address.', 'error');
//                return false;
//            }

//            if (!subject.trim()) {
//                this.showNotification('Please enter a subject.', 'error');
//                return false;
//            }

//            if (!message.trim()) {
//                this.showNotification('Please enter a message.', 'error');
//                return false;
//            }

//            return true;
//        },

//        // Check if email is valid
//        isValidEmail(email) {
//            const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
//            return emailRegex.test(email);
//        },

//        // Simulate form submission
//        async simulateFormSubmission() {
//            // In a real application, this would send data to a server
//            // For demo purposes, we'll just simulate a delay
//            return new Promise((resolve) => {
//                setTimeout(() => {
//                    console.log('Form submitted:', this.form);
//                    resolve();
//                }, 2000);
//            });
//        },

//        // Reset form
//        resetForm() {
//            this.form = {
//                name: '',
//                email: '',
//                subject: '',
//                message: ''
//            };
//        },

//        // Show notification
//        showNotification(message, type = 'info') {
//            // Create notification element
//            const notification = document.createElement('div');
//            notification.className = `notification notification-${type}`;
//            notification.innerHTML = `
//                <div class="notification-content">
//                    <span class="notification-message">${message}</span>
//                    <button class="notification-close" onclick="this.parentElement.parentElement.remove()">
//                        <i class="fas fa-times"></i>
//                    </button>
//                </div>
//            `;

//            // Add notification styles if they don't exist
//            this.addNotificationStyles();

//            // Add to page
//            document.body.appendChild(notification);

//            // Auto remove after 5 seconds
//            setTimeout(() => {
//                if (notification.parentNode) {
//                    notification.remove();
//                }
//            }, 5000);

//            // Animate in
//            setTimeout(() => {
//                notification.classList.add('show');
//            }, 100);
//        },

//        // Add notification styles
//        addNotificationStyles() {
//            if (document.getElementById('notification-styles')) return;

//            const styles = document.createElement('style');
//            styles.id = 'notification-styles';
//            styles.textContent = `
//                .notification {
//                    position: fixed;
//                    top: 20px;
//                    right: 20px;
//                    z-index: 9999;
//                    max-width: 400px;
//                    background: white;
//                    border-radius: 8px;
//                    box-shadow: 0 4px 12px rgba(0, 0, 0, 0.15);
//                    transform: translateX(100%);
//                    transition: transform 0.3s ease;
//                }

//                .notification.show {
//                    transform: translateX(0);
//                }

//                .notification-success {
//                    border-left: 4px solid #10b981;
//                }

//                .notification-error {
//                    border-left: 4px solid #ef4444;
//                }

//                .notification-info {
//                    border-left: 4px solid #3b82f6;
//                }

//                .dark .notification {
//                    background: rgb(30, 41, 59);
//                    color: rgb(248, 250, 252);
//                }

//                .notification-content {
//                    display: flex;
//                    align-items: center;
//                    justify-content: space-between;
//                    padding: 16px;
//                }

//                .notification-message {
//                    flex: 1;
//                    margin-right: 12px;
//                }

//                .notification-close {
//                    background: none;
//                    border: none;
//                    cursor: pointer;
//                    color: #6b7280;
//                    font-size: 14px;
//                    padding: 4px;
//                    border-radius: 4px;
//                    transition: background-color 0.2s;
//                }

//                .notification-close:hover {
//                    background-color: #f3f4f6;
//                }

//                .dark .notification-close:hover {
//                    background-color: #374151;
//                }
//            `;
//            document.head.appendChild(styles);
//        },

//        // Utility method to debounce function calls
//        debounce(func, wait) {
//            let timeout;
//            return function executedFunction(...args) {
//                const later = () => {
//                    clearTimeout(timeout);
//                    func(...args);
//                };
//                clearTimeout(timeout);
//                timeout = setTimeout(later, wait);
//            };
//        },

//        // Lazy load images
//        lazyLoadImages() {
//            const images = document.querySelectorAll('img[data-src]');
//            const imageObserver = new IntersectionObserver((entries, observer) => {
//                entries.forEach(entry => {
//                    if (entry.isIntersecting) {
//                        const img = entry.target;
//                        img.src = img.dataset.src;
//                        img.classList.remove('lazy');
//                        imageObserver.unobserve(img);
//                    }
//                });
//            });

//            images.forEach(img => imageObserver.observe(img));
//        },

//        // Performance optimization for scroll events
//        throttle(func, limit) {
//            let inThrottle;
//            return function () {
//                const args = arguments;
//                const context = this;
//                if (!inThrottle) {
//                    func.apply(context, args);
//                    inThrottle = true;
//                    setTimeout(() => inThrottle = false, limit);
//                }
//            }
//        }
//    }
//}

//// Additional utility functions
//document.addEventListener('DOMContentLoaded', function () {
//    // Add loading states to external links
//    document.querySelectorAll('a[target="_blank"]').forEach(link => {
//        link.addEventListener('click', function () {
//            // Add visual feedback for external links
//            this.style.opacity = '0.7';
//            setTimeout(() => {
//                this.style.opacity = '1';
//            }, 200);
//        });
//    });

//    // Add keyboard navigation support
//    document.addEventListener('keydown', function (e) {
//        // Close mobile menu with Escape key
//        if (e.key === 'Escape') {
//            const app = document.querySelector('[x-data]').__x.$data;
//            if (app.mobileMenuOpen) {
//                app.mobileMenuOpen = false;
//            }
//        }
//    });

//    // Add focus styles for keyboard navigation
//    const style = document.createElement('style');
//    style.textContent = `
//        *:focus {
//            outline: 2px solid rgb(var(--primary));
//            outline-offset: 2px;
//        }

//        .btn:focus,
//        .nav-link:focus,
//        .social-link:focus {
//            outline: 2px solid rgb(var(--primary));
//            outline-offset: 2px;
//        }
//    `;
//    document.head.appendChild(style);

//    // Performance optimization: Preload critical resources
//    const preloadLink = document.createElement('link');
//    preloadLink.rel = 'preload';
//    preloadLink.href = 'https://fonts.googleapis.com/css2?family=Inter:wght@300;400;500;600;700&display=swap';
//    preloadLink.as = 'style';
//    document.head.appendChild(preloadLink);
//});

//// Service Worker registration for PWA capabilities (optional)
//if ('serviceWorker' in navigator) {
//    window.addEventListener('load', function () {
//        // Uncomment to enable service worker
//        // navigator.serviceWorker.register('/sw.js');
//    });
//}

//// Analytics and tracking (placeholder)
//function trackEvent(eventName, eventData = {}) {
//    // Replace with actual analytics implementation
//    console.log('Event tracked:', eventName, eventData);
//}

//// Export functions for use in other scripts if needed
//window.portfolioUtils = {
//    trackEvent,
//    // Add other utility functions here
//};

// ============================================================
//  MR BAGOWABAIR — Portfolio Scripts
// ============================================================

document.addEventListener('DOMContentLoaded', function () {

    // ── AOS Animations ──────────────────────────────────────
    AOS.init({ once: true, duration: 700, easing: 'ease-out-cubic' });

    // ── Footer Year ─────────────────────────────────────────
    const yearEl = document.getElementById('year');
    if (yearEl) yearEl.textContent = new Date().getFullYear();

    // ── Navbar: scrolled state + Back-to-top ────────────────
    const nav = document.getElementById('mainNav');
    const btt = document.getElementById('backToTop');

    const onScroll = () => {
        if (window.scrollY > 30) nav.classList.add('scrolled');
        else nav.classList.remove('scrolled');

        if (btt) {
            if (window.scrollY > 600) btt.classList.add('show');
            else btt.classList.remove('show');
        }
    };
    window.addEventListener('scroll', onScroll, { passive: true });
    onScroll();

    // ── Smooth scroll for anchors + close mobile menu ───────
    document.querySelectorAll('a[href^="#"]').forEach(a => {
        a.addEventListener('click', e => {
            const id = a.getAttribute('href');
            if (id.length > 1) {
                const target = document.querySelector(id);
                if (target) {
                    e.preventDefault();
                    const offset = nav ? nav.offsetHeight + 12 : 80;
                    const top = target.getBoundingClientRect().top + window.scrollY - offset;
                    window.scrollTo({ top, behavior: 'smooth' });

                    const collapseEl = document.getElementById('navMenu');
                    if (collapseEl && collapseEl.classList.contains('show')) {
                        bootstrap.Collapse.getInstance(collapseEl)?.hide();
                    }
                }
            }
        });
    });

    // ── Animated counters ────────────────────────────────────
    const counters = document.querySelectorAll('.counter');
    const animateCounter = (el) => {
        const target = +el.dataset.target;
        const duration = 1400;
        const start = performance.now();
        const tick = (now) => {
            const p = Math.min(1, (now - start) / duration);
            const eased = 1 - Math.pow(1 - p, 3);
            el.textContent = Math.floor(target * eased);
            if (p < 1) requestAnimationFrame(tick);
            else el.textContent = target;
        };
        requestAnimationFrame(tick);
    };

    // ── Progress bar animation ───────────────────────────────
    const bars = document.querySelectorAll('.progress-bar[data-target]');
    const animateBar = (el) => { el.style.width = el.dataset.target + '%'; };

    // ── IntersectionObserver for counters + bars ─────────────
    const obs = new IntersectionObserver((entries) => {
        entries.forEach(e => {
            if (!e.isIntersecting) return;
            if (e.target.classList.contains('counter')) animateCounter(e.target);
            if (e.target.classList.contains('progress-bar')) animateBar(e.target);
            obs.unobserve(e.target);
        });
    }, { threshold: 0.5 });

    counters.forEach(c => obs.observe(c));
    bars.forEach(b => obs.observe(b));

    // ── Certificate Modal ────────────────────────────────────
    const certModalEl = document.getElementById('certModal');
    if (certModalEl) {
        const certModal = new bootstrap.Modal(certModalEl);
        const certImg = document.getElementById('certModalImage');
        const certLoader = document.getElementById('certModalLoader');
        const certTitle = document.getElementById('certModalLabel');
        const certIssuer = document.getElementById('certModalIssuer');
        const certOpen = document.getElementById('certModalOpen');

        const openCertModal = (el, e) => {
            if (e) e.preventDefault();
            const src = el.getAttribute('data-cert-image');
            const title = el.getAttribute('data-cert-title') || 'Certificate';
            const issuer = el.getAttribute('data-cert-issuer') || '';

            certTitle.textContent = title;
            certIssuer.textContent = issuer;
            if (certOpen) certOpen.href = src;
            certImg.alt = title + ' certificate';
            certImg.classList.remove('loaded');

            // Reset loader
            certLoader.innerHTML = '<div class="spinner-border text-primary" role="status"><span class="visually-hidden">Loading…</span></div>';
            certLoader.style.display = 'flex';

            certImg.src = src;
            certImg.onload = () => {
                certLoader.style.display = 'none';
                certImg.classList.add('loaded');
            };
            certImg.onerror = () => {
                certLoader.innerHTML = '<div class="text-muted small"><i class="bi bi-exclamation-triangle"></i> Could not load certificate image.</div>';
            };

            certModal.show();
        };

        document.querySelectorAll('.view-cert-btn').forEach(el => {
            el.addEventListener('click', (e) => openCertModal(el, e));
            if (el.getAttribute('role') === 'button') {
                el.addEventListener('keydown', (e) => {
                    if (e.key === 'Enter' || e.key === ' ') openCertModal(el, e);
                });
            }
        });

        certModalEl.addEventListener('hidden.bs.modal', () => {
            certImg.src = '';
            certImg.classList.remove('loaded');
            certLoader.innerHTML = '<div class="spinner-border text-primary" role="status"><span class="visually-hidden">Loading…</span></div>';
            certLoader.style.display = 'flex';
        });
    }

    // ── Contact Form (Formspree) ─────────────────────────────
    const form = document.getElementById('contact-form');
    const successMsg = document.getElementById('form-success');
    const submitBtn = document.getElementById('submit-btn');
    const btnText = document.getElementById('btn-text');

    if (form) {
        form.addEventListener('submit', async (e) => {
            e.preventDefault();

            // Loading state
            btnText.innerHTML = '<i class="bi bi-arrow-repeat me-2" style="animation:spin .8s linear infinite;display:inline-block"></i> Sending…';
            submitBtn.disabled = true;

            try {
                const response = await fetch(form.action, {
                    method: 'POST',
                    body: new FormData(form),
                    headers: { 'Accept': 'application/json' }
                });

                if (response.ok) {
                    if (successMsg) {
                        successMsg.classList.remove('d-none');
                        setTimeout(() => successMsg.classList.add('d-none'), 5000);
                    }
                    form.reset();
                } else {
                    throw new Error('Form submission failed');
                }
            } catch (err) {
                alert('There was a problem sending your message. Please try again later.');
                console.error('Contact form error:', err);
            } finally {
                btnText.innerHTML = '<i class="bi bi-send-fill me-2"></i> Send Message';
                submitBtn.disabled = false;
            }
        });
    }

    // ── Active nav-link highlighting on scroll ───────────────
    const sections = document.querySelectorAll('section[id], header[id]');
    const navLinks = document.querySelectorAll('#mainNav .nav-link');

    const highlightNav = () => {
        let current = '';
        const offset = nav ? nav.offsetHeight + 40 : 100;
        sections.forEach(sec => {
            if (window.scrollY >= sec.offsetTop - offset) {
                current = sec.getAttribute('id');
            }
        });
        navLinks.forEach(link => {
            link.classList.remove('active');
            if (link.getAttribute('href') === '#' + current) {
                link.classList.add('active');
            }
        });
    };
    window.addEventListener('scroll', highlightNav, { passive: true });
    highlightNav();

});