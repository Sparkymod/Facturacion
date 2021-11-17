using System.ComponentModel.DataAnnotations;

namespace Facturacion.Data.Model
{
    public class FacturaD
    {
        [Required]
        public int Rno { get; set; }
        [Required]
        public int NoFact { get; set; }
        [Required]
        public int IdFact { get; set; }
        [Required]
        public short IdTipoFact { get; set; }
        [Required]
        public string NombreEsp { get; set; } = "";
        [Required]
        public string NombreEng { get; set; } = "";
        [Required]
        public decimal PrecioRD { get; set; }
        [Required]
        public short Cantidad { get; set; }
    }
}
