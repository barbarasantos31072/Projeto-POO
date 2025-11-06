namespace ProjetoFinal.Classes
{
    public class Administrador : Utilizador
    {
        public string CodigoAcesso { get; set; }

        // O construtor chama o construtor da classe base (Utilizador)
        public Administrador(string nome, string email, string password, string codigoAcesso)
            : base(nome, email, password, "Administrador")
        {
            CodigoAcesso = codigoAcesso;
        }

        public void GerirUtilizadores()
        {
            Console.WriteLine($"{Nome} está a gerir os utilizadores...");
        }
    }
}