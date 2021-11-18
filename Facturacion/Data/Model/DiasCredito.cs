using System.ComponentModel.DataAnnotations;

namespace Facturacion.Data.Model
{
    public class DiasCredito
    {
        [Required]
        public byte IdDiasCredito { get;set; }

        [Required]
        [MaxLength(20)]
        public string Descripcion { get; set; } = "";

        [Required]
        public byte Dias { get; set; }
    }
}
