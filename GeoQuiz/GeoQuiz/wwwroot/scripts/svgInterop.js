window.svgInterop = {
    init: (objectId) => {
        console.log("svgInterop.init triggered:", objectId);

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

            let scale = 1.0;
            let translateX = 0;
            let translateY = 0;
            let isDragging = false, startX, startY;

            // Wrap contents in <g> for transforms
            let contentGroup = svg.querySelector("g#viewport");
            if (!contentGroup) {
                contentGroup = document.createElementNS("http://www.w3.org/2000/svg", "g");
                contentGroup.setAttribute("id", "viewport");

                while (svg.firstChild) {
                    contentGroup.appendChild(svg.firstChild);
                }
                svg.appendChild(contentGroup);
            }

            const applyTransform = () => {
                contentGroup.setAttribute(
                    "transform",
                    `translate(${translateX}, ${translateY}) scale(${scale})`
                );
            };

            // Store state globally so we can call from Blazor
            objectElement.svgState = {
                applyTransform,
                get scale() { return scale; },
                set scale(v) { scale = v; applyTransform(); },
                get translateX() { return translateX; },
                set translateX(v) { translateX = v; applyTransform(); },
                get translateY() { return translateY; },
                set translateY(v) { translateY = v; applyTransform(); }
            };

            // Dragging
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
    },

    zoomIn: (objectId) => {
        const objectElement = document.getElementById(objectId);
        if (objectElement?.svgState) {
            objectElement.svgState.scale = Math.min(objectElement.svgState.scale + 0.2, 10);
        }
    },

    zoomOut: (objectId) => {
        const objectElement = document.getElementById(objectId);
        if (objectElement?.svgState) {
            objectElement.svgState.scale = Math.max(objectElement.svgState.scale - 0.2, 0.2);
        }
    }
};
