using Microsoft.EntityFrameworkCore;

namespace BunkerSoftServidor.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Pruebas> Pruebas { get; set; }
    }
}