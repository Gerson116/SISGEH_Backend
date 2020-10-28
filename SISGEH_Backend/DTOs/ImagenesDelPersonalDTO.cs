using SISGEH_Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISGEH_Backend.DTOs
{
    public class ImagenesDelPersonalDTO
    {
        public int ID { get; set; }
        public int PersonalDeLaEmpresaId { get; set; }
    }
}
