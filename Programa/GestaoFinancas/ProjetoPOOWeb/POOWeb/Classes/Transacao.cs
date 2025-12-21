using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.IO;
using System.Text.Json;

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
        public TipoTransacao Tipo { get; set; }

        public enum TipoTransacao
        {
            Receita,
            Despesa
        }

        public static Dictionary<string, List<Transacao>> Transacoes = new Dictionary<string, List<Transacao>>();

        private static readonly string ficheiro = "Data/transacoes.json";
        public Transacao() { }

        public Transacao(int id, string descricao, decimal valor, DateTime data, Categoria categoria, TipoTransacao tipo)
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

        // Persistência de dados
        private static void GuardarDados()
        {
            string pasta = Path.GetDirectoryName(ficheiro);
            if (!Directory.Exists(pasta))
                Directory.CreateDirectory(pasta);

            string json = JsonSerializer.Serialize(Transacoes, new JsonSerializerOptions
            {
                WriteIndented = true,
                ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles
            });

            File.WriteAllText(ficheiro, json);
        }

        public static void CarregarDados()
        {
            if (!File.Exists(ficheiro))
                return;

            string json = File.ReadAllText(ficheiro);

            try
            {
                Transacoes = JsonSerializer.Deserialize<Dictionary<string, List<Transacao>>>(json)
                    ?? new Dictionary<string, List<Transacao>>();
            }
            catch
            {
                Transacoes = new Dictionary<string, List<Transacao>>();
            }
        }

        //  CRUD
        public static Transacao CriarTransacao(string descricao, decimal valor, DateTime data, string nomeCategoria, string tipo, string user)
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
            Categoria categoriaExistente = Categoria.ObterPorNome(nomeCategoria);

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
                (TipoTransacao)Enum.Parse(typeof(TipoTransacao), tipo)
            );

            if (!Transacoes.TryGetValue(user, out var transacoes))
            {
                transacoes = new List<Transacao>();
                Transacoes[user] = transacoes;
            }

            transacoes.Add(nova);
            GuardarDados();
            return nova;
        }

        // Apagar transacao
        public static bool Apagar(int id, string user)
        {
            List<Transacao> transacoes = ObterTransacoesUtilizador(user);
            Transacao trans = ObterPorId(id, transacoes);

            if (trans == null)
                return false;

            transacoes.Remove(trans);
            GuardarDados();
            return true;
        }

        public static bool Editar(
            int id,
            string novaDescricao,
            decimal novoValor,
            DateTime novaData,
            string nomeCategoria,
            string tipo,
            string user)
        {
            List<Transacao> transacoes = ObterTransacoesUtilizador(user);
            Transacao trans = ObterPorId(id, transacoes);

            if (trans == null)
                return false;

            // Validar
            if (string.IsNullOrWhiteSpace(novaDescricao) ||
                string.IsNullOrWhiteSpace(nomeCategoria) ||
                novoValor <= 0)
                throw new Exception("Dados inválidos.");

            // Procurar categoria
            Categoria cat = Categoria.ListaCategorias
                .FirstOrDefault(c => c.Nome.Equals(nomeCategoria, StringComparison.OrdinalIgnoreCase));

            if (cat == null)
                throw new Exception("Categoria não existe.");

            // Atualizar campos
            trans.Descricao = novaDescricao;
            trans.Valor = novoValor;
            trans.Data = novaData;
            trans.Categoria = cat;
            trans.Tipo = (TipoTransacao)Enum.Parse(typeof(TipoTransacao), tipo, true);

            GuardarDados();
            return true;
        }
        //Obter por ID
        public static Transacao ObterPorId(int id, List<Transacao> transacoes)
        {
            return transacoes.FirstOrDefault(t => t.Id == id);
        }
        // Total por Tipo
        public static decimal TotalPorTipo(TipoTransacao tipo, DateTime? inicio, DateTime? fim, string user)
        {
            List<Transacao> transacoes = ObterTransacoesUtilizador(user);
            return transacoes
                .Where(t => t.Tipo == tipo &&
                    (!inicio.HasValue || t.Data >= inicio.Value) &&
                    (!fim.HasValue || t.Data <= fim.Value))
                .Sum(t => t.Valor);
        }
        public static List<Transacao> ObterTransacoesUtilizador(string user)
        {
            if (Transacoes.Count == 0)
                CarregarDados();

            if (!Transacoes.TryGetValue(user, out var transacoes))
            {
                transacoes = new List<Transacao>();
                Transacoes[user] = transacoes;
            }

            return transacoes;
        }
    }

}
