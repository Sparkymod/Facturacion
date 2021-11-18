using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Facturacion.Data.Models
{
    [Table("SecFiscal")]
    public partial class SecFiscal
    {
        [Key]
        public short Rno { get; set; }
        [Column(TypeName = "date")]
        public DateTime Fecha { get; set; }
        [Column(TypeName = "numeric(8, 0)")]
        public decimal Inicio { get; set; }
        [Column(TypeName = "numeric(8, 0)")]
        public decimal Final { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string Valor { get; set; } = null!;
    }
}
