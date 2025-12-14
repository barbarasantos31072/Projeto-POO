document.getElementById("criarCategoriaForm").addEventListener("submit", async function (e) {
    e.preventDefault();

    const data = {
        nome: document.getElementById("nomeCategoria").value
    };

    try {
        const response = await fetch("http://localhost:5126/api/categorias", {
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

        document.getElementById("criarCategoriaForm").reset();


    } catch (err) {
        alert("Erro ao ligar ao servidor: " + err);
    }
});
