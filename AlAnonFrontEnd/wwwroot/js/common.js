function printInvoke() {
    window.print();
}

function blazorGetTimezoneOffset() {
    return new Date().getTimezoneOffset();
}
//window.blazorGetTimezoneOffset = function () {
//    return new Date().getTimezoneOffset();
//};

window.onload = function () {
    Fancybox.bind("[data-fancybox]", {
        // Your custom options
    });
}

function resizeCarouselItem(img) {
    var itemContainer = img.parentElement.parentElement.parentElement.parentElement;
    var itemHeight = img.height;
    itemContainer.style.height = itemHeight + "px";
}