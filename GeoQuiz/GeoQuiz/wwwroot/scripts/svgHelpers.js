function highlightSvgElementById(countryId, fillColor = "#81ef73", strokeColor = "#26ae14", flash = false) {
    const svgObject = document.getElementById('svg-map');
    if (!svgObject) return;

    const svgDoc = svgObject.contentDocument;
    if (!svgDoc) return;

    const group = svgDoc.getElementById(countryId);
    if (!group) return;

    const paths = group.querySelectorAll('path');
    if (paths.length === 0) return;

    paths.forEach(path => {
        const originalFill = path.style.fill;
        const originalStroke = path.style.stroke;

        path.style.fill = fillColor;
        path.style.stroke = strokeColor;

        if (flash) {
            setTimeout(() => {
                path.style.fill = originalFill;
                path.style.stroke = originalStroke;
            }, 1000); // 1 sec flash
        }
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
