using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
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
        private IConfiguration _configuration;
        private bool _respuesta;
        private IniciarSesion _iniciarSesion;

        public LoginController(ICRUD_Personal personalDeLaEmpresa, IConfiguration configuration)
        {
            //... La clase Mapper la voy a inyectar para así mapear los datos.
            _personalDeLaEmpresa = personalDeLaEmpresa;
            _configuration = configuration;
        }

        [HttpPost("iniciar-sesion")]
        public ActionResult<Token> IniciarSesion([FromForm] IniciarSesion iniciarSesion) 
        {
            _iniciarSesion = _personalDeLaEmpresa.Sesion(iniciarSesion);
            if (_iniciarSesion != null)
            {
                return ConstruirToken(_iniciarSesion);
            }
            return BadRequest();
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

        public Token ConstruirToken(IniciarSesion iniciarSesion)
        {
            var claim = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, iniciarSesion.Correo),
                new Claim(ClaimTypes.Role, iniciarSesion.Rol),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(1);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claim,
                expires: expiration,
                signingCredentials: creds
                );

            return new Token()
            {
                CodigoToken = new JwtSecurityTokenHandler().WriteToken(token),
                FechaDeExpiracion = expiration
            };
        }
    }
}
