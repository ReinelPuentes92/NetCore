using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _NetCore.Models;

public class EscuelaController : Controller
{

    private EscuelaContext _context;

    public EscuelaController(EscuelaContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var escuela = _context.Escuelas.FirstOrDefault();
        @ViewBag.cosaDinamica = "Pruebas";

        return View(escuela);
    }
}