let getById = (id, parent) => parent ? parent.getElementById(id) : getById(id, document);
let getByClass = (className, parent) => parent ? parent.getElementsByClassName(className) : getByClass(className, document);


function generateUUID() { // Public Domain/MIT
    var d = new Date().getTime();//Timestamp
    var d2 = performance && performance.now && performance.now() * 1000 || 0;//Time in microseconds since page-load or 0 if unsupported
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16;//random number between 0 and 16
        if (d > 0) {//Use timestamp until depleted
            r = (d + r) % 16 | 0;
            d = Math.floor(d / 16);
        } else {//Use microseconds since page-load if supported
            r = (d2 + r) % 16 | 0;
            d2 = Math.floor(d2 / 16);
        }
        return (c === 'x' ? r : r & 0x3 | 0x8).toString(16);
    });
}

//console.log("generateUUID:" + generateUUID());
function hide(element) {
    //console.log("hide [" + element.id + "]");
    element.classList.remove("block");
    element.classList.remove("show");
    element.classList.add("hide");
    element.style.display = "none";
}

function show(element) {
    //console.log("show [" + element +"]");
    element.classList.remove("hide");
    element.classList.add("block");
    element.classList.add("show");
    element.style.display = "block";

}

function hideMessage() {
    mensagemretorno = getById("mensagemretorno");
    hide(mensagemretorno);
}

function showMessage(mensagem, type) {
    mensagemretorno = getById("mensagemretorno");
    //console.log("showMessage", mensagemretorno);

    mensagemretorno.classList.remove("error");
    mensagemretorno.classList.remove("success");
    mensagemretorno.classList.add(type);

    mensagemretorno.innerHTML = mensagem;
    console.log(mensagem);

    //mensagemretorno.innerHTML = mensagem + "<span onclick='hide(mensagemretorno);' class='closePanel'>X</span>";

    show(mensagemretorno);

    setTimeout(function () {
        hide(mensagemretorno);
    }, 10000);

}

function ScrollToEnd(element) {
    element.scrollTop = element.scrollHeight;
}

function filter(e) {
    search = e.value.toLowerCase();

    document.querySelectorAll('.itemLista').forEach(function (row) {
        text = row.innerText.toLowerCase();
        if (text.match(search)) {
            row.style.display = "block";
        } else {
            row.style.display = "none";
        }
    });
}
