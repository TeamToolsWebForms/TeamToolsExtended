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

function taskTitleValidation() {
    toastr.error("Title must be between 3 and 100 symbols");
}

function taskDescriptionValidation() {
    toastr.error("Description must be between 3 and 200 symbols");
}

function showEditTaskPanel() {
    $("#EditTaskPanel").fadeIn();
}

function closeEditTaskPanel() {
    $("#EditTaskPanel").fadeOut();
}

function editTask() {
    toastr.success("Task edited successfully");
}

function deleteProjectTaskSuccess() {
    toastr.success("Task deleted successfully");
}

function showAjaxFileUpload() {
    $("#DocumentFileUpload").fadeToggle();
}

function closeFileUploadForm() {
    $("#DocumentFileUpload").fadeOut();
}

function verifyDownload() {
    $("#DocumentFileUpload").fadeOut();
    toastr.success("Files uploaded successfully");
}

function successAddToProject() {
    toastr.success("User successfully added to project");
}

function failAddToProject() {
    toastr.error("Sorry, but user with that email could not be found in the organization");
}

function loadUsers(users) {
    $("#ProjectUserField").autocomplete({
        source: users
    });
}

function loadProjectUsers(users) {
    $("#AssignUserToTask").autocomplete({
        source: users
    });
}

function userAssignedToProject() {
    toastr.success("User successfully assigned to task");
}

function invalidUser() {
    toastr.error("Cannot assign invalid username");
}