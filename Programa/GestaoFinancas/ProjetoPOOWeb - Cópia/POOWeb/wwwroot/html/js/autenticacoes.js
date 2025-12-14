
// BASE DE DADOS E PERFIS

const BaseDados = {
    Utilizadores: JSON.parse(localStorage.getItem("Utilizadores")) || []
};

const Perfis = {
    Administrador: "Administrador",
    Utilizador: "Utilizador"
};

// Salvar BaseDados no localStorage
function salvarBaseDados() {
    localStorage.setItem("Utilizadores", JSON.stringify(BaseDados.Utilizadores));
}

// CRIAR CONTA

function criarConta(nome, email, password, tipoConta, codigoAcesso) {
    if (!nome || !email || !password || password.length < 4) {
        return { sucesso: false, msg: "Dados inválidos" };
    }

    if (BaseDados.Utilizadores.some(u => u.email.toLowerCase() === email.toLowerCase())) {
        return { sucesso: false, msg: "Email já existe" };
    }

    if (tipoConta === Perfis.Administrador && !codigoAcesso) {
        return { sucesso: false, msg: "Código admin obrigatório" };
    }

    const novoUsuario = {
        id: Date.now(),
        nome,
        email,
        password,
        tipoConta
    };

    if (tipoConta === Perfis.Administrador) {
        novoUsuario.codigoAcesso = codigoAcesso;
    }

    BaseDados.Utilizadores.push(novoUsuario);
    salvarBaseDados();

    return { sucesso: true };
}

// LOGIN

function login(email, password) {
    const user = BaseDados.Utilizadores.find(
        u => u.email.toLowerCase() === email.toLowerCase() && u.password === password
    );

    if (!user) return false;

    sessionStorage.setItem("usuarioLogado", JSON.stringify({
        nome: user.nome,
        tipoConta: user.tipoConta
    }));

    return true;
}

// LOGOUT
function logout() {
    sessionStorage.removeItem("usuarioLogado");
    window.location.href = "login.html";
}

// PROTEÇÃO DE PÁGINA
function protegerPagina() {
    const usuario = sessionStorage.getItem("usuarioLogado");
    if (!usuario) {
        alert("Faça login para continuar");
        window.location.href = "login.html";
    }
}