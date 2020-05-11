using System;

namespace Entity
{
    public class Manipulador
    {
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public int Evaluacion { get; set; }
        public string Estado { get; set; }
        
        public void Evaluacio() 
         { 
            Estado = "Pendiente";
             }

    }
}
