using System;
using System.ComponentModel.DataAnnotations;

namespace AgendaWeb.Models
{
    public class Contact
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [Phone(ErrorMessage = "Formato de teléfono no válido.")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "Formato de correo no válido.")]
        public string Email { get; set; } = string.Empty;

        // Campo opcional para notas o comentarios
        public string? Notes { get; set; }

        // Fecha de creación automática
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}



