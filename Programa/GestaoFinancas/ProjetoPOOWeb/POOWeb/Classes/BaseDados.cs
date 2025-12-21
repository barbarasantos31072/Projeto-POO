using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace POOWeb.Classes
{
    public static class BaseDados
    {
        public static List<Utilizador> Utilizadores { get; set; } = new List<Utilizador>();
        public static Utilizador UtilizadorAtual { get; set; }

        private static readonly string ficheiro = "Data/contas.json";

        // ================== Persistência ==================
        public static void GuardarContas()
        {
            string pasta = Path.GetDirectoryName(ficheiro);
            if (!Directory.Exists(pasta))
                Directory.CreateDirectory(pasta);

            string json = JsonSerializer.Serialize(Utilizadores, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(ficheiro, json);
        }

        public static void CarregarContas()
        {
            if (!File.Exists(ficheiro))
                return;

            string json = File.ReadAllText(ficheiro);
            try
            {
                Utilizadores = JsonSerializer.Deserialize<List<Utilizador>>(json) ?? new List<Utilizador>();
            }
            catch
            {
                Utilizadores = new List<Utilizador>();
            }
        }
    }
}
