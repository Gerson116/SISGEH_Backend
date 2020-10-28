using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SISGEH_Backend.DTOs;

namespace SISGEH_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public LoginController()
        {
            //...
        }

        [HttpPost("iniciar-sesion")]
        public ActionResult<string> IniciarSesion() 
        {
            return string.Empty;
        }

        [HttpPost("nuevo-personal")]
        public ActionResult<string> NuevoPersonal([FromForm] PersonalDeLaEmpresaDTO nuevoPersonal) 
        {
            return string.Empty;
        }

        [HttpPost("recuperar-sesion")]
        public ActionResult<string> RecuperarSesion() 
        {
            return string.Empty;
        }
    }
}
