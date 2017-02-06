"use strict";

$(document).ready(function () {
    bindEvents();
});

function FileSuccess() {
    toastr.success("Upload status: File uploaded!");
}

function FileMemory() {
    toastr.error("Upload status: The file has to be less than 100 kb!");
}

function FileType() {
    toastr.error("Upload status: Only JPEG files are accepted!");
}

function InternalError(ex) {
    toastr.error("Upload status: The file could not be uploaded. The following error occured: InternalError");
}

function bindEvents() {
    $("#MainContent_ShowProjects").on("click", (e) => {
        $("#MainContent_ShowProjects").parent().addClass("active");
        $("#MainContent_ShowOrganizations").parent().removeClass("active");
    });

    $("#MainContent_ShowOrganizations").on("click", () => {
        $("#MainContent_ShowOrganizations").parent().addClass("active");
        $("#MainContent_ShowProjects").parent().removeClass("active");
    });
}

// attach the event binding function to every partial update
Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function (evt, args) {
    bindEvents();
});