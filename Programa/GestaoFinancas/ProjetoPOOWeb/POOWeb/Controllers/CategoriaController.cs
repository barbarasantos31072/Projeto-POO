using Microsoft.AspNetCore.Mvc;
using POOWeb.Classes;
using POOWeb.Models;
using System;

namespace POOWeb.Controllers
{
    [Route("api/categoria")]
    [ApiController]
    public class CategoriaController : Controller
    {

        // POST: Criar Categoria
        [HttpPost("criar")]
        public IActionResult CriarCategoria([FromBody] CategoriaDTO dados)
        {
            try
            {
                Categoria nova = Categoria.CriarCategoria(dados.Nome);
                return Ok(new { mensagem = "Categoria criada com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        // DELETE: Eliminar categoria
        [HttpDelete("eliminar/{nome}")]
        public IActionResult Eliminar(string nome)
        {
            bool apagou = Categoria.EliminarCategoria(nome);

            if (!apagou)
                return NotFound(new { mensagem = "Categoria não encontrada!" });
            else
                return Ok(new { mensagem = "Categoria apagada com sucesso!" });
        }

        // GET: listar categorias

        [HttpGet("listar")]
        public IActionResult Lista()
        {
            return Ok(Categoria.ListaCategorias);
        }
    }
}
