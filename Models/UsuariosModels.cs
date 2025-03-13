using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Biblioteca.Models
{
    public class UsuariosModels
    {
        [Key]
        public int UsuarioId { get; set; }  // Primary Key

        [Required(ErrorMessage = "El nombre del usuario es requerido.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido del usuario es requerido.")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El correo electrónico es requerido.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "El teléfono es requerido.")]
        public string Telefono { get; set; }

        // Relación con Préstamos (un usuario puede tener varios préstamos)
        public ICollection<PrestamosModels> Prestamos { get; set; }
    }
}
