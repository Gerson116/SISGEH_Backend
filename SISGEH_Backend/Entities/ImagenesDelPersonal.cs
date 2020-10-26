using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISGEH_Backend.Entities
{
    public class ImagenesDelPersonal
    {
        public int ID { get; set; }
        public int PersonalDeLaEmpresaId { get; set; }
        public PersonalDeLaEmpresa PersonalDeLaEmpresa { get; set; }
    }
}
