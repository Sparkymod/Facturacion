using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Facturacion.Data.Models
{
    [Table("FacturasD")]
    public partial class FacturasD
    {
        [Key]
        public int Rno { get; set; }
        public int NoFact { get; set; }
        [Column("Id_Facturable")]
        public short IdFacturable { get; set; }
        [Column("Id_TipoFacturable")]
        public byte IdTipoFacturable { get; set; }
        [Column("Nombre_Esp")]
        [StringLength(50)]
        [Unicode(false)]
        public string NombreEsp { get; set; } = null!;
        [Column("Nombre_Eng")]
        [MaxLength(50)]
        public byte[] NombreEng { get; set; } = null!;
        [Column("Precio_RD", TypeName = "numeric(7, 2)")]
        public decimal PrecioRd { get; set; }
        public byte Cantidad { get; set; }

        [ForeignKey(nameof(IdFacturable))]
        [InverseProperty(nameof(Facturable.FacturasDs))]
        public virtual Facturable IdFacturableNavigation { get; set; } = null!;
        [ForeignKey(nameof(IdTipoFacturable))]
        [InverseProperty(nameof(TiposFacturable.FacturasDs))]
        public virtual TiposFacturable IdTipoFacturableNavigation { get; set; } = null!;
        [ForeignKey(nameof(NoFact))]
        [InverseProperty(nameof(FacturasH.FacturasDs))]
        public virtual FacturasH NoFactNavigation { get; set; } = null!;
    }
}
