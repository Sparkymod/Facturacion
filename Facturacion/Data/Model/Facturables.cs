using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facturacion.Data.Model
{
    public class Facturables
    {
        [Required]
        public short IdFacturable { get; set; }
        [Required]
        [ForeignKey("TiposFacturable")]
        public string IdTipoFacturable { get; set; } = "";
        [Required]
        [MaxLength(50)]
        public string Nombre_Esp { get; set; } = "";
        [Required]
        [MaxLength(50)]
        public string Nombre_Ing { get; set; } = "";
        [Required]
        [Column(TypeName = "Money(19,4)")]
        public decimal Precio_1 { get; set; }
        [Required]
        [Column(TypeName = "Money(19,4)")]
        public decimal Precio_2 { get; set; }
        [Required]
        [Column(TypeName = "Money(19,4)")]
        public decimal Precio_3 { get; set; }
        [Required]
        public bool Activo { get; set; }
    }
}
