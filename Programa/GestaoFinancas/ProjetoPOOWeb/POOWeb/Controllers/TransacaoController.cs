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
        [HttpGet("listartransacoes")]
        public IActionResult Lista()
        {
            try
            {
                var transacoes = Transacao.ObterTransacoesUtilizador("user");

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
                Transacao.CriarTransacao(dados.Descricao, dados.Valor, dados.Data, dados.Categoria, dados.Tipo, "user");
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
                bool ok = Transacao.Editar(id, dados.Descricao, dados.Valor, dados.Data, dados.Categoria, dados.Tipo, "user");

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
        [HttpDelete("eliminartransacao")]
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagou = Transacao.Apagar(id, "user");

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
