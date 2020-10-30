using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SISGEH_Backend.DTOs
{
    public class IniciarSesion
    {
        [Required]
        public string Correo { get; set; }
        [Required]
        public string Pass { get; set; }
        public string Rol { get; set; }
    }
}
