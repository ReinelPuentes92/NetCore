using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _NetCore.Models;

public class AsignaturaController : Controller
{
    private EscuelaContext _context;

    public AsignaturaController(EscuelaContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {

        /*var asignatura = new Asignatura{
            Id = Guid.NewGuid().ToString(),
            Nombre = "Matematicas",
        };*/
        
        var asignatura = _context.Asignaturas.FirstOrDefault();
        @ViewBag.mensajeDinamico = "Materia para primaria y secundaria";
        @ViewBag.Fecha = DateTime.Now;

        return View(asignatura);
    }

    public IActionResult ListAsignatura()
    {
        var listAsignaturas = _context.Asignaturas;
        @ViewBag.Fecha = DateTime.Now;
        
        return View(listAsignaturas);
    }
}