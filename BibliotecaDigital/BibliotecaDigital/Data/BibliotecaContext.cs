using Microsoft.EntityFrameworkCore;
using BibliotecaDigital.Models;


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

        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de relación entre Libro y Calificación
            modelBuilder.Entity<Calificacion>()
                .HasOne(c => c.Libro)
                .WithMany(l => l.Calificaciones)
                .HasForeignKey(c => c.IdLibro);
        }
        */
    }
}
