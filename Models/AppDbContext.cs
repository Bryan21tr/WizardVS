using Microsoft.EntityFrameworkCore;
using WizardVS.Models;

namespace WizardVS.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; } 
        public DbSet<Empleado> Empleados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>().HasKey(p => p.Id_Producto);
            modelBuilder.Entity<Empleado>().HasKey(p => p.id_empleado);
        }
     
}
}