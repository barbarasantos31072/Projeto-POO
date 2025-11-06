using System;

namespace ProjetoFinal.Classes
{
    public class Receita
    {
        // Atributos
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public string Categoria { get; set; }

        // Construtor
        public Receita(int id, string descricao, decimal valor, DateTime data, string categoria)
{
    Id = id;
    Descricao = descricao;
    Valor = valor;
    Data = data;
    Categoria = categoria;
}

        // Métodos
        public bool ValidarValor()
        {
            return Valor > 0;
        }
    }
}
