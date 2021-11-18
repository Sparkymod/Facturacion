using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Facturacion.Data.Models
{
    [Table("Lista_Precios")]
    public partial class ListaPrecio
    {
        public ListaPrecio()
        {
            Clientes = new HashSet<Cliente>();
        }

        [Key]
        public byte IdListaPrecio { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string Descripcion { get; set; } = null!;

        [InverseProperty(nameof(Cliente.IdListaPrecioNavigation))]
        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
