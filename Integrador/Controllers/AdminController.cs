using Microsoft.AspNetCore.Mvc;
using Integrador.Models;

namespace Integrador.Controllers;

public class AdminController : Controller
{
    public IActionResult Admin()
    {
        ViewBag.listaProductos = BD.MostrarProductos();
        ViewBag.listaCategorias = BD.MostrarCategorias();
        return View();
    }

    [HttpPost]
    public IActionResult AgregarProducto(string descripcion, string nombre, int stock, int puntos, int id_categoria, int calificacion, IFormFile imagen)
    {
        byte[] imagenBytes = null;
        if (imagen != null)
        {
            using (var ms = new MemoryStream())
            {
                imagen.CopyTo(ms);
                imagenBytes = ms.ToArray();
            }
        }

        BD.AgregarProducto(descripcion, nombre, stock, puntos, id_categoria, calificacion, imagenBytes);
        return RedirectToAction("Tienda", "Home");
    }

    [HttpPost]
    public IActionResult EditarProducto(int idProducto, string descripcion, string nombre, int stock, int puntos, int id_categoria, int calificacion, IFormFile imagen)
    {
        byte[] imagenBytes = null;
        if (imagen != null)
        {
            using (var ms = new MemoryStream())
            {
                imagen.CopyTo(ms);
                imagenBytes = ms.ToArray();
            }
        }

        BD.EditarProducto(idProducto, descripcion, nombre, stock, puntos, id_categoria, calificacion, imagenBytes);
        return RedirectToAction("Tienda", "Home");
    }

    [HttpPost]
    public IActionResult EliminarProducto(int idProducto)
    {
        BD.EliminarProducto(idProducto);
        return RedirectToAction("Tienda", "Home");
    }

    [HttpPost]
    public IActionResult AgregarCategoria(string nombre)
    {
        BD.AgregarCategoria(nombre);
        return RedirectToAction("Tienda", "Home");
    }

    [HttpPost]
    public IActionResult EliminarCategoria(int idCategoria)
    {
        BD.EliminarCategoria(idCategoria);
        return RedirectToAction("Tienda", "Home");
    }

}