document.addEventListener("DOMContentLoaded", function () {
        const form = document.getElementById("criarcategoriaForm");
        const lista = document.getElementById("listaCategorias");

        fetch("http://localhost:5126/api/categoria/listar", { 
            credentials: "include" 
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error("Erro ao carregar categorias");
                }
                return response.json();
            })

            .then(categorias => {

                lista.innerHTML = "";

                categorias.forEach(categoria => {

                    const item = document.createElement("li");
                    item.textContent = categoria.nome;

                    const btnApagar = document.createElement("button");
                    btnApagar.textContent = "🗑️";
                    btnApagar.type = "button";

                    btnApagar.addEventListener("click", async () => {
                        if (!confirm("Apagar esta categoria?")) return;

                        const response = await fetch(
                            `http://localhost:5126/api/categoria/eliminar/${categoria.nome}`,
                            {
                                method: "DELETE",
                                credentials: "include"
                            }
                        );

                        if (response.ok) {
                            item.remove();
                        } else {
                            alert("Erro ao apagar categoria");
                        }
                    });

                    item.appendChild(btnApagar);
                    lista.appendChild(item);
                });
            })
            .catch(error => {
                console.error(error);
                lista.innerHTML = "<li>Erro ao carregar categorias</li>";
            });

        form.addEventListener("submit", async function (e) {
            e.preventDefault();

            const data = {
                nome: document.getElementById("categoriaNome").value
            };
            try {
                const response = await fetch("http://localhost:5126/api/categoria/criar", {
                    method: "POST",
                    credentials: "include",
                    headers: { "Content-Type": "application/json" },
                    body: JSON.stringify(data)
                });

                const result = await response.json();

                if (!response.ok) {
                    alert("Erro: " + result.erro);
                    return;
                }

                alert(result.mensagem);
                form.reset();
                location.reload();

            } catch (err) {
                alert("Erro ao ligar ao servidor: " + err);
            }
        }
    );
})
