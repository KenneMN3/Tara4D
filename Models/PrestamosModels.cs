using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Models
{
    public class PrestamosModels
    {
        [Key]
        public int PrestamoId { get; set; }  // Primary Key

        [Required(ErrorMessage = "La fecha de préstamo es requerida.")]
        [DataType(DataType.Date)]
        public DateTime FechaPrestamo { get; set; }

        [Required(ErrorMessage = "La fecha de devolución es requerida.")]
        [DataType(DataType.Date)]
        public DateTime FechaDevolucion { get; set; }

        [Required(ErrorMessage = "El estado del préstamo es requerido.")]
        public string Estado { get; set; }

        // Relación con Usuarios
        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }

        public UsuariosModels Usuario { get; set; }

        // Relación con Libros
        [ForeignKey("LibroId")]
        public int LibroId { get; set; }

        public LibrosModels Libro { get; set; }
    }
}
