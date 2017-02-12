"use strict";

function showCreateProjectPanel() {
    $("#CreteProjectPanel").fadeIn();
};

function updateProjectSuccess() {
    toastr.success("Project name updated successfully");
}

function deleteProjectSuccess() {
    toastr.success("Project deleted successfully");
}

function createProjectNameValidation() {
    toastr.error("Name must be between 3 and 100 symbols");
    $("#CreteProjectPanel").fadeOut();
}

function createProjectDescriptionValidation() {
    toastr.error("Descrition must be between 3 and 200 symbols");
    $("#CreteProjectPanel").fadeOut();
}

function createProjectSuccess() {
    toastr.success("Project created successfully");
    $("#CreteProjectPanel").fadeOut();
}

function closePanelForm() {
    $("#CreteProjectPanel").fadeOut();
};