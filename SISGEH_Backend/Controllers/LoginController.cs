using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SISGEH_Backend.DTOs;
using SISGEH_Backend.Entities;
using SISGEH_Backend.Services.SPersonalDeLaEmpresa;

namespace SISGEH_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ICRUD_Personal _personalDeLaEmpresa;
        private bool _respuesta;

        public LoginController(ICRUD_Personal personalDeLaEmpresa)
        {
            //... La clase Mapper la voy a inyectar para así mapear los datos.
            _personalDeLaEmpresa = personalDeLaEmpresa;
        }

        [HttpPost("iniciar-sesion")]
        public ActionResult<string> IniciarSesion() 
        {
            return string.Empty;
        }

        [HttpPost("nuevo-personal")]
        public ActionResult NuevoPersonal([FromForm] PersonalDeLaEmpresaDTO nuevoPersonal) 
        {
            _respuesta = _personalDeLaEmpresa.NuevoPersonal(nuevoPersonal);
            if (_respuesta)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("recuperar-sesion")]
        public ActionResult<string> RecuperarSesion() 
        {
            return string.Empty;
        }

        public Token ConstruirToken() 
        {
            throw new NotImplementedException();
        }
    }
}
