"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/WordHub").build();


connection.on("ReceiveWord", function (word, status) {
    var $display = $('#display');
    $('body').css("background-color", "white");

    if (status && status === "Correct") {
        $('body').css("background-color", "green");
        $display.text($display.text() + " - Good Job!");
    } 

    if (status && status === "Incorrect") {
        $('body').css("background-color", "red");
        $display.text($display.text() + " - Try Again!");
    }

    setTimeout(function () {
        $('body').css("background-color", "white");
        $display.text(word.value);
    }, 2000);


});


connection.on("WordListComplete", function () {
    var $display = $('#display');
    $('body').css("background-color", "green");
    $display.text($display.text() + " - Good Job!");

    setTimeout(function () {
        $('body').css("background-color", "white");
        $display.text("Congratulations you finished the list!");
    }, 2000);
    setTimeout(function () {
        $('body').css("background-color", "black");
        celebrate();
    }, 4000);
})

function celebrate() {
    var r = 4 + parseInt(Math.random() * 16);
    
    for (var i = r; i--;) {
        setTimeout(function () {
            createFirework(20, 100, 5, null, null, null, null, null, Math.random() > 0.5, true);
        }, (i + 1) * (1 + parseInt(Math.random() * 1000)));
    }
    
}

function writeDebug(data) {
    console.log(data);
}

connection.start().catch(function (err) {
    return console.error(err.toString());
});
