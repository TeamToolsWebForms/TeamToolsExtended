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