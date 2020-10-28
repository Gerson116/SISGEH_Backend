using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SISGEH_Backend.DTOs
{
    public class TipoDeSolicitudDTO
    {
        public int ID { get; set; }
        [Required]
        public string Nombre { get; set; }
    }
}
