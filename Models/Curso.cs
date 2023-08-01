using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace _NetCore.Models
{
    public class Curso:ObjetoEscuelaBase
    {
        [Display(Prompt = "Curso", Name = "Nombre curso")]
        [StringLength(5)]
        public override string Nombre { get; set; }        
        public TiposJornada Jornada { get; set; }     
        public List<Asignatura> Asignaturas{ get; set; }
        public List<Alumno> Alumnos{ get; set; }
        public string EscuelaId { get; set; }
        public Escuela Escuela { get; set; }
    }
}