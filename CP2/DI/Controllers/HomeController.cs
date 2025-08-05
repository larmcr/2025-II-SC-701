using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DI.Models;
using DI.Interfaces;

namespace DI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IAleatorio _aleatorio;

    public HomeController(ILogger<HomeController> logger, IAleatorio aleatorio)
    {
        _logger = logger;
        _aleatorio = aleatorio;
    }

    public IActionResult Index(IFechaHora actual)
    {
        ViewBag.FechaHoraActual = actual.Actual;
        ViewBag.AleatorioEntero = _aleatorio.Entero;
        ViewBag.AleatorioFlotante = _aleatorio.Flotante;
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
