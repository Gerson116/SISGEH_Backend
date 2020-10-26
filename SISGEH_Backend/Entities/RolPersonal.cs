using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SISGEH_Backend.Entities
{
    public class RolPersonal
    {
        public int ID { get; set; }
        public string CodigoDelRol { get; set; }
        [Required]
        public string NombreDelRol { get; set; }
    }
}
