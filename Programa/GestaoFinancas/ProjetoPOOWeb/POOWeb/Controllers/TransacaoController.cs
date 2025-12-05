using Microsoft.AspNetCore.Mvc;
using POOWeb.Classes;
using System;

namespace POOWeb.Controllers
{
    public class TransacaoController : Controller
    {
        public IActionResult CriarTransacao()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CriarTransacao(string descricao, decimal valor, DateTime data, string categoria, string tipo)
        {
            try
            {
                Transacao.CriarTransacao(descricao, valor, data, categoria, tipo);
                ViewBag.Sucesso = "Transação criada com sucesso!";
            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message;
            }

            return View();
        }

        // ---------- LISTAR TODAS AS TRANSAÇÕES ---------- //

        //        public IActionResult Lista()
        //{
        // return View(Transacao.ListaTransacoes);
        // }
    }
}
