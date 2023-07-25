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

    [Route("Alumno/Index/{alumnoId?}")]
    public IActionResult Index(string alumnoId)
    {
        @ViewBag.Fecha = DateTime.Now;

        if (!string.IsNullOrEmpty(alumnoId))
        {
            var alumnoSel = from alumn in _context.Alumnos
                         where alumn.Id == alumnoId
                         select alumn;

            return View(alumnoSel.SingleOrDefault());

        } else {

            return View("ListAlumno", _context.Alumnos);

        }
        
    }

    public IActionResult ListAlumno()
    {
        var listaAlumnos = _context.Alumnos;
        @ViewBag.Fecha = DateTime.Now;

        return View(listaAlumnos);
    }
    
}