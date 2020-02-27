var blazorCompilerInterop = {};

blazorCompilerInterop.dispatchBlazorCodeCompiledEvent = function (time) {
    var event = new CustomEvent("onBlazorCodeCompiled", { bubbles: true, detail: { time: time } });
    document.dispatchEvent(event);
};
window.blazorCompilerInterop = blazorCompilerInterop;