using System;
using Entity;
using Logica;
namespace RegSanitario.Models
{
    public class DueñoInputModel{
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string ID {get;set;}


    }
        public class DueñoViewModel: DueñoInputModel
    {
        public DueñoViewModel(Dueño dueño)
        {
            Nombre = dueño.Nombre;
            Apellido = dueño.Apellido;
            ID = dueño.ID;

        }
    }

}
