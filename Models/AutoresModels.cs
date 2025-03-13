

using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Biblioteca.Models
{
    public class AutoresModels
    {
        [Key]
        public int AutorId { get; set; }  // Primary Key

        [Required(ErrorMessage = "El nombre del autor es requerido.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido del autor es requerido.")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento del autor es requerida.")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "La nacionalidad del autor es requerida.")]
        public string Nacionalidad { get; set; }

        // Relación con Libros (1 autor puede tener varios libros)
        public ICollection<LibrosModels> Libros { get; set; }
    }
}
