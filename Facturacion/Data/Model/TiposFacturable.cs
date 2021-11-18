using System.ComponentModel.DataAnnotations;

namespace Facturacion.Data.Model
{
    public class TiposFacturable
    {
        [Required]
        public byte Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string TipoFacturable { get; set; } = "";
    }
}
