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
namespace RegSanitario.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class DueñoController: ControllerBase
   {
       private readonly DueñoService _dueñoService;
        public DueñoController(RestauranteContext context)
        {
            _dueñoService = new DueñoService(context);
        }

      [HttpGet]
      public IEnumerable<DueñoViewModel> Get() {
          var dueños = _dueñoService.ConsultarTodos().Select(u => new DueñoViewModel(u));
          return dueños;
      }
      
      [HttpPost]
      public ActionResult<DueñoViewModel> Post(DueñoInputModel dueñoInput) {
          
          Dueño dueño = mapearDueño(dueñoInput);
          var respuesta = _dueñoService.Guardar(dueño);
          if (respuesta.Error)
          {
              return BadRequest(respuesta.Mensaje);
          }
          return Ok(respuesta.Dueño);
      }
      private Dueño mapearDueño(DueñoInputModel dueñoInput){
          Dueño dueño = new Dueño();
          dueño.Nombre = dueñoInput.Nombre;
          dueño.Apellido = dueñoInput.Apellido;
          dueño.ID = dueñoInput.ID;

          return dueño;
      }

    }
}