window.getWindowWidth = () => {
    return window.innerWidth;
};

window.registerResizeCallback = (dotNetHelper) => {
    window.addEventListener("resize", () => {
        dotNetHelper.invokeMethodAsync("OnResize", window.innerWidth);
    });
};

