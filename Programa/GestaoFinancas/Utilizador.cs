using System;

namespace ProjetoFinal.Classes
{
    public class Utilizador
    {
        //Atributos
        public int Id;
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Perfil perfil { get; set; }

        public enum Perfil
        {
            Utilizador,
            Administrador
        }

        // Construtor
        public Utilizador(int id, string nome, string email, string password, Perfil perfil)
        {
            Id = id++;
            Nome = nome;
            Email = email;
            Password = password;
            Perfil = perfil;
        }
        public void MostrarInfo()
        {
            Console.WriteLine($"Nome: {Nome}, Email: {Email}");
        }

        public static Utilizador CriarConta()
        {
            int id;
            id = 1;
            Console.WriteLine("=== Criar Conta ===");
            Console.WriteLine("Administrador ou Utilizador?");
            string perfil = Console.ReadLine();
            Console.WriteLine("Nome:");
            string nome = Console.ReadLine();
            Console.WriteLine("Email:");
            string email = Console.ReadLine();
            Console.WriteLine("Inserir password:");
            string password = Console.ReadLine();
            
            int idGerado = id;
            id++;


            Console.WriteLine("Conta criada com sucesso!");


            return new Utilizador(id, nome, email, password);
        }
    }
    
}
