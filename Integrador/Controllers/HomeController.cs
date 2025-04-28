using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Integrador.Models;

namespace Integrador.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Tienda()
    {
        //ViewBag.AdminUser = Usuario.MostrarAdmin();
        ViewBag.listaProductos = BD.MostrarProductos();
        return View();
    }

    public IActionResult Mapa()
    {
        return View();
    }

    public IActionResult Chat()
    {
        return View();
    }
    
}
