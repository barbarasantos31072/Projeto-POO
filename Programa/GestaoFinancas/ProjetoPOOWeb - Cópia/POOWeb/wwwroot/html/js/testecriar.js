const tipo = document.getElementById("tipo");
    const adminCode = document.getElementById("adminCode");

    tipo.addEventListener("change", () => {
        if (tipo.value === "Administrador") {
            adminCode.style.display = "block";
        } else {
            adminCode.style.display = "none";
            adminCode.value = "";
        }