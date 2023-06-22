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
    public  IActionResult Iniciar() {
        ViewBag.Usuarios = Escape.getUsuarios();
        return View("IngresoDatos");
    }
    [HttpPost] public IActionResult Comenzar(string usuario)
    {
        Escape.usuarioActivo = usuario;
        Escape.pistasUsadas = "0";
        Escape.IniciarJuego();
        int proxHabitacion = Escape.GetEstadoJuego();
        ViewBag.Timer = Escape.timer;
        ViewBag.Pistas=Escape.GetPistas(proxHabitacion- 1);
        ViewBag.PistasUsadas = Escape.pistasUsadas;
        ViewBag.Acertijo = Escape.GetAcertijos(proxHabitacion-1);
        ViewBag.Titulo = Escape.GetTitulo(proxHabitacion-1);
        ViewBag.Vidas = 3-Escape.errores;
        string video = Escape.incognitasSalas[Escape.GetEstadoJuego()-1];
        ViewBag.Video = "~/vid/"+video+".mp4";
        return View("Habitacion"+proxHabitacion);
    }
    public IActionResult Continuar() {
        int proxHabitacion = Escape.GetEstadoJuego();
        ViewBag.Timer = Escape.timer;
        ViewBag.PistasUsadas = Escape.pistasUsadas;
        ViewBag.Pistas=Escape.GetPistas(proxHabitacion- 1);
        ViewBag.Acertijo = Escape.GetAcertijos(proxHabitacion-1);
        ViewBag.Titulo = Escape.GetTitulo(proxHabitacion-1);
        ViewBag.Vidas = 3-Escape.errores;
        string video = Escape.incognitasSalas[Escape.GetEstadoJuego()-1];
        ViewBag.Video = "~/vid/"+video+".mp4";
        return View("Habitacion"+proxHabitacion);
    }
    public IActionResult Pistas() {
        ViewBag.Pistas = Escape.GetAllPistas(Escape.GetEstadoJuego());
        ViewBag.PistasUsadas = Escape.pistasUsadas;
        return View("Pistas");
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    [HttpPost] public IActionResult Habitacion(int sala, string clave, string timer, string pistas) {
        if (string.IsNullOrEmpty(clave)) {
            clave = "";
        }
            Escape.pistasUsadas = pistas;
            int proxHabitacion = Escape.GetEstadoJuego();
            ViewBag.Pistas=Escape.GetPistas(proxHabitacion- 1);
            ViewBag.Acertijo = Escape.GetAcertijos(proxHabitacion-1);
            ViewBag.Titulo = Escape.GetTitulo(proxHabitacion-1);
            ViewBag.PistasUsadas = Escape.pistasUsadas;
            string video = Escape.incognitasSalas[Escape.GetEstadoJuego()-1];
            ViewBag.Video = "~/vid/"+video+".mp4";
            string error = Escape.ResolverSala(sala,clave);
        if (error == "Sala incorrecta") {
                Escape.timer = timer;
                ViewBag.Timer = Escape.timer;
                return View("Habitacion"+Escape.GetEstadoJuego());
        }
        if (error == "true") {
           
            if(Escape.GetEstadoJuego() >= 6) {
                Escape.setUsuarios();
                ViewBag.Usuarios = Escape.getUsuarios();
                return View("Ganador");
            }
            Escape.timer = timer;
            ViewBag.Timer = Escape.timer;
            proxHabitacion = Escape.GetEstadoJuego();
            ViewBag.Pistas=Escape.GetPistas(proxHabitacion- 1);
            ViewBag.PistasUsadas = Escape.pistasUsadas;
            ViewBag.Acertijo = Escape.GetAcertijos(proxHabitacion-1);
            ViewBag.Titulo = Escape.GetTitulo(proxHabitacion-1);
            ViewBag.Vidas = 3-Escape.errores;
            video = Escape.incognitasSalas[Escape.GetEstadoJuego()-1];
            ViewBag.Video = "~/vid/"+video+".mp4";
            return View("Habitacion"+Escape.GetEstadoJuego());
        } else {
                if(Escape.Error()) {
                    return View("perdedor");
                }
                Escape.timer = timer;
                ViewBag.Timer = Escape.timer;
                ViewBag.Error = error;
                ViewBag.Vidas = 3-Escape.errores;
                return View("Habitacion"+Escape.GetEstadoJuego());
            }
        }
    }

    

