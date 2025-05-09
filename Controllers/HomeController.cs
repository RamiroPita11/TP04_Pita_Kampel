using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP04_Pita_Kampel.Models;

namespace TP04_Pita_Kampel.Controllers;

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
}
