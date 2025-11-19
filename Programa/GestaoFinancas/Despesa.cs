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
            Random random = new Random();
            int id = random.Next(1, 10000);
            Console.Write("Descrição: ");
            string descricao = Console.ReadLine();

            Console.Write("Valor (€): ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal valor) || valor <= 0)
            {
                Console.WriteLine("Valor inválido! Deve ser maior que 0.");
                return null;
            }
            Console.Write("Data (AAAA-MM-DD): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime data))
            {
                Console.WriteLine("Data inválida!");
                return null;
            }

            Console.Write("Categoria: "); //if categoria nao existir invocar metodo criar categoria
            string categoria = Console.ReadLine();

            return new Despesa(id, descricao, valor, data, categoria, "Despesa");
        }
    }
}