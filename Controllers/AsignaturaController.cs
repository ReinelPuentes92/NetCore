using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using _NetCore.Models;

public class AsignaturaController : Controller
{
    private EscuelaContext _context;

    public AsignaturaController(EscuelaContext context)
    {
        _context = context;
    }

    [Route("Asignatura/Index/{asignaturaId?}")]
    public IActionResult Index(string asignaturaId)
    {

        if (!string.IsNullOrEmpty(asignaturaId))
        {
            var asignaruta = from asing in _context.Asignaturas
                         where asing.Id == asignaturaId
                         select asing;

            return View(asignaruta.SingleOrDefault());
        } else {
            return View("ListAsignatura", _context.Asignaturas);
        }

    }

    public IActionResult ListAsignatura()
    {
        var listAsignaturas = _context.Asignaturas;
        @ViewBag.Fecha = DateTime.Now;
        
        return View(listAsignaturas);
    }
}