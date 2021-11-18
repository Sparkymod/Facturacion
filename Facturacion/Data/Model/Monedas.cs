using System.ComponentModel.DataAnnotations;

namespace Facturacion.Data.Model
{
    public class Monedas
    {
        [Required]
        public byte IdMoneda { get; set; }

        [Required]
        [MaxLength(10)]
        public string Moneda { get; set; } = "";
    }
}
