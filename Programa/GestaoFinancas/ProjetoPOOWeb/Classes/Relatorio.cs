using Microsoft.AspNetCore.Mvc;
using ProjetoFinal.Classes;
using System;
using System.Linq;

namespace ProjetoFinal.Controllers
{
    public class RelatorioController : Controller
    {
        // GET: /Relatorio
        public IActionResult Index()
        {
            // Esta será a página principal do menu de relatórios
            return View();
        }

        // 1 - Total de Receitas
        public IActionResult TotalReceitas()
        {
            decimal total = BaseDados.Receitas.Sum(r => r.Valor);
            ViewBag.Total = total;
            return View();
        }

        // 2 - Total de Despesas
        public IActionResult TotalDespesas()
        {
            decimal total = BaseDados.Despesas.Sum(d => d.Valor);
            ViewBag.Total = total;
            return View();
        }

        // 3 - Listar Transações por Categoria
        public IActionResult TransacoesPorCategoria()
        {
            var agrupadas = BaseDados.Transacoes
                .GroupBy(t => t.Categoria)
                .Select(g => new
                {
                    Categoria = g.Key,
                    Total = g.Sum(t => t.Valor),
                    Transacoes = g.ToList()
                }).ToList();

            return View(agrupadas);
        }

        // 4 - Saldo Final num período
        public IActionResult SaldoFinal()
        {
            return View(); // Página para o utilizador escolher datas
        }

        [HttpPost]
        public IActionResult SaldoFinal(DateTime inicio, DateTime fim)
        {
            decimal receitas = BaseDados.Receitas
                .Where(r => r.Data >= inicio && r.Data <= fim)
                .Sum(r => r.Valor);

            decimal despesas = BaseDados.Despesas
                .Where(d => d.Data >= inicio && d.Data <= fim)
                .Sum(d => d.Valor);

            decimal saldo = receitas - despesas;
            ViewBag.Saldo = saldo;
            ViewBag.Inicio = inicio.ToShortDateString();
            ViewBag.Fim = fim.ToShortDateString();

            return View();
        }
    }
}
