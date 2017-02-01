"use strict";

$(document).ready(function () {
    bindEvents();
});

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