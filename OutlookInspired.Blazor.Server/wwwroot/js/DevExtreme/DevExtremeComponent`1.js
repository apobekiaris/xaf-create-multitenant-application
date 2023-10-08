
let devExtremeInitPromise = null;

export async function ensureDevExtremeAsync() {
    await loadDevExtreme();
}
export function printElement(element) {
    document.body.innerHTML = "";
    document.body.appendChild(element);
    setTimeout(() => {
        window.print();
        location.reload();
    }, 2000);
}
function loadDevExtreme() {
    return devExtremeInitPromise || (devExtremeInitPromise = new Promise(async (resolve, _) => {
        await loadScriptAsync("https://cdnjs.cloudflare.com/ajax/libs/devextreme-quill/1.6.2/dx-quill.min.js");
        await loadScriptAsync("https://cdn3.devexpress.com/jslib/23.1.3/js/dx.all.js");
        await loadScriptAsync("https://cdn3.devexpress.com/jslib/23.1.5/js/vectormap-data/usa.js");
        await loadScriptAsync("https://cdn3.devexpress.com/jslib/23.1.5/js/vectormap-data/world.js");
        await loadStylesheetAsync("https://cdn3.devexpress.com/jslib/23.1.3/css/dx.common.css");
        await loadStylesheetAsync("https://cdn3.devexpress.com/jslib/23.1.3/css/dx.material.orange.dark.compact.css");
        resolve();
    }));

    function loadScriptAsync(src) {
        return new Promise((resolve, _) => {
            const scriptEl = document.createElement("SCRIPT");
            scriptEl.src = src;
            scriptEl.onload = resolve;
            document.head.appendChild(scriptEl);
        });
    }
    function loadStylesheetAsync(href) {
        return new Promise((resolve, _) => {
            const stylesheetEl = document.createElement("LINK");
            stylesheetEl.href = href;
            stylesheetEl.rel = "stylesheet";
            stylesheetEl.onload = resolve;
            document.head.appendChild(stylesheetEl);
        });
    }
}

