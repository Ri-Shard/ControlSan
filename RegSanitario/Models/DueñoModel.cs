using System.ComponentModel.DataAnnotations;
using System;
using Entity;
using Logica;
namespace RegSanitario.Models
{
    public class DueñoInputModel{
        [Required(ErrorMessage = "El nombre  es requerido")]
        [StringLength(12,ErrorMessage="No puede ingresar mas de 12 Caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Apellido  es requerido")]
        [StringLength(12,ErrorMessage="No puede ingresar mas de 12 Caracteres")]

        public string Apellido { get; set; }
        [Required(ErrorMessage = "El ID  es requerido")]
        [StringLength(10,ErrorMessage="No puede ingresar mas de 10 Caracteres")]

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
