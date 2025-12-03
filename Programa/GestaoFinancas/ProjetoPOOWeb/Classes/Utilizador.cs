using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.Classes
{
    public class Utilizador
    {
//Propriedades

        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password é obrigatória")]
        [MinLength(4, ErrorMessage = "Password deve ter pelo menos 4 caracteres")]
        public string Password { get; set; }

        public Perfil PerfilUsuario { get; set; }

        public enum Perfil
        {
            Utilizador,
            Administrador
        }

//Construtor

        public Utilizador() { }

        public Utilizador(int id, string nome, string email, string password, Perfil perfil)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Password = password;
            PerfilUsuario = perfil;
        }



//Método gerar ID

        public static int GerarId()
        {
            Random rnd = new Random();
            return rnd.Next(1, 1000000);
        }
    }
}
