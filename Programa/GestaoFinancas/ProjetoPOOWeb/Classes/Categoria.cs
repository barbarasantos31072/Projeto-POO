using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Categoria
{

//Propriedades
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome da categoria é obrigatório.")]
    public string NomeCategoria { get; set; }

    [Required(ErrorMessage = "O tipo da categoria é obrigatório.")]
    public string Tipo { get; set; }   // "Despesa" ou "Receita"


//Lista de Categorias

    public static List<Categoria> ListaCategorias = new List<Categoria>();



//Construtor

    public Categoria(int id, string nomecat, string tipo)
    {
        Id = id;
        NomeCategoria = nomecat;
        Tipo = tipo;
    }


//Método Gerar Id

    private static Random rnd = new Random();

    private static int GerarId()
    {
        return rnd.Next(1, 9999999);
    }


//Criar Categoria
public static Categoria CriarCategoria(string nomecat, string tipo)
    {
        if (string.IsNullOrWhiteSpace(nomecat))
            throw new Exception("O nome da categoria é obrigatório.");

        if (tipo != "Despesa" && tipo != "Receita")
            throw new Exception("O tipo deve ser 'Despesa' ou 'Receita'.");

        // Impedir categorias duplicadas
        if (ListaCategorias.Exists(c =>
            c.NomeCategoria.ToLower() == nomecat.ToLower() && c.Tipo == tipo))
        {
            throw new Exception("Já existe uma categoria igual com este tipo.");
        }

        int novoId = GerarId();

        Categoria nova = new Categoria(novoId, nomecat, tipo);
        ListaCategorias.Add(nova);

        return nova;
    }
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

// Procurar categoria existente
    Categoria categoriaExistente = Categoria.ListaCategorias
        .FirstOrDefault(c =>
            c.NomeCategoria.Equals(categoria, StringComparison.OrdinalIgnoreCase)
            && c.Tipo == tipo);

// Se não existir, criar automaticamente
    if (categoriaExistente == null)
    {
        categoriaExistente = Categoria.CriarCategoria(categoria, tipo);
        Console.WriteLine($"Categoria '{categoria}' criada automaticamente.");
    }

    // Criar a transação
    int novoId = GerarId();

    Transacao nova = new Transacao(novoId, descricao, valor, data, categoriaExistente.NomeCategoria, tipo);

    ListaTransacoes.Add(nova);

    return nova;
}

}
