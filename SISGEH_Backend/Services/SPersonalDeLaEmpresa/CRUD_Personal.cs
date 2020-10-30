using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SISGEH_Backend.Context;
using SISGEH_Backend.DTOs;
using SISGEH_Backend.Entities;
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
        private PersonalDeLaEmpresa _personal;

        public CRUD_Personal(SISGEH_DbContext dbcontext, IMapper mapper)
        {
            //....
            _dbcontext = dbcontext;
            _mapper = mapper;
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
            _personal = _dbcontext.PersonalDeLaEmpresa.FirstOrDefault(p => p.Correo == iniciarSesion.Correo && p.Pass == iniciarSesion.Pass);
            if (_personal != null)
            {
                iniciarSesion.Rol = _dbcontext.RolPersonal.Find(_personal.RolPersonalId).CodigoDelRol;
                return iniciarSesion;
            }
            return null;
        }
    }
}
