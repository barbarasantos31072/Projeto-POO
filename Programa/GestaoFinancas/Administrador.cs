namespace ProjetoFinal.Classes
{
    public class Administrador : Utilizador
    {
        //Atributos
         public string CodigoAcesso { get; set; }

        //Construção
        public Administrador(string nome, string email, string password, string codigoacesso)
            : base(nome, email, password, "Administrador")
        {
            CodigoAcesso = codigoacesso;
        }

        public void GerirUtilizadores()
        {
            Console.WriteLine($"{Nome} está a gerir os utilizadores...");
        }
    }
}