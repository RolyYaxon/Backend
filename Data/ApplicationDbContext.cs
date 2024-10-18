using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        public DbSet<Inquilino> Inquilinos { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Propiedad> Propiedades { get; set; }
        public DbSet<Notificacion> Notificaciones { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>().HasKey(a => a.ID_Administrador);
            modelBuilder.Entity<Contrato>().HasKey(c => c.ID_Contrato);
            modelBuilder.Entity<Pago>().HasKey(p => p.ID_Pago);
            modelBuilder.Entity<Propiedad>().HasKey(pr => pr.ID_Propiedad);
            modelBuilder.Entity<Notificacion>().HasKey(n => n.ID_Notificacion);
            modelBuilder.Entity<Usuario>().HasKey(u => u.ID_Usuario);

      
      





            base.OnModelCreating(modelBuilder);
        }   
     
    }
}
