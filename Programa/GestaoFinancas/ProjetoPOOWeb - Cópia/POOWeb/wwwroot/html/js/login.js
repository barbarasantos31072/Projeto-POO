// ===== Base de dados simulada =====
const BaseDados = {
    Utilizadores: []
};

const Perfis = { Administrador: "Administrador", Utilizador: "Utilizador" };

// ===== Criar Conta =====
function criarConta(nome, email, password, tipoConta, codigoAcesso) {
    if (!nome.trim() || !email.trim() || !password || password.length < 4) {
        alert("Todos os campos obrigatórios ou senha menor que 4 caracteres");
        return false;
    }

    if (BaseDados.Utilizadores.some(u => u.email.toLowerCase() === email.toLowerCase())) {
        alert("Email já cadastrado!");
        return false;
    }

    const id = Math.floor(Math.random() * 1000000) + 1;

    if (tipoConta === Perfis.Administrador && !codigoAcesso.trim()) {
        alert("Código de acesso obrigatório para admin");
        return false;
    }

    BaseDados.Utilizadores.push({ id, nome, email, password, tipoConta, codigoAcesso });
    alert("Conta criada com sucesso!");
    return true;
}

// ===== Login =====
function login(email, password) {
    const user = BaseDados.Utilizadores.find(u => u.email.toLowerCase() === email.toLowerCase() && u.password === password);
    if (!user) {
        alert("Credenciais inválidas!");
        return false;
    }

    sessionStorage.setItem("usuarioLogado", JSON.stringify({ nome: user.nome, tipoConta: user.tipoConta }));
    return true;
}

// ===== Eventos =====
document.addEventListener("DOMContentLoaded", () => {
    // Criar conta
    const signupForm = document.getElementById("signupForm");
    if (signupForm) {
        signupForm.addEventListener("submit", e => {
            e.preventDefault();
            const nome = document.getElementById("nome").value;
            const email = document.getElementById("email").value;
            const password = document.getElementById("password").value;
            const tipoConta = document.getElementById("tipoConta").value;
            const codigoAcesso = document.getElementById("codigoAcesso").value;
            const sucesso = criarConta(nome, email, password, tipoConta, codigoAcesso);
            if (sucesso) window.location.href = "login.html";
        });
    }

    // Login
    const loginForm = document.getElementById("loginForm");
    if (loginForm) {
        loginForm.addEventListener("submit", e => {
            e.preventDefault();
            const email = document.getElementById("email").value;
            const password = document.getElementById("password").value;
            if (login(email, password)) window.location.href = "relatorio.html";
        });
    }

    // Exemplo de contas iniciais
    if (BaseDados.Utilizadores.length === 0) {
        criarConta("João Silva", "joao@mail.com", "1234", Perfis.Utilizador);
        criarConta("Admin Teste", "admin@mail.com", "admin123", Perfis.Administrador, "ABC123");
    }
});
5️⃣ relatorio.js (relatório funcional)
javascript
Copiar código
// ===== Lista de transações =====
const Transacao = {
    ListaTransacoes: [
        { descricao: "Almoço", valor: 15.5, data: new Date("2025-12-01"), categoria: "Alimentação", tipo: "Despesa" },
        { descricao: "Salário", valor: 1200, data: new Date("2025-12-01"), categoria: "Salário", tipo: "Receita" },
        { descricao: "Cinema", valor: 20, data: new Date("2025-12-03"), categoria: "Lazer", tipo: "Despesa" },
        { descricao: "Freelance", valor: 300, data: new Date("2025-12-05"), categoria: "Trabalho", tipo: "Receita" }
    ]
};

// ===== Funções =====
function totalDespesas() {
    return Transacao.ListaTransacoes.filter(t => t.tipo === "Despesa").reduce((acc, t) => acc + t.valor, 0);
}

function relatorioPorCategoria() {
    const mapa = {};
    Transacao.ListaTransacoes.forEach(t => mapa[t.categoria] = (mapa[t.categoria] || 0) + t.valor);
    return Object.keys(mapa).map(c => ({ categoria: c, total: mapa[c] }));
}

// ===== Renderização =====
function renderizarRelatorio() {
    const usuario = JSON.parse(sessionStorage.getItem("usuarioLogado"));
    if (!usuario) {
        alert("Faça login antes de acessar o relatório!");
        window.location.href = "login.html";
        return;
    }

    const totalSpan = document.getElementById("total");
    const ulCategorias = document.getElementById("porCategoria");

    totalSpan.innerText = totalDespesas().toFixed(2) + " €";

    ulCategorias.innerHTML = "";
    relatorioPorCategoria().forEach(cat => {
        const li = document.createElement("li");
        li.innerText = `${cat.categoria}: ${cat.total.toFixed(2)} €`;
        ulCategorias.appendChild(li);
    });
}

window.addEventListener("DOMContentLoaded", renderizarRelatorio);