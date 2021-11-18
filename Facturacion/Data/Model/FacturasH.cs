using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facturacion.Data.Model
{
    public class FacturasH
    {
        [Required]
        public int NoFact { get; set; }
        [Required]
        public DateTime FechaGen { get; set; }
        [Required]
        public DateTime FechaFact { get; set; }
        [Required]
        [ForeignKey("TiposFacturable")]
        public byte TipoFact { get; set; }
        [Required]
        [ForeignKey("Clientes")]
        public short IdCliente { get; set; }
        [Required]
        [Column(TypeName = "money(19, 4)")]
        public decimal Monto { get; set; }
        [MaxLength(20)]
        public string SecFiscal { get; set; } = "";
        [Required]
        public bool Pagada { get; set; }
    }
}
