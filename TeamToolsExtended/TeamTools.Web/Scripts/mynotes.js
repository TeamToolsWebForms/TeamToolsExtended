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
           $(`#note${id}`).hide();
           toastr.success(response);
       })
    .catch((err) => {
        toastr.error(err);
    });
}

function markAsNormalNote(id) {
    requester.postJSON(`/api/Note/Important/markNormal/${id}`)
       .then((response) => {
           $(`#note${id}`).remove();
           toastr.success(response);
       })
    .catch((err) => {
        toastr.error(err);
    });
}