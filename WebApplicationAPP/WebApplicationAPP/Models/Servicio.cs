using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplicationAPP.Models
{
    [Table("SERVICIOS_G2")]
    public class Servicio
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public decimal Monto { get; set; }

        public decimal IVA { get; set; }

        public int AreaServicio { get; set; }

        public string Encargado { get; set; }

        public string Sucursal { get; set; }

        public DateTime FechaDeRegistro { get; set; }

        public DateTime? FechaDeModificacion { get; set; }

        public bool Estado { get; set; }


    }
}
