// Base de dados simulada
const BaseDados = {
    Utilizadores: []
};

// Perfis possíveis
const Perfis = {
    Administrador: "Administrador",
    Utilizador: "Utilizador"
};

// ===== FUNÇÃO PARA CRIAR CONTA =====
function criarConta(nome, email, password, tipoConta, codigoAcesso) {
    try {
        if (!nome || !nome.trim()) throw new Error("Nome obrigatório");
        if (!email || !email.trim()) throw new Error("Email obrigatório");
        if (!password || password.length < 4) throw new Error("Password deve ter pelo menos 4 caracteres");

        // Verifica se email já existe
        if (BaseDados.Utilizadores.some(u => u.email.toLowerCase() === email.toLowerCase())) {
            throw new Error("Email já está em uso");
        }

        const id = Math.floor(Math.random() * 1000000) + 1;

        if (tipoConta === Perfis.Administrador) {
            if (!codigoAcesso || !codigoAcesso.trim()) throw new Error("Código de acesso obrigatório para administrador");

            const admin = { id, nome, email, password, tipoConta: Perfis.Administrador, codigoAcesso };
            BaseDados.Utilizadores.push(admin);
        } else {
            const user = { id, nome, email, password, tipoConta: Perfis.Utilizador };
            BaseDados.Utilizadores.push(user);
        }

        console.log("Conta criada com sucesso:", nome);
        return true;
    } catch (err) {
        console.error("Erro:", err.message);
        alert("Erro: " + err.message);
        return false;
    }
}

// ===== FUNÇÃO DE LOGIN =====
function login(email, password) {
    try {
        if (!email || !email.trim()) throw new Error("Email obrigatório");
        if (!password || !password.trim()) throw new Error("Password obrigatória");

        const utilizador = BaseDados.Utilizadores.find(u => u.email.toLowerCase() === email.toLowerCase() && u.password === password);

        if (!utilizador) throw new Error("Credenciais inválidas!");

        // Simular sessão
        sessionStorage.setItem("UserId", utilizador.id);
        sessionStorage.setItem("UserNome", utilizador.nome);
        sessionStorage.setItem("UserPerfil", utilizador.tipoConta);

        console.log(`Login efetuado com sucesso! Bem-vindo ${utilizador.nome}`);
        return true;
    } catch (err) {
        console.error("Erro:", err.message);
        alert("Erro: " + err.message);
        return false;
    }
}

// ===== EVENTO DO FORMULÁRIO DE CRIAR CONTA =====
const signupForm = document.getElementById("signupForm");
if (signupForm) {
    signupForm.addEventListener("submit", function(event) {
        event.preventDefault(); // evita reload da página

        const nome = document.getElementById("nome").value.trim();
        const email = document.getElementById("email").value.trim();
        const password = document.getElementById("password").value;
        const tipoConta = document.getElementById("tipoConta").value;
        const codigoAcesso = document.getElementById("codigoAcesso").value.trim();

        const sucesso = criarConta(nome, email, password, tipoConta, codigoAcesso);

        if (sucesso) {
            alert("Conta criada com sucesso! Redirecionando para login...");
            window.location.href = "login.html";
        }
    });
}

// ===== EVENTO DO FORMULÁRIO DE LOGIN =====
const loginForm = document.getElementById("loginForm");
if (loginForm) {
    loginForm.addEventListener("submit", function(event) {
        event.preventDefault();

        const email = document.getElementById("email").value.trim();
        const password = document.getElementById("password").value;

        const sucesso = login(email, password);
        if (sucesso) {
            // Redireciona para página de relatório
            window.location.href = "relatorio.html";
        }
    });
}

// ===== EXEMPLOS DE CONTAS INICIAIS =====
criarConta("João Silva", "joao@mail.com", "1234", Perfis.Utilizador);
criarConta("Admin Teste", "admin@mail.com", "admin123", Perfis.Administrador, "ABC123");