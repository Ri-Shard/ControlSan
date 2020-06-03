using System.ComponentModel.DataAnnotations;
using System;
using Entity;
using Logica;
namespace RegSanitario.Models
{
    public class RestauranteInputModel{
        [Required(ErrorMessage = "El nombre  es requerido")]
        [StringLength(20,ErrorMessage="No puede ingresar mas de 20 Caracteres")]
        public string NombreRestaurante { get; set; }
        [Required(ErrorMessage = "La Direccion es requerida")]
        [StringLength(20,ErrorMessage="No puede ingresar mas de 20 Caracteres")]
        public string Direccion { get; set; }
        public string Evaluacion { get; set; }
         [Required(ErrorMessage = "El Nit  es requerido")]
        [StringLength(20,ErrorMessage="No puede ingresar mas de 20 Caracteres")]
        public string Nit { get; set; }
        [Required(ErrorMessage = "El estado es requerido")]
        [StringLength(20,ErrorMessage="No puede ingresar mas de 20 Caracteres")]
        public string Estado { get; set; }
        [Required(ErrorMessage = "La identificacion del Dueño es requerida")]
        [StringLength(10,ErrorMessage="No puede ingresar mas de 10 Caracteres")]
        public string Id { get; set; }

    }
        public class RestauranteViewModel: RestauranteInputModel
    {
        public RestauranteViewModel(Restaurante restaurante)
        {
            NombreRestaurante = restaurante.NombreRestaurante;
            Direccion = restaurante.Direccion;
            Evaluacion = restaurante.Evaluacion;
            Nit = restaurante.Nit;
            Estado = restaurante.Estado;
            Id = restaurante.Id;
        }
    }

}
