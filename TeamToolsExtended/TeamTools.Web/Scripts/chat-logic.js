"use strict";

$(() => {
    function getParameterByName(name, url) {
        if (!url) {
            url = window.location.href;
        }
        name = name.replace(/[\[\]]/g, "\\$&");
        var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
            results = regex.exec(url);
        if (!results) return null;
        if (!results[2]) return '';
        return decodeURIComponent(results[2].replace(/\+/g, " "));
    }

    $.connection.hub.start();

    var chat = $.connection.chat;

    $('#sendMsg').click(function () {
        let msg = $('#m').val();
        let projectId = getParameterByName("id");
        console.log("here");
        chat.server.sendMessage(msg, projectId);
    });

    $('#ShowChat').click(function () {
        $("#main-chat").fadeToggle();
        let projectId = getParameterByName("id");

        chat.server.joinProject(projectId);
    });

    chat.client.addMessage = addMessage;
    chat.client.parseError = parseError;
});

function parseError(error) {
    toastr.error(error);
}

function addMessage(message) {
    let date = new Date(message.Created).toDateString();
    let creator = message.Creator;
    let content = message.Content;

    let wrapper = $("<div />").addClass("row message-bubble");
    let paragraph = $("<p />").addClass("text-muted");
    let creatorSpan = $("<span />").text(creator);
    paragraph.append(creatorSpan);
    let contentParagraph = $("<p />").text(content);
    let createdDate = $("<div />").text(`sent ${date}`);
    wrapper
        .append(paragraph)
        .append(contentParagraph)
        .append(createdDate);

    $('#message-container').append(wrapper);
}