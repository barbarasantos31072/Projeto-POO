using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.IO;
using System.Text.Json;

namespace POOWeb.Classes
{
    public class Categoria
    {

        private static readonly string ficheiro = "Data/categorias.json";
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
            GuardarDados();
            return nova;
        }
        //Eliminar Categoria
        public static bool EliminarCategoria(string nome)
        {
            Categoria categoria = ObterPorNome(nome);

            if (categoria == null)
                return false;

            ListaCategorias.Remove(categoria);
            GuardarDados();
            return true;
        }
        public static Categoria ObterPorNome(string nome)
        {
            return Categoria.ListaCategorias
                .FirstOrDefault(c => c.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase), null);
        }

        // Guardar categorias no ficheiro JSON
        public static void GuardarDados()
        {
            string pasta = Path.GetDirectoryName(ficheiro);
            if (!Directory.Exists(pasta))
                Directory.CreateDirectory(pasta);

            string json = JsonSerializer.Serialize(ListaCategorias, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(ficheiro, json);
        }

        // Carregar categorias do ficheiro JSON
        public static void CarregarDados()
        {
            if (!File.Exists(ficheiro))
                return;

            string json = File.ReadAllText(ficheiro);

            try
            {
                ListaCategorias = JsonSerializer.Deserialize<List<Categoria>>(json) ?? new List<Categoria>();
            }
            catch
            {
                ListaCategorias = new List<Categoria>();
            }
        }
    }
}
