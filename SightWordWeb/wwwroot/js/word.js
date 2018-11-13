"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/WordHub").build();

connection.on("ReceiveWord", function (word) {
    console.log(word);
    console.log(word.value);
    var msg = word.value.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = msg;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
});

connection.on("WordListComplete", function() {
    var h2 = document.createElement("h2");
    var feedbackDiv = document.getElementById("feedback");
    h2.textContent = "Congrats you finished the list";
    feedbackDiv.append(h2);
})

connection.start().catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("UpdateWordStatus", message, "Correct").catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});
