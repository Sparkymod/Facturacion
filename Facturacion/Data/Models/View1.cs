using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Facturacion.Data.Models
{
    [Keyless]
    public partial class View1
    {
        public short IdFacturable { get; set; }
        [Column("Tipo Facturable")]
        [StringLength(20)]
        [Unicode(false)]
        public string TipoFacturable { get; set; } = null!;
        [Column("Nombre_Esp")]
        [StringLength(50)]
        [Unicode(false)]
        public string NombreEsp { get; set; } = null!;
        [Column("Precio_1", TypeName = "money")]
        public decimal Precio1 { get; set; }
        [Column("Precio_2", TypeName = "money")]
        public decimal Precio2 { get; set; }
        [Column("Precio_3", TypeName = "money")]
        public decimal Precio3 { get; set; }
    }
}
