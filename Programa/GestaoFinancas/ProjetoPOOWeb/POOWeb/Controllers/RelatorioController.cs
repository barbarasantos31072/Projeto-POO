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
                var dados = Transacao.TotalPorTipo(Transacao.TipoTransacao.Despesa, inicio, fim, user);
                return Ok(dados);
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
                var dados = Transacao.TotalPorTipo(Transacao.TipoTransacao.Receita, inicio, fim, user);
                return Ok(dados);
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
                var totalDespesas = Transacao.TotalPorTipo(Transacao.TipoTransacao.Despesa, null, null, user);
                var totalReceitas = Transacao.TotalPorTipo(Transacao.TipoTransacao.Receita, null, null, user);
                var saldoTotal = totalReceitas - totalDespesas;
                return Ok(saldoTotal);
            }

            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }
    }
}
