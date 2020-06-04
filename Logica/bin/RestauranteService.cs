using Datos;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logica
{
    public class PersonaService
    {
        private readonly RestauranteContext _context;

        public PersonaService(RestauranteContext context)
        {
            _context = context;
        }

        public GuardarRestauranteResponse Guardar(Restaurante restaurante)
        {
            try
            {
                var res = _context.Restaurantes.Find(restaurante.Nit);
                if (res != null)
                {
                    return new GuardarRestauranteResponse("Error el Restaurante ya se encuentra registrado");
                }

                restaurante.Evaluacio();
                _context.Restaurantes.Add(restaurante);
                _context.SaveChanges();

                return new GuardarRestauranteResponse(restaurante);
            }
            catch (Exception e)
            {
                return new GuardarRestauranteResponse($"Error de la Aplicacion: {e.Message}");
            }
        }
        public class GuardarRestauranteResponse
        {
            public GuardarRestauranteResponse(Restaurante restaurante)
            {
                Error = false;
                Restaurante = restaurante;
            }
            public GuardarRestauranteResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public Restaurante Restaurante { get; set; }
        }

        public List<Restaurante> ConsultarTodos()
        {
            List<Restaurante> restaurantes = _context.Restaurantes.ToList();
            return restaurantes;
        }

        public string Eliminar(string Nit)
        {
            try
            {
                var restaurante = _context.Restaurantes.Find(Nit);
                if (restaurante != null)
                {
                    _context.Restaurantes.Remove(restaurante);
                    _context.SaveChanges();
                    return ($"El registro {restaurante.NombreRestaurante} se ha eliminado satisfactoriamente.");
                }
                else
                {
                    return ($"Lo sentimos, {Nit} no se encuentra registrada.");
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }

        }

        public string Modificar(Restaurante restauranteN)
        {
            try
            {
                var restauranteV = _context.Restaurantes.Find(restauranteN.Nit);
                if (restauranteV != null)
                {
                    restauranteV.Nit = restauranteN.Nit;
                    restauranteV.NombreRestaurante = restauranteN.NombreRestaurante;
                    restauranteV.Direccion = restauranteN.Direccion;
                    restauranteV.Evaluacion = restauranteN.Evaluacion;
                    restauranteV.Estado = restauranteN.Estado;
                    restauranteV.Id = restauranteN.Id;
                    _context.Restaurantes.Update(restauranteV);
                    _context.SaveChanges();
                    return ($"El registro {restauranteN.Nit} se ha modificado satisfactoriamente");

                }
                else
                {
                    return ($"Lo sentimos, {restauranteN.Nit} no se encuentra registrado.");

                }
            }
            catch (Exception e)
            {
                return ($"Error de la aplicacion: {e.Message}.");

            }
        }

        public Restaurante BuscarPorNit(string Nit)
        {

            Restaurante restaurante = _context.Restaurantes.Find(Nit);
            return restaurante;
        }
    }
}
