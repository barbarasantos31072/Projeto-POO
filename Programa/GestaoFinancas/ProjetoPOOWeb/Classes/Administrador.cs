using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.Classes
{
    public class Administrador : Utilizador
    {
        [Required(ErrorMessage = "Código de acesso é obrigatório")]
        public string CodigoAcesso { get; set; }

        public Administrador() { }

        public Administrador(int id, string nome, string email, string password, string codigoAcesso)
            : base(id, nome, email, password, Perfil.Administrador)
        {
            CodigoAcesso = codigoAcesso;
        }
    }
}
