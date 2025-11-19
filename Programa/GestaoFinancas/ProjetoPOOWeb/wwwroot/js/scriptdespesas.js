function addDespesa() {
    let desc = document.getElementById("descricao").value;
    let valor = document.getElementById("valor").value;

    if (desc.trim() === "" || valor.trim() === "") {
        alert("Preenche a descrição e o valor!");
        return;
    }

    let tabela = document.getElementById("tabelaDespesas").querySelector("tbody");

    let row = tabela.insertRow();
    row.innerHTML = `
        <td>${desc}</td>
        <td>${parseFloat(valor).toFixed(2)} €</td>
        <td><button class="btn-del" onclick="removeDespesa(this)">Remover</button></td>
    `;

    document.getElementById("descricao").value = "";
    document.getElementById("valor").value = "";
}
