using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facturacion.Data.Model
{
    public class Clientes
    {
        [Required]
        public short IdCliente { get; set; }

        [Required]
        [ForeignKey("Tipos_Clientes")]
        public byte IdTipoCliente { get; set; }

        [Required]
        [MaxLength(80)]
        public string Nombre { get; set; } = "";

        [MaxLength(80)]
        public string Contacto { get; set; } = "";

        [MaxLength(15)]
        public string Telefono { get; set; } = "";

        [MaxLength(15)]
        public string Celular { get; set; } = "";

        [Required]
        [MaxLength(80)]
        public string Email { get; set; } = "";

        [MaxLength(90)]
        public string Email2 { get; set; } = "";

        [MaxLength(90)]
        public string Email3 { get; set; } = "";

        [MaxLength(250)]
        public string Direccion { get; set; } = "";

        [MaxLength(15)]
        public string Rnc_Ced { get; set; } = "";

        [Required]
        public bool Activo { get; set; }

        [Required]
        public bool Fiscal { get; set; }

        [Required]
        [ForeignKey("Monedas")]
        public byte Id_Moneda { get; set; }

        [Required]
        [ForeignKey("Lista_Precios")]
        public byte IdListaPrecio { get; set; }

        [Required]
        [ForeignKey("DiasCredito")]
        public byte Id_DiasCredit { get; set; }

        [Required]
        [Column(TypeName = "money(19, 4)")]
        public decimal LineaCredito { get; set; }
    }
}
