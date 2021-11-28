using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TorneoFutbol.App.Dominio
{
   
   
    public class Entidad
    {
        

        public int Id { get; set; }
        [Required(ErrorMessage = "La Razon social es Obligatoria")]
        public string Razon_Social { get; set; }
        [Required(ErrorMessage = "El Nit es Obligatorio")]

        public string Nit { get; set; }
        [Required(ErrorMessage = "La Dirección es Obligatoria")]

        public string Direccion { get; set; }
         [Required(ErrorMessage = "El Teléfono es Obligatorio")]

        public string Teléfono{get; set;}
         [Required(ErrorMessage = "La Ciudad es Obligatoria")]

        public string Ciudad{get; set;}
        [Required(ErrorMessage = "El Sector es Obligatorio")]
        public Sector Sector{get; set;}
        [Required(ErrorMessage = "El Tipo de Servicio es Obligatorio")]

        public Tipo_Servicio Tipo_Servicio{get; set;}

        public string Direccion_Electronica{get; set;}

        public string Pagina_Web{get; set;}

        public Migrante Migrante{get; set;}
       

        
        
    }
}