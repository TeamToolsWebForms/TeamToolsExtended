"use strict";

function noUser() {
    toastr.error("No user found with this email");
}

function internalError() {
    toastr.error("Something went wrong, please try again");
}