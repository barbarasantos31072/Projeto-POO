using System;

namespace ProjetoFinal.Classes
{
    public class Administrador : Utilizador
    {
        public string CodigoAcesso { get; set; }

        public Administrador(int id, string nome, string email, string password, Perfil perfil, string codigoacesso)
            : base(id, nome, email, password, Perfil.Administrador)
        {
            CodigoAcesso = codigoacesso;
        }



        //Criar Conta Utilizador

        public static Administrador CriarContaAdmin()
        {
            Random rnd = new Random();
            int idGerado = rnd.Next(1, 1000000);

            Console.WriteLine("=== Criar Conta ===");

            // Primeiro pedir o código de acesso
            Console.WriteLine("Código de acesso do administrador:");
            string codigoAcesso = Console.ReadLine();

            Console.WriteLine("Nome:");
            string nome = Console.ReadLine();

            Console.WriteLine("Email:");
            string email = Console.ReadLine();

            Console.WriteLine("Inserir password:");
            string password = Console.ReadLine();

            Console.WriteLine("Administrador criado com sucesso!");

            return new Administrador(idGerado, nome, email, password, Perfil.Administrador, codigoAcesso);
        }

    }
}
