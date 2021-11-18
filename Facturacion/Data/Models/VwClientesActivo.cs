using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Facturacion.Data.Models
{
    [Keyless]
    public partial class VwClientesActivo
    {
        public short IdCliente { get; set; }
        [StringLength(80)]
        [Unicode(false)]
        public string Nombre { get; set; } = null!;
    }
}
