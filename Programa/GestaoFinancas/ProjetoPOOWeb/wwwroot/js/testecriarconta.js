document.getElementById("tipoConta").addEventListener("change", function () {
    let campoCodigo = document.getElementById("codigoAcesso");

    if (this.value === "Administrador") {
        campoCodigo.style.display = "block";
    } else {
        campoCodigo.style.display = "none";
        campoCodigo.value = "";
    }
});