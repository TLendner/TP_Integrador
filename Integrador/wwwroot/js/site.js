function validarNum() {
    let exito = true;
    let num = Number(document.getElementById("num").value); 
    
    if (!Number.isInteger(num) || num < 0) {
        alert("Error");
        exito = false;
    }
    
    return exito;
}

function validarFormAdmin() {
return(validarNum())
}

function validarPassword() {
    let mensajeA = document.getElementById("mensajeA");
    let mensajeB = document.getElementById("mensajeB");
    let mensajeC = document.getElementById("mensajeC");
    let pass = document.getElementById("password").value;
    const expresionRegular = /[^a-zA-Z0-9]/;

    mensajeA.style.color = (pass.length > 7 ? "green" : "red");
    mensajeB.style.color = (pass === pass.toLowerCase() ? "red" : "green");
    mensajeC.style.color = (expresionRegular.test(pass) ? "green" : "red");


    const esValida = (mensajeA.style.color === "green" && mensajeB.style.color === "green" && mensajeC.style.color === "green");


    document.getElementById("password").style.borderColor = (esValida ? "green" : "red");

    return esValida;
}

function validarMail() {
    let mail = document.getElementById("mail").value;
    const expresionRegular = /@/; 
    if (expresionRegular.test(mail)) {
        document.getElementById("mail").style.borderColor = "green";
        return true;
    } else {
        document.getElementById("mail").style.borderColor = "red";
        return false;
    }
}

function validarForm() {
    return (validarPassword() && validarMail());
}
function validarForm() {
    return (validarPassword());
}


var modal = document.getElementById("infoModal");


var btn = document.getElementById("infoButton");


var span = document.getElementsByClassName("close")[0];


btn.onclick = function() {
    modal.style.display = "block";
}

span.onclick = function() {
    modal.style.display = "none";
}

window.onclick = function(event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}
