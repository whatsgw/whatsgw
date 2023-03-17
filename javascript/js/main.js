
(function ($) {
    "use strict";

    if (window.location.protocol == 'http:') {
        location.href = location.href.replace("http://", "https://");
    }

    

    function showValidate(input) {
        var thisAlert = $(input).parent();

        $(thisAlert).addClass('alert-validate');
    }

    function hideValidate(input) {
        var thisAlert = $(input).parent();

        $(thisAlert).removeClass('alert-validate');
    }
    
    

})(jQuery);

var btnenviar = document.getElementById('btnenviar'),
    txtapikey = document.getElementById('txtapikey'),
    txtphone_number = document.getElementById('txtphone_number'),
    txtcontact_phone_number = document.getElementById('txtcontact_phone_number'),
    txtbody = document.getElementById('txtbody'),
    mensagemretorno = document.getElementById("mensagemretorno");

    txtapikey.value = "B3CA76C2-07F3-47E6-A2F8-YOWAPIKEY";
    txtphone_number.value = "5511999999999";
    txtcontact_phone_number.value = "5511988888888";
    txtbody.value = "Teste de Msg\n_Italico_ \n*negrito*\n~tachado~\n```Monoespaçado```\n😜";

hide(mensagemretorno);


function Enviar() {
    var req = new XMLHttpRequest();   // new HttpRequest instance 
    req.open("POST", "https://app.whatsgw.com.br/api/WhatsGw/Send");
    //req.open("POST", "http://localhost:58661/WhatsGwChat/login");
    //req.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
    req.setRequestHeader('Accept', '*/*');
    req.onload = function () {
        var jsonResponse = req.response;
        //console.log(req.readyState, req.status, jsonResponse);

        if (this.status === 200) {
            showMessage("Retorno: " + jsonResponse);
        } else {
            showMessage("Falhou: " + req.status);
        }
        // do something with jsonResponse
    };

    req.onerror = function (event) {
        showMessage("Falhou: " + event);
    };

    req.send(JSON.stringify({
        apikey: txtapikey.value,
        phone_number: txtphone_number.value,
        contact_phone_number: txtcontact_phone_number.value,
        message_custom_id: "yoursoftwareid",
        message_type: "text",
        message_body: txtbody.value,
        check_status: "1"
      }));
}

btnenviar.onclick = function (e) {
    e.preventDefault();

    Enviar();

};