"use strict";

function closeFileUploadForm() {
    $("#DocumentFileUpload").fadeOut();
}

function verifyDownload() {
    $("#DocumentFileUpload").fadeOut();
    toastr.success("Files uploaded successfully");
}

function showFileUpload() {
    $("#DocumentFileUpload").fadeIn();
}