using System;
using System.ComponentModel.DataAnnotations;

namespace TorneoFutbol.App.Dominio
{
      
    public class Migrante 
    {
        // Identificador único de cada SugerenciaCuidado
        public int Id { get; set; }
        /// Nombre del municipio
        [Required(ErrorMessage = "El Nombre es Obligatorio")]
        public string Nombre  { get; set; }
        [Required(ErrorMessage = "Los Apellidos son Obligatorios")]

        public string Apellidos {get; set;}
        [Required(ErrorMessage = "El Tipo de Identificación es Obligatorio")]

        public string Tipo_Identificacion{get; set;}
        [Required(ErrorMessage = "El Numero de Identificación es Obligatorio")]

        public string Numero_Identificacion {get; set;}
        [Required(ErrorMessage = "La fecha de nacimiento es Obligatoria")]

        public DateTime Fecha_Nacimiento {get; set;}

        public string Direccion_Electronica{get; set;}

        public string Teléfono{get; set;}

        public string Dirección_Actual{get; set;}

        public string Ciudad{get; set;}

        public string Situación_Laboral{get; set;}

        public Grupo Grupo {get; set;}
        
    }
}