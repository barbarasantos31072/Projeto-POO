const Categoria = {
        ListaCategorias: [],

        CriarCategoria: function(nome) {
            if (!nome || !nome.trim()) return null;
            if (this.ListaCategorias.includes(nome)) return null;
            this.ListaCategorias.push(nome);
            renderizarCategorias();
            return nome;
        },

        EliminarCategoria: function(nome) {
            const index = this.ListaCategorias.indexOf(nome);
            if (index === -1) return false;
            this.ListaCategorias.splice(index, 1);
            renderizarCategorias();
            return true;
        }
    };

    const listaUL = document.getElementById("listaCategorias");

    function criarCategoria() {
        const nome = document.getElementById("categoriaNome").value.trim();
        if (!nome) return;
        Categoria.CriarCategoria(nome);
        document.getElementById("categoriaNome").value = "";
    }

    function renderizarCategorias() {
        listaUL.innerHTML = ""; // limpa lista
        Categoria.ListaCategorias.forEach(nome => {
            const li = document.createElement("li");
            li.innerText = nome;

            const btnApagar = document.createElement("button");
            btnApagar.innerText = "Apagar";
            btnApagar.onclick = () => Categoria.EliminarCategoria(nome);

            li.appendChild(btnApagar);
            listaUL.appendChild(li);
        });
    }
