using ProjetoFinal.Classes;

namespace ProjetoFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                {
            bool sair = false;

            while (!sair)
            {
                Console.Clear();
                Console.WriteLine("=== MENU GERAL ===");
                Console.WriteLine("1 - Criar Conta");
                Console.WriteLine("2 - Login");
                Console.WriteLine("3 - Sistema de Gestão Financeira");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        //Criar Conta
                        break;
                    case "2":
                        //Login
                        break;
                    case "3":
                        //Sistema
                        break;
                    case "0":
                        sair = true;
                        Console.WriteLine("Saindo do programa...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida! Tente novamente.");
                        break;
                }

                if (!sair)
                {
                    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                }
            }
        }

                SistemaGestaoFinancas sistema = new SistemaGestaoFinancas();
                sistema.AdicionarTransacao();

            }
        }
    }
}

