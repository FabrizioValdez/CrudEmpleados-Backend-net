using Microsoft.EntityFrameworkCore; // <--- ESTA ES LA LÍNEA MÁGICA QUE FALTA
using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1
{
    // Corregido: DbContext (con 't')
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Empleado> Empleados { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}