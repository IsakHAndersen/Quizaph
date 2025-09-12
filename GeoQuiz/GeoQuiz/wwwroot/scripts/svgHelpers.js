function highlightSvgElementById(countryId) {
    const svgObject = document.getElementById('svg-map');
    if (!svgObject) {
        console.warn('SVG object element not found');
        return;
    }

    const svgDoc = svgObject.contentDocument;
    if (!svgDoc) {
        console.warn('SVG document not loaded yet');
        return;
    }

    const group = svgDoc.getElementById(countryId);
    if (!group) {
        console.warn(`No group with id: ${countryId}`);
        return;
    }

    console.log(`Highlighting country group: ${countryId}`);
    const paths = group.querySelectorAll('path');
    if (paths.length === 0) {
        console.warn(`No paths found in group ${countryId}`);
        return;
    }

    paths.forEach(path => {
        path.style.fill = "#81ef73";         
        path.style.stroke = "#26ae14";          
    });
}

function resetSvg() {
    const svgObject = document.getElementById('svg-map');
    if (!svgObject) {
        console.warn('SVG object element not found');
        return;
    }
    const svgDoc = svgObject.contentDocument;
    if (!svgDoc) {
        console.warn('SVG document not loaded yet');
        return;
    }
    const paths = svgDoc.querySelectorAll('path');
    if (paths.length === 0) {
        console.warn('No paths found in SVG document');
        return;
    }
    paths.forEach(path => {
        path.style.fill = "";
        path.style.stroke = ""; 
    });
}

function registerSvgClickHandlers(dotNetHelper) {
    const svgObject = document.getElementById('svg-map');
    if (!svgObject) {
        console.warn('SVG object element not found');
        return;
    }

    svgObject.addEventListener("load", () => {
        const svgDoc = svgObject.contentDocument;
        if (!svgDoc) {
            console.warn('SVG document not loaded yet');
            return;
        }

        const groups = svgDoc.querySelectorAll("g[id]");
        groups.forEach(g => {
            g.addEventListener("click", () => {
                console.log("Clicked country: " + g.id);
                dotNetHelper.invokeMethodAsync("OnCountryClicked", g.id);
            });
        });
    });
}
