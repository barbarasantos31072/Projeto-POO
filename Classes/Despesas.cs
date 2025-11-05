using System;

namespace ProjetoFinal.Classes
{
    public class Despesas
    {
        // Atributos
        public int Id { get; set; }
        public string Descricao { get; set; }
        public float Valor { get; set; }
        public DateTime Data { get; set; }
        public string Categoria { get; set; }

        // Construtor
        public Despesas(int id, string descricao, float valor, DateTime data, string categoria)
        {
            Id = id;
            Descricao = descricao;
            Valor = valor;
            Data = data;
            Categoria = categoria; // teste teste 
        }

        // Método
        public bool ValidarValor()
        {
            return Valor > 0;
        }
    }
}
