"use strict";

function titleValidation(oSrc, args) {
    let isValid = true;
    let textValue = args.Value.length;

    isValid = validateLength(textValue);

    if (!isValid) {
        toastr.error("Title must be between 3 and 100 symbols");
    }
}

function contentValidation(oSrc, args) {
    let isValid;
    let textValue = args.Value.length;

    isValid = validateLength(textValue);

    if (!isValid) {
        toastr.error("Content must be between 3 and 100 symbols");
    }
}

function validateLength(value) {
    console.log("called with value: " + value)
    if (value >= 3 && value <= 100) {
        return true;
    } else {
        return false;
    }
}