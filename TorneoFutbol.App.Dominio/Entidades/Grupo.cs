using System.Collections.Generic;
namespace TorneoFutbol.App.Dominio
{
     
    public class Grupo
    {
        public int Id { get; set; }

        public string Nombre_Grupo{get; set;}
        public string Parentesco { get; set; }
        public string Nombre_Integrante { get; set; }
        public string Cedula_Integrante { get; set; }
        
    }
}