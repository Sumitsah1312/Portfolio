document.addEventListener("DOMContentLoaded", function () {
    particlesJS("footerParticles", {
        particles: {
            number: { value: 80, density: { enable: true, value_area: 900 } },
            color: { value: "#ffffff" },
            opacity: {
                value: 0.2,
                random: true,
                anim: { enable: true, speed: 0.5, opacity_min: 0.1 }
            },
            size: { value: 1.2, random: true },
            move: { enable: true, speed: 0.3, direction: "none", out_mode: "bounce" },
            line_linked: { enable: false }
        },
        interactivity: { detect_on: "canvas", events: { resize: true } },
        retina_detect: true
    });
});
