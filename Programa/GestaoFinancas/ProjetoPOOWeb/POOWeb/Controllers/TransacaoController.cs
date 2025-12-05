using Microsoft.AspNetCore.Mvc;
using POOWeb.Classes;
using System;

namespace POOWeb.Controllers
{
    public class TransacaoController : Controller
    {
        //GET: Listar Transações
        [HttpGet]
        public IActionResult Lista() => View(Transacao.ListaTransacoes);

        //POST: Criar Transacao
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

        //PUT: Editar Transacao

        [HttpPut]
        public IActionResult Editar(int id, string descricao, decimal valor, DateTime data, string categoria, string tipo)
        {
            try
            {
                bool ok = Transacao.Editar(id, descricao, valor, data, categoria, tipo);

                if (ok)
                    return RedirectToAction("Lista");

                ViewBag.Erro = "Transação não encontrada.";
            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message;
            }

            return View(Transacao.ObterPorId(id));
        }

        //DELETE: Eliminar Transacao
        [HttpDelete]
        public IActionResult Apagar(int id)
        {
            bool apagou = Transacao.Apagar(id);

            if (!apagou)
                ViewBag.Erro = "Transação não encontrada.";
            else
                ViewBag.Sucesso = "Transação apagada com sucesso!";

            return RedirectToAction("Lista");
        }
    }
}
