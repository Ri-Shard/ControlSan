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

namespace RegSanitario.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class RestauranteController: ControllerBase
   {
       private readonly RestauranteService _restauranteService;
       public IConfiguration Configuration {get;}

       public RestauranteController(IConfiguration configuration){
           Configuration = configuration;
           string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
           _restauranteService = new RestauranteService(connectionString);
       }

      [HttpGet]
      public IEnumerable<RestauranteViewModel> Get() {
          var restaurantes = _restauranteService.ConsultarTodos().Select(u => new RestauranteViewModel(u));
          return restaurantes;
      }
      
      [HttpPost]
      public ActionResult<RestauranteViewModel> Post(RestauranteInputModel restauranteInput) {
          
          Restaurante restaurante = mapearRestaurante(restauranteInput);
          var respuesta = _restauranteService.Guardar(restaurante);
          if (respuesta.Error)
          {
              return BadRequest(respuesta.Mensaje);
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

        [HttpPut("{Nit}")]
        public ActionResult<RestauranteViewModel> Put(string Nit, RestauranteInputModel restauranteInput)
        {
            Restaurante restaurante = mapearRestaurante(restauranteInput);
            var id=_restauranteService.BuscarPorNit(restaurante.Nit);
            if(id==null){
                return BadRequest("No encontrado");
            }else
            {
                var response = _restauranteService.Modificar(restaurante);
                if (response.Error) 
                {
                    ModelState.AddModelError("Modificar restaurante", response.Mensaje);
                    var problemDetails = new ValidationProblemDetails(ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest,
                    };
                    return BadRequest(response.Mensaje);
                }
                return Ok(response.Restaurante);                
            }
        }
   }
}