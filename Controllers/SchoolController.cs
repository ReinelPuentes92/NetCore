using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _NetCore.Models;

namespace _NetCore.Controllers;

public class SchoolController : Controller
{
    public IActionResult Index()
    {
        var school = new School();
        
        school.YearFundation = 2005;
        school.SchoolId = Guid.NewGuid().ToString();
        school.NameSchool = "Constanza";

        @ViewBag.cosaDinamica = "Pruebas";
        
        return View(school);
    }
}