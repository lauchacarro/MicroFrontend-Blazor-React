var blazorMicroFrontend = {};
blazorMicroFrontend.setBlazor = function () {

    var script = document.createElement("script");
    script.src = "_framework/blazor.webassembly.js";
    document.head.appendChild(script);

};

blazorMicroFrontend.removeBlazor = function () {
    window.removeEventListeners('popstate');
    document.removeEventListeners('click');
    document.removeEventListeners('change');
    document.removeEventListeners('keydown');
    
    document.getElementsByTagName("bz-compiler")[0].innerHTML = "";

    var scriptBlazor = document.querySelector("script[src='_framework/blazor.webassembly.js']");
    if (scriptBlazor)
        scriptBlazor.parentNode.removeChild(scriptBlazor);

    var scriptWasm = document.querySelector("script[src='_framework/wasm/mono.js']");
    if (scriptWasm)
        scriptWasm.parentNode.removeChild(scriptWasm);
};

blazorMicroFrontend.resetBlazor = function () {
    blazorMicroFrontend.removeBlazor();
    blazorMicroFrontend.setBlazor();
};

window.blazorMicroFrontend = blazorMicroFrontend;