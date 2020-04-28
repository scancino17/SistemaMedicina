using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaMedicinas.Models;

namespace SistemaMedicinas.Data
{
    public class SistemaMedicinasContext : DbContext
    {
        public SistemaMedicinasContext (DbContextOptions<SistemaMedicinasContext> options)
            : base(options)
        {
        }

        public DbSet<SistemaMedicinas.Models.Medicina> Medicina { get; set; }
    }
}
