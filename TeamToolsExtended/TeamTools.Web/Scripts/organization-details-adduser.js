"use strict";

function loadUsers(users) {
    $("#UserField").autocomplete({
        source: users
    });
}