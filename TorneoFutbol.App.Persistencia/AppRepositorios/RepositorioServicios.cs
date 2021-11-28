using System.Collections.Generic;
using System.Linq;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Persistencia
{
    public class RepositorioServicios : IRepositorioServicios
    {
        private readonly AppContext _appContext = new AppContext();
        
        Servicio IRepositorioServicios.AddServicios(Servicio Servicios)
        {
            var ServicioAdicionado = _appContext.Servicios.Add(Servicios);
            _appContext.SaveChanges();
            return ServicioAdicionado.Entity;
        }

        void IRepositorioServicios.DeleteServicios(int IdServicios)
        {
            var ServicioEncontrado=_appContext.Servicios.FirstOrDefault(m=>m.Id==IdServicios);
            if(ServicioEncontrado==null)
                return;
            _appContext.Servicios.Remove(ServicioEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Servicio> IRepositorioServicios.GetAllServicios()
        {
            return _appContext.Servicios;
        }

        Servicio IRepositorioServicios.GetServicios(int IdServicios)
        {
            return _appContext.Servicios.FirstOrDefault(m=>m.Id==IdServicios);
            
        }

        Servicio IRepositorioServicios.UpdateServicios(Servicio Servicio)
        {
            var ServicioEncontrado=_appContext.Servicios.FirstOrDefault(m=>m.Id==Servicio.Id);
            if(ServicioEncontrado!=null)
            {
                ServicioEncontrado.Nombre = Servicio.Nombre;
                ServicioEncontrado.Numero_Migrantes = Servicio.Numero_Migrantes;
                ServicioEncontrado.Fecha_Inico_Servicio = Servicio.Fecha_Inico_Servicio;
                ServicioEncontrado.Fecha_Fin_Servicio = Servicio.Fecha_Fin_Servicio;
                ServicioEncontrado.Estado_Servicio = Servicio.Estado_Servicio;
                _appContext.SaveChanges();
            }
            return ServicioEncontrado;
        }
        public IEnumerable<Servicio> GetServicioNombre(string nombre)
        {
            return _appContext.Servicios
                   .Where(P => P.Nombre.Contains(nombre));
        }
    }
}


