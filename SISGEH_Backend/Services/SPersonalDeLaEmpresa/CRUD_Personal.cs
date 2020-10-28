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
        public bool CambiarEstadoDelPersonal(int id_Personal, bool estado)
        {
            throw new NotImplementedException();
        }

        public PersonalDeLaEmpresa EditarPersonal(PersonalDeLaEmpresaDTO editar_Personal)
        {
            throw new NotImplementedException();
        }

        public bool EliminarPersonal(PersonalDeLaEmpresa eliminarPersonal)
        {
            throw new NotImplementedException();
        }

        public bool EliminarPersonal(int id_personal)
        {
            throw new NotImplementedException();
        }

        public PersonalDeLaEmpresa NuevoPersonal(PersonalDeLaEmpresaDTO nuevo_Personal)
        {
            throw new NotImplementedException();
        }

        public PersonalDeLaEmpresa PerfilDelPersonal(int id_personal)
        {
            throw new NotImplementedException();
        }
    }
}
