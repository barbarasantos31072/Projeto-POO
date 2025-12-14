using Microsoft.AspNetCore.Mvc;
using POOWeb.Classes;
using System;

namespace POOWeb.Controllers
{
    [Route("api/categoria")]
    [ApiController]
    public class CategoriaController : Controller
    {

        // POST: Criar Categoria
        [HttpPost("criar")]
        public IActionResult CriarCategoria([FromBody] string nome)
        {
            try
            {
                Categoria nova = Categoria.CriarCategoria(nome);
                return Ok(new { mensagem = "Categoria criada com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        // DELETE: Eliminar categoria
        [HttpDelete("eliminar")]
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
