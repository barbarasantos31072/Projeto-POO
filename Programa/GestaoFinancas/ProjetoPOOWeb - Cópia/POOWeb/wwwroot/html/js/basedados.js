const BaseDados = {
    Utilizadores: []
};

const Perfis = {
    Administrador: "Administrador",
    Utilizador: "Utilizador"
};

// contas iniciais
BaseDados.Utilizadores.push(
    { id: 1, nome: "João Silva", email: "joao@mail.com", password: "1234", tipoConta: Perfis.Utilizador },
    { id: 2, nome: "Admin", email: "admin@mail.com", password: "admin123", tipoConta: Perfis.Administrador }
);
