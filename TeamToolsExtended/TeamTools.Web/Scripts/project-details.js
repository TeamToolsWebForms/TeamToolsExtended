"use strict";

function closeDeleteProjectForm() {
    $("#DeleteProjectPanel").fadeOut();
};

function showDeleteProjectPanel() {
    $("#DeleteProjectPanel").fadeIn();
};

function showNewTaskPanel() {
    $("#NewTaskPanel").fadeIn();
}

function closeNewTaskPanel() {
    $("#NewTaskPanel").fadeOut();
}

function createNewTask() {
    toastr.success("New task added successfully");
}

function parseError() {
    toastr.error("Something went wrong, please try again");
}