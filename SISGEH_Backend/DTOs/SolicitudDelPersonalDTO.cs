using SISGEH_Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISGEH_Backend.DTOs
{
    public class SolicitudDelPersonalDTO
    {
        public int ID { get; set; }
        public int TipoDeSolicitudId { get; set; }
        public TipoDeSolicitud TipoDeSolicitud { get; set; }
        public int PersonalDeLaEmpresaId { get; set; }
        public PersonalDeLaEmpresa PersonalDeLaEmpresa { get; set; }
        public string DescripcionDeLaSolicitud { get; set; }
        public int TiempoRequerido { get; set; }
        public DateTime FechaDeSolicitud { get; set; }
        public DateTime FechaDeRespuesta { get; set; }
    }
}
