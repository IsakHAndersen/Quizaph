function highlightSvgElementById(
    countryId,
    fillColor = "#81ef73",
    strokeColor = "#26ae14",
    flash = false
) {
    const svgObject = document.getElementById('svg-map');
    if (!svgObject) return;

    const svgDoc = svgObject.contentDocument;
    if (!svgDoc) return;

    const group = svgDoc.getElementById(countryId);
    if (!group) return;

    // Select both <path> and <circle> inside the group
    const shapes = group.querySelectorAll('path, circle');
    if (shapes.length === 0) return;

    shapes.forEach(shape => {
        const originalFill = shape.getAttribute("fill") || shape.style.fill;
        const originalStroke = shape.getAttribute("stroke") || shape.style.stroke;

        shape.style.fill = fillColor;
        shape.style.stroke = strokeColor;

        if (flash) {
            setTimeout(() => {
                shape.style.fill = originalFill;
                shape.style.stroke = originalStroke;
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
    const circles = svgDoc.querySelectorAll('circle');

    if (paths.length === 0 && circles.length === 0) {
        console.warn('No paths or circles found in SVG document');
        return;
    }

    // Reset all paths
    paths.forEach(path => {
        path.style.fill = "";
        path.style.stroke = "";
    });

    // Reset all circles
    circles.forEach(circle => {
        circle.style.fill = "";
        circle.style.stroke = "";
    });
}

