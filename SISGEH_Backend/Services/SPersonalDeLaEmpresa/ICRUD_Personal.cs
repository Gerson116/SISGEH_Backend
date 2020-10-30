using SISGEH_Backend.DTOs;
using SISGEH_Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISGEH_Backend.Services.SPersonalDeLaEmpresa
{
    public interface ICRUD_Personal
    {
        PersonalDeLaEmpresa PerfilDelPersonal(int id_personal);
        IniciarSesion Sesion (IniciarSesion iniciarSesion);
        bool NuevoPersonal(PersonalDeLaEmpresaDTO nuevo_Personal);
        PersonalDeLaEmpresa EditarPersonal(PersonalDeLaEmpresaDTO editar_Personal);
        bool EliminarPersonal(PersonalDeLaEmpresa datosDelPersonal);
        bool EliminarPersonal(int id_personal);
        bool CambiarEstadoDelPersonal(int id_Personal, bool estado);
    }
}
