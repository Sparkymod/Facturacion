using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Facturacion.Data.Models
{
    [Table("TiposFiscal")]
    public partial class TiposFiscal
    {
        [Key]
        public byte IdTipoFiscal { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string TipoFiscal { get; set; } = null!;
    }
}
