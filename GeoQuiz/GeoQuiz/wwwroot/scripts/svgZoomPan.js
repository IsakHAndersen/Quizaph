window.enableSvgZoomPan = (objectId) => {
    console.log("enableSvgZoomPan triggered with ID:", objectId);

    const objectElement = document.getElementById(objectId);
    if (!objectElement) {
        console.warn(`SVG object with ID "${objectId}" not found.`);
        return;
    }

    function handleSvgLoad() {
        console.log("SVG loaded");
        const svgDoc = objectElement.contentDocument;
        const svg = svgDoc?.querySelector("svg");
        if (!svg) return;

        const svgWidth = 2000;
        const svgHeight = 857;

        let scale = 0.5;
        let translateX = (svgWidth * (1 - scale)) / 2;
        let translateY = (svgHeight * (1 - scale)) / 2;


        let isDragging = false, startX, startY;

        let contentGroup = svg.querySelector("g#zoom-container");
        if (!contentGroup) {
            contentGroup = document.createElementNS("http://www.w3.org/2000/svg", "g");
            contentGroup.setAttribute("id", "zoom-container");

            while (svg.firstChild) {
                contentGroup.appendChild(svg.firstChild);
            }
            svg.appendChild(contentGroup);
        }

        const applyTransform = () => {
            contentGroup.setAttribute("transform", `translate(${translateX}, ${translateY}) scale(${scale})`);
        };

        svg.addEventListener("wheel", (e) => {
            e.preventDefault();
            const delta = e.deltaY > 0 ? -0.1 : 0.1;
            const newScale = Math.min(Math.max(0.2, scale + delta), 10);

            const pt = svg.createSVGPoint();
            pt.x = e.clientX;
            pt.y = e.clientY;
            const cursorpt = pt.matrixTransform(svg.getScreenCTM().inverse());

            translateX -= (cursorpt.x * (newScale - scale));
            translateY -= (cursorpt.y * (newScale - scale));
            scale = newScale;

            applyTransform();
        });

        svg.addEventListener("mousedown", (e) => {
            isDragging = true;
            startX = e.clientX;
            startY = e.clientY;
        });

        svg.addEventListener("mousemove", (e) => {
            if (!isDragging) return;
            const dx = e.clientX - startX;
            const dy = e.clientY - startY;
            translateX += dx;
            translateY += dy;
            startX = e.clientX;
            startY = e.clientY;
            applyTransform();
        });

        svg.addEventListener("mouseup", () => isDragging = false);
        svg.addEventListener("mouseleave", () => isDragging = false);

        applyTransform();
    }

    if (objectElement.contentDocument?.readyState === "complete") {
        handleSvgLoad();
    } else {
        objectElement.addEventListener("load", handleSvgLoad);
    }
};
