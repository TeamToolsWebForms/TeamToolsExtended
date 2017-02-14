"use strict";

function downloadFile(id) {
    requester.get(`/api/Documents/${id}`)
        .then((response) => {
            window.open("test", '_blank');
            toastr.success(response);
        })
    .catch((err) => {
        toastr.error(err);
    });
}