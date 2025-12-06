async function adicionarTransacao() {
    const desc = document.getElementById("descricao").value;
    const val = parseFloat(document.getElementById("valor").value);
    const data = document.getElementById("data").value;
    const cat = document.getElementById("categoria").value;
    const tipo = document.getElementById("tipo").value;

    if (!desc || !val || !data || !cat || !tipo) {
        alert("Todos os campos são obrigatórios!");
        return;
    }

    const transacao = { Descricao: desc, Valor: val, Data: data, Categoria: cat, Tipo: tipo };

    try {
        const response = await fetch('/api/transacoes', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(transacao)
        });

        if (!response.ok) {
            const erro = await response.json();
            alert("Erro: " + erro.erro);
            return;
        }

        const nova = await response.json();
        adicionarLinhaTabela(nova);

        document.getElementById("descricao").value = "";
        document.getElementById("valor").value = "";
        document.getElementById("data").value = "";
    } catch (err) {
        console.error(err);
        alert("Erro ao criar transação.");
    }
}

function adicionarLinhaTabela(trans) {
    const tabela = document.getElementById("tabelaTransacoes");
    const row = tabela.insertRow();
    row.innerHTML = `
        <td>${trans.descricao}</td>
        <td>${trans.valor.toFixed(2)} €</td>
        <td>${new Date(trans.data).toLocaleDateString()}</td>
        <td>${trans.categoria.nome}</td>
        <td>${trans.tipo}</td>
        <td>
            <button class="btn-small yellow" onclick="editar(this)">Editar</button>
            <button class="btn-small red" onclick="remover(this)">Eliminar</button>
        </td>
    `;
}