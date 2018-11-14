"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/WordHub").build();
var reviewerConnId;

connection.on("ReceiveWord", function (word) {
    console.log(word);
    console.log(word.value);
    var encodedWord = word.value.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var currentWord = document.getElementById('currentWord');
    currentWord.textContent = word.value;
});

connection.on("WordListComplete", function() {
    var h2 = document.createElement("h2");
    var feedbackDiv = document.getElementById("feedback");
    h2.textContent = "Congrats you finished the list";
    feedbackDiv.append(h2);
})

connection.on("ConnectionSuccess", function () {
    connection.invoke("RegisterAsReviewer");
});

connection.on("Registered", function (connId) {
    $('#ReviewerConnectionId').text(connId);
    reviewerConnId = connId;
});

connection.on("ClientConnected", function (connId) {
    alert(connId);
})

connection.start().catch(function (err) { return console.error(err.toString()); });


document.getElementById("start").addEventListener("click", function (event) {
    connection.invoke("StartWordList", "nameOfList").catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

document.getElementById("correctButton").addEventListener("click", function(event) {
    var currentWord = document.getElementById("currentWord");
    var word = currentWord.textContent;
    connection.invoke("UpdateWordStatus", word, "Correct");
});

document.getElementById("incorrectButton").addEventListener("click", function(event) {
    var currentWord = document.getElementById("currentWord");
    var word = currentWord.textContent;
    connection.invoke("UpdateWordStatus", word, "Incorrect");
});