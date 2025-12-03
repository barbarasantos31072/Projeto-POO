using System;

namespace ProjetoFinal.Classes
{
    public class Despesa : Transacao
    {
        public Despesa(int id, string descricao, decimal valor, DateTime data, string categoria, string tipo)
            : base(id, descricao, valor, data, categoria, "Despesa")
        {
            tipo = "Despesa";
        }

        public static Despesa CriarDespesa()
{
    try
    {
        Random random = new Random();
        int id = random.Next(1, 10000);

        Console.WriteLine("\n=== CRIAR DESPESA ===");

        Console.Write("Descrição: ");
        string descricao = Console.ReadLine();

        Console.Write("Valor (€): ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal valor) || valor <= 0)
        {
            throw new Exception("O valor da despesa é inválido! Deve ser um número maior que 0.");
        }

        Console.Write("Data (AAAA-MM-DD): ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime data))
        {
            throw new Exception("A data inserida não é válida!");
        }

        //Categorias
        Console.Write("Categoria: ");
        string nomeCategoria = Console.ReadLine();

        Categoria categoriaSelecionada = Categoria.ListaCategorias
            .Find(c => c.Nome.Equals(nomeCategoria, StringComparison.OrdinalIgnoreCase));

        if (categoriaSelecionada == null)
        {
            Console.WriteLine("Categoria não encontrada! Criar nova? (s/n)");
            string resp = Console.ReadLine().ToLower();

            if (resp == "s")
            {
                categoriaSelecionada = Categoria.CriarCategoria();
            }
            else
            {
                throw new Exception("Nenhuma categoria válida foi atribuída. Operação cancelada.");
            }
        }

        Console.WriteLine("Despesa criada com sucesso!");

        return new Despesa(id, descricao, valor, data, categoriaSelecionada, "Despesa");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"\nERRO: {ex.Message}");
        return null;
    }
}

