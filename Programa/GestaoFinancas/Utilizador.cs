using System;
using System.Runtime.InteropServices.Swift;

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
        public Utilizador(int id, string nome, string email, string password, Perfil pperfil)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Password = password;
            perfil = pperfil;
        }
        public void MostrarInfo()
        {
            Console.WriteLine($"Nome: {Nome}, Email: {Email}");
        }

        public static Utilizador CriarContaUtilizador()
        {
            Random rnd = new Random();
            int idGerado = rnd.Next(1, 1000000);
            Console.WriteLine("=== Criar Conta ===");
            Console.WriteLine("Nome:");
            string nome = Console.ReadLine();
            Console.WriteLine("Email:");
            string email = Console.ReadLine();
            Console.WriteLine("Inserir password:");
            string password = Console.ReadLine();


            Console.WriteLine("Conta criada com sucesso!");


            return new Utilizador(idGerado, nome, email, password, Perfil.Utilizador);
        }
    }

}
