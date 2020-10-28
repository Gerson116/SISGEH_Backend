using SISGEH_Backend.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SISGEH_Backend.DTOs
{
    public class PersonalDeLaEmpresaDTO
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public DateTime FechaDeNacimiento { get; set; }
        [Required]
        public string Correo { get; set; }
        [Required]
        public string Pass { get; set; }
        [Required]
        public DateTime FechaDeIngreso { get; set; }
        [Required]
        public bool Estado { get; set; }
        public int RolPersonalId { get; set; }
        public RolPersonalDTO RolPersonal { get; set; }
        public ICollection<TelefonosDelPersonal> NumeroDeTelefono { get; set; }
    }
}
