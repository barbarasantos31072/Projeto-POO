using System;

namespace ProjetoFinal.Classes
{
    public class Transacao
    {
        // Atributos
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public string Categoria { get; set; }

        // Construtor
        public Transacao (int id, string descricao, decimal valor, DateTime data, string categoria, string tipo)
        {
            Id = id;
            Descricao = descricao;
            Valor = valor;
            Data = data;
            Categoria = categoria;
            Tipo = tipo;
        }

        // Método Validar
        public bool ValidarValor()
        {
            return Valor > 0;
        }
    }
}
