// Initialize AOS (Animate On Scroll)
document.addEventListener('DOMContentLoaded', function () {
    AOS.init({
        duration: 800,
        easing: 'ease-in-out',
        once: true,
        offset: 100
    });
});

// Portfolio App Alpine.js Component
function portfolioApp() {
    return {
        // State
        darkMode: localStorage.getItem('darkMode') === 'true' || false,
        mobileMenuOpen: false,
        scrolled: false,
        activeSection: 'home',
        isSubmitting: false,

        // Form data
        form: {
            name: '',
            email: '',
            subject: '',
            message: ''
        },

        // Initialize
        init() {
            // Apply saved theme
            this.applyTheme();

            // Watch for theme changes
            this.$watch('darkMode', (value) => {
                localStorage.setItem('darkMode', value);
                this.applyTheme();
            });

            // Set up scroll listener
            this.setupScrollListener();

            // Set up smooth scrolling for navigation links
            this.setupSmoothScrolling();

            // Close mobile menu when clicking outside
            document.addEventListener('click', (e) => {
                if (!e.target.closest('.navbar') && this.mobileMenuOpen) {
                    this.mobileMenuOpen = false;
                }
            });
        },

        // Apply theme
        applyTheme() {
            if (this.darkMode) {
                document.documentElement.classList.add('dark');
            } else {
                document.documentElement.classList.remove('dark');
            }
        },

        // Set up scroll listener
        setupScrollListener() {
            let ticking = false;

            window.addEventListener('scroll', () => {
                if (!ticking) {
                    requestAnimationFrame(() => {
                        this.handleScroll();
                        ticking = false;
                    });
                    ticking = true;
                }
            });
        },

        // Handle scroll events
        handleScroll() {
            const scrollTop = window.pageYOffset || document.documentElement.scrollTop;

            // Update scrolled state
            this.scrolled = scrollTop > 50;

            // Update active section
            this.updateActiveSection();
        },

        // Update active section based on scroll position
        updateActiveSection() {
            const sections = ['home', 'about', 'skills', 'projects', 'services', 'education', 'contact'];
            const scrollPosition = window.scrollY + 200;

            for (let section of sections) {
                const element = document.getElementById(section);
                if (element) {
                    const offsetTop = element.offsetTop;
                    const offsetHeight = element.offsetHeight;

                    if (scrollPosition >= offsetTop && scrollPosition < offsetTop + offsetHeight) {
                        this.activeSection = section;
                        break;
                    }
                }
            }
        },

        // Set up smooth scrolling for navigation links
        setupSmoothScrolling() {
            document.querySelectorAll('a[href^="#"]').forEach(anchor => {
                anchor.addEventListener('click', (e) => {
                    e.preventDefault();
                    const target = document.querySelector(anchor.getAttribute('href'));

                    if (target) {
                        const navHeight = document.querySelector('.navbar').offsetHeight;
                        const targetPosition = target.offsetTop - navHeight;

                        window.scrollTo({
                            top: targetPosition,
                            behavior: 'smooth'
                        });

                        // Close mobile menu if open
                        this.mobileMenuOpen = false;
                    }
                });
            });
        },

        // Scroll to top
        scrollToTop() {
            window.scrollTo({
                top: 0,
                behavior: 'smooth'
            });
        },

        // Handle form submission
        async submitForm() {
            // Validate form
            if (!this.validateForm()) {
                return;
            }

            this.isSubmitting = true;

            try {
                // Simulate form submission (replace with actual endpoint)
                await this.simulateFormSubmission();

                // Show success message
                this.showNotification('Message sent successfully!', 'success');

                // Reset form
                this.resetForm();

            } catch (error) {
                console.error('Form submission error:', error);
                this.showNotification('Failed to send message. Please try again.', 'error');
            } finally {
                this.isSubmitting = false;
            }
        },

        // Validate form
        validateForm() {
            const { name, email, subject, message } = this.form;

            if (!name.trim()) {
                this.showNotification('Please enter your name.', 'error');
                return false;
            }

            if (!email.trim() || !this.isValidEmail(email)) {
                this.showNotification('Please enter a valid email address.', 'error');
                return false;
            }

            if (!subject.trim()) {
                this.showNotification('Please enter a subject.', 'error');
                return false;
            }

            if (!message.trim()) {
                this.showNotification('Please enter a message.', 'error');
                return false;
            }

            return true;
        },

        // Check if email is valid
        isValidEmail(email) {
            const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
            return emailRegex.test(email);
        },

        // Simulate form submission
        async simulateFormSubmission() {
            // In a real application, this would send data to a server
            // For demo purposes, we'll just simulate a delay
            return new Promise((resolve) => {
                setTimeout(() => {
                    console.log('Form submitted:', this.form);
                    resolve();
                }, 2000);
            });
        },

        // Reset form
        resetForm() {
            this.form = {
                name: '',
                email: '',
                subject: '',
                message: ''
            };
        },

        // Show notification
        showNotification(message, type = 'info') {
            // Create notification element
            const notification = document.createElement('div');
            notification.className = `notification notification-${type}`;
            notification.innerHTML = `
                <div class="notification-content">
                    <span class="notification-message">${message}</span>
                    <button class="notification-close" onclick="this.parentElement.parentElement.remove()">
                        <i class="fas fa-times"></i>
                    </button>
                </div>
            `;

            // Add notification styles if they don't exist
            this.addNotificationStyles();

            // Add to page
            document.body.appendChild(notification);

            // Auto remove after 5 seconds
            setTimeout(() => {
                if (notification.parentNode) {
                    notification.remove();
                }
            }, 5000);

            // Animate in
            setTimeout(() => {
                notification.classList.add('show');
            }, 100);
        },

        // Add notification styles
        addNotificationStyles() {
            if (document.getElementById('notification-styles')) return;

            const styles = document.createElement('style');
            styles.id = 'notification-styles';
            styles.textContent = `
                .notification {
                    position: fixed;
                    top: 20px;
                    right: 20px;
                    z-index: 9999;
                    max-width: 400px;
                    background: white;
                    border-radius: 8px;
                    box-shadow: 0 4px 12px rgba(0, 0, 0, 0.15);
                    transform: translateX(100%);
                    transition: transform 0.3s ease;
                }

                .notification.show {
                    transform: translateX(0);
                }

                .notification-success {
                    border-left: 4px solid #10b981;
                }

                .notification-error {
                    border-left: 4px solid #ef4444;
                }

                .notification-info {
                    border-left: 4px solid #3b82f6;
                }

                .dark .notification {
                    background: rgb(30, 41, 59);
                    color: rgb(248, 250, 252);
                }

                .notification-content {
                    display: flex;
                    align-items: center;
                    justify-content: space-between;
                    padding: 16px;
                }

                .notification-message {
                    flex: 1;
                    margin-right: 12px;
                }

                .notification-close {
                    background: none;
                    border: none;
                    cursor: pointer;
                    color: #6b7280;
                    font-size: 14px;
                    padding: 4px;
                    border-radius: 4px;
                    transition: background-color 0.2s;
                }

                .notification-close:hover {
                    background-color: #f3f4f6;
                }

                .dark .notification-close:hover {
                    background-color: #374151;
                }
            `;
            document.head.appendChild(styles);
        },

        // Utility method to debounce function calls
        debounce(func, wait) {
            let timeout;
            return function executedFunction(...args) {
                const later = () => {
                    clearTimeout(timeout);
                    func(...args);
                };
                clearTimeout(timeout);
                timeout = setTimeout(later, wait);
            };
        },

        // Lazy load images
        lazyLoadImages() {
            const images = document.querySelectorAll('img[data-src]');
            const imageObserver = new IntersectionObserver((entries, observer) => {
                entries.forEach(entry => {
                    if (entry.isIntersecting) {
                        const img = entry.target;
                        img.src = img.dataset.src;
                        img.classList.remove('lazy');
                        imageObserver.unobserve(img);
                    }
                });
            });

            images.forEach(img => imageObserver.observe(img));
        },

        // Performance optimization for scroll events
        throttle(func, limit) {
            let inThrottle;
            return function () {
                const args = arguments;
                const context = this;
                if (!inThrottle) {
                    func.apply(context, args);
                    inThrottle = true;
                    setTimeout(() => inThrottle = false, limit);
                }
            }
        }
    }
}

// Additional utility functions
document.addEventListener('DOMContentLoaded', function () {
    // Add loading states to external links
    document.querySelectorAll('a[target="_blank"]').forEach(link => {
        link.addEventListener('click', function () {
            // Add visual feedback for external links
            this.style.opacity = '0.7';
            setTimeout(() => {
                this.style.opacity = '1';
            }, 200);
        });
    });

    // Add keyboard navigation support
    document.addEventListener('keydown', function (e) {
        // Close mobile menu with Escape key
        if (e.key === 'Escape') {
            const app = document.querySelector('[x-data]').__x.$data;
            if (app.mobileMenuOpen) {
                app.mobileMenuOpen = false;
            }
        }
    });

    // Add focus styles for keyboard navigation
    const style = document.createElement('style');
    style.textContent = `
        *:focus {
            outline: 2px solid rgb(var(--primary));
            outline-offset: 2px;
        }
        
        .btn:focus,
        .nav-link:focus,
        .social-link:focus {
            outline: 2px solid rgb(var(--primary));
            outline-offset: 2px;
        }
    `;
    document.head.appendChild(style);

    // Performance optimization: Preload critical resources
    const preloadLink = document.createElement('link');
    preloadLink.rel = 'preload';
    preloadLink.href = 'https://fonts.googleapis.com/css2?family=Inter:wght@300;400;500;600;700&display=swap';
    preloadLink.as = 'style';
    document.head.appendChild(preloadLink);
});

// Service Worker registration for PWA capabilities (optional)
if ('serviceWorker' in navigator) {
    window.addEventListener('load', function () {
        // Uncomment to enable service worker
        // navigator.serviceWorker.register('/sw.js');
    });
}

// Analytics and tracking (placeholder)
function trackEvent(eventName, eventData = {}) {
    // Replace with actual analytics implementation
    console.log('Event tracked:', eventName, eventData);
}

// Export functions for use in other scripts if needed
window.portfolioUtils = {
    trackEvent,
    // Add other utility functions here
};
