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

        // Construtor
            public Utilizador(int id,string nome, string email, string password)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Password = password;
        }
    } 
}