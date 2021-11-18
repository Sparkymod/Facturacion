using System.ComponentModel.DataAnnotations;

namespace Facturacion.Data.Model
{
    public class Tipos_Clientes
    {
        [Required]
        public byte IdTipoClientes { get; set; }

        [MaxLength(20)]
        public string TipoCliente { get; set; } = "";
    }
}
