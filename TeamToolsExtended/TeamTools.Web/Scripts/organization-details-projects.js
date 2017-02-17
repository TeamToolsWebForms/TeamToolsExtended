"use strict";

function showCreatePanel() {
    $("#CreteProjectPanel").fadeIn();
}

function closeCreatePanel() {
    $("#CreteProjectPanel").fadeOut();
}

function createProjectSuccess() {
    toastr.success("New project created successfully");
}

function titleValidation() {
    toastr.error("Title must be between 3 and 100 symbols");
}

function descriptionValidation() {
    toastr.error("Description must be between 3 and 200 symbols");
}

function updateProjectSuccess() {
    toastr.success("Project updated successfully");
}

function deleteProjectSuccess() {
    toastr.success("Project deleted successfully");
}