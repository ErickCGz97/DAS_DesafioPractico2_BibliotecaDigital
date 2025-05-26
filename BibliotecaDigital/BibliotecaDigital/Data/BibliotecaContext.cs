using Microsoft.EntityFrameworkCore;
using BibliotecaDigital.Models;


namespace BibliotecaDigital.Data
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options)
        {
        }

        public DbSet<Libro> Libros { get; set; }
        public DbSet<Calificacion> Calificaciones { get; set; }
    }
}
