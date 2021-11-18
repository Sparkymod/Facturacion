using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Facturacion.Data.Models
{
    public partial class Facturable
    {
        public Facturable()
        {
            FacturasDs = new HashSet<FacturasD>();
            PacientesFacturables = new HashSet<PacientesFacturable>();
        }

        [Key]
        public short IdFacturable { get; set; }
        public byte IdTipoFactuable { get; set; }
        [Column("Nombre_Esp")]
        [StringLength(50)]
        [Unicode(false)]
        public string NombreEsp { get; set; } = null!;
        [Column("Nombre_Ing")]
        [StringLength(50)]
        [Unicode(false)]
        public string NombreIng { get; set; } = null!;
        [Column("Precio_1", TypeName = "money")]
        public decimal Precio1 { get; set; }
        [Column("Precio_2", TypeName = "money")]
        public decimal Precio2 { get; set; }
        [Column("Precio_3", TypeName = "money")]
        public decimal Precio3 { get; set; }
        [Required]
        public bool? Activo { get; set; }

        [ForeignKey(nameof(IdTipoFactuable))]
        [InverseProperty(nameof(TiposFacturable.Facturables))]
        public virtual TiposFacturable IdTipoFactuableNavigation { get; set; } = null!;
        [InverseProperty(nameof(FacturasD.IdFacturableNavigation))]
        public virtual ICollection<FacturasD> FacturasDs { get; set; }
        [InverseProperty(nameof(PacientesFacturable.IdFacturableNavigation))]
        public virtual ICollection<PacientesFacturable> PacientesFacturables { get; set; }
    }
}
