using Microsoft.AspNetCore.Mvc;
using ProjetoFinal.Classes;
using System;

namespace ProjetoFinal.Controllers
{
    public class TransacaoController : Controller
    {
        public IActionResult CriarDespesa()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CriarDespesa(string descricao, decimal valor, DateTime data, string categoria)
        {
            try
            {
                Transacao.CriarTransacao(descricao, valor, data, categoria, "Despesa");
                ViewBag.Sucesso = "Despesa criada com sucesso!";
            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message;
            }

            return View();
        }


        // ---------- CRIAR RECEITA ---------- //

        // GET: /Transacao/CriarReceita
        public IActionResult CriarReceita()
        {
            return View();
        }

        // POST: /Transacao/CriarReceita
        [HttpPost]
        public IActionResult CriarReceita(string descricao, decimal valor, DateTime data, string categoria)
        {
            try
            {
                Transacao.CriarTransacao(descricao, valor, data, categoria, "Receita");
                ViewBag.Sucesso = "Receita criada com sucesso!";
            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message;
            }

            return View();
        }


        // ---------- LISTAR TODAS AS TRANSAÇÕES ---------- //

        public IActionResult Lista()
        {
            return View(Transacao.ListaTransacoes);
        }
    }
}
