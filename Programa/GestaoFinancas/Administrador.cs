using System;

namespace ProjetoFinal.Classes
{
    public class Administrador : Utilizador
    {
        public string CodigoAcesso { get; set; }

        public Administrador(int id, string nome, string email, string password, string perfil, string codigoacesso)
            : base(id, nome, email, password, Perfil.Adminstrador)
        {
            CodigoAcesso = codigoacesso;
        }


        public void GerirUtilizadores()
        {
            Console.WriteLine($"{Nome} está a gerir os utilizadores...");
        }
    }

    //Criar Conta Utilizador

    public static Administrador CriarConta()
    {

    }

}
