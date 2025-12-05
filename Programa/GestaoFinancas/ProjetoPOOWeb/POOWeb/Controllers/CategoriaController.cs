using Microsoft.AspNetCore.Mvc;
using POOWeb.Classes;
using System;

namespace POOWeb.Controllers
{
    public class CategoriaController : Controller
    {

        // POST: Criar Categoria
        [HttpPost]
        public IActionResult CriarCategoria(string nome)
        {
            try
            {
                Categoria nova = Categoria.CriarCategoria(nome);
                ViewBag.Sucesso = "Categoria criada com sucesso!";
            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message;
            }

            return View();
        }
        // DELETE: Eliminar categoria
        [HttpDelete]
        public IActionResult Eliminar(string nome)
        {
            bool apagou = Categoria.EliminarCategoria(nome);

            if (!apagou)
                ViewBag.Erro = "Categoria não encontrada.";
            else
                ViewBag.Sucesso = "Categoria apagada com sucesso!";

            return RedirectToAction("Lista");
        }

        // GET: listar categorias

        [HttpGet]
        public IActionResult Lista()
        {
            return View(Categoria.ListaCategorias);
        }
    }
}
