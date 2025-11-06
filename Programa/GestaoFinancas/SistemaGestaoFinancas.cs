using System;
using System.Collections.Generic;

namespace ProjetoFinal.Classes
{
    public class SistemaGestaoFinancas
    {
        private List<Utilizador> utilizadores = new List<Utilizador>();
        private GestorTransacoes gestorTransacoes = new GestorTransacoes();
        private Utilizador? utilizadorAtual;

        public void Iniciar()
        {
            bool sair = false;

            while (!sair)
            {
                if (utilizadorAtual == null)
                {
                    Console.WriteLine("\n=== SISTEMA DE GESTÃO DE FINANÇAS ===");
                    Console.WriteLine("1 - Criar Utilizador");
                    Console.WriteLine("2 - Login");
                    Console.WriteLine("0 - Sair");
                    Console.Write("Escolha uma opção: ");
                    string opcao = Console.ReadLine() ?? "";

                    switch (opcao)
                    {
                        case "1":
                            CriarUtilizador();
                            break;
                        case "2":
                            FazerLogin();
                            break;
                        case "0":
                            sair = true;
                            break;
                        default:
                            Console.WriteLine("❌ Opção inválida!");
                            break;
                    }
                }
                else
                {
                    MostrarMenuPrincipal();
                }
            }
        }

        private void CriarUtilizador()
        {
            Console.WriteLine("\n=== CRIAR UTILIZADOR ===");
            Console.Write("Nome: ");
            string nome = Console.ReadLine() ?? "";
            Console.Write("Email: ");
            string email = Console.ReadLine() ?? "";
            Console.Write("Password: ");
            string password = Console.ReadLine() ?? "";

            Utilizador novo = new Utilizador(utilizadores.Count + 1, nome, email, password, "normal");
            utilizadores.Add(novo);
            Console.WriteLine("✅ Utilizador criado com sucesso!");
        }

        private void FazerLogin()
        {
            Console.WriteLine("\n=== LOGIN ===");
            Console.Write("Email: ");
            string email = Console.ReadLine() ?? "";
            Console.Write("Password: ");
            string password = Console.ReadLine() ?? "";

            Utilizador? encontrado = utilizadores.Find(u => u.Email == email && u.Password == password);

            if (encontrado != null)
            {
                utilizadorAtual = encontrado;
                Console.WriteLine($"👋 Bem-vindo, {utilizadorAtual.Nome}!");
            }
            else
            {
                Console.WriteLine("❌ Credenciais inválidas!");
            }
        }

        private void MostrarMenuPrincipal()
        {
            bool sair = false;

            while (!sair)
            {
                Console.WriteLine("\n=== MENU PRINCIPAL ===");
                Console.WriteLine("1 - Adicionar Transação");
                Console.WriteLine("2 - Listar Transações");
                Console.WriteLine("3 - Ver Saldo");
                Console.WriteLine("4 - Logout");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine() ?? "";

                switch (opcao)
                {
                    case "1":
                        gestorTransacoes.AdicionarTransacao();
                        break;
                    case "2":
                        Console.WriteLine("📋 (aqui vai listar as transações)");
                        break;
                    case "3":
                        Console.WriteLine("💰 (aqui vai mostrar o saldo)");
                        break;
                    case "4":
                        utilizadorAtual = null;
                        sair = true;
                        Console.WriteLine("👋 Logout efetuado com sucesso!");
                        break;
                    default:
                        Console.WriteLine(" Opção inválida!");
                        break;
                }
            }
        }
    }
}
