using Microsoft.AspNetCore.Mvc;
using _NetCore.Models;

public class CursoController : Controller
{
    private EscuelaContext _context;

    public CursoController(EscuelaContext context)
    {   
        _context = context;
    }

    [Route("Curso/{cursoId?}")]
    [Route("Curso/Index/{cursoId?}")]    
    public IActionResult Index(string cursoId)
    {
        @ViewBag.Fecha = DateTime.Now;

        if (!string.IsNullOrEmpty(cursoId))
        {
            var cursoSel = from cur in _context.Cursos
                        where cur.Id == cursoId
                        select cur;

            return View(cursoSel.SingleOrDefault());

        } else {

            return View("ListCursos", _context.Cursos);

        }
    }

    public IActionResult ListCursos()
    {
        @ViewBag.Fecha = DateTime.Now;
        return View(_context.Cursos);
    }

    public IActionResult Create()
    {
        @ViewBag.Fecha = DateTime.Now;
        return View();
    }

    [HttpPost]
    public IActionResult Create(Curso curso)
    {
        _context.Cursos.Add(curso);
        _context.SaveChanges();
        return View();
    }

}