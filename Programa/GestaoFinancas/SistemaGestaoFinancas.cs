using System;
using System.Collections.Generic;

namespace ProjetoFinal.Classes
{
    public class SistemaGestaoFinancas
    {
        private List<Utilizador> utilizadores = new List<Utilizador>();
        private List<Receita> receitas = new List<Receita>();
        private List<Despesa> despesas = new List<Despesa>();
        private Utilizador? utilizadorAtual;

        //Adicionar Transação
            public void AdicionarTransacao()
            {
                Console.WriteLine("\n=== ADICIONAR TRANSAÇÃO ===");
                Console.WriteLine("1 - Receita");
                Console.WriteLine("2 - Despesa");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();


                Console.Write("Descrição: ");
                string descricao = Console.ReadLine();

                Console.Write("Valor (€): ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal valor) || valor <= 0)
                {
                    Console.WriteLine("Valor inválido! Deve ser maior que 0.");
                    return;
                }

                Console.Write("Data (AAAA-MM-DD): ");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime data))
                {
                    Console.WriteLine("Data inválida!");
                    return;
                }

                Console.Write("Categoria: "); //if categoria nao existir invocar metodo criar categoria
                string categoria = Console.ReadLine();

                if (opcao == "1")
                {
                    Receita novaReceita = new Receita(receitas.Count + 1, descricao, valor, data, categoria);

                    if (!novaReceita.ValidarValor())
                    {
                        Console.WriteLine("Valor inválido!");
                        return;
                    }

                    receitas.Add(novaReceita);
                    Console.WriteLine("Receita adicionada com sucesso!");
                }
                else if (opcao == "2")
                {
                    Despesa novaDespesa = new Despesa(despesas.Count + 1, descricao, valor, data, categoria);

                    if (!novaDespesa.ValidarValor())
                    {
                        Console.WriteLine("Valor inválido!");
                        return;
                    }

                    despesas.Add(novaDespesa);
                    Console.WriteLine("Despesa adicionada com sucesso!");
                }
                else
                {
                    Console.WriteLine("Opção inválida!");
                }
            }
        }
    }

