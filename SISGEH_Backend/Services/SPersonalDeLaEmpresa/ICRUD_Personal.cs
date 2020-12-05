using Microsoft.AspNetCore.JsonPatch;
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
        PersonalDeLaEmpresaDTO PerfilDelPersonal(int id_personal);
        List<PersonalDeLaEmpresaDTO> ListadoEmpleado();
        IniciarSesion Sesion(IniciarSesion iniciarSesion);
        bool NuevoPersonal(PersonalDeLaEmpresaDTO nuevo_Personal);
        bool EditarPersonal(PersonalDeLaEmpresaDTO editar_Personal);
        bool BloquearPersonal(int idPersonal, JsonPatchDocument<PersonalDeLaEmpresa> patchDocument);
        bool EliminarPersonal(int id_personal);
        bool CambiarEstadoDelPersonal(int id_Personal, bool estado);
    }
}
