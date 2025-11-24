using System;
using System.Collections.Generic;
using System.Data.Common;

namespace ProjetoFinal.Classes
{
    public class SistemaGestaoFinancas
    {
        private List<Utilizador> utilizadores = new List<Utilizador>();
        private List<Receita> receitas = new List<Receita>();
        private List<Despesa> despesas = new List<Despesa>();
        private Utilizador? utilizadorAtual;

        //Criar Conta
        public List<Utilizador> CriarConta()
        {
            Console.WriteLine("\n=== CRIAR CONTA ===");
            Console.WriteLine("1 - Utilizador");
            Console.WriteLine("2 - Administrador");
            Console.Write("Escolha um perfil: ");

            string perfil = Console.ReadLine();

            if (perfil == "1")
            {

                Utilizador mUtilizador = Utilizador.CriarContaUtilizador();
            }
            else if (perfil == "2")
            {
                Administrador mAdministrador = Administrador.CriarContaAdmin();
            }
            else
            {
                Console.WriteLine("Perfil inválido!");
            }
            return utilizadores;
        }
        //Login
        public void Login()
        {
            Console.WriteLine("\n=== LOGIN ===");

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            Utilizador encontrado = utilizadores.Find(u => u.Email == email && u.Password == password);

            if (encontrado == null)
            {
                Console.WriteLine("Credenciais inválidas!");
                return;
            }

            utilizadorAtual = encontrado;

            Console.WriteLine("\nLogin efetuado com sucesso!");

        }

        //Adicionar Transação
        public void AdicionarTransacao()
        {
            Console.WriteLine("\n=== ADICIONAR TRANSAÇÃO ===");
            Console.WriteLine("Digite um número");
            Console.WriteLine("1 - Receita");
            Console.WriteLine("2 - Despesa");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();
            if (opcao == "1")
            {
                Receita receita = Receita.CriarReceita();
                if (receita != null)
                {
                    receitas.Add(receita);
                    Console.WriteLine("Receita adicionada com sucesso!");
                }
            }
            else if (opcao == "2")
            {
                Despesa despesa = Despesa.CriarDespesa();
                if (despesa != null)
                {
                    despesas.Add(despesa);
                    Console.WriteLine("Despesa adicionada com sucesso!");
                }
            }
            else
            {
                Console.WriteLine("Opção inválida! Deve escolher 1 ou 2.");
                return;
            }
        }
        public decimal TotalReceitas()
        {
            decimal total = 0;

            foreach (var receita in receitas)
            {
                total += receita.Valor;
            }

            return total;
        }
        public decimal TotalDespesas()

        {
            decimal total = 0;

            foreach (var despesa in despesas)
            {
                total += despesa.Valor;
            }

            return total;
        }
        //Menu Relatório
        public void MenuRelatorios()
        {
            bool sair = false;

            while (!sair)
            {
                Console.WriteLine("\n=== MENU DE RELATÓRIOS ===");
                Console.WriteLine("1 - Relatório Geral");
                Console.WriteLine("2 - Total de Receitas");
                Console.WriteLine("3 - Total de Despesas");
                Console.WriteLine("4 - Listar Transações por Categoria");
                Console.WriteLine("5 - Saldo Final");
                Console.WriteLine("0 - Voltar");

                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        // Relatório Geral
                        break;

                    case "2":
                        decimal totalr = TotalReceitas();
                        Console.WriteLine($"O total de receitas é: €{totalr}");
                        break;
                    case "3":
                        decimal totald = TotalReceitas();
                        Console.WriteLine($"O total de receitas é: €{totald}");
                        break;
                    case "4":
                        //listar por categoria
                        break;
                    case "5":
                    
                    break;
                    case "0":
                        sair = true;
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }











    }
}

