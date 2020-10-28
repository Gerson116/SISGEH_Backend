using SISGEH_Backend.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SISGEH_Backend.DTOs
{
    public class TelefonosDelPersonalDTO
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(11)]
        public string NumeroTelefonico { get; set; }
        public int PersonalDeLaEmpresaId { get; set; }
    }
}
