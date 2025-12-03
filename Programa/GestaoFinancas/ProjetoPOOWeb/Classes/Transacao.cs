using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ProjetoFinal.Classes
{
    public class Transacao
    {
//Propriedades
        public int Id { get; set; }

        [Required(ErrorMessage = "Descrição é obrigatória")]
        [StringLength(100, ErrorMessage = "Descrição deve ter no máximo 100 caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Valor é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Valor deve ser maior que 0")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Data é obrigatória")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Categoria é obrigatória")]
        public string Categoria { get; set; }

        [Required(ErrorMessage = "Tipo é obrigatório")]
        public string Tipo { get; set; }

//Lista de Transações
        public static List<Transacao> ListaTransacoes = new List<Transacao>();

//Construtor
        public Transacao() { }

        public Transacao(int id, string descricao, decimal valor, DateTime data, string categoria, string tipo)
        {
            Id = id;
            Descricao = descricao;
            Valor = valor;
            Data = data;
            Categoria = categoria;
            Tipo = tipo;
        }

//Gerar ID
        public static int GerarId()
        {
            return new Random().Next(1, 1000000);
        }

//Criar transação
        public static Transacao CriarTransacao(string descricao, decimal valor, DateTime data, string categoria, string tipo)
        {
            if (string.IsNullOrWhiteSpace(descricao))
                throw new Exception("A descrição é obrigatória.");

            if (valor <= 0)
                throw new Exception("O valor deve ser maior que 0.");

            if (string.IsNullOrWhiteSpace(categoria))
                throw new Exception("A categoria é obrigatória.");

            if (tipo != "Despesa" && tipo != "Receita")
                throw new Exception("O tipo deve ser 'Despesa' ou 'Receita'.");


//Procurar categoria existente
            Categoria categoriaExistente = Categoria.ListaCategorias
                .FirstOrDefault(c =>
                    c.NomeCategoria.Equals(categoria, StringComparison.OrdinalIgnoreCase)
                    && c.Tipo == tipo);

//Se não existir, criar
            if (categoriaExistente == null)
            {
                categoriaExistente = Categoria.CriarCategoria(categoria, tipo);
                Console.WriteLine($"Categoria '{categoria}' criada automaticamente.");
            }

//Criar transação
            int novoId = GerarId();

            Transacao nova = new Transacao(novoId, descricao, valor, data, categoriaExistente.NomeCategoria, tipo);

//Guardar na lista
            ListaTransacoes.Add(nova);

            return nova;
        }
    }
}
