//using Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using TorneoFutbol.App.Dominio;
using TorneoFutbol.App.Persistencia;

namespace TorneoFutbol.App.Consola
{
    class Program
    {
        private static IRepositorioMigrantes _repoMigrante = new RepositorioMigrantes();
        private static IRepositorioEntidades _repoEntidad = new RepositorioEntidades();
        private static IRepositorioServicios _repoServicio = new RepositorioServicios();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //AddMigrante();
            //AddEntidad();
            AddServicio();
            //BuscarDirectoresTecnicos(1);

        }

        private static void AddMigrante()
        {
            var Migrantes = new Migrante
            {
                Nombre = "Elbert",
                Apellidos = "Eiliz",
                Tipo_Identificacion = "Cedula",
                Numero_Identificacion = "13423523",
                Fecha_Nacimiento = new DateTime(1983, 9, 24),
            };

            _repoMigrante.AddMigrante(Migrantes);
        }

        private static void BuscarMigrantes(int IdMigrantes)
        {
            var Migrantes = _repoMigrante.GetMigrante(IdMigrantes);
            Console.WriteLine(Migrantes.Numero_Identificacion + " " + Migrantes.Nombre);
        }
        
        
        private static void AddEntidad()
        {
            var Entidad = new Entidad
            {
                Razon_Social = "Hospital la Miscericordia",
                Nit = "930522393",
                Direccion = "Calle 1 #50-3",
                Ciudad = "Manila",
                Teléfono = "21321444",
                Sector = Sector.Privado,
                Tipo_Servicio = Tipo_Servicio.Salud,
                Direccion_Electronica = "Soft@gmail.com",
                Pagina_Web = "www.optimusSystem.com"

                
            };

            _repoEntidad.AddEntidades(Entidad);
        }

        private static void AddServicio()
        {
            var servicios = new Servicio
            {
                Nombre = "Salud",
                Numero_Migrantes = 100,
                Fecha_Inico_Servicio = new DateTime(2021, 11, 27),
                Fecha_Fin_Servicio = new DateTime(2022, 11, 27),
                Estado_Servicio = Estado_Servicio.Activos

               
            };

            _repoServicio.AddServicios(servicios);
        }
    }

}
