using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SISGEH_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public UsuarioController()
        {
            //...
        }

        [HttpGet("personal")]
        public ActionResult<string> ListadoPersonal() 
        {
            return string.Empty;
        }

        [HttpGet("perfil-personal/{id}")]
        public ActionResult<string> Perfil(int id_personal) 
        {
            return string.Empty;
        }

        [HttpPost("nuevo-empleado")]
        public ActionResult<string> NuevoEmpleado() 
        {
            return string.Empty;
        }

        [HttpPut("modificar-datos")]
        public ActionResult<string> ActualizarDatosPersonal() 
        {
            return string.Empty;
        }
    }
}
