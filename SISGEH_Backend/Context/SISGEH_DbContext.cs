using Microsoft.EntityFrameworkCore;
using SISGEH_Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISGEH_Backend.Context
{
    public class SISGEH_DbContext : DbContext
    {
        public SISGEH_DbContext(DbContextOptions<SISGEH_DbContext> options) : base(options)
        {
            //...
        }
        public DbSet<PersonalDeLaEmpresa> PersonalDeLaEmpresa { get; set; }
        public DbSet<RolPersonal> RolPersonal { get; set; }
        public DbSet<TelefonosDelPersonal> TelefonosDelPersonal { get; set; }
        public DbSet<ImagenesDelPersonal> ImagenesDelPersonal { get; set; }
        public DbSet<SolicitudDelPersonal> SolicitudDelPersonal { get; set; }
        public DbSet<TipoDeSolicitud> TipoDeSolicitud { get; set; }
    }
}
