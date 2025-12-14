const BaseDados = {
    Utilizadores: JSON.parse(localStorage.getItem("Utilizadores")) || []
};


function salvarBaseDados() {
    localStorage.setItem("Utilizadores", JSON.stringify(BaseDados.Utilizadores));
}