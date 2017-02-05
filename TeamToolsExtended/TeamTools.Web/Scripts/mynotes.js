"use strict";

function setImportant(id) {
    requester.postJSON(`/api/Note/${id}`)
        .then((response) => {
            toastr.success(response);
        })
    .catch((err) => {
        toastr.error(err);
    });
}

function deleteNote(id) {
    requester.postJSON(`/api/Note/delete/${id}`)
       .then((response) => {
           toastr.success(response);
       })
    .catch((err) => {
        toastr.error(err);
    });
}