using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationAPP.Models
{
    [Table("Reservas_G2")]
    public class Reserva
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del asociado es requerido")]
        [StringLength(150)]
        public string NombreDelAsociado { get; set; } = string.Empty;

        [Required(ErrorMessage = "La identificación es requerida")]
        [StringLength(30)]
        public string Identificacion { get; set; } = string.Empty;

        [Required(ErrorMessage = "El teléfono es requerido")]
        [StringLength(10)]
        [RegularExpression(@"^\d{4}-\d{4}$", ErrorMessage = "Formato de teléfono inválido. Use: 0000-0000")]
        public string Telefono { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo es requerido")]
        [StringLength(50)]
        [EmailAddress(ErrorMessage = "Formato de correo inválido")]
        public string Correo { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "La dirección es requerida")]
        [StringLength(200)]
        public string Direccion { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal MontoTotal { get; set; }

        [Required(ErrorMessage = "La fecha del servicio es requerida")]
        public DateTime FechaDelServicio { get; set; }

        public DateTime FechaDeRegistro { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Debe seleccionar un servicio")]
        public int IdServicio { get; set; }

        // Propiedad de navegación
        [ForeignKey("IdServicio")]
        public virtual Servicio? Servicio { get; set; }
    }
}