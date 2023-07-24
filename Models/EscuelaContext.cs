using Microsoft.EntityFrameworkCore;

namespace _NetCore.Models
{
    public class EscuelaContext : DbContext
    {
        public DbSet<Escuela> Escuelas { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Evaluación> Evaluaciones { get; set; }

        public EscuelaContext(DbContextOptions<EscuelaContext> options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            //Escuela
            var escuela = new Escuela();
            escuela.AñoDeCreación = 2008;
            escuela.Id = Guid.NewGuid().ToString();
            escuela.Nombre = "Patzi School";
            escuela.Ciudad = "Bogotá";
            escuela.Pais = "Colombia";
            escuela.Dirección = "Avn 72";
            escuela.TipoEscuela = TiposEscuela.Secundaria;

            modelBuilder.Entity<Escuela>().HasData(escuela);

            //Asignatura
            modelBuilder.Entity<Asignatura>().HasData(
                new Asignatura {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "Matematicas"
                },
                new Asignatura {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "Español"
                },
                new Asignatura {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "Ingles"
                },
                new Asignatura {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "Ciencias Naturales"
                }
            );         

            //Alumno
            modelBuilder.Entity<Alumno>().HasData(
                GenerarAlumnosAlAzar().ToArray()
            );   
        }

        //Para crear alumnos
        private List<Alumno> GenerarAlumnosAlAzar()
        {
            string[] nombre1 = {"Carlos", "Alberto", "Pedro", "Jose"};
            string[] nombre2 = {"Victor", "Juan", "Albaro", "Julian"};
            string[] apellido = {"Mesa", "Gutierrez", "Rojas", "Gonzalez"};

            var listadoAlumnos = from n1 in nombre1
                                from n2 in nombre2
                                from apll in apellido
                                select new Alumno { Nombre = $"{n1} {n2} {apll}",
                                    Id = Guid.NewGuid().ToString()
                                };
            
            return listadoAlumnos.OrderBy((apll) => apll.Id).ToList();
        }

    }
}