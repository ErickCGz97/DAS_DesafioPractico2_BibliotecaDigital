using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaDigital.Models
{
    public class Calificacion
    {
        [Key]
        public int IdCalificacion { get; set; }

        [Required]
        [Range(1, 5)] // Asegura valores entre 1 y 5
        public int Puntuacion { get; set; }

        [Required]
        public DateTime FechaHora { get; set; } = DateTime.Now;

        // Relación con Libro
        [ForeignKey("Libro")]
        public int IdLibro { get; set; }
        public virtual Libro? Libro { get; set; }
    }
}