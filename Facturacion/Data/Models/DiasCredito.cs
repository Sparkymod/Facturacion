using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Facturacion.Data.Models
{
    [Table("DiasCredito")]
    public partial class DiasCredito
    {
        public DiasCredito()
        {
            Clientes = new HashSet<Cliente>();
        }

        [Key]
        public byte IdDiasCredito { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string Descripcion { get; set; } = null!;
        public byte Dias { get; set; }

        [InverseProperty(nameof(Cliente.IdDiasCreditoNavigation))]
        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
