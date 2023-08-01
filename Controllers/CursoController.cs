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

    [Route("Curso/Create")]
    public IActionResult Create()
    {
        @ViewBag.Fecha = DateTime.Now;
        return View();
    }

    [HttpPost]
    [Route("Curso/Create")]
    public IActionResult Create(Curso curso)
    {        
        //Se agrega el curso
        if (!string.IsNullOrEmpty(curso.Nombre)) 
        {   
            var escuela = _context.Escuelas.FirstOrDefault();
            
            curso.EscuelaId = escuela.Id;               
            _context.Cursos.Add(curso);
            _context.SaveChanges();

            @ViewBag.Notificacion = "Curso creado.";
            return View("Index", curso);
            
        } 
        else 
        {
            @ViewBag.Notificacion = "Llenar los campos faltantes.";
            return View();
        }

    }

    [Route("Curso/Edit/{cursoId?}")]
    [HttpGet]
    public IActionResult Edit(string cursoId)
    {
        if (!string.IsNullOrEmpty(cursoId))
        {
            var curso = from cur in _context.Cursos
                    where cur.Id == cursoId
                    select cur;
            
            return View(curso.SingleOrDefault());
        }
        else
        {
            return View("ListCursos", _context.Cursos);
        }
        
    }

    [Route("Curso/Edit/{cursoId?}")]
    [HttpPost]
    public IActionResult Edit(string cursoId, Curso curso)
    {
        if (!string.IsNullOrEmpty(curso.Nombre) && !string.IsNullOrEmpty(cursoId))
        {
            try
            {
                var cursoField = new Curso(){
                    Id = curso.Id,
                    Nombre = curso.Nombre,
                    Jornada = curso.Jornada,
                    EscuelaId = curso.EscuelaId
                };
                
                 _context.Cursos.Update(cursoField);            
                 _context.SaveChanges();

                @ViewBag.Notificacion = "Curso actualizado.";
                return View("Index", curso);
            }
            catch (System.Exception)
            {
                
                throw;
            }
           
        }
        else
        {
            @ViewBag.Notificacion = "Llenar los campos faltantes.";
            return View();
        }
    }

}