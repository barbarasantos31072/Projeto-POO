using Microsoft.AspNetCore.Mvc;
using POOWeb.Classes;
using POOWeb.Models;
using System;
using System.Linq;

namespace POOWeb.Controllers
{
    [Route("api/conta")]
    [ApiController]
    public class ContaController : Controller
    {

        // POST: Criar Conta
        [HttpPost("criar")]
        public IActionResult CriarConta([FromBody] ContaDTO dados)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dados.Nome))
                    throw new Exception("Nome obrigatório");
                if (string.IsNullOrWhiteSpace(dados.Email))
                    throw new Exception("Email obrigatório");
                if (string.IsNullOrWhiteSpace(dados.Password) || dados.Password.Length < 4)
                    throw new Exception("Password deve ter pelo menos 4 caracteres");

                Random rnd = new Random();
                int id = rnd.Next(1, 1000000);

                if (dados.TipoConta == "Administrador")
                {
                    if (string.IsNullOrWhiteSpace(dados.CodigoAcesso))
                        throw new Exception("Código de acesso obrigatório para administrador");

                    var admin = new Administrador(id, dados.Nome, dados.Email, dados.Password, dados.CodigoAcesso);
                    BaseDados.Utilizadores.Add(admin);
                }
                else
                {
                    var user = new Utilizador(id, dados.Nome, dados.Email, dados.Password, Utilizador.Perfil.Utilizador);
                    BaseDados.Utilizadores.Add(user);
                }

                return Ok(new { mensagem = "Conta criada com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        // POST: Login
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO dados)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dados.Email))
                    throw new Exception("Email obrigatório");
                if (string.IsNullOrWhiteSpace(dados.Password))
                    throw new Exception("Password obrigatória");

                // Procurar utilizador na lista
                var utilizador = BaseDados.Utilizadores
                    .FirstOrDefault(u => u.Email.Equals(dados.Email, StringComparison.OrdinalIgnoreCase) && u.Password == dados.Password);

                if (utilizador == null)
                    throw new Exception("Credenciais inválidas!");

                // Guardar o utilizador logado na sessão
                HttpContext.Session.SetInt32("UserId", utilizador.Id);
                HttpContext.Session.SetString("UserNome", utilizador.Nome);
                HttpContext.Session.SetString("UserPerfil", utilizador.PerfilUsuario.ToString());

                return Ok(new {mensagem = $"Login efetuado com sucesso! Bem-vindo {utilizador.Nome}"});
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }
    }
}
