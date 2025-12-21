using Microsoft.AspNetCore.Mvc;
using System.Linq;
using POOWeb.Classes;
using System.Linq.Expressions;

namespace POOWeb.Controllers
{
    [Route("api/relatorios")]
    [ApiController]
    public class RelatorioController : Controller
    {

        // GET: Relatório por categoria
        [HttpGet("categoria")]
        public IActionResult PorCategoria()
        {
            try
            {
                string user = HttpContext.Session.GetString("UserNome");
                var dados = Transacao.ObterTransacoesUtilizador(user)
                .GroupBy(t => t.Categoria)
                .Select(g => new
                {
                    Categoria = g.Key,
                    Total = g.Sum(x => x.Valor)
                })
                .ToList();

                return Ok(dados);
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }

        }

        [HttpGet("despesas")]
public IActionResult TotalDespesas([FromQuery] DateTime inicio, [FromQuery] DateTime fim)
{
    try
    {
        string user = HttpContext.Session.GetString("UserNome");

        var total = Transacao.ObterTransacoesUtilizador(user)
            .Where(t => t.Tipo == Transacao.TipoTransacao.Despesa
                     && t.Data >= inicio
                     && t.Data <= fim)
            .Sum(t => t.Valor);

        return Ok(total);
    }
    catch (Exception ex)
    {
        return BadRequest(new { erro = ex.Message });
    }
}


       [HttpGet("receitas")]
public IActionResult TotalReceitas([FromQuery] DateTime inicio, [FromQuery] DateTime fim)
{
    try
    {
        string user = HttpContext.Session.GetString("UserNome");

        var total = Transacao.ObterTransacoesUtilizador(user)
            .Where(t => t.Tipo == Transacao.TipoTransacao.Receita
                     && t.Data >= inicio
                     && t.Data <= fim)
            .Sum(t => t.Valor);

        return Ok(total);
    }
    catch (Exception ex)
    {
        return BadRequest(new { erro = ex.Message });
    }
}


      [HttpGet("saldo")]
public IActionResult TotalSaldo()
{
    try
    {
        string user = HttpContext.Session.GetString("UserNome");

        var transacoes = Transacao.ObterTransacoesUtilizador(user);

        var totalReceitas = transacoes
            .Where(t => t.Tipo == Transacao.TipoTransacao.Receita)
            .Sum(t => t.Valor);

        var totalDespesas = transacoes
            .Where(t => t.Tipo == Transacao.TipoTransacao.Despesa)
            .Sum(t => t.Valor);

        var saldo = totalReceitas - totalDespesas;

        return Ok(saldo);
    }
    catch (Exception ex)
    {
        return BadRequest(new { erro = ex.Message });
    }
}

