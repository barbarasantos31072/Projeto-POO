using Microsoft.AspNetCore.Mvc;
using POOWeb.Classes;
using System;
using System.Linq;

namespace POOWeb.Models
{
    public class TransacaoDTO
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public string Categoria { get; set; }
        public string Tipo { get; set; }
    }
}
