using System.ComponentModel.DataAnnotations;

namespace Facturacion.Data.Model
{
    public class Lista_Precios
    {
        [Required]
        public byte IdListaPrecio { get; set; }

        [Required]
        [MaxLength(20)]
        public string Descripcion { get; set; } = "";
    }
}
