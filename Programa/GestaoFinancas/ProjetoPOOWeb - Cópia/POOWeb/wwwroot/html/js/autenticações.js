function criarConta(nome, email, password, tipoConta, codigoAcesso) {
    if (!nome || !email || !password || password.length < 4) {
        return { sucesso: false, msg: "Dados inválidos" };
    }

    if (BaseDados.Utilizadores.some(u => u.email === email)) {
        return { sucesso: false, msg: "Email já existe" };
    }

    if (tipoConta === Perfis.Administrador && !codigoAcesso) {
        return { sucesso: false, msg: "Código admin obrigatório" };
    }

    BaseDados.Utilizadores.push({
        id: Date.now(),
        nome,
        email,
        password,
        tipoConta
    });

    return { sucesso: true };
}

function login(email, password) {
    const user = BaseDados.Utilizadores.find(
        u => u.email === email && u.password === password
    );

    if (!user) return false;

    sessionStorage.setItem("usuarioLogado", JSON.stringify({
        nome: user.nome,
        tipoConta: user.tipoConta
    }));
    return true;
}

function logout() {
    sessionStorage.removeItem("usuarioLogado");
    window.location.href = "login.html";
}

function protegerPagina() {
    const usuario = sessionStorage.getItem("usuarioLogado");
    if (!usuario) {
        alert("Faça login para continuar");
        window.location.href = "login.html";
    }
}