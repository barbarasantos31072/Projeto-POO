document.addEventListener("DOMContentLoaded", () => {
    const form = document.getElementById("signupForm");
    if (!form) return;

    form.addEventListener("submit", e => {
        e.preventDefault();

        const res = criarConta(
            nome.value,
            email.value,
            password.value,
            tipoConta.value,
            codigoAcesso.value
        );

        if (res.sucesso) {
            window.location.href = "login.html";
        } else {
            alert(res.msg);
        }
    });
});