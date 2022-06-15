using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ProyectoFinal_JuegoWiki.Models;

namespace ProyectoFinal_JuegoWiki.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ProyectoFinal_JuegoWiki.Models.Ceniza> Ceniza { get; set; }
        public DbSet<ProyectoFinal_JuegoWiki.Models.TipoArma> TipoArma { get; set; }
        public DbSet<ProyectoFinal_JuegoWiki.Models.Arma> Arma { get; set; }
        public DbSet<ProyectoFinal_JuegoWiki.Models.Armadura> Armadura { get; set; }
        public DbSet<ProyectoFinal_JuegoWiki.Models.Consumible> Consumible { get; set; }
    }
}
