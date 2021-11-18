using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Facturacion.Data.Models
{
    public partial class Moneda
    {
        public Moneda()
        {
            Clientes = new HashSet<Cliente>();
        }

        [Key]
        public byte IdMoneda { get; set; }
        [Column("Moneda")]
        [StringLength(10)]
        [Unicode(false)]
        public string Moneda1 { get; set; } = null!;

        [InverseProperty(nameof(Cliente.IdMonedaNavigation))]
        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
