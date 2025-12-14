document.getElementById("signupForm").addEventListener("submit", async function (e) {
    e.preventDefault();

    const data = {
        nome: document.getElementById("nome").value,
        email: document.getElementById("email").value,
        password: document.getElementById("password").value,
        tipoConta: document.getElementById("tipoConta").value,
        codigoAcesso: document.getElementById("codigoAcesso").value
    };

    try {
        const response = await fetch("http://localhost:5126/api/conta/criar", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(data)
        });

        const result = await response.json();

        if (!response.ok) {
            alert("Erro: " + result.erro);
            return;
        }

        alert(result.mensagem);
        window.location.href = "login.html";

    } catch (err) {
        alert("Erro ao ligar ao servidor: " + err);
    }
});
