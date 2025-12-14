using Microsoft.AspNetCore.Mvc;
using POOWeb.Classes;
using System;
using System.Linq;

namespace POOWeb.Models
{
    public class ContaDTO
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string TipoConta { get; set; }
        public string CodigoAcesso { get; set; }
    }
}