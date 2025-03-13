using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Biblioteca.Models
{
    public class EditorialesModels
    {
        [Key]
        public int EditorialId { get; set; }  // Primary Key

        [Required(ErrorMessage = "El nombre de la editorial es requerido.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El país de origen es requerido.")]
        public string Pais { get; set; }

        [Required(ErrorMessage = "El año de fundación es requerido.")]
        public int AnioFundacion { get; set; }

        [Required(ErrorMessage = "El número de contacto es requerido.")]
        public string Contacto { get; set; }

        // Relación con Libros (una editorial puede tener varios libros)
        public ICollection<LibrosModels> Libros { get; set; }
    }
}
