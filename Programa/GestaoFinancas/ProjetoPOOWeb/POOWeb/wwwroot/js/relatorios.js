document.addEventListener("DOMContentLoaded", function () {

    const saldoSpan = document.getElementById("saldo");
    const totalReceitasSpan = document.getElementById("totalReceitas");
    const totalDespesasSpan = document.getElementById("totalDespesas");
    const listaCategoria = document.getElementById("porCategoria");

    const inicioInput = document.getElementById("inicio");
    const fimInput = document.getElementById("fim");
    const btnFiltrar = document.getElementById("filtrar");


    fetch("http://localhost:5126/api/relatorios/saldo", {
        credentials: "include"
    })
        .then(res => res.json())
        .then(valor => {
            saldoSpan.textContent = valor.toFixed(2) + " €";
        });


    fetch("http://localhost:5126/api/relatorios/despesas", {
        credentials: "include"
    })
        .then(res => res.json())
        .then(total => {
            totalDespesasSpan.textContent = total.toFixed(2) + " €";
        });


    fetch("http://localhost:5126/api/relatorios/receitas", {
        credentials: "include"
    })
        .then(res => res.json())
        .then(total => {
            totalReceitasSpan.textContent = total.toFixed(2) + " €";
        });
fetch("http://localhost:5126/api/relatorios/categoria", {
        credentials: "include"
    })
        .then(res => res.json())
        .then(dados => {

            listaCategoria.innerHTML = "";

            dados.forEach(item => {
                const li = document.createElement("li");
                li.textContent = `${item.categoria.nome}: ${item.total.toFixed(2)} €`;
                listaCategoria.appendChild(li);
            });
        });


    btnFiltrar.addEventListener("click", () => {

        const inicio = inicioInput.value;
        const fim = fimInput.value;

        if (!inicio || !fim) {
            alert("Selecione as duas datas");
            return;
        }

        fetch(`http://localhost:5126/api/relatorios/despesas?inicio=${inicio}&fim=${fim}`, {
            credentials: "include"
        })
            .then(res => res.json())
            .then(total => {
                totalDespesasSpan.textContent = total.toFixed(2) + " €";
            });

        fetch(`http://localhost:5126/api/relatorios/receitas?inicio=${inicio}&fim=${fim}`, {
            credentials: "include"
        })
            .then(res => res.json())
            .then(total => {
                totalReceitasSpan.textContent = total.toFixed(2) + " €";
            });
    });
});