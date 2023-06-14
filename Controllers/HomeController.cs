using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SalaDeEscape.Models;
using System.Collections.Generic;
namespace SalaDeEscape.Controllers;

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

    public IActionResult Tutorial()
    {
        return View();
    }
    public IActionResult Creditos()
    {
        return View();
    }
    public IActionResult Comenzar()
    {
        Escape.IniciarJuego();
        int proxHabitacion = Escape.GetEstadoJuego();
        ViewBag.Pistas=Escape.GetPistas(proxHabitacion- 1);
        ViewBag.Acertijo = Escape.GetAcertijos(proxHabitacion-1);
        ViewBag.Titulo = Escape.GetTitulo(proxHabitacion-1);
        string video = Escape.incognitasSalas[Escape.GetEstadoJuego()-1];
        ViewBag.Video = "~/vid/"+video+".mp4";
        return View("Habitacion"+proxHabitacion);
    }
    public IActionResult Continuar() {
        int proxHabitacion = Escape.GetEstadoJuego();
        ViewBag.Pistas=Escape.GetPistas(proxHabitacion- 1);
        ViewBag.Acertijo = Escape.GetAcertijos(proxHabitacion-1);
        ViewBag.Titulo = Escape.GetTitulo(proxHabitacion-1);
        string video = Escape.incognitasSalas[Escape.GetEstadoJuego()-1];
        ViewBag.Video = "~/vid/"+video+".mp4";
        return View("Habitacion"+proxHabitacion);
    }
    public IActionResult Pistas() {
        return View("Pistas");
        List <string[]> ListaPistas = new List <string[]>();
        for (int i = 0;i<Escape.GetEstadoJuego();i++) {
            ListaPistas[i] = Escape.GetPistas(i);
        }
   
        ViewBag.Pistas[0] = "Escape.GetPistas(0)";
        
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    [HttpPost] public IActionResult Habitacion(int sala, string clave) {
        if (string.IsNullOrEmpty(clave)) {
            clave = "";
        }
            int proxHabitacion = Escape.GetEstadoJuego();
            ViewBag.Pistas=Escape.GetPistas(proxHabitacion- 1);
            ViewBag.Acertijo = Escape.GetAcertijos(proxHabitacion-1);
            ViewBag.Titulo = Escape.GetTitulo(proxHabitacion-1);
            string video = Escape.incognitasSalas[Escape.GetEstadoJuego()-1];
            ViewBag.Video = "~/vid/"+video+".mp4";
        
        if (Escape.ResolverSala(sala,clave)) {
           
            if(Escape.GetEstadoJuego() == 6) {
                return View("Ganador");
            }
            proxHabitacion = Escape.GetEstadoJuego();
            ViewBag.Pistas=Escape.GetPistas(proxHabitacion- 1);
            ViewBag.Acertijo = Escape.GetAcertijos(proxHabitacion-1);
            ViewBag.Titulo = Escape.GetTitulo(proxHabitacion-1);
            video = Escape.incognitasSalas[Escape.GetEstadoJuego()-1];
            ViewBag.Video = "~/vid/"+video+".mp4";
            return View("Habitacion"+Escape.GetEstadoJuego());
        } else {
            return View("Habitacion"+Escape.GetEstadoJuego());
        }
    }

    
}
