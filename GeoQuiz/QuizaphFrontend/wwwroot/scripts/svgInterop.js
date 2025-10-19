
let practiceMode = false;
window.svgInterop = {
    init: (objectId, dotNetHelper) => {
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

            // Hover + Click Handlers for Countries
            const countries = svg.querySelectorAll("g");
            countries.forEach(country => {
                country.style.cursor = "pointer";

                let mouseDownX, mouseDownY, isMouseDown = false;

                country.addEventListener("mouseenter", () => {
                    if (dotNetHelper) {
                        const id = country.getAttribute("id");
                        dotNetHelper.invokeMethodAsync("OnCountryHovered", id);
                    }
                    country.style.fill = "#00CFC1";
                });

                country.addEventListener("mouseleave", () => {
                    if (dotNetHelper) {
                        dotNetHelper.invokeMethodAsync("OnCountryHoverLeave");
                    }
                    country.style.fill = "";
                });

                country.addEventListener("mousedown", (e) => {
                    isMouseDown = true;
                    mouseDownX = e.clientX;
                    mouseDownY = e.clientY;
                });

                country.addEventListener("mouseup", (e) => {
                    if (!isMouseDown) return;
                    isMouseDown = false;

                    const dx = e.clientX - mouseDownX;
                    const dy = e.clientY - mouseDownY;
                    const distance = Math.sqrt(dx * dx + dy * dy);

                    // Only trigger click if mouse didn't move much
                    if (distance < 5) {
                        const id = country.getAttribute("id");
                        if (id) {
                            console.log("Clicked country:", id);
                            dotNetHelper.invokeMethodAsync("OnCountryClicked", id);
                        }
                    }
                });

                const circles = country.querySelectorAll("circle.clickable");
                circles.forEach(circle => {
                    circle.style.cursor = "pointer";

                    // Save the original radius
                    const originalRadius = circle.getAttribute("r");

                    circle.addEventListener("click", (e) => {
                        e.stopPropagation(); // Prevent bubbling
                        const parentGroup = circle.closest("g");
                        if (parentGroup) {
                            const clickEvent = new MouseEvent("click", {
                                bubbles: true,
                                cancelable: true,
                                clientX: e.clientX,
                                clientY: e.clientY
                            });
                            parentGroup.dispatchEvent(clickEvent);
                        }
                    });

                    // Hover effects
                    circle.addEventListener("mouseenter", () => {
                        // Enlarge circle
                        circle.setAttribute("r", parseFloat(originalRadius) * 1.5); // 1.5x larger
                        // Optional: change color to indicate hover
                        circle.setAttribute("fill", "#00CFC1");
                    });

                    circle.addEventListener("mouseleave", () => {
                        // Restore original size
                        circle.setAttribute("r", originalRadius);
                        // Restore original fill (if any)
                        circle.setAttribute("fill", "#277DF5");
                    });
                });

            });

            // Trigger country click manually
            objectElement.svgApi = {
                triggerCountryClick: (countryId) => {
                    const target = svg.querySelector(`g#${countryId}`);
                    if (target) {
                        target.dispatchEvent(new Event("click"));
                    } else {
                        console.warn(`Country with ID "${countryId}" not found.`);
                    }
                }
            };

            // Zoom + Drag Support (unchanged)
            let scale = 1.0;
            let translateX = 0;
            let translateY = 0;
            let isDragging = false, startX, startY;

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

            objectElement.svgState = {
                applyTransform,
                get scale() { return scale; },
                set scale(v) { scale = v; applyTransform(); },
                get translateX() { return translateX; },
                set translateX(v) { translateX = v; applyTransform(); },
                get translateY() { return translateY; },
                set translateY(v) { translateY = v; applyTransform(); }
            };

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

    enablePracticeHover: () => { practiceMode = true; },
    disablePracticeHover: () => { practiceMode = false; },

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
    },

    triggerCountryClick: (objectId, countryId) => {
        const objectElement = document.getElementById(objectId);
        if (objectElement?.svgApi) {
            objectElement.svgApi.triggerCountryClick(countryId);
        }
    }
};