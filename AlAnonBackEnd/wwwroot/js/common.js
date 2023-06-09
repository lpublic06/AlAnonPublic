﻿window.ShowToastr = (type, message) => {
    if (type === "success")
        toastr.success(message, 'Operation Successful', { timeOut: 5000 });
    if (type === "error")
        toastr.error(message, 'Operation error', { timeOut: 5000 });
}
window.ShowSwal = (type, message, submsg) => {
    if (type == "success")
        Swal.fire(message, submsg, type);
    if (type == "error")
        Swal.fire(message, submsg, type);
}

window.ShowDeleteConfirmation = () => {
    $('#deleteConfirmationModal').modal('show');
}

window.HideDeleteConfirmation = () => {
    $('#deleteConfirmationModal').modal('hide');
}
function showText(toggleText) {
    toggleText.classList.toggle("active");
}

window.onload = function () {
    Fancybox.bind("[data-fancybox]", {
        // Your custom options
    });    

    Fancybox.bind('[data-fancybox="word"]', {
        iframe: {
            css: {
                width: '600px'
            }
        }
    });
}

window.blazorGetTimezoneOffset = function () {
    return new Date().getTimezoneOffset();
};

function resizeCarouselItem(img) {
    var itemContainer = img.parentElement.parentElement.parentElement.parentElement;
    var itemHeight = img.height;
    itemContainer.style.height = itemHeight + "px";
}