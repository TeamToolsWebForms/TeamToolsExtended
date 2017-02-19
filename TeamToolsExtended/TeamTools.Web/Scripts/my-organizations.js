"use strict";

function showCreatePanel() {
    $("#CreteOrganizationPanel").fadeIn();
}

function closeCreatePanel() {
    $("#CreteOrganizationPanel").fadeOut();
}

function saveOrganization() {
    $("#CreteOrganizationPanel").fadeOut();
    toastr.success("Organization created successfully");
}

function requiredName() {
    toastr.error("Name is required");
}

function requiredDescription() {
    toastr.error("Description is required");
}

function joinSuccess() {
    toastr.success("Successfully joined organization");
}

function joinFail() {
    toastr.error("Something went wrong, please try again");
}