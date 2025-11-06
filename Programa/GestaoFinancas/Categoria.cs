using System;
using System.Data.Common;
public class Categoria
{
    public int Id { get; set; }
    public string NomeCategoria { get; set; }
    public string Tipo { get; set; }

    // Construtor
        public Categoria(int id, string nomecat, string tipo)
        {
           Id = id;
           NomeCategoria = nomecat;
           Tipo = tipo;
        }

        // Método criarcategoria
        public static Categoria CriarCategoria(int id, string nomecat, string tipo)
        {
            return new Categoria(id, nomecat, tipo);
        }
 
}