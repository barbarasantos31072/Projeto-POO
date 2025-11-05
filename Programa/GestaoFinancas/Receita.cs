using System;

namespace ProjetoFinal.Classes
{
    public class Receita
    {
        // Atributos
        public int Id { get; set; }
        public string Descricao { get; set; }
        public float Valor { get; set; }
        public DateTime Data { get; set; }
        public string Categoria { get; set; }

        // Construtor
        public Receita(int id, string descricao, float valor, DateTime data, string categoria)
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
            // retorna true se o valor for positivo
            return Valor > 0;
        }
    }
}
