using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Integrador.Models;

namespace Integrador.Controllers;

public class Account : Controller
{
    private readonly ILogger<Account> _logger;

    public Account(ILogger<Account> logger)
    {
        _logger = logger;
    }

    public IActionResult Login()
    {
        return View();
    }
    public IActionResult Perfil()
    {
        return View();
    }

    public IActionResult ValidarUser(string username, string password)
        {
            var usuario = BD.Mostrar(username, password);

            if (usuario == null)
            {
                ViewBag.ErrorMessage = "Usuario o contraseña incorrectos";
                return View("Login");
            }
            else
            {
                ViewBag.MostrarInfo = usuario.username;
                return View("Perfil");
            }
        }
        public IActionResult ValidarOlvide(string username, string mail, string pregunta)
        {
            var usuario = BD.MostrarOlvide(username, mail, pregunta);

            if (usuario == null)
            {
                ViewBag.ErrorMessage = "Dato/s incorrectos";
                return View("Olvide");
            }
            else
            {
                ViewBag.User = usuario.username;
                return View("CambiarContraseña");
            }
        }

        public IActionResult Registrar()
        {
            return View("Registro");
        }
        
        public IActionResult Olvide()
        {
            return View("Olvide");
        }

        [HttpPost]
        public IActionResult GuardarUser(string username, string password, string mail, string pregunta)
        {
            BD.AgregarUsuario(username, password, mail, pregunta);
            return View("Login");
        }

        [HttpPost]
        public IActionResult CrearNuevaContraseña(string username, string password)
        {
            BD.CambiarPassword(username, password);
            return View("Login");
        }
    
}
