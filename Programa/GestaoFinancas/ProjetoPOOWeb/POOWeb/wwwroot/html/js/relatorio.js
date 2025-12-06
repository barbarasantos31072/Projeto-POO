// ===== Simula a lista de transações =====
const Transacao = {
    ListaTransacoes: [
        { descricao: "Almoço", valor: 15.5, data: new Date("2025-12-01"), categoria: "Alimentação", tipo: "Despesa" },
        { descricao: "Salário", valor: 1200, data: new Date("2025-12-01"), categoria: "Salário", tipo: "Receita" },
        { descricao: "Cinema", valor: 20, data: new Date("2025-12-03"), categoria: "Lazer", tipo: "Despesa" },
        { descricao: "Freelance", valor: 300, data: new Date("2025-12-05"), categoria: "Trabalho", tipo: "Receita" }
    ]
};

// ===== Funções de cálculo =====
function relatorioPorCategoria() {
    const mapa = {};
    Transacao.ListaTransacoes.forEach(t => {
        if (!mapa[t.categoria]) mapa[t.categoria] = 0;
        mapa[t.categoria] += t.valor;
    });

    return Object.keys(mapa).map(c => ({
        categoria: c,
        total: mapa[c]
    }));
}

function totalPorTipo(tipo, inicio = null, fim = null) {
    let total = 0;
    Transacao.ListaTransacoes.forEach(t => {
        if (t.tipo === tipo) {
            if ((inicio && t.data < inicio) || (fim && t.data > fim)) return;
            total += t.valor;
        }
    });
    return total;
}

function totalDespesas(inicio = null, fim = null) {
    return totalPorTipo("Despesa", inicio, fim);
}

function totalReceitas(inicio = null, fim = null) {
    return totalPorTipo("Receita", inicio, fim);
}

function totalSaldo() {
    return totalReceitas() - totalDespesas();
}

// ===== Captura elementos HTML =====
const totalSpan = document.getElementById("total");
const ulCategorias = document.getElementById("porCategoria");

// ===== Função para renderizar relatório =====
function renderizarRelatorio() {
    // Verifica se usuário está logado
    const usuario = JSON.parse(sessionStorage.getItem("usuarioLogado"));
    if (!usuario) {
        alert("Você precisa fazer login para acessar esta página!");
        window.location.href = "login.html";
        return;
    }

    // Total gasto
    const totalGasto = totalDespesas();
    totalSpan.innerText = totalGasto.toFixed(2) + " €";

    // Por categoria
    const categorias = relatorioPorCategoria();
    ulCategorias.innerHTML = "";
    categorias.forEach(cat => {
        const li = document.createElement("li");
        li.innerText = `${cat.categoria}: ${cat.total.toFixed(2)} €`;
        ulCategorias.appendChild(li);
    });

    // Você pode também mostrar o saldo total se quiser
    console.log(`Saldo total: ${totalSaldo().toFixed(2)} €`);
}

// ===== Executa ao carregar a página =====
window.addEventListener("DOMContentLoaded", renderizarRelatorio);