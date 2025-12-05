using Microsoft.AspNetCore.Mvc;
using POOWeb.Classes;
using System;
using System.Linq;

namespace POOWeb.Controllers
{
    public class ContaController : Controller
    {
        // GET: Criar Conta
        [HttpGet]
        public IActionResult CriarConta()
        {
            return View();
        }

        // POST: Criar Conta
        [HttpPost]
        public IActionResult CriarConta(string nome, string email, string password, string tipoConta, string codigoAcesso)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nome))
                    throw new Exception("Nome obrigatório");
                if (string.IsNullOrWhiteSpace(email))
                    throw new Exception("Email obrigatório");
                if (string.IsNullOrWhiteSpace(password) || password.Length < 4)
                    throw new Exception("Password deve ter pelo menos 4 caracteres");

                Random rnd = new Random();
                int id = rnd.Next(1, 1000000);

                if (tipoConta == "Administrador")
                {
                    if (string.IsNullOrWhiteSpace(codigoAcesso))
                        throw new Exception("Código de acesso obrigatório para administrador");

                    var admin = new Administrador(id, nome, email, password, codigoAcesso);
                    BaseDados.Utilizadores.Add(admin);
                }
                else
                {
                    var user = new Utilizador(id, nome, email, password, Utilizador.Perfil.Utilizador);
                    BaseDados.Utilizadores.Add(user);
                }

                ViewBag.Mensagem = "Conta criada com sucesso!";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message;
                return View();
            }
        }

        // GET: Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email))
                    throw new Exception("Email obrigatório");
                if (string.IsNullOrWhiteSpace(password))
                    throw new Exception("Password obrigatória");

                // Procurar utilizador na lista
                var utilizador = BaseDados.Utilizadores
                    .FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase) && u.Password == password);

                if (utilizador == null)
                    throw new Exception("Credenciais inválidas!");

                // Guardar o utilizador logado na sessão
                HttpContext.Session.SetInt32("UserId", utilizador.Id);
                HttpContext.Session.SetString("UserNome", utilizador.Nome);
                HttpContext.Session.SetString("UserPerfil", utilizador.PerfilUsuario.ToString());

                ViewBag.Mensagem = $"Login efetuado com sucesso! Bem-vindo {utilizador.Nome}";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message;
                return View();
            }
        }
    }
}
