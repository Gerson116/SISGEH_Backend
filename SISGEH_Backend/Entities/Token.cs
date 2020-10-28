using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISGEH_Backend.Entities
{
    public class Token
    {
        public string CodigoToken { get; set; }
        public DateTime FechaDeExpiracion { get; set; }
    }
}
