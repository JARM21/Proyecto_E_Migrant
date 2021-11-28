using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace TorneoFutbol.App.Dominio
{
    
    public class Servicio
    {

        public int Id { get; set; }
        
        public string Nombre { get; set; }
        
        public int Numero_Migrantes { get; set; }

        public DateTime Fecha_Inico_Servicio{get; set;}  // pendiente

        public DateTime Fecha_Fin_Servicio{get; set;}

        public Estado_Servicio Estado_Servicio{get; set;}

    }
}