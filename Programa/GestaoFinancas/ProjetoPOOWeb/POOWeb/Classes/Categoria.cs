using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace POOWeb.Classes
{
    public class Categoria
    {
        // Propriedades

        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da categoria é obrigatório.")]
        public string Nome { get; set; }

        // Lista de Categorias
        public static List<Categoria> ListaCategorias = new List<Categoria>();

        // Random para gerar ID
        private static Random rnd = new Random();

        private static int GerarId()
        {
            return rnd.Next(1, 9999999);
        }

        // Construtor
        public Categoria(int id, string nomecat)
        {
            Id = id;
            Nome = nomecat;
        }

        // Criar categoria
        public static Categoria CriarCategoria(string nome)
        {
            int id = GerarId();
            Categoria nova = new Categoria(id, nome);
            ListaCategorias.Add(nova);
            return nova;
        }
        //Eliminar Categoria
        public static bool EliminarCategoria(string nome)
        {
            Categoria categoria = ObterPorNome(nome);

            if (categoria == null)
                return false;

            ListaCategorias.Remove(categoria);
            return true;
        }
        public static Categoria ObterPorNome(string nome)
        {
            return Categoria.ListaCategorias
                .FirstOrDefault(c => c.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase), null);
        }
    }
}
