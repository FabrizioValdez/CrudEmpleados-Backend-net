namespace WebApplication1.Models;
using System.ComponentModel.DataAnnotations;

    public class Empleado
    {
        [Key]
        public int IdEmpleado { get; set; } // EF Core reconocerá esto como PK
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Sueldo { get; set; }
    }

