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
            escuela.Dirección = "TV 72F # 43 - 59";            
            escuela.TipoEscuela = TiposEscuela.Secundaria;            

            //Cargar cursos de la escuela
            var cursos = CargarCursos(escuela);

            //x cada curso cargar asignaturas
            var asignaturas = CargarAsignatura(cursos);

            //x cada curso cargar alumnos
            var alumnos = CargarAlumnos(cursos);

            modelBuilder.Entity<Escuela>().HasData(escuela);
            modelBuilder.Entity<Curso>().HasData(cursos.ToArray());
            modelBuilder.Entity<Asignatura>().HasData(asignaturas.ToArray());
            modelBuilder.Entity<Alumno>().HasData(alumnos.ToArray());       
        }

        //Para crear alumnos
        private List<Alumno> GenerarAlumnosAlAzar(Curso curso, int cantidad)
        {
            string[] nombre1 = {"Carlos", "Alberto", "Pedro", "Jose"};
            string[] nombre2 = {"Victor", "Juan", "Albaro", "Julian"};
            string[] apellido = {"Mesa", "Gutierrez", "Rojas", "Gonzalez"};

            var listadoAlumnos = from n1 in nombre1
                                from n2 in nombre2
                                from apll in apellido
                                select new Alumno { 
                                    Id = Guid.NewGuid().ToString(),
                                    Nombre = $"{n1} {n2} {apll}",
                                    CursoId = curso.Id                                    
                                };
            
            return listadoAlumnos.OrderBy((apll) => apll.Id).Take(cantidad).ToList();
        }

        //Para cargar alumnos
        private List<Alumno> CargarAlumnos(List<Curso> cursos)
        {
            var listAlumnos = new List<Alumno>();

            Random rnd = new Random();
            foreach(var curso in cursos){
                int cantRandom = rnd.Next(5, 20);
                var tempList = GenerarAlumnosAlAzar(curso, cantRandom);
                listAlumnos.AddRange(tempList);
            }
            return listAlumnos;
        }

        //Para generar cursos
        private static List<Curso> CargarCursos(Escuela escuela)
        {
            return new List<Curso>() {
                new Curso() {
                    Id = Guid.NewGuid().ToString(),
                    EscuelaId = escuela.Id,
                    Nombre = "101",
                    Jornada = TiposJornada.Mañana
                },
                new Curso() {
                    Id = Guid.NewGuid().ToString(),
                    EscuelaId = escuela.Id,
                    Nombre = "102",
                    Jornada = TiposJornada.Mañana
                },
                new Curso() {
                    Id = Guid.NewGuid().ToString(),
                    EscuelaId = escuela.Id,
                    Nombre = "201",
                    Jornada = TiposJornada.Tarde
                },
                new Curso() {
                    Id = Guid.NewGuid().ToString(),
                    EscuelaId = escuela.Id,
                    Nombre = "202",
                    Jornada = TiposJornada.Noche
                },
                new Curso() {
                    Id = Guid.NewGuid().ToString(),
                    EscuelaId = escuela.Id,
                    Nombre = "301",
                    Jornada = TiposJornada.Mañana
                },
                new Curso() {
                    Id = Guid.NewGuid().ToString(),
                    EscuelaId = escuela.Id,
                    Nombre = "302",
                    Jornada = TiposJornada.Tarde
                }
            };
        }

        //para relacionar cursos con asignaturas
        private static List<Asignatura> CargarAsignatura (List<Curso> cursos)
        {
            var listCompleta = new List<Asignatura>();
            foreach(var curso in cursos)
            {
                var tmpLista = new List<Asignatura>{
                    new Asignatura {
                        Id = Guid.NewGuid().ToString(),
                        CursoId = curso.Id,
                        Nombre = "Matematicas"
                    },
                    new Asignatura {
                        Id = Guid.NewGuid().ToString(),
                        CursoId = curso.Id,
                        Nombre = "Español"
                    },
                    new Asignatura {
                        Id = Guid.NewGuid().ToString(),
                        CursoId = curso.Id,
                        Nombre = "Ingles"
                    },
                    new Asignatura {
                        Id = Guid.NewGuid().ToString(),
                        CursoId = curso.Id,
                        Nombre = "Ciencias Naturales"
                    }
                };   
                listCompleta.AddRange(tmpLista);
                //curso.Asignaturas = listCompleta;
            }

            return listCompleta;
        }

    }
}