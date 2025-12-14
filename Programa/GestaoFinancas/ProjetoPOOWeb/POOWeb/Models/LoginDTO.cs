using Microsoft.AspNetCore.Mvc;
using POOWeb.Classes;
using System;
using System.Linq;

namespace POOWeb.Models
{
    public class LoginDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}