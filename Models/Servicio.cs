using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationAPP.Models
{
    [Table("Servicios_G2")]
    public class Servicio
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripción es requerida")]
        [StringLength(200)]
        public string Descripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = "El monto es requerido")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor a 0")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "El IVA es requerido")]
        [Range(0, 1, ErrorMessage = "El IVA debe estar entre 0 y 1")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal IVA { get; set; }

        [Required(ErrorMessage = "El área de servicio es requerida")]
        [Range(1, 3, ErrorMessage = "Área de servicio inválida")]
        public int AreaServicio { get; set; }

        [Required(ErrorMessage = "El encargado es requerido")]
        [StringLength(200)]
        public string Encargado { get; set; } = string.Empty;

        [Required(ErrorMessage = "La sucursal es requerida")]
        [StringLength(100)]
        public string Sucursal { get; set; } = string.Empty;

        public DateTime FechaDeRegistro { get; set; } = DateTime.Now;

        public DateTime? FechaDeModificacion { get; set; }

        public bool Estado { get; set; } = true;

        // Propiedad de navegación
        public virtual ICollection<Reserva>? Reservas { get; set; }
    }
}