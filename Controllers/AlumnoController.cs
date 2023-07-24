using System.Reflection.Metadata.Ecma335;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using _NetCore.Models;

public class AlumnoController : Controller
{

    private EscuelaContext _context;

    public AlumnoController(EscuelaContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        /*var alumno = new Alumno {
            Id = Guid.NewGuid().ToString(),
            Nombre = "Pepito Perez"
        };*/
        var alumno = _context.Alumnos.FirstOrDefault();
        @ViewBag.Fecha = DateTime.Now;

        return View(alumno);
    }

    public IActionResult ListAlumno()
    {
        var listaAlumnos = _context.Alumnos;
        @ViewBag.Fecha = DateTime.Now;

        return View(listaAlumnos);
    }
    
}