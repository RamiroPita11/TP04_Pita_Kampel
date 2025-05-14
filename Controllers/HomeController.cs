using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP04_Pita_Kampel.Models;

namespace TP04_Pita_Kampel.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private static Juego juego = new Juego();

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
       
        string palabra = juego.elegirPalabra();
        juego.inicializarLetrasPalabra();
        
        

        ViewBag.LetrasAdivinadas = juego.letrasDeLaPalabra;
        ViewBag.LetrasUsadas = juego.letrasArriesgadas;
        ViewBag.Intentos = juego.intentosRealizados;

        return View();
    }

    public IActionResult ArriesgarLetra(char letra) 
    {
        if (juego != null && letra != null)
        {
            juego.arriesgarLetra(letra);
        }

        return RedirectToAction("Index");
    }

    public IActionResult ArriesgarPalabra(string palabra)
    {
         if (juego!= null && palabra !=null)
         {
            juego.arriesgarPalabra(palabra);
         }
          return RedirectToAction("Index");
    } 
}
