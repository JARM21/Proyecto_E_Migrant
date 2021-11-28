using System.Collections.Generic;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Persistencia
{
    public interface IRepositorioServicios
    {
        IEnumerable<Servicio> GetAllServicios();

        Servicio AddServicios(Servicio Servicios);

        Servicio UpdateServicios(Servicio Servicios);

        void DeleteServicios(int IdServicios);

        Servicio GetServicios(int IdServicios);
        public IEnumerable<Servicio> GetServicioNombre(string nombre);
    }
}