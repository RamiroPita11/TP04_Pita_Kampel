using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP04_Pita_Kampel.Models;

namespace TP04_Pita_Kampel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

       
        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(Juego.palabra))
            {
                Juego.inicializarJuego();
            }

            ViewBag.palabraParcial = Juego.palabraParcial;
            ViewBag.LetrasUsadas = Juego.letrasArriesgadas;
            ViewBag.Intentos = Juego.intentosRealizados;
            ViewBag.MaxIntentos = Juego.maxIntentos;

            if (Juego.intentosRealizados == Juego.maxIntentos)
            { 
                ViewBag.Perdio = "Perdiste la partida, se acabaron los intentos.";
                return View("perdioJuego");
            }

            return View();
        }
       

        
        public IActionResult ArriesgarLetra(char letra)
        {
            if (letra != default)
            {
                bool adivinada = Juego.arriesgarLetra(letra);
                if (!adivinada && Juego.intentosRealizados == Juego.maxIntentos)
                {
                    ViewBag.Perdio = "Perdiste la partida, se acabaron los intentos.";
                    return View("perdioJuego");
                }
               
            }

         
            if (!Juego.palabraParcial.Contains('_'))
            {
             ViewBag.Gano = "¡Ganaste la partida!";   
                return View("ganoJuego");
            }

            return RedirectToAction("Index");
        }

    
        public IActionResult ArriesgarPalabra(string palabra)
        {
            bool gano = false;
            if (!string.IsNullOrEmpty(palabra))
            {
                gano = Juego.arriesgarPalabra(palabra);
            }

            if (gano)
            {
                ViewBag.Gano = "¡Ganaste la partida!";
                return View("ganoJuego");
            }
            else
            {      
                 ViewBag.Perdio = "Perdiste la partida, la palabra era: " + Juego.palabra;
               return View("perdioJuego");
            }
        }
    }
}
