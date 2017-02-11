"use strict";

$(function () {
    let newTaskPanel = $("#NewTaskPanel");

    function showChat() {
        $("#main-chat").removeClass("hidden");
    }
    
    $("#CreateNew").on("click", () => {
        newTaskPanel.fadeIn();
    });

    $("#closeTaskForm").on("click", () => {
        newTaskPanel.fadeOut();
    });

    $("#CreateTask").on("click", () => {
        toastr.success("New task added successfully");
        newTaskPanel.fadeOut();
    });
});