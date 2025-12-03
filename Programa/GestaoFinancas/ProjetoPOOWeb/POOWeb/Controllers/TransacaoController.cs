using Microsoft.AspNetCore.Mvc;
using ProjetoFinal.Classes;
using System.Linq;

namespace ProjetoFinal.Controllers
{
    public class TransacaoController : Controller
    {
        public IActionResult AdicionarDespesa()
        {
            ViewBag.Categorias = Categoria.ListaCategorias;
            return View();
        }

        [HttpPost]
        public IActionResult AdicionarDespesa(string descricao, decimal valor, DateTime data, string categoriaNome)
        {
            try
            {
                // validações, criação e armazenamento da despesa (como expliquei antes)
            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message;
                ViewBag.Categorias = Categoria.ListaCategorias;
                return View();
            }
        }
        public IActionResult AdicionarReceita()
        {
            ViewBag.Categorias = Categoria.ListaCategorias;
            return View();
        }

        [HttpPost]
        public IActionResult AdicionarReceita(string descricao, decimal valor, DateTime data, string categoriaNome)
        {
            try
            {
                // validações, criação e armazenamento da receita
            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message;
                ViewBag.Categorias = Categoria.ListaCategorias;
                return View();
            }
        }
    }
}
