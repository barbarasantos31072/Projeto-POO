 using System;

namespace ProjetoFinal.Classes
{
    public class Utilizador
    {
        //Atributos
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Perfil { get; set; }       
        // Construtor
            public Utilizador(string nome, string email, string password, string perfil)
        {
            Nome = nome;
            Email = email;
            Password = password;
            Perfil = perfil;
        }
    } 
}