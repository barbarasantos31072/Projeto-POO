protegerPagina();

// ================= CAPTURA DE ELEMENTOS =================
const totalSpan = document.getElementById("total");
const ulCategorias = document.getElementById("porCategoria");

// ================= RENDERIZAÇÃO =================
function renderizarRelatorio() {
    const totalGasto = totalDespesas();
    totalSpan.textContent = totalGasto.toFixed(2) + " €";

    ulCategorias.innerHTML = "";
    relatorioPorCategoria().forEach(cat => {
        const li = document.createElement("li");
        li.textContent = `${cat.categoria}: ${cat.total.toFixed(2)} €`;
        ulCategorias.appendChild(li);
    });
}

document.addEventListener("DOMContentLoaded", renderizarRelatorio);
