using System;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Restaurante
    {
       [Key]
        public string Nit {get; set;}
        public string NombreRestaurante { get; set; }
        public string Direccion { get; set; }
        public string Evaluacion { get; set; }
        public string Estado { get; set; }
        public string Id { get; set; }
        
        public void Evaluacio() 
         { 
            Estado = "Pendiente";
             }
        
    }
}
