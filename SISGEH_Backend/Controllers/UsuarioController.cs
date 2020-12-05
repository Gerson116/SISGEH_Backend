using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SISGEH_Backend.Context;
using SISGEH_Backend.DTOs;
using SISGEH_Backend.Entities;
using SISGEH_Backend.Services.SPersonalDeLaEmpresa;

namespace SISGEH_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UsuarioController : ControllerBase
    {
        private ICRUD_Personal _personal;
        private IMapper _mapper;
        private SISGEH_DbContext _context;

        public UsuarioController(ICRUD_Personal personal, IMapper mapper, SISGEH_DbContext context)
        {
            //...
            _personal = personal;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet("personal")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "bb2d5d6e-c72e-4bb6-b245-b9058235c396")]
        public ActionResult<List<PersonalDeLaEmpresaDTO>> ListadoPersonal() 
        {
            var listado = _personal.ListadoEmpleado();
            return listado;
        }

        [HttpGet("perfil/{idPersonal}")]
        public ActionResult<PersonalDeLaEmpresaDTO> Perfil(int idPersonal) 
        {
            var datos = _personal.PerfilDelPersonal(idPersonal);
            if (datos == null)
            {
                return NotFound();
            }
            return datos;
        }

        [HttpPost("nuevo-empleado")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "bb2d5d6e-c72e-4bb6-b245-b9058235c396")]
        public ActionResult NuevoEmpleado([FromForm] PersonalDeLaEmpresaDTO personalDeLaEmpresa)
        {
            var datos = _personal.NuevoPersonal(personalDeLaEmpresa);
            if (datos != null)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("modificar-datos/{idPersonal}")]
        [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme, Roles = "bb2d5d6e-c72e-4bb6-b245-b9058235c396")]
        public ActionResult ActualizarDatosPersonal([FromForm] PersonalDeLaEmpresaDTO personalDeLaEmpresa, int idPersonal) 
        {
            personalDeLaEmpresa.ID = idPersonal;
            var datos = _personal.EditarPersonal(personalDeLaEmpresa);
            if (datos)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPatch("editar-perfil/{idPersonal}")]
        public ActionResult ActualizarDatosPersonalSoloEstado(int idPersonal, [FromBody] JsonPatchDocument<PersonalDeLaEmpresa> patchDocument)
        {
            //...
            var perfilDTO = _personal.PerfilDelPersonal(id_personal: idPersonal);
            if (patchDocument != null && perfilDTO != null)
            {
                var perfil = _mapper.Map<PersonalDeLaEmpresa>(perfilDTO);

                patchDocument.ApplyTo(perfil, ModelState);
                var isValid = TryValidateModel(perfil);
                if (!isValid)
                {
                    return BadRequest(ModelState);
                }
                _context.SaveChanges();
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("eliminar-personal/{idPersonal}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "bb2d5d6e-c72e-4bb6-b245-b9058235c396")]
        public ActionResult EliminarPersonal(int idPersonal)
        {
            bool respuesta = _personal.EliminarPersonal(idPersonal);
            if (respuesta)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
