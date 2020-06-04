using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Logica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RegSanitario.Models;
using Datos;
using System.ComponentModel.DataAnnotations;

namespace RegSanitario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestauranteController : ControllerBase
    {
        private readonly RestauranteService _restauranteService;
        public RestauranteController(RestauranteContext context)
        {
            _restauranteService = new RestauranteService(context);
        }

        [HttpGet]
        public IEnumerable<RestauranteViewModel> Get()
        {
            var restaurantes = _restauranteService.ConsultarTodos().Select(u => new RestauranteViewModel(u));
            return restaurantes;
        }

        [HttpPost]
        public ActionResult<RestauranteViewModel> Post(RestauranteInputModel restauranteInput)
        {

            Restaurante restaurante = mapearRestaurante(restauranteInput);
            var respuesta = _restauranteService.Guardar(restaurante);
            if (respuesta.Error)
            {
                ModelState.AddModelError("Guardar Restaurante", respuesta.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            return Ok(respuesta.Restaurante);
        }
        // DELETE: api/Persona/5
        [HttpDelete("{Nit}")]
        public ActionResult<string> Delete(string Nit)
        {
            string mensaje = _restauranteService.Eliminar(Nit);
            return Ok(mensaje);
        }
        private Restaurante mapearRestaurante(RestauranteInputModel restauranteInput)
        {
            var restaurante = new Restaurante
            {
                Estado = restauranteInput.Estado,
                NombreRestaurante = restauranteInput.NombreRestaurante,
                Direccion = restauranteInput.Direccion,
                Evaluacion = restauranteInput.Evaluacion,
                Nit = restauranteInput.Nit,
                Id = restauranteInput.Id

            };
            return restaurante;
        }
        // PUT: api/Restaurante/5
        [HttpPut("{Nit}")]
        public ActionResult<RestauranteViewModel> Put(string Nit, RestauranteInputModel restauranteInput)
        {
            Restaurante restaurante = mapearRestaurante(restauranteInput);
            var nit = _restauranteService.BuscarPorNit(restaurante.Nit);
            if (nit == null)
            {
                return BadRequest("No encontrado");
            }
            else
            {
                string respuesta = _restauranteService.Modificar(restaurante);
               return Ok(respuesta);
            }
        }
 
        
    }
}
