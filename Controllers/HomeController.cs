using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PreguntadORT.Models;

namespace PreguntadORT.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        Juego.InicializarJuego();
        ViewBag.Categorias = BD.ObtenerCategorias();
        ViewBag.dificultad = BD.ObtenerDificultades();
        return View();
    }

    public IActionResult Comenzar(string username, int dificultad, int categoria)
    {
        Juego.CargarPartida(username, dificultad, categoria);

        if(Juego.TienePreguntas())
        {
           return Jugar();
        }
        else
        {
            return ConfigurarJuego();
        }

    }

    public IActionResult Jugar()
    {
    Pregunta preguntaActual = Juego.ObtenerProximaPregunta();

    if (preguntaActual != null)
    {
    ViewBag.Pregunta = preguntaActual;

    List<Respuesta> respuestas = Juego.ObtenerProximasRespuestas(preguntaActual.Id);
    ViewBag.Respuestas = respuestas;

    return View("Juego","Home");
    
    }
    else
    {
    return View("Fin", "Home");
    }
    }

    [HttpPost] 
    
    // public IActionResult VerificarRespuesta(int idPregunta, int idRespuesta)
    // {
    //     bool esCorrecta = Juego.VerificarRespuesta(idPregunta, idRespuesta);
    //     ViewBag.EsCorrecta = esCorrecta;
    //     return View("Respuesta");
    // }

    public IActionResult ConfigurarJuego()
    {
        ViewBag.Categorias = BD.ObtenerCategorias();
        ViewBag.dificultad = BD.ObtenerDificultades();
        return View("InicializarJuego");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
