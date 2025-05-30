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
    if (HttpContext.Session.GetString("username") != null)
    {
        return RedirectToAction("Perfil");
    }

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
        HttpContext.Session.SetString("username", usuario.username);
        HttpContext.Session.SetInt32("idUsuario", usuario.id_usuario);
        HttpContext.Session.SetInt32("puntos", usuario.puntos);
        HttpContext.Session.SetInt32("admin", usuario.MostrarAdmin() ? 1 : 0);

        return RedirectToAction("Perfil");
    }
}
public IActionResult Logout()
{
    HttpContext.Session.Clear();
    return RedirectToAction("Login");
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
        return View("Perfil");
    }

    [HttpPost]
    public IActionResult CrearNuevaContraseña(string username, string password)
    {
        BD.CambiarPassword(username, password);
        return View("Login");
    }    
}
