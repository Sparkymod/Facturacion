using System.ComponentModel.DataAnnotations;

namespace Facturacion.Data.Model
{
    public class FacturaH
    {
        [Required]
        public int NoFact { get; set; }
        [Required]
        public DateTime FechaGen { get; set; }
        [Required]
        public DateTime FechaFact { get; set; }
        [Required]
        public byte TipoFact { get; set; }
        [Required]
        public int IdCliente { get; set; }
        [Required]
        public decimal Monto { get; set; }
        [Required]
        public string SecFact { get; set; } = "";
        [Required]
        public bool Pagada { get; set; }
    }
}
