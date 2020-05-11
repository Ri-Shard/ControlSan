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
   public class DueñoController: ControllerBase
   {
       private readonly DueñoService _dueñoService;
       public IConfiguration Configuration {get;}

       public DueñoController(IConfiguration configuration){
           Configuration = configuration;
           string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
           _dueñoService = new DueñoService(connectionString);
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