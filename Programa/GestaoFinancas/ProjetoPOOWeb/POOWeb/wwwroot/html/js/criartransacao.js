document.getElementById("criartransacaoForm").addEventListener("submit", async function (e) {
    e.preventDefault();

    const data = {
        descricao: document.getElementById("descricao").value,
        valor: parseFloat(document.getElementById("valor").value),
        data: document.getElementById("data").value,
        categoria: document.getElementById("categoria").value,
        tipo: document.getElementById("tipo").value
    };

    try {
        const response = await fetch("http://localhost:5126/api/transacoes/criartransacao", {
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
        document.getElementById("criartransacaoForm").reset();

    } catch (err) {
        alert("Erro ao ligar ao servidor: " + err);
    }

});
