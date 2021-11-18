using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Facturacion.Data.Models
{
    public partial class TiposFacturable
    {
        public TiposFacturable()
        {
            Facturables = new HashSet<Facturable>();
            FacturasDs = new HashSet<FacturasD>();
        }

        [Key]
        public byte Id { get; set; }
        [Column("Tipo Facturable")]
        [StringLength(20)]
        [Unicode(false)]
        public string TipoFacturable { get; set; } = null!;

        [InverseProperty(nameof(Facturable.IdTipoFactuableNavigation))]
        public virtual ICollection<Facturable> Facturables { get; set; }
        [InverseProperty(nameof(FacturasD.IdTipoFacturableNavigation))]
        public virtual ICollection<FacturasD> FacturasDs { get; set; }
    }
}
