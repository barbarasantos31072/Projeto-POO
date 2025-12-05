using System.Collections.Generic;

namespace POOWeb.Classes
{
    public static class BaseDados
    {
        public static List<Utilizador> Utilizadores { get; set; } = new List<Utilizador>();
        public static Utilizador UtilizadorAtual { get; set; }
    }
}
