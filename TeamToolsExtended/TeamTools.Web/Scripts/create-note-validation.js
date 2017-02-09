"use strict";

function titleValidation() {
    toastr.error("Title must be between 3 and 100 symbols");
}

function contentValidation() {
    toastr.error("Content must be between 3 and 100 symbols");
}

function noteSuccess() {
    toastr.success("Note created successfully");
}

function updateProjectSuccess() {
    toastr.success("Project name updated successfully");
}

function deleteProjectSuccess() {
    toastr.success("Project deleted successfully");
}

function createProjectNameValidation() {
    toastr.error("Name must be between 3 and 100 symbols");
}

function createProjectDescriptionValidation() {
    toastr.error("Descrition must be between 3 and 200 symbols");
}

function createProjectSuccess() {
    toastr.success("Project created successfully");
}