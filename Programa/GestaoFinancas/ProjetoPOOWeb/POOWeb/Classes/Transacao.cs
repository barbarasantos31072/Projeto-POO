using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace POOWeb.Classes
{
    public class Transacao
    {
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
        public Categoria Categoria { get; set; }

        [Required(ErrorMessage = "Tipo é obrigatório")]
        public TipoCategoria Tipo { get; set; }

        public enum TipoCategoria
        {
            Receita,
            Despesa
        }
        // Lista global de transações
        public static List<Transacao> ListaTransacoes = new List<Transacao>();

        public Transacao() { }

        public Transacao(int id, string descricao, decimal valor, DateTime data, Categoria categoria, TipoCategoria tipo)
        {
            Id = id;
            Descricao = descricao;
            Valor = valor;
            Data = data;
            this.Categoria = categoria;
            Tipo = tipo;
        }

        // Random para gerar ID
        private static Random rnd = new Random();
        private static int GerarId()
        {
            return rnd.Next(1, 9999999);
        }

        //  MÉTODO PRINCIPAL — CRIA TRANSACAO E PROCURA CATEGORIA
        public static Transacao CriarTransacao(string descricao, decimal valor, DateTime data, string nomeCategoria, string tipo)
        {
            if (string.IsNullOrWhiteSpace(descricao))
                throw new Exception("A descrição é obrigatória.");

            if (valor <= 0)
                throw new Exception("O valor deve ser maior que 0.");

            if (string.IsNullOrWhiteSpace(nomeCategoria))
                throw new Exception("A categoria é obrigatória.");

            if (tipo != "Despesa" && tipo != "Receita")
                throw new Exception("O tipo deve ser 'Despesa' ou 'Receita'.");

            //  Procurar categoria existente na lista da classe Categoria
            Categoria categoriaExistente = Categoria.ListaCategorias
                .FirstOrDefault(c => c.Nome.Equals(nomeCategoria, StringComparison.OrdinalIgnoreCase), null);

            // Se não existir → criar automaticamente
            if (categoriaExistente == null)
            {
                throw new Exception("Esta categoria não existe");
            }

            // Criar transação
            int novoId = GerarId();

            Transacao nova = new Transacao(
                novoId,
                descricao,
                valor,
                data,
                categoriaExistente,
                (TipoCategoria)Enum.Parse(typeof(TipoCategoria), tipo)
            );

            ListaTransacoes.Add(nova);

            return nova;
        }
    }
}
