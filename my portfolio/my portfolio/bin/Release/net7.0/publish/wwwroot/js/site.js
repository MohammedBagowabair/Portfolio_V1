
window.getWindowWidth = function () {
    return window.innerWidth;
};

window.initializeComponents = function () {
    console.log("JS components initialized");
    // Add any other JS initialization logic here
};

// site.js
window.registerResizeCallback = function (dotNetHelper) {
    window.addEventListener("resize", () => {
        dotNetHelper.invokeMethodAsync("OnResize");
    });
};

window.scrollToElement = function (id) {
    const element = document.getElementById(id);
    if (element) {
        element.scrollIntoView({ behavior: 'smooth' });
    }
};

