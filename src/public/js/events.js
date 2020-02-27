document.addEventListener("onReactDashboardMounted", function (event) {
    if (window.blazorMicroFrontend)
        window.blazorMicroFrontend.resetBlazor();
});

