using Microsoft.AspNetCore.Mvc;
using POOWeb.Classes;
using POOWeb.Models;
using System;

namespace POOWeb.Controllers
{
    [Route("api/transacoes")]
    [ApiController]
    public class TransacaoController : Controller
    {
        //GET: Listar Transações
        [HttpGet("listar")]
        public IActionResult Lista()
        {
            
            try
            {
                string user = HttpContext.Session.GetString("UserNome");
                var transacoes = Transacao.ObterTransacoesUtilizador(user);

                return Ok(transacoes);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { erro = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        //POST: Criar Transacao
        [HttpPost("criartransacao")]
        public IActionResult CriarTransacao([FromBody] TransacaoDTO dados)
        {
            
            try
            {
                string user = HttpContext.Session.GetString("UserNome");
                Transacao.CriarTransacao(dados.Descricao, dados.Valor, dados.Data, dados.Categoria, dados.Tipo, user);
                return Ok(new { mensagem = "Transação criada com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        //PUT: Editar Transacao
        [HttpPut("editartansacao")]
        public IActionResult Editar(int id, [FromBody] TransacaoDTO dados)
        {
            
            try
            {
                string user = HttpContext.Session.GetString("UserNome");
                bool ok = Transacao.Editar(id, dados.Descricao, dados.Valor, dados.Data, dados.Categoria, dados.Tipo, user);

                if (!ok)
                    return NotFound(new { erro = "Transação não encontrada." });

                return Ok(new { mensagem = "Transação atualizada com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        //DELETE: Eliminar Transacao
        [HttpDelete("eliminar/{id}")]
        public IActionResult Apagar(int id)
        {
            
            try
            {
                string user = HttpContext.Session.GetString("UserNome");
                bool apagou = Transacao.Apagar(id, user);

                if (!apagou)
                    return NotFound(new { erro = "Transação não encontrada." });

                return Ok(new { mensagem = "Transação apagada com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }
    }
}
