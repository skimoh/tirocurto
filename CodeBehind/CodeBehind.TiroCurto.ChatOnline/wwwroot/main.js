"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chat").build();
$("#send").disabled = true;

//recebptor da mensagem postada broadcast
connection.on("ReceiveMessage", function (usuarioQueMandou, mensagem, usuarioQueRecebe) {

    var usuarioLogado = $("#usuario").val();

    if (usuarioLogado == usuarioQueRecebe || usuarioQueRecebe == 'todos') {
        var msg = mensagem.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
        var li = $("<li></li>").text(usuarioQueMandou + ": " + msg);
        li.addClass("list-group-item");
        $("#messagesList").append(li);
    }

    if (usuarioLogado == usuarioQueMandou && usuarioQueRecebe != 'todos') {
        var msg = mensagem.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
        var li = $("<li></li>").text(usuarioQueMandou + ": " + msg);
        li.addClass("list-group-item");
        li.addClass("quandoManda");
        $("#messagesList").append(li);
    }
});

//Ação de envio de mensagens
$("#send").on("click", function (event) {    
    var mensagem = $("#mensagem").val();
    var usuarioDestino = $("#destino").val();
    var connectionId = sessionStorage.getItem('conectionId');
    var usuarioLogado = $("#usuario").val();

    //invocar uma chamada no backend
    connection.invoke("SendMessage", usuarioLogado, mensagem, usuarioDestino, connectionId).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});


connection.start().then(function () {

    console.log("conectado-SignalR");

    connection.invoke('getConnectionId')
        .then(function (connectionId) {
            sessionStorage.setItem('conectionId', connectionId);            
        }).catch(err => console.error(err.toString()));;
});

$(document).ready(function () {
    //nomes randomicos para usuario logado
    var quotes = new Array("joao", "pedro","lucas","samuel");
    var randno = quotes[Math.floor(Math.random() * quotes.length)];
    $('#usuario').val(randno);

});