using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Facturacion.Data.Models
{
    [Table("FacturasH")]
    public partial class FacturasH
    {
        public FacturasH()
        {
            FacturasDs = new HashSet<FacturasD>();
        }

        [Key]
        public int NoFact { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FechaGen { get; set; }
        [Column(TypeName = "date")]
        public DateTime Fecha { get; set; }
        public short IdCliente { get; set; }
        [Column(TypeName = "money")]
        public decimal Monto { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string? SecFiscal { get; set; }
        public bool Pagada { get; set; }
        public byte IdTipoFiscal { get; set; }

        [ForeignKey(nameof(IdCliente))]
        [InverseProperty(nameof(Cliente.FacturasHes))]
        public virtual Cliente IdClienteNavigation { get; set; } = null!;
        [InverseProperty(nameof(FacturasD.NoFactNavigation))]
        public virtual ICollection<FacturasD> FacturasDs { get; set; }
    }
}
