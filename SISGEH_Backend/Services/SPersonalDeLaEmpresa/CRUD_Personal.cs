using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SISGEH_Backend.Context;
using SISGEH_Backend.DTOs;
using SISGEH_Backend.Entities;
using SISGEH_Backend.Services.SEncriptando;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISGEH_Backend.Services.SPersonalDeLaEmpresa
{
    public class CRUD_Personal : ICRUD_Personal
    {
        private SISGEH_DbContext _dbcontext;
        private IMapper _mapper;
        private IHashService _hashService;
        private PersonalDeLaEmpresa _personal;
        private IDataProtector _protector;

        public CRUD_Personal(SISGEH_DbContext dbcontext, IMapper mapper, IHashService hashService,
            IDataProtectionProvider protectionProvider, IConfiguration configuration)
        {
            //....
            _dbcontext = dbcontext;
            _mapper = mapper;
            _hashService = hashService;
            _protector = protectionProvider.CreateProtector(configuration["Encriptando:key"]);
        }
        public bool CambiarEstadoDelPersonal(int id_Personal, bool estado)
        {
            throw new NotImplementedException();
        }

        public PersonalDeLaEmpresa EditarPersonal(PersonalDeLaEmpresaDTO editar_Personal)
        {
            if (editar_Personal != null)
            {
                _personal = _mapper.Map<PersonalDeLaEmpresa>(editar_Personal);
                _dbcontext.Entry(_personal).State = EntityState.Modified;
                _dbcontext.SaveChanges();
                return _personal;
            }
            return null;
        }

        public bool EliminarPersonal(PersonalDeLaEmpresa datosDelPersonal)
        {
            _personal = PerfilDelPersonal(datosDelPersonal.ID);
            if (_personal != null)
            {
                _dbcontext.PersonalDeLaEmpresa.Remove(datosDelPersonal);
                _dbcontext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool EliminarPersonal(int id_personal)
        {
            _personal = _dbcontext.PersonalDeLaEmpresa.Find(id_personal);
            if (_personal != null)
            {
                _dbcontext.PersonalDeLaEmpresa.Remove(_personal);
                _dbcontext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool NuevoPersonal(PersonalDeLaEmpresaDTO nuevo_Personal)
        {
            var encriptando = _protector.Protect(nuevo_Personal.Pass);
            nuevo_Personal.Pass = encriptando;

            if (nuevo_Personal != null)
            {
                _personal = _mapper.Map<PersonalDeLaEmpresa>(nuevo_Personal);
                _personal.FechaDeIngreso = DateTime.Today;
                _personal.Estado = true;
                _dbcontext.PersonalDeLaEmpresa.Add(_personal);
                _dbcontext.SaveChanges();
                return true;
            }
            return false;
        }

        public PersonalDeLaEmpresa PerfilDelPersonal(int id_personal)
        {
            _personal = _dbcontext.PersonalDeLaEmpresa.Find(id_personal);
            if (_personal != null)
            {
                return _personal;
            }
            return null;
        }

        public IniciarSesion Sesion(IniciarSesion iniciarSesion)
        {
            _personal = _dbcontext.PersonalDeLaEmpresa.FirstOrDefault(p => p.Correo == iniciarSesion.Correo);
            var desencriptandoPass = (iniciarSesion.Pass == _protector.Unprotect(_personal.Pass)) ? _personal.Pass : null;
            _personal = _dbcontext.PersonalDeLaEmpresa.FirstOrDefault(p => p.Correo == iniciarSesion.Correo && p.Pass == desencriptandoPass);

            if (_personal != null)
            {
                iniciarSesion.Rol = _dbcontext.RolPersonal.Find(_personal.RolPersonalId).CodigoDelRol;
                return iniciarSesion;
            }

            return null;
        }
    }
}
