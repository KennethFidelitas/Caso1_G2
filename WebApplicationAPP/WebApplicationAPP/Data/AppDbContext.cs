using Microsoft.EntityFrameworkCore;
using WebApplicationAPP.Models;

namespace WebApplicationAPP.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Reserva> Reservas { get; set; }

    }
}
