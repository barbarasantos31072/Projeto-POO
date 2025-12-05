using Microsoft.AspNetCore.Mvc;
using System.Linq;
using POOWeb.Classes;


public class RelatorioController : Controller
{
    // GET: Relatório por categoria
    [HttpGet]
    public IActionResult PorCategoria()
    {
        var dados = Transacao.ListaTransacoes
            .GroupBy(t => t.Categoria)
            .Select(g => new
            {
                Categoria = g.Key,
                Total = g.Sum(x => x.Valor)
            })
            .ToList();

        return View(dados);
    }

    [HttpGet]
    public IActionResult TotalDespesas(DateTime inicio, DateTime fim)
    {
        var dados = Transacao.TotalPorTipo(Transacao.TipoTransacao.Despesa, inicio, fim);
        return View(dados);
    }
    [HttpGet]
    public IActionResult TotalReceitas(DateTime inicio, DateTime fim)
    {
        var dados = Transacao.TotalPorTipo(Transacao.TipoTransacao.Receita, inicio, fim);
        return View(dados);
    }

    [HttpGet]
    public IActionResult TotalSaldo()
    {
        var totalDespesas = Transacao.TotalPorTipo(Transacao.TipoTransacao.Despesa, null, null);
        var totalReceitas = Transacao.TotalPorTipo(Transacao.TipoTransacao.Receita, null, null);
        var saldoTotal = totalReceitas - totalDespesas;
        return View(saldoTotal);
    }

}
