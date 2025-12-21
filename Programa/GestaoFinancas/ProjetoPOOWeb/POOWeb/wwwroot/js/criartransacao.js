const tabela = document.getElementById("tabelaTransacoes");

fetch("http://localhost:5126/api/transacoes/listar")
    .then(response => {
        if (!response.ok) {
            throw new Error("Erro ao carregar transações");
        }
        return response.json();
    })
     .then(transacoes => {

        tabela.innerHTML = "";

        transacoes.forEach(t => {

            const tr = document.createElement("tr");

            const tdDescricao = document.createElement("td");
            tdDescricao.textContent = t.descricao;

            const tdValor = document.createElement("td");
            tdValor.textContent = t.valor.toFixed(2) + " €";

            const tdData = document.createElement("td");
            tdData.textContent = new Date(t.data).toLocaleDateString();

            const tdCategoria = document.createElement("td");
            tdCategoria.textContent = t.categoria.nome;

            const tdTipo = document.createElement("td");
            tdTipo.textContent = t.tipo;

            const tdAcoes = document.createElement("td");
            const btnApagar = document.createElement("button");
            btnApagar.textContent = "🗑️";

            btnApagar.addEventListener("click", () => {
               fetch(`http://localhost:5126/api/transacoes/eliminar/${t.id}`, {
                    method: "DELETE",
                    credentials: "include"
                })
                .then(() => location.reload());
            });

            tdAcoes.appendChild(btnApagar);

            tr.appendChild(tdDescricao);
            tr.appendChild(tdValor);
            tr.appendChild(tdData);
            tr.appendChild(tdCategoria);
            tr.appendChild(tdTipo);
            tr.appendChild(tdAcoes);

            tabela.appendChild(tr);
        });
    })
    .catch(error => {
        console.error("Erro:", error);
        tabela.innerHTML = `
            <tr>
                <td colspan="6">Erro ao carregar transações</td>
            </tr>
        `;
    });

const select = document.getElementById("categoria");
fetch("http://localhost:5126/api/categoria/listar")
    .then(response => {
        if (!response.ok) {
            throw new Error("Network response was not ok");
        }
        return response.json();
    })
    .then(data => {

        data.forEach(categoria => {
            const option = document.createElement("option");
            option.value = categoria.nome;
            option.textContent = categoria.nome;
            select.appendChild(option);
        });
    })
    .catch(error => {
        console.error("Error fetching data:", error);
        select.innerHTML = '<option value="">Failed to load data</option>';
    });

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
            credentials: "include",
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
        location.reload();

    } catch (err) {
        alert("Erro ao ligar ao servidor: " + err);
    }

});