document.getElementById("loginForm").addEventListener("submit", async function (e) {
    e.preventDefault();

    const data = {
        email: document.getElementById("email").value,
        password: document.getElementById("password").value,
    };

    try {
        const response = await fetch("http://localhost:5126/api/conta/login", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(data)
        });

        const result = await response.json();

        if (!response.ok) {
            alert("Erro: " + result.erro);
            return;
        }


        localStorage.setItem("usuarioEmail", data.email);
        if (result.token) {
            localStorage.setItem("token", result.token);
        }

        alert(result.mensagem);
        window.location.href = "paginicial.html";

    } catch (err) {
        alert("Erro ao ligar ao servidor: " + err);
    }
});
