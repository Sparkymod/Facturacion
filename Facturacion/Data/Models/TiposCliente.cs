using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Facturacion.Data.Models
{
    [Table("Tipos_Clientes")]
    public partial class TiposCliente
    {
        public TiposCliente()
        {
            Clientes = new HashSet<Cliente>();
        }

        [Key]
        public byte IdTipoCliente { get; set; }
        [Column("Tipo Cliente")]
        [StringLength(20)]
        [Unicode(false)]
        public string TipoCliente { get; set; } = null!;

        [InverseProperty(nameof(Cliente.IdTipoClienteNavigation))]
        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
