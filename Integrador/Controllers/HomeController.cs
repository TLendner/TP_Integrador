using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Integrador.Models;
using Microsoft.AspNetCore.Mvc.TagHelpers;

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

public IActionResult Tienda(string orden = "", string? mensaje = null)
{
    ViewBag.Admin = HttpContext.Session.GetInt32("admin");
    List<Producto> productos = BD.MostrarProductos();

    if (orden == "menor")
    {
        productos = productos.OrderBy(p => p.puntos).ToList();
    }
    else if (orden == "mayor")
    {
        productos = productos.OrderByDescending(p => p.puntos).ToList();
    }

    ViewBag.listaProductos = productos;
    ViewBag.OrdenSeleccionado = orden;
    ViewBag.Mensaje = mensaje;
    return View();
}


    public IActionResult Producto(int id)
    {
        if(HttpContext.Session.GetString("username") == null)
        {
            return RedirectToAction("Login", "Account");
        }
        Producto prod = BD.MostrarUnProducto(id);
        ViewBag.Producto = prod;

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
    
    public IActionResult Comprar(int id, int puntos)
    {
        if(HttpContext.Session.GetInt32("puntos") < puntos)
        {
            return RedirectToAction("Tienda", new { mensaje = "Puntos insuficientes" });
        }
        BD.RestarStock(id);
        BD.RestarPuntos(HttpContext.Session.GetInt32("idUsuario").Value, puntos);
        return RedirectToAction("Tienda");
    }
}
