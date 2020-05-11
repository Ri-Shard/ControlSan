using System;
using Entity;
using Logica;
namespace RegSanitario.Models
{
    public class RestauranteInputModel{
        public string NombreRestaurante { get; set; }
        public string Direccion { get; set; }
        public string Evaluacion { get; set; }
        public string Nit { get; set; }
        public string Estado { get; set; }
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
