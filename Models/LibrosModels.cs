using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Models
{
    public class LibrosModels
    {
        [Key]
        public int LibroId { get; set; }  // Primary Key

        [Required(ErrorMessage = "El título del libro es requerido.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "El género del libro es requerido.")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "La fecha de publicación es requerida.")]
        [DataType(DataType.Date)]
        public DateTime FechaPublicacion { get; set; }

        [Required(ErrorMessage = "El ISBN es requerido.")]
        public string ISBN { get; set; }

        // Relación con Autores (muchos libros pueden ser de un autor)
        [ForeignKey("AutorId")]
        public int AutorId { get; set; }

        public AutoresModels Autor { get; set; }

        // Relación con Editoriales (un libro tiene una editorial)
        [ForeignKey("EditorialId")]
        public int EditorialId { get; set; }

        public EditorialesModels Editorial { get; set; }
    }
}
