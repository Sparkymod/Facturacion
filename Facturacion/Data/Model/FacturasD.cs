using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facturacion.Data.Model
{
    public class FacturasD
    {
        [Required]
        public int Rno { get; set; }
        [Required]
        [ForeignKey("FacturaH")]
        public int NoFact { get; set; }
        [Required]
        [ForeignKey("Facturables")]
        public int IdFact { get; set; }
        [Required]
        public short IdTipoFact { get; set; }
        [Required]
        [MaxLength(50)]
        public string NombreEsp { get; set; } = "";
        [Required]
        public string NombreIng { get; set; } = "";
        [Required]
        [Column(TypeName = "Numeric(7,2)")]
        public decimal PrecioRD { get; set; }
        [Required]
        public short Cantidad { get; set; }
    }
}
