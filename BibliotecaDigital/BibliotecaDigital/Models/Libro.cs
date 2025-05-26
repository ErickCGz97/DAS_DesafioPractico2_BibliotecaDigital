using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaDigital.Models
{
    public class Libro
    {
        [Key]
        public int IdLibro { get; set; }

        [Required]
        [StringLength(255)]
        public string Titulo { get; set; }

        [Required]
        [StringLength(255)]
        public string Autor { get; set; }

        [Required]
        [StringLength(100)]
        public string Genero { get; set; }

        [Required]
        public string Sinopsis { get; set; }

        [Required]
        [StringLength(500)]
        public string Portada_URL { get; set; }

        //Relacion con tabla Calificaciones
        public virtual ICollection<Calificacion>? Calificaciones { get; set; }

        //Nueva propiedad para almacenar el promedio de calificación
        [NotMapped] // Evita que esta propiedad se guarde en la base de datos
        public double PromedioCalificacion { get; set; }
    }
}
