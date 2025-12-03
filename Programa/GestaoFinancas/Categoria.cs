using System;
using System.Data.Common;
public class Categoria
{
    public int Id { get; set; }
    public string NomeCategoria { get; set; }
    public string Tipo { get; set; }

    // Construtor
    public Categoria(int id, string nomecat, string tipo)
    {
        Id = id;
        NomeCategoria = nomecat;
        Tipo = tipo;
    }

    // Método criar categoria
    public static List<Categoria> ListaCategorias = new List<Categoria>();
    public static Categoria CriarCategoria()
    {
        Random rnd = new Random();
        int idGerado = rnd.Next(1, 1000000);
        Console.WriteLine("=== Criar Nova Categoria ===");

        Console.Write("Nome da categoria: ");
        string nomecat = Console.ReadLine();

        Console.Write("Tipo da categoria: ");
        string tipo = Console.ReadLine();

        Categoria nova = new Categoria(idGerado, nomecat, tipo);

        ListaCategorias.Add(nova);


        Console.WriteLine("Categoria criada com sucesso!");

        return nova;
    }

    public static void ListarCategorias()
    {
        Console.WriteLine("=== Categorias Existentes ===");

        foreach (var c in ListaCategorias)
        {
            Console.WriteLine($"{c.Id} - {c.NomeCategoria}");
        }

    }

}