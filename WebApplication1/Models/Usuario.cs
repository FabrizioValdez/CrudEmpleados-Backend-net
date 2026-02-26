using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string Rol { get; set; } // Admin o User
    }
}
